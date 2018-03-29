namespace SuperPOS.UI.TA
{
    partial class FrmTaMenuSet
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
            this.gridControlTaMenuSet = new DevExpress.XtraGrid.GridControl();
            this.gvTaMenuSet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MSEngName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MSOtherName = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaMenuSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaMenuSet)).BeginInit();
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
            // gridControlTaMenuSet
            // 
            this.gridControlTaMenuSet.Location = new System.Drawing.Point(5, 121);
            this.gridControlTaMenuSet.MainView = this.gvTaMenuSet;
            this.gridControlTaMenuSet.Name = "gridControlTaMenuSet";
            this.gridControlTaMenuSet.Size = new System.Drawing.Size(436, 252);
            this.gridControlTaMenuSet.TabIndex = 2;
            this.gridControlTaMenuSet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaMenuSet});
            // 
            // gvTaMenuSet
            // 
            this.gvTaMenuSet.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvTaMenuSet.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTaMenuSet.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvTaMenuSet.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTaMenuSet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.MSEngName,
            this.MSOtherName});
            this.gvTaMenuSet.GridControl = this.gridControlTaMenuSet;
            this.gvTaMenuSet.IndicatorWidth = 50;
            this.gvTaMenuSet.Name = "gvTaMenuSet";
            this.gvTaMenuSet.OptionsBehavior.Editable = false;
            this.gvTaMenuSet.OptionsMenu.EnableColumnMenu = false;
            this.gvTaMenuSet.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaMenuSet.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaMenuSet.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaMenuSet.OptionsView.ShowGroupPanel = false;
            this.gvTaMenuSet.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvTaMenuSet_CustomDrawRowIndicator);
            this.gvTaMenuSet.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvTaMenuSet_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // MSEngName
            // 
            this.MSEngName.Caption = "Menu Set English Name";
            this.MSEngName.FieldName = "MSEngName";
            this.MSEngName.Name = "MSEngName";
            this.MSEngName.Visible = true;
            this.MSEngName.VisibleIndex = 0;
            // 
            // MSOtherName
            // 
            this.MSOtherName.Caption = "Menu Set Other Name";
            this.MSOtherName.FieldName = "MSOtherName";
            this.MSOtherName.Name = "MSOtherName";
            this.MSOtherName.Visible = true;
            this.MSOtherName.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlTaMenuSet);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(449, 378);
            this.panelControl1.TabIndex = 3;
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
            this.txtOtherName.Location = new System.Drawing.Point(324, 18);
            this.txtOtherName.Name = "txtOtherName";
            this.txtOtherName.Size = new System.Drawing.Size(100, 24);
            this.txtOtherName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(232, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Other Name:";
            // 
            // txtEngName
            // 
            this.txtEngName.Location = new System.Drawing.Point(104, 18);
            this.txtEngName.Name = "txtEngName";
            this.txtEngName.Size = new System.Drawing.Size(100, 24);
            this.txtEngName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "English Name:";
            // 
            // FrmTaMenuSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 378);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaMenuSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MenuSet";
            this.Load += new System.EventHandler(this.FrmTaMenuSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaMenuSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaMenuSet)).EndInit();
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

        private DevExpress.XtraGrid.GridControl gridControlTaMenuSet;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaMenuSet;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn MSEngName;
        private DevExpress.XtraGrid.Columns.GridColumn MSOtherName;
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