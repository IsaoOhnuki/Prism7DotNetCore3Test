using ApplicationLogicModule;
using BlankCoreApp1.Services;
using BlankCoreApp1.Views;
using ModelLibrary.Services;
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
            _ = containerRegistry.RegisterSingleton<IContentViewService, ContentViewService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            _ = moduleCatalog.AddModule<ApplicationLogicModule.ApplicationLogicModule>();
            _ = moduleCatalog.AddModule<AppricationViewModule.AppricationViewModule>();

            // MainWindowで使いたいがDLLロードが間に合わないためMainWindowViewModelでロードしてResolveする。
            _ = moduleCatalog.AddModule<MessageServiceModule.MessageServiceModule>(InitializationMode.OnDemand);
            _ = moduleCatalog.AddModule<LogServiceModule.LogServiceModule>(InitializationMode.OnDemand);
        }
    }
}
