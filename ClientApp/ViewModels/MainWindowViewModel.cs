using Prism.Events;
using Prism.Mvvm;

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

        public MainWindowViewModel(IEventAggregator ea)
        {
            System.Windows.Application.Current.Properties["Endpoint"] = "http://127.0.0.1:8080/onvif/device_service";
            ea.GetEvent<Events.NewStatusEvent>().Subscribe((value) => StatusTXT = value);
        }
    }
}
