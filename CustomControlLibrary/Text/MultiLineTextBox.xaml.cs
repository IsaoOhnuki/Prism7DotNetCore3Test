using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.Text
{
    /// <summary>
    /// MultiLineTextBox.xaml の相互作用ロジック
    /// </summary>
    public partial class MultiLineTextBox : UserControl
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
                typeof(MultiLineTextBox),
                new FrameworkPropertyMetadata(defaultValue: "MultiLineTextBox"));

        public MultiLineTextBox()
        {
            InitializeComponent();
        }
    }
}
