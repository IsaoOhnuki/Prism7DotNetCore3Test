using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.CustomBaseControl
{
    /// <summary>
    /// TitleTextBaseContrl.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogTitleTextBaseControl : UserControl
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
                typeof(DialogTitleTextBaseControl),
                new PropertyMetadata(default(string)));

        public DialogTitleTextBaseControl()
        {
            InitializeComponent();
        }
    }
}
