using System;

namespace LogicCommonLibrary.DataAccess.Attributes
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
