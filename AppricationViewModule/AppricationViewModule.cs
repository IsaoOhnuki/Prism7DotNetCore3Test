using AppricationViewModule.Views;
using ModelLibrary.Enumerate;
using ModelLibrary.Services;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows.Controls;

namespace AppricationViewModule
{
    public class AppricationViewModule : IModule
    {
        public IRegionManager RegionManager { get; }

        public IContentViewService ContentViewService { get; }

        public IMessageService MessageService { get; }

        public AppricationViewModule(IRegionManager regionManager, IContentViewService contentViewService, IMessageService messageService)
        {
            RegionManager = regionManager;
            ContentViewService = contentViewService;
            MessageService = messageService;

            ContentControl mainContent = new ContentControl();
            ContentViewService.GetWindowContent(ContentViewType.MainWindowContent).Content = mainContent;
            mainContent.SetValue(Prism.Regions.RegionManager.RegionNameProperty, AppViewConst.ContentRegion_AppViewMainContent);
            MessageService.SetMessageDialog(nameof(MessageDialogPage));
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            RegionManager.RequestNavigate(AppViewConst.ContentRegion_AppViewMainContent, nameof(ReserveView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<MessageDialogPage>();
            containerRegistry.RegisterForNavigation<ShadeScreen>();
            containerRegistry.RegisterForNavigation<ReserveView>();
            containerRegistry.RegisterForNavigation<TopPage>();
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ReserveView>();
            containerRegistry.RegisterForNavigation<ReserveEdit>();
        }
    }
}
