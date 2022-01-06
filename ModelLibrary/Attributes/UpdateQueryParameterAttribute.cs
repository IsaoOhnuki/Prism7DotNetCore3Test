using System;

namespace ModelLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UpdateQueryParameterAttribute : Attribute
    {
        public string Parameter { get; set; }

        public UpdateQueryParameterAttribute(string parameter)
        {
            Parameter = parameter;
        }
    }
}
