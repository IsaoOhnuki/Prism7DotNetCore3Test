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
    ///     <MyNamespace:BaseButtonControl/>
    ///
    /// </summary>
    public class BaseButtonControl : Control
    {
        public new HorizontalAlignment HorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static new readonly DependencyProperty HorizontalAlignmentProperty =
            DependencyProperty.Register(
                nameof(HorizontalAlignment),
                typeof(HorizontalAlignment),
                typeof(BaseButtonControl),
                new FrameworkPropertyMetadata(default));

        public new VerticalAlignment VerticalAlignment
        {
            get => (VerticalAlignment)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static new readonly DependencyProperty VerticalAlignmentProperty =
            DependencyProperty.Register(
                nameof(VerticalAlignment),
                typeof(VerticalAlignment),
                typeof(BaseButtonControl),
                new FrameworkPropertyMetadata(default));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                nameof(Text),
                typeof(string),
                typeof(BaseButtonControl),
                new FrameworkPropertyMetadata(default));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                nameof(Command),
                typeof(ICommand),
                typeof(BaseButtonControl),
                new FrameworkPropertyMetadata(default(ICommand)));

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(
                nameof(CommandParameter),
                typeof(object),
                typeof(BaseButtonControl),
                new FrameworkPropertyMetadata(default));

        static BaseButtonControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseButtonControl), new FrameworkPropertyMetadata(typeof(BaseButtonControl)));
        }
    }
}
