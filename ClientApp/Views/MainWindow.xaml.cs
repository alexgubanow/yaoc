using ActionEngineModule.Views;
using ActionEngineModule.ViewModels;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClientApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private IEventAggregator _ea;

        public MainWindow(IEventAggregator ea)
        {
            InitializeComponent();
            _ea = ea;
            ea.GetEvent<Events.OpenDialogEvent>().Subscribe((value) => ShowDialog(value));
            ea.GetEvent<Events.CloseDialogEvent>().Subscribe((value) => CloseDialog(value));
        }
        private async void ShowDialog(object item)
        {
            tae.ActionTrigger data = (tae.ActionTrigger)item;
            object control = null;
            string title = "";
            if (data != null)
            {
                control = new EditTrigger();
                var dc = ((control as EditTrigger).DataContext as EditTriggerViewModel);
                dc.IsNew = data.Token == null;
                if (data.Token != null)
                {
                    title = "Edit trigger: " + data.Token;
                    dc.Token = data.Token;
                    if (data.Configuration.TopicExpression != null)
                    {
                        dc.TopicExpr = TopicExpressionToString.ToString(data.Configuration.TopicExpression.Any);
                        dc.SetUsedTopicsFromString(dc.TopicExpr);
                    }
                    if (data.Configuration.ContentExpression != null)
                    {
                        dc.ContentExpr = data.Configuration.ContentExpression.Any[0].Value;
                    }
                }
                else
                {
                    title = "Create new trigger";
                }
            }
            if (control == null)
            {
                return;
            }
            var dialog = new CustomDialog(new MetroDialogSettings() { AnimateHide = false, AnimateShow = false }) 
            { Content = control, Title = title, DialogTitleFontSize = 18 };

            await this.ShowMetroDialogAsync(dialog);
            await dialog.WaitUntilUnloadedAsync();
        }
        private async void CloseDialog(object sender)
        {
            var dialog = (sender as DependencyObject).TryFindParent<BaseMetroDialog>();

            await this.HideMetroDialogAsync(dialog);
        }
    }
}
