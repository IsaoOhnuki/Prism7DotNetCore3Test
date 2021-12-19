using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.Services;
using Prism.Services.Dialogs;

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
            return "Message";
        }

        IDialogResult IMessageService.ShowMessage(MessageInputModel messageInputModel)
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
