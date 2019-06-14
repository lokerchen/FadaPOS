namespace SuperPOS.UI.TA
{
    partial class FrmTaMenuItemCopyChoices
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
            this.gridControlMenuItem = new DevExpress.XtraGrid.GridControl();
            this.gvMenuItem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiDishCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiEngName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiOtherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiRegularPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiSpecialPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiSuppleShiftID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiSuppleShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiPrintID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiDeptCodeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiDeptCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiWorkDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiMenuSetID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiMenuSet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiRmk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiMenuCateID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiLargePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiSmallPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiBtnColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMenuItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenuItem)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridControlMenuItem);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupBox1.Location = new System.Drawing.Point(9, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 488);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Menu Item";
            // 
            // gridControlMenuItem
            // 
            this.gridControlMenuItem.Location = new System.Drawing.Point(6, 31);
            this.gridControlMenuItem.MainView = this.gvMenuItem;
            this.gridControlMenuItem.Name = "gridControlMenuItem";
            this.gridControlMenuItem.Size = new System.Drawing.Size(704, 374);
            this.gridControlMenuItem.TabIndex = 14;
            this.gridControlMenuItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMenuItem});
            // 
            // gvMenuItem
            // 
            this.gvMenuItem.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvMenuItem.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvMenuItem.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvMenuItem.Appearance.OddRow.Options.UseBackColor = true;
            this.gvMenuItem.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvMenuItem.Appearance.Row.Options.UseFont = true;
            this.gvMenuItem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.MiDishCode,
            this.MiPosition,
            this.MiEngName,
            this.MiOtherName,
            this.MiRegularPrice,
            this.MiSpecialPrice,
            this.MiSuppleShiftID,
            this.MiSuppleShift,
            this.MiPrintID,
            this.MiPrint,
            this.MiDeptCodeID,
            this.MiDeptCode,
            this.MiWorkDay,
            this.MiMenuSetID,
            this.MiMenuSet,
            this.MiRmk,
            this.MiMenuCateID,
            this.MiLargePrice,
            this.MiSmallPrice,
            this.MiBtnColor});
            this.gvMenuItem.GridControl = this.gridControlMenuItem;
            this.gvMenuItem.IndicatorWidth = 50;
            this.gvMenuItem.Name = "gvMenuItem";
            this.gvMenuItem.OptionsBehavior.Editable = false;
            this.gvMenuItem.OptionsMenu.EnableColumnMenu = false;
            this.gvMenuItem.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvMenuItem.OptionsView.EnableAppearanceEvenRow = true;
            this.gvMenuItem.OptionsView.EnableAppearanceOddRow = true;
            this.gvMenuItem.OptionsView.ShowGroupPanel = false;
            this.gvMenuItem.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvMenuItem_CustomDrawRowIndicator);
            this.gvMenuItem.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvMenuItem_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // MiDishCode
            // 
            this.MiDishCode.Caption = "Code";
            this.MiDishCode.FieldName = "MiDishCode";
            this.MiDishCode.Name = "MiDishCode";
            this.MiDishCode.Visible = true;
            this.MiDishCode.VisibleIndex = 0;
            this.MiDishCode.Width = 78;
            // 
            // MiPosition
            // 
            this.MiPosition.Caption = "Display Position";
            this.MiPosition.FieldName = "MiPosition";
            this.MiPosition.Name = "MiPosition";
            this.MiPosition.Width = 115;
            // 
            // MiEngName
            // 
            this.MiEngName.Caption = "Item Name";
            this.MiEngName.FieldName = "MiEngName";
            this.MiEngName.Name = "MiEngName";
            this.MiEngName.Visible = true;
            this.MiEngName.VisibleIndex = 1;
            this.MiEngName.Width = 98;
            // 
            // MiOtherName
            // 
            this.MiOtherName.Caption = "Other Name";
            this.MiOtherName.FieldName = "MiOtherName";
            this.MiOtherName.Name = "MiOtherName";
            this.MiOtherName.Width = 95;
            // 
            // MiRegularPrice
            // 
            this.MiRegularPrice.Caption = "Regular Price";
            this.MiRegularPrice.FieldName = "MiRegularPrice";
            this.MiRegularPrice.Name = "MiRegularPrice";
            this.MiRegularPrice.Width = 93;
            // 
            // MiSpecialPrice
            // 
            this.MiSpecialPrice.Caption = "Special Price";
            this.MiSpecialPrice.FieldName = "MiSpecialPrice";
            this.MiSpecialPrice.Name = "MiSpecialPrice";
            this.MiSpecialPrice.Width = 86;
            // 
            // MiSuppleShiftID
            // 
            this.MiSuppleShiftID.Caption = "MiSuppleShiftID";
            this.MiSuppleShiftID.FieldName = "MiSuppleShiftID";
            this.MiSuppleShiftID.Name = "MiSuppleShiftID";
            // 
            // MiSuppleShift
            // 
            this.MiSuppleShift.Caption = "Supply Shift";
            this.MiSuppleShift.FieldName = "MiSuppleShift";
            this.MiSuppleShift.Name = "MiSuppleShift";
            this.MiSuppleShift.Width = 94;
            // 
            // MiPrintID
            // 
            this.MiPrintID.Caption = "MiPrintID";
            this.MiPrintID.FieldName = "MiPrintID";
            this.MiPrintID.Name = "MiPrintID";
            // 
            // MiPrint
            // 
            this.MiPrint.Caption = "Print Name";
            this.MiPrint.FieldName = "MiPrint";
            this.MiPrint.Name = "MiPrint";
            this.MiPrint.Width = 88;
            // 
            // MiDeptCodeID
            // 
            this.MiDeptCodeID.Caption = "MiDeptCodeID";
            this.MiDeptCodeID.FieldName = "MiDeptCodeID";
            this.MiDeptCodeID.Name = "MiDeptCodeID";
            this.MiDeptCodeID.Width = 113;
            // 
            // MiDeptCode
            // 
            this.MiDeptCode.Caption = "Print Order";
            this.MiDeptCode.FieldName = "MiDeptCode";
            this.MiDeptCode.Name = "MiDeptCode";
            this.MiDeptCode.Width = 73;
            // 
            // MiWorkDay
            // 
            this.MiWorkDay.Caption = "Working Day";
            this.MiWorkDay.FieldName = "MiWorkDay";
            this.MiWorkDay.Name = "MiWorkDay";
            this.MiWorkDay.Width = 160;
            // 
            // MiMenuSetID
            // 
            this.MiMenuSetID.Caption = "MiMenuSetID";
            this.MiMenuSetID.FieldName = "MiMenuSetID";
            this.MiMenuSetID.Name = "MiMenuSetID";
            this.MiMenuSetID.Width = 52;
            // 
            // MiMenuSet
            // 
            this.MiMenuSet.Caption = "Menu Set";
            this.MiMenuSet.FieldName = "MiMenuSet";
            this.MiMenuSet.Name = "MiMenuSet";
            this.MiMenuSet.Width = 60;
            // 
            // MiRmk
            // 
            this.MiRmk.Caption = "Remark";
            this.MiRmk.FieldName = "MiRmk";
            this.MiRmk.Name = "MiRmk";
            this.MiRmk.Width = 253;
            // 
            // MiMenuCateID
            // 
            this.MiMenuCateID.Caption = "MiMenuCateID";
            this.MiMenuCateID.FieldName = "MiMenuCateID";
            this.MiMenuCateID.Name = "MiMenuCateID";
            // 
            // MiLargePrice
            // 
            this.MiLargePrice.Caption = "Large Price";
            this.MiLargePrice.FieldName = "MiLargePrice";
            this.MiLargePrice.Name = "MiLargePrice";
            // 
            // MiSmallPrice
            // 
            this.MiSmallPrice.Caption = "Small Price";
            this.MiSmallPrice.FieldName = "MiSmallPrice";
            this.MiSmallPrice.Name = "MiSmallPrice";
            // 
            // MiBtnColor
            // 
            this.MiBtnColor.Caption = "MiBtnColor";
            this.MiBtnColor.FieldName = "MiBtnColor";
            this.MiBtnColor.Name = "MiBtnColor";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(452, 422);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 57);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(170, 422);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 57);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmTaMenuItemCopyChoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 495);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaMenuItemCopyChoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTaMenuItemCopyChoices";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaMenuItemCopyChoices_Load);
            this.SizeChanged += new System.EventHandler(this.FrmTaMenuItemCopyChoices_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMenuItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenuItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOK;
        private DevExpress.XtraGrid.GridControl gridControlMenuItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn MiDishCode;
        private DevExpress.XtraGrid.Columns.GridColumn MiPosition;
        private DevExpress.XtraGrid.Columns.GridColumn MiEngName;
        private DevExpress.XtraGrid.Columns.GridColumn MiOtherName;
        private DevExpress.XtraGrid.Columns.GridColumn MiRegularPrice;
        private DevExpress.XtraGrid.Columns.GridColumn MiSpecialPrice;
        private DevExpress.XtraGrid.Columns.GridColumn MiSuppleShiftID;
        private DevExpress.XtraGrid.Columns.GridColumn MiSuppleShift;
        private DevExpress.XtraGrid.Columns.GridColumn MiPrintID;
        private DevExpress.XtraGrid.Columns.GridColumn MiPrint;
        private DevExpress.XtraGrid.Columns.GridColumn MiDeptCodeID;
        private DevExpress.XtraGrid.Columns.GridColumn MiDeptCode;
        private DevExpress.XtraGrid.Columns.GridColumn MiWorkDay;
        private DevExpress.XtraGrid.Columns.GridColumn MiMenuSetID;
        private DevExpress.XtraGrid.Columns.GridColumn MiMenuSet;
        private DevExpress.XtraGrid.Columns.GridColumn MiRmk;
        private DevExpress.XtraGrid.Columns.GridColumn MiMenuCateID;
        private DevExpress.XtraGrid.Columns.GridColumn MiLargePrice;
        private DevExpress.XtraGrid.Columns.GridColumn MiSmallPrice;
        private DevExpress.XtraGrid.Columns.GridColumn MiBtnColor;
    }
}