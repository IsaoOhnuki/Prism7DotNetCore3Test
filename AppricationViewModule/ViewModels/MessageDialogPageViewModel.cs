using ModelLibrary.Service;
using MvvmLibrary.Mvvm;
using Prism.Regions;

namespace AppricationViewModule.ViewModels
{
    public class MessageDialogPageViewModel : CommonViewModel
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private string _leftButtonText;
        public string LeftButtonText
        {
            get => _leftButtonText;
            set => SetProperty(ref _leftButtonText, value);
        }

        private string _rightButtonText;
        public string RightButtonText
        {
            get => _rightButtonText;
            set => SetProperty(ref _rightButtonText, value);
        }

        public MessageDialogPageViewModel(ILogService logService, IRegionManager regionManager)
            : base(logService, regionManager)
        {
            LeftButtonText = "GO";
            RightButtonText = "BACK";
            Message = "Message";
            Title = "Title";
        }
    }
}
