using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win32Interop.WinHandles.Internal;
using WindowsHelper.Classes;
using WindowsHelper.Properties;

namespace WindowsHelper
{
    static class Program
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static IntPtr _hookID = IntPtr.Zero;

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Mouse.StartTranking();
            _hookID = InterceptKeys.Start();

            InterceptKeys.CompleteHookingKey += Key => {
                var hookedKey = Key;
            };

            using (var noti = new NotifyIcon())
            {
                noti.Text = "My Notification";
                noti.Icon = Icon.FromHandle((Resources.Icon).GetHicon());
                noti.MouseClick += Noti_MouseClick;

                noti.ContextMenuStrip = new ContextMenuStrip();
                noti.ContextMenuStrip.Items.Add("열기", Resources.Icon, Open_Clicked);
                noti.ContextMenuStrip.Items.Add("도움말", Resources.Icon, Help_Clicked);
                noti.ContextMenuStrip.Items.Add(new ToolStripSeparator());
                noti.ContextMenuStrip.Items.Add("종료", Resources.Icon, Exit_Clicked);

                noti.Visible = true;

                Application.Run();
            }

            NativeMethods.UnhookWindowsHookEx(_hookID);
        }

        private static void Noti_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("왼쪽 버튼 클릭", "From Tray");               
            }
        }

        private static void Open_Clicked(object sender, EventArgs e)
        {
            //MessageBox.Show("열기 메뉴 클릭", "From Tray");
            var frm = new Form1();
            frm.ShowDialog();
        }

        private static void Help_Clicked(object sender, EventArgs e)
        {
            MessageBox.Show("도움말 메뉴 클릭", "From Tray");
        }

        private static void Exit_Clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
