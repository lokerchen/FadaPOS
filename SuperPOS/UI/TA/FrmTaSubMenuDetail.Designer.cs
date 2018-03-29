namespace SuperPOS.UI.TA
{
    partial class FrmTaSubMenuDetail
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
            this.gridControlTaSubMenuDetail = new DevExpress.XtraGrid.GridControl();
            this.gvTaSubMenuDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.smID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtEngName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtOtherName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.EngName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OtherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaSubMenuDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaSubMenuDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlTaSubMenuDetail
            // 
            this.gridControlTaSubMenuDetail.Location = new System.Drawing.Point(5, 178);
            this.gridControlTaSubMenuDetail.MainView = this.gvTaSubMenuDetail;
            this.gridControlTaSubMenuDetail.Name = "gridControlTaSubMenuDetail";
            this.gridControlTaSubMenuDetail.Size = new System.Drawing.Size(436, 271);
            this.gridControlTaSubMenuDetail.TabIndex = 2;
            this.gridControlTaSubMenuDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaSubMenuDetail});
            // 
            // gvTaSubMenuDetail
            // 
            this.gvTaSubMenuDetail.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvTaSubMenuDetail.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTaSubMenuDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvTaSubMenuDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTaSubMenuDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.smID,
            this.EngName,
            this.OtherName,
            this.Price});
            this.gvTaSubMenuDetail.GridControl = this.gridControlTaSubMenuDetail;
            this.gvTaSubMenuDetail.IndicatorWidth = 50;
            this.gvTaSubMenuDetail.Name = "gvTaSubMenuDetail";
            this.gvTaSubMenuDetail.OptionsBehavior.Editable = false;
            this.gvTaSubMenuDetail.OptionsMenu.EnableColumnMenu = false;
            this.gvTaSubMenuDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaSubMenuDetail.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaSubMenuDetail.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaSubMenuDetail.OptionsView.ShowGroupPanel = false;
            this.gvTaSubMenuDetail.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvTaSubMenuDetail_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // smID
            // 
            this.smID.Caption = "smID";
            this.smID.FieldName = "smID";
            this.smID.Name = "smID";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnExit);
            this.panelControl3.Controls.Add(this.btnDel);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Location = new System.Drawing.Point(5, 124);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(436, 48);
            this.panelControl3.TabIndex = 1;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(231, 14);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(95, 25);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(120, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 14);
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
            this.panelControl2.Size = new System.Drawing.Size(436, 113);
            this.panelControl2.TabIndex = 0;
            // 
            // txtEngName
            // 
            this.txtEngName.Location = new System.Drawing.Point(126, 18);
            this.txtEngName.Name = "txtEngName";
            this.txtEngName.Size = new System.Drawing.Size(272, 24);
            this.txtEngName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "English Name:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlTaSubMenuDetail);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(449, 459);
            this.panelControl1.TabIndex = 6;
            // 
            // txtOtherName
            // 
            this.txtOtherName.Location = new System.Drawing.Point(126, 59);
            this.txtOtherName.Name = "txtOtherName";
            this.txtOtherName.Size = new System.Drawing.Size(272, 24);
            this.txtOtherName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(28, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Other Name:";
            // 
            // EngName
            // 
            this.EngName.Caption = "English Name";
            this.EngName.FieldName = "EngName";
            this.EngName.Name = "EngName";
            this.EngName.Visible = true;
            this.EngName.VisibleIndex = 0;
            // 
            // OtherName
            // 
            this.OtherName.Caption = "Other Name";
            this.OtherName.FieldName = "OtherName";
            this.OtherName.Name = "OtherName";
            this.OtherName.Visible = true;
            this.OtherName.VisibleIndex = 1;
            // 
            // Price
            // 
            this.Price.Caption = "Price";
            this.Price.FieldName = "Price";
            this.Price.Name = "Price";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(332, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 25);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmTaSubMenuDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 477);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaSubMenuDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTaSubMenuDetail";
            this.Load += new System.EventHandler(this.FrmTaSubMenuDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaSubMenuDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaSubMenuDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlTaSubMenuDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaSubMenuDetail;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn smID;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtEngName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtOtherName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn EngName;
        private DevExpress.XtraGrid.Columns.GridColumn OtherName;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}