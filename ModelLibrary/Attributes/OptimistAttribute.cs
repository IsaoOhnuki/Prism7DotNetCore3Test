using System;

namespace ModelLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OptimistAttribute : Attribute
    {
        public bool DeleteWhere { get; set; }

        public OptimistAttribute(bool deleteWhere)
        {
            DeleteWhere = deleteWhere;
        }
    }
}
