using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.Models
{
    public interface IDataAccess
    {
        public string GetLastQuery();

        public string GetLastQueryParam();
    }
}
