using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLibrary.Panel
{
    /// <summary>
    /// DialogPanel.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogPanel : UserControl
    {
        public new object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public new static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(
                nameof(Content),
                typeof(object),
                typeof(DialogPanel),
                new FrameworkPropertyMetadata(default));

        public new DataTemplate ContentTemplate
        {
            get => (DataTemplate)GetValue(ContentTemplateProperty);
            set => SetValue(ContentTemplateProperty, value);
        }

        public new static readonly DependencyProperty ContentTemplateProperty =
            DependencyProperty.Register(
                nameof(ContentTemplate),
                typeof(DataTemplate),
                typeof(DialogPanel),
                new FrameworkPropertyMetadata(default));

        public new DataTemplateSelector ContentTemplateSelector
        {
            get => (DataTemplateSelector)GetValue(ContentTemplateSelectorProperty);
            set => SetValue(ContentTemplateSelectorProperty, value);
        }

        public new static readonly DependencyProperty ContentTemplateSelectorProperty =
            DependencyProperty.Register(
                nameof(ContentTemplateSelector),
                typeof(DataTemplateSelector),
                typeof(DialogPanel),
                new FrameworkPropertyMetadata(default));

        public ICommand OkCommand
        {
            get => (ICommand)GetValue(OkCommandProperty);
            set => SetValue(OkCommandProperty, value);
        }

        public static readonly DependencyProperty OkCommandProperty =
            DependencyProperty.Register(
                nameof(OkCommand),
                typeof(ICommand),
                typeof(DialogPanel),
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
                typeof(DialogPanel),
                new FrameworkPropertyMetadata(default(ICommand)));

        public DialogPanel()
        {
            InitializeComponent();
        }
    }
}
