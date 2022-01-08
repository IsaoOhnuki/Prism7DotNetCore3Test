using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.Models;
using ModelLibrary.Services;
using Prism.Navigation;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;

namespace MvvmCommonLibrary.Mvvm
{
    public abstract class ViewModelBase : ModelBase, INavigationAware, IConfirmNavigationRequest, IDestructible
    {
        protected ILogService LogService { get; private set; }

        protected IRegionManager RegionManager { get; private set; }

        protected IMessageService MessageService { get; set; }

        public string PreviousView { get; set; }

        public string TransitionView { get; set; }

        public object TransitionParameter { get; set; }

        public ViewModelBase(ILogService logService, IRegionManager regionManager, IMessageService messageService)
        {
            LogService = logService;
            RegionManager = regionManager;
            MessageService = messageService;
        }

        public string GetViewName(bool viewNameView = false)
        {
            string vmName = GetType().Name;
            if (viewNameView)
            {
                return vmName.Substring(0, vmName.IndexOf("Model"));
            }
            else
            {
                return vmName.Substring(0, vmName.IndexOf("ViewModel"));
            }
        }

        public void DoTransitionPage(string contentRegion, string fromPage, string toPage,
            object parameter = null)
        {
            NavigationParameters navigationParam = new NavigationParameters
            {
                { MvvmConst.NavigationParameterKey_PreviousView, fromPage },
                { MvvmConst.NavigationParameterKey_TransitionView, toPage },
                { MvvmConst.NavigationParameterKey_TransitionBack, false },
                { MvvmConst.NavigationParameterKey_TransitionParameter, parameter },
            };
            RegionManager.RequestNavigate(contentRegion, toPage, navigationParam);
        }

        public void DoBackTransition(string contentRegion, object parameter = null)
        {
            NavigationParameters navigationParam = new NavigationParameters
            {
                { MvvmConst.NavigationParameterKey_PreviousView, TransitionView },
                { MvvmConst.NavigationParameterKey_TransitionView, PreviousView },
                { MvvmConst.NavigationParameterKey_TransitionBack, true },
                { MvvmConst.NavigationParameterKey_TransitionParameter, parameter },
            };
            RegionManager.RequestNavigate(contentRegion, PreviousView, navigationParam);
        }

        public abstract void InisiarizeView(object parameter);

        public abstract void PreviousInisiarizeView(object parameter);

        public virtual ButtonResult ShowMessage(MessageDialogStyle messageDialogStyle, string message, string title = null)
        {
            MessageInputModel messageInput = new MessageInputModel
            {
                Title = title ?? MessageService.GetMessage(MessageId.ConfirmMessageTitle),
                Message = new MessageModel(message),
                MessageDialogStyle = messageDialogStyle,
                LeftButtonCaption = MessageService.GetMessage(MessageId.CancelButtonCaption),
                RightButtonCaption = MessageService.GetMessage(MessageId.OkButtonCaption),
                CenterButtonText = MessageService.GetMessage(MessageId.CloseButtonCaption),
            };
            ButtonResult result = MessageService.ShowMessage(messageInput);
            return result;
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
            TransitionView = navigationContext.Parameters[MvvmConst.NavigationParameterKey_TransitionView] as string;
            PreviousView = navigationContext.Parameters[MvvmConst.NavigationParameterKey_PreviousView] as string;
            TransitionParameter = navigationContext.Parameters[MvvmConst.NavigationParameterKey_TransitionParameter];
            bool? transitionBack = navigationContext.Parameters[MvvmConst.NavigationParameterKey_TransitionBack] as bool?;

            if (transitionBack.HasValue && transitionBack.Value)
            {
                PreviousInisiarizeView(TransitionParameter);
            }
            else
            {
                InisiarizeView(TransitionParameter);
            }
        }

        public virtual void Destroy()
        {
        }
    }
}
