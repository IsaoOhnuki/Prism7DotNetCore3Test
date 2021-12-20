using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using Prism.Services.Dialogs;

namespace ModelLibrary.Services
{
    public interface IMessageService
    {
        string GetMessage(MessageId messageId);

        IDialogResult ShowMessage(MessageInputModel messageInputModel);
    }
}
