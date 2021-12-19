using ModelLibrary.Services;
using MvvmLibrary.Mvvm;
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

        public TopPageViewModel(ILogService logService, IRegionManager regionManager, IMessageService messageService)
            : base(logService, regionManager, messageService)
        {
            AcceptCommand = new DelegateCommand(DoAccept, IsCanAccept);

            Text = nameof(TopPageViewModel);
            AcceptText = "GO";
        }

        protected void DoAccept()
        {
            ShowMessage("0123456789");
        }

        protected bool IsCanAccept()
        {
            return true;
        }

        public override void InisiarizeView(NavigationParameters navigationParameters)
        {
        }

        public override void PreviousInisiarizeView(NavigationParameters navigationParameters)
        {
        }

        //public override void ReturnMessageDialog(MessageDialogResult messageDialogResult, NavigationParameters navigationParameters)
        //{
        //    switch (messageDialogResult)
        //    {
        //        case MessageDialogResult.Ok:
        //            DoTransitionPage(GetViewName(), ViewConst.ViewPage_TopPage);
        //            break;
        //        case MessageDialogResult.Cancel:
        //            DoTransitionPage(GetViewName(), ViewConst.ViewPage_ViewA);
        //            break;
        //        default:
        //            throw new NotImplementedException();
        //    }
        //}
    }
}
