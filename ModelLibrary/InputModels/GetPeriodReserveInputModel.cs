using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.InputModels
{
    public class GetPeriodReserveInputModel : DataAccessInputModel
    {
        public DateTime ReserveStart { get; set; }

        public DateTime ReserveEnd { get; set; }
    }
}
