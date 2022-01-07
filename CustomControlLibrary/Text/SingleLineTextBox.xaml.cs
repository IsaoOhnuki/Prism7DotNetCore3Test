using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.Text
{
    /// <summary>
    /// SingleLineTextBox.xaml の相互作用ロジック
    /// </summary>
    public partial class SingleLineTextBox : UserControl
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
                typeof(SingleLineTextBox),
                new FrameworkPropertyMetadata(defaultValue: "SingleLineTextBox"));

        public SingleLineTextBox()
        {
            InitializeComponent();
        }
    }
}
