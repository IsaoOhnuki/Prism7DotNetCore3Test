using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.InputModels
{
    public class GetDataInputModel<TTable> : DataAccessInputModel
    {
        public TTable TableClass { get; set; }
    }
}
