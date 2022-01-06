using System;

namespace ModelLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class InsertQueryParameterAttribute : Attribute
    {
        public string Parameter { get; set; }

        public InsertQueryParameterAttribute(string parameter)
        {
            Parameter = parameter;
        }
    }
}
