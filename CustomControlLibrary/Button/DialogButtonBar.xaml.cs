using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLibrary.Button
{
    /// <summary>
    /// DialogButtonBar.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogButtonBar : UserControl
    {
        public string OkCaption
        {
            get => (string)GetValue(OkCaptionProperty);
            set => SetValue(OkCaptionProperty, value);
        }

        public static readonly DependencyProperty OkCaptionProperty =
            DependencyProperty.Register(
                nameof(OkCaption),
                typeof(string),
                typeof(DialogButtonBar),
                new FrameworkPropertyMetadata(default(string)));

        public string CancelCaption
        {
            get => (string)GetValue(CancelCaptionProperty);
            set => SetValue(CancelCaptionProperty, value);
        }

        public static readonly DependencyProperty CancelCaptionProperty =
            DependencyProperty.Register(
                nameof(CancelCaption),
                typeof(string),
                typeof(DialogButtonBar),
                new FrameworkPropertyMetadata(default(string)));

        public bool OkButtonIsEnabled
        {
            get => (bool)GetValue(OkButtonIsEnabledProperty);
            set => SetValue(OkButtonIsEnabledProperty, value);
        }

        public static readonly DependencyProperty OkButtonIsEnabledProperty =
            DependencyProperty.Register(
                nameof(OkButtonIsEnabled),
                typeof(bool),
                typeof(DialogButtonBar),
                new FrameworkPropertyMetadata(defaultValue: true));

        public bool CancelButtonIsEnabled
        {
            get => (bool)GetValue(CancelButtonIsEnabledProperty);
            set => SetValue(CancelButtonIsEnabledProperty, value);
        }

        public static readonly DependencyProperty CancelButtonIsEnabledProperty =
            DependencyProperty.Register(
                nameof(CancelButtonIsEnabled),
                typeof(bool),
                typeof(DialogButtonBar),
                new FrameworkPropertyMetadata(defaultValue: true));

        public Visibility OkButtonVisibility
        {
            get => (Visibility)GetValue(OkButtonVisibilityProperty);
            set => SetValue(OkButtonVisibilityProperty, value);
        }

        public static readonly DependencyProperty OkButtonVisibilityProperty =
            DependencyProperty.Register(
                nameof(OkButtonVisibility),
                typeof(Visibility),
                typeof(DialogButtonBar),
                new FrameworkPropertyMetadata(default(Visibility)));

        public Visibility CancelButtonVisibility
        {
            get => (Visibility)GetValue(CancelButtonVisibilityProperty);
            set => SetValue(CancelButtonVisibilityProperty, value);
        }

        public static readonly DependencyProperty CancelButtonVisibilityProperty =
            DependencyProperty.Register(
                nameof(CancelButtonVisibility),
                typeof(Visibility),
                typeof(DialogButtonBar),
                new FrameworkPropertyMetadata(default(Visibility)));

        public ICommand OkCommand
        {
            get => (ICommand)GetValue(OkCommandProperty);
            set => SetValue(OkCommandProperty, value);
        }

        public static readonly DependencyProperty OkCommandProperty =
            DependencyProperty.Register(
                nameof(OkCommand),
                typeof(ICommand),
                typeof(DialogButtonBar),
                new FrameworkPropertyMetadata(default(ICommand)));

        public ICommand CancelCommand
        {
            get => (ICommand)GetValue(CancelCommandProperty);
            set => SetValue(CancelCommandProperty, value);
        }

        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register(
                nameof(CancelCommand),
                typeof(ICommand),
                typeof(DialogButtonBar),
                new FrameworkPropertyMetadata(default(ICommand)));

        public DialogButtonBar()
        {
            InitializeComponent();
        }
    }
}
