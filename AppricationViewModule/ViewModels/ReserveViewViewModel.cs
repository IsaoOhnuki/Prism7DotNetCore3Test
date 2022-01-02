using ModelLibrary.Models.Database;
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
    }
}
