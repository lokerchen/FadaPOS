namespace SuperPOS.UI.TA
{
    partial class FrmTaMenuCate
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
            this.MenuSetID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MenuSet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeptCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CatePosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CateOtherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CateEngName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueMenuSet = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtPosition = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lueDeptCode = new DevExpress.XtraEditors.LookUpEdit();
            this.txtEngName = new DevExpress.XtraEditors.TextEdit();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMenuCate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DeptCodeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlMenuCate = new DevExpress.XtraGrid.GridControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtOtherName = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkHotKey = new DevExpress.XtraEditors.CheckEdit();
            this.txtHotKeyDishCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.IsHotKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HotKeyDishCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lueMenuSet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDeptCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenuCate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMenuCate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkHotKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHotKeyDishCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuSetID
            // 
            this.MenuSetID.Caption = "MenuSetID";
            this.MenuSetID.FieldName = "MenuSetID";
            this.MenuSetID.Name = "MenuSetID";
            // 
            // MenuSet
            // 
            this.MenuSet.Caption = "Menu Set";
            this.MenuSet.FieldName = "MenuSet";
            this.MenuSet.Name = "MenuSet";
            this.MenuSet.Visible = true;
            this.MenuSet.VisibleIndex = 4;
            this.MenuSet.Width = 101;
            // 
            // DeptCode
            // 
            this.DeptCode.Caption = "Department Code";
            this.DeptCode.FieldName = "DeptCode";
            this.DeptCode.Name = "DeptCode";
            this.DeptCode.Visible = true;
            this.DeptCode.VisibleIndex = 3;
            this.DeptCode.Width = 156;
            // 
            // CatePosition
            // 
            this.CatePosition.Caption = "Display Position";
            this.CatePosition.FieldName = "CatePosition";
            this.CatePosition.Name = "CatePosition";
            this.CatePosition.Visible = true;
            this.CatePosition.VisibleIndex = 2;
            this.CatePosition.Width = 117;
            // 
            // CateOtherName
            // 
            this.CateOtherName.Caption = "Other Name";
            this.CateOtherName.FieldName = "CateOtherName";
            this.CateOtherName.Name = "CateOtherName";
            this.CateOtherName.Visible = true;
            this.CateOtherName.VisibleIndex = 1;
            this.CateOtherName.Width = 92;
            // 
            // CateEngName
            // 
            this.CateEngName.Caption = "English Name";
            this.CateEngName.FieldName = "CateEngName";
            this.CateEngName.Name = "CateEngName";
            this.CateEngName.Visible = true;
            this.CateEngName.VisibleIndex = 0;
            this.CateEngName.Width = 99;
            // 
            // lueMenuSet
            // 
            this.lueMenuSet.Location = new System.Drawing.Point(445, 42);
            this.lueMenuSet.Name = "lueMenuSet";
            this.lueMenuSet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMenuSet.Properties.NullText = "[Please select...]";
            this.lueMenuSet.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.lueMenuSet.Size = new System.Drawing.Size(153, 24);
            this.lueMenuSet.TabIndex = 10;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(372, 44);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(67, 18);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Menu Set:";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(115, 75);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Properties.Mask.EditMask = "f0";
            this.txtPosition.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPosition.Size = new System.Drawing.Size(171, 24);
            this.txtPosition.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(6, 81);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(103, 18);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Display Position:";
            // 
            // lueDeptCode
            // 
            this.lueDeptCode.Location = new System.Drawing.Point(445, 5);
            this.lueDeptCode.Name = "lueDeptCode";
            this.lueDeptCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDeptCode.Properties.NullText = "[Please select...]";
            this.lueDeptCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.lueDeptCode.Size = new System.Drawing.Size(153, 24);
            this.lueDeptCode.TabIndex = 6;
            // 
            // txtEngName
            // 
            this.txtEngName.Location = new System.Drawing.Point(115, 5);
            this.txtEngName.Name = "txtEngName";
            this.txtEngName.Size = new System.Drawing.Size(171, 24);
            this.txtEngName.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // gvMenuCate
            // 
            this.gvMenuCate.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvMenuCate.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvMenuCate.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvMenuCate.Appearance.OddRow.Options.UseBackColor = true;
            this.gvMenuCate.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.CateEngName,
            this.CateOtherName,
            this.CatePosition,
            this.DeptCode,
            this.MenuSet,
            this.IsHotKey,
            this.HotKeyDishCode,
            this.DeptCodeID,
            this.MenuSetID});
            this.gvMenuCate.GridControl = this.gridControlMenuCate;
            this.gvMenuCate.IndicatorWidth = 50;
            this.gvMenuCate.Name = "gvMenuCate";
            this.gvMenuCate.OptionsBehavior.Editable = false;
            this.gvMenuCate.OptionsMenu.EnableColumnMenu = false;
            this.gvMenuCate.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvMenuCate.OptionsView.EnableAppearanceEvenRow = true;
            this.gvMenuCate.OptionsView.EnableAppearanceOddRow = true;
            this.gvMenuCate.OptionsView.ShowGroupPanel = false;
            this.gvMenuCate.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvMenuCate_CustomDrawRowIndicator);
            this.gvMenuCate.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvMenuCate_FocusedRowChanged);
            // 
            // DeptCodeID
            // 
            this.DeptCodeID.Caption = "DeptCodeID";
            this.DeptCodeID.FieldName = "DeptCodeID";
            this.DeptCodeID.Name = "DeptCodeID";
            // 
            // gridControlMenuCate
            // 
            this.gridControlMenuCate.Location = new System.Drawing.Point(5, 207);
            this.gridControlMenuCate.MainView = this.gvMenuCate;
            this.gridControlMenuCate.Name = "gridControlMenuCate";
            this.gridControlMenuCate.Size = new System.Drawing.Size(617, 372);
            this.gridControlMenuCate.TabIndex = 8;
            this.gridControlMenuCate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMenuCate});
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(318, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(121, 18);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Department Code:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 18);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "English Name:";
            // 
            // txtOtherName
            // 
            this.txtOtherName.Location = new System.Drawing.Point(115, 40);
            this.txtOtherName.Name = "txtOtherName";
            this.txtOtherName.Size = new System.Drawing.Size(171, 24);
            this.txtOtherName.TabIndex = 4;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtHotKeyDishCode);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Controls.Add(this.chkHotKey);
            this.panelControl2.Controls.Add(this.lueMenuSet);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.txtPosition);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.lueDeptCode);
            this.panelControl2.Controls.Add(this.txtEngName);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.txtOtherName);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Location = new System.Drawing.Point(5, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(617, 143);
            this.panelControl2.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Other Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(190, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(40, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnExit);
            this.panelControl3.Controls.Add(this.btnDel);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Location = new System.Drawing.Point(5, 154);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(617, 48);
            this.panelControl3.TabIndex = 10;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(340, 14);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(95, 25);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.gridControlMenuCate);
            this.panelControl1.Location = new System.Drawing.Point(6, 6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(627, 584);
            this.panelControl1.TabIndex = 1;
            // 
            // chkHotKey
            // 
            this.chkHotKey.Location = new System.Drawing.Point(523, 84);
            this.chkHotKey.Name = "chkHotKey";
            this.chkHotKey.Properties.Caption = "Hot Key";
            this.chkHotKey.Size = new System.Drawing.Size(75, 22);
            this.chkHotKey.TabIndex = 11;
            this.chkHotKey.CheckedChanged += new System.EventHandler(this.chkHotKey_CheckedChanged);
            // 
            // txtHotKeyDishCode
            // 
            this.txtHotKeyDishCode.Location = new System.Drawing.Point(427, 112);
            this.txtHotKeyDishCode.Name = "txtHotKeyDishCode";
            this.txtHotKeyDishCode.Properties.Mask.EditMask = "f0";
            this.txtHotKeyDishCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtHotKeyDishCode.Size = new System.Drawing.Size(171, 24);
            this.txtHotKeyDishCode.TabIndex = 13;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(351, 118);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(70, 18);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Dish Code:";
            // 
            // IsHotKey
            // 
            this.IsHotKey.Caption = "HotKey";
            this.IsHotKey.Name = "IsHotKey";
            // 
            // HotKeyDishCode
            // 
            this.HotKeyDishCode.Caption = "HotKeyDishCode";
            this.HotKeyDishCode.Name = "HotKeyDishCode";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(490, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 25);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmTaMenuCate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 595);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaMenuCate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTaMenuCategory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaMenuCategory_Load);
            this.SizeChanged += new System.EventHandler(this.FrmTaMenuCate_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.lueMenuSet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDeptCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenuCate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMenuCate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkHotKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHotKeyDishCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn MenuSetID;
        private DevExpress.XtraGrid.Columns.GridColumn MenuSet;
        private DevExpress.XtraGrid.Columns.GridColumn DeptCode;
        private DevExpress.XtraGrid.Columns.GridColumn CatePosition;
        private DevExpress.XtraGrid.Columns.GridColumn CateOtherName;
        private DevExpress.XtraGrid.Columns.GridColumn CateEngName;
        private DevExpress.XtraEditors.LookUpEdit lueMenuSet;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtPosition;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lueDeptCode;
        private DevExpress.XtraEditors.TextEdit txtEngName;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMenuCate;
        private DevExpress.XtraGrid.Columns.GridColumn DeptCodeID;
        private DevExpress.XtraGrid.GridControl gridControlMenuCate;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtOtherName;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtHotKeyDishCode;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.CheckEdit chkHotKey;
        private DevExpress.XtraGrid.Columns.GridColumn IsHotKey;
        private DevExpress.XtraGrid.Columns.GridColumn HotKeyDishCode;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}