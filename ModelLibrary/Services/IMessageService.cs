using ModelLibrary.Constant;
using ModelLibrary.Enumerate;
using Prism.Services.Dialogs;

namespace ModelLibrary.Services
{
    public interface IMessageService : IService
    {
        string GetMessage(MessageConst.MessageId messageId);

        ButtonResult ShowMessage(string message, string title, MessageDialogStyle messageDialogType);
    }
}
