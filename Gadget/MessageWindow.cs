using SiretT.Utils.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace SiretT.Controls {
    public class MessageWindow : Window {
        private IntPtr parentHwnd;
        private IntPtr hwnd;
        private Window parent;

        public MessageWindow(Window window) {
            this.Loaded += NewUserMessage_Loaded;
            this.WindowStyle = System.Windows.WindowStyle.None;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            this.ShowInTaskbar = false;
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.AllowsTransparency = true;
            parentHwnd = new WindowInteropHelper(window).Handle;
            parent = window;
            parent.SizeChanged += MessageWindow_StateChanged;
        }

        private void MessageWindow_StateChanged(object sender, EventArgs e) {
            double left = (parent.Width / 2.0) - (this.Width / 2.0);
            double top = (parent.Height / 2.0) - (this.Height / 2.0);
            //Win32.MoveWindow(hwnd, (int)left, (int)top, (int)this.Width, (int)this.Height, true);
            this.Left = 0;
            this.Top = 0;
        }

        void NewUserMessage_Loaded(object sender, RoutedEventArgs e) {
            hwnd = new WindowInteropHelper(this).Handle;
            parent.Topmost = true;
            Win32.SetParent(hwnd, parentHwnd);
            int exStyle = (int)Win32.GetWindowLong(hwnd, (int)Win32.GetWindowLongFields.GWL_EXSTYLE);

            exStyle |= (int)Win32.ExtendedWindowStyles.WS_EX_TOOLWINDOW;
            Win32.SetWindowLong(hwnd, (int)Win32.GetWindowLongFields.GWL_EXSTYLE, (IntPtr)exStyle);
            Win32.EnableWindow(parentHwnd, true);
            Win32.SetFocus(hwnd);
            double left = (parent.ActualWidth / 2.0) - (this.Width / 2.0);
            double top = (parent.ActualHeight / 2.0) - (this.Height / 2.0);
            //Win32.MoveWindow(hwnd, (int)0, (int)0, (int)this.Width, (int)this.Height, true);
            this.Left = 0;
            this.Top = 0;
            parent.Topmost = false;
        }
    }
}
