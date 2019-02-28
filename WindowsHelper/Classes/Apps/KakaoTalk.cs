using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win32Interop.WinHandles;

namespace WindowsHelper.Classes.Apps
{
    public class KakaoTalk
    {
        public const string ClassID = "32770";
        public const string MainCaptionID = "카카오톡";


        public WindowHandle GetMainHandle()
        {
            return TopLevelWindowUtils.FindWindow(x => x.GetWindowText().Contains(MainCaptionID));
        }

        public IEnumerable<WindowHandle> GetDialogHandles()
        {
            return TopLevelWindowUtils.FindWindows(x => x.GetClassName().Contains(ClassID));
        }

        public RECT GetMainWindowRect(WindowHandle hWnd)
        {
            RECT rect = new RECT();

            if (hWnd.IsValid)
            {
                WinAPI.GetWinRect(hWnd.RawPtr, out rect);
            }

            return rect;
        }

        public void SetWinPos(WindowHandle hWnd, RECT rect)
        {
            if (hWnd.IsValid)
            {
                const int offset = 20;

                var mainWndWidth = rect.Right - rect.Left;
                var mainWndHeight = rect.Bottom - rect.Top;

                var location = new Location() { x = Monitor.Witdh - mainWndWidth - offset, y = 0 + offset };
                var size = new Classes.Size() { width = mainWndWidth, height = mainWndHeight };

                WinAPI.SetWinPos(hWnd.RawPtr, IntPtr.Zero, location, size, WinAPI.SWP_SHOWWINDOW); 
            }
        }


    }
}
