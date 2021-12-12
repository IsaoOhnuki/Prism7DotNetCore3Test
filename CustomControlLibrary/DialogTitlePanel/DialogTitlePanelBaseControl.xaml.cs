using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomControlLibrary.DialogTitlePanel
{
    /// <summary>
    /// MessageDialogControl.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogTitlePanelControl : UserControl
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
                typeof(DialogTitlePanelControl),
                new PropertyMetadata(
                    default(Brush),
                    (d, e) => {
                        if (d is DialogTitlePanelControl obj)
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
                typeof(DialogTitlePanelControl),
                new PropertyMetadata(
                    default(object),
                    (d, e) =>
                    {
                        if (d is DialogTitlePanelControl obj)
                        {
                            if (obj.dialogTitlePanelLabel.Content != e.NewValue)
                            {
                                obj.dialogTitlePanelLabel.Content = e.NewValue;
                            }
                        }
                    }));

        public DialogTitlePanelControl()
        {
            InitializeComponent();
        }
    }
}
