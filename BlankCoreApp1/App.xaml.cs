using BlankCoreApp1.Views;
using MvvmUtilityLibrary.ContentRegionMediator;
using MvvmUtilityLibrary.Interface;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace BlankCoreApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IContentRegionMediator, ContentRegionMediator>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<LogServiceModule.LogServiceModule>();
            moduleCatalog.AddModule<MessageServiceModule.MessageServiceModule>();
            moduleCatalog.AddModule<ApplicationLogicServiceModule.ApplicationLogicServiceModule>();
            moduleCatalog.AddModule<AppricationViewModule.AppricationViewModule>();
        }
    }
}
