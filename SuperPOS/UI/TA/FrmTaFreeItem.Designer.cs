namespace SuperPOS.UI.TA
{
    partial class FrmTaFreeItem
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalAmount = new DevExpress.XtraEditors.TextEdit();
            this.gridControlFreeFood = new DevExpress.XtraGrid.GridControl();
            this.gvFreeFoodItem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DishCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.txtDishCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFreeFood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFreeFoodItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDishCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtTotalAmount);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(5, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(436, 46);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(163, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Total Amount Threshold:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(199, 11);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Properties.Mask.EditMask = "n2";
            this.txtTotalAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalAmount.Size = new System.Drawing.Size(207, 24);
            this.txtTotalAmount.TabIndex = 1;
            // 
            // gridControlFreeFood
            // 
            this.gridControlFreeFood.Location = new System.Drawing.Point(5, 172);
            this.gridControlFreeFood.MainView = this.gvFreeFoodItem;
            this.gridControlFreeFood.Name = "gridControlFreeFood";
            this.gridControlFreeFood.Size = new System.Drawing.Size(436, 262);
            this.gridControlFreeFood.TabIndex = 2;
            this.gridControlFreeFood.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFreeFoodItem});
            // 
            // gvFreeFoodItem
            // 
            this.gvFreeFoodItem.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvFreeFoodItem.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvFreeFoodItem.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvFreeFoodItem.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvFreeFoodItem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.DishCode});
            this.gvFreeFoodItem.GridControl = this.gridControlFreeFood;
            this.gvFreeFoodItem.IndicatorWidth = 50;
            this.gvFreeFoodItem.Name = "gvFreeFoodItem";
            this.gvFreeFoodItem.OptionsBehavior.Editable = false;
            this.gvFreeFoodItem.OptionsMenu.EnableColumnMenu = false;
            this.gvFreeFoodItem.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvFreeFoodItem.OptionsView.EnableAppearanceEvenRow = true;
            this.gvFreeFoodItem.OptionsView.EnableAppearanceOddRow = true;
            this.gvFreeFoodItem.OptionsView.ShowGroupPanel = false;
            this.gvFreeFoodItem.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvFreeFoodItem_CustomDrawRowIndicator);
            this.gvFreeFoodItem.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvFreeFoodItem_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // DishCode
            // 
            this.DishCode.Caption = "Free Food Item Dish Code";
            this.DishCode.FieldName = "DishCode";
            this.DishCode.Name = "DishCode";
            this.DishCode.Visible = true;
            this.DishCode.VisibleIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControlFreeFood);
            this.panelControl2.Controls.Add(this.panelControl1);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Location = new System.Drawing.Point(6, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(449, 437);
            this.panelControl2.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnDel);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Location = new System.Drawing.Point(5, 118);
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
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.txtDishCode);
            this.panelControl4.Controls.Add(this.labelControl2);
            this.panelControl4.Location = new System.Drawing.Point(5, 57);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(436, 56);
            this.panelControl4.TabIndex = 0;
            // 
            // txtDishCode
            // 
            this.txtDishCode.Location = new System.Drawing.Point(199, 15);
            this.txtDishCode.Name = "txtDishCode";
            this.txtDishCode.Properties.Mask.EditMask = "n0";
            this.txtDishCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDishCode.Size = new System.Drawing.Size(207, 24);
            this.txtDishCode.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(178, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Free Food Item Dish Code:";
            // 
            // FrmTaFreeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 447);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaFreeItem";
            this.Text = "FrmTaFreeItem";
            this.Load += new System.EventHandler(this.FrmTaFreeItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFreeFood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFreeFoodItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDishCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTotalAmount;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControlFreeFood;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFreeFoodItem;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn DishCode;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.TextEdit txtDishCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}