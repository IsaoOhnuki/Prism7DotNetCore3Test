using ModelLibrary.InputModels;
using ModelLibrary.Services;
using MvvmServiceLibrary;
using Prism.Mvvm;
using System.Windows;

namespace BlankCoreApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public IMessageService MessageService { get; private set; }

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ContentRegionName { get; }

        public string OverwrapRegionName { get; }

        public MainWindowViewModel(IMessageService messageService)
        {
            MessageService = messageService;

            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;

            ContentRegionName = ViewConst.MainViewRegion_Content;
            OverwrapRegionName = ViewConst.MainViewRegion_OverwrapContent;
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageInputModel messageInputModel = new MessageInputModel()
            {
                MessageDialogName = ViewConst.ViewPage_MessageDialogPage,
                Exception = e.Exception,
            };
            MessageService.ShowMessage(messageInputModel);
        }
    }
}
