using ModelLibrary.Service;
using MvvmLibrary;
using MvvmLibrary.Mvvm;
using MvvmUtilityLibrary.Mvvm;
using Prism.Commands;
using Prism.Regions;
using System.Windows.Input;

namespace AppricationViewModule.ViewModels
{
    public class MessageDialogPageViewModel : ViewModelBase
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

        public ICommand BackCommand { get; }


        public ICommand GoCommand { get; }
        
        public MessageDialogPageViewModel(ILogService logService, IRegionManager regionManager)
            : base(logService, regionManager)
        {
            GoCommand = new DelegateCommand(TransitionGo);
            BackCommand = new DelegateCommand(TransitionBack);

            LeftButtonText = "BACK";
            RightButtonText = "GO";
            Message = "Message\n0123456789";
            Title = "?";
        }

        void TransitionGo()
        {
            //IRegion contentRegion = RegionManager.Regions[ViewConst.MainViewRegion_OverwrapContent];
            //contentRegion.Content = null;
            DoTransitionPage(GetViewName(), ViewConst.ViewA);
        }

        void TransitionBack()
        {
            //ContentRegionMediator.ContentRegion.Content = null;
            DoTransitionPage(GetViewName(), PreviousView);
        }

        public override void InisiarizeView(NavigationParameters navigationParameters)
        {
        }
    }
}
