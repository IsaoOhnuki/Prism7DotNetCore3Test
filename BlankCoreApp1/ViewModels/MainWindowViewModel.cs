using MvvmLibrary;
using Prism.Mvvm;

namespace BlankCoreApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ContentRegionName { get; }

        public string OverwrapRegionName { get; }

        public MainWindowViewModel()
        {
            ContentRegionName = ViewConst.MainViewRegion_Content;
            OverwrapRegionName = ViewConst.MainViewRegion_OverwrapContent;
        }
    }
}
