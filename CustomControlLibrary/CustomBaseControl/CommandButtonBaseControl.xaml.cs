using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLibrary.CustomBaseControl
{
    /// <summary>
    /// DialogButtonBaseControl.xaml の相互作用ロジック
    /// </summary>
    public partial class CommandButtonBaseControl : UserControl
    {
        public new object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public static readonly new DependencyProperty ContentProperty =
            DependencyProperty.Register(
                nameof(Content),
                typeof(object),
                typeof(CommandButtonBaseControl),
                new PropertyMetadata(
                    default(object),
                    (d, e) => {
                        if (d is CommandButtonBaseControl obj)
                        {
                            if (obj.commandButtonLabel.Content != e.NewValue)
                            {
                                obj.commandButtonLabel.Content = e.NewValue;
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
                typeof(CommandButtonBaseControl),
                new PropertyMetadata(
                    default(ICommand),
                    (d, e) => {
                        if (d is CommandButtonBaseControl obj)
                        {
                            if (obj.commandButton.Command != (ICommand)e.NewValue)
                            {
                                obj.commandButton.Command = (ICommand)e.NewValue;
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
                typeof(CommandButtonBaseControl),
                new PropertyMetadata(
                    default(object),
                    (d, e) => {
                        if (d is CommandButtonBaseControl obj)
                        {
                            if (obj.commandButton.CommandParameter != e.NewValue)
                            {
                                obj.commandButton.CommandParameter = e.NewValue;
                            }
                        }
                    }));

        public CommandButtonBaseControl()
        {
            InitializeComponent();
        }
    }
}
