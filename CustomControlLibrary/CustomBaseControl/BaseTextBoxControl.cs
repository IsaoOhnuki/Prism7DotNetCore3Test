using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.CustomBaseControl
{
    public class BaseTextBoxControl : BaseCustomControl
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
                typeof(BaseTextBoxControl),
                new FrameworkPropertyMetadata(defaultValue: "BaseTextBoxControl"));

        public Thickness TextMargin
        {
            get => (Thickness)GetValue(TextMarginProperty);
            set => SetValue(TextMarginProperty, value);
        }

        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register(
                nameof(TextMargin),
                typeof(Thickness),
                typeof(BaseTextBoxControl),
                new FrameworkPropertyMetadata(default(Thickness)));

        public bool AcceptsReturn
        {
            get => (bool)GetValue(AcceptsReturnProperty);
            set => SetValue(AcceptsReturnProperty, value);
        }

        public static readonly DependencyProperty AcceptsReturnProperty =
            DependencyProperty.Register(
                nameof(AcceptsReturn),
                typeof(bool),
                typeof(BaseTextBoxControl),
                new FrameworkPropertyMetadata(default(bool)));

        public ScrollBarVisibility HorizontalScrollBarVisibility
        {
            get => (ScrollBarVisibility)GetValue(HorizontalScrollBarVisibilityProperty);
            set => SetValue(HorizontalScrollBarVisibilityProperty, value);
        }

        public static readonly DependencyProperty HorizontalScrollBarVisibilityProperty =
            DependencyProperty.Register(
                nameof(HorizontalScrollBarVisibility),
                typeof(ScrollBarVisibility),
                typeof(BaseTextBoxControl),
                new FrameworkPropertyMetadata(default(ScrollBarVisibility)));

        public ScrollBarVisibility VerticalScrollBarVisibility
        {
            get => (ScrollBarVisibility)GetValue(VerticalScrollBarVisibilityProperty);
            set => SetValue(VerticalScrollBarVisibilityProperty, value);
        }

        public static readonly DependencyProperty VerticalScrollBarVisibilityProperty =
            DependencyProperty.Register(
                nameof(VerticalScrollBarVisibility),
                typeof(ScrollBarVisibility),
                typeof(BaseTextBoxControl),
                new FrameworkPropertyMetadata(default(ScrollBarVisibility)));

        static BaseTextBoxControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseTextBoxControl), new FrameworkPropertyMetadata(typeof(BaseTextBoxControl)));
        }
    }
}
