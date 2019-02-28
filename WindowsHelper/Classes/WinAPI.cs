using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Win32Interop.WinHandles.Internal;

namespace WindowsHelper.Classes
{
    public static class WinAPI
    {
        
        [DllImport("user32")]
        static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
        [DllImport("user32.dll")]
        static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        public const int HWND_BOTTOM = 0x1;
        public const int SWP_NOSIZE = 0x1;
        public const int SWP_NOMOVE = 0x2;
        public const int SWP_NOZORDER = 0X4;
        public const int SWP_SHOWWINDOW = 0x0040;

        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;

        public static int SetWinPos(IntPtr hWnd, IntPtr hWndInsertAfter, Location location, Size size, int flag)
        {
            return SetWindowPos(hWnd, hWndInsertAfter, location.x, location.y, size.width, size.height, flag);
        }

        public static bool GetWinRect(IntPtr hwnd, out RECT lpRect)
        {
            return GetWindowRect(hwnd, out lpRect);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    }


    public struct Location
    {
        public int x;
        public int y;
    }

    public struct Size
    {
        public int width;
        public int height;
    }
}
