using ModelLibrary.Models.Database;
using ModelLibrary.Models.Database.Enumerate;
using MvvmCommonLibrary.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppricationViewModule.Models
{
    public class ReserveItemModel : ModelBase
    {
        public TReserve Reserve
        {
            get
            {
                return new TReserve
                {
                    ReserveId = ReserveId,
                    State = State,
                    ReserveStart = ReserveStart,
                    ReserveEnd = ReserveEnd,
                    BlockStart = ReserveStart + BlockStart,
                    BlockEnd = ReserveEnd + BlockEnd,
                    ReserveMemo = ReserveMemo,
                    ReserveMemo1 = ReserveMemo1,
                    Optimist = Optimist,
                };
            }
            set
            {
                ReserveId = value.ReserveId;
                State = value.State;
                ReserveStart = value.ReserveStart;
                ReserveEnd = value.ReserveEnd;
                BlockStart = value.BlockStart - value.ReserveStart;
                BlockEnd = value.BlockEnd - value.ReserveEnd;
                ReserveMemo = value.ReserveMemo;
                ReserveMemo1 = value.ReserveMemo1;
                Optimist = value.Optimist;
            }
        }

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

        private DateTime _reserveStart;
        public DateTime ReserveStart
        {
            get => _reserveStart;
            set => SetProperty(ref _reserveStart, value);
        }

        private DateTime _reserveEnd;
        public DateTime ReserveEnd
        {
            get => _reserveEnd;
            set => SetProperty(ref _reserveEnd, value);
        }

        private TimeSpan _blockStart;
        public TimeSpan BlockStart
        {
            get => _blockStart;
            set => SetProperty(ref _blockStart, value);
        }

        private TimeSpan _blockEnd;
        public TimeSpan BlockEnd
        {
            get => _blockEnd;
            set => SetProperty(ref _blockEnd, value);
        }

        private string _reserveMemo;
        public string ReserveMemo
        {
            get => _reserveMemo;
            set => SetProperty(ref _reserveMemo, value);
        }

        private string _reserveMemo1;
        public string ReserveMemo1
        {
            get => _reserveMemo1;
            set => SetProperty(ref _reserveMemo1, value);
        }

        private DateTime _optimist;
        public DateTime Optimist
        {
            get => _optimist;
            set => SetProperty(ref _optimist, value);
        }
    }
}
