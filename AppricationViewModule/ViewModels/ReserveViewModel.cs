using AppricationViewModule.Models;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;
using ModelLibrary.Services;
using MvvmCommonLibrary.Mvvm;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace AppricationViewModule.ViewModels
{
    public class ReserveViewModel : ViewModelBase
    {
        public IApplicationLogic ApplicationLogic { get; private set; }

        public ICommand CreateCommand { get; private set; }

        public ICommand SearchCommand { get; private set; }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (StartDate != value)
                {
                    SetProperty(ref _startDate, value);
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
                if (EndDate != value)
                {
                    SetProperty(ref _endDate, value);
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
                if (StartTime != value)
                {
                    SetProperty(ref _startTime, value);
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
                if (EndTime != value)
                {
                    SetProperty(ref _endTime, value);
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
                if (StartDateTime != value)
                {
                    SetProperty(ref _startDateTime, value);
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
                if (EndDateTime != value)
                {
                    SetProperty(ref _endDateTime, value);
                    EndDate = value.Date;
                    EndTime = value.TimeOfDay;
                }
            }
        }

        private TReserve _currentReserve;

        public TReserve CurrentReserve
        {
            get => _currentReserve;
            set => SetProperty(ref _currentReserve, value);
        }

        private ObservableCollection<ReserveItemModel> _reserves;

        public ObservableCollection<ReserveItemModel> Reserves
        {
            get => _reserves;
            set => SetProperty(ref _reserves, value);
        }

        public ReserveViewModel(ILogService logService, IRegionManager regionManager, IMessageService messageService,
            IApplicationLogic applicationLogic)
            : base(logService, regionManager, messageService)
        {
            ApplicationLogic = applicationLogic;

            SearchCommand = new DelegateCommand(() => SearchPeriodReserve());
            CreateCommand = new DelegateCommand(() => CreateReserve());
        }

        public void CreateReserve()
        {
            GetDataResultModel<TReserve> resultModel =
                ApplicationLogic.CreateReserve(new CreateReserveInputModel()
                {
                    StartDateTime = DateTime.Now,
                    EndDateTime = DateTime.Now,
                });
            DoTransitionPage(
                AppViewConst.ContentRegion_AppViewMainContent,
                    GetViewName(true),
                        AppViewConst.View_ReserveEdit,
                            resultModel.TableClass);
        }

        public void SearchPeriodReserve()
        {
            GetPeriodReserveInputModel inputModel = new GetPeriodReserveInputModel
            {
                ReserveStart = StartDateTime,
                ReserveEnd = EndDateTime,
            };
            GetDataListResultModel<TReserve> resultModel = ApplicationLogic.GetPeriodReserve(inputModel);
            Reserves = new ObservableCollection<ReserveItemModel>();
            Reserves.AddRange(resultModel.DataList.Select(x => new ReserveItemModel { Reserve = x }));
        }

        public override void InisiarizeView(object parameter)
        {
            StartDateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            EndDateTime = StartDateTime.AddMonths(1).AddDays(-1);

            SearchPeriodReserve();
        }

        public override void PreviousInisiarizeView(object parameter)
        {
            if (PreviousView == AppViewConst.View_ReserveEdit)
            {
                bool? success = parameter as bool?;
                if (success.HasValue && success.Value)
                {
                    SearchPeriodReserve();
                }
            }
        }
    }
}
