using GongSolutions.Shell.Interop;
using RenameWPF;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace Microsoft.SDK.Samples.VistaBridge.Interop {
    internal static class UnsafeNativeMethods {
        [DllImport("kernel32.dll", SetLastError = true, ThrowOnUnmappableChar = true, BestFitMapping = false)]
        internal static extern SafeLibraryHandle LoadLibrary(string fileName);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteObject(IntPtr graphicsObjectHandle);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern SafeHandle LoadString(SafeHandle hInstance, uint id, StringBuilder lpBuffer, int cchBufferMax);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int LoadString(SafeLibraryHandle hInstance, uint id, StringBuilder lpBuffer, int cchBufferMax);


        [DllImport(ExternDll.ComDlg32, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool GetOpenFileName([In, Out] NativeMethods.OpenFileName ofn);

        // TODO: Do we want to remove this?
        [DllImport(ExternDll.ComCtl32, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern void TaskDialog(
            IntPtr hwndParent,
            IntPtr hInstance,
            string pszWindowtitle,
            string pszMainInstruction,
            string pszContent,
            NativeMethods.TASKDIALOG_COMMON_BUTTON_FLAGS dwCommonButtons,
            string pszIcon,
            [In, Out] ref int pnButton);

        [DllImport(ExternDll.ComCtl32, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern HRESULT TaskDialogIndirect(
            [In] NativeMethods.TASKDIALOGCONFIG pTaskConfig,
            [Out] out int pnButton,
            [Out] out int pnRadioButton,
            [Out] out bool pVerificationFlagChecked);


        // Various overloads of SendMessage
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int SendMessage(
            IntPtr hWnd,
            uint msg,
            IntPtr wParam,
            IntPtr lParam
        );

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int SendMessage(
            IntPtr hWnd,
            uint msg,
            int wParam,
            bool lParam
        );

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int SendMessage(
           IntPtr hWnd, uint Msg,
           int wParam, string lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int SendMessage(
          IntPtr hWnd, uint Msg,
          ref int wParam, StringBuilder lParam);




        //// Various helpers for forcing binding to proper version of Comctl32 (v6)
        //[DllImport(ExternDll.Kernel32, SetLastError = true)]
        //internal static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport(ExternDll.Kernel32, SetLastError = true)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport(ExternDll.Kernel32, SetLastError = true)]
        internal static extern IntPtr CreateActCtx([In] ref NativeMethods.ACTCTXW pActCtx);

        [DllImport(ExternDll.Kernel32, SetLastError = true)]
        internal static extern bool ActivateActCtx(
            [In, Out]ref NativeMethods.ACTCTXW pActCtx,
            [In, Out] ref IntPtr lpCookie);

        [DllImport(ExternDll.Kernel32, SetLastError = true)]
        internal static extern IntPtr DeactivateActCtx(
            int dwFlags,
            IntPtr ulCookie);

        [DllImport("ole32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        internal static extern object CoGetObject(
           string pszName,
           [In] ref NativeMethods.BIND_OPTS3 pBindOptions,
           [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

        #region Various GDI Functions

        [DllImport("user32.dll")]
        internal static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern void ReleaseDC(IntPtr hWnd, IntPtr hdc);

        [DllImport("user32.dll")]
        internal static extern int DrawCaption(
        IntPtr hwnd,    // handle to window
        IntPtr hdc,      // handle to device context
        ref NativeMethods.RECT lprc, // rectangle to draw into
         int uFlags   // drawing options
        );

        [DllImport("user32.dll")]
        internal static extern int GetClientRect(
            IntPtr hwnd,
            ref NativeMethods.RECT rect);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateRectRgn(
            int left,
            int top,
            int right,
            int bottom);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int widthOfEllipse,   // width of the ellipse used to create the rounded corners
            int heightOfEllipse);

        [DllImport("user32.dll")]
        internal static extern int SetWindowRgn(
            IntPtr hwnd,
            IntPtr hrgn,
            bool redrawWindow);

        #endregion

        #region DWM APIs

        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_THUMBNAIL_PROPERTIES {
            public int dwFlags;
            public Rect rcDestination;
            public Rect rcSource;
            public byte opacity;
            public bool fVisible;
            public bool fSourceClientAreaOnly;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_PRESENT_PARAMETERS {
            public int cbSize;
            public bool fQueue;
            public UInt64 cRefreshStart;
            public uint cBuffer;
            public bool fUseSourceRate;
            public Microsoft.SDK.Samples.VistaBridge.Interop.NativeMethods.UNSIGNED_RATIO uiNumerator;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_BLURBEHIND {
            public int dwFlags;
            public bool fEnable;
            public IntPtr hRgnBlur;
            public bool fTransitionOnMaximized;
        };

        //
        //  Composition
        //
        [DllImport("DwmApi.dll")]
        internal static extern int DwmEnableComposition(
            bool fEnabled);

        [DllImport("DwmApi.dll")]
        internal static extern int DwmIsCompositionEnabled(
            ref bool fEnabled);

        [DllImport("DwmApi.dll")]
        internal static extern int DwmRegisterThumbnail(
            IntPtr hwndDestination,
            IntPtr hwndSource,
            ref NativeMethods.SIZE minimizedSize,
            ref IntPtr hThumbnailId);

        [DllImport("DwmApi.dll")]
        internal static extern int DwmUnregisterThumbnail(
            IntPtr hThumbnailId);

        [DllImport("DwmApi.dll")]
        internal static extern int DwmUpdateThumbnailProperties(
            IntPtr hThumbnailId,
            ref DWM_THUMBNAIL_PROPERTIES tp);

        [DllImport("DwmApi.dll")]
        internal static extern int DwmQueryThumbnailSourceSize(
            IntPtr hThumbnailId,
            ref NativeMethods.SIZE size);

        [DllImport("DwmApi.dll")]
        internal static extern int DwmSetWindowAttribute(
            IntPtr hwnd,
            uint dwAttributeToSet, //DWMWA_* values
            IntPtr pvAttributeValue,
            uint cbAttribute);

        [DllImport("DwmApi.dll")]
        internal static extern int DwmGetWindowAttribute(
            IntPtr hwnd,
            uint dwAttributeToGet, //DWMWA_* values
            IntPtr pvAttributeValue,
            uint cbAttribute);

        [DllImport("DwmApi.dll")]
        public static extern int DwmSetPresentParameters(
            IntPtr hwnd,
            ref DWM_PRESENT_PARAMETERS pPresentParams);

        [DllImport("DwmApi.dll")]
        internal static extern int DwmSetDxFrameDuration(
            IntPtr hwnd,
            int refreshes);

        [DllImport("DwmApi.dll")]
        internal static extern int DwmModifyPreviousDxFrameDuration(
            IntPtr hwnd,
            int refreshes,
            bool fRelative);

        [DllImport("DwmApi.dll")]
        internal static extern int DwmGetCompositionTimingInfo(
            IntPtr hwnd,
            IntPtr timingInfo);

        [DllImport("DwmApi.dll")]
        internal static extern int DwmEnableMMCSS(
            bool fEnableMMCSS);


        [DllImport("DwmApi.dll")]
        internal static extern int DwmEnableBlurBehindWindow(
            IntPtr hwnd,
            ref DWM_BLURBEHIND bb);

        [DllImport("DwmApi.dll")]
        internal static extern int DwmExtendFrameIntoClientArea(
            IntPtr hwnd,
            ref NativeMethods.MARGINS m);

        [DllImport("DwmApi.dll")]
        internal static extern int DwmGetColorizationColor(
            ref int color);


        #endregion
    }
}
