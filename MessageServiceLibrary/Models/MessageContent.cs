using ModelLibrary.Enumerate;

namespace MessageServiceLibrary.Models
{
    public class MessageContent
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public MessageDialogStyle MessageDialogValue { get; set; }
    }
}
