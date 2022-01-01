using ModelLibrary.Services;

namespace ModelLibrary.ModelBases
{
    public class LogicBase
    {
        //[Dependency]
        public static ILogService Logger { get; set; }
    }
}
