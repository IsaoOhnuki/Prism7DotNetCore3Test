using System;
using System.Collections.Generic;
using System.Windows;

namespace MvvmCommonLibrary.Behavior
{
    public static class ViewElementRegister
    {
        public static event Action<string, FrameworkElement> OnRegistElement;

        public static Dictionary<string, FrameworkElement> ContentElements { get; } = new Dictionary<string, FrameworkElement>();

        public static readonly DependencyProperty ElementProperty =
            DependencyProperty.RegisterAttached(
                "Element",
                typeof(string),
                typeof(ViewElementRegister),
                new PropertyMetadata(
                    default(string),
                    (d, e) =>
                    {
                        if (d is FrameworkElement element)
                        {
                            string elementName = e.NewValue.ToString();
                            ContentElements.Add(elementName, element);
                            OnRegistElement?.Invoke(elementName, element);
                        }
                    }));

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
