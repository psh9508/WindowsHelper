namespace WindowsHelper
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn닫기 = new System.Windows.Forms.Button();
            this.btn카카오톡정렬 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn닫기
            // 
            this.btn닫기.Location = new System.Drawing.Point(215, 292);
            this.btn닫기.Name = "btn닫기";
            this.btn닫기.Size = new System.Drawing.Size(75, 23);
            this.btn닫기.TabIndex = 0;
            this.btn닫기.Text = "닫기";
            this.btn닫기.UseVisualStyleBackColor = true;
            this.btn닫기.Click += new System.EventHandler(this.btn닫기_Click);
            // 
            // btn카카오톡정렬
            // 
            this.btn카카오톡정렬.Location = new System.Drawing.Point(68, 40);
            this.btn카카오톡정렬.Name = "btn카카오톡정렬";
            this.btn카카오톡정렬.Size = new System.Drawing.Size(162, 23);
            this.btn카카오톡정렬.TabIndex = 1;
            this.btn카카오톡정렬.Text = "카카오톡 정렬";
            this.btn카카오톡정렬.UseVisualStyleBackColor = true;
            this.btn카카오톡정렬.Click += new System.EventHandler(this.btn카카오톡정렬_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 327);
            this.ControlBox = false;
            this.Controls.Add(this.btn카카오톡정렬);
            this.Controls.Add(this.btn닫기);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "WindowsHelper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn닫기;
        private System.Windows.Forms.Button btn카카오톡정렬;
    }
}

