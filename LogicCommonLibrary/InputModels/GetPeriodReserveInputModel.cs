using System;

namespace LogicCommonLibrary.InputModels
{
    public class GetPeriodReserveInputModel : DataAccessInputModel
    {
        public DateTime ReserveStart { get; set; }

        public DateTime ReserveEnd { get; set; }
    }
}
