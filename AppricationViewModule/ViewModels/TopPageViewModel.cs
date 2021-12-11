using ModelLibrary.Service;
using MvvmLibrary;
using MvvmLibrary.Mvvm;
using Prism.Commands;
using Prism.Regions;
using System.Windows.Input;

namespace AppricationViewModule.ViewModels
{
    public class TopPageViewModel : CommonViewModel
    {
        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private string _acceptText;
        public string AcceptText
        {
            get => _acceptText;
            set => SetProperty(ref _acceptText, value);
        }

        public ICommand AcceptCommand { get; }

        public TopPageViewModel(ILogService logService, IRegionManager regionManager)
            : base(logService, regionManager)
        {
            AcceptCommand = new DelegateCommand(DoAccept, IsCanAccept);

            Text = nameof(TopPageViewModel);
            AcceptText = "GO";
        }

        protected void DoAccept()
        {
            RegionManager.RequestNavigate(ViewConst.ContentRegion, ViewConst.MessageDialogPage);
        }

        protected bool IsCanAccept()
        {
            return true;
        }
    }
}
