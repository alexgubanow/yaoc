﻿using Prism.Commands;
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
    public class TriggersUPDEvent : PubSubEvent<ActionTrigger[]> { }
    class TriggersViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        private ActionEnginePortClient actionEngineClient;
        private ObservableCollection<ActionTrigger> _Triggers;
        public ObservableCollection<ActionTrigger> Triggers
        {
            get { return _Triggers; }
            set { SetProperty(ref _Triggers, value); }
        }

        public DelegateCommand<ActionTrigger> EditCMD { get; private set; }
        public DelegateCommand<ActionTrigger> DeleteCMD { get; private set; }
        public DelegateCommand CreateCMD { get; private set; }
        public DelegateCommand UpdateCMD { get; private set; }

        private static readonly object _lock = new object();
        TriggersViewModel(IEventAggregator ea)
        {
            _eventAggregator = ea;
            EditCMD = new DelegateCommand<ActionTrigger>(Edit);
            DeleteCMD = new DelegateCommand<ActionTrigger>(Delete);
            CreateCMD = new DelegateCommand(Create);
            UpdateCMD = new DelegateCommand(UpdateList);
            Triggers = new ObservableCollection<ActionTrigger>();
            BindingOperations.EnableCollectionSynchronization(Triggers, _lock);
            ea.GetEvent<TriggersUPDEvent>().Subscribe((value) => { Triggers.Clear(); Triggers.AddRange(value); });
            ea.GetEvent<CreateTriggerEvent>().Subscribe((value) => CreateActionTriggerRequest(value));
            ea.GetEvent<ModifyTriggerEvent>().Subscribe((value) => ModifyActionTriggerRequest(value));
            while (System.Windows.Application.Current.Properties["AEclient"] == null)
            {

            }
            actionEngineClient = (ActionEnginePortClient)System.Windows.Application.Current.Properties["AEclient"];
        }
        
        private void Create()
        {
            _eventAggregator.GetEvent<Events.OpenDialogEvent>().Publish(new tae.ActionTrigger());
        }
        private async void CreateActionTriggerRequest(ActionTriggerConfiguration item)
        {
            if (actionEngineClient != null && item != null)
            {
                try
                {
                    var task = actionEngineClient.CreateActionTriggersAsync(new CreateActionTriggersRequest() {
                        ActionTrigger = new ActionTriggerConfiguration[1] { item } });
                    await task.ConfigureAwait(false);
                    UpdateList();
                }
                catch (Exception ex)
                {
                    _eventAggregator.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
                }
            }
        }
        private void Edit(ActionTrigger item)
        {
            _eventAggregator.GetEvent<Events.OpenDialogEvent>().Publish(item);
        }
        private async void ModifyActionTriggerRequest(ActionTrigger item)
        {
            if (item != null && actionEngineClient != null)
            {
                try
                {
                    ActionTrigger[] tmp = new ActionTrigger[1] { item };
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
        private async void Delete(ActionTrigger item)
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
                var GetActionTriggersTask = actionEngineClient.GetActionTriggersAsync();
                await GetActionTriggersTask.ConfigureAwait(false);
                _eventAggregator.GetEvent<TriggersUPDEvent>().Publish(GetActionTriggersTask.Result.ActionTrigger);
            }
            catch (Exception ex)
            {
                _eventAggregator.GetEvent<Events.NewStatusEvent>().Publish(ex.Message);
            }
        }
    }
}
