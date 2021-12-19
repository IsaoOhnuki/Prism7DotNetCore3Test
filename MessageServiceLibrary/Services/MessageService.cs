using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.Services;
using Prism.Services.Dialogs;
using System.Windows;

namespace MessageServiceModule.Services
{
    public class MessageService : IMessageService
    {
        public ILogService Logger { get; private set; }

        public IDialogService DialogService { get; private set; }

        public MessageService(ILogService logger, IDialogService dialogService)
        {
            Logger = logger;
            DialogService = dialogService;
        }

        public string GetMessage(MessageId messageId)
        {
            return System.Configuration.ConfigurationManager.AppSettings[messageId.ToString()];
        }

        public IDialogResult ShowMessage(MessageInputModel messageInputModel)
        {
            IDialogResult dialogResult = null;
            DialogService.ShowDialog(
                messageInputModel.MessageDialogName,
                new DialogParameters
                {
                    { nameof(MessageInputModel), messageInputModel },
                },
                x => dialogResult = x);

            return dialogResult;
        }
    }
}
