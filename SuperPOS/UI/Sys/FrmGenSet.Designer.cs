namespace SuperPOS.UI.Sys
{
    partial class FrmGenSet
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lueBackUpDriver = new DevExpress.XtraEditors.LookUpEdit();
            this.chkIsBackup = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtVatPer = new DevExpress.XtraEditors.TextEdit();
            this.txtCheckCurrency = new DevExpress.XtraEditors.TextEdit();
            this.txtTillNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkDisplayCode = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueBackUpDriver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsBackup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVatPer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTillNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisplayCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lueBackUpDriver);
            this.panelControl1.Controls.Add(this.chkIsBackup);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.txtVatPer);
            this.panelControl1.Controls.Add(this.txtCheckCurrency);
            this.panelControl1.Controls.Add(this.txtTillNum);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.chkDisplayCode);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(313, 332);
            this.panelControl1.TabIndex = 0;
            // 
            // lueBackUpDriver
            // 
            this.lueBackUpDriver.Location = new System.Drawing.Point(146, 96);
            this.lueBackUpDriver.Name = "lueBackUpDriver";
            this.lueBackUpDriver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBackUpDriver.Size = new System.Drawing.Size(136, 24);
            this.lueBackUpDriver.TabIndex = 13;
            // 
            // chkIsBackup
            // 
            this.chkIsBackup.Location = new System.Drawing.Point(20, 60);
            this.chkIsBackup.Name = "chkIsBackup";
            this.chkIsBackup.Properties.Caption = "Back Up When Exit";
            this.chkIsBackup.Size = new System.Drawing.Size(156, 22);
            this.chkIsBackup.TabIndex = 12;
            this.chkIsBackup.CheckedChanged += new System.EventHandler(this.chkIsBackup_CheckedChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 99);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(102, 18);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Back Up Driver:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(47, 272);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 33);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtVatPer
            // 
            this.txtVatPer.Location = new System.Drawing.Point(146, 218);
            this.txtVatPer.Name = "txtVatPer";
            this.txtVatPer.Properties.Mask.EditMask = "P";
            this.txtVatPer.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtVatPer.Size = new System.Drawing.Size(100, 24);
            this.txtVatPer.TabIndex = 8;
            // 
            // txtCheckCurrency
            // 
            this.txtCheckCurrency.Location = new System.Drawing.Point(98, 175);
            this.txtCheckCurrency.Name = "txtCheckCurrency";
            this.txtCheckCurrency.Size = new System.Drawing.Size(100, 24);
            this.txtCheckCurrency.TabIndex = 7;
            // 
            // txtTillNum
            // 
            this.txtTillNum.Location = new System.Drawing.Point(113, 133);
            this.txtTillNum.Name = "txtTillNum";
            this.txtTillNum.Properties.Mask.EditMask = "d";
            this.txtTillNum.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTillNum.Size = new System.Drawing.Size(100, 24);
            this.txtTillNum.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(20, 224);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(111, 18);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "VAT Percentage:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(20, 181);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 18);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Currency:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 139);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(78, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Till Number:";
            // 
            // chkDisplayCode
            // 
            this.chkDisplayCode.Location = new System.Drawing.Point(20, 21);
            this.chkDisplayCode.Name = "chkDisplayCode";
            this.chkDisplayCode.Properties.Caption = "Display Item Code Select";
            this.chkDisplayCode.Size = new System.Drawing.Size(226, 22);
            this.chkDisplayCode.TabIndex = 0;
            // 
            // FrmGenSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 332);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGenSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmGenSet";
            this.Load += new System.EventHandler(this.FrmGenSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueBackUpDriver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsBackup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVatPer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTillNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisplayCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chkDisplayCode;
        private DevExpress.XtraEditors.TextEdit txtVatPer;
        private DevExpress.XtraEditors.TextEdit txtCheckCurrency;
        private DevExpress.XtraEditors.TextEdit txtTillNum;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.CheckEdit chkIsBackup;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueBackUpDriver;
    }
}