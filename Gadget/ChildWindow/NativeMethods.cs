using System;
using System.Runtime.InteropServices;

namespace Microsoft.SDK.Samples.VistaBridge.Interop {
    public enum WM : uint {
        NULL = 0x0000,
        CREATE = 0x0001,
        DESTROY = 0x0002,
        MOVE = 0x0003,
        SIZE = 0x0005,
        ACTIVATE = 0x0006,
        SETFOCUS = 0x0007,
        KILLFOCUS = 0x0008,
        ENABLE = 0x000A,
        SETREDRAW = 0x000B,
        SETTEXT = 0x000C,
        GETTEXT = 0x000D,
        GETTEXTLENGTH = 0x000E,
        PAINT = 0x000F,
        CLOSE = 0x0010,
        QUERYENDSESSION = 0x0011,
        QUIT = 0x0012,
        QUERYOPEN = 0x0013,
        ERASEBKGND = 0x0014,
        SYSCOLORCHANGE = 0x0015,
        ENDSESSION = 0x0016,
        SHOWWINDOW = 0x0018,
        WININICHANGE = 0x001A,
        SETTINGCHANGE = 0x001A,
        DEVMODECHANGE = 0x001B,
        ACTIVATEAPP = 0x001C,
        FONTCHANGE = 0x001D,
        TIMECHANGE = 0x001E,
        CANCELMODE = 0x001F,
        SETCURSOR = 0x0020,
        MOUSEACTIVATE = 0x0021,
        CHILDACTIVATE = 0x0022,
        QUEUESYNC = 0x0023,
        GETMINMAXINFO = 0x0024,
        PAINTICON = 0x0026,
        ICONERASEBKGND = 0x0027,
        NEXTDLGCTL = 0x0028,
        SPOOLERSTATUS = 0x002A,
        DRAWITEM = 0x002B,
        MEASUREITEM = 0x002C,
        DELETEITEM = 0x002D,
        VKEYTOITEM = 0x002E,
        CHARTOITEM = 0x002F,
        SETFONT = 0x0030,
        GETFONT = 0x0031,
        SETHOTKEY = 0x0032,
        GETHOTKEY = 0x0033,
        QUERYDRAGICON = 0x0037,
        COMPAREITEM = 0x0039,
        GETOBJECT = 0x003D,
        COMPACTING = 0x0041,
        COMMNOTIFY = 0x0044,
        WINDOWPOSCHANGING = 0x0046,
        WINDOWPOSCHANGED = 0x0047,
        POWER = 0x0048,
        COPYDATA = 0x004A,
        CANCELJOURNAL = 0x004B,
        NOTIFY = 0x004E,
        INPUTLANGCHANGEREQUEST = 0x0050,
        INPUTLANGCHANGE = 0x0051,
        TCARD = 0x0052,
        HELP = 0x0053,
        USERCHANGED = 0x0054,
        NOTIFYFORMAT = 0x0055,
        CONTEXTMENU = 0x007B,
        STYLECHANGING = 0x007C,
        STYLECHANGED = 0x007D,
        DISPLAYCHANGE = 0x007E,
        GETICON = 0x007F,
        SETICON = 0x0080,
        NCCREATE = 0x0081,
        NCDESTROY = 0x0082,
        NCCALCSIZE = 0x0083,
        NCHITTEST = 0x0084,
        NCPAINT = 0x0085,
        NCACTIVATE = 0x0086,
        GETDLGCODE = 0x0087,
        SYNCPAINT = 0x0088,
        NCMOUSEMOVE = 0x00A0,
        NCLBUTTONDOWN = 0x00A1,
        NCLBUTTONUP = 0x00A2,
        NCLBUTTONDBLCLK = 0x00A3,
        NCRBUTTONDOWN = 0x00A4,
        NCRBUTTONUP = 0x00A5,
        NCRBUTTONDBLCLK = 0x00A6,
        NCMBUTTONDOWN = 0x00A7,
        NCMBUTTONUP = 0x00A8,
        NCMBUTTONDBLCLK = 0x00A9,
        KEYDOWN = 0x0100,
        KEYUP = 0x0101,
        CHAR = 0x0102,
        DEADCHAR = 0x0103,
        SYSKEYDOWN = 0x0104,
        SYSKEYUP = 0x0105,
        SYSCHAR = 0x0106,
        SYSDEADCHAR = 0x0107,
        KEYLAST = 0x0108,
        IME_STARTCOMPOSITION = 0x010D,
        IME_ENDCOMPOSITION = 0x010E,
        IME_COMPOSITION = 0x010F,
        IME_KEYLAST = 0x010F,
        INITDIALOG = 0x0110,
        COMMAND = 0x0111,
        SYSCOMMAND = 0x0112,
        TIMER = 0x0113,
        HSCROLL = 0x0114,
        VSCROLL = 0x0115,
        INITMENU = 0x0116,
        INITMENUPOPUP = 0x0117,
        MENUSELECT = 0x011F,
        MENUCHAR = 0x0120,
        ENTERIDLE = 0x0121,
        MENURBUTTONUP = 0x0122,
        MENUDRAG = 0x0123,
        MENUGETOBJECT = 0x0124,
        UNINITMENUPOPUP = 0x0125,
        MENUCOMMAND = 0x0126,
        CTLCOLORMSGBOX = 0x0132,
        CTLCOLOREDIT = 0x0133,
        CTLCOLORLISTBOX = 0x0134,
        CTLCOLORBTN = 0x0135,
        CTLCOLORDLG = 0x0136,
        CTLCOLORSCROLLBAR = 0x0137,
        CTLCOLORSTATIC = 0x0138,
        MOUSEMOVE = 0x0200,
        LBUTTONDOWN = 0x0201,
        LBUTTONUP = 0x0202,
        LBUTTONDBLCLK = 0x0203,
        RBUTTONDOWN = 0x0204,
        RBUTTONUP = 0x0205,
        RBUTTONDBLCLK = 0x0206,
        MBUTTONDOWN = 0x0207,
        MBUTTONUP = 0x0208,
        MBUTTONDBLCLK = 0x0209,
        MOUSEWHEEL = 0x020A,
        PARENTNOTIFY = 0x0210,
        ENTERMENULOOP = 0x0211,
        EXITMENULOOP = 0x0212,
        NEXTMENU = 0x0213,
        SIZING = 0x0214,
        CAPTURECHANGED = 0x0215,
        MOVING = 0x0216,
        DEVICECHANGE = 0x0219,
        MDICREATE = 0x0220,
        MDIDESTROY = 0x0221,
        MDIACTIVATE = 0x0222,
        MDIRESTORE = 0x0223,
        MDINEXT = 0x0224,
        MDIMAXIMIZE = 0x0225,
        MDITILE = 0x0226,
        MDICASCADE = 0x0227,
        MDIICONARRANGE = 0x0228,
        MDIGETACTIVE = 0x0229,
        MDISETMENU = 0x0230,
        ENTERSIZEMOVE = 0x0231,
        EXITSIZEMOVE = 0x0232,
        DROPFILES = 0x0233,
        MDIREFRESHMENU = 0x0234,
        IME_SETCONTEXT = 0x0281,
        IME_NOTIFY = 0x0282,
        IME_CONTROL = 0x0283,
        IME_COMPOSITIONFULL = 0x0284,
        IME_SELECT = 0x0285,
        IME_CHAR = 0x0286,
        IME_REQUEST = 0x0288,
        IME_KEYDOWN = 0x0290,
        IME_KEYUP = 0x0291,
        MOUSEHOVER = 0x02A1,
        MOUSELEAVE = 0x02A3,
        CUT = 0x0300,
        COPY = 0x0301,
        PASTE = 0x0302,
        CLEAR = 0x0303,
        UNDO = 0x0304,
        RENDERFORMAT = 0x0305,
        RENDERALLFORMATS = 0x0306,
        DESTROYCLIPBOARD = 0x0307,
        DRAWCLIPBOARD = 0x0308,
        PAINTCLIPBOARD = 0x0309,
        VSCROLLCLIPBOARD = 0x030A,
        SIZECLIPBOARD = 0x030B,
        ASKCBFORMATNAME = 0x030C,
        CHANGECBCHAIN = 0x030D,
        HSCROLLCLIPBOARD = 0x030E,
        QUERYNEWPALETTE = 0x030F,
        PALETTEISCHANGING = 0x0310,
        PALETTECHANGED = 0x0311,
        HOTKEY = 0x0312,
        PRINT = 0x0317,
        PRINTCLIENT = 0x0318,
        HANDHELDFIRST = 0x0358,
        HANDHELDLAST = 0x035F,
        AFXFIRST = 0x0360,
        AFXLAST = 0x037F,
        PENWINFIRST = 0x0380,
        PENWINLAST = 0x038F,
        APP = 0x8000,
        USER = 0x0400,
        DDE_INITIATE = 0x03E0,
        DDE_TERMINATE,
        DDE_ADVISE,
        DDE_UNADVISE,
        DDE_ACK,
        DDE_DATA,
        DDE_REQUEST,
        DDE_POKE,
        DDE_EXECUTE
    }
    internal static class NativeMethods {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetClassLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr LoadImage(IntPtr hWnd, IntPtr idi, int type, int cx, int cy, int fuLoad);

