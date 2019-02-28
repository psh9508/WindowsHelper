using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win32Interop.WinHandles;
using WindowsHelper.Classes;
using WindowsHelper.Classes.Apps;
using WindowsHelper.Classes.Helper;

namespace WindowsHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn카카오톡정렬_Click(object sender, EventArgs e)
        {
            var kakaoLogic = new KakaoTalk();

            var mainHandle = kakaoLogic.GetMainHandle();

            var rect = kakaoLogic.GetMainWindowRect(mainHandle);
            kakaoLogic.SetMainWindowPos(mainHandle, rect);

            var dialogWnds = kakaoLogic.GetDialogHandles();

            if (dialogWnds.Count() > 0)
            {
                foreach (var dialogWnd in dialogWnds)
                {
                    kakaoLogic.SetDialogPos(dialogWnd);
                    TopLevelWindowUtils.BringOnTop(dialogWnd);
                }
            }
        }

        private void btn닫기_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
