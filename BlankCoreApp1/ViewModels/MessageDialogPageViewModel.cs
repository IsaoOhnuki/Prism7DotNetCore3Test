using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Windows.Input;

namespace BlankCoreApp1.ViewModels
{
    public class MessageDialogPageViewModel : BindableBase, IDialogAware
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
        
        public MessageDialogPageViewModel()
        {
            GoCommand = new DelegateCommand(TransitionGo);
            BackCommand = new DelegateCommand(TransitionBack);
        }

        void TransitionGo()
        {
            RequestClose(new DialogResult(ButtonResult.OK));
        }

        void TransitionBack()
        {
            RequestClose(new DialogResult(ButtonResult.Cancel));
        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            MessageInputModel messageInputModel = parameters.GetValue<MessageInputModel>(nameof(MessageInputModel));

            switch (messageInputModel.MessageDialogStyle)
            {
                case MessageDialogStyle.ConfirmMessage:
                    LeftButtonText = "BACK";
                    RightButtonText = "GO";
                    Message = messageInputModel.Message;
                    Title = "?";
                    break;
                case MessageDialogStyle.ErrorMessage:
                    LeftButtonText = "BACK";
                    RightButtonText = "GO";
                    Message = messageInputModel.Message;
                    Title = "?";
                    break;
                case MessageDialogStyle.WarningMessage:
                    LeftButtonText = "BACK";
                    RightButtonText = "GO";
                    Message = messageInputModel.Message;
                    Title = "?";
                    break;
                case MessageDialogStyle.InformationMessage:
                    LeftButtonText = "BACK";
                    RightButtonText = "GO";
                    Message = messageInputModel.Message;
                    Title = "?";
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
