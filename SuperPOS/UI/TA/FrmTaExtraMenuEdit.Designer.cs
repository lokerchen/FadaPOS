namespace SuperPOS.UI.TA
{
    partial class FrmTaExtraMenuEdit
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
            this.gridControlExtraMenu = new DevExpress.XtraGrid.GridControl();
            this.gvExtraMenu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eMenuEngName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eMenuOtherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eMenuPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eMenuPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eMenuType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eMenuBtnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.txtOtherName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.txtEngName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDispPosition = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtMenuType = new DevExpress.XtraEditors.TextEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnTasteItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnDrinkItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnTi0 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTi1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTi2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTi5 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTi4 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTi3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTi9 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTi8 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTi7 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTi6 = new DevExpress.XtraEditors.SimpleButton();
            this.btnKeyBoard = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExtraMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExtraMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDispPosition.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuType.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlExtraMenu
            // 
            this.gridControlExtraMenu.Location = new System.Drawing.Point(355, 115);
            this.gridControlExtraMenu.MainView = this.gvExtraMenu;
            this.gridControlExtraMenu.Name = "gridControlExtraMenu";
            this.gridControlExtraMenu.Size = new System.Drawing.Size(364, 448);
            this.gridControlExtraMenu.TabIndex = 14;
            this.gridControlExtraMenu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvExtraMenu});
            // 
            // gvExtraMenu
            // 
            this.gvExtraMenu.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvExtraMenu.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvExtraMenu.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvExtraMenu.Appearance.OddRow.Options.UseBackColor = true;
            this.gvExtraMenu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.eMenuEngName,
            this.eMenuOtherName,
            this.eMenuPrice,
            this.eMenuPosition,
            this.eMenuType,
            this.eMenuBtnName});
            this.gvExtraMenu.GridControl = this.gridControlExtraMenu;
            this.gvExtraMenu.IndicatorWidth = 50;
            this.gvExtraMenu.Name = "gvExtraMenu";
            this.gvExtraMenu.OptionsBehavior.Editable = false;
            this.gvExtraMenu.OptionsMenu.EnableColumnMenu = false;
            this.gvExtraMenu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvExtraMenu.OptionsView.EnableAppearanceEvenRow = true;
            this.gvExtraMenu.OptionsView.EnableAppearanceOddRow = true;
            this.gvExtraMenu.OptionsView.ShowGroupPanel = false;
            this.gvExtraMenu.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvExtraMenu_CustomDrawRowIndicator);
            this.gvExtraMenu.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvExtraMenu_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // eMenuEngName
            // 
            this.eMenuEngName.Caption = "Item Name";
            this.eMenuEngName.FieldName = "eMenuEngName";
            this.eMenuEngName.Name = "eMenuEngName";
            this.eMenuEngName.Visible = true;
            this.eMenuEngName.VisibleIndex = 0;
            this.eMenuEngName.Width = 168;
            // 
            // eMenuOtherName
            // 
            this.eMenuOtherName.Caption = "Other Name";
            this.eMenuOtherName.FieldName = "eMenuOtherName";
            this.eMenuOtherName.Name = "eMenuOtherName";
            this.eMenuOtherName.Width = 93;
            // 
            // eMenuPrice
            // 
            this.eMenuPrice.Caption = "Price";
            this.eMenuPrice.FieldName = "eMenuPrice";
            this.eMenuPrice.Name = "eMenuPrice";
            this.eMenuPrice.Visible = true;
            this.eMenuPrice.VisibleIndex = 1;
            this.eMenuPrice.Width = 118;
            // 
            // eMenuPosition
            // 
            this.eMenuPosition.Caption = "Position";
            this.eMenuPosition.FieldName = "eMenuPosition";
            this.eMenuPosition.Name = "eMenuPosition";
            this.eMenuPosition.Width = 64;
            // 
            // eMenuType
            // 
            this.eMenuType.Caption = "Type";
            this.eMenuType.FieldName = "eMenuType";
            this.eMenuType.Name = "eMenuType";
            this.eMenuType.Width = 71;
            // 
            // eMenuBtnName
            // 
            this.eMenuBtnName.Caption = "Button Type";
            this.eMenuBtnName.FieldName = "eMenuBtnName";
            this.eMenuBtnName.Name = "eMenuBtnName";
            this.eMenuBtnName.Width = 98;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Appearance.Options.UseForeColor = true;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExit.Location = new System.Drawing.Point(725, 584);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(135, 64);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Appearance.BackColor = System.Drawing.Color.Orange;
            this.btnDel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDel.Appearance.Options.UseBackColor = true;
            this.btnDel.Appearance.Options.UseForeColor = true;
            this.btnDel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnDel.Location = new System.Drawing.Point(190, 318);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 55);
            this.btnDel.TabIndex = 17;
            this.btnDel.Text = "Cancel";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.Orange;
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnSave.Location = new System.Drawing.Point(107, 318);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 55);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.BackColor = System.Drawing.Color.Orange;
            this.btnAdd.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Appearance.Options.UseBackColor = true;
            this.btnAdd.Appearance.Options.UseForeColor = true;
            this.btnAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnAdd.Location = new System.Drawing.Point(15, 318);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 55);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add New";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(15, 194);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Mask.EditMask = "f";
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrice.Size = new System.Drawing.Size(169, 24);
            this.txtPrice.TabIndex = 17;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(15, 170);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(35, 18);
            this.labelControl14.TabIndex = 16;
            this.labelControl14.Text = "Price:";
            // 
            // txtOtherName
            // 
            this.txtOtherName.Location = new System.Drawing.Point(15, 122);
            this.txtOtherName.Name = "txtOtherName";
            this.txtOtherName.Size = new System.Drawing.Size(169, 24);
            this.txtOtherName.TabIndex = 15;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(15, 98);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(86, 18);
            this.labelControl13.TabIndex = 14;
            this.labelControl13.Text = "Other Name:";
            // 
            // txtEngName
            // 
            this.txtEngName.Location = new System.Drawing.Point(14, 55);
            this.txtEngName.Name = "txtEngName";
            this.txtEngName.Size = new System.Drawing.Size(170, 24);
            this.txtEngName.TabIndex = 13;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 31);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(87, 18);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "English Name";
            // 
            // txtDispPosition
            // 
            this.txtDispPosition.Location = new System.Drawing.Point(15, 264);
            this.txtDispPosition.Name = "txtDispPosition";
            this.txtDispPosition.Properties.Mask.EditMask = "n0";
            this.txtDispPosition.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDispPosition.Size = new System.Drawing.Size(169, 24);
            this.txtDispPosition.TabIndex = 11;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 240);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(103, 18);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Display Position:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTi9);
            this.groupBox1.Controls.Add(this.btnTi8);
            this.groupBox1.Controls.Add(this.btnTi7);
            this.groupBox1.Controls.Add(this.btnTi6);
            this.groupBox1.Controls.Add(this.btnTi5);
            this.groupBox1.Controls.Add(this.btnTi4);
            this.groupBox1.Controls.Add(this.btnTi3);
            this.groupBox1.Controls.Add(this.btnTi2);
            this.groupBox1.Controls.Add(this.btnTi1);
            this.groupBox1.Controls.Add(this.btnTi0);
            this.groupBox1.Controls.Add(this.gridControlExtraMenu);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.panelControl4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtMenuType);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(866, 657);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extra Menu Edit";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(20, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(87, 18);
            this.labelControl4.TabIndex = 25;
            this.labelControl4.Text = "Button Name";
            // 
            // txtMenuType
            // 
            this.txtMenuType.Enabled = false;
            this.txtMenuType.Location = new System.Drawing.Point(20, 73);
            this.txtMenuType.Name = "txtMenuType";
            this.txtMenuType.Size = new System.Drawing.Size(170, 24);
            this.txtMenuType.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKeyBoard);
            this.groupBox2.Controls.Add(this.txtEngName);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtDispPosition);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.labelControl3);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.labelControl13);
            this.groupBox2.Controls.Add(this.labelControl14);
            this.groupBox2.Controls.Add(this.txtOtherName);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox2.Location = new System.Drawing.Point(6, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 460);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit Item";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.btnDrinkItem);
            this.panelControl4.Controls.Add(this.btnTasteItem);
            this.panelControl4.Location = new System.Drawing.Point(541, 19);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(319, 62);
            this.panelControl4.TabIndex = 25;
            // 
            // btnTasteItem
            // 
            this.btnTasteItem.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTasteItem.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTasteItem.Appearance.Options.UseBackColor = true;
            this.btnTasteItem.Appearance.Options.UseForeColor = true;
            this.btnTasteItem.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTasteItem.Location = new System.Drawing.Point(23, 12);
            this.btnTasteItem.Name = "btnTasteItem";
            this.btnTasteItem.Size = new System.Drawing.Size(86, 40);
            this.btnTasteItem.TabIndex = 18;
            this.btnTasteItem.Text = "Taste Item";
            this.btnTasteItem.Click += new System.EventHandler(this.btnTasteItem_Click);
            // 
            // btnDrinkItem
            // 
            this.btnDrinkItem.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDrinkItem.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDrinkItem.Appearance.Options.UseBackColor = true;
            this.btnDrinkItem.Appearance.Options.UseForeColor = true;
            this.btnDrinkItem.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnDrinkItem.Location = new System.Drawing.Point(171, 12);
            this.btnDrinkItem.Name = "btnDrinkItem";
            this.btnDrinkItem.Size = new System.Drawing.Size(86, 40);
            this.btnDrinkItem.TabIndex = 19;
            this.btnDrinkItem.Text = "Drink Item";
            this.btnDrinkItem.Click += new System.EventHandler(this.btnDrinkItem_Click);
            // 
            // btnTi0
            // 
            this.btnTi0.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTi0.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTi0.Appearance.Options.UseBackColor = true;
            this.btnTi0.Appearance.Options.UseForeColor = true;
            this.btnTi0.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTi0.Location = new System.Drawing.Point(725, 115);
            this.btnTi0.Name = "btnTi0";
            this.btnTi0.Size = new System.Drawing.Size(135, 40);
            this.btnTi0.TabIndex = 20;
            this.btnTi0.Text = "Taste Item";
            // 
            // btnTi1
            // 
            this.btnTi1.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTi1.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTi1.Appearance.Options.UseBackColor = true;
            this.btnTi1.Appearance.Options.UseForeColor = true;
            this.btnTi1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTi1.Location = new System.Drawing.Point(725, 160);
            this.btnTi1.Name = "btnTi1";
            this.btnTi1.Size = new System.Drawing.Size(135, 40);
            this.btnTi1.TabIndex = 27;
            this.btnTi1.Text = "Taste Item";
            // 
            // btnTi2
            // 
            this.btnTi2.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTi2.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTi2.Appearance.Options.UseBackColor = true;
            this.btnTi2.Appearance.Options.UseForeColor = true;
            this.btnTi2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTi2.Location = new System.Drawing.Point(725, 205);
            this.btnTi2.Name = "btnTi2";
            this.btnTi2.Size = new System.Drawing.Size(135, 40);
            this.btnTi2.TabIndex = 28;
            this.btnTi2.Text = "Taste Item";
            // 
            // btnTi5
            // 
            this.btnTi5.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTi5.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTi5.Appearance.Options.UseBackColor = true;
            this.btnTi5.Appearance.Options.UseForeColor = true;
            this.btnTi5.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTi5.Location = new System.Drawing.Point(725, 341);
            this.btnTi5.Name = "btnTi5";
            this.btnTi5.Size = new System.Drawing.Size(135, 40);
            this.btnTi5.TabIndex = 31;
            this.btnTi5.Text = "Taste Item";
            // 
            // btnTi4
            // 
            this.btnTi4.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTi4.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTi4.Appearance.Options.UseBackColor = true;
            this.btnTi4.Appearance.Options.UseForeColor = true;
            this.btnTi4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTi4.Location = new System.Drawing.Point(725, 296);
            this.btnTi4.Name = "btnTi4";
            this.btnTi4.Size = new System.Drawing.Size(135, 40);
            this.btnTi4.TabIndex = 30;
            this.btnTi4.Text = "Taste Item";
            // 
            // btnTi3
            // 
            this.btnTi3.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTi3.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTi3.Appearance.Options.UseBackColor = true;
            this.btnTi3.Appearance.Options.UseForeColor = true;
            this.btnTi3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTi3.Location = new System.Drawing.Point(725, 251);
            this.btnTi3.Name = "btnTi3";
            this.btnTi3.Size = new System.Drawing.Size(135, 40);
            this.btnTi3.TabIndex = 29;
            this.btnTi3.Text = "Taste Item";
            // 
            // btnTi9
            // 
            this.btnTi9.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTi9.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTi9.Appearance.Options.UseBackColor = true;
            this.btnTi9.Appearance.Options.UseForeColor = true;
            this.btnTi9.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTi9.Location = new System.Drawing.Point(725, 523);
            this.btnTi9.Name = "btnTi9";
            this.btnTi9.Size = new System.Drawing.Size(135, 40);
            this.btnTi9.TabIndex = 35;
            this.btnTi9.Text = "Taste Item";
            // 
            // btnTi8
            // 
            this.btnTi8.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTi8.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTi8.Appearance.Options.UseBackColor = true;
            this.btnTi8.Appearance.Options.UseForeColor = true;
            this.btnTi8.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTi8.Location = new System.Drawing.Point(725, 478);
            this.btnTi8.Name = "btnTi8";
            this.btnTi8.Size = new System.Drawing.Size(135, 40);
            this.btnTi8.TabIndex = 34;
            this.btnTi8.Text = "Taste Item";
            // 
            // btnTi7
            // 
            this.btnTi7.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTi7.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTi7.Appearance.Options.UseBackColor = true;
            this.btnTi7.Appearance.Options.UseForeColor = true;
            this.btnTi7.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTi7.Location = new System.Drawing.Point(725, 433);
            this.btnTi7.Name = "btnTi7";
            this.btnTi7.Size = new System.Drawing.Size(135, 40);
            this.btnTi7.TabIndex = 33;
            this.btnTi7.Text = "Taste Item";
            // 
            // btnTi6
            // 
            this.btnTi6.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTi6.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTi6.Appearance.Options.UseBackColor = true;
            this.btnTi6.Appearance.Options.UseForeColor = true;
            this.btnTi6.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTi6.Location = new System.Drawing.Point(725, 387);
            this.btnTi6.Name = "btnTi6";
            this.btnTi6.Size = new System.Drawing.Size(135, 40);
            this.btnTi6.TabIndex = 32;
            this.btnTi6.Text = "Taste Item";
            // 
            // btnKeyBoard
            // 
            this.btnKeyBoard.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnKeyBoard.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKeyBoard.Appearance.Options.UseBackColor = true;
            this.btnKeyBoard.Appearance.Options.UseForeColor = true;
            this.btnKeyBoard.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnKeyBoard.Location = new System.Drawing.Point(15, 379);
            this.btnKeyBoard.Name = "btnKeyBoard";
            this.btnKeyBoard.Size = new System.Drawing.Size(250, 55);
            this.btnKeyBoard.TabIndex = 18;
            this.btnKeyBoard.Text = "KeyBoard";
            this.btnKeyBoard.Click += new System.EventHandler(this.btnKeyBoard_Click);
            // 
            // FrmTaExtraMenuEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 668);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaExtraMenuEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTaExtraMenuEdit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaExtraMenuEdit_Load);
            this.SizeChanged += new System.EventHandler(this.FrmTaExtraMenuEdit_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExtraMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExtraMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDispPosition.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuType.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControlExtraMenu;
        private DevExpress.XtraGrid.Views.Grid.GridView gvExtraMenu;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn eMenuPosition;
        private DevExpress.XtraGrid.Columns.GridColumn eMenuEngName;
        private DevExpress.XtraGrid.Columns.GridColumn eMenuOtherName;
        private DevExpress.XtraGrid.Columns.GridColumn eMenuPrice;
        private DevExpress.XtraGrid.Columns.GridColumn eMenuType;
        private DevExpress.XtraGrid.Columns.GridColumn eMenuBtnName;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.TextEdit txtOtherName;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit txtEngName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDispPosition;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.TextEdit txtMenuType;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton btnDrinkItem;
        private DevExpress.XtraEditors.SimpleButton btnTasteItem;
        private DevExpress.XtraEditors.SimpleButton btnTi0;
        private DevExpress.XtraEditors.SimpleButton btnTi9;
        private DevExpress.XtraEditors.SimpleButton btnTi8;
        private DevExpress.XtraEditors.SimpleButton btnTi7;
        private DevExpress.XtraEditors.SimpleButton btnTi6;
        private DevExpress.XtraEditors.SimpleButton btnTi5;
        private DevExpress.XtraEditors.SimpleButton btnTi4;
        private DevExpress.XtraEditors.SimpleButton btnTi3;
        private DevExpress.XtraEditors.SimpleButton btnTi2;
        private DevExpress.XtraEditors.SimpleButton btnTi1;
        private DevExpress.XtraEditors.SimpleButton btnKeyBoard;
    }
}