        #region General Definitions

        // Various helper constants
        internal static IntPtr NO_PARENT = IntPtr.Zero;

        // Various important window messages
        internal const int USER = 0x0400;
        internal const int ENTERIDLE = 0x0121;

        // FormatMessage constants and structs
        internal const int FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;

        #endregion

        #region TaskDialog Definitions

        // Main task dialog configuration struct
        // NOTE: Packing must be set to 4 to make this work on 64-bit platforms
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        internal class TASKDIALOGCONFIG {
            internal uint cbSize;
            internal IntPtr hwndParent;
            internal IntPtr hInstance;
            internal TASKDIALOG_FLAGS dwFlags;
            internal TASKDIALOG_COMMON_BUTTON_FLAGS dwCommonButtons;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszWindowTitle;
            internal TASKDIALOGCONFIG_ICON_UNION MainIcon; // NOTE: 32-bit union field, holds pszMainIcon as well
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszMainInstruction;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszContent;
            internal uint cButtons;
            internal IntPtr pButtons;           // Ptr to TASKDIALOG_BUTTON structs
            //[MarshalAs(UnmanagedType.ByValArray, SizeConst=5)] internal NativeMethods.TASKDIALOG_BUTTON[] pButtons;
            internal int nDefaultButton;
            internal uint cRadioButtons;
            internal IntPtr pRadioButtons;      // Ptr to TASKDIALOG_BUTTON structs
            internal int nDefaultRadioButton;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszVerificationText;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszExpandedInformation;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszExpandedControlText;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszCollapsedControlText;
            internal TASKDIALOGCONFIG_ICON_UNION FooterIcon;  // NOTE: 32-bit union field, holds pszFooterIcon as well
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszFooter;
            internal PFTASKDIALOGCALLBACK pfCallback;
            internal IntPtr lpCallbackData;
            internal uint cxWidth;
        }

