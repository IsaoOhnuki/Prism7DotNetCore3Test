using AppricationViewModule.Views;
using BlankCoreApp1;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Reflection.Metadata;

namespace AppricationViewModule
{
    public class AppricationViewModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public AppricationViewModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(ViewConstant.ContentRegion, "TopPage");
            _regionManager.RequestNavigate(ViewConstant.ContentRegion, "ViewA");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TopPage>();
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}