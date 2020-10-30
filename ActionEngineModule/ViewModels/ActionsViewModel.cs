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
    public class ActionsUPDEvent : PubSubEvent<tae.Action[]> { }
    class ActionsViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        private ActionEnginePortClient actionEngineClient;
        private ObservableCollection<tae.Action> _Actions;
        public ObservableCollection<tae.Action> Actions
        {
            get { return _Actions; }
            set { SetProperty(ref _Actions, value); }
        }

        public DelegateCommand<tae.Action> EditCMD { get; private set; }
        public DelegateCommand<tae.Action> DeleteCMD { get; private set; }
        public DelegateCommand CreateCMD { get; private set; }
        public DelegateCommand UpdateCMD { get; private set; }

        private static readonly object _lock = new object();
        ActionsViewModel(IEventAggregator ea)
        {
            _eventAggregator = ea;
            EditCMD = new DelegateCommand<tae.Action>(Edit);
            DeleteCMD = new DelegateCommand<tae.Action>(Delete);
            CreateCMD = new DelegateCommand(Create);
            UpdateCMD = new DelegateCommand(UpdateList);
            Actions = new ObservableCollection<tae.Action>();
            BindingOperations.EnableCollectionSynchronization(Actions, _lock);
            ea.GetEvent<ActionsUPDEvent>().Subscribe((value) => { Actions.Clear(); Actions.AddRange(value); });
            while (System.Windows.Application.Current.Properties["AEclient"] == null)
            {

            }
            actionEngineClient = (ActionEnginePortClient)System.Windows.Application.Current.Properties["AEclient"];
            //UpdateList();
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
        private async void Create()
        {
            if (actionEngineClient != null)
            {
                try
                {
                    ActionTriggerConfiguration[] tmp = new ActionTriggerConfiguration[1] {
                        new ActionTriggerConfiguration() { TopicExpression = new TopicExpressionType() {
                            Any = SerializeToXmlElement("tns1:RecordingConfig/JobState"),
                            Dialect = "http://docs.oasis-open.org/wsn/t-1/TopicExpression/ConcreteSet" } } };
                    var task = actionEngineClient.CreateActionTriggersAsync(new CreateActionTriggersRequest() { ActionTrigger = tmp });
                    await task.ConfigureAwait(false);
                    UpdateList();
                }
                catch (Exception ex)
                {
                    _eventAggregator.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
                }
            }
        }
        private async void Edit(tae.Action item)
        {
            if (item != null && actionEngineClient != null)
            {
                try
                {
                    ActionTrigger[] tmp = new ActionTrigger[1] { new ActionTrigger() };
                    var task = actionEngineClient.ModifyActionTriggersAsync(tmp);
                    await task.ConfigureAwait(false);
                    UpdateList();
                }
                catch (Exception ex)
                {
                    _eventAggregator.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
                }
            }
        }
        private async void Delete(tae.Action item)
        {
            if (item != null && actionEngineClient != null)
            {
                try
                {
                    string[] tmp = new string[1] { item.Token };
                    var task = actionEngineClient.DeleteActionTriggersAsync(tmp);
                    await task.ConfigureAwait(false);
                    UpdateList();
                }
                catch (Exception ex)
                {
                    _eventAggregator.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
                }
            }
        }
        private async void UpdateList()
        {
            try
            {
                var task = actionEngineClient.GetActionsAsync();
                await task.ConfigureAwait(false);
                _eventAggregator.GetEvent<ActionsUPDEvent>().Publish(task.Result.Action);
            }
            catch (Exception ex)
            {
                _eventAggregator.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
            }
        }
    }
}
