using ActionEngineModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ActionEngineModule
{
    public class ActionEngineModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ActionEngineRegion", typeof(ActionEngine));
            regionManager.RegisterViewWithRegion("TriggersRegion", typeof(Triggers));
            regionManager.RegisterViewWithRegion("ActionsRegion", typeof(Actions));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}