namespace SuperPOS.UI.TA
{
    partial class FrmTaShowOrderDriver
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lueDriver = new DevExpress.XtraEditors.LookUpEdit();
            this.btnShowAllDriver = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.gridControlTaDriver = new DevExpress.XtraGrid.GridControl();
            this.gvTaPendOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CheckCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PostCodeZone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Addr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PayOrderType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StaffName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DriverName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Discount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiscountPer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDriver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaPendOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridControlTaDriver);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnShowAllDriver);
            this.groupBox1.Controls.Add(this.lueDriver);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 455);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delivery Charges";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Location = new System.Drawing.Point(15, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Show Driver";
            // 
            // lueDriver
            // 
            this.lueDriver.Location = new System.Drawing.Point(138, 53);
            this.lueDriver.Name = "lueDriver";
            this.lueDriver.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lueDriver.Properties.Appearance.Options.UseFont = true;
            this.lueDriver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDriver.Properties.NullText = "[Please select...]";
            this.lueDriver.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.lueDriver.Size = new System.Drawing.Size(207, 30);
            this.lueDriver.TabIndex = 15;
            // 
            // btnShowAllDriver
            // 
            this.btnShowAllDriver.BackColor = System.Drawing.Color.Blue;
            this.btnShowAllDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAllDriver.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnShowAllDriver.ForeColor = System.Drawing.Color.White;
            this.btnShowAllDriver.Location = new System.Drawing.Point(377, 46);
            this.btnShowAllDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowAllDriver.Name = "btnShowAllDriver";
            this.btnShowAllDriver.Size = new System.Drawing.Size(146, 37);
            this.btnShowAllDriver.TabIndex = 17;
            this.btnShowAllDriver.Text = "Show All Driver";
            this.btnShowAllDriver.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(355, 378);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(168, 57);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gridControlTaDriver
            // 
            this.gridControlTaDriver.Location = new System.Drawing.Point(15, 93);
            this.gridControlTaDriver.MainView = this.gvTaPendOrder;
            this.gridControlTaDriver.Name = "gridControlTaDriver";
            this.gridControlTaDriver.Size = new System.Drawing.Size(465, 278);
            this.gridControlTaDriver.TabIndex = 19;
            this.gridControlTaDriver.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaPendOrder});
            // 
            // gvTaPendOrder
            // 
            this.gvTaPendOrder.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvTaPendOrder.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTaPendOrder.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvTaPendOrder.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTaPendOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.CheckCode,
            this.OrderTime,
            this.PostCode,
            this.PostCodeZone,
            this.Addr,
            this.PayOrderType,
            this.CustomerName,
            this.CustomerPhone,
            this.TotalAmount,
            this.StaffName,
            this.DriverName,
            this.IsPaid,
            this.menuAmount,
            this.Discount,
            this.DiscountPer});
            this.gvTaPendOrder.GridControl = this.gridControlTaDriver;
            this.gvTaPendOrder.IndicatorWidth = 50;
            this.gvTaPendOrder.Name = "gvTaPendOrder";
            this.gvTaPendOrder.OptionsBehavior.Editable = false;
            this.gvTaPendOrder.OptionsMenu.EnableColumnMenu = false;
            this.gvTaPendOrder.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaPendOrder.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaPendOrder.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaPendOrder.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.AppearanceCell.Options.UseFont = true;
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // CheckCode
            // 
            this.CheckCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckCode.AppearanceCell.Options.UseFont = true;
            this.CheckCode.Caption = "Order No.";
            this.CheckCode.FieldName = "CheckCode";
            this.CheckCode.Name = "CheckCode";
            this.CheckCode.Visible = true;
            this.CheckCode.VisibleIndex = 0;
            // 
            // OrderTime
            // 
            this.OrderTime.Caption = "Time";
            this.OrderTime.FieldName = "OrderTime";
            this.OrderTime.Name = "OrderTime";
            this.OrderTime.Visible = true;
            this.OrderTime.VisibleIndex = 2;
            // 
            // PostCode
            // 
            this.PostCode.Caption = "PostCode";
            this.PostCode.FieldName = "PostCode";
            this.PostCode.Name = "PostCode";
            this.PostCode.Visible = true;
            this.PostCode.VisibleIndex = 3;
            // 
            // PostCodeZone
            // 
            this.PostCodeZone.Caption = "PostCode Zone";
            this.PostCodeZone.FieldName = "PostCodeZone";
            this.PostCodeZone.Name = "PostCodeZone";
            this.PostCodeZone.Visible = true;
            this.PostCodeZone.VisibleIndex = 4;
            // 
            // Addr
            // 
            this.Addr.Caption = "Address";
            this.Addr.FieldName = "Addr";
            this.Addr.Name = "Addr";
            this.Addr.Visible = true;
            this.Addr.VisibleIndex = 5;
            // 
            // PayOrderType
            // 
            this.PayOrderType.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayOrderType.AppearanceCell.Options.UseFont = true;
            this.PayOrderType.Caption = "Order Type";
            this.PayOrderType.FieldName = "PayOrderType";
            this.PayOrderType.Name = "PayOrderType";
            this.PayOrderType.Visible = true;
            this.PayOrderType.VisibleIndex = 1;
            // 
            // CustomerName
            // 
            this.CustomerName.Caption = "Customer Name";
            this.CustomerName.FieldName = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Visible = true;
            this.CustomerName.VisibleIndex = 6;
            // 
            // CustomerPhone
            // 
            this.CustomerPhone.Caption = "Phone Number";
            this.CustomerPhone.FieldName = "CustomerPhone";
            this.CustomerPhone.Name = "CustomerPhone";
            this.CustomerPhone.Visible = true;
            this.CustomerPhone.VisibleIndex = 7;
            // 
            // TotalAmount
            // 
            this.TotalAmount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalAmount.AppearanceCell.Options.UseFont = true;
            this.TotalAmount.Caption = "Total Amount";
            this.TotalAmount.FieldName = "TotalAmount";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.Visible = true;
            this.TotalAmount.VisibleIndex = 8;
            // 
            // StaffName
            // 
            this.StaffName.Caption = "Staff Name";
            this.StaffName.FieldName = "StaffName";
            this.StaffName.Name = "StaffName";
            this.StaffName.Visible = true;
            this.StaffName.VisibleIndex = 11;
            // 
            // DriverName
            // 
            this.DriverName.Caption = "Driver";
            this.DriverName.FieldName = "DriverName";
            this.DriverName.Name = "DriverName";
            this.DriverName.Visible = true;
            this.DriverName.VisibleIndex = 10;
            // 
            // IsPaid
            // 
            this.IsPaid.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsPaid.AppearanceCell.Options.UseFont = true;
            this.IsPaid.Caption = "Is Paid";
            this.IsPaid.FieldName = "IsPaid";
            this.IsPaid.Name = "IsPaid";
            this.IsPaid.Visible = true;
            this.IsPaid.VisibleIndex = 9;
            // 
            // menuAmount
            // 
            this.menuAmount.Caption = "Menu Amount";
            this.menuAmount.FieldName = "MenuAmount";
            this.menuAmount.Name = "menuAmount";
            // 
            // Discount
            // 
            this.Discount.Caption = "Discount";
            this.Discount.FieldName = "Discount";
            this.Discount.Name = "Discount";
            // 
            // DiscountPer
            // 
            this.DiscountPer.Caption = "DiscountPer";
            this.DiscountPer.FieldName = "DiscountPer";
            this.DiscountPer.Name = "DiscountPer";
            // 
            // FrmTaShowOrderDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 467);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaShowOrderDriver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTaShowOrderDriver";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDriver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaPendOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LookUpEdit lueDriver;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnShowAllDriver;
        private DevExpress.XtraGrid.GridControl gridControlTaDriver;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaPendOrder;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn CheckCode;
        private DevExpress.XtraGrid.Columns.GridColumn OrderTime;
        private DevExpress.XtraGrid.Columns.GridColumn PostCode;
        private DevExpress.XtraGrid.Columns.GridColumn PostCodeZone;
        private DevExpress.XtraGrid.Columns.GridColumn Addr;
        private DevExpress.XtraGrid.Columns.GridColumn PayOrderType;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerPhone;
        private DevExpress.XtraGrid.Columns.GridColumn TotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn StaffName;
        private DevExpress.XtraGrid.Columns.GridColumn DriverName;
        private DevExpress.XtraGrid.Columns.GridColumn IsPaid;
        private DevExpress.XtraGrid.Columns.GridColumn menuAmount;
        private DevExpress.XtraGrid.Columns.GridColumn Discount;
        private DevExpress.XtraGrid.Columns.GridColumn DiscountPer;
    }
}