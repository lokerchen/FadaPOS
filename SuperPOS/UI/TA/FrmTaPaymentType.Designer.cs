namespace SuperPOS.UI.TA
{
    partial class FrmTaPaymentType
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
            this.gridControlTaPaymentType = new DevExpress.XtraGrid.GridControl();
            this.gvTaPaymentType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PaymentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtPayType = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaPaymentType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaPaymentType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlTaPaymentType
            // 
            this.gridControlTaPaymentType.Location = new System.Drawing.Point(5, 121);
            this.gridControlTaPaymentType.MainView = this.gvTaPaymentType;
            this.gridControlTaPaymentType.Name = "gridControlTaPaymentType";
            this.gridControlTaPaymentType.Size = new System.Drawing.Size(436, 482);
            this.gridControlTaPaymentType.TabIndex = 2;
            this.gridControlTaPaymentType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaPaymentType});
            // 
            // gvTaPaymentType
            // 
            this.gvTaPaymentType.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvTaPaymentType.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTaPaymentType.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvTaPaymentType.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTaPaymentType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.PaymentType});
            this.gvTaPaymentType.GridControl = this.gridControlTaPaymentType;
            this.gvTaPaymentType.IndicatorWidth = 50;
            this.gvTaPaymentType.Name = "gvTaPaymentType";
            this.gvTaPaymentType.OptionsBehavior.Editable = false;
            this.gvTaPaymentType.OptionsMenu.EnableColumnMenu = false;
            this.gvTaPaymentType.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaPaymentType.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaPaymentType.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaPaymentType.OptionsView.ShowGroupPanel = false;
            this.gvTaPaymentType.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvTaPaymentType_CustomDrawRowIndicator);
            this.gvTaPaymentType.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvTaPaymentType_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // PaymentType
            // 
            this.PaymentType.Caption = "Payment Type";
            this.PaymentType.FieldName = "PaymentType";
            this.PaymentType.Name = "PaymentType";
            this.PaymentType.Visible = true;
            this.PaymentType.VisibleIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlTaPaymentType);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Location = new System.Drawing.Point(8, 8);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(449, 608);
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
            this.panelControl2.Controls.Add(this.txtPayType);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(5, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(436, 56);
            this.panelControl2.TabIndex = 0;
            // 
            // txtPayType
            // 
            this.txtPayType.Location = new System.Drawing.Point(126, 21);
            this.txtPayType.Name = "txtPayType";
            this.txtPayType.Size = new System.Drawing.Size(245, 24);
            this.txtPayType.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(102, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Payment Type:";
            // 
            // FrmTaPaymentType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 618);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaPaymentType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTaPaymentType";
            this.Load += new System.EventHandler(this.FrmTaPaymentType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaPaymentType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaPaymentType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlTaPaymentType;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaPaymentType;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn PaymentType;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtPayType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}