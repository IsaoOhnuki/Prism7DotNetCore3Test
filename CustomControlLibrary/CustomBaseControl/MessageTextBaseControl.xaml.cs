using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.CustomBaseControl
{
    /// <summary>
    /// MessageTextBaseControl.xaml の相互作用ロジック
    /// </summary>
    public partial class MessageTextBaseControl : UserControl
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
                typeof(MessageTextBaseControl),
                new PropertyMetadata(
                    default(string),
                    (d, e) =>
                    {
                        if (d is MessageTextBaseControl obj)
                        {
                            if (obj.messageText.Text != (string)e.NewValue)
                            {
                                obj.messageText.Text = (string)e.NewValue;
                            }
                        }
                    }));

        public MessageTextBaseControl()
        {
            InitializeComponent();
        }
    }
}
