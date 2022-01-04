using CustomControlLibrary.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLibrary.TitleBar
{
    /// <summary>
    /// WindowTitleBar.xaml の相互作用ロジック
    /// </summary>
    public partial class WindowTitleBar : UserControl
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
                typeof(WindowTitleBar),
                new FrameworkPropertyMetadata(defaultValue: "WindowTitleBar"));

        public ICommand IconCommand
        {
            get => (ICommand)GetValue(IconCommandProperty);
            set => SetValue(IconCommandProperty, value);
        }

        public static readonly DependencyProperty IconCommandProperty =
            DependencyProperty.Register(
                nameof(IconCommand),
                typeof(ICommand),
                typeof(WindowTitleBar),
                new FrameworkPropertyMetadata(default(ICommand)));

        public ICommand MaxCommand
        {
            get => (ICommand)GetValue(MaxCommandProperty);
            set => SetValue(MaxCommandProperty, value);
        }

        public static readonly DependencyProperty MaxCommandProperty =
            DependencyProperty.Register(
                nameof(MaxCommand),
                typeof(ICommand),
                typeof(WindowTitleBar),
                new FrameworkPropertyMetadata(default(ICommand)));

        public ICommand CloseCommand
        {
            get => (ICommand)GetValue(CloseCommandProperty);
            set => SetValue(CloseCommandProperty, value);
        }

        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register(
                nameof(CloseCommand),
                typeof(ICommand),
                typeof(WindowTitleBar),
                new FrameworkPropertyMetadata(default(ICommand)));

        public Window Window
        {
            get => (Window)GetValue(WindowProperty);
            set => SetValue(WindowProperty, value);
        }

        public static readonly DependencyProperty WindowProperty =
            DependencyProperty.Register(
                nameof(Window),
                typeof(Window),
                typeof(WindowTitleBar),
                new FrameworkPropertyMetadata(
                    default(Window),
                    (d, e) =>
                    {
                        if (d is WindowTitleBar obj)
                        {
                            (obj.CloseCommand as DefaultCommand)?.FireCanExecuteChanged(obj, EventArgs.Empty);
                            (obj.IconCommand as DefaultCommand)?.FireCanExecuteChanged(obj, EventArgs.Empty);
                            (obj.MaxCommand as DefaultCommand)?.FireCanExecuteChanged(obj, EventArgs.Empty);
                        }
                    }));

        public WindowTitleBar()
        {
            InitializeComponent();

            CloseCommand = new DefaultCommand(() => Window.Close(), () => Window != null);
            IconCommand = new DefaultCommand(() => Window.WindowState = WindowState.Minimized, () => Window != null);
            MaxCommand = new DefaultCommand(
                () => Window.WindowState = (Window.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal,
                () => Window != null);
        }

        private void BaseWindowTitleControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Window != null && e.LeftButton == MouseButtonState.Pressed)
            {
                Window.DragMove();
            }
        }

        private void dbl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Window != null)
            {
                MaxCommand.Execute(null);
            }
        }
    }
}
