using ModelLibrary.Enumerate;
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
            ShowMessage(MessageService.GetMessage(MessageId.SuccessMessage),
                MessageService.GetMessage(MessageId.InformationMessageTitle));
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
    }
}
