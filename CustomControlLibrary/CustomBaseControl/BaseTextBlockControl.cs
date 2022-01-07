using System.Windows;

namespace CustomControlLibrary.CustomBaseControl
{
    public class BaseTextBlockControl : BaseCustomControl
    {
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                nameof(Text),
                typeof(string),
                typeof(BaseTextBlockControl),
                new FrameworkPropertyMetadata(defaultValue: "BaseTextBlockControl"));

        public Thickness TextMargin
        {
            get => (Thickness)GetValue(TextMarginProperty);
            set => SetValue(TextMarginProperty, value);
        }

        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register(
                nameof(TextMargin),
                typeof(Thickness),
                typeof(BaseTextBlockControl),
                new FrameworkPropertyMetadata(default(Thickness)));

        static BaseTextBlockControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseTextBlockControl), new FrameworkPropertyMetadata(typeof(BaseTextBlockControl)));
        }
    }
}
