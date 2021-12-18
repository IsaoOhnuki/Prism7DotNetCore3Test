using ModelLibrary;
using ModelLibrary.Constant;
using ModelLibrary.inputModel;
using ModelLibrary.Service;
using Prism.Services.Dialogs;

namespace BlankCoreApp1.Services
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

        public string GetMessage(MessageConst.MessageId messageId)
        {
            return "Message";
        }

        public ButtonResult ShowMessage(string message, string title, MessageDialogStyle messageDialogType)
        {
            MessageContent messageContent = new MessageContent()
            {
                Message = message,
                Title = title,
                MessageDialogValue = messageDialogType
            };

            IDialogResult dialogResult = null;
            DialogService.ShowDialog("MessageDialog",
                new DialogParameters
                {
                    { "MessageContent", messageContent }
                },
                result => dialogResult = result);

            return dialogResult.Result;
        }
    }
}
