using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

            Shown += (sender, e) => {
                this.Size = new System.Drawing.Size(350, Classes.Monitor.Height);
                this.Location = new Point(0, 0);
            };

            Mouse.TrankingMousePos += (sender, pos) => {

                var uiThread = SynchronizationContext.Current;

                if (pos.X < 20)
                    ShowForm();
                else
                    new Thread(HideForm).Start();
            };
        }
       
        private void ShowForm()
        {
            //if (this.Location.X >= 150 && this.Location.X <= 360)
            //    return;

            if(this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.Location = new Point(-350, 0);

                    while (this.Location.X <= 0)
                    {
                        this.Location = new Point(this.Location.X + 1, 0);
                    }
                }));
            }
        }

        private void HideForm()
        {
            
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

        private void btn크롬_Click(object sender, EventArgs e)
        {
            var kakaoLogic = new KakaoTalk();

            var chromeLogic = new Chrome();

            var chromeHandles = chromeLogic.GetBrowserHandles();

            foreach (var item in chromeHandles)
            {
                //kakaoLogic.SetMainWindowPos(item, new RECT() { Bottom = 500, Left = 500, Right = 500, Top = 500 });
                chromeLogic.SetBrowserCenter(item);
            }
        }
    }
}
