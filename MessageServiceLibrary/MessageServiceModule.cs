using MessageServiceLibrary.Views;
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
            containerRegistry.RegisterDialog<MessageDialog>();
        }
    }
}
