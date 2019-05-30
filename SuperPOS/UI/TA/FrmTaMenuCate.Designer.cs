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
            this.txtPosition = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtEngName = new DevExpress.XtraEditors.TextEdit();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMenuCate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IsHotKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HotKeyDishCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeptCodeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlMenuCate = new DevExpress.XtraGrid.GridControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtOtherName = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lueMenuSet = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lueDeptCode = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtHotKeyDishCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.chkHotKey = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnMenuSet4 = new System.Windows.Forms.Button();
            this.btnMenuSet3 = new System.Windows.Forms.Button();
            this.btnMenuSet2 = new System.Windows.Forms.Button();
            this.btnMenuSet1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colorEditBtn = new DevExpress.XtraEditors.ColorEdit();
            this.BtnColor = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenuCate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMenuCate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueMenuSet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDeptCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHotKeyDishCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHotKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEditBtn.Properties)).BeginInit();
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
            this.MenuSet.Width = 101;
            // 
            // DeptCode
            // 
            this.DeptCode.Caption = "Department Code";
            this.DeptCode.FieldName = "DeptCode";
            this.DeptCode.Name = "DeptCode";
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
            this.MenuSetID,
            this.BtnColor});
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
            // DeptCodeID
            // 
            this.DeptCodeID.Caption = "DeptCodeID";
            this.DeptCodeID.FieldName = "DeptCodeID";
            this.DeptCodeID.Name = "DeptCodeID";
            // 
            // gridControlMenuCate
            // 
            this.gridControlMenuCate.Location = new System.Drawing.Point(6, 103);
            this.gridControlMenuCate.MainView = this.gvMenuCate;
            this.gridControlMenuCate.Name = "gridControlMenuCate";
            this.gridControlMenuCate.Size = new System.Drawing.Size(360, 338);
            this.gridControlMenuCate.TabIndex = 8;
            this.gridControlMenuCate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMenuCate});
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
            this.panelControl2.Controls.Add(this.colorEditBtn);
            this.panelControl2.Controls.Add(this.txtPosition);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.txtEngName);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.txtOtherName);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Location = new System.Drawing.Point(388, 12);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(454, 143);
            this.panelControl2.TabIndex = 9;
            // 
            // lueMenuSet
            // 
            this.lueMenuSet.Location = new System.Drawing.Point(569, 305);
            this.lueMenuSet.Name = "lueMenuSet";
            this.lueMenuSet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMenuSet.Properties.NullText = "[Please select...]";
            this.lueMenuSet.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.lueMenuSet.Size = new System.Drawing.Size(153, 24);
            this.lueMenuSet.TabIndex = 10;
            this.lueMenuSet.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(496, 307);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(67, 18);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Menu Set:";
            this.labelControl5.Visible = false;
            // 
            // lueDeptCode
            // 
            this.lueDeptCode.Location = new System.Drawing.Point(569, 268);
            this.lueDeptCode.Name = "lueDeptCode";
            this.lueDeptCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDeptCode.Properties.NullText = "[Please select...]";
            this.lueDeptCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.lueDeptCode.Size = new System.Drawing.Size(153, 24);
            this.lueDeptCode.TabIndex = 6;
            this.lueDeptCode.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(442, 271);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(121, 18);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Department Code:";
            this.labelControl3.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Other Name:";
            // 
            // txtHotKeyDishCode
            // 
            this.txtHotKeyDishCode.Location = new System.Drawing.Point(171, 24);
            this.txtHotKeyDishCode.Name = "txtHotKeyDishCode";
            this.txtHotKeyDishCode.Properties.Mask.EditMask = "f0";
            this.txtHotKeyDishCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtHotKeyDishCode.Size = new System.Drawing.Size(171, 24);
            this.txtHotKeyDishCode.TabIndex = 13;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(95, 30);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(70, 18);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Dish Code:";
            // 
            // chkHotKey
            // 
            this.chkHotKey.Location = new System.Drawing.Point(6, 26);
            this.chkHotKey.Name = "chkHotKey";
            this.chkHotKey.Properties.Caption = "Hot Key";
            this.chkHotKey.Size = new System.Drawing.Size(75, 22);
            this.chkHotKey.TabIndex = 11;
            this.chkHotKey.CheckedChanged += new System.EventHandler(this.chkHotKey_CheckedChanged);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnExit);
            this.panelControl3.Controls.Add(this.btnDel);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Location = new System.Drawing.Point(388, 382);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(355, 71);
            this.panelControl3.TabIndex = 10;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(270, 8);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 57);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(181, 8);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(82, 57);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(93, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 57);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(4, 8);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 57);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupBox5);
            this.panelControl1.Controls.Add(this.gridControlMenuCate);
            this.panelControl1.Location = new System.Drawing.Point(6, 6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(376, 447);
            this.panelControl1.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnMenuSet4);
            this.groupBox5.Controls.Add(this.btnMenuSet3);
            this.groupBox5.Controls.Add(this.btnMenuSet2);
            this.groupBox5.Controls.Add(this.btnMenuSet1);
            this.groupBox5.Location = new System.Drawing.Point(5, 7);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(360, 89);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Menu Set";
            // 
            // btnMenuSet4
            // 
            this.btnMenuSet4.BackColor = System.Drawing.Color.Gray;
            this.btnMenuSet4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSet4.ForeColor = System.Drawing.Color.White;
            this.btnMenuSet4.Location = new System.Drawing.Point(273, 24);
            this.btnMenuSet4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMenuSet4.Name = "btnMenuSet4";
            this.btnMenuSet4.Size = new System.Drawing.Size(82, 57);
            this.btnMenuSet4.TabIndex = 3;
            this.btnMenuSet4.Text = "button9";
            this.btnMenuSet4.UseVisualStyleBackColor = false;
            // 
            // btnMenuSet3
            // 
            this.btnMenuSet3.BackColor = System.Drawing.Color.Gray;
            this.btnMenuSet3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSet3.ForeColor = System.Drawing.Color.White;
            this.btnMenuSet3.Location = new System.Drawing.Point(184, 24);
            this.btnMenuSet3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMenuSet3.Name = "btnMenuSet3";
            this.btnMenuSet3.Size = new System.Drawing.Size(82, 57);
            this.btnMenuSet3.TabIndex = 2;
            this.btnMenuSet3.Text = "button8";
            this.btnMenuSet3.UseVisualStyleBackColor = false;
            // 
            // btnMenuSet2
            // 
            this.btnMenuSet2.BackColor = System.Drawing.Color.Gray;
            this.btnMenuSet2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSet2.ForeColor = System.Drawing.Color.White;
            this.btnMenuSet2.Location = new System.Drawing.Point(96, 24);
            this.btnMenuSet2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMenuSet2.Name = "btnMenuSet2";
            this.btnMenuSet2.Size = new System.Drawing.Size(82, 57);
            this.btnMenuSet2.TabIndex = 1;
            this.btnMenuSet2.Text = "button7";
            this.btnMenuSet2.UseVisualStyleBackColor = false;
            // 
            // btnMenuSet1
            // 
            this.btnMenuSet1.BackColor = System.Drawing.Color.Gray;
            this.btnMenuSet1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSet1.ForeColor = System.Drawing.Color.White;
            this.btnMenuSet1.Location = new System.Drawing.Point(7, 24);
            this.btnMenuSet1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMenuSet1.Name = "btnMenuSet1";
            this.btnMenuSet1.Size = new System.Drawing.Size(82, 57);
            this.btnMenuSet1.TabIndex = 0;
            this.btnMenuSet1.Text = "button6";
            this.btnMenuSet1.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkHotKey);
            this.groupBox1.Controls.Add(this.txtHotKeyDishCode);
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Location = new System.Drawing.Point(388, 162);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(348, 63);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hot Key Set Up";
            // 
            // colorEditBtn
            // 
            this.colorEditBtn.EditValue = System.Drawing.Color.Empty;
            this.colorEditBtn.Location = new System.Drawing.Point(302, 8);
            this.colorEditBtn.Name = "colorEditBtn";
            this.colorEditBtn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEditBtn.Properties.ShowCustomColors = false;
            this.colorEditBtn.Properties.ShowSystemColors = false;
            this.colorEditBtn.Size = new System.Drawing.Size(100, 24);
            this.colorEditBtn.TabIndex = 9;
            // 
            // BtnColor
            // 
            this.BtnColor.Caption = "BtnColor";
            this.BtnColor.FieldName = "BtnColor";
            this.BtnColor.Name = "BtnColor";
            // 
            // FrmTaMenuCate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 584);
            this.Controls.Add(this.lueMenuSet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.lueDeptCode);
            this.Controls.Add(this.labelControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaMenuCate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTaMenuCategory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaMenuCategory_Load);
            this.SizeChanged += new System.EventHandler(this.FrmTaMenuCate_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenuCate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMenuCate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueMenuSet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDeptCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHotKeyDishCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHotKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEditBtn.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn MenuSetID;
        private DevExpress.XtraGrid.Columns.GridColumn MenuSet;
        private DevExpress.XtraGrid.Columns.GridColumn DeptCode;
        private DevExpress.XtraGrid.Columns.GridColumn CatePosition;
        private DevExpress.XtraGrid.Columns.GridColumn CateOtherName;
        private DevExpress.XtraGrid.Columns.GridColumn CateEngName;
        private DevExpress.XtraEditors.TextEdit txtPosition;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtEngName;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMenuCate;
        private DevExpress.XtraGrid.Columns.GridColumn DeptCodeID;
        private DevExpress.XtraGrid.GridControl gridControlMenuCate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtOtherName;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtHotKeyDishCode;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.CheckEdit chkHotKey;
        private DevExpress.XtraGrid.Columns.GridColumn IsHotKey;
        private DevExpress.XtraGrid.Columns.GridColumn HotKeyDishCode;
        private DevExpress.XtraEditors.LookUpEdit lueMenuSet;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lueDeptCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnMenuSet4;
        private System.Windows.Forms.Button btnMenuSet3;
        private System.Windows.Forms.Button btnMenuSet2;
        private System.Windows.Forms.Button btnMenuSet1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private DevExpress.XtraEditors.ColorEdit colorEditBtn;
        private DevExpress.XtraGrid.Columns.GridColumn BtnColor;
    }
}