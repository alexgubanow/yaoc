using Prism.Mvvm;
using System.IO;
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
        private string _UploadPath;
        public string UploadPath
        {
            get { return _UploadPath; }
            set { SetProperty(ref _UploadPath, value); }
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
                        UploadPath = UploadPath
                    }
                },
            };
            var FtpContent = new FtpContentConfiguration()
            {
                Type = "File",
                Item = new FtpContentConfigurationUploadFile() { destinationFileName = DestinationFileName }
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
        public void ParseItemList(ItemList paramList)
        {
            foreach (var item in paramList.ElementItem)
            {
                if (item.Name == "Destinations")
                {
                    object Destinations = new FtpHostConfigurations();
                    XML.XmlElementToObject(item.Any.OuterXml, ref Destinations);
                    if (Destinations != null)
                    {
                        Host = (Destinations as FtpHostConfigurations).FtpDestination[0].HostAddress.Value;
                        Port = (Destinations as FtpHostConfigurations).FtpDestination[0].HostAddress.portNo;
                        UploadPath = (Destinations as FtpHostConfigurations).FtpDestination[0].UploadPath;
                        Username = (Destinations as FtpHostConfigurations).FtpDestination[0].FtpAuthentication.User.username;
                        Passwd = Encoding.ASCII.GetString((Destinations as FtpHostConfigurations).FtpDestination[0].FtpAuthentication.User.password);
                    }
                }
                else if (item.Name == "FtpContent")
                {
                    object FtpContent = new FtpContentConfiguration();
                    XML.XmlElementToObject(item.Any.OuterXml, ref FtpContent);
                    if (FtpContent != null && (FtpContent as FtpContentConfiguration).Type == "File")
                    {
                        DestinationFileName = ((FtpContent as FtpContentConfiguration).Item as FtpContentConfigurationUploadFile).destinationFileName;
                    }

                }
            }
        }
    }
}
