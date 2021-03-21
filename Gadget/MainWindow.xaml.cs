using Gadget.Commands;
using SiretT.Media;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;

namespace Gadget {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private DispatcherTimer clickTimer = new DispatcherTimer();
        private DateTime time;
        private bool click;
        private TimeSpan interval;
        private Point position;
        private const double dradTh = 2;
        private const double clickTh = 250;
        private const double dclickTh = 250;
        private int clickCount;
        private MouseButtonEventArgs mouseevent;
        private ModifierKeys modifiers;
        private Thread czth;

        #region Window styles
        [Flags]
        public enum ExtendedWindowStyles {
            // ...
            WS_EX_TOOLWINDOW = 0x00000080,
            // ...
        }

        public enum GetWindowLongFields {
            // ...
            GWL_EXSTYLE = (-20),
            // ...
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        public static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong) {
            int error = 0;
            IntPtr result = IntPtr.Zero;
            // Win32 SetWindowLong doesn't clear error on success
            SetLastError(0);

            if (IntPtr.Size == 4) {
                // use SetWindowLong
                Int32 tempResult = IntSetWindowLong(hWnd, nIndex, IntPtrToInt32(dwNewLong));
                error = Marshal.GetLastWin32Error();
                result = new IntPtr(tempResult);
            } else {
                // use SetWindowLongPtr
                result = IntSetWindowLongPtr(hWnd, nIndex, dwNewLong);
                error = Marshal.GetLastWin32Error();
            }

            if ((result == IntPtr.Zero) && (error != 0)) {
                throw new System.ComponentModel.Win32Exception(error);
            }

            return result;
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
        private static extern IntPtr IntSetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
        private static extern Int32 IntSetWindowLong(IntPtr hWnd, int nIndex, Int32 dwNewLong);

        private static int IntPtrToInt32(IntPtr intPtr) {
            return unchecked((int)intPtr.ToInt64());
        }

        [DllImport("kernel32.dll", EntryPoint = "SetLastError")]
        public static extern void SetLastError(int dwErrorCode);
        #endregion

        public MainWindow() {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
            this.LocationChanged += MainWindow_LocationChanged;
            //this.MouseDown += MainWindow_MouseDown;
            _opt_.Visibility = System.Windows.Visibility.Hidden;
            clickTimer.Interval = TimeSpan.FromMilliseconds(dclickTh);
            clickTimer.Tick += clickTimer_Tick;
            //MessageBox.Show(new OverflowException().Message);
        }

        public IntPtr Handle { get { return new WindowInteropHelper(this).Handle; } }

        void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            int exStyle = (int)GetWindowLong(Handle, (int)GetWindowLongFields.GWL_EXSTYLE);

            exStyle |= (int)ExtendedWindowStyles.WS_EX_TOOLWINDOW;
            SetWindowLong(Handle, (int)GetWindowLongFields.GWL_EXSTYLE, (IntPtr)exStyle);
            Settings.Instance.Initalise("settings.xml");
            _gadget_.Background = Settings.Instance.BackColor;

            this.Topmost = Settings.Instance.Topmost;
            pinned.Angle = this.Topmost ? 45 : 0;

            this.Left = Settings.Instance.Left;
            this.Top = Settings.Instance.Top;

            if (Settings.Instance.UseColorization)
                Settings.Instance.BackColor = new SolidColorBrush(ColorHelper.Colorization);

            if (Settings.Instance.UseColorization) {
                BackgroundWorker bwk = new BackgroundWorker();
                bwk.DoWork += bwk_DoWork;
                bwk.RunWorkerAsync();
            }
        }

        void bwk_DoWork(object sender, DoWorkEventArgs e) {
            BackgroundWorker bwk = sender as BackgroundWorker;
            while (Settings.Instance.UseColorization) {
                _gadget_.Dispatcher.Invoke(new Action(() => {
                    Settings.Instance.BackColor = new SolidColorBrush(ColorHelper.Colorization);
                    _gadget_.Background = Settings.Instance.BackColor;
                }));
                Thread.Sleep(3000);
            }
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Settings.Instance.Save("settings.xml");
        }

