namespace SuperPOS.UI.Sys
{
    partial class FrmShiftCodeDetail
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkSun = new DevExpress.XtraEditors.CheckEdit();
            this.chkSat = new DevExpress.XtraEditors.CheckEdit();
            this.chkFri = new DevExpress.XtraEditors.CheckEdit();
            this.chkThur = new DevExpress.XtraEditors.CheckEdit();
            this.chkWed = new DevExpress.XtraEditors.CheckEdit();
            this.chkTues = new DevExpress.XtraEditors.CheckEdit();
            this.chkMon = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsSpecialPrice = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtOtherName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtShiftName = new DevExpress.XtraEditors.TextEdit();
            this.txtShiftCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTues.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSpecialPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShiftName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShiftCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new System.Drawing.Size(380, 392);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.panelControl2);
            this.xtraTabPage2.Controls.Add(this.panelControl1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(373, 356);
            this.xtraTabPage2.Text = "Shift Code Details";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnAdd);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Location = new System.Drawing.Point(6, 309);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(361, 43);
            this.panelControl2.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(274, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(94, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(184, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dtpEnd);
            this.panelControl1.Controls.Add(this.dtpFrom);
            this.panelControl1.Controls.Add(this.chkSun);
            this.panelControl1.Controls.Add(this.chkSat);
            this.panelControl1.Controls.Add(this.chkFri);
            this.panelControl1.Controls.Add(this.chkThur);
            this.panelControl1.Controls.Add(this.chkWed);
            this.panelControl1.Controls.Add(this.chkTues);
            this.panelControl1.Controls.Add(this.chkMon);
            this.panelControl1.Controls.Add(this.chkIsSpecialPrice);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.txtOtherName);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txtShiftName);
            this.panelControl1.Controls.Add(this.txtShiftCode);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(6, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(361, 300);
            this.panelControl1.TabIndex = 0;
            // 
            // chkSun
            // 
            this.chkSun.Location = new System.Drawing.Point(267, 190);
            this.chkSun.Name = "chkSun";
            this.chkSun.Properties.Caption = "Sun";
            this.chkSun.Size = new System.Drawing.Size(75, 22);
            this.chkSun.TabIndex = 15;
            // 
            // chkSat
            // 
            this.chkSat.Location = new System.Drawing.Point(267, 160);
            this.chkSat.Name = "chkSat";
            this.chkSat.Properties.Caption = "Sat";
            this.chkSat.Size = new System.Drawing.Size(75, 22);
            this.chkSat.TabIndex = 14;
            // 
            // chkFri
            // 
            this.chkFri.Location = new System.Drawing.Point(267, 130);
            this.chkFri.Name = "chkFri";
            this.chkFri.Properties.Caption = "Fri";
            this.chkFri.Size = new System.Drawing.Size(75, 22);
            this.chkFri.TabIndex = 13;
            // 
            // chkThur
            // 
            this.chkThur.Location = new System.Drawing.Point(267, 100);
            this.chkThur.Name = "chkThur";
            this.chkThur.Properties.Caption = "Thur";
            this.chkThur.Size = new System.Drawing.Size(75, 22);
            this.chkThur.TabIndex = 12;
            // 
            // chkWed
            // 
            this.chkWed.Location = new System.Drawing.Point(267, 70);
            this.chkWed.Name = "chkWed";
            this.chkWed.Properties.Caption = "Wed";
            this.chkWed.Size = new System.Drawing.Size(75, 22);
            this.chkWed.TabIndex = 11;
            // 
            // chkTues
            // 
            this.chkTues.Location = new System.Drawing.Point(267, 40);
            this.chkTues.Name = "chkTues";
            this.chkTues.Properties.Caption = "Tues";
            this.chkTues.Size = new System.Drawing.Size(75, 22);
            this.chkTues.TabIndex = 10;
            // 
            // chkMon
            // 
            this.chkMon.Location = new System.Drawing.Point(267, 10);
            this.chkMon.Name = "chkMon";
            this.chkMon.Properties.Caption = "Mon";
            this.chkMon.Size = new System.Drawing.Size(75, 22);
            this.chkMon.TabIndex = 9;
            // 
            // chkIsSpecialPrice
            // 
            this.chkIsSpecialPrice.Location = new System.Drawing.Point(83, 246);
            this.chkIsSpecialPrice.Name = "chkIsSpecialPrice";
            this.chkIsSpecialPrice.Properties.Caption = "Enable Sepcial Price";
            this.chkIsSpecialPrice.Size = new System.Drawing.Size(158, 22);
            this.chkIsSpecialPrice.TabIndex = 8;
            this.chkIsSpecialPrice.CheckedChanged += new System.EventHandler(this.chkIsSpecialPrice_CheckedChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(73, 207);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(23, 18);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "To:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(57, 159);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(39, 18);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "From:";
            // 
            // txtOtherName
            // 
            this.txtOtherName.Location = new System.Drawing.Point(112, 105);
            this.txtOtherName.Name = "txtOtherName";
            this.txtOtherName.Size = new System.Drawing.Size(129, 24);
            this.txtOtherName.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 111);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(86, 18);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Other Name:";
            // 
            // txtShiftName
            // 
            this.txtShiftName.Location = new System.Drawing.Point(112, 54);
            this.txtShiftName.Name = "txtShiftName";
            this.txtShiftName.Size = new System.Drawing.Size(129, 24);
            this.txtShiftName.TabIndex = 1;
            // 
            // txtShiftCode
            // 
            this.txtShiftCode.Location = new System.Drawing.Point(112, 9);
            this.txtShiftCode.Name = "txtShiftCode";
            this.txtShiftCode.Size = new System.Drawing.Size(129, 24);
            this.txtShiftCode.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 18);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Shift Name:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Shift Code:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "HH:mm";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(112, 151);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowUpDown = true;
            this.dtpFrom.Size = new System.Drawing.Size(129, 26);
            this.dtpFrom.TabIndex = 16;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "HH:mm";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(112, 199);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(129, 26);
            this.dtpEnd.TabIndex = 17;
            // 
            // FrmShiftCodeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 392);
            this.Controls.Add(this.xtraTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShiftCodeDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shift Code Details";
            this.Load += new System.EventHandler(this.FrmShiftCodeDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTues.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSpecialPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShiftName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShiftCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.TextEdit txtShiftCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkSun;
        private DevExpress.XtraEditors.CheckEdit chkSat;
        private DevExpress.XtraEditors.CheckEdit chkFri;
        private DevExpress.XtraEditors.CheckEdit chkThur;
        private DevExpress.XtraEditors.CheckEdit chkWed;
        private DevExpress.XtraEditors.CheckEdit chkTues;
        private DevExpress.XtraEditors.CheckEdit chkMon;
        private DevExpress.XtraEditors.CheckEdit chkIsSpecialPrice;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtOtherName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtShiftName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpFrom;
    }
}