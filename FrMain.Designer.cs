
namespace PRM
{
    public partial class FrMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrMain));
            this.KillLv = new System.Windows.Forms.ListView();
            this.Killcol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RunLv = new System.Windows.Forms.ListView();
            this.RunNamecol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PrmIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.PrmContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.StopStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PrmContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // KillLv
            // 
            this.KillLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Killcol});
            this.KillLv.HideSelection = false;
            this.KillLv.Location = new System.Drawing.Point(4, 45);
            this.KillLv.MultiSelect = false;
            this.KillLv.Name = "KillLv";
            this.KillLv.Size = new System.Drawing.Size(211, 311);
            this.KillLv.TabIndex = 0;
            this.KillLv.UseCompatibleStateImageBehavior = false;
            this.KillLv.View = System.Windows.Forms.View.Details;
            this.KillLv.SelectedIndexChanged += new System.EventHandler(this.KillLv_SelectedIndexChanged);
            // 
            // Killcol
            // 
            this.Killcol.Text = "Name";
            this.Killcol.Width = 207;
            // 
            // RunLv
            // 
            this.RunLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RunNamecol});
            this.RunLv.HideSelection = false;
            this.RunLv.Location = new System.Drawing.Point(252, 45);
            this.RunLv.MultiSelect = false;
            this.RunLv.Name = "RunLv";
            this.RunLv.Size = new System.Drawing.Size(211, 311);
            this.RunLv.TabIndex = 1;
            this.RunLv.UseCompatibleStateImageBehavior = false;
            this.RunLv.View = System.Windows.Forms.View.Details;
            this.RunLv.SelectedIndexChanged += new System.EventHandler(this.RunLv_SelectedIndexChanged);
            // 
            // RunNamecol
            // 
            this.RunNamecol.Text = "Name";
            this.RunNamecol.Width = 205;
            // 
            // PrmIcon
            // 
            this.PrmIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("PrmIcon.Icon")));
            this.PrmIcon.Text = "PRM";
            this.PrmIcon.Visible = true;
            this.PrmIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PrmIcon_MouseDoubleClick);
            // 
            // PrmContextMenu
            // 
            this.PrmContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PrmContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenStripMenu,
            this.StopStripMenu,
            this.closeStripMenu,
            this.updateStripMenu});
            this.PrmContextMenu.Name = "contextMenuStrip1";
            this.PrmContextMenu.Size = new System.Drawing.Size(181, 114);
            // 
            // OpenStripMenu
            // 
            this.OpenStripMenu.Name = "OpenStripMenu";
            this.OpenStripMenu.Size = new System.Drawing.Size(180, 22);
            this.OpenStripMenu.Text = "열기";
            this.OpenStripMenu.Click += new System.EventHandler(this.PrmIconOpen_Click);
            // 
            // StopStripMenu
            // 
            this.StopStripMenu.Name = "StopStripMenu";
            this.StopStripMenu.Size = new System.Drawing.Size(180, 22);
            this.StopStripMenu.Text = "중지";
            this.StopStripMenu.Click += new System.EventHandler(this.StopStripMenu_Click);
            // 
            // closeStripMenu
            // 
            this.closeStripMenu.Name = "closeStripMenu";
            this.closeStripMenu.Size = new System.Drawing.Size(180, 22);
            this.closeStripMenu.Text = "닫기";
            this.closeStripMenu.Click += new System.EventHandler(this.PrmIconClose_Click);
            // 
            // updateStripMenu
            // 
            this.updateStripMenu.Name = "updateStripMenu";
            this.updateStripMenu.Size = new System.Drawing.Size(180, 22);
            this.updateStripMenu.Text = "업데이트";
            this.updateStripMenu.Click += new System.EventHandler(this.updateStripMenu_Click);
            // 
            // FrMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(714, 407);
            this.Controls.Add(this.RunLv);
            this.Controls.Add(this.KillLv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrMain";
            this.Text = "PRM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrMain_Load);
            this.PrmContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView KillLv;
        public System.Windows.Forms.ListView RunLv;
        public System.Windows.Forms.ColumnHeader Killcol;
        public System.Windows.Forms.ColumnHeader RunNamecol;
        private System.Windows.Forms.ContextMenuStrip PrmContextMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenStripMenu;
        private System.Windows.Forms.ToolStripMenuItem closeStripMenu;
        public System.Windows.Forms.NotifyIcon PrmIcon;
        public System.Windows.Forms.ToolStripMenuItem StopStripMenu;
        private System.Windows.Forms.ToolStripMenuItem updateStripMenu;
    }
}

