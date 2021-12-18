using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace MvvmServiceLibrary.Converter
{
    public class WidthAndHeightToRectConverter : MarkupExtension, IMultiValueConverter
    {
        private WidthAndHeightToRectConverter _converter;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ??= new WidthAndHeightToRectConverter();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double width = (double)values[0];
            double height = (double)values[1];
            return new Rect(0, 0, width, height);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            Rect rect = (Rect)value;
            return new object[] { rect.Width, rect.Height };
        }
    }
}
