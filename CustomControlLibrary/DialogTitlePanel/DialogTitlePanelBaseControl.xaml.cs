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

namespace CustomControlLibrary.DialogTitlePanel
{
    /// <summary>
    /// DialogTitlePanelBaseControl.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogTitlePanelBaseControl : UserControl
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
                typeof(DialogTitlePanelBaseControl),
                new PropertyMetadata(
                    default(Brush),
                    (d, e) => {
                        if (d is DialogTitlePanelBaseControl obj)
                        {
                            if (obj.dialogTitlePanel.Content != e.NewValue)
                            {
                                obj.dialogTitlePanel.Content = e.NewValue;
                            }
                        }
                    }));

        public new object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public static new readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(
                nameof(Content),
                typeof(object),
                typeof(DialogTitlePanelBaseControl),
                new PropertyMetadata(
                    default(object),
                    (d, e) =>
                    {
                        if (d is DialogTitlePanelBaseControl obj)
                        {
                            if (obj.dialogTitlePanelLabel.Content != e.NewValue)
                            {
                                obj.dialogTitlePanelLabel.Content = e.NewValue;
                            }
                        }
                    }));

        public DialogTitlePanelBaseControl()
        {
            InitializeComponent();
        }
    }
}
