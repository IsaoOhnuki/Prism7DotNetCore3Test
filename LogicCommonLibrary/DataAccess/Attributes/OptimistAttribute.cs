using System;

namespace LogicCommonLibrary.DataAccess.Attributes
{
    public class OptimistAttribute : Attribute
    {
        public bool DeleteWhere { get; set; }

        public OptimistAttribute(bool deleteWhere)
        {
            DeleteWhere = deleteWhere;
        }
    }
}
