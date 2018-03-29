namespace SuperPOS.UI.TA
{
    partial class FrmTaPostCode
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
            this.xtcPostcodeCharge = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageCharge = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageZone = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlCharge = new DevExpress.XtraGrid.GridControl();
            this.gvCharge = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Charge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlZone = new DevExpress.XtraGrid.GridControl();
            this.gvZone = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.zID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.zPostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Zone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.txtZone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPostCodeZone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtCharge = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPostCodeCharge = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtcPostcodeCharge)).BeginInit();
            this.xtcPostcodeCharge.SuspendLayout();
            this.xtraTabPageCharge.SuspendLayout();
            this.xtraTabPageZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCharge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCharge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtZone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostCodeZone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCharge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostCodeCharge.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtcPostcodeCharge
            // 
            this.xtcPostcodeCharge.Location = new System.Drawing.Point(5, 6);
            this.xtcPostcodeCharge.Name = "xtcPostcodeCharge";
            this.xtcPostcodeCharge.SelectedTabPage = this.xtraTabPageCharge;
            this.xtcPostcodeCharge.Size = new System.Drawing.Size(477, 354);
            this.xtcPostcodeCharge.TabIndex = 1;
            this.xtcPostcodeCharge.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageCharge,
            this.xtraTabPageZone});
            this.xtcPostcodeCharge.Selected += new DevExpress.XtraTab.TabPageEventHandler(this.xtcPostcodeCharge_Selected);
            // 
            // xtraTabPageCharge
            // 
            this.xtraTabPageCharge.Controls.Add(this.panelControl2);
            this.xtraTabPageCharge.Controls.Add(this.gridControlCharge);
            this.xtraTabPageCharge.Name = "xtraTabPageCharge";
            this.xtraTabPageCharge.Size = new System.Drawing.Size(470, 318);
            this.xtraTabPageCharge.Text = "Charges for Special Postcode Prefixes";
            // 
            // xtraTabPageZone
            // 
            this.xtraTabPageZone.Controls.Add(this.panelControl4);
            this.xtraTabPageZone.Controls.Add(this.gridControlZone);
            this.xtraTabPageZone.Name = "xtraTabPageZone";
            this.xtraTabPageZone.Size = new System.Drawing.Size(470, 318);
            this.xtraTabPageZone.Text = "Postcode Zone Assignment";
            // 
            // gridControlCharge
            // 
            this.gridControlCharge.Location = new System.Drawing.Point(10, 64);
            this.gridControlCharge.MainView = this.gvCharge;
            this.gridControlCharge.Name = "gridControlCharge";
            this.gridControlCharge.Size = new System.Drawing.Size(450, 249);
            this.gridControlCharge.TabIndex = 7;
            this.gridControlCharge.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCharge});
            // 
            // gvCharge
            // 
            this.gvCharge.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvCharge.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvCharge.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvCharge.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvCharge.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.PostCode,
            this.Charge});
            this.gvCharge.GridControl = this.gridControlCharge;
            this.gvCharge.IndicatorWidth = 50;
            this.gvCharge.Name = "gvCharge";
            this.gvCharge.OptionsBehavior.Editable = false;
            this.gvCharge.OptionsMenu.EnableColumnMenu = false;
            this.gvCharge.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvCharge.OptionsView.EnableAppearanceEvenRow = true;
            this.gvCharge.OptionsView.EnableAppearanceOddRow = true;
            this.gvCharge.OptionsView.ShowGroupPanel = false;
            this.gvCharge.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvCharge_CustomDrawRowIndicator);
            this.gvCharge.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCharge_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // PostCode
            // 
            this.PostCode.Caption = "Postcode";
            this.PostCode.FieldName = "PostCode";
            this.PostCode.Name = "PostCode";
            this.PostCode.Visible = true;
            this.PostCode.VisibleIndex = 0;
            // 
            // Charge
            // 
            this.Charge.Caption = "Charge";
            this.Charge.FieldName = "PostCharge";
            this.Charge.Name = "Charge";
            this.Charge.Visible = true;
            this.Charge.VisibleIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnDel);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Location = new System.Drawing.Point(6, 360);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(470, 48);
            this.panelControl3.TabIndex = 6;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(349, 9);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(95, 25);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(194, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(26, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridControlZone
            // 
            this.gridControlZone.Location = new System.Drawing.Point(8, 62);
            this.gridControlZone.MainView = this.gvZone;
            this.gridControlZone.Name = "gridControlZone";
            this.gridControlZone.Size = new System.Drawing.Size(453, 249);
            this.gridControlZone.TabIndex = 8;
            this.gridControlZone.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvZone});
            // 
            // gvZone
            // 
            this.gvZone.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvZone.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvZone.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvZone.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvZone.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.zID,
            this.zPostCode,
            this.Zone});
            this.gvZone.GridControl = this.gridControlZone;
            this.gvZone.IndicatorWidth = 50;
            this.gvZone.Name = "gvZone";
            this.gvZone.OptionsBehavior.Editable = false;
            this.gvZone.OptionsMenu.EnableColumnMenu = false;
            this.gvZone.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvZone.OptionsView.EnableAppearanceEvenRow = true;
            this.gvZone.OptionsView.EnableAppearanceOddRow = true;
            this.gvZone.OptionsView.ShowGroupPanel = false;
            this.gvZone.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvZone_CustomDrawRowIndicator);
            this.gvZone.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvZone_FocusedRowChanged);
            // 
            // zID
            // 
            this.zID.Caption = "ID";
            this.zID.FieldName = "ID";
            this.zID.Name = "zID";
            // 
            // zPostCode
            // 
            this.zPostCode.Caption = "PostCode";
            this.zPostCode.FieldName = "PostCode";
            this.zPostCode.Name = "zPostCode";
            this.zPostCode.Visible = true;
            this.zPostCode.VisibleIndex = 0;
            // 
            // Zone
            // 
            this.Zone.Caption = "Zone";
            this.Zone.FieldName = "Zone";
            this.Zone.Name = "Zone";
            this.Zone.Visible = true;
            this.Zone.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.xtcPostcodeCharge);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(485, 419);
            this.panelControl1.TabIndex = 7;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.txtZone);
            this.panelControl4.Controls.Add(this.labelControl3);
            this.panelControl4.Controls.Add(this.txtPostCodeZone);
            this.panelControl4.Controls.Add(this.labelControl4);
            this.panelControl4.Location = new System.Drawing.Point(8, 3);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(450, 53);
            this.panelControl4.TabIndex = 9;
            // 
            // txtZone
            // 
            this.txtZone.Location = new System.Drawing.Point(323, 13);
            this.txtZone.Name = "txtZone";
            this.txtZone.Size = new System.Drawing.Size(122, 24);
            this.txtZone.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(280, 19);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 18);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Zone:";
            // 
            // txtPostCodeZone
            // 
            this.txtPostCodeZone.Location = new System.Drawing.Point(96, 13);
            this.txtPostCodeZone.Name = "txtPostCodeZone";
            this.txtPostCodeZone.Size = new System.Drawing.Size(122, 24);
            this.txtPostCodeZone.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(26, 19);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 18);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Postcode:";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtCharge);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.txtPostCodeCharge);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Location = new System.Drawing.Point(10, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(450, 53);
            this.panelControl2.TabIndex = 10;
            // 
            // txtCharge
            // 
            this.txtCharge.Location = new System.Drawing.Point(323, 13);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.Properties.Mask.EditMask = "f2";
            this.txtCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCharge.Size = new System.Drawing.Size(122, 24);
            this.txtCharge.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(253, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 18);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Charge:";
            // 
            // txtPostCodeCharge
            // 
            this.txtPostCodeCharge.Location = new System.Drawing.Point(96, 13);
            this.txtPostCodeCharge.Name = "txtPostCodeCharge";
            this.txtPostCodeCharge.Size = new System.Drawing.Size(122, 24);
            this.txtPostCodeCharge.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(26, 19);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 18);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Postcode:";
            // 
            // FrmTaPostCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 441);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaPostCode";
            this.Text = "FrmTaPostCode";
            this.Load += new System.EventHandler(this.FrmTaPostCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtcPostcodeCharge)).EndInit();
            this.xtcPostcodeCharge.ResumeLayout(false);
            this.xtraTabPageCharge.ResumeLayout(false);
            this.xtraTabPageZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtZone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostCodeZone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCharge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostCodeCharge.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtcPostcodeCharge;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageCharge;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageZone;
        private DevExpress.XtraGrid.GridControl gridControlCharge;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCharge;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn PostCode;
        private DevExpress.XtraGrid.Columns.GridColumn Charge;
        private DevExpress.XtraGrid.GridControl gridControlZone;
        private DevExpress.XtraGrid.Views.Grid.GridView gvZone;
        private DevExpress.XtraGrid.Columns.GridColumn zID;
        private DevExpress.XtraGrid.Columns.GridColumn zPostCode;
        private DevExpress.XtraGrid.Columns.GridColumn Zone;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtCharge;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPostCodeCharge;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.TextEdit txtZone;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPostCodeZone;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}