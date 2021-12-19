using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MvvmServiceLibrary.ContentRegionMediator
{
    public class ContentRegionMediator
    {
        public static Dictionary<ContentRegionType, ContentControl> ContentControls { get; } = new Dictionary<ContentRegionType, ContentControl>();

        public static readonly DependencyProperty MainContentRegionProperty =
            DependencyProperty.RegisterAttached(
                "MainContentRegion",
                typeof(bool),
                typeof(ContentRegionMediator),
                new PropertyMetadata(
                    default(bool),
                    (d, e) =>
                    {
                        if (d is ContentControl contentControl)
                        {
                            bool attache = (bool)e.NewValue;
                            if (attache)
                            {
                                ContentControls.Add(ContentRegionType.MainContent, contentControl);
                            }
                            else
                            {
                                ContentControls.Remove(ContentRegionType.MainContent);
                            }
                        }
                    }));

        public static void SetMainContentRegion(DependencyObject obj, bool value)
        {
            obj.SetValue(MainContentRegionProperty, value);
        }

        public static bool GetMainContentRegion(DependencyObject obj)
        {
            return (bool)obj.GetValue(MainContentRegionProperty);
        }

        public static readonly DependencyProperty OverwrapContentRegionProperty =
            DependencyProperty.RegisterAttached(
                "OverwrapContentRegion",
                typeof(bool),
                typeof(ContentRegionMediator),
                new PropertyMetadata(
                    default(bool),
                    (d, e) =>
                    {
                        if (d is ContentControl contentControl)
                        {
                            bool attache = (bool)e.NewValue;
                            if (attache)
                            {
                                ContentControls.Add(ContentRegionType.OverwrapContent, contentControl);
                            }
                            else
                            {
                                ContentControls.Remove(ContentRegionType.OverwrapContent);
                            }
                        }
                    }));

        public static void SetOverwrapContentRegion(DependencyObject obj, bool value)
        {
            obj.SetValue(OverwrapContentRegionProperty, value);
        }

        public static bool GetOverwrapContentRegion(DependencyObject obj)
        {
            return (bool)obj.GetValue(OverwrapContentRegionProperty);
        }
    }
}
