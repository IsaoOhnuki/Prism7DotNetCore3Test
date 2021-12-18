using ModelLibrary.Constant;
using ModelLibrary.Service;
using MvvmLibrary.Mvvm;
using MvvmServiceLibrary;
using Prism.Commands;
using Prism.Regions;
using System.Windows.Input;

namespace AppricationViewModule.ViewModels
{
    public class ViewAViewModel : ViewModelBase
    {
        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public ICommand BackCommand { get; }

        protected IMessageService MessageService { get; private set; }

        public ViewAViewModel(ILogService logService, IRegionManager regionManager, IMessageService messageService)
            : base(logService, regionManager)
        {
            MessageService = messageService;

            BackCommand = new DelegateCommand(TransitionBack);

            Message = MessageService.GetMessage(MessageConst.MessageId.Message);
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
