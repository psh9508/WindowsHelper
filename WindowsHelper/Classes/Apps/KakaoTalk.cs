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
        public readonly Size _kingSize;
        public readonly Size _middleSize;
        public readonly Size _smallSize;

        public KakaoTalk()
        {
            _kingSize = new Size { height = 1000, width = 300 };
            _middleSize = new Size { height = 800, width = 300 };
            _smallSize = new Size { height = 500, width = 300 };
        }

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
                TopLevelWindowUtils.GetWinRect(hWnd.RawPtr, out rect);
            }

            return rect;
        }

        public void SetMainWindowPos(WindowHandle hWnd, RECT rect)
        {
            if (hWnd.IsValid)
            {
                const int offset = 20;

                var mainWndWidth = rect.Right - rect.Left;
                var mainWndHeight = rect.Bottom - rect.Top;

                var location = new Location() { x = Monitor.Witdh - mainWndWidth - offset, y = 0 + offset };
                var size = new Win32Interop.WinHandles.Size() { width = mainWndWidth, height = mainWndHeight };

                TopLevelWindowUtils.SetWinPos(hWnd.RawPtr, IntPtr.Zero, location, size, 1); 
            }
        }

        public void SetDialogPos(WindowHandle hWnd)
        {
            var rect = GetMainWindowRect(hWnd);

            //var location = new Location() { x = rect.Left, y = rect.Top };
            var location = new Location() { x = 0, y = 0 };

            TopLevelWindowUtils.SetWinPos(hWnd.RawPtr, IntPtr.Zero, location, _kingSize, 1);
        }

    }
}
