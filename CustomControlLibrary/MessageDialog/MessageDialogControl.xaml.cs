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
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                nameof(Title),
                typeof(string),
                typeof(MessageDialogControl),
                new PropertyMetadata(
                    default(string),
                    (d, e) => {
                        if (d is MessageDialogControl obj)
                        {
                            if (obj.title.Content != e.NewValue)
                            {
                                obj.title.Content = e.NewValue;
                            }
                        }
                    }));

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
                new PropertyMetadata(
                    default(string),
                    (d, e) => {
                        if (d is MessageDialogControl obj)
                        {
                            if (obj.message.Content != e.NewValue)
                            {
                                obj.message.Content = e.NewValue;
                            }
                        }
                    }));

        public string LeftButtonText
        {
            get => (string)GetValue(LeftButtonTextProperty);
            set => SetValue(LeftButtonTextProperty, value);
        }

        public static readonly DependencyProperty LeftButtonTextProperty =
            DependencyProperty.Register(
                nameof(LeftButtonText),
                typeof(string),
                typeof(MessageDialogControl),
                new PropertyMetadata(
                    default(string),
                    (d, e) => {
                        if (d is MessageDialogControl obj)
                        {
                            if (obj.leftButton.Content != e.NewValue)
                            {
                                obj.leftButton.Content = e.NewValue;
                            }
                        }
                    }));

        public string RightButtonText
        {
            get => (string)GetValue(RightButtonTextProperty);
            set => SetValue(RightButtonTextProperty, value);
        }

        public static readonly DependencyProperty RightButtonTextProperty =
            DependencyProperty.Register(
                nameof(RightButtonText),
                typeof(string),
                typeof(MessageDialogControl),
                new PropertyMetadata(
                    default(string),
                    (d, e) => {
                        if (d is MessageDialogControl obj)
                        {
                            if (obj.rightButton.Content != e.NewValue)
                            {
                                obj.rightButton.Content = e.NewValue;
                            }
                        }
                    }));

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
                new PropertyMetadata(
                    default(ICommand),
                    (d, e) => {
                        if (d is MessageDialogControl obj)
                        {
                            if (obj.leftButton.Command != (ICommand)e.NewValue)
                            {
                                obj.leftButton.Command = (ICommand)e.NewValue;
                            }
                        }
                    }));

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
                new PropertyMetadata(
                    default(string),
                    (d, e) => {
                        if (d is MessageDialogControl obj)
                        {
                            if (obj.rightButton.Command != (ICommand)e.NewValue)
                            {
                                obj.rightButton.Command = (ICommand)e.NewValue;
                            }
                        }
                    }));

        public MessageDialogControl()
        {
            InitializeComponent();
        }
    }
}
