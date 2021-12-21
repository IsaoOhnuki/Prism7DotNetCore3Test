using ModelLibrary.Constant;
using ModelLibrary.Enumerate;
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

        public ICommand ErrorCommand { get; }

        public ICommand WarningCommand { get; }

        public ICommand InformationCommand { get; }

        public ICommand BackCommand { get; }

        public ViewAViewModel(ILogService logService, IRegionManager regionManager, IMessageService messageService)
            : base(logService, regionManager, messageService)
        {
            ErrorCommand = new DelegateCommand(() =>
            {
                ShowMessage(MessageDialogStyle.ErrorMessage,
                    MessageService.GetMessage(MessageId.DoneMessage),
                    MessageService.GetMessage(MessageId.ErrorMessageTitle));
            });
            WarningCommand = new DelegateCommand(() =>
            {
                ShowMessage(MessageDialogStyle.WarningMessage,
                    MessageService.GetMessage(MessageId.FailureMessage),
                    MessageService.GetMessage(MessageId.WarningMessageTitle));
            });
            InformationCommand = new DelegateCommand(() =>
            {
                ShowMessage(MessageDialogStyle.InformationMessage,
                    MessageService.GetMessage(MessageId.SuccessMessage),
                    MessageService.GetMessage(MessageId.InformationMessageTitle));
            });
            BackCommand = new DelegateCommand(() => DoTransitionPage(GetViewName(), ViewConst.ViewPage_TopPage));
        }

        public override void InisiarizeView(NavigationParameters navigationParameters)
        {
        }

        public override void PreviousInisiarizeView(NavigationParameters navigationParameters)
        {
        }
    }
}
