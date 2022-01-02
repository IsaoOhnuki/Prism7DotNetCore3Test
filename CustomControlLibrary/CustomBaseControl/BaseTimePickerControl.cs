using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControlLibrary.CustomBaseControl
{
    /// <summary>
    /// このカスタム コントロールを XAML ファイルで使用するには、手順 1a または 1b の後、手順 2 に従います。
    ///
    /// 手順 1a) 現在のプロジェクトに存在する XAML ファイルでこのカスタム コントロールを使用する場合
    /// この XmlNamespace 属性を使用場所であるマークアップ ファイルのルート要素に
    /// 追加します:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControlLibrary.CustomBaseControl"
    ///
    ///
    /// 手順 1b) 異なるプロジェクトに存在する XAML ファイルでこのカスタム コントロールを使用する場合
    /// この XmlNamespace 属性を使用場所であるマークアップ ファイルのルート要素に
    /// 追加します:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControlLibrary.CustomBaseControl;assembly=CustomControlLibrary.CustomBaseControl"
    ///
    /// また、XAML ファイルのあるプロジェクトからこのプロジェクトへのプロジェクト参照を追加し、
    /// リビルドして、コンパイル エラーを防ぐ必要があります:
    ///
    ///     ソリューション エクスプローラーで対象のプロジェクトを右クリックし、
    ///     [参照の追加] の [プロジェクト] を選択してから、このプロジェクトを参照し、選択します。
    ///
    ///
    /// 手順 2)
    /// コントロールを XAML ファイルで使用します。
    ///
    ///     <MyNamespace:BaseTimePicker/>
    ///
    /// </summary>
    public class BaseTimePickerControl : Control
    {
        internal string Hour
        {
            get => (string)GetValue(HourProperty);
            set => SetValue(HourProperty, value);
        }

        internal static readonly DependencyProperty HourProperty =
            DependencyProperty.Register(
                nameof(Hour),
                typeof(string),
                typeof(BaseTimePickerControl),
                new FrameworkPropertyMetadata(
                    default,
                    (d, e) =>
                    {
                        if (d is BaseTimePickerControl control)
                        {
                            int hour = int.Parse(e.NewValue as string);
                            if (hour > 12)
                            {
                                hour = 12;
                            }
                            int minute = int.Parse(control.Minute);
                            if (minute > 59)
                            {
                                minute = 59;
                            }
                            DateTime dt = new DateTime(1, 1, 1, hour, minute, 0);
                            control.Time = dt;
                        }
                    }));

        internal string Minute
        {
            get => (string)GetValue(MinuteProperty);
            set => SetValue(MinuteProperty, value);
        }

        internal static readonly DependencyProperty MinuteProperty =
            DependencyProperty.Register(
                nameof(Minute),
                typeof(string),
                typeof(BaseTimePickerControl),
                new FrameworkPropertyMetadata(
                    default,
                    (d, e) =>
                    {
                        if (d is BaseTimePickerControl control)
                        {
                            int minute = int.Parse(e.NewValue as string);
                            if (minute > 59)
                            {
                                minute = 59;
                            }
                            int hour = int.Parse(control.Minute);
                            if (hour > 12)
                            {
                                hour = 12;
                            }
                            DateTime dt = new DateTime(1, 1, 1, hour, minute, 0);
                            control.Time = dt;
                        }
                    }));

        public DateTime Time
        {
            get => (DateTime)GetValue(TimeProperty);
            set => SetValue(TimeProperty, value);
        }

        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register(
                nameof(Time),
                typeof(DateTime),
                typeof(BaseTimePickerControl),
                new FrameworkPropertyMetadata(default));

        static BaseTimePickerControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseTimePickerControl), new FrameworkPropertyMetadata(typeof(BaseTimePickerControl)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            TextBox hourTextBox = GetTemplateChild("HourTextBox") as TextBox;
            hourTextBox.PreviewTextInput += HourTextBox_PreviewTextInput;
            TextBox minuteTextBox = GetTemplateChild("MinuteTextBox") as TextBox;
            minuteTextBox.PreviewTextInput += MinuteTextBox_PreviewTextInput;
        }

        private void HourTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            BaseTimePickerControl control = sender as BaseTimePickerControl;
            e.Handled = !new Regex("[0-9]").IsMatch(e.Text) || control.Hour.Length >= 2 || int.Parse(control.Hour + e.Text) > 12;
        }

        private void MinuteTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            BaseTimePickerControl control = sender as BaseTimePickerControl;
            e.Handled = !new Regex("[0-9]").IsMatch(e.Text) || control.Hour.Length >= 2 || int.Parse(control.Minute + e.Text) > 59;
        }
    }
}
