namespace SuperPOS.UI.Sys
{
    partial class FrmUsrAuthRule
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
            this.xtcOtherChoice = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageTakeaway = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageQuickFood = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageEatIn = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageGeneral = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlAccess = new DevExpress.XtraGrid.GridControl();
            this.gvAccess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AccessDept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AccessDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AccessBtnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsAccess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lueAuthGrp = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtcOtherChoice)).BeginInit();
            this.xtcOtherChoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAuthGrp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lueAuthGrp);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.xtcOtherChoice);
            this.panelControl1.Controls.Add(this.gridControlAccess);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(22, 13);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(551, 474);
            this.panelControl1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(359, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 27);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // xtcOtherChoice
            // 
            this.xtcOtherChoice.Location = new System.Drawing.Point(14, 45);
            this.xtcOtherChoice.Name = "xtcOtherChoice";
            this.xtcOtherChoice.SelectedTabPage = this.xtraTabPageTakeaway;
            this.xtcOtherChoice.Size = new System.Drawing.Size(527, 35);
            this.xtcOtherChoice.TabIndex = 4;
            this.xtcOtherChoice.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageTakeaway,
            this.xtraTabPageQuickFood,
            this.xtraTabPageEatIn,
            this.xtraTabPageGeneral});
            this.xtcOtherChoice.Selected += new DevExpress.XtraTab.TabPageEventHandler(this.xtcOtherChoice_Selected);
            // 
            // xtraTabPageTakeaway
            // 
            this.xtraTabPageTakeaway.Name = "xtraTabPageTakeaway";
            this.xtraTabPageTakeaway.Size = new System.Drawing.Size(520, 0);
            this.xtraTabPageTakeaway.Text = "Takeaway Access";
            // 
            // xtraTabPageQuickFood
            // 
            this.xtraTabPageQuickFood.Name = "xtraTabPageQuickFood";
            this.xtraTabPageQuickFood.Size = new System.Drawing.Size(520, 0);
            this.xtraTabPageQuickFood.Text = "Quick Food Access";
            // 
            // xtraTabPageEatIn
            // 
            this.xtraTabPageEatIn.Name = "xtraTabPageEatIn";
            this.xtraTabPageEatIn.Size = new System.Drawing.Size(520, 0);
            this.xtraTabPageEatIn.Text = "Eat In Access";
            // 
            // xtraTabPageGeneral
            // 
            this.xtraTabPageGeneral.Name = "xtraTabPageGeneral";
            this.xtraTabPageGeneral.Size = new System.Drawing.Size(520, 0);
            this.xtraTabPageGeneral.Text = "General Access";
            // 
            // gridControlAccess
            // 
            this.gridControlAccess.Location = new System.Drawing.Point(15, 80);
            this.gridControlAccess.MainView = this.gvAccess;
            this.gridControlAccess.Name = "gridControlAccess";
            this.gridControlAccess.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4});
            this.gridControlAccess.Size = new System.Drawing.Size(520, 383);
            this.gridControlAccess.TabIndex = 3;
            this.gridControlAccess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAccess});
            // 
            // gvAccess
            // 
            this.gvAccess.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvAccess.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvAccess.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvAccess.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvAccess.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.GrpID,
            this.AccessDept,
            this.AccessDetail,
            this.AccessBtnID,
            this.IsAccess});
            this.gvAccess.GridControl = this.gridControlAccess;
            this.gvAccess.IndicatorWidth = 50;
            this.gvAccess.Name = "gvAccess";
            this.gvAccess.OptionsMenu.EnableColumnMenu = false;
            this.gvAccess.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvAccess.OptionsSelection.MultiSelect = true;
            this.gvAccess.OptionsView.EnableAppearanceEvenRow = true;
            this.gvAccess.OptionsView.EnableAppearanceOddRow = true;
            this.gvAccess.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // GrpID
            // 
            this.GrpID.Caption = "GrpID";
            this.GrpID.FieldName = "GrpID";
            this.GrpID.Name = "GrpID";
            // 
            // AccessDept
            // 
            this.AccessDept.Caption = "AccessDept";
            this.AccessDept.FieldName = "AccessDept";
            this.AccessDept.Name = "AccessDept";
            // 
            // AccessDetail
            // 
            this.AccessDetail.Caption = "Access Detail";
            this.AccessDetail.FieldName = "AccessDetail";
            this.AccessDetail.Name = "AccessDetail";
            this.AccessDetail.Visible = true;
            this.AccessDetail.VisibleIndex = 0;
            // 
            // AccessBtnID
            // 
            this.AccessBtnID.Caption = "AccessBtnID";
            this.AccessBtnID.FieldName = "AccessBtnID";
            this.AccessBtnID.Name = "AccessBtnID";
            // 
            // IsAccess
            // 
            this.IsAccess.Caption = "Check";
            this.IsAccess.ColumnEdit = this.repositoryItemCheckEdit4;
            this.IsAccess.FieldName = "IsAccess";
            this.IsAccess.Name = "IsAccess";
            this.IsAccess.Visible = true;
            this.IsAccess.VisibleIndex = 1;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(29, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(107, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Authority Group:";
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            this.repositoryItemCheckEdit4.ValueChecked = "1";
            this.repositoryItemCheckEdit4.ValueUnchecked = "0";
            // 
            // lueAuthGrp
            // 
            this.lueAuthGrp.Location = new System.Drawing.Point(142, 12);
            this.lueAuthGrp.Name = "lueAuthGrp";
            this.lueAuthGrp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAuthGrp.Size = new System.Drawing.Size(211, 24);
            this.lueAuthGrp.TabIndex = 1;
            this.lueAuthGrp.EditValueChanged += new System.EventHandler(this.lueAuthGrp_EditValueChanged);
            // 
            // FrmUsrAuthRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 503);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUsrAuthRule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmUsrAuthRule";
            this.Load += new System.EventHandler(this.FrmUsrAuthRule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtcOtherChoice)).EndInit();
            this.xtcOtherChoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAuthGrp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControlAccess;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAccess;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn AccessDetail;
        private DevExpress.XtraGrid.Columns.GridColumn IsAccess;
        private DevExpress.XtraTab.XtraTabControl xtcOtherChoice;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageTakeaway;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageQuickFood;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageEatIn;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageGeneral;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn GrpID;
        private DevExpress.XtraGrid.Columns.GridColumn AccessDept;
        private DevExpress.XtraGrid.Columns.GridColumn AccessBtnID;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraEditors.LookUpEdit lueAuthGrp;
    }
}