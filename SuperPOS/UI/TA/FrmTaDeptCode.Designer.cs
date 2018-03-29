namespace SuperPOS.UI.Sys
{
    partial class FrmTaDeptCode
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
            this.gridControlTaDeptCode = new DevExpress.XtraGrid.GridControl();
            this.gvTaDeptCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeptEngName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeptOtherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtOtherName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtEngName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaDeptCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaDeptCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlTaDeptCode
            // 
            this.gridControlTaDeptCode.Location = new System.Drawing.Point(5, 121);
            this.gridControlTaDeptCode.MainView = this.gvTaDeptCode;
            this.gridControlTaDeptCode.Name = "gridControlTaDeptCode";
            this.gridControlTaDeptCode.Size = new System.Drawing.Size(436, 482);
            this.gridControlTaDeptCode.TabIndex = 2;
            this.gridControlTaDeptCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaDeptCode});
            // 
            // gvTaDeptCode
            // 
            this.gvTaDeptCode.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvTaDeptCode.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTaDeptCode.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvTaDeptCode.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTaDeptCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.DeptEngName,
            this.DeptOtherName});
            this.gvTaDeptCode.GridControl = this.gridControlTaDeptCode;
            this.gvTaDeptCode.IndicatorWidth = 50;
            this.gvTaDeptCode.Name = "gvTaDeptCode";
            this.gvTaDeptCode.OptionsBehavior.Editable = false;
            this.gvTaDeptCode.OptionsMenu.EnableColumnMenu = false;
            this.gvTaDeptCode.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaDeptCode.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaDeptCode.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaDeptCode.OptionsView.ShowGroupPanel = false;
            this.gvTaDeptCode.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvTaDeptCode_CustomDrawRowIndicator);
            this.gvTaDeptCode.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvTaDeptCode_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // DeptEngName
            // 
            this.DeptEngName.Caption = "Department Name";
            this.DeptEngName.FieldName = "DeptEngName";
            this.DeptEngName.Name = "DeptEngName";
            this.DeptEngName.Visible = true;
            this.DeptEngName.VisibleIndex = 0;
            // 
            // DeptOtherName
            // 
            this.DeptOtherName.Caption = "Department Other Name";
            this.DeptOtherName.FieldName = "DeptOtherName";
            this.DeptOtherName.Name = "DeptOtherName";
            this.DeptOtherName.Visible = true;
            this.DeptOtherName.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlTaDeptCode);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(449, 608);
            this.panelControl1.TabIndex = 2;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnDel);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Location = new System.Drawing.Point(5, 67);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(436, 48);
            this.panelControl3.TabIndex = 1;
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
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(171, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtOtherName);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.txtEngName);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(5, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(436, 56);
            this.panelControl2.TabIndex = 0;
            // 
            // txtOtherName
            // 
            this.txtOtherName.Location = new System.Drawing.Point(310, 18);
            this.txtOtherName.Name = "txtOtherName";
            this.txtOtherName.Size = new System.Drawing.Size(100, 24);
            this.txtOtherName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(218, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Other Name:";
            // 
            // txtEngName
            // 
            this.txtEngName.Location = new System.Drawing.Point(68, 18);
            this.txtEngName.Name = "txtEngName";
            this.txtEngName.Size = new System.Drawing.Size(100, 24);
            this.txtEngName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Name:";
            // 
            // FrmTaDeptCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 608);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaDeptCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTaDeptCode";
            this.Load += new System.EventHandler(this.FrmTaDeptCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaDeptCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaDeptCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlTaDeptCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaDeptCode;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn DeptEngName;
        private DevExpress.XtraGrid.Columns.GridColumn DeptOtherName;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtOtherName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtEngName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}