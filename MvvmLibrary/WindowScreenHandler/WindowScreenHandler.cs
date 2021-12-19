using ModelLibrary.Services;
using System.Windows;

namespace MvvmServiceLibrary.WindowScreenHandler
{
    public class WindowScreenHandler : IWindowScreenHandler
    {
        public static Window Window { get; set; }

        public static readonly DependencyProperty AttacheProperty =
            DependencyProperty.RegisterAttached(
                "Attache",
                typeof(bool),
                typeof(WindowScreenHandler),
                new PropertyMetadata(
                    default(bool),
                    (d, e) =>
                    {
                        if (d is Window window)
                        {
                            bool attache = (bool)e.NewValue;
                            if (attache)
                            {
                                Window = window;
                            }
                            else
                            {
                                Window = null;
                            }
                        }
                    }));

        public static void SetAttache(DependencyObject obj, bool value)
        {
            obj.SetValue(AttacheProperty, value);
        }

        public static bool GetAttache(DependencyObject obj)
        {
            return (bool)obj.GetValue(AttacheProperty);
        }
    }
}
