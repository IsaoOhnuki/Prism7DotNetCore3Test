﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLibrary.Button
{
    /// <summary>
    /// DialogButtonBar.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogButtonBar : UserControl
    {
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