        internal const int TASKDIALOG_IDEALWIDTH = 0;  // Value for TASKDIALOGCONFIG.cxWidth
        internal const int TASKDIALOG_BUTTON_SHIELD_ICON = 1;

        // NOTE: We include a "spacer" so that the struct size varies on 
        // 64-bit architectures
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
        internal struct TASKDIALOGCONFIG_ICON_UNION {
            // TODO: getting TypeLoadException if this is a true string/int union
            //internal TASKDIALOGCONFIG_ICON_UNION(string s) 
            //{
            //    hMainIcon = 0;
            //    pszMainIcon = s; 
            //}   

            internal TASKDIALOGCONFIG_ICON_UNION(int i) {
                spacer = IntPtr.Zero;
                pszIcon = 0;
                hMainIcon = i;
            }

            [FieldOffset(0)]
            internal int hMainIcon;
            [FieldOffset(0)]
            internal int pszIcon;
            [FieldOffset(0)]
            internal IntPtr spacer;
        }

        // NOTE: Packing must be set to 4 to make this work on 64-bit platforms
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        internal struct TASKDIALOG_BUTTON {
            public TASKDIALOG_BUTTON(int n, string txt) {
                nButtonID = n;
                pszButtonText = txt;
            }

            internal int nButtonID;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszButtonText;
        }

