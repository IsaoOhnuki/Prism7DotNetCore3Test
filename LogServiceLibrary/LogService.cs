using ModelLibrary.Services;
using System;

namespace LogServiceModule
{
    public class LogService : ILogService
    {
        public ILogService Logger => throw new NotImplementedException();

        public LogService()
        {

        }
    }
}
