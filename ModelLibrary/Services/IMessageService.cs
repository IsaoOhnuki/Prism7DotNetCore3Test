using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using Prism.Services.Dialogs;

namespace ModelLibrary.Services
{
    public interface IMessageService : IService
    {
        string GetMessage(MessageId messageId);

        IDialogResult ShowMessage(string message, string title, MessageDialogStyle messageDialogType);

        IDialogResult ShowMessage(MessageInputModel messageInputModel);
    }
}
