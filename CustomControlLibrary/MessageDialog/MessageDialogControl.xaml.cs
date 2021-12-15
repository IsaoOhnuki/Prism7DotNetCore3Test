using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLibrary.MessageDialog
{
    /// <summary>
    /// MessageDialogControl.xaml の相互作用ロジック
    /// </summary>
    public partial class MessageDialogControl : UserControl
    {
        public object Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                nameof(Title),
                typeof(object),
                typeof(MessageDialogControl),
                new PropertyMetadata(default));

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(
                nameof(Message),
                typeof(string),
                typeof(MessageDialogControl),
                new PropertyMetadata(default(string)));

        public string LeftButtonText
        {
            get => (string)GetValue(LeftButtonTextProperty);
            set => SetValue(LeftButtonTextProperty, value);
        }

        public static readonly DependencyProperty LeftButtonTextProperty =
            DependencyProperty.Register(
                nameof(LeftButtonText),
                typeof(object),
                typeof(MessageDialogControl),
                new PropertyMetadata(default));

        public string RightButtonText
        {
            get => (string)GetValue(RightButtonTextProperty);
            set => SetValue(RightButtonTextProperty, value);
        }

        public static readonly DependencyProperty RightButtonTextProperty =
            DependencyProperty.Register(
                nameof(RightButtonText),
                typeof(object),
                typeof(MessageDialogControl),
                new PropertyMetadata(default));

        public ICommand LeftButtonCommand
        {
            get => (ICommand)GetValue(LeftButtonCommandProperty);
            set => SetValue(LeftButtonCommandProperty, value);
        }

        public static readonly DependencyProperty LeftButtonCommandProperty =
            DependencyProperty.Register(
                nameof(LeftButtonCommand),
                typeof(ICommand),
                typeof(MessageDialogControl),
                new PropertyMetadata(default(ICommand)));

        public ICommand RightButtonCommand
        {
            get => (ICommand)GetValue(RightButtonCommandProperty);
            set => SetValue(RightButtonCommandProperty, value);
        }

        public static readonly DependencyProperty RightButtonCommandProperty =
            DependencyProperty.Register(
                nameof(RightButtonCommand),
                typeof(ICommand),
                typeof(MessageDialogControl),
                new PropertyMetadata(default(ICommand)));

        public MessageDialogControl()
        {
            InitializeComponent();
        }
    }
}
