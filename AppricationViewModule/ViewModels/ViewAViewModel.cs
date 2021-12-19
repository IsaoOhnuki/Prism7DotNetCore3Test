using ModelLibrary.Constant;
using ModelLibrary.Services;
using MvvmLibrary.Mvvm;
using MvvmServiceLibrary;
using Prism.Commands;
using Prism.Regions;
using System.Windows.Input;

namespace AppricationViewModule.ViewModels
{
    public class ViewAViewModel : ViewModelBase
    {

        public ICommand BackCommand { get; }

        protected IMessageService MessageService { get; private set; }

        public ViewAViewModel(ILogService logService, IRegionManager regionManager, IMessageService messageService)
            : base(logService, regionManager, messageService)
        {
            BackCommand = new DelegateCommand(TransitionBack);
        }

        void TransitionBack()
        {
            DoTransitionPage(GetViewName(), ViewConst.ViewPage_TopPage);
        }

        public override void InisiarizeView(NavigationParameters navigationParameters)
        {
        }

        public override void PreviousInisiarizeView(NavigationParameters navigationParameters)
        {
        }
    }
}
