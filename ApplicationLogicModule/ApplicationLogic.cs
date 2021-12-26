using ModelLibrary.Services;

namespace ApplicationLogicModule
{
    public class Table_1
    {
        public string col_1 { get; set; }
        public int col_2 { get; set; }
        public byte[] col_3 { get; set; }
    }

    public class ApplicationLogic : IApplicationLogic
    {
        public ILogService Logger { get; set; }

        public ApplicationLogic(ILogService logger)
        {
            Logger = logger;
        }
    }
}
