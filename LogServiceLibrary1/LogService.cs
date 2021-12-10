using ModelLibrary.Service;
using System;

namespace LogServiceLibrary
{
    public class LogService : ILogService
    {
        public ILogService Logger => throw new NotImplementedException();

        public LogService()
        {

        }
    }
}
