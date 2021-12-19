using ModelLibrary;
using ModelLibrary.Service;
using MvvmLibrary.Mvvm;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Windows.Input;

namespace BlankCoreApp1.ViewModels
{
    public class MessageDialogPageViewModel : ViewModelBase, IDialogAware
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
        }

        void TransitionBack()
        {
        }

        NavigationParameters _navigationParameters;

        public event Action<IDialogResult> RequestClose;

        public override void InisiarizeView(NavigationParameters navigationParameters)
        {
            _navigationParameters = navigationParameters;
        }

        public override void PreviousInisiarizeView(NavigationParameters navigationParameters)
        {
        }

        //public override void ReturnMessageDialog(MessageDialogResult messageDialogResult, NavigationParameters navigationParameters)
        //{
        //}

        public bool CanCloseDialog()
        {
            throw new NotImplementedException();
        }

        public void OnDialogClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
