using CustomControlLibrary;
using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.Services;
using MvvmCommonLibrary.Behavior;
using MvvmCommonLibrary.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Windows;
using System.Windows.Input;

namespace AppricationViewModule.ViewModels
{
    public class MessageDialogPageViewModel : BindableBase, IDialogAware
    {
        private DialogNotifyStyle _dialogNotifyStyle;
        public DialogNotifyStyle DialogNotifyStyle
        {
            get => _dialogNotifyStyle;
            set => SetProperty(ref _dialogNotifyStyle, value);
        }

        private string _title = "MessageDialogPage";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _message = "Message";
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private string _leftButtonText = "LeftButtonText";
        public string LeftButtonText
        {
            get => _leftButtonText;
            set => SetProperty(ref _leftButtonText, value);
        }

        private string _rightButtonText = "RightButtonText";
        public string RightButtonText
        {
            get => _rightButtonText;
            set => SetProperty(ref _rightButtonText, value);
        }

        private string _centerButtonText = "CenterButtonText";
        public string CenterButtonText
        {
            get => _centerButtonText;
            set => SetProperty(ref _centerButtonText, value);
        }

        private double _mainWindowWidth;
        public double MainWindowWidth
        {
            get => _mainWindowWidth;
            set => SetProperty(ref _mainWindowWidth, value);
        }

        private double _mainWindowHeight;
        public double MainWindowHeight
        {
            get => _mainWindowHeight;
            set => SetProperty(ref _mainWindowHeight, value);
        }

        public Size MainWindowSize
        {
            get => new Size(MainWindowWidth, MainWindowHeight);
            set
            {
                MainWindowWidth = value.Width;
                MainWindowHeight = value.Height;
            }
        }

        public ICommand CancelCommand { get; }

        public ICommand OkCommand { get; }

        public ICommand CloseCommand { get; }

        public IMessageService MessageService { get; }

        public IRegionManager RegionManager { get; }

        public MessageDialogPageViewModel(IMessageService messageService, IRegionManager regionManager)
        {
            MessageService = messageService;
            RegionManager = regionManager;

            OkCommand = new DelegateCommand(() => RequestClose(new DialogResult(ButtonResult.OK)));
            CancelCommand = new DelegateCommand(() => RequestClose(new DialogResult(ButtonResult.Cancel)));
            CloseCommand = new DelegateCommand(() => RequestClose(new DialogResult(ButtonResult.None)));

            ContentSizeRegister.OnSizeChanged += ContentSizeRegister_OnSizeChanged;
            MainWindowSize = ContentSizeRegister.RegistElementSize["MainWindowContent"];
        }

        private void ContentSizeRegister_OnSizeChanged(string Key, Size element)
        {
            MainWindowWidth = element.Width;
            MainWindowHeight = element.Height;
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
                DialogNotifyStyle = messageInputModel.MessageDialogStyle switch
                {
                    MessageDialogStyle.ErrorMessage => DialogNotifyStyle.Error,
                    MessageDialogStyle.WarningMessage => DialogNotifyStyle.Warning,
                    MessageDialogStyle.InformationMessage => DialogNotifyStyle.Information,
                    MessageDialogStyle.ConfirmMessage => DialogNotifyStyle.Confirm,
                    _ => throw new NotImplementedException(),
                };
                LeftButtonText = messageInputModel.LeftButtonCaption;
                RightButtonText = messageInputModel.RightButtonCaption;
                CenterButtonText = messageInputModel.CenterButtonText;
                Message = messageInputModel.Message.GetMessage();
                Title = messageInputModel.Title;
            }
            else
            {
                DialogNotifyStyle = DialogNotifyStyle.Error;
                Title = messageInputModel.Exception.GetType().Name;
                Message = messageInputModel.Exception.Message + "\r\n";

                Exception innerException = messageInputModel.Exception.InnerException;
                while (innerException != null)
                {
                    Message += "\r\n";
                    Message += "InnerException\r\n";
                    Message += innerException.GetType().Name + "\r\n";
                    Message += innerException.Message + "\r\n";

                    innerException = innerException.InnerException;
                }

                CenterButtonText = MessageService.GetMessage(MessageId.CloseButtonCaption);
            }
        }
    }
}
