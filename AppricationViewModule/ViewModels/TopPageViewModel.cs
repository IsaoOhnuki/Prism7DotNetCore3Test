using ModelLibrary.Enumerate;
using ModelLibrary.Services;
using MvvmLibrary.Mvvm;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
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

        public ICommand ErrorCommand { get; }

        public TopPageViewModel(ILogService logService, IRegionManager regionManager, IMessageService messageService)
            : base(logService, regionManager, messageService)
        {
            AcceptCommand = new DelegateCommand(DoAccept, IsCanAccept);
            ErrorCommand = new DelegateCommand(() => throw new Exception("Error", new Exception("Error", new Exception())), () => true);

            Text = nameof(TopPageViewModel);
            AcceptText = "GO";
        }

        protected void DoAccept()
        {
            ButtonResult result = ShowMessage(MessageDialogStyle.ConfirmMessage,
                MessageService.GetMessage(MessageId.ConfirmMessageTitle),
                MessageService.GetMessage(MessageId.InformationMessageTitle));
            if (result == ButtonResult.OK)
            {
                DoTransitionPage(AppViewConst.ContentRegion_AppViewMainContent, GetViewName(), AppViewConst.View_ViewA);
            }
            else if (result == ButtonResult.Cancel)
            {

            }
            else
            {
                throw new NotImplementedException();
            }
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
