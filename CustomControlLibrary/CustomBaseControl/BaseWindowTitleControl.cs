using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
    ///     <MyNamespace:BaseWindowTitleBar/>
    ///
    /// </summary>
    public class BaseWindowTitleControl : BaseCustomControl
    {
        public object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(
                nameof(Content),
                typeof(object),
                typeof(BaseWindowTitleControl),
                new FrameworkPropertyMetadata(defaultValue: "BaseWindowTitleControl"));

        public object Button1Content
        {
            get => GetValue(Button1ContentProperty);
            set => SetValue(Button1ContentProperty, value);
        }

        public static readonly DependencyProperty Button1ContentProperty =
            DependencyProperty.Register(
                nameof(Button1Content),
                typeof(object),
                typeof(BaseWindowTitleControl),
                new FrameworkPropertyMetadata(defaultValue: "＿"));

        public Brush Button1Brush
        {
            get => (Brush)GetValue(Button1BrushProperty);
            set => SetValue(Button1BrushProperty, value);
        }

        public static readonly DependencyProperty Button1BrushProperty =
            DependencyProperty.Register(
                nameof(Button1Brush),
                typeof(Brush),
                typeof(BaseWindowTitleControl),
                new FrameworkPropertyMetadata(default(Brush)));

        public ICommand Button1Command
        {
            get => (ICommand)GetValue(Button1CommandProperty);
            set => SetValue(Button1CommandProperty, value);
        }

        public static readonly DependencyProperty Button1CommandProperty =
            DependencyProperty.Register(
                nameof(Button1Command),
                typeof(ICommand),
                typeof(BaseWindowTitleControl),
                new FrameworkPropertyMetadata(default(ICommand)));

        public object Button2Content
        {
            get => GetValue(Button2ContentProperty);
            set => SetValue(Button2ContentProperty, value);
        }

        public static readonly DependencyProperty Button2ContentProperty =
            DependencyProperty.Register(
                nameof(Button2Content),
                typeof(object),
                typeof(BaseWindowTitleControl),
                new FrameworkPropertyMetadata(defaultValue: "□"));

        public Brush Button2Brush
        {
            get => (Brush)GetValue(Button2BrushProperty);
            set => SetValue(Button2BrushProperty, value);
        }

        public static readonly DependencyProperty Button2BrushProperty =
            DependencyProperty.Register(
                nameof(Button2Brush),
                typeof(Brush),
                typeof(BaseWindowTitleControl),
                new FrameworkPropertyMetadata(default(Brush)));

        public ICommand Button2Command
        {
            get => (ICommand)GetValue(Button2CommandProperty);
            set => SetValue(Button2CommandProperty, value);
        }

        public static readonly DependencyProperty Button2CommandProperty =
            DependencyProperty.Register(
                nameof(Button2Command),
                typeof(ICommand),
                typeof(BaseWindowTitleControl),
                new FrameworkPropertyMetadata(default(ICommand)));

        public object Button3Content
        {
            get => GetValue(Button3ContentProperty);
            set => SetValue(Button3ContentProperty, value);
        }

        public static readonly DependencyProperty Button3ContentProperty =
            DependencyProperty.Register(
                nameof(Button3Content),
                typeof(object),
                typeof(BaseWindowTitleControl),
                new FrameworkPropertyMetadata(defaultValue: "×"));

        public Brush Button3Brush
        {
            get => (Brush)GetValue(Button3BrushProperty);
            set => SetValue(Button3BrushProperty, value);
        }

        public static readonly DependencyProperty Button3BrushProperty =
            DependencyProperty.Register(
                nameof(Button3Brush),
                typeof(Brush),
                typeof(BaseWindowTitleControl),
                new FrameworkPropertyMetadata(default(Brush)));

        public ICommand Button3Command
        {
            get => (ICommand)GetValue(Button3CommandProperty);
            set => SetValue(Button3CommandProperty, value);
        }

        public static readonly DependencyProperty Button3CommandProperty =
            DependencyProperty.Register(
                nameof(Button3Command),
                typeof(ICommand),
                typeof(BaseWindowTitleControl),
                new FrameworkPropertyMetadata(default(ICommand)));

        static BaseWindowTitleControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseWindowTitleControl), new FrameworkPropertyMetadata(typeof(BaseWindowTitleControl)));
        }
    }
}
