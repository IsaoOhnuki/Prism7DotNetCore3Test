using ModelLibrary.Constant;
using ModelLibrary.Service;
using MvvmLibrary.Mvvm;
using Prism.Regions;

namespace AppricationViewModule.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        protected IMessageService MessageService { get; private set; }

        public ViewAViewModel(IRegionManager regionManager, IMessageService messageService)
            : base(regionManager)
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
