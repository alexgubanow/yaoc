using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using tae;
using tev;
using utils;

namespace ActionEngineModule.ViewModels
{
    public class CreateTriggerEvent : PubSubEvent<ActionTriggerConfiguration> { }
    public class ModifyTriggerEvent : PubSubEvent<ActionTrigger> { }
    public class DropDownCheckableItem
    {
        public bool IsChecked { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
    public class EditTriggerViewModel : BindableBase
    {
        private readonly IEventAggregator _ea;
        public DelegateCommand<object> OkCMD { get; private set; }
        public DelegateCommand<object> CloseCMD { get; private set; }
        public DelegateCommand TopicsItemCheckedCMD { get; private set; }
        public DelegateCommand ActionTokensItemCheckedCMD { get; private set; }
        public DelegateCommand LoadedCMD { get; private set; }
        private ActionEnginePortClient taeClient
        {
            get { return (ActionEnginePortClient)Application.Current.Properties["TAEclient"]; }
        }
        private EventPortTypeClient tevClient
        {
            get { return (EventPortTypeClient)Application.Current.Properties["TEVclient"]; }
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
        private string _TopicExpr;
        public string TopicExpr
        {
            set { SetProperty(ref _TopicExpr, value); }
            get { return _TopicExpr; }
        }
        private string[] _Actions = new string[0];
        public string[] Actions
        {
            set { SetProperty(ref _Actions, value); }
            get { return _Actions; }
        }
        private string _ContentExpr;
        public string ContentExpr
        {
            set { SetProperty(ref _ContentExpr, value); }
            get { return _ContentExpr; }
        }
        private ObservableCollection<DropDownCheckableItem> _Topics;
        public ObservableCollection<DropDownCheckableItem> Topics
        {
            get { return _Topics; }
            set { SetProperty(ref _Topics, value); }
        }
        private ObservableCollection<DropDownCheckableItem> _ActionTokens;
        public ObservableCollection<DropDownCheckableItem> ActionTokens
        {
            get { return _ActionTokens; }
            set { SetProperty(ref _ActionTokens, value); }
        }

        EditTriggerViewModel(IEventAggregator ea)
        {
            _ea = ea;
            OkCMD = new DelegateCommand<object>(Create);
            CloseCMD = new DelegateCommand<object>(Close);
            TopicsItemCheckedCMD = new DelegateCommand(TopicsToString);
            LoadedCMD = new DelegateCommand(OnLoaded);
        }
        private async void OnLoaded()
        {
            var rawTopics = new List<DropDownCheckableItem>();
            try
            {
                var task = tevClient.GetEventPropertiesAsync(new GetEventPropertiesRequest());
                await task.ConfigureAwait(false);
                Application.Current.Properties["EventProperties"] = task.Result;
            }
            catch (Exception ex)
            {
                _ea.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
            }
            foreach (var item in ((GetEventPropertiesResponse)System.Windows.Application.Current.Properties["EventProperties"]).TopicSet.Any)
            {
                rawTopics.Add(new DropDownCheckableItem() { IsChecked = false, Name = item.Name + "//." });
                foreach (XmlElement childTopic in item.ChildNodes)
                {
                    rawTopics.Add(new DropDownCheckableItem() { IsChecked = false, Name = item.Name + "/" + childTopic.Name });
                    foreach (XmlElement subChildTopic in childTopic.ChildNodes)
                    {
                        if (!subChildTopic.Name.StartsWith("tt:"))
                        {
                            rawTopics.Add(new DropDownCheckableItem()
                            {
                                IsChecked = false,
                                Name = item.Name + "/" + childTopic.Name + "/" + subChildTopic.Name
                            });
                        }
                    }
                }
            }
            Topics = new ObservableCollection<DropDownCheckableItem>(rawTopics);
            if (!IsNew)
            {
                SetUsedTopicsFromString(TopicExpr);
            }
            var list = new List<DropDownCheckableItem>();
            try
            {
                var task = taeClient.GetActionsAsync();
                await task.ConfigureAwait(false);
                Application.Current.Properties["ActionTokens"] = task.Result.Action;
            }
            catch (Exception ex)
            {
                _ea.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
            }
            foreach (var item in ((tae.Action[])Application.Current.Properties["ActionTokens"]))
            {
                list.Add(new DropDownCheckableItem() { IsChecked = false, Token = item.Token, Name = item.Configuration.Name });
            }
            ActionTokens = new ObservableCollection<DropDownCheckableItem>(list);
            if (!IsNew)
            {
                SetUsedActionsFromString(Actions);
            }
        }
        public void TopicsToString()
        {
            string b = "";
            foreach (var item in Topics.Where(item => item.IsChecked))
            {
                b += item.Name + '|';
            }
            if (b.Length > 0)
            {
                b = b.Remove(b.Length - 1);
            }
            TopicExpr = b;
        }
        public void SetUsedTopicsFromString(string value)
        {
            var usedTopics = value.Split('|');
            foreach (var item in usedTopics)
            {
                foreach (var topicFromList in from topicFromList in Topics
                                              where topicFromList.Name == item
                                              select topicFromList)
                {
                    topicFromList.IsChecked = true;
                }
            }
        }
        public void SetUsedActionsFromString(string[] value)
        {
            foreach (var item in value)
            {
                foreach (var list in from list in ActionTokens
                                     where list.Token == item
                                     select list)
                {
                    list.IsChecked = true;
                }
            }
        }
        private void Create(object sender)
        {
            List<string> markedActions = (ActionTokens.Where(action => action.IsChecked).Select(action => action.Token)).ToList();
            var conf = new ActionTriggerConfiguration()
            {
                TopicExpression = GetTopicExpressionType(),
                ContentExpression = GetQueryExpressionType(),
                ActionToken = markedActions.ToArray()
            };
            if (IsNew)
            {
                _ea.GetEvent<CreateTriggerEvent>().Publish(conf);
            }
            else
            {
                ActionTrigger item = new ActionTrigger()
                {
                    Configuration = conf,
                    Token = Token
                };
                _ea.GetEvent<ModifyTriggerEvent>().Publish(item);
            }
            Close(sender);
        }

        private tae.QueryExpressionType GetQueryExpressionType()
        {
            tae.QueryExpressionType queryExpressionType = null;
            if (ContentExpr != null)
            {
                queryExpressionType = new tae.QueryExpressionType()
                {
                    Any = XML.ToXmlNodeArray(ContentExpr),
                    Dialect = "http://www.onvif.org/ver10/tev/messageContentFilter/ItemFilter"
                };
            }

            return queryExpressionType;
        }

        private tae.TopicExpressionType GetTopicExpressionType()
        {
            tae.TopicExpressionType topicExpressionType = null;
            if (TopicExpr.Length > 0)
            {
                topicExpressionType = new tae.TopicExpressionType()
                {
                    Any = XML.ToXmlNodeArray(TopicExpr),
                    Dialect = "http://docs.oasis-open.org/wsn/t-1/TopicExpression/ConcreteSet"
                };
            }

            return topicExpressionType;
        }

        private void Close(object sender)
        {
            _ea.GetEvent<Events.CloseDialogEvent>().Publish(sender);
        }
    }
}
