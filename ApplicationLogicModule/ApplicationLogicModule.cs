using ApplicationLogicModule.ApplicationLogics;
using LogicCommonLibrary.DataAccess;
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
            _ = containerRegistry.RegisterSingleton<IApplicationLogic, ApplicationLogicRepository>();
            _ = containerRegistry.RegisterSingleton<IDatabaseConnection, DatabaseConnection>();
        }
    }
}
