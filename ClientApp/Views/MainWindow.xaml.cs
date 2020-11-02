using ActionEngineModule.ViewModels;
using ActionEngineModule.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Prism.Events;
using System.Windows;

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
            object control = null;
            string title = "";
            if (item is tae.ActionTrigger)
            {
                tae.ActionTrigger data = (tae.ActionTrigger)item;
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
            else if (item is tae.Action)
            {
                tae.Action data = (tae.Action)item;
                control = new EditAction();
                var dc = ((control as EditAction).DataContext as EditActionViewModel);
                dc.IsNew = data.Token == null;
                if (data.Token != null)
                {
                    title = "Edit action: " + data.Token;
                    dc.Token = data.Token;
                    dc.Name = data.Configuration.Name;
                    dc.SelectedActionType = data.Configuration.Type;
                    switch (dc.SelectedActionType.Name)
                    {
                        case "CommandAction":
                            dc.CommandActionVM.ParseItemList(data.Configuration.Parameters);
                            break;
                        case "FtpAction":
                            dc.FtpVM.ParseItemList(data.Configuration.Parameters);
                            break;
                        case "EMailAction":
                            dc.EmailVM.ParseItemList(data.Configuration.Parameters);
                            break;
                    }
                }
                else
                {
                    title = "Create new action";
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
