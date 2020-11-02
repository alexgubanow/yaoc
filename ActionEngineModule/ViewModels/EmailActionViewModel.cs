using Prism.Mvvm;
using System;
using System.Text;
using System.Xml.Serialization;
using tae;
using utils;

namespace ActionEngineModule.ViewModels
{
    public class EmailActionViewModel : BindableBase
    {
        private string _SMTPServer = "";
        public string SMTPServer
        {
            get { return _SMTPServer; }
            set { SetProperty(ref _SMTPServer, value); ParametersReference = GetItemList(); }
        }
        private string _SMTPUser = "";
        public string SMTPUser
        {
            get { return _SMTPUser; }
            set { SetProperty(ref _SMTPUser, value); ParametersReference = GetItemList(); }
        }
        private string _SMTPPassword = "";
        public string SMTPPassword
        {
            get { return _SMTPPassword; }
            set { SetProperty(ref _SMTPPassword, value); ParametersReference = GetItemList(); }
        }
        private string _DestinationEmail = "";
        public string DestinationEmail
        {
            get { return _DestinationEmail; }
            set { SetProperty(ref _DestinationEmail, value); ParametersReference = GetItemList(); }
        }
        private string _SenderEmail = "";
        public string SenderEmail
        {
            get { return _SenderEmail; }
            set { SetProperty(ref _SenderEmail, value); ParametersReference = GetItemList(); }
        }
        private string _Topic = "";
        public string Topic
        {
            get { return _Topic; }
            set { SetProperty(ref _Topic, value); ParametersReference = GetItemList(); }
        }
        private string _Message = "";
        public string Message
        {
            get { return _Message; }
            set { SetProperty(ref _Message, value); ParametersReference = GetItemList(); }
        }
        private ItemList _ParametersReference;
        public ItemList ParametersReference
        {
            get { return _ParametersReference; }
            set { SetProperty(ref _ParametersReference, value); }
        }

        public EmailActionViewModel()
        {
        }
        public ItemList GetItemList()
        {
            var Destinations = new EMailServerConfiguration()
            {
                SMTPConfig = new SMTPConfig()
                {
                    HostAddress = new HostAddress() { Value = SMTPServer, formatType = AddressFormatType.ipv4 }
                },
                AuthenticationConfig = new AuthenticationConfig()
                {
                    User = new UserCredentials() { username = SMTPUser, password = Encoding.ASCII.GetBytes(SMTPPassword) }
                }
            };
            var Receivers = new EMailReceiverConfiguration()
            {
                TO = DestinationEmail.Split(',')
            };
            var Body = new EMailBodyTextConfiguration()
            {
                type = Message
            };
            return new ItemList
            {
                SimpleItem = new ItemListSimpleItem[2]
            {
                new ItemListSimpleItem() { Name = "Sender", Value = SenderEmail },
                new ItemListSimpleItem() { Name = "Subject", Value = Topic }
            },
                ElementItem = new ItemListElementItem[3]
            {
                new ItemListElementItem() { Name = "Destinations", Any = XML.ToXmlElement(Destinations)},
                new ItemListElementItem() { Name = "Receivers", Any = XML.ToXmlElement(Receivers)},
                new ItemListElementItem() { Name = "Body", Any = XML.ToXmlElement(Body)}
            }
            };
        }

        public void ParseItemList(ItemList parameters)
        {
            foreach (var item in parameters.SimpleItem)
            {
                if (item.Name == "Sender")
                {
                    SenderEmail = item.Value;
                }
                else if (item.Name == "Subject")
                {
                    Topic = item.Value;
                }
            }
            foreach (var item in parameters.ElementItem)
            {
                if (item.Name == "Destinations")
                {
                    object obj = new EMailServerConfiguration();
                    XML.XmlElementToObject(item.Any.OuterXml, ref obj);
                    if (obj != null)
                    {
                        SMTPServer = (obj as EMailServerConfiguration).SMTPConfig.HostAddress.Value;
                        SMTPUser = (obj as EMailServerConfiguration).AuthenticationConfig.User.username;
                        SMTPPassword = Encoding.ASCII.GetString((obj as EMailServerConfiguration).AuthenticationConfig.User.password);
                    }
                }
                else if (item.Name == "Receivers")
                {
                    object obj = new EMailReceiverConfiguration();
                    XML.XmlElementToObject(item.Any.OuterXml, ref obj);
                    if (obj != null)
                    {
                        DestinationEmail = string.Join(",", (obj as EMailReceiverConfiguration).TO);
                    }
                }
                else if (item.Name == "Body")
                {
                    object obj = new EMailBodyTextConfiguration();
                    XML.XmlElementToObject(item.Any.OuterXml, ref obj);
                    if (obj != null)
                    {
                        Message = (obj as EMailBodyTextConfiguration).type;
                    }
                }
            }
        }
    }
}
