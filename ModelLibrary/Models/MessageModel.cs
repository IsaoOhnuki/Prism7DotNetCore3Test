using System;
using System.Collections.Generic;
using System.Globalization;

namespace ModelLibrary.Models
{
    public class MessageModel
    {
        public string Message { get; set; }

        public List<string> MessageParameter { get; set; }

        public Exception Exception { get; set; }

        public string GetMessage()
        {
            if (MessageParameter != null)
            {
                return string.Format(CultureInfo.CurrentCulture, Message, MessageParameter.ToArray());
            }
            else
            {
                return Message;
            }
        }

        public MessageModel(string message, string[] parameter = null, Exception exception = null)
        {
            Message = message;
            MessageParameter = new List<string>();
            if (parameter != null)
            {
                MessageParameter.AddRange(parameter);
            }
            Exception = exception;
        }
    }
}
