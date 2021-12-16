using MvvmLibrary;
using MvvmUtilityLibrary.Interface;
using Prism.Mvvm;

namespace BlankCoreApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        protected IContentRegionMediator ContentRegionMediator { get; private set; }

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ContentRegionName { get; }

        public string OverwrapRegionName { get; }

        public MainWindowViewModel(IContentRegionMediator contentRegionMediator)
        {
            ContentRegionMediator = contentRegionMediator;
            ContentRegionName = ViewConst.MainViewRegion_Content;
            OverwrapRegionName = ViewConst.MainViewRegion_OverwrapContent;
        }
    }
}
