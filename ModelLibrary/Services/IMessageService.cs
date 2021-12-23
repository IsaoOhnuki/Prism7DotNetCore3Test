using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using Prism.Services.Dialogs;
using System;

namespace ModelLibrary.Services
{
    public interface IMessageService
    {
        void SetMessageDialog(string dialogName);

        string GetMessage(MessageId messageId);

        ButtonResult ShowMessage(MessageInputModel messageInputModel);

        ButtonResult ShowMessage(Exception exception);

        ButtonResult ShowMessage(MessageDialogStyle messageDialogStyle, string message, string title = null);

        ButtonResult ShowMessage(MessageDialogStyle messageDialogStyle, string message, string[] parameter, string title = null);
    }
}
