using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLibrary.CustomBaseControl
{
    public class BaseButtonControl : BaseContentControl
    {
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                nameof(Command),
                typeof(ICommand),
                typeof(BaseButtonControl),
                new FrameworkPropertyMetadata(default(ICommand)));

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(
                nameof(CommandParameter),
                typeof(object),
                typeof(BaseButtonControl),
                new FrameworkPropertyMetadata(default));

        static BaseButtonControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseButtonControl), new FrameworkPropertyMetadata(typeof(BaseButtonControl)));
        }
    }
}
