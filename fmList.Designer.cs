
namespace PRM
{
    partial class fmList
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
            this.AddKListChBox = new System.Windows.Forms.CheckedListBox();
            this.AddKBtn = new System.Windows.Forms.Button();
            this.CancelKBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddKListChBox
            // 
            this.AddKListChBox.FormattingEnabled = true;
            this.AddKListChBox.Location = new System.Drawing.Point(3, 5);
            this.AddKListChBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddKListChBox.Name = "AddKListChBox";
            this.AddKListChBox.Size = new System.Drawing.Size(212, 404);
            this.AddKListChBox.TabIndex = 0;
            // 
            // AddKBtn
            // 
            this.AddKBtn.Location = new System.Drawing.Point(3, 416);
            this.AddKBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddKBtn.Name = "AddKBtn";
            this.AddKBtn.Size = new System.Drawing.Size(103, 29);
            this.AddKBtn.TabIndex = 1;
            this.AddKBtn.Text = "추가";
            this.AddKBtn.UseVisualStyleBackColor = true;
            this.AddKBtn.Click += new System.EventHandler(this.AddKBtn_Click);
            // 
            // CancelKBtn
            // 
            this.CancelKBtn.Location = new System.Drawing.Point(112, 416);
            this.CancelKBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CancelKBtn.Name = "CancelKBtn";
            this.CancelKBtn.Size = new System.Drawing.Size(103, 29);
            this.CancelKBtn.TabIndex = 2;
            this.CancelKBtn.Text = "취소";
            this.CancelKBtn.UseVisualStyleBackColor = true;
            this.CancelKBtn.Click += new System.EventHandler(this.CancelKBtn_Click);
            // 
            // fmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(219, 451);
            this.ControlBox = false;
            this.Controls.Add(this.CancelKBtn);
            this.Controls.Add(this.AddKBtn);
            this.Controls.Add(this.AddKListChBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmList";
            this.ShowInTaskbar = false;
            this.Text = "ProcessList";
            this.Load += new System.EventHandler(this.FrmList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox AddKListChBox;
        private System.Windows.Forms.Button AddKBtn;
        private System.Windows.Forms.Button CancelKBtn;
    }
}