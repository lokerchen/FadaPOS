namespace SuperPOS.UI.TA
{
    partial class FrmTaDiscount
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
            this.gridControlTaDiscount = new DevExpress.XtraGrid.GridControl();
            this.gvTaDiscount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaDiscThre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtDiscountThreshold = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDiscount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTaType = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountThreshold.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlTaDiscount
            // 
            this.gridControlTaDiscount.Location = new System.Drawing.Point(4, 135);
            this.gridControlTaDiscount.MainView = this.gvTaDiscount;
            this.gridControlTaDiscount.Name = "gridControlTaDiscount";
            this.gridControlTaDiscount.Size = new System.Drawing.Size(436, 443);
            this.gridControlTaDiscount.TabIndex = 2;
            this.gridControlTaDiscount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaDiscount});
            // 
            // gvTaDiscount
            // 
            this.gvTaDiscount.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvTaDiscount.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTaDiscount.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvTaDiscount.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTaDiscount.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.TaType,
            this.TaDiscount,
            this.TaDiscThre});
            this.gvTaDiscount.GridControl = this.gridControlTaDiscount;
            this.gvTaDiscount.IndicatorWidth = 50;
            this.gvTaDiscount.Name = "gvTaDiscount";
            this.gvTaDiscount.OptionsBehavior.Editable = false;
            this.gvTaDiscount.OptionsMenu.EnableColumnMenu = false;
            this.gvTaDiscount.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaDiscount.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaDiscount.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaDiscount.OptionsView.ShowGroupPanel = false;
            this.gvTaDiscount.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvTaDiscount_CustomDrawRowIndicator);
            this.gvTaDiscount.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvTaDiscount_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // TaType
            // 
            this.TaType.Caption = "Type";
            this.TaType.FieldName = "TaType";
            this.TaType.Name = "TaType";
            this.TaType.Visible = true;
            this.TaType.VisibleIndex = 0;
            this.TaType.Width = 134;
            // 
            // TaDiscount
            // 
            this.TaDiscount.Caption = "Discount(%)";
            this.TaDiscount.FieldName = "TaDiscount";
            this.TaDiscount.Name = "TaDiscount";
            this.TaDiscount.Visible = true;
            this.TaDiscount.VisibleIndex = 1;
            this.TaDiscount.Width = 109;
            // 
            // TaDiscThre
            // 
            this.TaDiscThre.Caption = "Discount Threshold";
            this.TaDiscThre.FieldName = "TaDiscThre";
            this.TaDiscThre.Name = "TaDiscThre";
            this.TaDiscThre.Visible = true;
            this.TaDiscThre.VisibleIndex = 2;
            this.TaDiscThre.Width = 141;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlTaDiscount);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Location = new System.Drawing.Point(8, 8);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(449, 590);
            this.panelControl1.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(329, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 93);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Controls.Add(this.txtTaType);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.txtDiscountThreshold);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.txtDiscount);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(5, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(436, 124);
            this.panelControl2.TabIndex = 0;
            // 
            // txtDiscountThreshold
            // 
            this.txtDiscountThreshold.Location = new System.Drawing.Point(162, 87);
            this.txtDiscountThreshold.Name = "txtDiscountThreshold";
            this.txtDiscountThreshold.Properties.Mask.EditMask = "f2";
            this.txtDiscountThreshold.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDiscountThreshold.Size = new System.Drawing.Size(155, 24);
            this.txtDiscountThreshold.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(129, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Discount Threshold:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(162, 50);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Properties.Mask.EditMask = "P";
            this.txtDiscount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDiscount.Size = new System.Drawing.Size(155, 24);
            this.txtDiscount.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(56, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Discount(%):";
            // 
            // txtTaType
            // 
            this.txtTaType.Enabled = false;
            this.txtTaType.Location = new System.Drawing.Point(162, 12);
            this.txtTaType.Name = "txtTaType";
            this.txtTaType.Properties.Mask.EditMask = "f2";
            this.txtTaType.Size = new System.Drawing.Size(155, 24);
            this.txtTaType.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(104, 18);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 18);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Type:";
            // 
            // FrmTaDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 608);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaDiscount";
            this.Text = "FrmTaDiscount";
            this.Load += new System.EventHandler(this.FrmTaDiscount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountThreshold.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlTaDiscount;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn TaType;
        private DevExpress.XtraGrid.Columns.GridColumn TaDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn TaDiscThre;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtDiscountThreshold;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDiscount;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTaType;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}