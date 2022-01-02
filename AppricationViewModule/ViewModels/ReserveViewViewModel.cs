using AppricationViewModule.Models;
using ModelLibrary.InputModels;
using ModelLibrary.Models.Database;
using ModelLibrary.ResultModels;
using ModelLibrary.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AppricationViewModule.ViewModels
{
    public class ReserveViewViewModel : BindableBase
    {
        public IApplicationLogic ApplicationLogic { get; private set; }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        private TReserve _currentReserve;

        public TReserve CurrentReserve
        {
            get => _currentReserve;
            set => SetProperty(ref _currentReserve, value);
        }

        private ObservableCollection<TReserve> _reserves;

        public ObservableCollection<TReserve> Reserves
        {
            get => _reserves;
            set => SetProperty(ref _reserves, value);
        }

        public ReserveViewViewModel(IApplicationLogic applicationLogic)
        {
            ApplicationLogic = applicationLogic;
        }

        public void GetPeriodReserve(Period period)
        {
            GetPeriodReserveInputModel inputModel = new GetPeriodReserveInputModel
            {
                ReserveStart = period.Start,
                ReserveEnd = period.End,
            };
            GetDataListResultModel<TReserve> resultModel = ApplicationLogic.GetPeriodReserve(inputModel);
            Reserves = new ObservableCollection<TReserve>();
            Reserves.AddRange(resultModel.DataList);
        }
    }
}
