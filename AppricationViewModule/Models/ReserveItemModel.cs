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
                    ReserveType = ReserveType,
                    ReserveState = ReserveState,
                    ReserveStart = StartDate + StartTime,
                    ReserveEnd = EndDate + EndTime,
                    BlockStart = StartDate + StartTime - BlockStartTime,
                    BlockEnd = EndDate + EndTime + BlockEndTime,
                    ReserveMemo = ReserveMemo,
                    ReserveMemo1 = ReserveMemo1,
                    Optimist = Optimist,
                };
            }
            set
            {
                ReserveId = value.ReserveId;
                ReserveType = value.ReserveType;
                ReserveState = value.ReserveState;
                StartDate = value.ReserveStart.Date;
                EndDate = value.ReserveEnd.Date;
                StartTime = value.ReserveStart.TimeOfDay;
                EndTime = value.ReserveEnd.TimeOfDay;
                BlockStartTime = value.ReserveStart - value.BlockStart;
                BlockEndTime = value.BlockEnd - value.ReserveEnd;
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

        private ReserveState _reserveState;
        public ReserveState ReserveState
        {
            get => _reserveState;
            set => SetProperty(ref _reserveState, value);
        }

        private ReserveType _reserveType;
        public ReserveType ReserveType
        {
            get => _reserveType;
            set => SetProperty(ref _reserveType, value);
        }

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

        private TimeSpan _startTime;
        public TimeSpan StartTime
        {
            get => _startTime;
            set => SetProperty(ref _startTime, value);
        }

        private TimeSpan _endTime;
        public TimeSpan EndTime
        {
            get => _endTime;
            set => SetProperty(ref _endTime, value);
        }

        private TimeSpan _blockStartTime;
        public TimeSpan BlockStartTime
        {
            get => _blockStartTime;
            set => SetProperty(ref _blockStartTime, value);
        }

        private TimeSpan _blockEndTime;
        public TimeSpan BlockEndTime
        {
            get => _blockEndTime;
            set => SetProperty(ref _blockEndTime, value);
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
