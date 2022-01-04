using ModelLibrary.Services;
using System.Runtime.CompilerServices;

namespace LogicCommonLibrary.LogicBase
{
    public class LogicBase
    {
        public ILogService Logger { get; set; }

        protected void LogStartMethod([CallerMemberName] string methodName = null)
        {
            Logger.StartMethod(methodName);
        }

        protected void LogEndMethod([CallerMemberName] string methodName = null)
        {
            Logger.EndMethod(methodName);
        }
    }
}