        // Task Dialog - identifies common buttons
        [Flags]
        internal enum TASKDIALOG_COMMON_BUTTON_FLAGS {
            TDCBF_OK_BUTTON = 0x0001, // selected control return value IDOK
            TDCBF_YES_BUTTON = 0x0002, // selected control return value IDYES
            TDCBF_NO_BUTTON = 0x0004, // selected control return value IDNO
            TDCBF_CANCEL_BUTTON = 0x0008, // selected control return value IDCANCEL
            TDCBF_RETRY_BUTTON = 0x0010, // selected control return value IDRETRY
            TDCBF_CLOSE_BUTTON = 0x0020  // selected control return value IDCLOSE
        }

        // Identify button *return values* - note that, unfortunately, these are different
        // from the inbound button values
        internal enum TASKDIALOG_COMMON_BUTTON_RETURN_ID {
            IDOK = 1,
            IDCANCEL = 2,
            IDABORT = 3,
            IDRETRY = 4,
            IDIGNORE = 5,
            IDYES = 6,
            IDNO = 7,
            IDCLOSE = 8
        }

        internal enum TASKDIALOG_ELEMENTS {
            TDE_CONTENT,
            TDE_EXPANDED_INFORMATION,
            TDE_FOOTER,
            TDE_MAIN_INSTRUCTION
        }

        internal enum TASKDIALOG_ICON_ELEMENT {
            TDIE_ICON_MAIN,
            TDIE_ICON_FOOTER
        }

        // Task Dialog - flags
        [Flags]
        internal enum TASKDIALOG_FLAGS {
            NONE = 0,
            TDF_ENABLE_HYPERLINKS = 0x0001,
            TDF_USE_HICON_MAIN = 0x0002,
            TDF_USE_HICON_FOOTER = 0x0004,
            TDF_ALLOW_DIALOG_CANCELLATION = 0x0008,
            TDF_USE_COMMAND_LINKS = 0x0010,
            TDF_USE_COMMAND_LINKS_NO_ICON = 0x0020,
            TDF_EXPAND_FOOTER_AREA = 0x0040,
            TDF_EXPANDED_BY_DEFAULT = 0x0080,
            TDF_VERIFICATION_FLAG_CHECKED = 0x0100,
            TDF_SHOW_PROGRESS_BAR = 0x0200,
            TDF_SHOW_MARQUEE_PROGRESS_BAR = 0x0400,
            TDF_CALLBACK_TIMER = 0x0800,
            TDF_POSITION_RELATIVE_TO_WINDOW = 0x1000,
            TDF_RTL_LAYOUT = 0x2000,
            TDF_NO_DEFAULT_RADIO_BUTTON = 0x4000
        }

        internal enum TASKDIALOG_MESSAGES {
            TDM_NAVIGATE_PAGE = USER + 101,
            TDM_CLICK_BUTTON = USER + 102, // wParam = Button ID
            TDM_SET_MARQUEE_PROGRESS_BAR = USER + 103, // wParam = 0 (nonMarque) wParam != 0 (Marquee)
            TDM_SET_PROGRESS_BAR_STATE = USER + 104, // wParam = new progress state
            TDM_SET_PROGRESS_BAR_RANGE = USER + 105, // lParam = MAKELPARAM(nMinRange, nMaxRange)
            TDM_SET_PROGRESS_BAR_POS = USER + 106, // wParam = new position
            TDM_SET_PROGRESS_BAR_MARQUEE = USER + 107, // wParam = 0 (stop marquee), wParam != 0 (start marquee), lparam = speed (milliseconds between repaints)
            TDM_SET_ELEMENT_TEXT = USER + 108, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
            TDM_CLICK_RADIO_BUTTON = USER + 110, // wParam = Radio Button ID
            TDM_ENABLE_BUTTON = USER + 111, // lParam = 0 (disable), lParam != 0 (enable), wParam = Button ID
            TDM_ENABLE_RADIO_BUTTON = USER + 112, // lParam = 0 (disable), lParam != 0 (enable), wParam = Radio Button ID
            TDM_CLICK_VERIFICATION = USER + 113, // wParam = 0 (unchecked), 1 (checked), lParam = 1 (set key focus)
            TDM_UPDATE_ELEMENT_TEXT = USER + 114, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
            TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE = USER + 115, // wParam = Button ID, lParam = 0 (elevation not required), lParam != 0 (elevation required)
            TDM_UPDATE_ICON = USER + 116  // wParam = icon element (TASKDIALOG_ICON_ELEMENTS), lParam = new icon (hIcon if TDF_USE_HICON_* was set, PCWSTR otherwise)
        }

