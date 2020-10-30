using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Xml.Linq;
using System.Xml.Serialization;
using tae;

namespace ActionEngineModule.ViewModels
{
    public class CreateTriggerEvent : PubSubEvent<ActionTriggerConfiguration> { }
    public class ModifyTriggerEvent : PubSubEvent<ActionTrigger> { }
    public class EditTriggerViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        public DelegateCommand<object> OkCMD { get; private set; }
        public DelegateCommand<object> CloseCMD { get; private set; }

        private string _Topic;
        public string Topic
        {
            get { return _Topic; }
            set { SetProperty(ref _Topic, value); }
        }
        private string _Token;
        public string Token
        {
            get { return _Token; }
            set { SetProperty(ref _Token, value); }
        }
        private bool _IsNew;
        public bool IsNew
        {
            get { return _IsNew; }
            set { SetProperty(ref _IsNew, value); }
        }
        EditTriggerViewModel(IEventAggregator ea)
        {
            _eventAggregator = ea;
            OkCMD = new DelegateCommand<object>(Create);
            CloseCMD = new DelegateCommand<object>(Close);
        }
        public static System.Xml.XmlNode[] SerializeToXmlElement(object o)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            using (System.Xml.XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                new XmlSerializer(o.GetType()).Serialize(writer, o);
            }
            return new System.Xml.XmlNode[1] { doc.DocumentElement.LastChild };
        }
        private void Create(object sender)
        {
            if (IsNew)
            {
                ActionTriggerConfiguration item =
                            new ActionTriggerConfiguration()
                            {
                                TopicExpression = new TopicExpressionType()
                                {
                                    Any = SerializeToXmlElement(Topic),
                                    Dialect = "http://docs.oasis-open.org/wsn/t-1/TopicExpression/ConcreteSet"
                                }
                            };
                _eventAggregator.GetEvent<CreateTriggerEvent>().Publish(item);
            }
            else
            {
                ActionTrigger item =
                            new ActionTrigger()
                            {
                                Configuration = new ActionTriggerConfiguration() {
                                    TopicExpression = new TopicExpressionType()
                                    {
                                        Any = SerializeToXmlElement(Topic),
                                        Dialect = "http://docs.oasis-open.org/wsn/t-1/TopicExpression/ConcreteSet"
                                    }
                                },
                                Token = Token
                            };
                _eventAggregator.GetEvent<ModifyTriggerEvent>().Publish(item);
            }
            Close(sender);
        }
        private void Close(object sender)
        {
            _eventAggregator.GetEvent<Events.CloseDialogEvent>().Publish(sender);
        }
    }
}
