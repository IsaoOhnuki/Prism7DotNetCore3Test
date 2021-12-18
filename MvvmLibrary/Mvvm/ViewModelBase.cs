using ModelLibrary.Service;
using MvvmServiceLibrary;
using MvvmServiceLibrary.Mvvm;
using Prism.Navigation;
using Prism.Regions;
using System;

namespace MvvmLibrary.Mvvm
{
    public abstract class ViewModelBase : ModelBase, INavigationAware, IConfirmNavigationRequest, IDestructible
    {
        protected ILogService LogService { get; private set; }

        protected IRegionManager RegionManager { get; private set; }

        public string PreviousView { get; set; }

        public string TransitionView { get; set; }

        public ViewModelBase(ILogService logService, IRegionManager regionManager)
        {
            LogService = logService;
            RegionManager = regionManager;
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

        public virtual void ReturnMessageDialog(MessageDialogResult messageDialogResult, NavigationParameters navigationParameters)
        {
        }


        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
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

            // メッセージダイアログ遷移かを判定する
            string navigationType = navigationContext.Parameters[ViewConst.NavigationParameterKey_NavigationType] as string;
            if (navigationType == ViewConst.NavigationTypeKey_MessageDialogNavigation)
            {
                // メッセージダイアログ遷移パラメータ取得
                NavigationParameters navigationParameters =
                    navigationContext.Parameters[ViewConst.NavigationParameterKey_MessageDialogParameter] as NavigationParameters;
                InisiarizeView(navigationParameters);
            }
            else if(navigationType == ViewConst.NavigationTypeKey_MessageDialogResultNavigation)
            {
                // メッセージダイアログ遷移パラメータ取得
                NavigationParameters navigationParameters =
                    navigationContext.Parameters[ViewConst.NavigationParameterKey_MessageDialogParameter] as NavigationParameters;
                MessageDialogResult messageDialogResult =
                    (MessageDialogResult)navigationContext.Parameters[ViewConst.NavigationParameterKey_MessageDialogResult];
                ReturnMessageDialog(messageDialogResult, navigationParameters);
            }
            else
            {
                InisiarizeView(navigationContext.Parameters);
            }
        }

        public void ShowMessageDialog(string fromPage, NavigationParameters navigationParameters)
        {
            // メッセージダイアログに遷移する。
            NavigationParameters naviParam = new NavigationParameters()
            {
                // 遷移パラメータ設定
                { ViewConst.NavigationParameterKey_PreviousView, fromPage },
                { ViewConst.NavigationParameterKey_TransitionView, null },
                // メッセージダイアログ遷移パラメータ設定
                { ViewConst.NavigationParameterKey_NavigationType, ViewConst.NavigationTypeKey_MessageDialogNavigation},
                { ViewConst.NavigationParameterKey_MessageDialogParameter , navigationParameters },
            };
            // メッセージダイアログ表示。
            RegionManager.RequestNavigate(ViewConst.MainViewRegion_OverwrapContent, ViewConst.ViewPage_MessageDialogPage, naviParam);
        }

        public void HideMessageDialog(MessageDialogResult messageDialogResult, NavigationParameters navigationParameters)
        {
            // メッセージダイアログ非表示。
            RegionManager.Regions[ViewConst.MainViewRegion_OverwrapContent].RemoveAll();
            // メッセージダイアログ呼び出し元に遷移する。
            NavigationParameters naviParam = new NavigationParameters()
            {
                // 遷移パラメータ設定
                { ViewConst.NavigationParameterKey_NavigationType, ViewConst.NavigationTypeKey_MessageDialogResultNavigation},
                { ViewConst.NavigationParameterKey_TransitionView, PreviousView　},
                // メッセージダイアログ戻り値パラメータ設定
                { ViewConst.NavigationParameterKey_NavigationType, ViewConst.NavigationTypeKey_MessageDialogResultNavigation },
                { ViewConst.NavigationParameterKey_MessageDialogParameter , navigationParameters },
                { ViewConst.NavigationParameterKey_MessageDialogResult , messageDialogResult },
            };
            // メッセージダイアログ呼び出し元表示。
            RegionManager.RequestNavigate(ViewConst.MainViewRegion_OverwrapContent, PreviousView, naviParam);
        }

        public virtual void Destroy()
        {
       }
    }
}
