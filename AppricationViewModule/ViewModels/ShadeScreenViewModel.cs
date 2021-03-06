using ModelLibrary.Services;
using MvvmCommonLibrary.Mvvm;
using Prism.Regions;

namespace AppricationViewModule.ViewModels
{
    public class ShadeScreenViewModel : ViewModelBase
    {
        public ShadeScreenViewModel(ILogService logService, IRegionManager regionManager, IMessageService messageService)
            : base(logService, regionManager, messageService)
        {

        }

        public override void InisiarizeView(NavigationParameters navigationParameters)
        {
        }

        public override void PreviousInisiarizeView(NavigationParameters navigationParameters)
        {
        }
    }
}
