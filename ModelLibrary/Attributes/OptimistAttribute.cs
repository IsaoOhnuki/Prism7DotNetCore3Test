using System;

namespace ModelLibrary.Attributes
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
