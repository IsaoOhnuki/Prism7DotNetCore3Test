using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLibrary.CustomBaseControl
{
    /// <summary>
    /// DialogButtonBaseControl.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogButtonBaseControl : UserControl
    {
        public new object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public static new readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(
                nameof(Content),
                typeof(object),
                typeof(DialogButtonBaseControl),
                new PropertyMetadata(
                    default,
                    (d, e) =>
                    {
                        if (d is DialogButtonBaseControl obj)
                        {
                            if (obj.label.Content != e.NewValue)
                            {
                                obj.label.Content = e.NewValue;
                            }
                        }
                    }));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                nameof(Command),
                typeof(ICommand),
                typeof(DialogButtonBaseControl),
                new PropertyMetadata(
                    default(ICommand),
                    (d, e) =>
                    {
                        if (d is DialogButtonBaseControl obj)
                        {
                            if (obj.dialogButton.Command != (ICommand)e.NewValue)
                            {
                                obj.dialogButton.Command = (ICommand)e.NewValue;
                            }
                        }
                    }));

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(
                nameof(CommandParameter),
                typeof(object),
                typeof(DialogButtonBaseControl),
                new PropertyMetadata(
                    default,
                    (d, e) =>
                    {
                        if (d is DialogButtonBaseControl obj)
                        {
                            if (obj.dialogButton.CommandParameter != e.NewValue)
                            {
                                obj.dialogButton.CommandParameter = e.NewValue;
                            }
                        }
                    }));

        public DialogButtonBaseControl()
        {
            InitializeComponent();
        }
    }
}
