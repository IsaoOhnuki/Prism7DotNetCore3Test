using BlankCoreApp1.Behavior;
using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.Services;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace BlankCoreApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public IMessageService MessageService { get; private set; }

        public IContentViewService ContentViewService { get; private set; }

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
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
            }

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
            MessageService.ShowMessage(messageInputModel);
        }
    }
}
