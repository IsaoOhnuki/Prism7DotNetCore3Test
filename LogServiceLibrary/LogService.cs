using ModelLibrary.Services;
using System;
using System.Runtime.CompilerServices;

namespace LogServiceModule
{
    public class LogService : ILogService
    {
        public ILogService Logger => throw new NotImplementedException();

        public LogService()
        {

        }

        public void StartMethod([CallerMemberName] string methodName = null)
        {
            throw new NotImplementedException();
        }

        public void EndMethod([CallerMemberName] string methodName = null)
        {
            throw new NotImplementedException();
        }
    }
}
