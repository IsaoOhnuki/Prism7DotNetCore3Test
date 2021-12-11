using ModelLibrary.Constant;

namespace ModelLibrary.Service
{
    public interface IMessageService : IService
    {
        string GetMessage(MessageConst.MessageId messageId);
    }
}
