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

namespace ActionEngineModule.ViewModels
{
    public class CreateActionEvent : PubSubEvent<ActionConfiguration> { }
    public class ModifyActionEvent : PubSubEvent<Action> { }
    public class EditActionViewModel : BindableBase
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
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        private XmlQualifiedName _SelectedActionType;
        public XmlQualifiedName SelectedActionType
        {
            get { return _SelectedActionType; }
            set { SetProperty(ref _SelectedActionType, value); }
        }
        private bool _IsNew;
        public bool IsNew
        {
            get { return _IsNew; }
            set { SetProperty(ref _IsNew, value); }
        }
        private ObservableCollection<XmlQualifiedName> _ActionTypes;
        public ObservableCollection<XmlQualifiedName> ActionTypes
        {
            get { return _ActionTypes; }
            set { SetProperty(ref _ActionTypes, value); }
        }

        EditActionViewModel(IEventAggregator ea)
        {
            _eventAggregator = ea;
            OkCMD = new DelegateCommand<object>(Create);
            CloseCMD = new DelegateCommand<object>(Close);
            ActionTypes = new ObservableCollection<XmlQualifiedName>(
               (XmlQualifiedName[])System.Windows.Application.Current.Properties["SupportedActions"]);
        }
        public static XmlNode[] SerializeToXmlElement(object o)
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                new XmlSerializer(o.GetType()).Serialize(writer, o);
            }
            return new XmlNode[1] { doc.DocumentElement.LastChild };
        }
        private void Create(object sender)
        {
            if (IsNew)
            {
                var item = new ActionConfiguration()
                {
                    Name = Name,
                    Type = SelectedActionType
                };
                _eventAggregator.GetEvent<CreateActionEvent>().Publish(item);
            }
            else
            {
                var item = new tae.Action()
                {
                    Token = Token,
                    Configuration = new ActionConfiguration()
                    {
                        Name = Name,
                        Type = SelectedActionType
                    }
                };
                _eventAggregator.GetEvent<ModifyActionEvent>().Publish(item);
            }
            Close(sender);
        }

        private void Close(object sender)
        {
            _eventAggregator.GetEvent<Events.CloseDialogEvent>().Publish(sender);
        }
    }
}
