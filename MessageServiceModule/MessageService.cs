using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.ResultModels;
using ModelLibrary.Services;
using Prism.Services.Dialogs;
using System;

namespace MessageServiceModule
{
    public class MessageService : IMessageService
    {
        public IDialogService DialogService { get; private set; }

        public string DialogName { get; private set; }

        public MessageService(IDialogService dialogService)
        {
            DialogService = dialogService;
        }

        public void SetMessageDialog(string dialogName)
        {
            DialogName = dialogName;
        }

        public string GetMessage(MessageId messageId)
        {
            return System.Configuration.ConfigurationManager.AppSettings[messageId.ToString()];
        }

        public ButtonResult ShowMessage(MessageInputModel messageInputModel)
        {
            if (string.IsNullOrEmpty(DialogName))
            {
                return ButtonResult.None;
            }
            else
            {
                IDialogResult dialogResult = null;
                DialogService.ShowDialog(
                    DialogName,
                    new DialogParameters
                    {
                        { nameof(MessageInputModel), messageInputModel },
                    },
                    x => dialogResult = x);

                return dialogResult.Result;
            }
        }

        public ButtonResult ShowMessage(Exception exception)
        {
            MessageInputModel messageInput = new MessageInputModel
            {
                Exception = exception,
            };
            ButtonResult result = ShowMessage(messageInput);
            return result;
        }

        public ButtonResult ShowMessage(MessageDialogStyle messageDialogStyle, string message, string title = null)
        {
            MessageInputModel messageInput = new MessageInputModel
            {
                Title = title ?? GetMessage(MessageId.ConfirmMessageTitle),
                Message = new MessageModel(message),
                MessageDialogStyle = messageDialogStyle,
                LeftButtonCaption = GetMessage(MessageId.CancelButtonCaption),
                RightButtonCaption = GetMessage(MessageId.OkButtonCaption),
                CenterButtonText = GetMessage(MessageId.CloseButtonCaption),
            };
            ButtonResult result = ShowMessage(messageInput);
            return result;
        }

        public ButtonResult ShowMessage(MessageDialogStyle messageDialogStyle, string message, string[] parameter, string title = null)
        {
            MessageInputModel messageInput = new MessageInputModel
            {
                Title = title ?? GetMessage(MessageId.ConfirmMessageTitle),
                Message = new MessageModel(message, parameter),
                MessageDialogStyle = messageDialogStyle,
                LeftButtonCaption = GetMessage(MessageId.CancelButtonCaption),
                RightButtonCaption = GetMessage(MessageId.OkButtonCaption),
                CenterButtonText = GetMessage(MessageId.CloseButtonCaption),
            };
            ButtonResult result = ShowMessage(messageInput);
            return result;
        }
    }
}
