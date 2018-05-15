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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtraMenu = new DevExpress.XtraGrid.GridControl();
            this.gvExtraMenu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eMenuEngName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eMenuOtherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eMenuPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eMenuPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eMenuType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eMenuBtnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkComboType = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.chkComboBtnType = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.txtOtherName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.txtEngName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDispPosition = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExtraMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExtraMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkComboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkComboBtnType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDispPosition.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlExtraMenu);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Location = new System.Drawing.Point(13, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(546, 543);
            this.panelControl1.TabIndex = 0;
            // 
            // gridControlExtraMenu
            // 
            this.gridControlExtraMenu.Location = new System.Drawing.Point(5, 240);
            this.gridControlExtraMenu.MainView = this.gvExtraMenu;
            this.gridControlExtraMenu.Name = "gridControlExtraMenu";
            this.gridControlExtraMenu.Size = new System.Drawing.Size(524, 282);
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
            this.eMenuEngName.Caption = "English Name";
            this.eMenuEngName.FieldName = "eMenuEngName";
            this.eMenuEngName.Name = "eMenuEngName";
            this.eMenuEngName.Visible = true;
            this.eMenuEngName.VisibleIndex = 0;
            this.eMenuEngName.Width = 99;
            // 
            // eMenuOtherName
            // 
            this.eMenuOtherName.Caption = "Other Name";
            this.eMenuOtherName.FieldName = "eMenuOtherName";
            this.eMenuOtherName.Name = "eMenuOtherName";
            this.eMenuOtherName.Visible = true;
            this.eMenuOtherName.VisibleIndex = 1;
            this.eMenuOtherName.Width = 93;
            // 
            // eMenuPrice
            // 
            this.eMenuPrice.Caption = "Price";
            this.eMenuPrice.FieldName = "eMenuPrice";
            this.eMenuPrice.Name = "eMenuPrice";
            this.eMenuPrice.Visible = true;
            this.eMenuPrice.VisibleIndex = 2;
            this.eMenuPrice.Width = 47;
            // 
            // eMenuPosition
            // 
            this.eMenuPosition.Caption = "Position";
            this.eMenuPosition.FieldName = "eMenuPosition";
            this.eMenuPosition.Name = "eMenuPosition";
            this.eMenuPosition.Visible = true;
            this.eMenuPosition.VisibleIndex = 3;
            this.eMenuPosition.Width = 64;
            // 
            // eMenuType
            // 
            this.eMenuType.Caption = "Type";
            this.eMenuType.FieldName = "eMenuType";
            this.eMenuType.Name = "eMenuType";
            this.eMenuType.Visible = true;
            this.eMenuType.VisibleIndex = 4;
            this.eMenuType.Width = 71;
            // 
            // eMenuBtnName
            // 
            this.eMenuBtnName.Caption = "Button Type";
            this.eMenuBtnName.FieldName = "eMenuBtnName";
            this.eMenuBtnName.Name = "eMenuBtnName";
            this.eMenuBtnName.Visible = true;
            this.eMenuBtnName.VisibleIndex = 5;
            this.eMenuBtnName.Width = 98;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnExit);
            this.panelControl3.Controls.Add(this.btnDel);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Location = new System.Drawing.Point(5, 159);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(524, 60);
            this.panelControl3.TabIndex = 1;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(275, 17);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(95, 25);
            this.btnDel.TabIndex = 17;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(145, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 25);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 25);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.chkComboType);
            this.panelControl2.Controls.Add(this.labelControl11);
            this.panelControl2.Controls.Add(this.chkComboBtnType);
            this.panelControl2.Controls.Add(this.txtPrice);
            this.panelControl2.Controls.Add(this.labelControl14);
            this.panelControl2.Controls.Add(this.txtOtherName);
            this.panelControl2.Controls.Add(this.labelControl13);
            this.panelControl2.Controls.Add(this.txtEngName);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.txtDispPosition);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Location = new System.Drawing.Point(5, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(524, 148);
            this.panelControl2.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(328, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 18);
            this.labelControl1.TabIndex = 24;
            this.labelControl1.Text = "Type:";
            // 
            // chkComboType
            // 
            this.chkComboType.Location = new System.Drawing.Point(374, 43);
            this.chkComboType.Name = "chkComboType";
            this.chkComboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkComboType.Size = new System.Drawing.Size(139, 24);
            this.chkComboType.TabIndex = 23;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(280, 14);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(87, 18);
            this.labelControl11.TabIndex = 22;
            this.labelControl11.Text = "Button Type:";
            // 
            // chkComboBtnType
            // 
            this.chkComboBtnType.Location = new System.Drawing.Point(374, 8);
            this.chkComboBtnType.Name = "chkComboBtnType";
            this.chkComboBtnType.Properties.AllowMultiSelect = true;
            this.chkComboBtnType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkComboBtnType.Size = new System.Drawing.Size(139, 24);
            this.chkComboBtnType.TabIndex = 21;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(113, 77);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Mask.EditMask = "f";
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrice.Size = new System.Drawing.Size(147, 24);
            this.txtPrice.TabIndex = 17;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(72, 83);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(35, 18);
            this.labelControl14.TabIndex = 16;
            this.labelControl14.Text = "Price:";
            // 
            // txtOtherName
            // 
            this.txtOtherName.Location = new System.Drawing.Point(113, 42);
            this.txtOtherName.Name = "txtOtherName";
            this.txtOtherName.Size = new System.Drawing.Size(147, 24);
            this.txtOtherName.TabIndex = 15;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(21, 48);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(86, 18);
            this.labelControl13.TabIndex = 14;
            this.labelControl13.Text = "Other Name:";
            // 
            // txtEngName
            // 
            this.txtEngName.Location = new System.Drawing.Point(113, 8);
            this.txtEngName.Name = "txtEngName";
            this.txtEngName.Size = new System.Drawing.Size(147, 24);
            this.txtEngName.TabIndex = 13;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(92, 18);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "English Name:";
            // 
            // txtDispPosition
            // 
            this.txtDispPosition.Location = new System.Drawing.Point(113, 107);
            this.txtDispPosition.Name = "txtDispPosition";
            this.txtDispPosition.Properties.Mask.EditMask = "n0";
            this.txtDispPosition.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDispPosition.Size = new System.Drawing.Size(147, 24);
            this.txtDispPosition.TabIndex = 11;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(4, 113);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(103, 18);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Display Position:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(405, 17);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 25);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmTaExtraMenuEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 569);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaExtraMenuEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTaExtraMenuEdit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaExtraMenuEdit_Load);
            this.SizeChanged += new System.EventHandler(this.FrmTaExtraMenuEdit_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExtraMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExtraMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkComboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkComboBtnType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDispPosition.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
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
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkComboType;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkComboBtnType;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}