using ModelLibrary.Service;
using MvvmLibrary.Mvvm;
using MvvmServiceLibrary;
using Prism.Commands;
using Prism.Regions;
using System.Windows.Input;

namespace AppricationViewModule.ViewModels
{
    public class TopPageViewModel : ViewModelBase
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
            ShowOverwrapPage(GetViewName(), ViewConst.MessageDialogPage);
        }

        protected bool IsCanAccept()
        {
            return true;
        }

        public override void InisiarizeView(NavigationParameters navigationParameters)
        {
        }
    }
}
