using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CustomControlLibrary.Converter
{
    public class HorizontalToTextAlignmentConverter : MarkupExtension, IValueConverter
    {
        private static HorizontalToTextAlignmentConverter _converter;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ??= new HorizontalToTextAlignmentConverter();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((HorizontalAlignment)value)
            {
                case HorizontalAlignment.Left:
                    return TextAlignment.Left;
                case HorizontalAlignment.Right:
                    return TextAlignment.Right;
                case HorizontalAlignment.Center:
                    return TextAlignment.Center;
                case HorizontalAlignment.Stretch:
                    return TextAlignment.Justify;
                default:
                    throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((TextAlignment)value)
            {
                case TextAlignment.Left:
                    return HorizontalAlignment.Left;
                case TextAlignment.Right:
                    return HorizontalAlignment.Right;
                case TextAlignment.Center:
                    return HorizontalAlignment.Center;
                case TextAlignment.Justify:
                    return HorizontalAlignment.Stretch;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
