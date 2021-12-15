using CustomControlLibrary.CustomBaseControl;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomControlLibrary.Button
{
    /// <summary>
    /// CommandButton.xaml の相互作用ロジック
    /// </summary>
    public partial class CommandButton : BaseButtonControl
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

        public CommandButton()
        {
            InitializeComponent();
        }
    }
}
