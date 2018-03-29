namespace SuperPOS.UI.Sys
{
    partial class FrmUsrAuthGrp
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
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEngName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtOtherName = new DevExpress.XtraEditors.TextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlUsrAuthGrp = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvUsrAuthGrp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrpEngName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrpOtherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUsrAuthGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsrAuthGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.txtOtherName);
            this.panelControl4.Controls.Add(this.labelControl2);
            this.panelControl4.Controls.Add(this.txtEngName);
            this.panelControl4.Controls.Add(this.labelControl1);
            this.panelControl4.Location = new System.Drawing.Point(5, 5);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(436, 97);
            this.panelControl4.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(199, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Authority Group English Name:";
            // 
            // txtEngName
            // 
            this.txtEngName.Location = new System.Drawing.Point(212, 15);
            this.txtEngName.Name = "txtEngName";
            this.txtEngName.Size = new System.Drawing.Size(219, 24);
            this.txtEngName.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 63);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(193, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Authority Group Other Name:";
            // 
            // txtOtherName
            // 
            this.txtOtherName.Location = new System.Drawing.Point(212, 60);
            this.txtOtherName.Name = "txtOtherName";
            this.txtOtherName.Size = new System.Drawing.Size(219, 24);
            this.txtOtherName.TabIndex = 3;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnDel);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Location = new System.Drawing.Point(5, 108);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(436, 48);
            this.panelControl3.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(31, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(171, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(311, 14);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(95, 25);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // gridControlUsrAuthGrp
            // 
            this.gridControlUsrAuthGrp.Location = new System.Drawing.Point(5, 162);
            this.gridControlUsrAuthGrp.MainView = this.gvUsrAuthGrp;
            this.gridControlUsrAuthGrp.Name = "gridControlUsrAuthGrp";
            this.gridControlUsrAuthGrp.Size = new System.Drawing.Size(436, 307);
            this.gridControlUsrAuthGrp.TabIndex = 2;
            this.gridControlUsrAuthGrp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUsrAuthGrp});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlUsrAuthGrp;
            this.gridView1.Name = "gridView1";
            // 
            // gvUsrAuthGrp
            // 
            this.gvUsrAuthGrp.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvUsrAuthGrp.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvUsrAuthGrp.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvUsrAuthGrp.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvUsrAuthGrp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.GrpEngName,
            this.GrpOtherName});
            this.gvUsrAuthGrp.GridControl = this.gridControlUsrAuthGrp;
            this.gvUsrAuthGrp.IndicatorWidth = 50;
            this.gvUsrAuthGrp.Name = "gvUsrAuthGrp";
            this.gvUsrAuthGrp.OptionsBehavior.Editable = false;
            this.gvUsrAuthGrp.OptionsMenu.EnableColumnMenu = false;
            this.gvUsrAuthGrp.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvUsrAuthGrp.OptionsView.EnableAppearanceEvenRow = true;
            this.gvUsrAuthGrp.OptionsView.EnableAppearanceOddRow = true;
            this.gvUsrAuthGrp.OptionsView.ShowGroupPanel = false;
            this.gvUsrAuthGrp.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvUsrAuthGrp_CustomDrawRowIndicator);
            this.gvUsrAuthGrp.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvUsrAuthGrp_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // GrpEngName
            // 
            this.GrpEngName.Caption = "Authority Group English Name";
            this.GrpEngName.FieldName = "GrpEngName";
            this.GrpEngName.Name = "GrpEngName";
            this.GrpEngName.Visible = true;
            this.GrpEngName.VisibleIndex = 0;
            // 
            // GrpOtherName
            // 
            this.GrpOtherName.Caption = "Authority Group Other Name";
            this.GrpOtherName.FieldName = "GrpOtherName";
            this.GrpOtherName.Name = "GrpOtherName";
            this.GrpOtherName.Visible = true;
            this.GrpOtherName.VisibleIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControlUsrAuthGrp);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(449, 476);
            this.panelControl2.TabIndex = 2;
            // 
            // FrmUsrAuthGrp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 476);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUsrAuthGrp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmUsrAuthGrp";
            this.Load += new System.EventHandler(this.FrmUsrAuthGrp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUsrAuthGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsrAuthGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.TextEdit txtOtherName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtEngName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl gridControlUsrAuthGrp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUsrAuthGrp;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn GrpEngName;
        private DevExpress.XtraGrid.Columns.GridColumn GrpOtherName;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}