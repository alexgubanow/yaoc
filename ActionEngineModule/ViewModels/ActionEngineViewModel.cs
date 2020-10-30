using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using tae;
using tds;
using tev;

namespace ActionEngineModule.ViewModels
{
    class ActionEngineViewModel : BindableBase
    {
        private IEventAggregator _ea;
        public DelegateCommand CreateOnvifClientsCMD { get; private set; }
        ActionEngineViewModel(IEventAggregator ea)
        {
            _ea = ea;
            CreateOnvifClientsCMD = new DelegateCommand(CreateOnvifClients);            
        }
        private async void CreateOnvifClients()
        {
            if (System.Windows.Application.Current.Properties["Endpoint"] == null)
            {
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
            var TDSclient = new DeviceClient(binding,
                new EndpointAddress((string)System.Windows.Application.Current.Properties["Endpoint"]));
            var allCapabilitiesTask = TDSclient.GetCapabilitiesAsync(new CapabilityCategory[] { CapabilityCategory.All });
            await allCapabilitiesTask.ConfigureAwait(false);
            var mediaAddress = new EndpointAddress((string)System.Windows.Application.Current.Properties["Endpoint"]);
            var TEVclient = new EventPortTypeClient(binding, mediaAddress);
            var TAEclient = new ActionEnginePortClient(binding, mediaAddress);
            System.Windows.Application.Current.Properties["TAEclient"] = TAEclient;
            System.Windows.Application.Current.Properties["TEVclient"] = TEVclient;
            System.Windows.Application.Current.Properties["TDSclient"] = TDSclient;
        }
    }
}
