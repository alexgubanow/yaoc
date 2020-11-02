using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows;
using System.Xml;
using tae;
using tds;
using tev;

namespace ClientApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Yet Another Onvif Client";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _StatusTXT;
        public string StatusTXT
        {
            get { return _StatusTXT; }
            set { SetProperty(ref _StatusTXT, value); }
        }
        private Visibility _TabsVisibility = Visibility.Collapsed;
        public Visibility TabsVisibility
        {
            get { return _TabsVisibility; }
            set { SetProperty(ref _TabsVisibility, value); }
        }
        public string Endpoint
        {
            get => (string)System.Windows.Application.Current.Properties["Endpoint"];
            set
            {
                System.Windows.Application.Current.Properties["Endpoint"] = value; string tmp = "";
                SetProperty(ref tmp, value);
            }
        }
        public string User
        {
            get => (string)System.Windows.Application.Current.Properties["User"];
            set
            {
                System.Windows.Application.Current.Properties["User"] = value; string tmp = "";
                SetProperty(ref tmp, value);
            }
        }
        public string Password
        {
            get => (string)System.Windows.Application.Current.Properties["Password"];
            set
            {
                System.Windows.Application.Current.Properties["Password"] = value; string tmp = "";
                SetProperty(ref tmp, value);
            }
        }
        public DelegateCommand ConnectCMD { get; private set; }

        public MainWindowViewModel(IEventAggregator ea)
        {
            Endpoint = "http://127.0.0.1:8080/onvif/device_service";
            ea.GetEvent<Events.NewStatusEvent>().Subscribe((value) => StatusTXT = value);
            ConnectCMD = new DelegateCommand(CreateOnvifClients);
        }
        private async void CreateOnvifClients()
        {
            if (Endpoint.Length == 0)
            {
                TabsVisibility = Visibility.Collapsed;
                return;
            }
            var messageElement = new TextMessageEncodingBindingElement
            {
                MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.WSAddressing10)
            };
            var httpBinding = new HttpTransportBindingElement
            {
                AuthenticationScheme = AuthenticationSchemes.Digest
            };
            var binding = new CustomBinding(messageElement, httpBinding);
            var TDSclient = new DeviceClient(binding, new EndpointAddress(Endpoint));
            var allCapabilitiesTask = TDSclient.GetCapabilitiesAsync(new CapabilityCategory[] { CapabilityCategory.All });
            await allCapabilitiesTask.ConfigureAwait(false);
            var mediaAddress = new EndpointAddress(Endpoint);
            var TEVclient = new EventPortTypeClient(binding, mediaAddress);
            var TAEclient = new ActionEnginePortClient(binding, mediaAddress);

            var task = TAEclient.GetSupportedActionsAsync();
            await task.ConfigureAwait(false);
            XmlQualifiedName[] tmp = new XmlQualifiedName[task.Result.ActionDescription.Length];
            for (int i = 0; i < task.Result.ActionDescription.Length; i++)
            {
                tmp[i] = task.Result.ActionDescription[i].Name;
            }
            System.Windows.Application.Current.Properties["SupportedActions"] = tmp;
            System.Windows.Application.Current.Properties["TAEclient"] = TAEclient;
            System.Windows.Application.Current.Properties["TEVclient"] = TEVclient;
            System.Windows.Application.Current.Properties["TDSclient"] = TDSclient;
            TabsVisibility = Visibility.Visible;
        }
    }
}
