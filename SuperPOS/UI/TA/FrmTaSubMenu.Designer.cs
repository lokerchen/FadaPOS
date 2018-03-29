namespace SuperPOS.UI.TA
{
    partial class FrmTaSubMenu
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
            this.gridControlTaSubMenu = new DevExpress.XtraGrid.GridControl();
            this.gvTaSubMenu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SetMeal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtSetMeal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaSubMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaSubMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSetMeal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlTaSubMenu
            // 
            this.gridControlTaSubMenu.Location = new System.Drawing.Point(5, 121);
            this.gridControlTaSubMenu.MainView = this.gvTaSubMenu;
            this.gridControlTaSubMenu.Name = "gridControlTaSubMenu";
            this.gridControlTaSubMenu.Size = new System.Drawing.Size(436, 289);
            this.gridControlTaSubMenu.TabIndex = 2;
            this.gridControlTaSubMenu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaSubMenu});
            // 
            // gvTaSubMenu
            // 
            this.gvTaSubMenu.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvTaSubMenu.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTaSubMenu.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvTaSubMenu.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTaSubMenu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.SetMeal});
            this.gvTaSubMenu.GridControl = this.gridControlTaSubMenu;
            this.gvTaSubMenu.IndicatorWidth = 50;
            this.gvTaSubMenu.Name = "gvTaSubMenu";
            this.gvTaSubMenu.OptionsBehavior.Editable = false;
            this.gvTaSubMenu.OptionsMenu.EnableColumnMenu = false;
            this.gvTaSubMenu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaSubMenu.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaSubMenu.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaSubMenu.OptionsView.ShowGroupPanel = false;
            this.gvTaSubMenu.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvTaSubMenu_FocusedRowChanged);
            this.gvTaSubMenu.DoubleClick += new System.EventHandler(this.gvTaSubMenu_DoubleClick);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // SetMeal
            // 
            this.SetMeal.Caption = "Set Meal";
            this.SetMeal.FieldName = "SetMeal";
            this.SetMeal.Name = "SetMeal";
            this.SetMeal.Visible = true;
            this.SetMeal.VisibleIndex = 0;
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
            this.panelControl2.Controls.Add(this.txtSetMeal);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(5, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(436, 56);
            this.panelControl2.TabIndex = 0;
            // 
            // txtSetMeal
            // 
            this.txtSetMeal.Location = new System.Drawing.Point(105, 18);
            this.txtSetMeal.Name = "txtSetMeal";
            this.txtSetMeal.Size = new System.Drawing.Size(272, 24);
            this.txtSetMeal.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Set Meal:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlTaSubMenu);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Location = new System.Drawing.Point(4, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(449, 420);
            this.panelControl1.TabIndex = 5;
            // 
            // FrmTaSubMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 433);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaSubMenu";
            this.Text = "FrmTaSubMenu";
            this.Load += new System.EventHandler(this.FrmTaSubMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaSubMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaSubMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSetMeal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlTaSubMenu;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaSubMenu;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn SetMeal;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtSetMeal;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}