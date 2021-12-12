using ModelLibrary.Service;
using Prism.Regions;

namespace MvvmLibrary.Mvvm
{
    public class CommonViewModel : RegionViewModelBase
    {
        public string PreviousView { get; set; }

        public CommonViewModel(ILogService logService, IRegionManager regionManager)
            : base(logService, regionManager)
        {
        }

        public string GetViewName()
        {
            string vmName = GetType().Name;
            return vmName.Substring(0, vmName.IndexOf("ViewModel"));
        }

        public NavigationParameters GetPageTransitionParameters()
        {
            NavigationParameters navigationParam = new NavigationParameters
            {
                { ViewConst.NavigationParameterKey_PreviousView, GetViewName() }
            };
            return navigationParam;
        }

        public void PageTransition(string region, string page, NavigationParameters navigationParam)
        {
            if (!string.IsNullOrEmpty(region) && !string.IsNullOrEmpty(page))
            {
                RegionManager.RequestNavigate(region, page, navigationParam);
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            PreviousView = navigationContext.Parameters[ViewConst.NavigationParameterKey_PreviousView] as string;
        }
    }
}
