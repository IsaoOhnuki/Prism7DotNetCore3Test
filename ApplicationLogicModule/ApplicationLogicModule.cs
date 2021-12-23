using ModelLibrary.Services;
using Prism.Ioc;
using Prism.Modularity;

namespace ApplicationLogicModule
{
    public class ApplicationLogicModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _ = containerRegistry.RegisterSingleton<IApplicationLogic, ApplicationLogic>();
        }
    }
}
