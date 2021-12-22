using System;
using System.Collections.Generic;
using System.Windows;

namespace BlankCoreApp1.Behavior
{
    public static class ViewElementRegister
    {
        public static event Action<FrameworkElement> OnRegistElement;

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
                            ContentElements.Add(e.NewValue.ToString(), element);
                            OnRegistElement?.Invoke(element);
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
