using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.Services;
using MvvmCommonLibrary.Mvvm;
using Prism.Regions;
using System;

namespace AppricationViewModule.ViewModels
{
    public class ReserveEditViewModel : ViewModelBase
    {
        public IApplicationLogic ApplicationLogic { get; private set; }

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

        public TReserve SelectedReserve
        {
            get => new TReserve()
            {
                ReserveStart = StartDateTime,
                ReserveEnd = EndDateTime,
                BlockStart = StartDate + StartBlockTime,
                BlockEnd = EndDate + EndBlockTime,
                ReserveMemo = ReserveMemo,
                ReserveMemo1 = ReserveMemo1,
            };
            set
            {
                StartDateTime = value.ReserveStart;
                EndDateTime = value.ReserveEnd;
                StartBlockTime = value.BlockStart.TimeOfDay;
                EndBlockTime = value.BlockEnd.TimeOfDay;
                ReserveMemo = value.ReserveMemo;
                ReserveMemo1 = value.ReserveMemo1;
            }
        }

        public ReserveEditViewModel(ILogService logService, IRegionManager regionManager, IMessageService messageService,
            IApplicationLogic applicationLogic)
            : base(logService, regionManager, messageService)
        {
            ApplicationLogic = applicationLogic;

            CreateReserveInputModel inputModel = new CreateReserveInputModel()
            {
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now,
            };
            SelectedReserve = ApplicationLogic.CreateReserve(inputModel).Reserve;
        }

        public override void InisiarizeView(NavigationParameters navigationParameters)
        {

        }

        public override void PreviousInisiarizeView(NavigationParameters navigationParameters)
        {

        }
    }
}
