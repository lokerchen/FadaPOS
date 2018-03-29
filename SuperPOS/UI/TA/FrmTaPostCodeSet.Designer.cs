namespace SuperPOS.UI.TA
{
    partial class FrmTaPostCodeSet
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
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtPCZone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPostCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridControlPCSet = new DevExpress.XtraGrid.GridControl();
            this.gvPCSet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PCZone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtPCDist = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPCAddr = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.PCDist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PCAddr = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPCZone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPCSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPCSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPCDist.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPCAddr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnDel);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Location = new System.Drawing.Point(8, 410);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(470, 48);
            this.panelControl3.TabIndex = 11;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(345, 11);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(95, 25);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(190, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(22, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtPCAddr);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.txtPCDist);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.txtPCZone);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.txtPostCode);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Location = new System.Drawing.Point(7, 13);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(455, 110);
            this.panelControl2.TabIndex = 13;
            // 
            // txtPCZone
            // 
            this.txtPCZone.Location = new System.Drawing.Point(319, 11);
            this.txtPCZone.Name = "txtPCZone";
            this.txtPCZone.Properties.Mask.EditMask = "00000-9999";
            this.txtPCZone.Size = new System.Drawing.Size(122, 24);
            this.txtPCZone.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(249, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 18);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "PC Zone:";
            // 
            // txtPostCode
            // 
            this.txtPostCode.Location = new System.Drawing.Point(92, 11);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(122, 24);
            this.txtPostCode.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(71, 18);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Post Code:";
            // 
            // gridControlPCSet
            // 
            this.gridControlPCSet.Location = new System.Drawing.Point(7, 129);
            this.gridControlPCSet.MainView = this.gvPCSet;
            this.gridControlPCSet.Name = "gridControlPCSet";
            this.gridControlPCSet.Size = new System.Drawing.Size(455, 249);
            this.gridControlPCSet.TabIndex = 12;
            this.gridControlPCSet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPCSet});
            // 
            // gvPCSet
            // 
            this.gvPCSet.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvPCSet.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvPCSet.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvPCSet.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvPCSet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.PostCode,
            this.PCAddr,
            this.PCZone,
            this.PCDist});
            this.gvPCSet.GridControl = this.gridControlPCSet;
            this.gvPCSet.IndicatorWidth = 50;
            this.gvPCSet.Name = "gvPCSet";
            this.gvPCSet.OptionsBehavior.Editable = false;
            this.gvPCSet.OptionsMenu.EnableColumnMenu = false;
            this.gvPCSet.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvPCSet.OptionsView.EnableAppearanceEvenRow = true;
            this.gvPCSet.OptionsView.EnableAppearanceOddRow = true;
            this.gvPCSet.OptionsView.ShowGroupPanel = false;
            this.gvPCSet.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvPCSet_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // PostCode
            // 
            this.PostCode.Caption = "Post Code";
            this.PostCode.FieldName = "PostCode";
            this.PostCode.Name = "PostCode";
            this.PostCode.Visible = true;
            this.PostCode.VisibleIndex = 0;
            this.PostCode.Width = 106;
            // 
            // PCZone
            // 
            this.PCZone.Caption = "PC Zone";
            this.PCZone.FieldName = "PCZone";
            this.PCZone.Name = "PCZone";
            this.PCZone.Visible = true;
            this.PCZone.VisibleIndex = 2;
            this.PCZone.Width = 85;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.gridControlPCSet);
            this.panelControl1.Location = new System.Drawing.Point(8, 10);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(468, 394);
            this.panelControl1.TabIndex = 12;
            // 
            // txtPCDist
            // 
            this.txtPCDist.Location = new System.Drawing.Point(92, 44);
            this.txtPCDist.Name = "txtPCDist";
            this.txtPCDist.Properties.Mask.EditMask = "n2";
            this.txtPCDist.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPCDist.Size = new System.Drawing.Size(122, 24);
            this.txtPCDist.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 50);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 18);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Distance:";
            // 
            // txtPCAddr
            // 
            this.txtPCAddr.Location = new System.Drawing.Point(92, 76);
            this.txtPCAddr.Name = "txtPCAddr";
            this.txtPCAddr.Properties.Mask.EditMask = "f2";
            this.txtPCAddr.Size = new System.Drawing.Size(349, 24);
            this.txtPCAddr.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(25, 79);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(57, 18);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Address:";
            // 
            // PCDist
            // 
            this.PCDist.Caption = "Distance";
            this.PCDist.FieldName = "PCDist";
            this.PCDist.Name = "PCDist";
            this.PCDist.Visible = true;
            this.PCDist.VisibleIndex = 3;
            this.PCDist.Width = 89;
            // 
            // PCAddr
            // 
            this.PCAddr.Caption = "Address";
            this.PCAddr.FieldName = "PCAddr";
            this.PCAddr.Name = "PCAddr";
            this.PCAddr.Visible = true;
            this.PCAddr.VisibleIndex = 1;
            this.PCAddr.Width = 230;
            // 
            // FrmTaPostCodeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 468);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaPostCodeSet";
            this.Text = "FrmTaPostCodeSet";
            this.Load += new System.EventHandler(this.FrmTaPostCodeSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPCZone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPCSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPCSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPCDist.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPCAddr.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtPCZone;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPostCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gridControlPCSet;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPCSet;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn PostCode;
        private DevExpress.XtraGrid.Columns.GridColumn PCZone;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtPCAddr;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtPCDist;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn PCAddr;
        private DevExpress.XtraGrid.Columns.GridColumn PCDist;
    }
}