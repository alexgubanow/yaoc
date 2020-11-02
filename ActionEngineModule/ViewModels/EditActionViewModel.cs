using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using tae;

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
        private EmailActionViewModel _EmailVM = new EmailActionViewModel();
        public EmailActionViewModel EmailVM
        {
            get { return _EmailVM; }
            set { SetProperty(ref _EmailVM, value); }
        }
        private FtpActionViewModel _FtpVM = new FtpActionViewModel();
        public FtpActionViewModel FtpVM
        {
            get { return _FtpVM; }
            set { SetProperty(ref _FtpVM, value); }
        }
        private CommandActionViewModel _CommandActionVM = new CommandActionViewModel();
        public CommandActionViewModel CommandActionVM
        {
            get { return _CommandActionVM; }
            set { SetProperty(ref _CommandActionVM, value); }
        }
        private XmlQualifiedName _SelectedActionType;
        public XmlQualifiedName SelectedActionType
        {
            get { return _SelectedActionType; }
            set
            {
                SetProperty(ref _SelectedActionType, value);
                switch (value.Name)
                {
                    case "EMailAction":
                        EmailActionVisibility = Visibility.Visible;
                        FtpActionVisibility = Visibility.Collapsed;
                        CommandActionVisibility = Visibility.Collapsed;
                        break;
                    case "FtpAction":
                        EmailActionVisibility = Visibility.Collapsed;
                        FtpActionVisibility = Visibility.Visible;
                        CommandActionVisibility = Visibility.Collapsed;
                        break;
                    case "CommandAction":
                        EmailActionVisibility = Visibility.Collapsed;
                        FtpActionVisibility = Visibility.Collapsed;
                        CommandActionVisibility = Visibility.Visible;
                        break;
                    default:
                        EmailActionVisibility = Visibility.Collapsed;
                        FtpActionVisibility = Visibility.Collapsed;
                        CommandActionVisibility = Visibility.Collapsed;
                        break;
                }
            }
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
        private Visibility _EmailActionVisibility = Visibility.Collapsed;
        public Visibility EmailActionVisibility
        {
            get { return _EmailActionVisibility; }
            set { SetProperty(ref _EmailActionVisibility, value); }
        }
        private Visibility _FtpActionVisibility = Visibility.Collapsed;
        public Visibility FtpActionVisibility
        {
            get { return _FtpActionVisibility; }
            set { SetProperty(ref _FtpActionVisibility, value); }
        }
        private Visibility _CommandActionVisibility = Visibility.Collapsed;
        public Visibility CommandActionVisibility
        {
            get { return _CommandActionVisibility; }
            set { SetProperty(ref _CommandActionVisibility, value); }
        }
        
        EditActionViewModel(IEventAggregator ea)
        {
            EmailActionVisibility = Visibility.Visible;
            FtpActionVisibility = Visibility.Collapsed;
            _eventAggregator = ea;
            OkCMD = new DelegateCommand<object>(Create);
            CloseCMD = new DelegateCommand<object>(Close);
            ActionTypes = new ObservableCollection<XmlQualifiedName>(
               (XmlQualifiedName[])Application.Current.Properties["SupportedActions"]);
        }
        private void Create(object sender)
        {
            if (IsNew)
            {
                var item = new ActionConfiguration()
                {
                    Name = Name,
                    Type = SelectedActionType,
                    Parameters = GetActionParams()
                };
                _eventAggregator.GetEvent<CreateActionEvent>().Publish(item);
            }
            else
            {
                var item = new Action()
                {
                    Token = Token,
                    Configuration = new ActionConfiguration()
                    {
                        Name = Name,
                        Type = SelectedActionType,
                        Parameters = GetActionParams()
                    }
                };
                _eventAggregator.GetEvent<ModifyActionEvent>().Publish(item);
            }
            Close(sender);
        }

        private ItemList GetActionParams()
        {
            return SelectedActionType.Name switch
            {
                "EMailAction" => EmailVM.GetItemList(),
                "FtpAction" => FtpVM.GetItemList(),
                "CommandAction" => CommandActionVM.GetItemList(),
                _ => null,
            };
        }

        private void Close(object sender)
        {
            _eventAggregator.GetEvent<Events.CloseDialogEvent>().Publish(sender);
        }
    }
}
