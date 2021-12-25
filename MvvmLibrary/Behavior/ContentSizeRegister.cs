using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using MvvmCommonLibrary.Model;

namespace MvvmCommonLibrary.Behavior
{
    public class ContentSizeRegister
    {
        public static Dictionary<string, Size> RegistElementSize { get; } = new Dictionary<string, Size>();

        public static Dictionary<FrameworkElement, string> RegistElement { get; } = new Dictionary<FrameworkElement, string>();

        public static event Action<string, Size> OnSizeChanged;

        public static readonly DependencyProperty ElementProperty =
            DependencyProperty.RegisterAttached(
                "Element",
                typeof(string),
                typeof(ContentSizeRegister),
                new PropertyMetadata(
                    default(string),
                    (d, e) =>
                    {
                        if (d is FrameworkElement element)
                        {
                            element.SizeChanged += Element_SizeChanged;
                            string key = e.NewValue.ToString();
                            RegistElement.Add(element, key);
                            RegistElementSize.Add(key, new Size(element.ActualWidth, element.ActualHeight));
                        }
                    }));

        private static void Element_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (sender is FrameworkElement element)
            {
                string key = RegistElement[element];
                Size size = new Size(element.ActualWidth, element.ActualHeight);
                RegistElementSize[key] = size;
                OnSizeChanged?.Invoke(key, size);
            }
        }

        public static void SetElement(DependencyObject obj, string value)
        {
            obj.SetValue(ElementProperty, value);
        }

        public static string GetElement(DependencyObject obj)
        {
            return (string)obj.GetValue(ElementProperty);
        }
    }
}
