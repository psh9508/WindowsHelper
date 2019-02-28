using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Classes
{
    public static class Monitor
    {
        public static int Witdh { get { return Screen.PrimaryScreen.Bounds.Width; } }
        public static int Height { get { return Screen.PrimaryScreen.Bounds.Height; } }
    }
}
