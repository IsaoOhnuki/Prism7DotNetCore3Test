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

        internal RowDefinition TopHeight
        {
            get => (RowDefinition)GetValue(TopHeightProperty);
            set => SetValue(TopHeightProperty, value);
        }

        internal static readonly DependencyProperty TopHeightProperty =
            DependencyProperty.Register(
                nameof(TopHeight),
                typeof(RowDefinition),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(default));

        internal RowDefinition BottomHeight
        {
            get => (RowDefinition)GetValue(BottomHeightProperty);
            set => SetValue(BottomHeightProperty, value);
        }

        internal static readonly DependencyProperty BottomHeightProperty =
            DependencyProperty.Register(
                nameof(BottomHeight),
                typeof(RowDefinition),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(default));

        internal ColumnDefinition LeftWidth
        {
            get => (ColumnDefinition)GetValue(LeftWidthProperty);
            set => SetValue(LeftWidthProperty, value);
        }

        internal static readonly DependencyProperty LeftWidthProperty =
            DependencyProperty.Register(
                nameof(LeftWidth),
                typeof(ColumnDefinition),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(default));

        internal ColumnDefinition RightWidth
        {
            get => (ColumnDefinition)GetValue(RightWidthProperty);
            set => SetValue(RightWidthProperty, value);
        }

        internal static readonly DependencyProperty RightWidthProperty =
            DependencyProperty.Register(
                nameof(RightWidth),
                typeof(ColumnDefinition),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(default));

        public RowDefinition LabelHeight
        {
            get => (RowDefinition)GetValue(LabelHeightProperty);
            set => SetValue(LabelHeightProperty, value);
        }

        public static readonly DependencyProperty LabelHeightProperty =
            DependencyProperty.Register(
                nameof(LabelHeight),
                typeof(RowDefinition),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(
                    default,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    (d, e) =>
                    {
                        if (d is LabelingContainer control)
                        {
                            if (e.NewValue is string str)
                            {

                            }
                            else if (e.NewValue is RowDefinition def)
                            {

                            }
                        }
                    }));

        public ColumnDefinition LabelWidth
        {
            get => (ColumnDefinition)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register(
                nameof(LabelWidth),
                typeof(ColumnDefinition),
                typeof(LabelingContainer),
                new FrameworkPropertyMetadata(default));

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
                    (d, e) =>
                    {
                        if (d is LabelingContainer control)
                        {
                            switch ((CrossAlignment)e.NewValue)
                            {
                                case CrossAlignment.Left:
                                    control.LabelRow = 1;
                                    control.LabelColumn = 0;
                                    control.TopHeight = new RowDefinition { Height = GridLength.Auto };
                                    control.BottomHeight = new RowDefinition { Height = GridLength.Auto };
                                    control.LeftWidth = new ColumnDefinition { Width = (GridLength)new GridLengthConverter().ConvertFrom(control.LabelWidth) };
                                    control.RightWidth = new ColumnDefinition { Width = GridLength.Auto };
                                    break;
                                case CrossAlignment.Top:
                                    control.LabelRow = 0;
                                    control.LabelColumn = 1;
                                    control.TopHeight = new RowDefinition { Height = (GridLength)new GridLengthConverter().ConvertFrom(control.LabelHeight) };
                                    control.BottomHeight = new RowDefinition { Height = GridLength.Auto };
                                    control.LeftWidth = new ColumnDefinition { Width = GridLength.Auto };
                                    control.RightWidth = new ColumnDefinition { Width = GridLength.Auto };
                                    break;
                                case CrossAlignment.Right:
                                    control.LabelRow = 0;
                                    control.LabelColumn = 1;
                                    control.TopHeight = new RowDefinition { Height = GridLength.Auto };
                                    control.BottomHeight = new RowDefinition { Height = GridLength.Auto };
                                    control.RightWidth = new ColumnDefinition { Width = (GridLength)new GridLengthConverter().ConvertFrom(control.LabelWidth) };
                                    control.LeftWidth = new ColumnDefinition { Width = GridLength.Auto };
                                    break;
                                case CrossAlignment.Bottom:
                                    control.LabelRow = 2;
                                    control.LabelColumn = 1;
                                    control.TopHeight = new RowDefinition { Height = GridLength.Auto };
                                    control.BottomHeight = new RowDefinition { Height = (GridLength)new GridLengthConverter().ConvertFrom(control.LabelHeight) };
                                    control.LeftWidth = new ColumnDefinition { Width = GridLength.Auto };
                                    control.RightWidth = new ColumnDefinition { Width = GridLength.Auto };
                                    break;
                                default:
                                    throw new NotImplementedException();
                            }
                        }
                    }));

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
