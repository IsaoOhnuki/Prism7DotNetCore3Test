using ModelLibrary.InputModel;
using System;

namespace ModelLibrary.InputModels
{
    public class CreateReserveInputModel : InputModelBase
    {
        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
