using ModelLibrary.Services;

namespace ApplicationLogicModule
{
    public class ApplicationLogic : IApplicationLogic
    {
        public ILogService Logger { get; set; }

        public ApplicationLogic(ILogService logger)
        {
            Logger = logger;
        }
    }
}
