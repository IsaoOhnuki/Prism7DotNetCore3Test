using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.CustomBaseControl
{
    public class BaseContentControl : ContentControl
    {
        public new object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public new static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(
                nameof(Content),
                typeof(object),
                typeof(BaseContentControl),
                new FrameworkPropertyMetadata(default));

        static BaseContentControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseContentControl), new FrameworkPropertyMetadata(typeof(BaseContentControl)));
        }
    }
}
