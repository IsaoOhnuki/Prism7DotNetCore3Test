using ModelLibrary.Constant;
using ModelLibrary.Service;

namespace MessageServiceModule
{
    public class MessageService : IMessageService
    {
        public ILogService Logger { get; private set; }

        public MessageService(ILogService logger)
        {
            Logger = logger;
        }

        public string GetMessage(MessageConst.MessageId messageId)
        {
            return "Message";
        }
    }
}
