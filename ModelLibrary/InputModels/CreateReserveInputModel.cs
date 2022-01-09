using ModelLibrary.InputModel;
using ModelLibrary.Models.Database.Enumerate;
using System;

namespace ModelLibrary.InputModels
{
    public class CreateReserveInputModel : InputModelBase
    {
        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public ReserveState ReserveState { get; set; }
    }
}
