using ModelLibrary.Services;
using Prism.Ioc;
using Prism.Modularity;

namespace MessageServiceModule
{
    public class MessageServiceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }
    }
}
