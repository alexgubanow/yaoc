using Prism.Mvvm;
using System.Text;
using tae;
using utils;

namespace ActionEngineModule.ViewModels
{
    public class FtpActionViewModel : BindableBase
    {
        private string _Port;
        public string Port
        {
            get { return _Port; }
            set { SetProperty(ref _Port, value); }
        }
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set { SetProperty(ref _Username, value); }
        }
        private string _Passwd;
        public string Passwd
        {
            get { return _Passwd; }
            set { SetProperty(ref _Passwd, value); }
        }
        private string _Host;
        public string Host
        {
            get { return _Host; }
            set { SetProperty(ref _Host, value); }
        }
        private string _DestinationFileName;
        public string DestinationFileName
        {
            get { return _DestinationFileName; }
            set { SetProperty(ref _DestinationFileName, value); }
        }
        public FtpActionViewModel()
        {
        }
        public ItemList GetItemList()
        {
            var Destinations = new FtpHostConfigurations()
            {
                FtpDestination = new FtpDestinationConfiguration[1] {
                    new FtpDestinationConfiguration(){
                        FtpAuthentication = new FtpAuthenticationConfiguration() {
                            User = new UserCredentials(){ username = Username, password= Encoding.ASCII.GetBytes(Passwd)} } ,
                        HostAddress = new FtpHostAddress(){ Value = Host, portNo = Port, formatType = AddressFormatType.ipv4 },
                        UploadPath = DestinationFileName
                    }
                },
            };
            var FtpContent = new FtpContentConfiguration()
            {
                Type = "File",
                Item = new FtpContentConfigurationUploadFile()
            };
            return new ItemList
            {
                ElementItem = new ItemListElementItem[2]
            {
                new ItemListElementItem() { Name = "Destinations", Any = XML.ToXmlElement(Destinations)},
                new ItemListElementItem() { Name = "FtpContent", Any = XML.ToXmlElement(FtpContent)}
            }
            };
        }
    }
}
