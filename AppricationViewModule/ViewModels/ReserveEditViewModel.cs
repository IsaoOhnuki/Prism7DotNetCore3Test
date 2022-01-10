using AppricationViewModule.Models;
using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;
using ModelLibrary.Services;
using MvvmCommonLibrary.Mvvm;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Windows.Input;

namespace AppricationViewModule.ViewModels
{
    public class ReserveEditViewModel : ViewModelBase
    {
        public IApplicationLogic ApplicationLogic { get; private set; }

        public ICommand OkCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        private ReserveItemModel _selectedReserve;
        public ReserveItemModel SelectedReserve
        {
            get => _selectedReserve;
            set => SetProperty(ref _selectedReserve, value);
        }

        public ReserveEditViewModel(ILogService logService, IRegionManager regionManager, IMessageService messageService,
            IApplicationLogic applicationLogic)
            : base(logService, regionManager, messageService)
        {
            ApplicationLogic = applicationLogic;

            OkCommand = new DelegateCommand(() => Ok());
            CancelCommand = new DelegateCommand(() => Cancel());
        }

        public void Ok()
        {
            ButtonResult result = ShowMessage(MessageDialogStyle.ConfirmMessage,
                MessageService.GetMessage(MessageId.ConfirmMessageTitle),
                MessageService.GetMessage(MessageId.InformationMessageTitle));
            if (result == ButtonResult.OK)
            {
                SetDataInputModel<TReserve> inputModel =
                    new SetDataInputModel<TReserve>()
                    {
                        TableClass = SelectedReserve.Reserve,
                    };

                CountResultModel resultModel;
                if (inputModel.TableClass.ReserveId == 0)
                {
                    resultModel = ApplicationLogic.InsertReserve(inputModel);
                }
                else
                {
                    resultModel = ApplicationLogic.UpdateReserve(inputModel);
                }

                if (!resultModel.Result)
                {
                    ShowMessage(MessageDialogStyle.ErrorMessage, resultModel.Messages[0]);
                }

                DoBackTransition(
                    AppViewConst.ContentRegion_AppViewMainContent,
                        resultModel.Count == 1);
            }
        }

        public void Cancel()
        {
            DoBackTransition(AppViewConst.ContentRegion_AppViewMainContent);
        }

        public override void InisiarizeView(object parameter)
        {
            SelectedReserve = new ReserveItemModel()
            {
                Reserve = parameter as TReserve,
            };
        }

        public override void PreviousInisiarizeView(object parameter)
        {

        }
    }
}
