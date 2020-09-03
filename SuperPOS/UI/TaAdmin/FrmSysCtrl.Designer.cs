namespace SuperPOS.UI.TaAdmin
{
    partial class FrmSysCtrl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtShopName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtShopAddress = new DevExpress.XtraEditors.TextEdit();
            this.chkShopDetailReadOnly = new DevExpress.XtraEditors.CheckEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShopDetailReadOnly.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 473);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Control";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkShopDetailReadOnly);
            this.groupBox2.Controls.Add(this.txtShopAddress);
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.txtShopName);
            this.groupBox2.Controls.Add(this.labelControl1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupBox2.Location = new System.Drawing.Point(15, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 144);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shop Details";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(53, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 18);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Address";
            // 
            // txtShopName
            // 
            this.txtShopName.Location = new System.Drawing.Point(126, 31);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(434, 24);
            this.txtShopName.TabIndex = 9;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(29, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 18);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Shop Name";
            // 
            // txtShopAddress
            // 
            this.txtShopAddress.Location = new System.Drawing.Point(126, 61);
            this.txtShopAddress.Name = "txtShopAddress";
            this.txtShopAddress.Size = new System.Drawing.Size(434, 24);
            this.txtShopAddress.TabIndex = 11;
            // 
            // chkShopDetailReadOnly
            // 
            this.chkShopDetailReadOnly.Location = new System.Drawing.Point(16, 101);
            this.chkShopDetailReadOnly.Name = "chkShopDetailReadOnly";
            this.chkShopDetailReadOnly.Properties.Caption = "Shop Details Read Only";
            this.chkShopDetailReadOnly.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkShopDetailReadOnly.Size = new System.Drawing.Size(186, 22);
            this.chkShopDetailReadOnly.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnSave.Location = new System.Drawing.Point(434, 403);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 55);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = System.Drawing.Color.Olive;
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Appearance.Options.UseForeColor = true;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExit.Location = new System.Drawing.Point(533, 403);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 55);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmSysCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 493);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSysCtrl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSysCtrl";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShopDetailReadOnly.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.TextEdit txtShopAddress;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtShopName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkShopDetailReadOnly;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}