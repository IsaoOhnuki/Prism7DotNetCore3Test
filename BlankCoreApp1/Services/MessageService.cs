using AppricationViewModule;
using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.Services;
using Prism.Services.Dialogs;

namespace BlankCoreApp1.Services
{
    public class MessageService : IMessageService
    {
        public IDialogService DialogService { get; private set; }

        public MessageService(IDialogService dialogService)
        {
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
                ViewConst.ViewPage_MessageDialogPage,
                new DialogParameters
                {
                    { nameof(MessageInputModel), messageInputModel },
                },
                x => dialogResult = x);

            return dialogResult;
        }
    }
}
