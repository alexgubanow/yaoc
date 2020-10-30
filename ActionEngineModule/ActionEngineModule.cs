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
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}