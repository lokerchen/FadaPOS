namespace SuperPOS.UI.TA
{
    partial class FrmTaMenuItemDetail
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
            this.xtcOtherChoice = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageSecond = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageThird = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageTasteHandle = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.chkEditEnableChoice = new DevExpress.XtraEditors.CheckEdit();
            this.chkEditAppend = new DevExpress.XtraEditors.CheckEdit();
            this.txtAddPrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtOtherName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtEngName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControlOtherChoice = new DevExpress.XtraGrid.GridControl();
            this.gvOtherChoice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiEngName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiOtherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MiPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsAutoAppend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsEnableChoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MenuItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MenuItemType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtcOtherChoice)).BeginInit();
            this.xtcOtherChoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditEnableChoice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditAppend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOtherChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOtherChoice)).BeginInit();
            this.SuspendLayout();
            // 
            // xtcOtherChoice
            // 
            this.xtcOtherChoice.Location = new System.Drawing.Point(5, 5);
            this.xtcOtherChoice.Name = "xtcOtherChoice";
            this.xtcOtherChoice.SelectedTabPage = this.xtraTabPageSecond;
            this.xtcOtherChoice.Size = new System.Drawing.Size(363, 35);
            this.xtcOtherChoice.TabIndex = 0;
            this.xtcOtherChoice.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageSecond,
            this.xtraTabPageThird,
            this.xtraTabPageTasteHandle});
            this.xtcOtherChoice.Selected += new DevExpress.XtraTab.TabPageEventHandler(this.xtcOtherChoice_Selected);
            // 
            // xtraTabPageSecond
            // 
            this.xtraTabPageSecond.Name = "xtraTabPageSecond";
            this.xtraTabPageSecond.Size = new System.Drawing.Size(356, 0);
            this.xtraTabPageSecond.Text = "Second Choices";
            // 
            // xtraTabPageThird
            // 
            this.xtraTabPageThird.Name = "xtraTabPageThird";
            this.xtraTabPageThird.Size = new System.Drawing.Size(356, 0);
            this.xtraTabPageThird.Text = "Third Choices";
            // 
            // xtraTabPageTasteHandle
            // 
            this.xtraTabPageTasteHandle.Name = "xtraTabPageTasteHandle";
            this.xtraTabPageTasteHandle.Size = new System.Drawing.Size(356, 0);
            this.xtraTabPageTasteHandle.Text = "Taste Handling";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.xtcOtherChoice);
            this.panelControl1.Location = new System.Drawing.Point(4, 6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(542, 496);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Controls.Add(this.gridControlOtherChoice);
            this.panelControl2.Location = new System.Drawing.Point(5, 36);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(522, 449);
            this.panelControl2.TabIndex = 4;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.btnExit);
            this.panelControl4.Controls.Add(this.btnDel);
            this.panelControl4.Controls.Add(this.btnSave);
            this.panelControl4.Controls.Add(this.btnAdd);
            this.panelControl4.Location = new System.Drawing.Point(7, 395);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(510, 48);
            this.panelControl4.TabIndex = 5;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(272, 12);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(95, 25);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(142, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.chkEditEnableChoice);
            this.panelControl3.Controls.Add(this.chkEditAppend);
            this.panelControl3.Controls.Add(this.txtAddPrice);
            this.panelControl3.Controls.Add(this.labelControl3);
            this.panelControl3.Controls.Add(this.txtOtherName);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.txtEngName);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Location = new System.Drawing.Point(5, 5);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(510, 114);
            this.panelControl3.TabIndex = 4;
            // 
            // chkEditEnableChoice
            // 
            this.chkEditEnableChoice.Location = new System.Drawing.Point(360, 51);
            this.chkEditEnableChoice.Name = "chkEditEnableChoice";
            this.chkEditEnableChoice.Properties.Caption = "Enable Choice";
            this.chkEditEnableChoice.Size = new System.Drawing.Size(118, 22);
            this.chkEditEnableChoice.TabIndex = 7;
            // 
            // chkEditAppend
            // 
            this.chkEditAppend.Location = new System.Drawing.Point(360, 16);
            this.chkEditAppend.Name = "chkEditAppend";
            this.chkEditAppend.Properties.Caption = "Auto Append";
            this.chkEditAppend.Size = new System.Drawing.Size(118, 22);
            this.chkEditAppend.TabIndex = 6;
            // 
            // txtAddPrice
            // 
            this.txtAddPrice.Location = new System.Drawing.Point(123, 82);
            this.txtAddPrice.Name = "txtAddPrice";
            this.txtAddPrice.Properties.Mask.EditMask = "f2";
            this.txtAddPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAddPrice.Size = new System.Drawing.Size(127, 24);
            this.txtAddPrice.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(52, 88);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(65, 18);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Add Price:";
            // 
            // txtOtherName
            // 
            this.txtOtherName.Location = new System.Drawing.Point(123, 47);
            this.txtOtherName.Name = "txtOtherName";
            this.txtOtherName.Size = new System.Drawing.Size(127, 24);
            this.txtOtherName.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 18);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Other Name:";
            // 
            // txtEngName
            // 
            this.txtEngName.Location = new System.Drawing.Point(123, 12);
            this.txtEngName.Name = "txtEngName";
            this.txtEngName.Size = new System.Drawing.Size(127, 24);
            this.txtEngName.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 18);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "English Name:";
            // 
            // gridControlOtherChoice
            // 
            this.gridControlOtherChoice.Location = new System.Drawing.Point(7, 125);
            this.gridControlOtherChoice.MainView = this.gvOtherChoice;
            this.gridControlOtherChoice.Name = "gridControlOtherChoice";
            this.gridControlOtherChoice.Size = new System.Drawing.Size(510, 264);
            this.gridControlOtherChoice.TabIndex = 3;
            this.gridControlOtherChoice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOtherChoice});
            // 
            // gvOtherChoice
            // 
            this.gvOtherChoice.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvOtherChoice.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvOtherChoice.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvOtherChoice.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvOtherChoice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.MiEngName,
            this.MiOtherName,
            this.MiPrice,
            this.IsAutoAppend,
            this.IsEnableChoice,
            this.MenuItemID,
            this.MenuItemType});
            this.gvOtherChoice.GridControl = this.gridControlOtherChoice;
            this.gvOtherChoice.IndicatorWidth = 40;
            this.gvOtherChoice.Name = "gvOtherChoice";
            this.gvOtherChoice.OptionsBehavior.Editable = false;
            this.gvOtherChoice.OptionsMenu.EnableColumnMenu = false;
            this.gvOtherChoice.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvOtherChoice.OptionsView.EnableAppearanceEvenRow = true;
            this.gvOtherChoice.OptionsView.EnableAppearanceOddRow = true;
            this.gvOtherChoice.OptionsView.ShowGroupPanel = false;
            this.gvOtherChoice.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvOtherChoice_CustomDrawRowIndicator);
            this.gvOtherChoice.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvOtherChoice_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // MiEngName
            // 
            this.MiEngName.Caption = "English Name";
            this.MiEngName.FieldName = "MiEngName";
            this.MiEngName.Name = "MiEngName";
            this.MiEngName.Visible = true;
            this.MiEngName.VisibleIndex = 0;
            // 
            // MiOtherName
            // 
            this.MiOtherName.Caption = "Other Name";
            this.MiOtherName.FieldName = "MiOtherName";
            this.MiOtherName.Name = "MiOtherName";
            this.MiOtherName.Visible = true;
            this.MiOtherName.VisibleIndex = 1;
            // 
            // MiPrice
            // 
            this.MiPrice.Caption = "Add Price";
            this.MiPrice.FieldName = "MiPrice";
            this.MiPrice.Name = "MiPrice";
            this.MiPrice.Visible = true;
            this.MiPrice.VisibleIndex = 2;
            // 
            // IsAutoAppend
            // 
            this.IsAutoAppend.Caption = "Auto Append";
            this.IsAutoAppend.FieldName = "IsAutoAppend";
            this.IsAutoAppend.Name = "IsAutoAppend";
            this.IsAutoAppend.Visible = true;
            this.IsAutoAppend.VisibleIndex = 3;
            // 
            // IsEnableChoice
            // 
            this.IsEnableChoice.Caption = "Enable Choices";
            this.IsEnableChoice.FieldName = "IsEnableChoice";
            this.IsEnableChoice.Name = "IsEnableChoice";
            this.IsEnableChoice.Visible = true;
            this.IsEnableChoice.VisibleIndex = 4;
            // 
            // MenuItemID
            // 
            this.MenuItemID.Caption = "MenuItemID";
            this.MenuItemID.FieldName = "MenuItemID";
            this.MenuItemID.Name = "MenuItemID";
            // 
            // MenuItemType
            // 
            this.MenuItemType.Caption = "MenuItemType";
            this.MenuItemType.FieldName = "MenuItemType";
            this.MenuItemType.Name = "MenuItemType";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(402, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 25);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmTaMenuItemDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 576);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaMenuItemDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTaMenuItemDetail";
            this.Load += new System.EventHandler(this.FrmTaMenuItemDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtcOtherChoice)).EndInit();
            this.xtcOtherChoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditEnableChoice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditAppend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOtherChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOtherChoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtcOtherChoice;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageSecond;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageThird;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageTasteHandle;
        private DevExpress.XtraGrid.GridControl gridControlOtherChoice;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOtherChoice;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn MiEngName;
        private DevExpress.XtraGrid.Columns.GridColumn MiOtherName;
        private DevExpress.XtraGrid.Columns.GridColumn MiPrice;
        private DevExpress.XtraGrid.Columns.GridColumn IsAutoAppend;
        private DevExpress.XtraGrid.Columns.GridColumn IsEnableChoice;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.CheckEdit chkEditAppend;
        private DevExpress.XtraEditors.TextEdit txtAddPrice;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtOtherName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtEngName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkEditEnableChoice;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn MenuItemID;
        private DevExpress.XtraGrid.Columns.GridColumn MenuItemType;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}