using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomControlLibrary.CustomBaseControl
{
    /// <summary>
    /// ShadePanelBaseControl.xaml の相互作用ロジック
    /// </summary>
    public partial class ShadePanelBaseControl : UserControl
    {
        public new Brush Background
        {
            get => (Brush)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        public static new readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register(
                nameof(Background),
                typeof(Brush),
                typeof(ShadePanelBaseControl),
                new PropertyMetadata(
                    new SolidColorBrush(Color.FromArgb(0x7f, 0, 0, 0)),
                    (d, e) =>
                    {
                        if (d is ShadePanelBaseControl obj)
                        {
                            if (obj.shadePanel.Background != (Brush)e.NewValue)
                            {
                                obj.shadePanel.Background = (Brush)e.NewValue;
                            }
                        }
                    }));

        public ShadePanelBaseControl()
        {
            InitializeComponent();
        }
    }
}
