using ModelLibrary.Constant;
using ModelLibrary.Service;
using MvvmLibrary.Mvvm;
using Prism.Regions;

namespace AppricationViewModule.ViewModels
{
    public class ViewAViewModel : CommonViewModel
    {
        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        protected IMessageService MessageService { get; private set; }

        public ViewAViewModel(ILogService logService, IRegionManager regionManager, IMessageService messageService)
            : base(logService, regionManager)
        {
            MessageService = messageService;

            Message = MessageService.GetMessage(MessageConst.MessageId.Message);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}
