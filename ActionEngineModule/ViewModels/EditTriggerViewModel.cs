using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using tae;
using tev;
using utils;

namespace ActionEngineModule.ViewModels
{
    public class CreateTriggerEvent : PubSubEvent<ActionTriggerConfiguration> { }
    public class ModifyTriggerEvent : PubSubEvent<ActionTrigger> { }
    public class Topic
    {
        public bool IsChecked { get; set; }
        public string Data { get; set; }
    }
    public class EditTriggerViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        public DelegateCommand<object> OkCMD { get; private set; }
        public DelegateCommand<object> CloseCMD { get; private set; }
        public DelegateCommand DropDownMenuItemCheckedCMD { get; private set; }

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
        private string _ContentExpr;
        public string ContentExpr
        {
            set { SetProperty(ref _ContentExpr, value); }
            get { return _ContentExpr; }
        }
        private ObservableCollection<Topic> _Topics;
        public ObservableCollection<Topic> Topics
        {
            get { return _Topics; }
            set { SetProperty(ref _Topics, value); }
        }

        EditTriggerViewModel(IEventAggregator ea)
        {
            _eventAggregator = ea;
            OkCMD = new DelegateCommand<object>(Create);
            CloseCMD = new DelegateCommand<object>(Close);
            DropDownMenuItemCheckedCMD = new DelegateCommand(TopicsToString);
            var evpr = (GetEventPropertiesResponse)System.Windows.Application.Current.Properties["EventProperties"];
            var rawTopics = new List<Topic>();
            foreach (var item in evpr.TopicSet.Any)
            {
                rawTopics.Add(new Topic() { IsChecked = false, Data = item.Name + "//." });
                foreach (XmlElement childTopic in item.ChildNodes)
                {
                    rawTopics.Add(new Topic() { IsChecked = false, Data = item.Name + "/" + childTopic.Name });
                }
            }
            Topics = new ObservableCollection<Topic>(rawTopics);
        }
        public void TopicsToString()
        {
            string b = "";
            foreach (var item in Topics.Where(item => item.IsChecked))
            {
                b += item.Data + '|';
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
                                              where topicFromList.Data == item
                                              select topicFromList)
                {
                    topicFromList.IsChecked = true;
                }
            }
        }
        private void Create(object sender)
        {
            if (IsNew)
            {
                ActionTriggerConfiguration item =
                    new ActionTriggerConfiguration()
                    {
                        TopicExpression = GetTopicExpressionType(),
                        ContentExpression = GetQueryExpressionType()
                    };
                _eventAggregator.GetEvent<CreateTriggerEvent>().Publish(item);
            }
            else
            {
                ActionTrigger item =
                    new ActionTrigger()
                    {
                        Configuration = new ActionTriggerConfiguration()
                        {
                            TopicExpression = GetTopicExpressionType(),
                            ContentExpression = GetQueryExpressionType()
                        },
                        Token = Token
                    };
                _eventAggregator.GetEvent<ModifyTriggerEvent>().Publish(item);
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
            _eventAggregator.GetEvent<Events.CloseDialogEvent>().Publish(sender);
        }
    }
}
