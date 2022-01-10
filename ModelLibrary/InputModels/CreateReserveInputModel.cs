using ModelLibrary.InputModel;
using ModelLibrary.Models.Database.Enumerate;
using System;

namespace ModelLibrary.InputModels
{
    public class CreateReserveInputModel : InputModelBase
    {
        public DateTime StartDateTime { get; set; }

        public ReserveType ReserveType { get; set; }
    }
}
