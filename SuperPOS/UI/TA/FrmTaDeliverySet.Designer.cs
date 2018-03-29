namespace SuperPOS.UI.TA
{
    partial class FrmTaDeliverySet
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
            this.gridControlDeliverySet = new DevExpress.XtraGrid.GridControl();
            this.gvDeliverySet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DistFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DistTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtMile = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPerMile = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkDeliveryChge = new DevExpress.XtraEditors.CheckEdit();
            this.chkIgnoreDelivery = new DevExpress.XtraEditors.CheckEdit();
            this.txtOrderThreshold = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtSurchargeAmount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.AmountToPay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtDistFrom = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDistTo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtAmountToPay = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliverySet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeliverySet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerMile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeliveryChge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIgnoreDelivery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderThreshold.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurchargeAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountToPay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlDeliverySet
            // 
            this.gridControlDeliverySet.Location = new System.Drawing.Point(7, 348);
            this.gridControlDeliverySet.MainView = this.gvDeliverySet;
            this.gridControlDeliverySet.Name = "gridControlDeliverySet";
            this.gridControlDeliverySet.Size = new System.Drawing.Size(450, 249);
            this.gridControlDeliverySet.TabIndex = 5;
            this.gridControlDeliverySet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDeliverySet});
            // 
            // gvDeliverySet
            // 
            this.gvDeliverySet.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvDeliverySet.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvDeliverySet.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvDeliverySet.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvDeliverySet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.DistFrom,
            this.DistTo,
            this.AmountToPay});
            this.gvDeliverySet.GridControl = this.gridControlDeliverySet;
            this.gvDeliverySet.IndicatorWidth = 50;
            this.gvDeliverySet.Name = "gvDeliverySet";
            this.gvDeliverySet.OptionsBehavior.Editable = false;
            this.gvDeliverySet.OptionsMenu.EnableColumnMenu = false;
            this.gvDeliverySet.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvDeliverySet.OptionsView.EnableAppearanceEvenRow = true;
            this.gvDeliverySet.OptionsView.EnableAppearanceOddRow = true;
            this.gvDeliverySet.OptionsView.ShowGroupPanel = false;
            this.gvDeliverySet.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvDeliverySet_CustomDrawRowIndicator);
            this.gvDeliverySet.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDeliverySet_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // DistFrom
            // 
            this.DistFrom.Caption = "Distance From";
            this.DistFrom.FieldName = "DistFrom";
            this.DistFrom.Name = "DistFrom";
            this.DistFrom.Visible = true;
            this.DistFrom.VisibleIndex = 0;
            // 
            // DistTo
            // 
            this.DistTo.Caption = "Distance From";
            this.DistTo.FieldName = "DistTo";
            this.DistTo.Name = "DistTo";
            this.DistTo.Visible = true;
            this.DistTo.VisibleIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnDel);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Location = new System.Drawing.Point(7, 294);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(450, 48);
            this.panelControl3.TabIndex = 4;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(306, 9);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(95, 25);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(166, 9);
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
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.txtSurchargeAmount);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.txtOrderThreshold);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.chkIgnoreDelivery);
            this.panelControl2.Controls.Add(this.chkDeliveryChge);
            this.panelControl2.Controls.Add(this.txtMile);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.txtPerMile);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(7, 7);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(450, 175);
            this.panelControl2.TabIndex = 3;
            // 
            // txtMile
            // 
            this.txtMile.Location = new System.Drawing.Point(344, 60);
            this.txtMile.Name = "txtMile";
            this.txtMile.Properties.Mask.EditMask = "n2";
            this.txtMile.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMile.Size = new System.Drawing.Size(59, 24);
            this.txtMile.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(331, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Ignore Delivery Surcharge When Distance Exceeds";
            // 
            // txtPerMile
            // 
            this.txtPerMile.Location = new System.Drawing.Point(7, 8);
            this.txtPerMile.Name = "txtPerMile";
            this.txtPerMile.Properties.Mask.EditMask = "n2";
            this.txtPerMile.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPerMile.Size = new System.Drawing.Size(100, 24);
            this.txtPerMile.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(113, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(125, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Per Mile Thereafter";
            // 
            // chkDeliveryChge
            // 
            this.chkDeliveryChge.Location = new System.Drawing.Point(7, 38);
            this.chkDeliveryChge.Name = "chkDeliveryChge";
            this.chkDeliveryChge.Properties.Caption = "Delivery Charge Includes In Order";
            this.chkDeliveryChge.Size = new System.Drawing.Size(253, 22);
            this.chkDeliveryChge.TabIndex = 4;
            // 
            // chkIgnoreDelivery
            // 
            this.chkIgnoreDelivery.Location = new System.Drawing.Point(7, 90);
            this.chkIgnoreDelivery.Name = "chkIgnoreDelivery";
            this.chkIgnoreDelivery.Properties.Caption = "Ignore Delivery Distance Charge If Surcharge Applies";
            this.chkIgnoreDelivery.Size = new System.Drawing.Size(371, 22);
            this.chkIgnoreDelivery.TabIndex = 5;
            // 
            // txtOrderThreshold
            // 
            this.txtOrderThreshold.Location = new System.Drawing.Point(119, 112);
            this.txtOrderThreshold.Name = "txtOrderThreshold";
            this.txtOrderThreshold.Properties.Mask.EditMask = "n2";
            this.txtOrderThreshold.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtOrderThreshold.Size = new System.Drawing.Size(100, 24);
            this.txtOrderThreshold.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(7, 118);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(106, 18);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Order Threshold";
            // 
            // txtSurchargeAmount
            // 
            this.txtSurchargeAmount.Location = new System.Drawing.Point(134, 142);
            this.txtSurchargeAmount.Name = "txtSurchargeAmount";
            this.txtSurchargeAmount.Properties.Mask.EditMask = "n2";
            this.txtSurchargeAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSurchargeAmount.Size = new System.Drawing.Size(100, 24);
            this.txtSurchargeAmount.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 148);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(121, 18);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Surcharge Amount";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(409, 66);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(31, 18);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "Miles";
            // 
            // AmountToPay
            // 
            this.AmountToPay.Caption = "Amount To Pay";
            this.AmountToPay.FieldName = "AmountToPay";
            this.AmountToPay.Name = "AmountToPay";
            this.AmountToPay.Visible = true;
            this.AmountToPay.VisibleIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtAmountToPay);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.txtDistTo);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.txtDistFrom);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Location = new System.Drawing.Point(7, 188);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(450, 100);
            this.panelControl1.TabIndex = 5;
            // 
            // txtDistFrom
            // 
            this.txtDistFrom.Location = new System.Drawing.Point(134, 5);
            this.txtDistFrom.Name = "txtDistFrom";
            this.txtDistFrom.Properties.Mask.EditMask = "n2";
            this.txtDistFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDistFrom.Size = new System.Drawing.Size(169, 24);
            this.txtDistFrom.TabIndex = 12;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(7, 11);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(99, 18);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Distance From:";
            // 
            // txtDistTo
            // 
            this.txtDistTo.Location = new System.Drawing.Point(134, 39);
            this.txtDistTo.Name = "txtDistTo";
            this.txtDistTo.Properties.Mask.EditMask = "n2";
            this.txtDistTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDistTo.Size = new System.Drawing.Size(169, 24);
            this.txtDistTo.TabIndex = 14;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(7, 45);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(83, 18);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Distance To:";
            // 
            // txtAmountToPay
            // 
            this.txtAmountToPay.Location = new System.Drawing.Point(134, 70);
            this.txtAmountToPay.Name = "txtAmountToPay";
            this.txtAmountToPay.Properties.Mask.EditMask = "n2";
            this.txtAmountToPay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAmountToPay.Size = new System.Drawing.Size(169, 24);
            this.txtAmountToPay.TabIndex = 16;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(7, 76);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(108, 18);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "Amount To Pay:";
            // 
            // FrmTaDeliverySet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 609);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControlDeliverySet);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaDeliverySet";
            this.Text = "FrmTaDeliverySet";
            this.Load += new System.EventHandler(this.FrmTaDeliverySet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliverySet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeliverySet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerMile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeliveryChge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIgnoreDelivery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderThreshold.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurchargeAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountToPay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlDeliverySet;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDeliverySet;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn DistFrom;
        private DevExpress.XtraGrid.Columns.GridColumn DistTo;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtSurchargeAmount;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtOrderThreshold;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit chkIgnoreDelivery;
        private DevExpress.XtraEditors.CheckEdit chkDeliveryChge;
        private DevExpress.XtraEditors.TextEdit txtMile;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPerMile;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn AmountToPay;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtAmountToPay;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtDistTo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtDistFrom;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}