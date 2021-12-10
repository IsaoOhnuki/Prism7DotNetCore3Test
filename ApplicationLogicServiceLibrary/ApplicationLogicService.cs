using ModelLibrary.Service;

namespace ApplicationLogicServiceLibrary
{
    public class ApplicationLogicService : IApplicationLogicService
    {
        public ILogService Logger { get; set; }

        public ApplicationLogicService(ILogService logger)
        {
            Logger = logger;
        }
    }
}
