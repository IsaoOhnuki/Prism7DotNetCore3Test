using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace ModelLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LessThanAttribute : ValidationAttribute
    {
        public string OtherProperty { get; private set; }
        public string OtherPropertyDisplayName { get; internal set; }

        public LessThanAttribute(string otherProperty)
        {
            OtherProperty = otherProperty;
            ErrorMessage = "{0}は{1}より小さい値を指定してください。";
        }

        public override string FormatErrorMessage(string name)
        {
            // エラーメッセージを返す
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, OtherPropertyDisplayName ?? OtherProperty);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // 比較対象のPropertyInfo
            PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            // 比較対象のプロパティの値
            object propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
            Type type = propertyInfo.PropertyType;

            if (type == typeof(DateTime))
            {
                // ここで値の比較。条件を満たしていれば検証成功を返す
                if ((DateTime)value < (DateTime)propertyValue)
                {
                    return ValidationResult.Success;
                }
            }
            else if (type == typeof(int))
            {
                if ((int)value < (int)propertyValue)
                {
                    return ValidationResult.Success;
                }
            }
            // ...other type

            if (OtherPropertyDisplayName == null)
            {
                OtherPropertyDisplayName = GetDisplayNameForProperty(validationContext.ObjectType, OtherProperty);
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        // 比較対象のプロパティ名を取得する。ここはオマケなので削っても問題ない
        private static string GetDisplayNameForProperty(Type containerType, string propertyName)
        {
            ICustomTypeDescriptor typeDescriptor = GetTypeDescriptor(containerType);
            PropertyDescriptor property = typeDescriptor.GetProperties().Find(propertyName, true);

            if (property == null)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.CurrentCulture, "not found property '{0}'", propertyName));
            }

            IEnumerable<Attribute> attributes = property.Attributes.Cast<Attribute>();
            DisplayAttribute display = attributes.OfType<DisplayAttribute>().FirstOrDefault();

            if (display != null)
            {
                // DisplayAttributeがついてたらその名称を返す
                return display.GetName();
            }

            DisplayNameAttribute displayName = attributes.OfType<DisplayNameAttribute>().FirstOrDefault();

            if (displayName != null)
            {
                // DisplayNameAttributeがついてたらその名称を返す
                return displayName.DisplayName;
            }

            return propertyName;
        }

        private static ICustomTypeDescriptor GetTypeDescriptor(Type type)
        {
            return new AssociatedMetadataTypeTypeDescriptionProvider(type).GetTypeDescriptor(type);
        }
    }
}
