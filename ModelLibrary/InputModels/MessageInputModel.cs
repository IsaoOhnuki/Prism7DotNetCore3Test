using ModelLibrary.Enumerate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.InputModels
{
    public class MessageInputModel
    {
        public string MessageDialogName { get; set; }

        public MessageDialogStyle MessageDialogStyle { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public List<string> MessageParameter { get; set; }
    }
}
