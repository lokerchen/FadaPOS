namespace SuperPOS.UI.Sys
{
    partial class FrmCompAddr
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAddrCode = new DevExpress.XtraEditors.TextEdit();
            this.txtCompName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlCompAddr = new DevExpress.XtraGrid.GridControl();
            this.gvCompAddr = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AddrCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CompName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddrCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCompAddr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCompAddr)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.xtraTabControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(528, 395);
            this.panelControl1.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(524, 391);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelControl4);
            this.xtraTabPage1.Controls.Add(this.panelControl3);
            this.xtraTabPage1.Controls.Add(this.panelControl2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(517, 355);
            this.xtraTabPage1.Text = "Computer Address";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtCompName);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.txtAddrCode);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(7, 9);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(447, 59);
            this.panelControl2.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(95, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Address Code:";
            // 
            // txtAddrCode
            // 
            this.txtAddrCode.Location = new System.Drawing.Point(108, 21);
            this.txtAddrCode.Name = "txtAddrCode";
            this.txtAddrCode.Size = new System.Drawing.Size(100, 24);
            this.txtAddrCode.TabIndex = 1;
            // 
            // txtCompName
            // 
            this.txtCompName.Location = new System.Drawing.Point(338, 21);
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(100, 24);
            this.txtCompName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(224, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(113, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Computer Name:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(28, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(183, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(338, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnDelete);
            this.panelControl3.Location = new System.Drawing.Point(7, 74);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(447, 40);
            this.panelControl3.TabIndex = 7;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.gridControlCompAddr);
            this.panelControl4.Location = new System.Drawing.Point(7, 120);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(447, 210);
            this.panelControl4.TabIndex = 8;
            // 
            // gridControlCompAddr
            // 
            this.gridControlCompAddr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCompAddr.Location = new System.Drawing.Point(2, 2);
            this.gridControlCompAddr.MainView = this.gvCompAddr;
            this.gridControlCompAddr.Name = "gridControlCompAddr";
            this.gridControlCompAddr.Size = new System.Drawing.Size(443, 206);
            this.gridControlCompAddr.TabIndex = 0;
            this.gridControlCompAddr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCompAddr});
            // 
            // gvCompAddr
            // 
            this.gvCompAddr.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvCompAddr.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvCompAddr.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvCompAddr.Appearance.OddRow.Options.UseBackColor = true;
            this.gvCompAddr.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.AddrCode,
            this.CompName});
            this.gvCompAddr.GridControl = this.gridControlCompAddr;
            this.gvCompAddr.IndicatorWidth = 50;
            this.gvCompAddr.Name = "gvCompAddr";
            this.gvCompAddr.OptionsBehavior.Editable = false;
            this.gvCompAddr.OptionsMenu.EnableColumnMenu = false;
            this.gvCompAddr.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvCompAddr.OptionsView.EnableAppearanceEvenRow = true;
            this.gvCompAddr.OptionsView.EnableAppearanceOddRow = true;
            this.gvCompAddr.OptionsView.ShowGroupPanel = false;
            this.gvCompAddr.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvCompAddr_CustomDrawRowIndicator);
            this.gvCompAddr.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCompAddr_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // AddrCode
            // 
            this.AddrCode.Caption = "Address Code";
            this.AddrCode.FieldName = "AddrCode";
            this.AddrCode.Name = "AddrCode";
            this.AddrCode.Visible = true;
            this.AddrCode.VisibleIndex = 0;
            // 
            // CompName
            // 
            this.CompName.Caption = "Computer Name";
            this.CompName.FieldName = "CompName";
            this.CompName.Name = "CompName";
            this.CompName.Visible = true;
            this.CompName.VisibleIndex = 1;
            // 
            // FrmCompAddr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 395);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCompAddr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Computer Address";
            this.Load += new System.EventHandler(this.FrmCompAddr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddrCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCompAddr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCompAddr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtCompName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtAddrCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraGrid.GridControl gridControlCompAddr;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCompAddr;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn AddrCode;
        private DevExpress.XtraGrid.Columns.GridColumn CompName;
    }
}