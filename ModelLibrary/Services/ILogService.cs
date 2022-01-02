using System.Runtime.CompilerServices;

namespace ModelLibrary.Services
{
    public interface ILogService
    {
        public void StartMethod([CallerMemberName] string methodName = null);
        public void EndMethod([CallerMemberName] string methodName = null);
    }
}
