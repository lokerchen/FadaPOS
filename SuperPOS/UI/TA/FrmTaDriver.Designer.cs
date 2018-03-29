namespace SuperPOS.UI.TA
{
    partial class FrmTaDriver
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControlTaDriver = new DevExpress.XtraGrid.GridControl();
            this.gvTaDriver = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DriverName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DriverNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DriverWorkDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.chkWorkDay = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.txtPhoneNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDriverName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkWorkDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDriverName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Driver Name:";
            // 
            // gridControlTaDriver
            // 
            this.gridControlTaDriver.Location = new System.Drawing.Point(5, 148);
            this.gridControlTaDriver.MainView = this.gvTaDriver;
            this.gridControlTaDriver.Name = "gridControlTaDriver";
            this.gridControlTaDriver.Size = new System.Drawing.Size(425, 366);
            this.gridControlTaDriver.TabIndex = 2;
            this.gridControlTaDriver.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaDriver});
            // 
            // gvTaDriver
            // 
            this.gvTaDriver.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvTaDriver.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTaDriver.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvTaDriver.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTaDriver.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.DriverName,
            this.DriverNumber,
            this.DriverWorkDay});
            this.gvTaDriver.GridControl = this.gridControlTaDriver;
            this.gvTaDriver.IndicatorWidth = 50;
            this.gvTaDriver.Name = "gvTaDriver";
            this.gvTaDriver.OptionsBehavior.Editable = false;
            this.gvTaDriver.OptionsMenu.EnableColumnMenu = false;
            this.gvTaDriver.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaDriver.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaDriver.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaDriver.OptionsView.ShowGroupPanel = false;
            this.gvTaDriver.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvTaDriver_CustomDrawRowIndicator);
            this.gvTaDriver.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvTaDriver_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // DriverName
            // 
            this.DriverName.Caption = "Driver Name";
            this.DriverName.FieldName = "DriverName";
            this.DriverName.Name = "DriverName";
            this.DriverName.Visible = true;
            this.DriverName.VisibleIndex = 0;
            // 
            // DriverNumber
            // 
            this.DriverNumber.Caption = "Phone Number";
            this.DriverNumber.FieldName = "DriverNumber";
            this.DriverNumber.Name = "DriverNumber";
            this.DriverNumber.Visible = true;
            this.DriverNumber.VisibleIndex = 1;
            // 
            // DriverWorkDay
            // 
            this.DriverWorkDay.Caption = "Work Day";
            this.DriverWorkDay.FieldName = "DriverWorkDay";
            this.DriverWorkDay.Name = "DriverWorkDay";
            this.DriverWorkDay.Visible = true;
            this.DriverWorkDay.VisibleIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlTaDriver);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Location = new System.Drawing.Point(8, 8);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(439, 521);
            this.panelControl1.TabIndex = 3;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnDel);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Location = new System.Drawing.Point(318, 5);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(112, 137);
            this.panelControl3.TabIndex = 1;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(9, 98);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(95, 25);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(9, 56);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl11);
            this.panelControl2.Controls.Add(this.chkWorkDay);
            this.panelControl2.Controls.Add(this.txtPhoneNum);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.txtDriverName);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(5, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(307, 137);
            this.panelControl2.TabIndex = 0;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(21, 102);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(88, 18);
            this.labelControl11.TabIndex = 22;
            this.labelControl11.Text = "Working Day:";
            // 
            // chkWorkDay
            // 
            this.chkWorkDay.Location = new System.Drawing.Point(115, 96);
            this.chkWorkDay.Name = "chkWorkDay";
            this.chkWorkDay.Properties.AllowMultiSelect = true;
            this.chkWorkDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkWorkDay.Size = new System.Drawing.Size(146, 24);
            this.chkWorkDay.TabIndex = 21;
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(115, 57);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Properties.Mask.EditMask = "f0";
            this.txtPhoneNum.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPhoneNum.Size = new System.Drawing.Size(146, 24);
            this.txtPhoneNum.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 63);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(102, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Phone Number:";
            // 
            // txtDriverName
            // 
            this.txtDriverName.Location = new System.Drawing.Point(115, 18);
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.Size = new System.Drawing.Size(146, 24);
            this.txtDriverName.TabIndex = 1;
            // 
            // FrmTaDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 538);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaDriver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTaDriver";
            this.Load += new System.EventHandler(this.FrmTaDriver_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkWorkDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDriverName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControlTaDriver;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaDriver;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn DriverName;
        private DevExpress.XtraGrid.Columns.GridColumn DriverNumber;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtPhoneNum;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDriverName;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkWorkDay;
        private DevExpress.XtraGrid.Columns.GridColumn DriverWorkDay;
    }
}