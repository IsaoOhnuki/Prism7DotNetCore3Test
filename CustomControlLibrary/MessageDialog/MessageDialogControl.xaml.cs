using MvvmServiceLibrary;
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
        public DialogNotifyStyle DialogNotifyStyle
        {
            get => (DialogNotifyStyle)GetValue(DialogNotifyStyleProperty);
            set => SetValue(DialogNotifyStyleProperty, value);
        }

        public static readonly DependencyProperty DialogNotifyStyleProperty =
            DependencyProperty.Register(
                nameof(DialogNotifyStyle),
                typeof(DialogNotifyStyle),
                typeof(MessageDialogControl),
                new PropertyMetadata(default(DialogNotifyStyle)));

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

        public string CenterButtonText
        {
            get => (string)GetValue(CenterButtonTextProperty);
            set => SetValue(CenterButtonTextProperty, value);
        }

        public static readonly DependencyProperty CenterButtonTextProperty =
            DependencyProperty.Register(
                nameof(CenterButtonText),
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

        public ICommand CenterButtonCommand
        {
            get => (ICommand)GetValue(CenterButtonCommandProperty);
            set => SetValue(CenterButtonCommandProperty, value);
        }

        public static readonly DependencyProperty CenterButtonCommandProperty =
            DependencyProperty.Register(
                nameof(CenterButtonCommand),
                typeof(ICommand),
                typeof(MessageDialogControl),
                new PropertyMetadata(default(ICommand)));

        public bool ConfirmStyleButton
        {
            get => (bool)GetValue(ConfirmStyleButtonProperty);
            set => SetValue(ConfirmStyleButtonProperty, value);
        }

        public static readonly DependencyProperty ConfirmStyleButtonProperty =
            DependencyProperty.Register(
                nameof(ConfirmStyleButton),
                typeof(bool),
                typeof(MessageDialogControl),
                new PropertyMetadata(false));

        public MessageDialogControl()
        {
            InitializeComponent();
        }
    }
}
