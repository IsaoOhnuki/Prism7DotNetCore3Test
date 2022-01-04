using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Shell;

namespace BlankCoreApp1.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Window枠なしでリサイズ可能にした時にWindow上端に出る白バーを消す
            WindowChrome.SetWindowChrome(this, new WindowChrome()
            {
                GlassFrameThickness = new Thickness(0),
                CaptionHeight = 0,
                ResizeBorderThickness = new Thickness(8),
                CornerRadius = new CornerRadius(0)
            });
        }

        // https://zenn.dev/karamem0/articles/2013_05_27_000000
        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);
        //    var handle = new WindowInteropHelper(this).Handle;
        //    if (handle == IntPtr.Zero)
        //    {
        //        return;
        //    }
        //    HwndSource.FromHwnd(handle).AddHook(this.WindowProc);
        //}

        //private IntPtr WindowProc(IntPtr handle, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        //{
        //    if (msg == (int)Win32.WindowMessages.WM_GETMINMAXINFO)
        //    {
        //        var result = this.OnGetMinMaxInfo(handle, wParam, lParam);
        //        if (result != null)
        //        {
        //            handled = true;
        //            return result.Value;
        //        }
        //    }
        //    return IntPtr.Zero;
        //}

        //private IntPtr? OnGetMinMaxInfo(IntPtr handle, IntPtr wParam, IntPtr lParam)
        //{
        //    var monitor = Win32.MonitorFromWindow(handle, Win32.MonitorFlag.MONITOR_DEFAULTTONEAREST);
        //    if (monitor == IntPtr.Zero)
        //    {
        //        return null;
        //    }
        //    var monitorInfo = new Win32.MonitorInfo();
        //    if (Win32.GetMonitorInfo(monitor, monitorInfo) != true)
        //    {
        //        return null;
        //    }
        //    var workingRectangle = monitorInfo.WorkingRectangle;
        //    var monitorRectangle = monitorInfo.MonitorRectangle;
        //    var minmax = (Win32.MinMaxInfo)Marshal.PtrToStructure(lParam, typeof(Win32.MinMaxInfo));
        //    minmax.MaxPosition.X = Math.Abs(workingRectangle.Left - monitorRectangle.Left);
        //    minmax.MaxPosition.Y = Math.Abs(workingRectangle.Top - monitorRectangle.Top);
        //    minmax.MaxSize.X = Math.Abs(workingRectangle.Right - monitorRectangle.Left);
        //    minmax.MaxSize.Y = Math.Abs(workingRectangle.Bottom - monitorRectangle.Top);
        //    Marshal.StructureToPtr(minmax, lParam, true);
        //    return IntPtr.Zero;
        //}
    }
}