        internal enum TASKDIALOG_NOTIFICATIONS {
            TDN_CREATED = 0,
            TDN_NAVIGATED = 1,
            TDN_BUTTON_CLICKED = 2,            // wParam = Button ID
            TDN_HYPERLINK_CLICKED = 3,         // lParam = (LPCWSTR)pszHREF
            TDN_TIMER = 4,                     // wParam = Milliseconds since dialog created or timer reset
            TDN_DESTROYED = 5,
            TDN_RADIO_BUTTON_CLICKED = 6,      // wParam = Radio Button ID
            TDN_DIALOG_CONSTRUCTED = 7,
            TDN_VERIFICATION_CLICKED = 8,      // wParam = 1 if checkbox checked, 0 if not, lParam is unused and always 0
            TDN_HELP = 9,
            TDN_EXPANDO_BUTTON_CLICKED = 10    // wParam = 0 (dialog is now collapsed), wParam != 0 (dialog is now expanded)
        }

        // Used in the various SET_DEFAULT* TaskDialog messages
        internal const int NO_DEFAULT_BUTTON_SPECIFIED = 0;

        // Task Dialog config and related structs (for TaskDialogIndirect())
        internal delegate int PFTASKDIALOGCALLBACK(
            IntPtr hwnd,
            uint msg,
            IntPtr wParam,
            IntPtr lParam,
            IntPtr lpRefData);

        internal enum PBST {
            PBST_NORMAL = 0x0001,
            PBST_ERROR = 0x0002,
            PBST_PAUSED = 0x0003
        }

        internal enum TD_ICON {
            TD_WARNING_ICON = 65535,
            TD_ERROR_ICON = 65534,
            TD_INFORMATION_ICON = 65533,
            TD_SHIELD_ICON = 65532
        }

        #endregion

