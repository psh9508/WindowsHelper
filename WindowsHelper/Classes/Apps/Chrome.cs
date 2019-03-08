using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win32Interop.WinHandles;

namespace WindowsHelper.Classes.Apps
{
    public class Chrome
    {
        public const string ClassID = "Chrome_WidgetWin_1";

        public readonly Size _smallSize;

        public Chrome()
        {
            _smallSize = new Size { height = 1000, width = 300 };
        }

        public IEnumerable<WindowHandle> GetBrowserHandles()
        {
            return TopLevelWindowUtils.FindWindows(x => x.GetClassName().Contains(ClassID));
        }

        public void SetBrowserCenter(WindowHandle hWnd)
        {
            if (hWnd.IsValid)
            {
                RECT rect = new RECT();
                TopLevelWindowUtils.GetWinRect(hWnd.RawPtr, out rect);

                var mainWndWidth = rect.Right - rect.Left;
                var mainWndHeight = rect.Bottom - rect.Top;

                var location = new Location() { x = Monitor.Witdh / 2 - mainWndWidth / 2
                                              , y = Monitor.Height / 2 - mainWndHeight / 2 };
                var size = new Win32Interop.WinHandles.Size() { width = mainWndWidth, height = mainWndHeight };

                TopLevelWindowUtils.SetWinPos(hWnd.RawPtr, IntPtr.Zero, location, size, 1);
            }
        }

        public void SetBrowserSize(WindowHandle hWnd)
        {
            TopLevelWindowUtils.SetWinPos(hWnd.RawPtr, IntPtr.Zero, new Location { x = 200, y = 100 }, _smallSize, 1);
        }
    }
}
