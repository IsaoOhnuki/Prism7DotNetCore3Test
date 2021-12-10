using ModelLibrary.Service;

namespace MessageServiceLibrary
{
    public class MessageService : IMessageService
    {
        public ILogService Logger { get; private set; }

        public MessageService(ILogService logger)
        {
            Logger = logger;
        }
    }
}
