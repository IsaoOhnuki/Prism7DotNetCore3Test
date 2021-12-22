using AppricationViewModule;
using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.Services;
using Prism.Services.Dialogs;
using System;

namespace BlankCoreApp1.Services
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

        public IDialogResult ShowMessage(MessageInputModel messageInputModel)
        {
            if (string.IsNullOrEmpty(DialogName))
            {
                throw new ArgumentException("メッセージダイアログが指定されていません。");
            }

            IDialogResult dialogResult = null;
            DialogService.ShowDialog(
                DialogName,
                new DialogParameters
                {
                    { nameof(MessageInputModel), messageInputModel },
                },
                x => dialogResult = x);

            return dialogResult;
        }
    }
}
