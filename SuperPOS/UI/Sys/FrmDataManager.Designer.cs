namespace SuperPOS.UI.Sys
{
    partial class FrmDataManager
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
            this.btnBackup = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtBackup = new DevExpress.XtraEditors.TextEdit();
            this.txtRestore = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtBackup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRestore.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBackup
            // 
            this.btnBackup.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnBackup.Appearance.Options.UseBackColor = true;
            this.btnBackup.Location = new System.Drawing.Point(421, 15);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(130, 37);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "Backup Data";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(143, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Backup Data File Location:";
            // 
            // txtBackup
            // 
            this.txtBackup.Location = new System.Drawing.Point(12, 33);
            this.txtBackup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBackup.Name = "txtBackup";
            this.txtBackup.Size = new System.Drawing.Size(382, 20);
            this.txtBackup.TabIndex = 2;
            // 
            // txtRestore
            // 
            this.txtRestore.Location = new System.Drawing.Point(12, 110);
            this.txtRestore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRestore.Name = "txtRestore";
            this.txtRestore.Size = new System.Drawing.Size(382, 20);
            this.txtRestore.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 91);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(146, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Restore Data File Location:";
            // 
            // btnRestore
            // 
            this.btnRestore.Appearance.BackColor = System.Drawing.Color.Teal;
            this.btnRestore.Appearance.Options.UseBackColor = true;
            this.btnRestore.Location = new System.Drawing.Point(421, 58);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(130, 37);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "Restore Data";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Location = new System.Drawing.Point(421, 100);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 37);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmDataManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 149);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtRestore);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.txtBackup);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDataManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmDataManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDataManager_Load);
            this.SizeChanged += new System.EventHandler(this.FrmDataManager_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.txtBackup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRestore.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnBackup;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtBackup;
        private DevExpress.XtraEditors.TextEdit txtRestore;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}