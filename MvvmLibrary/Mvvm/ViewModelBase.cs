using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.Services;
using MvvmServiceLibrary;
using MvvmServiceLibrary.Mvvm;
using Prism.Navigation;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;

namespace MvvmLibrary.Mvvm
{
    public abstract class ViewModelBase : ModelBase, INavigationAware, IConfirmNavigationRequest, IDestructible
    {
        protected ILogService LogService { get; private set; }

        protected IRegionManager RegionManager { get; private set; }

        protected IMessageService MessageService;

        public string PreviousView { get; set; }

        public string TransitionView { get; set; }

        public ViewModelBase(ILogService logService, IRegionManager regionManager, IMessageService messageService)
        {
            LogService = logService;
            RegionManager = regionManager;
            MessageService = messageService;
        }

        public string GetViewName()
        {
            string vmName = GetType().Name;
            return vmName.Substring(0, vmName.IndexOf("ViewModel"));
        }

        public void DoTransitionPage(string fromPage, string toPage)
        {
            NavigationParameters navigationParam = new NavigationParameters
            {
                { ViewConst.NavigationParameterKey_PreviousView, fromPage },
                { ViewConst.NavigationParameterKey_TransitionView, toPage },
            };
            RegionManager.RequestNavigate(ViewConst.MainViewRegion_Content, toPage, navigationParam);
        }

        public abstract void InisiarizeView(NavigationParameters navigationParameters);

        public abstract void PreviousInisiarizeView(NavigationParameters navigationParameters);

        public virtual IDialogResult ShowMessage(string message, string title = null) 
        {
            MessageInputModel messageInput = new MessageInputModel
            {
                Title = title ?? MessageService.GetMessage(MessageId.ConfirmMessageTitle),
                Message = message,
                MessageDialogName = ViewConst.ViewPage_MessageDialogPage,
                MessageDialogStyle = MessageDialogStyle.ConfirmMessage,
                LeftButtonCaption = MessageService.GetMessage(MessageId.CancelButtonCaption),
                RightButtonCaption = MessageService.GetMessage(MessageId.OkButtonCaption),
                CenterButtonText = MessageService.GetMessage(MessageId.CloseButtonCaption),
            };
            RegionManager.RequestNavigate(ViewConst.MainViewRegion_OverwrapContent, ViewConst.ViewPage_ShadeScreen, new NavigationParameters());
            MessageShowing = true;
            IDialogResult result = MessageService.ShowMessage(messageInput);
            MessageShowing = false;
            RegionManager.Regions[ViewConst.MainViewRegion_OverwrapContent].RemoveAll();
            return result;
        }

        private bool _messageShowing;

        public bool MessageShowing
        {
            get => _messageShowing;
            private set => SetProperty(ref _messageShowing, value);
        }

        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        /// <summary>
        /// ナビゲーション可能かどうかを返却する
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // ナビゲーション可能
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 遷移パラメータを取得する
            TransitionView = navigationContext.Parameters[ViewConst.NavigationParameterKey_TransitionView] as string;
            PreviousView = navigationContext.Parameters[ViewConst.NavigationParameterKey_PreviousView] as string;

            InisiarizeView(navigationContext.Parameters);
        }

        public virtual void Destroy()
        {
        }
    }
}
