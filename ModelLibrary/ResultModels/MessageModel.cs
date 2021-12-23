using System.Collections.Generic;
using System.Globalization;

namespace ModelLibrary.ResultModels
{
    public class MessageModel
    {
        public string Message { get; set; }

        public List<string> MessageParameter { get; set; }

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

        public MessageModel(string message)
        {
            Message = message;
        }

        public MessageModel(string message, string[] parameter)
        {
            Message = message;
            MessageParameter = new List<string>();
            MessageParameter.AddRange(parameter);
        }
    }
}
