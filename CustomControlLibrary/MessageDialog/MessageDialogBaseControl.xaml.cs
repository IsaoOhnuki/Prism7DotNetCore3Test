using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.MessageDialog
{
    /// <summary>
    /// MessageDialogBaseControl.xaml の相互作用ロジック
    /// </summary>
    public partial class MessageDialogBaseControl : UserControl
    {
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                nameof(Title),
                typeof(string),
                typeof(MessageDialogBaseControl),
                new PropertyMetadata(default(string)));

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(
                nameof(Message),
                typeof(string),
                typeof(MessageDialogBaseControl),
                new PropertyMetadata(default(string)));

        public string LeftButtonText
        {
            get => (string)GetValue(LeftButtonTextProperty);
            set => SetValue(LeftButtonTextProperty, value);
        }

        public static readonly DependencyProperty LeftButtonTextProperty =
            DependencyProperty.Register(
                nameof(LeftButtonText),
                typeof(string),
                typeof(MessageDialogBaseControl),
                new PropertyMetadata(default(string)));

        public string RightButtonText
        {
            get => (string)GetValue(RightButtonTextProperty);
            set => SetValue(RightButtonTextProperty, value);
        }

        public static readonly DependencyProperty RightButtonTextProperty =
            DependencyProperty.Register(
                nameof(RightButtonText),
                typeof(string),
                typeof(MessageDialogBaseControl),
                new PropertyMetadata(default(string)));

        public MessageDialogBaseControl()
        {
            InitializeComponent();
        }
    }
}
