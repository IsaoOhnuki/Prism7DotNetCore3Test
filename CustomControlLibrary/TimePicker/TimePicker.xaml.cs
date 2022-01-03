using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.TimePicker
{
    /// <summary>
    /// TimePicker.xaml の相互作用ロジック
    /// </summary>
    public partial class TimePicker : UserControl
    {
        public TimeSpan SelectedTime
        {
            get => (TimeSpan)GetValue(SelectedTimeProperty);
            set => SetValue(SelectedTimeProperty, value);
        }

        public static readonly DependencyProperty SelectedTimeProperty =
            DependencyProperty.Register(
                nameof(SelectedTime),
                typeof(TimeSpan),
                typeof(TimePicker),
                new FrameworkPropertyMetadata(
                    new TimeSpan(0, 0, 0),
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public TimePicker()
        {
            InitializeComponent();
        }
    }
}
