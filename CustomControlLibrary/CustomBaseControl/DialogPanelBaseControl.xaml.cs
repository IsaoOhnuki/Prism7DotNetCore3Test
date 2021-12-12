using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControlLibrary.CustomBaseControl
{
    /// <summary>
    /// DialogPanelBaseControl.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogPanelBaseControl : UserControl
    {
        public new Brush Background
        {
            get => (Brush)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        public static readonly new DependencyProperty BackgroundProperty =
            DependencyProperty.Register(
                nameof(Background),
                typeof(Brush),
                typeof(DialogPanelBaseControl),
                new PropertyMetadata(
                    Brushes.White,
                    (d, e) => {
                        if (d is DialogPanelBaseControl obj)
                        {
                            if (obj.dialogPanel.Background != (Brush)e.NewValue)
                            {
                                obj.dialogPanel.Background = (Brush)e.NewValue;
                            }
                        }
                    }));

public DialogPanelBaseControl()
        {
            InitializeComponent();
        }
    }
}
