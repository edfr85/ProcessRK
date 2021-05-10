
namespace PRM.UC
{
    partial class ucCon
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.KillTitle = new System.Windows.Forms.Button();
            this.RunTitle = new System.Windows.Forms.Button();
            this.LogTitle = new System.Windows.Forms.Button();
            this.AddKillListBtn = new System.Windows.Forms.Button();
            this.DelKillListBtn = new System.Windows.Forms.Button();
            this.AddRunListBtn = new System.Windows.Forms.Button();
            this.DelRunListBtn = new System.Windows.Forms.Button();
            this.KillTitmerBtn = new System.Windows.Forms.Button();
            this.LogLv = new System.Windows.Forms.ListView();
            this.RunNamecol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // KillTitle
            // 
            this.KillTitle.Location = new System.Drawing.Point(3, 3);
            this.KillTitle.Name = "KillTitle";
            this.KillTitle.Size = new System.Drawing.Size(211, 37);
            this.KillTitle.TabIndex = 0;
            this.KillTitle.Text = "Kill Process";
            this.KillTitle.UseVisualStyleBackColor = true;
            // 
            // RunTitle
            // 
            this.RunTitle.Location = new System.Drawing.Point(251, 3);
            this.RunTitle.Name = "RunTitle";
            this.RunTitle.Size = new System.Drawing.Size(211, 37);
            this.RunTitle.TabIndex = 1;
            this.RunTitle.Text = "Run Process";
            this.RunTitle.UseVisualStyleBackColor = true;
            // 
            // LogTitle
            // 
            this.LogTitle.Location = new System.Drawing.Point(499, 3);
            this.LogTitle.Name = "LogTitle";
            this.LogTitle.Size = new System.Drawing.Size(211, 37);
            this.LogTitle.TabIndex = 2;
            this.LogTitle.Text = "Log";
            this.LogTitle.UseVisualStyleBackColor = true;
            // 
            // AddKillListBtn
            // 
            this.AddKillListBtn.Location = new System.Drawing.Point(3, 363);
            this.AddKillListBtn.Name = "AddKillListBtn";
            this.AddKillListBtn.Size = new System.Drawing.Size(104, 37);
            this.AddKillListBtn.TabIndex = 3;
            this.AddKillListBtn.Text = "추가";
            this.AddKillListBtn.UseVisualStyleBackColor = true;
            this.AddKillListBtn.Click += new System.EventHandler(this.AddKillListBtn_Click);
            // 
            // DelKillListBtn
            // 
            this.DelKillListBtn.Location = new System.Drawing.Point(110, 363);
            this.DelKillListBtn.Name = "DelKillListBtn";
            this.DelKillListBtn.Size = new System.Drawing.Size(104, 37);
            this.DelKillListBtn.TabIndex = 5;
            this.DelKillListBtn.Text = "삭제";
            this.DelKillListBtn.UseVisualStyleBackColor = true;
            this.DelKillListBtn.Click += new System.EventHandler(this.DelKillListBtn_Click);
            // 
            // AddRunListBtn
            // 
            this.AddRunListBtn.Location = new System.Drawing.Point(251, 363);
            this.AddRunListBtn.Name = "AddRunListBtn";
            this.AddRunListBtn.Size = new System.Drawing.Size(104, 37);
            this.AddRunListBtn.TabIndex = 7;
            this.AddRunListBtn.Text = "추가";
            this.AddRunListBtn.UseVisualStyleBackColor = true;
            this.AddRunListBtn.Click += new System.EventHandler(this.AddRunListBtn_Click);
            // 
            // DelRunListBtn
            // 
            this.DelRunListBtn.Location = new System.Drawing.Point(361, 363);
            this.DelRunListBtn.Name = "DelRunListBtn";
            this.DelRunListBtn.Size = new System.Drawing.Size(104, 37);
            this.DelRunListBtn.TabIndex = 6;
            this.DelRunListBtn.Text = "삭제";
            this.DelRunListBtn.UseVisualStyleBackColor = true;
            this.DelRunListBtn.Click += new System.EventHandler(this.DelRunListBtn_Click);
            // 
            // KillTitmerBtn
            // 
            this.KillTitmerBtn.Location = new System.Drawing.Point(499, 363);
            this.KillTitmerBtn.Name = "KillTitmerBtn";
            this.KillTitmerBtn.Size = new System.Drawing.Size(211, 37);
            this.KillTitmerBtn.TabIndex = 9;
            this.KillTitmerBtn.Text = "프로그램 중지";
            this.KillTitmerBtn.UseVisualStyleBackColor = true;
            this.KillTitmerBtn.Click += new System.EventHandler(this.KillTitmerBtn_Click);
            // 
            // LogLv
            // 
            this.LogLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RunNamecol});
            this.LogLv.HideSelection = false;
            this.LogLv.Location = new System.Drawing.Point(500, 46);
            this.LogLv.Name = "LogLv";
            this.LogLv.Size = new System.Drawing.Size(211, 311);
            this.LogLv.TabIndex = 11;
            this.LogLv.UseCompatibleStateImageBehavior = false;
            this.LogLv.View = System.Windows.Forms.View.Details;
            // 
            // RunNamecol
            // 
            this.RunNamecol.Text = "Name + bevior";
            this.RunNamecol.Width = 207;
            // 
            // ucCon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LogLv);
            this.Controls.Add(this.KillTitmerBtn);
            this.Controls.Add(this.AddRunListBtn);
            this.Controls.Add(this.DelRunListBtn);
            this.Controls.Add(this.DelKillListBtn);
            this.Controls.Add(this.AddKillListBtn);
            this.Controls.Add(this.LogTitle);
            this.Controls.Add(this.RunTitle);
            this.Controls.Add(this.KillTitle);
            this.Name = "ucCon";
            this.Size = new System.Drawing.Size(719, 403);
            this.Load += new System.EventHandler(this.ucCon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button KillTitle;
        private System.Windows.Forms.Button RunTitle;
        private System.Windows.Forms.Button LogTitle;
        private System.Windows.Forms.Button AddKillListBtn;
        public System.Windows.Forms.Button DelKillListBtn;
        private System.Windows.Forms.Button AddRunListBtn;
        private System.Windows.Forms.Button DelRunListBtn;
        private System.Windows.Forms.Button KillTitmerBtn;
        private System.Windows.Forms.ListView LogLv;
        public System.Windows.Forms.ColumnHeader RunNamecol;
    }
}
