﻿using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Xml;
using System.Xml.Serialization;
using tae;

namespace ActionEngineModule.ViewModels
{
    public class ActionsUPDEvent : PubSubEvent<tae.Action[]> { }
    class ActionsViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        private ActionEnginePortClient actionEngineClient { 
            get { return (ActionEnginePortClient)System.Windows.Application.Current.Properties["TAEclient"]; } }
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
            ea.GetEvent<CreateActionEvent>().Subscribe((value) => CreateActionRequest(value));
            ea.GetEvent<ModifyActionEvent>().Subscribe((value) => ModifyActionRequest(value));
        }
        private async void CreateActionRequest(ActionConfiguration item)
        {
            if (actionEngineClient != null && item != null)
            {
                try
                {
                    var req = new CreateActionsRequest(new ActionConfiguration[1] { item });
                    var task = actionEngineClient.CreateActionsAsync(req);
                    await task.ConfigureAwait(false);
                    UpdateList();
                }
                catch (Exception ex)
                {
                    _eventAggregator.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
                }
            }
        }
        private async void ModifyActionRequest(tae.Action item)
        {
            if (item != null && actionEngineClient != null)
            {
                try
                {
                    tae.Action[] tmp = new tae.Action[1] { item };
                    var task = actionEngineClient.ModifyActionsAsync(tmp);
                    await task.ConfigureAwait(false);
                    UpdateList();
                }
                catch (Exception ex)
                {
                    _eventAggregator.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
                }
            }
        }
        private void Create()
        {
            _eventAggregator.GetEvent<Events.OpenDialogEvent>().Publish(new tae.Action());
        }
        private void Edit(tae.Action item)
        {
            _eventAggregator.GetEvent<Events.OpenDialogEvent>().Publish(item);
        }
        private async void Delete(tae.Action item)
        {
            if (item != null && actionEngineClient != null)
            {
                try
                {
                    string[] tmp = new string[1] { item.Token };
                    var task = actionEngineClient.DeleteActionsAsync(tmp);
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
