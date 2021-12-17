using AppricationViewModule.Views;
using MvvmServiceLibrary;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace AppricationViewModule
{
    public class AppricationViewModule : IModule
    {
        public IRegionManager RegionManager { get; }

        public AppricationViewModule(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            RegionManager.RequestNavigate(ViewConst.MainViewRegion_Content, ViewConst.TopPage);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TopPage>();
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<MessageDialogPage>();
        }
    }
}
