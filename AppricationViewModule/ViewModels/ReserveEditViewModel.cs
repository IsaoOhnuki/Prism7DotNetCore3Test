using ModelLibrary.Services;
using MvvmCommonLibrary.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public ReserveEditViewModel(ILogService logService, IRegionManager regionManager, IMessageService messageService,
            IApplicationLogic applicationLogic)
            : base(logService, regionManager, messageService)
        {
            ApplicationLogic = applicationLogic;

            StartDateTime = DateTime.Now;
            EndDateTime = DateTime.Now;
        }

        public override void InisiarizeView(NavigationParameters navigationParameters)
        {

        }

        public override void PreviousInisiarizeView(NavigationParameters navigationParameters)
        {

        }
    }
}
