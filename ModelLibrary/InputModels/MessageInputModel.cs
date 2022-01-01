using ModelLibrary.Enumerate;
using ModelLibrary.Models;
using System;

namespace ModelLibrary.InputModels
{
    public class MessageInputModel
    {
        public MessageDialogStyle MessageDialogStyle { get; set; }

        public string Title { get; set; }

        public MessageModel Message { get; set; }

        public string LeftButtonCaption { get; set; }

        public string RightButtonCaption { get; set; }

        public string CenterButtonText { get; set; }

        public Exception Exception { get; set; }
    }
}
