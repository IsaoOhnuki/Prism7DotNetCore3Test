using System;

namespace ModelLibrary.Attributes
{
    public class InsertQueryParameterAttribute : Attribute
    {
        public string Parameter { get; set; }

        public InsertQueryParameterAttribute(string parameter)
        {
            Parameter = parameter;
        }
    }
}
