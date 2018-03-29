namespace SuperPOS.UI.TA
{
    partial class FrmTaDeliveryNote
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
            this.gridControlTaDeliveryNote = new DevExpress.XtraGrid.GridControl();
            this.gvTaDeliveryNote = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeliveryNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtDeliverNote = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaDeliveryNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaDeliveryNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliverNote.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlTaDeliveryNote
            // 
            this.gridControlTaDeliveryNote.Location = new System.Drawing.Point(5, 121);
            this.gridControlTaDeliveryNote.MainView = this.gvTaDeliveryNote;
            this.gridControlTaDeliveryNote.Name = "gridControlTaDeliveryNote";
            this.gridControlTaDeliveryNote.Size = new System.Drawing.Size(436, 482);
            this.gridControlTaDeliveryNote.TabIndex = 2;
            this.gridControlTaDeliveryNote.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaDeliveryNote});
            // 
            // gvTaDeliveryNote
            // 
            this.gvTaDeliveryNote.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvTaDeliveryNote.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTaDeliveryNote.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvTaDeliveryNote.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTaDeliveryNote.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.DeliveryNote});
            this.gvTaDeliveryNote.GridControl = this.gridControlTaDeliveryNote;
            this.gvTaDeliveryNote.IndicatorWidth = 50;
            this.gvTaDeliveryNote.Name = "gvTaDeliveryNote";
            this.gvTaDeliveryNote.OptionsBehavior.Editable = false;
            this.gvTaDeliveryNote.OptionsMenu.EnableColumnMenu = false;
            this.gvTaDeliveryNote.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaDeliveryNote.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaDeliveryNote.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaDeliveryNote.OptionsView.ShowGroupPanel = false;
            this.gvTaDeliveryNote.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvTaDeliveryNote_CustomDrawRowIndicator);
            this.gvTaDeliveryNote.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvTaDeliveryNote_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // DeliveryNote
            // 
            this.DeliveryNote.Caption = "Delivery Note";
            this.DeliveryNote.FieldName = "DeliveryNote";
            this.DeliveryNote.Name = "DeliveryNote";
            this.DeliveryNote.Visible = true;
            this.DeliveryNote.VisibleIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlTaDeliveryNote);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(449, 608);
            this.panelControl1.TabIndex = 4;
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
            this.panelControl2.Controls.Add(this.txtDeliverNote);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(5, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(436, 56);
            this.panelControl2.TabIndex = 0;
            // 
            // txtDeliverNote
            // 
            this.txtDeliverNote.Location = new System.Drawing.Point(126, 21);
            this.txtDeliverNote.Name = "txtDeliverNote";
            this.txtDeliverNote.Size = new System.Drawing.Size(245, 24);
            this.txtDeliverNote.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Delivery Note:";
            // 
            // FrmTaDeliveryNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 645);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaDeliveryNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTaDeliveryNote";
            this.Load += new System.EventHandler(this.FrmTaDeliveryNote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaDeliveryNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaDeliveryNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliverNote.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlTaDeliveryNote;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaDeliveryNote;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn DeliveryNote;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtDeliverNote;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}