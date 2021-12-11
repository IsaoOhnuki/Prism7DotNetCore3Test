using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.CustomBaseControl
{
    /// <summary>
    /// LabelBaseControl.xaml の相互作用ロジック
    /// </summary>
    public partial class LabelBaseControl : UserControl
    {
        public new object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public static readonly new DependencyProperty ContentProperty =
            DependencyProperty.Register(
                nameof(Content),
                typeof(object),
                typeof(LabelBaseControl),
                new PropertyMetadata(default(object)));

        public LabelBaseControl()
        {
            InitializeComponent();
        }
    }
}
