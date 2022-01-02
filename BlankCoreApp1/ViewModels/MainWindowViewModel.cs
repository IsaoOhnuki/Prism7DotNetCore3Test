using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.Services;
using MvvmCommonLibrary.Behavior;
using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace BlankCoreApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public IMessageService MessageService { get; private set; }

        public ILogService LogService { get; private set; }

        public IContentViewService ContentViewService { get; private set; }

        public IDatabaseConnection DatabaseConnection { get; private set; }

        private string _title = "Prism Application";
        public string Title
        {
            get => _title;
            set => _ = SetProperty(ref _title, value);
        }

        private string _mainContentName = "MainWindowContent";
        public string MainContentName
        {
            get => _mainContentName;
            set => _ = SetProperty(ref _mainContentName, value);
        }

        private string _mainWindowName = "MainWindow";
        public string MainWindowName
        {
            get => _mainWindowName;
            set => _ = SetProperty(ref _mainWindowName, value);
        }

        public string ContentRegionName { get; }

        public string OverwrapRegionName { get; }

        public MainWindowViewModel(IContainerProvider container, IModuleManager moduleManager, IContentViewService contentViewService)
        {
            ContentViewService = contentViewService;

            {   // DIでもらおうとするとDLLロード、Resolveが間に合わないので例外が発生する。
                // なので自前でロードしてResolveする。
                moduleManager.LoadModule(nameof(MessageServiceModule.MessageServiceModule));
                MessageService = container.Resolve<IMessageService>();
                moduleManager.LoadModule(nameof(LogServiceModule.LogServiceModule));
                LogService = container.Resolve<ILogService>();
                moduleManager.LoadModule(nameof(ApplicationLogicModule.ApplicationLogicModule));
                DatabaseConnection = container.Resolve<IDatabaseConnection>();
            }

            string server = "localhost\\SQLEXPRESS";
            string database = "TestDb";
            string user = "sa";
            string pass = "Express";
            string conn = "Persist Security Info=False;User ID=" + user + ";Password=" + pass + ";Initial Catalog=" + database + ";Server=" + server;
            DatabaseConnection.SetConnection(conn);

            ViewElementRegister.OnRegistElement += ViewElementRegister_OnRegistElement;
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        private void ViewElementRegister_OnRegistElement(string elementName, FrameworkElement element)
        {
            if (element is IAddChild parent)
            {
                ContentControl mainContent = new ContentControl();
                mainContent.SetValue(RegionManager.RegionNameProperty, ContentViewType.MainWindowContent.ToString());
                parent.AddChild(mainContent);
                ContentControl overwrapContent = new ContentControl();
                overwrapContent.SetValue(RegionManager.RegionNameProperty, ContentViewType.MainWindowOverwrapContent.ToString());
                parent.AddChild(overwrapContent);
                ContentViewService.RegisterWindowContent(ContentViewType.MainWindowContent, mainContent);
                ContentViewService.RegisterWindowContent(ContentViewType.MainWindowOverwrapContent, overwrapContent);
            }
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageInputModel messageInputModel = new MessageInputModel()
            {
                Exception = e.Exception,
            };
            _ = MessageService.ShowMessage(messageInputModel);
        }
    }
}
