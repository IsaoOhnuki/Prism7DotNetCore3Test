﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLibrary.CustomBaseControl
{
    /// <summary>
    /// DialogButtonBaseControl.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogButtonBaseControl : UserControl
    {
        public new string Content
        {
            get => (string)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public static readonly new DependencyProperty ContentProperty =
            DependencyProperty.Register(
                nameof(Content),
                typeof(string),
                typeof(DialogButtonBaseControl),
                new PropertyMetadata(default(string)));

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
                new PropertyMetadata(default(ICommand)));

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
                new PropertyMetadata(default(object)));

        public DialogButtonBaseControl()
        {
            InitializeComponent();
        }
    }
}
