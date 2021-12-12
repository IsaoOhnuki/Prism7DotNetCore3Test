using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomControlLibrary.CustomBaseControl
{
    /// <summary>
    /// LabelBaseControl.xaml の相互作用ロジック
    /// </summary>
    public partial class LabelBaseControl : UserControl
    {
        public new object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public static new readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(
                nameof(Content),
                typeof(object),
                typeof(LabelBaseControl),
                new PropertyMetadata(
                    default,
                    (d, e) =>
                    {
                        if (d is LabelBaseControl obj)
                        {
                            if (obj.label.Content != e.NewValue)
                            {
                                obj.label.Content = e.NewValue;
                            }
                        }
                    }));

        public ImageSource TopImage
        {
            get => (ImageSource)GetValue(TopImageProperty);
            set => SetValue(TopImageProperty, value);
        }

        public static readonly DependencyProperty TopImageProperty =
            DependencyProperty.Register(
                nameof(TopImage),
                typeof(ImageSource),
                typeof(LabelBaseControl),
                new PropertyMetadata(
                    default,
                    (d, e) =>
                    {
                        if (d is LabelBaseControl obj)
                        {
                            if (obj.topImage.Source != (ImageSource)e.NewValue)
                            {
                                obj.topImage.Source = (ImageSource)e.NewValue;
                            }
                        }
                    }));

        public ImageSource BottomImage
        {
            get => (ImageSource)GetValue(BottomImageProperty);
            set => SetValue(BottomImageProperty, value);
        }

        public static readonly DependencyProperty BottomImageProperty =
            DependencyProperty.Register(
                nameof(BottomImage),
                typeof(ImageSource),
                typeof(LabelBaseControl),
                new PropertyMetadata(
                    default,
                    (d, e) =>
                    {
                        if (d is LabelBaseControl obj)
                        {
                            if (obj.bottomImage.Source != (ImageSource)e.NewValue)
                            {
                                obj.bottomImage.Source = (ImageSource)e.NewValue;
                            }
                        }
                    }));

        public ImageSource LeftImage
        {
            get => (ImageSource)GetValue(LeftImageProperty);
            set => SetValue(LeftImageProperty, value);
        }

        public static readonly DependencyProperty LeftImageProperty =
            DependencyProperty.Register(
                nameof(LeftImage),
                typeof(ImageSource),
                typeof(LabelBaseControl),
                new PropertyMetadata(
                    default,
                    (d, e) =>
                    {
                        if (d is LabelBaseControl obj)
                        {
                            if (obj.leftImage.Source != (ImageSource)e.NewValue)
                            {
                                obj.leftImage.Source = (ImageSource)e.NewValue;
                            }
                        }
                    }));

        public ImageSource RightImage
        {
            get => (ImageSource)GetValue(RightImageProperty);
            set => SetValue(RightImageProperty, value);
        }

        public static readonly DependencyProperty RightImageProperty =
            DependencyProperty.Register(
                nameof(RightImage),
                typeof(ImageSource),
                typeof(LabelBaseControl),
                new PropertyMetadata(
                    default,
                    (d, e) =>
                    {
                        if (d is LabelBaseControl obj)
                        {
                            if (obj.rightImage.Source != (ImageSource)e.NewValue)
                            {
                                obj.rightImage.Source = (ImageSource)e.NewValue;
                            }
                        }
                    }));

        public LabelBaseControl()
        {
            InitializeComponent();
        }
    }
}