        #region File Operations Definitions

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class OpenFileName {
            internal int structSize;
            internal IntPtr owner;
            internal IntPtr instance;
            internal string filter;
            internal string customFilter;
            internal int maxCustFilter;
            internal int filterIndex;
            internal string file;
            internal int maxFile;
            internal string fileTitle;

            internal int maxFileTitle;
            internal string initialDir;
            internal string title;
            internal Int16 flags;
            internal Int16 fileOffset;
            internal int fileExtension;
            internal string defExt;
            internal IntPtr custData;
            internal IntPtr hook;
            internal string templateName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        internal struct COMDLG_FILTERSPEC {
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszName;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszSpec;
        }

        internal enum FDAP {
            FDAP_BOTTOM = 0x00000000,
            FDAP_TOP = 0x00000001,
        }

        internal enum FDE_SHAREVIOLATION_RESPONSE {
            FDESVR_DEFAULT = 0x00000000,
            FDESVR_ACCEPT = 0x00000001,
            FDESVR_REFUSE = 0x00000002
        }

        internal enum FDE_OVERWRITE_RESPONSE {
            FDEOR_DEFAULT = 0x00000000,
            FDEOR_ACCEPT = 0x00000001,
            FDEOR_REFUSE = 0x00000002
        }

        internal enum SIATTRIBFLAGS {
            SIATTRIBFLAGS_AND = 0x00000001, // if multiple items and the attirbutes together.
            SIATTRIBFLAGS_OR = 0x00000002, // if multiple items or the attributes together.
            SIATTRIBFLAGS_APPCOMPAT = 0x00000003, // Call GetAttributes directly on the ShellFolder for multiple attributes
        }

        internal enum SIGDN : uint {
            SIGDN_NORMALDISPLAY = 0x00000000,           // SHGDN_NORMAL
            SIGDN_PARENTRELATIVEPARSING = 0x80018001,   // SHGDN_INFOLDER | SHGDN_FORPARSING
            SIGDN_DESKTOPABSOLUTEPARSING = 0x80028000,  // SHGDN_FORPARSING
            SIGDN_PARENTRELATIVEEDITING = 0x80031001,   // SHGDN_INFOLDER | SHGDN_FOREDITING
            SIGDN_DESKTOPABSOLUTEEDITING = 0x8004c000,  // SHGDN_FORPARSING | SHGDN_FORADDRESSBAR
            SIGDN_FILESYSPATH = 0x80058000,             // SHGDN_FORPARSING
            SIGDN_URL = 0x80068000,                     // SHGDN_FORPARSING
            SIGDN_PARENTRELATIVEFORADDRESSBAR = 0x8007c001,     // SHGDN_INFOLDER | SHGDN_FORPARSING | SHGDN_FORADDRESSBAR
            SIGDN_PARENTRELATIVE = 0x80080001           // SHGDN_INFOLDER
        }

        [Flags]
        internal enum FOS : uint {
            FOS_OVERWRITEPROMPT = 0x00000002,
            FOS_STRICTFILETYPES = 0x00000004,
            FOS_NOCHANGEDIR = 0x00000008,
            FOS_PICKFOLDERS = 0x00000020,
            FOS_FORCEFILESYSTEM = 0x00000040, // Ensure that items returned are filesystem items.
            FOS_ALLNONSTORAGEITEMS = 0x00000080, // Allow choosing items that have no storage.
            FOS_NOVALIDATE = 0x00000100,
            FOS_ALLOWMULTISELECT = 0x00000200,
            FOS_PATHMUSTEXIST = 0x00000800,
            FOS_FILEMUSTEXIST = 0x00001000,
            FOS_CREATEPROMPT = 0x00002000,
            FOS_SHAREAWARE = 0x00004000,
            FOS_NOREADONLYRETURN = 0x00008000,
            FOS_NOTESTFILECREATE = 0x00010000,
            FOS_HIDEMRUPLACES = 0x00020000,
            FOS_HIDEPINNEDPLACES = 0x00040000,
            FOS_NODEREFERENCELINKS = 0x00100000,
            FOS_DONTADDTORECENT = 0x02000000,
            FOS_FORCESHOWHIDDEN = 0x10000000,
            FOS_DEFAULTNOMINIMODE = 0x20000000
        }

        internal enum CDCONTROLSTATE {
            CDCS_INACTIVE = 0x00000000,
            CDCS_ENABLED = 0x00000001,
            CDCS_VISIBLE = 0x00000002
        }

        #endregion

        #region KnownFolder Definitions

        internal enum FFFP_MODE {
            FFFP_EXACTMATCH,
            FFFP_NEARESTPARENTMATCH
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        internal struct KNOWNFOLDER_DEFINITION {
            internal NativeMethods.KF_CATEGORY category;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszName;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszCreator;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszDescription;
            internal Guid fidParent;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszRelativePath;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszParsingName;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszToolTip;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszLocalizedName;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszIcon;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string pszSecurity;
            internal uint dwAttributes;
            internal NativeMethods.KF_DEFINITION_FLAGS kfdFlags;
            internal Guid ftidType;
        }

        internal enum KF_CATEGORY {
            KF_CATEGORY_VIRTUAL = 0x00000001,
            KF_CATEGORY_FIXED = 0x00000002,
            KF_CATEGORY_COMMON = 0x00000003,
            KF_CATEGORY_PERUSER = 0x00000004
        }

        [Flags]
        internal enum KF_DEFINITION_FLAGS {
            KFDF_PERSONALIZE = 0x00000001,
            KFDF_LOCAL_REDIRECT_ONLY = 0x00000002,
            KFDF_ROAMABLE = 0x00000004,
        }


        // Property System structs and consts
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        internal struct PROPERTYKEY {
            internal Guid fmtid;
            internal uint pid;
        }

        #endregion

        #region Activation Context Definitions

        [Flags]
        internal enum ACTCTXFlags {
            ACTCTX_FLAG_PROCESSOR_ARCHITECTURE_VALID = 0x00000001,
            ACTCTX_FLAG_LANGID_VALID = 0x00000002,
            ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID = 0x00000004,
            ACTCTX_FLAG_RESOURCE_NAME_VALID = 0x00000008,
            ACTCTX_FLAG_SET_PROCESS_DEFAULT = 0x00000010,
            ACTCTX_FLAG_APPLICATION_NAME_VALID = 0x00000020,
            ACTCTX_FLAG_SOURCE_IS_ASSEMBLYREF = 0x00000040,
            ACTCTX_FLAG_HMODULE_VALID = 0x00000080,
            ACTCTX_FLAG_OVERRIDEMANIFEST_VALID = 0x00000100,
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        internal struct ACTCTXW {
            internal uint cbSize;
            internal int dwFlags;
            internal string lpSource;
            internal uint wProcessorArchitecture;
            internal int wLangId;
            internal string lpAssemblyDirectory;
            internal int lpResourceName;
            internal string lpApplicationName;
            internal IntPtr hModule;
            internal IntPtr OverrideManifest;
        }

        #endregion

        #region Elevation COM Object

        [Flags]
        internal enum CLSCTX {
            CLSCTX_INPROC_SERVER = 0x1,
            CLSCTX_INPROC_HANDLER = 0x2,
            CLSCTX_LOCAL_SERVER = 0x4,
            CLSCTX_REMOTE_SERVER = 0x10,
            CLSCTX_NO_CODE_DOWNLOAD = 0x400,
            CLSCTX_NO_CUSTOM_MARSHAL = 0x1000,
            CLSCTX_ENABLE_CODE_DOWNLOAD = 0x2000,
            CLSCTX_NO_FAILURE_LOG = 0x4000,
            CLSCTX_DISABLE_AAA = 0x8000,
            CLSCTX_ENABLE_AAA = 0x10000,
            CLSCTX_FROM_DEFAULT_CONTEXT = 0x20000,
            CLSCTX_INPROC = CLSCTX_INPROC_SERVER | CLSCTX_INPROC_HANDLER,
            CLSCTX_SERVER = CLSCTX_INPROC_SERVER | CLSCTX_LOCAL_SERVER | CLSCTX_REMOTE_SERVER,
            CLSCTX_ALL = CLSCTX_SERVER | CLSCTX_INPROC_HANDLER
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct BIND_OPTS3 {
            internal uint cbStruct;
            internal uint grfFlags;
            internal uint grfMode;
            internal uint dwTickCountDeadline;
            internal uint dwTrackFlags;
            internal uint dwClassContext;
            internal uint locale;
            object pServerInfo; // will be passing null, so type doesn't matter
            internal IntPtr hwnd;
        }

        #endregion

        #region Command Link Definitions

        internal const int BS_COMMANDLINK = 0x0000000E;
        internal const uint BCM_SETNOTE = 0x00001609;
        internal const uint BCM_GETNOTE = 0x0000160A;
        internal const uint BCM_GETNOTELENGTH = 0x0000160B;
        internal const uint BCM_SETSHIELD = 0x0000160C;

        #endregion

        #region GDI and DWM Definitions

        [StructLayout(LayoutKind.Sequential)]
        public struct SIZE {
            public int cx;
            public int cy;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT {
            internal int left;
            internal int top;
            internal int right;
            internal int bottom;
        };


        [StructLayout(LayoutKind.Sequential)]
        internal struct DTHUMBNAIL_PROPERTIES {
            internal int dwFlags;
            internal NativeMethods.RECT rcDestination;
            internal NativeMethods.RECT rcSource;
            internal byte opacity;
            internal bool fVisible;
            internal bool fSourceClientAreaOnly;
        };


        internal const int DWMNCRP_USEWINDOWSTYLE = 0;  // Enable/disable non-client rendering based on window style
        internal const int DWMNCRP_DISABLED = 1;        // Disabled non-client rendering; window style is ignored
        internal const int DWMNCRP_ENABLED = 2;         // Enabled non-client rendering; window style is ignored

        internal const int DWMWA_NCRENDERING_ENABLED = 1;       // Enable/disable non-client rendering Use DWMNCRP_* values
        internal const int DWMWA_NCRENDERING_POLICY = 2;        // Non-client rendering policy
        internal const int DWMWA_TRANSITIONS_FORCEDISABLED = 3; // Potentially enable/forcibly disable transitions 0 or 1

        [StructLayout(LayoutKind.Sequential)]
        internal struct UNSIGNED_RATIO {
            internal UInt32 uiNumerator;
            internal UInt32 uiDenominator;
        };

        [StructLayout(LayoutKind.Sequential)]
        internal struct DPRESENT_PARAMETERS {
            internal int cbSize;
            internal bool fQueue;
            internal UInt64 cRefreshStart;
            internal uint cBuffer;
            internal bool fUseSourceRate;
            internal UNSIGNED_RATIO uiNumerator;
        };


        [StructLayout(LayoutKind.Explicit)]
        internal struct DTIMING_INFO {
            [FieldOffset(0)]
            internal UInt32 cbSize;
            [FieldOffset(4)]
            internal UNSIGNED_RATIO rateRefresh;// Monitor refresh rate
            [FieldOffset(12)]
            internal UNSIGNED_RATIO rateCompose;// composition rate     
            [FieldOffset(20)]
            internal UInt64 qpcVBlank;          // QPC time at VBlank
            [FieldOffset(28)]
            internal UInt64 cRefresh;           // DWM refresh counter
            [FieldOffset(36)]
            internal UInt64 qpcCompose;         // QPC time at a compose time
            [FieldOffset(44)]
            internal UInt64 cFrame;             // Frame number that was composed at qpcCompose
            [FieldOffset(52)]
            internal UInt64 cRefreshFrame;      // Refresh count of the frame that was composed at qpcCompose
            [FieldOffset(60)]
            internal UInt64 cRefreshConfirmed;  // The target refresh count of the last
            // frame confirmed completed by the GPU
            [FieldOffset(68)]
            internal UInt32 cFlipsOutstanding;  // the number of outstanding flips

            //
            // Feedback on previous performance only valid on 2nd and subsequent calls
            //
            [FieldOffset(72)]
            internal UInt64 cFrameCurrent;      // Last frame displayed
            [FieldOffset(80)]
            internal UInt64 cFramesAvailable;   // number of frames available but not displayed, used or dropped
            [FieldOffset(88)]
            internal UInt64 cFrameCleared;      // Source frame number when the following statistics where last cleared
            [FieldOffset(96)]
            internal UInt64 cFramesReceived;    // number of new frames received
            [FieldOffset(104)]
            internal UInt64 cFramesDisplayed;   // number of unique frames displayed
            [FieldOffset(112)]
            internal UInt64 cFramesDropped;     // number of rendered frames that wer  never
            [FieldOffset(120)]                // displayed because composition occured too late
            internal UInt64 cFramesMissed;      // number of times an old frame was composed 
            // when a new frame should have been used
            // but was not available
        };


        internal const int DBB_ENABLE = 0x00000001;  // fEnable has been specified
        internal const int DBB_BLURREGION = 0x00000002;  // hRgnBlur has been specified
        internal const int DBB_TRANSITIONONMAXIMIZED = 0x00000004;  // fTransitionOnMaximized has been specified

        [StructLayout(LayoutKind.Sequential)]
        internal struct DBLURBEHIND {
            public int dwFlags;
            public bool fEnable;
            public IntPtr hRgnBlur;
            public bool fTransitionOnMaximized;
        };

        [StructLayout(LayoutKind.Sequential)]
        internal struct MARGINS {
            public int cxLeftWidth;      // width of left border that retains its size
            public int cxRightWidth;     // width of right border that retains its size
            public int cyTopHeight;      // height of top border that retains its size
            public int cyBottomHeight;   // height of bottom border that retains its size
        };


        #endregion
    }

}

