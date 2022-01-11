using AppricationViewModule.Models;
using ModelLibrary.Enumerate;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.Models.Database.Enumerate;
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

        public ICommand CreateReserveCommand { get; private set; }

        public ICommand CreateEstimateReserveCommand { get; private set; }

        public ICommand CreateBlockReserveCommand { get; private set; }

        public ICommand SearchCommand { get; private set; }

        public ICommand ShowSelectedItemCommand { get; private set; }

        private DateTime _startDateTime;

        public DateTime StartDateTime
        {
            get => _startDateTime;
            set
            {
                if (StartDateTime != value)
                {
                    SetProperty(ref _startDateTime, value);
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
                }
            }
        }

        private ReserveItemModel _currentReserve;

        public ReserveItemModel CurrentReserve
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
            CreateReserveCommand = new DelegateCommand(() => CreateReserve(ReserveType.Reserve));
            CreateBlockReserveCommand = new DelegateCommand(() => CreateReserve(ReserveType.Block));
            CreateEstimateReserveCommand = new DelegateCommand(() => CreateReserve(ReserveType.Estimate));
            ShowSelectedItemCommand = new DelegateCommand<object>(x => EditReserve(x));
        }

        public void EditReserve(object current)
        {
            DoTransitionPage(
                AppViewConst.ContentRegion_AppViewMainContent,
                    GetViewName(true),
                        AppViewConst.View_ReserveEdit,
                            (current as ReserveItemModel).Reserve);
        }

        public void CreateReserve(ReserveType reserveType)
        {
            GetDataResultModel<TReserve> resultModel =
                ApplicationLogic.CreateReserve(new CreateReserveInputModel()
                {
                    StartDateTime = DateTime.Now,
                    ReserveType = reserveType,
                });

            if (!resultModel.Result)
            {
                ShowMessage(MessageDialogStyle.ErrorMessage, resultModel.Messages[0]);
                return;
            }

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
                //WhereString = "AND TR.ReserveState <> 0",
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
