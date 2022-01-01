using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.Models.Database.Enumerate
{
    public enum ReserveState
    {
        Delete,
        Reserve,
        Block,
        Estimate,
        Success,
        Failure,
    }
}
