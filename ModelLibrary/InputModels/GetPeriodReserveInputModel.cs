using ModelLibrary.InputModel;
using System;

namespace ModelLibrary.InputModels
{
    public class GetPeriodReserveInputModel : InputModelBase
    {
        public DateTime ReserveStart { get; set; }

        public DateTime ReserveEnd { get; set; }

        public string WhereString { get; set; }
    }
}
