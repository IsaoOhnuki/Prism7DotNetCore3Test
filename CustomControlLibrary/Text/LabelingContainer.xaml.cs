using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.Text
{
    /// <summary>
    /// LabelingContainer.xaml の相互作用ロジック
    /// </summary>
    public partial class LabelingContainer : UserControl
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
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(default));

        internal Visibility LabelVisibility
        {
            get => (Visibility)GetValue(LabelVisibilityProperty);
            set => SetValue(LabelVisibilityProperty, value);
        }

        internal static readonly DependencyProperty LabelVisibilityProperty =
            DependencyProperty.Register(
                nameof(LabelVisibility),
                typeof(Visibility),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(defaultValue: Visibility.Visible));

        public bool LabelVisible
        {
            get => (bool)GetValue(LabelVisibleProperty);
            set => SetValue(LabelVisibleProperty, value);
        }

        public static readonly DependencyProperty LabelVisibleProperty =
            DependencyProperty.Register(
                nameof(LabelVisible),
                typeof(bool),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(
                    defaultValue: true,
                    (d, e) =>
                    {
                        if (d is LabelingContainer control)
                        {
                            bool visible = (bool)e.NewValue;
                            control.LabelVisibility = visible ? Visibility.Visible : Visibility.Hidden;
                        }
                    }
                    ));

        internal GridLength TopHeight
        {
            get => (GridLength)GetValue(TopHeightProperty);
            set => SetValue(TopHeightProperty, value);
        }

        internal static readonly DependencyProperty TopHeightProperty =
            DependencyProperty.Register(
                nameof(TopHeight),
                typeof(GridLength),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(default(GridLength)));

        internal GridLength BottomHeight
        {
            get => (GridLength)GetValue(BottomHeightProperty);
            set => SetValue(BottomHeightProperty, value);
        }

        internal static readonly DependencyProperty BottomHeightProperty =
            DependencyProperty.Register(
                nameof(BottomHeight),
                typeof(GridLength),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(default(GridLength)));

        internal GridLength LeftWidth
        {
            get => (GridLength)GetValue(LeftWidthProperty);
            set => SetValue(LeftWidthProperty, value);
        }

        internal static readonly DependencyProperty LeftWidthProperty =
            DependencyProperty.Register(
                nameof(LeftWidth),
                typeof(GridLength),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(default(GridLength)));

        internal GridLength RightWidth
        {
            get => (GridLength)GetValue(RightWidthProperty);
            set => SetValue(RightWidthProperty, value);
        }

        internal static readonly DependencyProperty RightWidthProperty =
            DependencyProperty.Register(
                nameof(RightWidth),
                typeof(GridLength),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(default(GridLength)));

        public GridLength LabelHeight
        {
            get => (GridLength)GetValue(LabelHeightProperty);
            set => SetValue(LabelHeightProperty, value);
        }

        public static readonly DependencyProperty LabelHeightProperty =
            DependencyProperty.Register(
                nameof(LabelHeight),
                typeof(GridLength),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(
                    defaultValue: GridLength.Auto,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                        (d, e) =>
                        {
                            if (d is LabelingContainer control)
                            {
                                ControlRender(control, control.LabelingPosition);
                            }
                        }));

        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register(
                nameof(LabelWidth),
                typeof(GridLength),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(
                    defaultValue: GridLength.Auto,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                        (d, e) =>
                        {
                            if (d is LabelingContainer control)
                            {
                                ControlRender(control, control.LabelingPosition);
                            }
                        }));

        public new object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public static new readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(
                nameof(Content),
                typeof(object),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(default));

        //public new HorizontalAlignment HorizontalContentAlignment
        //{
        //    get => (HorizontalAlignment)GetValue(HorizontalContentAlignmentProperty);
        //    set => SetValue(HorizontalContentAlignmentProperty, value);
        //}

        //public static new readonly DependencyProperty HorizontalContentAlignmentProperty =
        //    DependencyProperty.Register(
        //        nameof(HorizontalContentAlignment),
        //        typeof(HorizontalAlignment),
        //        typeof(LabelingContainer),
        //        new FrameworkPropertyMetadata(default));

        //public new VerticalAlignment VerticalContentAlignment
        //{
        //    get => (VerticalAlignment)GetValue(VerticalContentAlignmentProperty);
        //    set => SetValue(VerticalContentAlignmentProperty, value);
        //}

        //public static new readonly DependencyProperty VerticalContentAlignmentProperty =
        //    DependencyProperty.Register(
        //        nameof(VerticalContentAlignment),
        //        typeof(VerticalAlignment),
        //        typeof(LabelingContainer),
        //        new FrameworkPropertyMetadata(default));

        public CrossAlignment LabelingPosition
        {
            get => (CrossAlignment)GetValue(LabelingPositionProperty);
            set => SetValue(LabelingPositionProperty, value);
        }

        public static readonly DependencyProperty LabelingPositionProperty =
            DependencyProperty.Register(
                nameof(LabelingPosition),
                typeof(CrossAlignment),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(
                    CrossAlignment.Top,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    (d, e) =>
                    {
                        if (d is LabelingContainer control)
                        {
                            ControlRender(control, (CrossAlignment)e.NewValue);
                        }
                    }));

        private static void ControlRender(LabelingContainer control, CrossAlignment alignment)
        {
            switch (alignment)
            {
                case CrossAlignment.Left:
                    control.LabelRow = 1;
                    control.LabelColumn = 0;
                    control.TopHeight = new GridLength(0, GridUnitType.Star);
                    control.BottomHeight = new GridLength(0, GridUnitType.Star);
                    control.LeftWidth = control.LabelWidth;
                    control.RightWidth = new GridLength(0, GridUnitType.Star);
                    break;
                case CrossAlignment.Top:
                    control.LabelRow = 0;
                    control.LabelColumn = 1;
                    control.TopHeight = control.LabelHeight;
                    control.BottomHeight = new GridLength(0, GridUnitType.Star);
                    control.LeftWidth = new GridLength(0, GridUnitType.Star);
                    control.RightWidth = new GridLength(0, GridUnitType.Star);
                    break;
                case CrossAlignment.Right:
                    control.LabelRow = 1;
                    control.LabelColumn = 2;
                    control.TopHeight = new GridLength(0, GridUnitType.Star);
                    control.BottomHeight = new GridLength(0, GridUnitType.Star);
                    control.LeftWidth = new GridLength(0, GridUnitType.Star);
                    control.RightWidth = control.LabelWidth;
                    break;
                case CrossAlignment.Bottom:
                    control.LabelRow = 2;
                    control.LabelColumn = 1;
                    control.TopHeight = new GridLength(0, GridUnitType.Star);
                    control.BottomHeight = control.LabelHeight;
                    control.LeftWidth = new GridLength(0, GridUnitType.Star);
                    control.RightWidth = new GridLength(0, GridUnitType.Star);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        internal int LabelRow
        {
            get => (int)GetValue(LabelRowProperty);
            set => SetValue(LabelRowProperty, value);
        }

        internal static readonly DependencyProperty LabelRowProperty =
            DependencyProperty.Register(
                nameof(LabelRow),
                typeof(int),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(defaultValue: 0));

        internal int LabelColumn
        {
            get => (int)GetValue(LabelingPositionProperty);
            set => SetValue(LabelColumnProperty, value);
        }

        internal static readonly DependencyProperty LabelColumnProperty =
            DependencyProperty.Register(
                nameof(LabelColumn),
                typeof(int),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(defaultValue: 1));

        public LabelingContainer()
        {
            InitializeComponent();
        }
    }
}
