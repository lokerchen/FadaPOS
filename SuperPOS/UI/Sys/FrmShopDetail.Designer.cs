namespace SuperPOS.UI.Sys
{
    partial class FrmShopDetail
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
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtShopAddr = new System.Windows.Forms.RichTextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtShopName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTelNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtVatNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVatNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtVatNo);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.txtTelNo);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.txtShopAddr);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtShopName);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(412, 317);
            this.panelControl1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(140, 269);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 31);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtShopAddr
            // 
            this.txtShopAddr.Location = new System.Drawing.Point(124, 63);
            this.txtShopAddr.Name = "txtShopAddr";
            this.txtShopAddr.Size = new System.Drawing.Size(270, 96);
            this.txtShopAddr.TabIndex = 4;
            this.txtShopAddr.Text = "";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 63);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(94, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Shop Address:";
            // 
            // txtShopName
            // 
            this.txtShopName.Location = new System.Drawing.Point(124, 15);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(270, 24);
            this.txtShopName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Shop Name:";
            // 
            // txtTelNo
            // 
            this.txtTelNo.Location = new System.Drawing.Point(124, 178);
            this.txtTelNo.Name = "txtTelNo";
            this.txtTelNo.Properties.Mask.EditMask = "f0";
            this.txtTelNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTelNo.Size = new System.Drawing.Size(270, 24);
            this.txtTelNo.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(7, 184);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(101, 18);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Telephone No.:";
            // 
            // txtVatNo
            // 
            this.txtVatNo.Location = new System.Drawing.Point(124, 218);
            this.txtVatNo.Name = "txtVatNo";
            this.txtVatNo.Properties.Mask.EditMask = "f0";
            this.txtVatNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtVatNo.Size = new System.Drawing.Size(270, 24);
            this.txtVatNo.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(47, 224);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 18);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "VAT No.:";
            // 
            // FrmShopDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 317);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmShopDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shop Details";
            this.Load += new System.EventHandler(this.FrmShopDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShopName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVatNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtShopName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.RichTextBox txtShopAddr;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtVatNo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtTelNo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}