
namespace PRM
{
    partial class FrmUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lsbOriginal = new System.Windows.Forms.ListBox();
            this.lsbUpdate = new System.Windows.Forms.ListBox();
            this.btnCloseU = new System.Windows.Forms.Button();
            this.txtState = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnOpenPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsbOriginal
            // 
            this.lsbOriginal.FormattingEnabled = true;
            this.lsbOriginal.ItemHeight = 12;
            this.lsbOriginal.Location = new System.Drawing.Point(12, 12);
            this.lsbOriginal.Name = "lsbOriginal";
            this.lsbOriginal.Size = new System.Drawing.Size(460, 340);
            this.lsbOriginal.TabIndex = 0;
            // 
            // lsbUpdate
            // 
            this.lsbUpdate.AllowDrop = true;
            this.lsbUpdate.FormattingEnabled = true;
            this.lsbUpdate.ItemHeight = 12;
            this.lsbUpdate.Location = new System.Drawing.Point(494, 12);
            this.lsbUpdate.Name = "lsbUpdate";
            this.lsbUpdate.Size = new System.Drawing.Size(208, 340);
            this.lsbUpdate.TabIndex = 4;
            // 
            // btnCloseU
            // 
            this.btnCloseU.Location = new System.Drawing.Point(494, 365);
            this.btnCloseU.Name = "btnCloseU";
            this.btnCloseU.Size = new System.Drawing.Size(208, 30);
            this.btnCloseU.TabIndex = 7;
            this.btnCloseU.Text = "종료";
            this.btnCloseU.UseVisualStyleBackColor = true;
            this.btnCloseU.Click += new System.EventHandler(this.btnCloseU_Click);
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(12, 371);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(143, 21);
            this.txtState.TabIndex = 8;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(328, 365);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(151, 30);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "업데이트";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnOpenPath
            // 
            this.btnOpenPath.Location = new System.Drawing.Point(171, 365);
            this.btnOpenPath.Name = "btnOpenPath";
            this.btnOpenPath.Size = new System.Drawing.Size(151, 30);
            this.btnOpenPath.TabIndex = 10;
            this.btnOpenPath.Text = "폴더열기";
            this.btnOpenPath.UseVisualStyleBackColor = true;
            this.btnOpenPath.Click += new System.EventHandler(this.btnOpenPath_Click);
            // 
            // FrmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(714, 407);
            this.ControlBox = false;
            this.Controls.Add(this.btnOpenPath);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.btnCloseU);
            this.Controls.Add(this.lsbUpdate);
            this.Controls.Add(this.lsbOriginal);
            this.Name = "FrmUpdate";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUpdate_FormClosed);
            this.Load += new System.EventHandler(this.FrmUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbOriginal;
        private System.Windows.Forms.ListBox lsbUpdate;
        private System.Windows.Forms.Button btnCloseU;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnOpenPath;
    }
}