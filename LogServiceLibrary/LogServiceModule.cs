using ModelLibrary.Service;
using Prism.Ioc;
using Prism.Modularity;

namespace LogServiceModule
{
    public class LogServiceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILogService, LogService>();
        }
    }
}
