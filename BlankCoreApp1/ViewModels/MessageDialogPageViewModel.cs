using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.Services;
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

        private string _centerButtonText;
        public string CenterButtonText
        {
            get => _centerButtonText;
            set => SetProperty(ref _centerButtonText, value);
        }

        public ICommand BackCommand { get; }


        public ICommand GoCommand { get; }

        public ICommand StopCommand { get; }

        private bool _confirmStyleButton;
        public bool ConfirmStyleButton
        {
            get => _confirmStyleButton;
            set => SetProperty(ref _confirmStyleButton, value);
        }

        public IMessageService MessageService { get; }

        public MessageDialogPageViewModel(IMessageService messageService)
        {
            MessageService = messageService;

            GoCommand = new DelegateCommand(TransitionGo);
            BackCommand = new DelegateCommand(TransitionBack);
            StopCommand = new DelegateCommand(TransitionBack);
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

            if (messageInputModel.Exception == null)
            {
                ConfirmStyleButton = messageInputModel.MessageDialogStyle == MessageDialogStyle.ConfirmMessage;
                LeftButtonText = messageInputModel.LeftButtonCaption;
                RightButtonText = messageInputModel.RightButtonCaption;
                CenterButtonText = messageInputModel.CenterButtonText;
                Message = messageInputModel.Message;
                Title = messageInputModel.Title;
            }
            else
            {
                ConfirmStyleButton = false;
                Title = nameof(messageInputModel.Exception);
                Message = messageInputModel.Exception.Message;
                CenterButtonText = MessageService.GetMessage(MessageId.CloseButtonCaption);
            }
        }
    }
}