        void MainWindow_MouseDown(object sender, MouseButtonEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        void MainWindow_LocationChanged(object sender, EventArgs e) {
            Settings.Instance.Left = this.Left;
            Settings.Instance.Top = this.Top;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void _hover__MouseEnter(object sender, MouseEventArgs e) {
            _opt_.Visibility = System.Windows.Visibility.Visible;
            _hover_.Visibility = System.Windows.Visibility.Hidden;
        }

        private void _hover__MouseLeave(object sender, MouseEventArgs e) {
            _hover_.Visibility = System.Windows.Visibility.Visible;
            _opt_.Visibility = System.Windows.Visibility.Hidden;
        }

        private void fixed_Click(object sender, RoutedEventArgs e) {
            this.Topmost = !this.Topmost;
            Settings.Instance.Topmost = this.Topmost;
            pinned.Angle = this.Topmost ? 45 : 0;
        }

        private void settings_Click(object sender, RoutedEventArgs e) {
            if (fg == null || !fg.IsLoaded)
                fg = new Config(_gadget_);
            fg.Show();
            fg.Focus();
            //_gadget_.Background = Settings.Instance.BackColor;
        }

        void clickTimer_Tick(object sender, EventArgs e) {
            clickTimer.Stop();
            Click(mouseevent.ChangedButton, clickCount);
            clickCount = 0;
            modifiers = Keyboard.Modifiers;
        }

        private void _gadget__MouseDown(object sender, MouseButtonEventArgs e) {
            clickTimer.Stop();
            time = DateTime.Now;
            position = e.GetPosition(null);
            if (sender == _gadget_) {
                click = true;
                modifiers = Keyboard.Modifiers;
            }
        }

        private void _gadget__MouseUp(object sender, MouseButtonEventArgs e) {
            if (click) {
                interval = (DateTime.Now - time);
                var nposition = e.GetPosition(null);
                if (nposition.X - position.X <= dradTh && nposition.Y - position.Y <= dradTh)
                    if (interval.TotalMilliseconds <= clickTh) {
                        click = false;
                        mouseevent = e;
                        clickCount++;
                        //Click(e);
                        clickTimer.Start();
                    } else {
                        click = false;
                    }
            }
        }

        private void Click(MouseButton changedButton, int clickCount) {
            foreach (OnClickEvent i in Settings.Instance.Events.Where(d => { return d is OnClickEvent; })) {
                if (changedButton == i.MouseButton && clickCount == i.ClickCount) {
                    if (modifiers != i.ModifierKeys)
                        continue;
                    if (i.DefinedActions == DefinedActions.RunCommand) {
                        RunCommand(i.Command);
                    } else if (i.DefinedActions == DefinedActions.Hibernate)
                        RunCommand("shutdown -h", false);
                    else if (i.DefinedActions == DefinedActions.PowerOff)
                        RunCommand("shutdown -s", false);
                    else if (i.DefinedActions == DefinedActions.Restart)
                        RunCommand("shutdown -r", false);
                    else if (i.DefinedActions == DefinedActions.Settings)
                        RunCommand("ms-settings:");
                    else if (i.DefinedActions == DefinedActions.ControlPanel)
                        RunCommand("control");
                }
            }
            modifiers = ModifierKeys.None;
        }

        private void _gadget__MouseWheel(object sender, MouseWheelEventArgs e) {
            foreach (OnWheelEvent i in Settings.Instance.Events.Where(d => { return d is OnWheelEvent; })) {
                if (i.MouseWheelDirection == MouseWheelDirection.Up && e.Delta < 0) continue;
                if (i.MouseWheelDirection == MouseWheelDirection.Down && e.Delta >= 0) continue;
                if (i.WheelCount == (int)(Math.Abs(e.Delta) / 120)) {
                    if (modifiers != ModifierKeys.None && modifiers != i.ModifierKeys)
                        continue;
                    if (i.DefinedActions == DefinedActions.RunCommand) {
                        RunCommand(i.Command);
                    } else if (i.DefinedActions == DefinedActions.VolumeDown)
                        SetVolume(IntPtr.Zero, (float)GetVolume(IntPtr.Zero) - 2);
                    else if (i.DefinedActions == DefinedActions.VolumeUp)
                        SetVolume(IntPtr.Zero, (float)GetVolume(IntPtr.Zero) + 2);
                    else if (i.DefinedActions == DefinedActions.AppSwithDown) ;
                    //RunCommand("", false);
                    else if (i.DefinedActions == DefinedActions.AppSwithUp) ;
                    //RunCommand("");
                    else if (i.DefinedActions == DefinedActions.Settings)
                        RunCommand("ms-settings:");
                    else if (i.DefinedActions == DefinedActions.ControlPanel)
                        RunCommand("control");
                }
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        private float? GetVolume(IntPtr hWnd) {
            hWnd = FindWindow("MozillaWindowClass", null);
            if (hWnd == IntPtr.Zero)
                return null;

            uint pID;
            GetWindowThreadProcessId(hWnd, out pID);
            if (pID == 0)
                return null;

            return VolumeMixer.GetApplicationVolume((int)pID);
        }

        private void SetVolume(IntPtr hWnd, float volume) {
            hWnd = FindWindow("MozillaWindowClass", null);
            if (hWnd == IntPtr.Zero)
                return;

            uint pID;
            GetWindowThreadProcessId(hWnd, out pID);
            if (pID == 0)
                return;

            VolumeMixer.SetApplicationVolume((int)pID, volume);
        }

        private void RunCommand(string command) {
            if (string.IsNullOrEmpty(command)) return;
            command = '"' + command + '"';
            string cmd = command.Substring(0, command.IndexOf(" ") > -1 ? command.IndexOf(" ") : command.Length);
            string arg = command.Substring(command.IndexOf(" ") > -1 ? command.IndexOf(" ") : command.Length);
            cmd = Environment.ExpandEnvironmentVariables(cmd);
            Process.Start(new ProcessStartInfo(cmd, arg));
        }

        private void RunCommand(string command, bool view) {
            if (string.IsNullOrEmpty(command)) return;
            string cmd = command.Substring(0, command.IndexOf(" ") > -1 ? command.IndexOf(" ") : command.Length);
            string arg = command.Substring(command.IndexOf(" ") > -1 ? command.IndexOf(" ") : command.Length);
            Process.Start(new ProcessStartInfo(cmd, arg) { CreateNoWindow = !view, UseShellExecute = view });
        }

        public Config fg { get; set; }
    }
}
