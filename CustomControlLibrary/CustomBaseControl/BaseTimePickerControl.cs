using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
    public class BaseTimePickerControl : BaseCustomControl
    {
        private int HourLimit = 24;
        private int MinuteLimit = 60;

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
                            if (e.NewValue != e.OldValue)
                            {
                                string hVal = e.NewValue as string;
                                int hour = 0;
                                if (!string.IsNullOrEmpty(hVal))
                                {
                                    hour = int.Parse(hVal, CultureInfo.CurrentCulture);
                                }
                                if (hour >= control.HourLimit)
                                {
                                    hour = control.HourLimit - 1;
                                }
                                string mVal = control.Minute;
                                int minute = 0;
                                if (!string.IsNullOrEmpty(mVal))
                                {
                                    minute = int.Parse(mVal, CultureInfo.CurrentCulture);
                                }
                                if (minute >= control.MinuteLimit)
                                {
                                    minute = control.MinuteLimit - 1;
                                }
                                if (control.Time.Hours != hour || control.Time.Minutes != minute)
                                {
                                    TimeSpan dt = new TimeSpan(hour, minute, 0);
                                    control.Time = dt;
                                }
                            }
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
                            if (e.NewValue != e.OldValue)
                            {
                                string mVal = e.NewValue as string;
                                int minute = 0;
                                if (!string.IsNullOrEmpty(mVal))
                                {
                                    minute = int.Parse(mVal, CultureInfo.CurrentCulture);
                                }
                                if (minute >= control.MinuteLimit)
                                {
                                    minute = control.MinuteLimit - 1;
                                }
                                string hVal = control.Hour;
                                int hour = 0;
                                if (!string.IsNullOrEmpty(hVal))
                                {
                                    hour = int.Parse(hVal, CultureInfo.CurrentCulture);
                                }
                                if (hour >= control.HourLimit)
                                {
                                    hour = control.HourLimit;
                                }
                                if (control.Time.Hours != hour || control.Time.Minutes != minute)
                                {
                                    TimeSpan dt = new TimeSpan(hour, minute, 0);
                                    control.Time = dt;
                                }
                            }
                        }
                    }));

        public TimeSpan Time
        {
            get => (TimeSpan)GetValue(TimeProperty);
            set => SetValue(TimeProperty, value);
        }

        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register(
                nameof(Time),
                typeof(TimeSpan),
                typeof(BaseTimePickerControl),
                new FrameworkPropertyMetadata(
                    new TimeSpan(0, 0, 0),
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    (d, e) =>
                    {
                        if (d is BaseTimePickerControl control)
                        {
                            string hVal = ((TimeSpan)e.NewValue).Hours.ToString(CultureInfo.CurrentCulture);
                            if (control.Hour != hVal)
                            {
                                control.Hour = hVal;
                            }
                            string mVal = ((TimeSpan)e.NewValue).Minutes.ToString(CultureInfo.CurrentCulture);
                            if (control.Minute != mVal)
                            {
                                control.Minute = mVal;
                            }
                        }
                    }));

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
            TextBox control = sender as TextBox;
            string val = control.CaretIndex == 0 ? e.Text + control.Text : control.Text + e.Text;
            e.Handled = !new Regex("[0-9]").IsMatch(e.Text) || int.Parse(val, CultureInfo.CurrentCulture) > HourLimit;
        }

        private void MinuteTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox control = sender as TextBox;
            string val = control.CaretIndex == 0 ? e.Text + control.Text : control.Text + e.Text;
            e.Handled = !new Regex("[0-9]").IsMatch(e.Text) || int.Parse(val, CultureInfo.CurrentCulture) > MinuteLimit;
        }
    }
}
