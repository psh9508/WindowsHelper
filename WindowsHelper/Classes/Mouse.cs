using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Win32Interop.WinHandles.Internal.NativeMethods;

namespace WindowsHelper.Classes
{
    public static class Mouse
    {
        public static event EventHandler<Point> TrankingMousePos;

        private static Thread _tranker = new Thread(Tranking);

        public static void StartTranking()
        {
            _tranker.Start();
        }

        public static void StopTranking()
        {
            _tranker.Abort();
        }

        private static void Tranking()
        {
            Point pos;

            while(true)
            {
                GetCursorPos(out pos);

                TrankingMousePos?.Invoke(null, pos);
            }
        }
    }
}
