using ModelLibrary.Services;
using Prism.Ioc;
using Prism.Modularity;

namespace ApplicationLogicServiceModule
{
    public class ApplicationLogicServiceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationLogicService, ApplicationLogicService>();
        }
    }
}
