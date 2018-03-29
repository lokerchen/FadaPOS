namespace SuperPOS.UI.Sys
{
    partial class FrmPrtSet
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
            this.gridControlPrtSet = new DevExpress.XtraGrid.GridControl();
            this.gvPrtSet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PrtCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PrtName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtPrtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrtCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrtSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrtSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrtCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlPrtSet
            // 
            this.gridControlPrtSet.Location = new System.Drawing.Point(5, 121);
            this.gridControlPrtSet.MainView = this.gvPrtSet;
            this.gridControlPrtSet.Name = "gridControlPrtSet";
            this.gridControlPrtSet.Size = new System.Drawing.Size(436, 387);
            this.gridControlPrtSet.TabIndex = 2;
            this.gridControlPrtSet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPrtSet});
            // 
            // gvPrtSet
            // 
            this.gvPrtSet.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvPrtSet.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvPrtSet.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvPrtSet.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvPrtSet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.PrtCode,
            this.PrtName});
            this.gvPrtSet.GridControl = this.gridControlPrtSet;
            this.gvPrtSet.IndicatorWidth = 50;
            this.gvPrtSet.Name = "gvPrtSet";
            this.gvPrtSet.OptionsBehavior.Editable = false;
            this.gvPrtSet.OptionsMenu.EnableColumnMenu = false;
            this.gvPrtSet.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvPrtSet.OptionsView.EnableAppearanceEvenRow = true;
            this.gvPrtSet.OptionsView.EnableAppearanceOddRow = true;
            this.gvPrtSet.OptionsView.ShowGroupPanel = false;
            this.gvPrtSet.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPrtSet_CustomDrawRowIndicator);
            this.gvPrtSet.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvPrtSet_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // PrtCode
            // 
            this.PrtCode.Caption = "Pinter Code";
            this.PrtCode.FieldName = "PrtCode";
            this.PrtCode.Name = "PrtCode";
            this.PrtCode.Visible = true;
            this.PrtCode.VisibleIndex = 0;
            // 
            // PrtName
            // 
            this.PrtName.Caption = "Printer Name";
            this.PrtName.FieldName = "PrtName";
            this.PrtName.Name = "PrtName";
            this.PrtName.Visible = true;
            this.PrtName.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlPrtSet);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(446, 511);
            this.panelControl1.TabIndex = 1;
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
            this.panelControl2.Controls.Add(this.txtPrtName);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.txtPrtCode);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(5, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(436, 56);
            this.panelControl2.TabIndex = 0;
            // 
            // txtPrtName
            // 
            this.txtPrtName.Location = new System.Drawing.Point(330, 15);
            this.txtPrtName.Name = "txtPrtName";
            this.txtPrtName.Size = new System.Drawing.Size(100, 24);
            this.txtPrtName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(232, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(90, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Printer Name:";
            // 
            // txtPrtCode
            // 
            this.txtPrtCode.Location = new System.Drawing.Point(97, 18);
            this.txtPrtCode.Name = "txtPrtCode";
            this.txtPrtCode.Size = new System.Drawing.Size(100, 24);
            this.txtPrtCode.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Printer Code:";
            // 
            // FrmPrtSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 511);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrtSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Printer Setting";
            this.Load += new System.EventHandler(this.FrmPrtSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrtSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrtSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrtCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPrtSet;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPrtSet;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn PrtCode;
        private DevExpress.XtraGrid.Columns.GridColumn PrtName;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtPrtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPrtCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}