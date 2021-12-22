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

        public IContentViewService ContentViewService { get; }

        public IMessageService MessageService { get; }

        public AppricationViewModule(IRegionManager regionManager, IContentViewService contentViewService, IMessageService messageService)
        {
            RegionManager = regionManager;
            ContentViewService = contentViewService;
            MessageService = messageService;
            messageService.SetMessageDialog(nameof(MessageDialogPage));
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            RegionManager.RequestNavigate(ContentViewType.MainWindowContent.ToString(), nameof(TopPage));
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
