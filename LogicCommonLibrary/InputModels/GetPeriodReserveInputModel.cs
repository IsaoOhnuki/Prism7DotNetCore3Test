using ModelLibrary.Services;
using System;

namespace LogicCommonLibrary.InputModels
{
    public class GetPeriodReserveInputModel : DataAccessInputModel
    {
        public GetPeriodReserveInputModel(IDatabaseConnection databaseConnection)
            : base(databaseConnection)
        {
        }

        public DateTime ReserveStart { get; set; }

        public DateTime ReserveEnd { get; set; }

        public string WhereString { get; set; }
    }
}
