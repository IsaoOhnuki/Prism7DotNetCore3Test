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
using System.ComponentModel;
using System.Windows.Input;

namespace AppricationViewModule.ViewModels
{
    public class ReserveEditViewModel : ViewModelBase
    {
        public IApplicationLogic ApplicationLogic { get; private set; }

        public ICommand OkCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public bool OkEnable
        {
            get => SelectedReserve == null ? false : SelectedReserve.OldItem.ReserveId == 0 || SelectedReserve.Editing;
        }

        private ReserveItemModel _selectedReserve;
        public ReserveItemModel SelectedReserve
        {
            get => _selectedReserve;
            set
            {
                SetProperty(ref _selectedReserve, value);
                RaisePropertyChanged(nameof(OkEnable));
            }
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
                        TableClass = SelectedReserve.Item,
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
                Item = parameter as TReserve,
            };
            SelectedReserve.PropertyChanged += SelectedReserve_PropertyChanged;
        }

        private void SelectedReserve_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(OkEnable));
        }

        public override void PreviousInisiarizeView(object parameter)
        {

        }
    }
}
