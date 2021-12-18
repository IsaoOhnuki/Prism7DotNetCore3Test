using ModelLibrary.Constant;
using Prism.Services.Dialogs;

namespace MvvmServiceLibrary.Mvvm
{
    public interface IMessageService
    {
        string GetMessage(MessageConst.MessageId messageId);

        ButtonResult ShowMessage(string message, string title, MessageDialogStyle messageDialogType);
    }
}
