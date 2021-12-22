using ModelLibrary.Enumerate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.InputModels
{
    public class MessageInputModel
    {
        public MessageDialogStyle MessageDialogStyle { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public List<string> MessageParameter { get; set; }

        public string LeftButtonCaption { get; set; }

        public string RightButtonCaption { get; set; }

        public string CenterButtonText { get; set; }

        public Exception Exception { get; set; }
    }
}
