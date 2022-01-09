using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.Models.Database.Enumerate;
using ModelLibrary.ResultModels;
using ModelLibrary.Services;
using MvvmCommonLibrary.Mvvm;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Windows.Input;

namespace AppricationViewModule.ViewModels
{
    public class ReserveEditViewModel : ViewModelBase
    {
        public IApplicationLogic ApplicationLogic { get; private set; }

        public ICommand OkCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        private int _reserveId;

        public int ReserveId
        {
            get => _reserveId;
            set => SetProperty(ref _reserveId, value);
        }

        private ReserveState _state;

        public ReserveState State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (_startDate != value)
                {
                    _ = SetProperty(ref _startDate, value);
                    StartDateTime = StartDate + StartTime;
                }
            }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (_endDate != value)
                {
                    _ = SetProperty(ref _endDate, value);
                    EndDateTime = EndDate + EndTime;
                }
            }
        }

        private TimeSpan _startTime;

        public TimeSpan StartTime
        {
            get => _startTime;
            set
            {
                if (_startTime != value)
                {
                    _ = SetProperty(ref _startTime, value);
                    StartDateTime = StartDate + StartTime;
                }
            }
        }

        private TimeSpan _endTime;

        public TimeSpan EndTime
        {
            get => _endTime;
            set
            {
                if (_endTime != value)
                {
                    _ = SetProperty(ref _endTime, value);
                    EndDateTime = EndDate + EndTime;
                }
            }
        }

        private TimeSpan _startBlockTime;

        public TimeSpan StartBlockTime
        {
            get => _startBlockTime;
            set
            {
                if (_startBlockTime != value)
                {
                    _ = SetProperty(ref _startBlockTime, value);
                }
            }
        }

        private TimeSpan _endBlockTime;

        public TimeSpan EndBlockTime
        {
            get => _endBlockTime;
            set
            {
                if (_endBlockTime != value)
                {
                    _ = SetProperty(ref _endBlockTime, value);
                }
            }
        }

        private DateTime _startDateTime;

        public DateTime StartDateTime
        {
            get => _startDateTime;
            set
            {
                if (_startDateTime != value)
                {
                    _ = SetProperty(ref _startDateTime, value);
                    StartDate = value.Date;
                    StartTime = value.TimeOfDay;
                }
            }
        }

        private DateTime _endDateTime;

        public DateTime EndDateTime
        {
            get => _endDateTime;
            set
            {
                if (_endDateTime != value)
                {
                    _ = SetProperty(ref _endDateTime, value);
                    EndDate = value.Date;
                    EndTime = value.TimeOfDay;
                }
            }
        }

        private string _reserveMemo;

        public string ReserveMemo
        {
            get => _reserveMemo;
            set
            {
                if (_reserveMemo != value)
                {
                    _ = SetProperty(ref _reserveMemo, value);
                }
            }
        }

        private string _reserveMemo1;

        public string ReserveMemo1
        {
            get => _reserveMemo1;
            set
            {
                if (_reserveMemo1 != value)
                {
                    _ = SetProperty(ref _reserveMemo1, value);
                }
            }
        }

        private DateTime _optimist;
        public DateTime Optimist
        {
            get => _optimist;
            set => SetProperty(ref _optimist, value);
        }

        public TReserve SelectedReserve
        {
            get => new TReserve()
            {
                ReserveId = ReserveId,
                State = State,
                ReserveStart = StartDateTime,
                ReserveEnd = EndDateTime,
                BlockStart = StartDate + StartBlockTime,
                BlockEnd = EndDate + EndBlockTime,
                ReserveMemo = ReserveMemo,
                ReserveMemo1 = ReserveMemo1,
                Optimist = Optimist,
            };
            set
            {
                ReserveId = value.ReserveId;
                State = value.State;
                StartDateTime = value.ReserveStart;
                EndDateTime = value.ReserveEnd;
                StartBlockTime = value.BlockStart.TimeOfDay;
                EndBlockTime = value.BlockEnd.TimeOfDay;
                ReserveMemo = value.ReserveMemo;
                ReserveMemo1 = value.ReserveMemo1;
                Optimist = value.Optimist;
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
                        TableClass = SelectedReserve,
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
            SelectedReserve = parameter as TReserve;
        }

        public override void PreviousInisiarizeView(object parameter)
        {

        }
    }
}
