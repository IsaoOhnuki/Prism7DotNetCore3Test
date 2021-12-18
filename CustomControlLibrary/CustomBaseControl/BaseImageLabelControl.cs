using ModelLibrary;
using System.Windows;
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
    ///     <MyNamespace:ImageLabel/>
    ///
    /// </summary>

    public class BaseImageLabelControl : BaseCustomControl
    {
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                nameof(Text),
                typeof(string),
                typeof(BaseImageLabelControl),
                new FrameworkPropertyMetadata(defaultValue: "BaseImageLabelControl"));

        public Thickness TextMargin
        {
            get => (Thickness)GetValue(TextMarginProperty);
            set => SetValue(TextMarginProperty, value);
        }

        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register(
                nameof(TextMargin),
                typeof(Thickness),
                typeof(BaseImageLabelControl),
                new FrameworkPropertyMetadata(default(Thickness)));

        public ImageSource ImageSource
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        internal static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register(
                nameof(ImageSource),
                typeof(ImageSource),
                typeof(BaseImageLabelControl),
                new FrameworkPropertyMetadata(default(ImageSource)));

        public Thickness ImageMargin
        {
            get => (Thickness)GetValue(ImageMarginProperty);
            set => SetValue(ImageMarginProperty, value);
        }

        public static readonly DependencyProperty ImageMarginProperty =
            DependencyProperty.Register(
                nameof(ImageMargin),
                typeof(Thickness),
                typeof(BaseImageLabelControl),
                new FrameworkPropertyMetadata(default(Thickness)));

        internal int ImageRow
        {
            get => (int)GetValue(ImageRowProperty);
            set => SetValue(ImageRowProperty, value);
        }

        internal static readonly DependencyProperty ImageRowProperty =
            DependencyProperty.Register(
                nameof(ImageRow),
                typeof(int),
                typeof(BaseImageLabelControl),
                new FrameworkPropertyMetadata(defaultValue: 1));

        internal int ImageColumn
        {
            get => (int)GetValue(ImageColumnProperty);
            set => SetValue(ImageColumnProperty, value);
        }

        internal static readonly DependencyProperty ImageColumnProperty =
            DependencyProperty.Register(
                nameof(ImageColumn),
                typeof(int),
                typeof(BaseImageLabelControl),
                new FrameworkPropertyMetadata(defaultValue: 0));

        public CrossAlignment ImageAlignment
        {
            get => (CrossAlignment)GetValue(ImageAlignmentProperty);
            set => SetValue(ImageAlignmentProperty, value);
        }

        public static readonly DependencyProperty ImageAlignmentProperty =
            DependencyProperty.Register(
                nameof(ImageAlignment),
                typeof(CrossAlignment),
                typeof(BaseImageLabelControl),
                new FrameworkPropertyMetadata(
                    default(CrossAlignment),
                    (d, e) =>
                    {
                        if (d is BaseImageLabelControl ctrl)
                        {
                            switch ((CrossAlignment)e.NewValue)
                            {
                                case CrossAlignment.Left:
                                    ctrl.ImageRow = 1;
                                    ctrl.ImageColumn = 0;
                                    break;
                                case CrossAlignment.Top:
                                    ctrl.ImageRow = 0;
                                    ctrl.ImageColumn = 1;
                                    break;
                                case CrossAlignment.Right:
                                    ctrl.ImageRow = 1;
                                    ctrl.ImageColumn = 2;
                                    break;
                                case CrossAlignment.Bottom:
                                    ctrl.ImageRow = 2;
                                    ctrl.ImageColumn = 1;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }));

        internal GridLength LeftMargin
        {
            get => (GridLength)GetValue(LeftMarginProperty);
            set => SetValue(LeftMarginProperty, value);
        }

        internal static readonly DependencyProperty LeftMarginProperty =
            DependencyProperty.Register(
                nameof(LeftMargin),
                typeof(GridLength),
                typeof(BaseImageLabelControl),
                new FrameworkPropertyMetadata(default(GridLength)));

        internal GridLength RightMargin
        {
            get => (GridLength)GetValue(RightMarginProperty);
            set => SetValue(RightMarginProperty, value);
        }

        internal static readonly DependencyProperty RightMarginProperty =
            DependencyProperty.Register(
                nameof(RightMargin),
                typeof(GridLength),
                typeof(BaseImageLabelControl),
                new FrameworkPropertyMetadata(default(GridLength)));

        public new HorizontalAlignment HorizontalContentAlignment
        {
            get => (HorizontalAlignment)GetValue(HorizontalContentAlignmentProperty);
            set => SetValue(HorizontalContentAlignmentProperty, value);
        }

        public static new readonly DependencyProperty HorizontalContentAlignmentProperty =
            DependencyProperty.Register(
                nameof(HorizontalContentAlignment),
                typeof(HorizontalAlignment),
                typeof(BaseImageLabelControl),
                new FrameworkPropertyMetadata(
                    default(HorizontalAlignment),
                    (d, e) =>
                    {
                        if (d is BaseImageLabelControl ctrl)
                        {
                            switch ((HorizontalAlignment)e.NewValue)
                            {
                                case HorizontalAlignment.Stretch:
                                case HorizontalAlignment.Center:
                                    ctrl.LeftMargin = new GridLength(1, GridUnitType.Star);
                                    ctrl.RightMargin = new GridLength(1, GridUnitType.Star);
                                    break;
                                case HorizontalAlignment.Left:
                                    ctrl.LeftMargin = new GridLength(0, GridUnitType.Star);
                                    ctrl.RightMargin = new GridLength(1, GridUnitType.Star);
                                    break;
                                case HorizontalAlignment.Right:
                                    ctrl.LeftMargin = new GridLength(1, GridUnitType.Star);
                                    ctrl.RightMargin = new GridLength(0, GridUnitType.Star);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }));

        internal GridLength TopMargin
        {
            get => (GridLength)GetValue(TopMarginProperty);
            set => SetValue(TopMarginProperty, value);
        }

        internal static readonly DependencyProperty TopMarginProperty =
            DependencyProperty.Register(
                nameof(TopMargin),
                typeof(GridLength),
                typeof(BaseImageLabelControl),
                new FrameworkPropertyMetadata(default(GridLength)));

        internal GridLength BottomMargin
        {
            get => (GridLength)GetValue(BottomMarginProperty);
            set => SetValue(BottomMarginProperty, value);
        }

        internal static readonly DependencyProperty BottomMarginProperty =
            DependencyProperty.Register(
                nameof(BottomMargin),
                typeof(GridLength),
                typeof(BaseImageLabelControl),
                new FrameworkPropertyMetadata(default(GridLength)));

        public new VerticalAlignment VerticalContentAlignment
        {
            get => (VerticalAlignment)GetValue(VerticalContentAlignmentProperty);
            set => SetValue(VerticalContentAlignmentProperty, value);
        }

        public static new readonly DependencyProperty VerticalContentAlignmentProperty =
            DependencyProperty.Register(
                nameof(VerticalContentAlignment),
                typeof(VerticalAlignment),
                typeof(BaseImageLabelControl),
                new FrameworkPropertyMetadata(
                    default(VerticalAlignment),
                    (d, e) =>
                    {
                        if (d is BaseImageLabelControl ctrl)
                        {
                            switch ((VerticalAlignment)e.NewValue)
                            {
                                case VerticalAlignment.Center:
                                case VerticalAlignment.Stretch:
                                    ctrl.TopMargin = new GridLength(1, GridUnitType.Star);
                                    ctrl.BottomMargin = new GridLength(1, GridUnitType.Star);
                                    break;
                                case VerticalAlignment.Top:
                                    ctrl.TopMargin = new GridLength(0, GridUnitType.Star);
                                    ctrl.BottomMargin = new GridLength(1, GridUnitType.Star);
                                    break;
                                case VerticalAlignment.Bottom:
                                    ctrl.TopMargin = new GridLength(1, GridUnitType.Star);
                                    ctrl.BottomMargin = new GridLength(0, GridUnitType.Star);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }));

        static BaseImageLabelControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseImageLabelControl), new FrameworkPropertyMetadata(typeof(BaseImageLabelControl)));
        }
    }
}
