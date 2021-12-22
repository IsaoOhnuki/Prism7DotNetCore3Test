using AppricationViewModule.Views;
using ModelLibrary.Enumerate;
using ModelLibrary.Services;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace AppricationViewModule
{
    public class AppricationViewModule : IModule
    {
        public IRegionManager RegionManager { get; }

        public AppricationViewModule(IRegionManager regionManager, IContentViewService contentViewService)
        {
            RegionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            RegionManager.RequestNavigate(ContentViewType.MainWindowContent.ToString(), ViewConst.ViewPage_TopPage);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<MessageDialogPage>();
            containerRegistry.RegisterForNavigation<ShadeScreen>();
            containerRegistry.RegisterForNavigation<TopPage>();
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}
