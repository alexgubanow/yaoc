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
    public class TriggersUPDEvent : PubSubEvent<Trigger[]> { }
    class ActionEngineViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        private ActionEnginePortClient actionEngineClient;
        private ObservableCollection<Trigger> _Triggers;
        public ObservableCollection<Trigger> Triggers
        {
            get { return _Triggers; }
            set { SetProperty(ref _Triggers, value); }
        }

        public DelegateCommand<Trigger> EditTriggerCMD { get; private set; }
        public DelegateCommand<Trigger> DeleteTriggerCMD { get; private set; }
        public DelegateCommand CreateTriggerCMD { get; private set; }
        public DelegateCommand UpdateCMD { get; private set; }

        private static object _lock = new object();
        ActionEngineViewModel(IEventAggregator ea)
        {
            _eventAggregator = ea;
            EditTriggerCMD = new DelegateCommand<Trigger>(EditTrigger);
            DeleteTriggerCMD = new DelegateCommand<Trigger>(DeleteTrigger);
            CreateTriggerCMD = new DelegateCommand(CreateTrigger);
            UpdateCMD = new DelegateCommand(UpdateTriggersList);
            Triggers = new ObservableCollection<Trigger>();
            BindingOperations.EnableCollectionSynchronization(Triggers, _lock);
            ea.GetEvent<TriggersUPDEvent>().Subscribe((value) => { Triggers.Clear(); Triggers.AddRange(value); });
            if (System.Windows.Application.Current.Properties["Endpoint"] == null)
            {
                return;
            }
            var messageElement = new TextMessageEncodingBindingElement
            {
                MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None)
            };
            var httpBinding = new HttpTransportBindingElement
            {
                AuthenticationScheme = AuthenticationSchemes.Basic
            };
            var mediaAddress = new EndpointAddress((string)System.Windows.Application.Current.Properties["Endpoint"]);
            actionEngineClient = new ActionEnginePortClient(new CustomBinding(messageElement, httpBinding), mediaAddress);
            actionEngineClient.ClientCredentials.UserName.UserName = "admin";
            actionEngineClient.ClientCredentials.UserName.Password = "admin";
            UpdateTriggersList();
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
        private async void CreateTrigger()
        {
            if (actionEngineClient != null)
            {
                try
                {
                    //"tns1:RecordingConfig/JobState"
                    ActionTriggerConfiguration[] tmp = new ActionTriggerConfiguration[1] {
                        new ActionTriggerConfiguration() { TopicExpression = new TopicExpressionType() { 
                            Any = SerializeToXmlElement("tns1:RecordingConfig/JobState"),
                            Dialect = "http://docs.oasis-open.org/wsn/t-1/TopicExpression/ConcreteSet" } } };
                    var task = actionEngineClient.CreateActionTriggersAsync(new CreateActionTriggersRequest() { ActionTrigger = tmp });
                    await task.ConfigureAwait(false);
                    UpdateTriggersList();
                }
                catch (Exception ex)
                {
                    _eventAggregator.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
                }
            }
        }
        private async void EditTrigger(Trigger trigger)
        {
            if (trigger != null && actionEngineClient != null)
            {
                try
                {
                    ActionTrigger[] tmp = new ActionTrigger[1] { new ActionTrigger() };
                    var task = actionEngineClient.ModifyActionTriggersAsync(tmp);
                    await task.ConfigureAwait(false);
                    UpdateTriggersList();
                }
                catch (Exception ex)
                {
                    _eventAggregator.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
                }
            }
        }
        private async void DeleteTrigger(Trigger trigger)
        {
            if (trigger != null && actionEngineClient != null)
            {
                try
                {
                    string[] tmp = new string[1] { trigger.Token };
                    var task = actionEngineClient.DeleteActionTriggersAsync(tmp);
                    await task.ConfigureAwait(false);
                    UpdateTriggersList();
                }
                catch (Exception ex)
                {
                    _eventAggregator.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
                }
            }
        }
        private async void UpdateTriggersList()
        {
            try
            {
                var GetActionTriggersTask = actionEngineClient.GetActionTriggersAsync();
                await GetActionTriggersTask.ConfigureAwait(false);
                _eventAggregator.GetEvent<TriggersUPDEvent>().Publish(ActionTriggerToTrigger(GetActionTriggersTask.Result.ActionTrigger));
            }
            catch (Exception ex)
            {
                _eventAggregator.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
            }
        }

        private Trigger[] ActionTriggerToTrigger(ActionTrigger[] ActionTriggers)
        {
            Trigger[] tmp = new Trigger[ActionTriggers.Length];
            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = new Trigger
                {
                    Token = ActionTriggers[i].Token
                };
                if (ActionTriggers[i].Configuration != null)
                {
                    if (ActionTriggers[i].Configuration.TopicExpression != null)
                    {
                        foreach (var expr in ActionTriggers[i].Configuration.TopicExpression.Any)
                        {
                            tmp[i].TopicExpression = expr.InnerText;
                        }
                        tmp[i].TopicExpressionDialect = ActionTriggers[i].Configuration.TopicExpression.Dialect;
                    }
                    if (ActionTriggers[i].Configuration.ContentExpression != null)
                    {
                        foreach (var expr in ActionTriggers[i].Configuration.ContentExpression.Any)
                        {
                            tmp[i].ContentExpression = expr.InnerText;
                        }
                        tmp[i].ContentExpressionDialect = ActionTriggers[i].Configuration.ContentExpression.Dialect;
                    }
                    tmp[i].ActionTokens = ActionTriggers[i].Configuration.ActionToken;
                }
            }
            return tmp;
        }
    }
}
