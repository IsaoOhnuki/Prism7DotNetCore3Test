using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomControlLibrary.Button
{
    /// <summary>
    /// CommandButton.xaml の相互作用ロジック
    /// </summary>
    public partial class CommandButton : UserControl
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
                typeof(CommandButton),
                new FrameworkPropertyMetadata(defaultValue: "BaseImageLabelControl"));

        public ImageSource ImageSource
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        internal static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register(
                nameof(ImageSource),
                typeof(ImageSource),
                typeof(CommandButton),
                new FrameworkPropertyMetadata(default(ImageSource)));

        public CommandStatus CommandStatus
        {
            get => (CommandStatus)GetValue(CommandStatusProperty);
            set => SetValue(CommandStatusProperty, value);
        }

        internal static readonly DependencyProperty CommandStatusProperty =
            DependencyProperty.Register(
                nameof(CommandStatus),
                typeof(CommandStatus),
                typeof(CommandButton),
                new FrameworkPropertyMetadata(default(CommandStatus)));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                nameof(Command),
                typeof(ICommand),
                typeof(CommandButton),
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
                typeof(CommandButton),
                new FrameworkPropertyMetadata(default));

        public CommandButton()
        {
            InitializeComponent();
        }
    }
}
