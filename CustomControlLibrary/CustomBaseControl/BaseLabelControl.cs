using System.Windows;

namespace CustomControlLibrary.CustomBaseControl
{
    public class BaseLabelControl : BaseCustomControl
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
                typeof(BaseLabelControl),
                new FrameworkPropertyMetadata(defaultValue: "BaseLabelControl"));

        public Thickness TextMargin
        {
            get => (Thickness)GetValue(TextMarginProperty);
            set => SetValue(TextMarginProperty, value);
        }

        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register(
                nameof(TextMargin),
                typeof(Thickness),
                typeof(BaseLabelControl),
                new FrameworkPropertyMetadata(default(Thickness)));

        static BaseLabelControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseLabelControl), new FrameworkPropertyMetadata(typeof(BaseLabelControl)));
        }
    }
}
