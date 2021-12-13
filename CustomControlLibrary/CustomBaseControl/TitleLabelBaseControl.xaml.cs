using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.CustomBaseControl
{
    /// <summary>
    /// TitleLabelBaseControl.xaml の相互作用ロジック
    /// </summary>
    public partial class TitleLabelBaseControl : UserControl
    {
        public new object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public static new readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(
                nameof(Content),
                typeof(object),
                typeof(TitleLabelBaseControl),
                new PropertyMetadata(
                    default,
                    (d, e) =>
                    {
                        if (d is TitleLabelBaseControl obj)
                        {
                            if (obj.dialogTitleText.Content != e.NewValue)
                            {
                                obj.dialogTitleText.Content = e.NewValue;
                            }
                        }
                    }));

        public TitleLabelBaseControl()
        {
            InitializeComponent();
        }
    }
}
