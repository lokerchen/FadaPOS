namespace SuperPOS.UI.TA
{
    partial class FrmTaPendOrder
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
            this.gridControlTaPendOrder = new DevExpress.XtraGrid.GridControl();
            this.gvTaPendOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.IsSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BusDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridRefNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDeliveryFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridSurcharge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPrtKit = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrtBill = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrtReceipt = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpen = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelivery = new DevExpress.XtraEditors.SimpleButton();
            this.btnCollection = new DevExpress.XtraEditors.SimpleButton();
            this.btnShop = new DevExpress.XtraEditors.SimpleButton();
            this.btnAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnPay = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.lueDriver = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnNotPaid = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveOrder = new DevExpress.XtraEditors.SimpleButton();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnAssignDriver = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowAssigned = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowUnAssigned = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaPendOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaPendOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDriver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlTaPendOrder);
            this.panelControl1.Location = new System.Drawing.Point(10, 9);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(658, 392);
            this.panelControl1.TabIndex = 0;
            // 
            // gridControlTaPendOrder
            // 
            this.gridControlTaPendOrder.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlTaPendOrder.Font = new System.Drawing.Font("Calibri", 14F);
            this.gridControlTaPendOrder.Location = new System.Drawing.Point(4, 4);
            this.gridControlTaPendOrder.MainView = this.gvTaPendOrder;
            this.gridControlTaPendOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlTaPendOrder.Name = "gridControlTaPendOrder";
            this.gridControlTaPendOrder.Size = new System.Drawing.Size(649, 384);
            this.gridControlTaPendOrder.TabIndex = 3;
            this.gridControlTaPendOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaPendOrder});
            // 
            // gvTaPendOrder
            // 
            this.gvTaPendOrder.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvTaPendOrder.Appearance.EvenRow.Font = new System.Drawing.Font("Calibri", 14F);
            this.gvTaPendOrder.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTaPendOrder.Appearance.EvenRow.Options.UseFont = true;
            this.gvTaPendOrder.Appearance.HeaderPanel.Font = new System.Drawing.Font("Calibri", 10F);
            this.gvTaPendOrder.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvTaPendOrder.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvTaPendOrder.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTaPendOrder.Appearance.OddRow.Font = new System.Drawing.Font("Calibri", 14F);
            this.gvTaPendOrder.Appearance.OddRow.Options.UseFont = true;
            this.gvTaPendOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.OrderNo,
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
            this.DiscountPer,
            this.IsSave,
            this.BusDate,
            this.gridRefNum,
            this.gridDeliveryFee,
            this.gridSurcharge});
            this.gvTaPendOrder.DetailHeight = 272;
            this.gvTaPendOrder.GridControl = this.gridControlTaPendOrder;
            this.gvTaPendOrder.IndicatorWidth = 44;
            this.gvTaPendOrder.Name = "gvTaPendOrder";
            this.gvTaPendOrder.OptionsBehavior.Editable = false;
            this.gvTaPendOrder.OptionsMenu.EnableColumnMenu = false;
            this.gvTaPendOrder.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaPendOrder.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaPendOrder.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaPendOrder.OptionsView.ShowGroupPanel = false;
            this.gvTaPendOrder.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvTaPendOrder_CustomDrawRowIndicator);
            this.gvTaPendOrder.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvTaPendOrder_FocusedRowChanged);
            this.gvTaPendOrder.DoubleClick += new System.EventHandler(this.gvTaPendOrder_DoubleClick);
            // 
            // ID
            // 
            this.ID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.AppearanceCell.Options.UseFont = true;
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.MinWidth = 17;
            this.ID.Name = "ID";
            this.ID.Width = 66;
            // 
            // OrderNo
            // 
            this.OrderNo.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F);
            this.OrderNo.AppearanceCell.Options.UseFont = true;
            this.OrderNo.Caption = "Order No";
            this.OrderNo.FieldName = "OtherCheckCode";
            this.OrderNo.MinWidth = 17;
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.Visible = true;
            this.OrderNo.VisibleIndex = 0;
            this.OrderNo.Width = 66;
            // 
            // CheckCode
            // 
            this.CheckCode.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckCode.AppearanceCell.Options.UseFont = true;
            this.CheckCode.Caption = "Order No.";
            this.CheckCode.FieldName = "CheckCode";
            this.CheckCode.MinWidth = 17;
            this.CheckCode.Name = "CheckCode";
            this.CheckCode.Width = 66;
            // 
            // OrderTime
            // 
            this.OrderTime.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F);
            this.OrderTime.AppearanceCell.Options.UseFont = true;
            this.OrderTime.Caption = "Order Time";
            this.OrderTime.FieldName = "OrderTime";
            this.OrderTime.MinWidth = 17;
            this.OrderTime.Name = "OrderTime";
            this.OrderTime.Visible = true;
            this.OrderTime.VisibleIndex = 2;
            // 
            // PostCode
            // 
            this.PostCode.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F);
            this.PostCode.AppearanceCell.Options.UseFont = true;
            this.PostCode.Caption = "PostCode";
            this.PostCode.FieldName = "PostCode";
            this.PostCode.MinWidth = 17;
            this.PostCode.Name = "PostCode";
            this.PostCode.Visible = true;
            this.PostCode.VisibleIndex = 3;
            this.PostCode.Width = 66;
            // 
            // PostCodeZone
            // 
            this.PostCodeZone.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F);
            this.PostCodeZone.AppearanceCell.Options.UseFont = true;
            this.PostCodeZone.Caption = "PostCode Zone";
            this.PostCodeZone.FieldName = "PostCodeZone";
            this.PostCodeZone.MinWidth = 17;
            this.PostCodeZone.Name = "PostCodeZone";
            this.PostCodeZone.Visible = true;
            this.PostCodeZone.VisibleIndex = 4;
            this.PostCodeZone.Width = 66;
            // 
            // Addr
            // 
            this.Addr.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F);
            this.Addr.AppearanceCell.Options.UseFont = true;
            this.Addr.Caption = "Address";
            this.Addr.FieldName = "Addr";
            this.Addr.MinWidth = 17;
            this.Addr.Name = "Addr";
            this.Addr.Visible = true;
            this.Addr.VisibleIndex = 5;
            this.Addr.Width = 66;
            // 
            // PayOrderType
            // 
            this.PayOrderType.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayOrderType.AppearanceCell.Options.UseFont = true;
            this.PayOrderType.Caption = "Order Type";
            this.PayOrderType.FieldName = "PayOrderType";
            this.PayOrderType.MinWidth = 17;
            this.PayOrderType.Name = "PayOrderType";
            this.PayOrderType.Visible = true;
            this.PayOrderType.VisibleIndex = 1;
            this.PayOrderType.Width = 66;
            // 
            // CustomerName
            // 
            this.CustomerName.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F);
            this.CustomerName.AppearanceCell.Options.UseFont = true;
            this.CustomerName.Caption = "Customer Name";
            this.CustomerName.FieldName = "CustomerName";
            this.CustomerName.MinWidth = 17;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Visible = true;
            this.CustomerName.VisibleIndex = 6;
            this.CustomerName.Width = 66;
            // 
            // CustomerPhone
            // 
            this.CustomerPhone.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F);
            this.CustomerPhone.AppearanceCell.Options.UseFont = true;
            this.CustomerPhone.Caption = "Phone Number";
            this.CustomerPhone.FieldName = "CustomerPhone";
            this.CustomerPhone.MinWidth = 17;
            this.CustomerPhone.Name = "CustomerPhone";
            this.CustomerPhone.Visible = true;
            this.CustomerPhone.VisibleIndex = 7;
            this.CustomerPhone.Width = 66;
            // 
            // TotalAmount
            // 
            this.TotalAmount.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalAmount.AppearanceCell.Options.UseFont = true;
            this.TotalAmount.Caption = "Total Amount";
            this.TotalAmount.FieldName = "TotalAmount";
            this.TotalAmount.MinWidth = 17;
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.Visible = true;
            this.TotalAmount.VisibleIndex = 8;
            this.TotalAmount.Width = 66;
            // 
            // StaffName
            // 
            this.StaffName.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F);
            this.StaffName.AppearanceCell.Options.UseFont = true;
            this.StaffName.Caption = "Staff Name";
            this.StaffName.FieldName = "StaffName";
            this.StaffName.MinWidth = 17;
            this.StaffName.Name = "StaffName";
            this.StaffName.Visible = true;
            this.StaffName.VisibleIndex = 11;
            this.StaffName.Width = 66;
            // 
            // DriverName
            // 
            this.DriverName.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F);
            this.DriverName.AppearanceCell.Options.UseFont = true;
            this.DriverName.Caption = "Driver";
            this.DriverName.FieldName = "DriverName";
            this.DriverName.MinWidth = 17;
            this.DriverName.Name = "DriverName";
            this.DriverName.Visible = true;
            this.DriverName.VisibleIndex = 10;
            this.DriverName.Width = 66;
            // 
            // IsPaid
            // 
            this.IsPaid.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsPaid.AppearanceCell.Options.UseFont = true;
            this.IsPaid.Caption = "Is Paid";
            this.IsPaid.FieldName = "IsPaid";
            this.IsPaid.MinWidth = 17;
            this.IsPaid.Name = "IsPaid";
            this.IsPaid.Visible = true;
            this.IsPaid.VisibleIndex = 9;
            this.IsPaid.Width = 66;
            // 
            // menuAmount
            // 
            this.menuAmount.Caption = "Menu Amount";
            this.menuAmount.FieldName = "MenuAmount";
            this.menuAmount.MinWidth = 17;
            this.menuAmount.Name = "menuAmount";
            this.menuAmount.Width = 66;
            // 
            // Discount
            // 
            this.Discount.Caption = "Discount";
            this.Discount.FieldName = "Discount";
            this.Discount.MinWidth = 17;
            this.Discount.Name = "Discount";
            this.Discount.Width = 66;
            // 
            // DiscountPer
            // 
            this.DiscountPer.Caption = "DiscountPer";
            this.DiscountPer.FieldName = "DiscountPer";
            this.DiscountPer.MinWidth = 17;
            this.DiscountPer.Name = "DiscountPer";
            this.DiscountPer.Width = 66;
            // 
            // IsSave
            // 
            this.IsSave.Caption = "Is Save";
            this.IsSave.FieldName = "IsSave";
            this.IsSave.MinWidth = 17;
            this.IsSave.Name = "IsSave";
            this.IsSave.Width = 66;
            // 
            // BusDate
            // 
            this.BusDate.AppearanceCell.Font = new System.Drawing.Font("Calibri", 14F);
            this.BusDate.AppearanceCell.Options.UseFont = true;
            this.BusDate.Caption = "BusDate";
            this.BusDate.FieldName = "gridBusDate";
            this.BusDate.MinWidth = 17;
            this.BusDate.Name = "BusDate";
            this.BusDate.Visible = true;
            this.BusDate.VisibleIndex = 12;
            this.BusDate.Width = 66;
            // 
            // gridRefNum
            // 
            this.gridRefNum.Caption = "gridRefNum";
            this.gridRefNum.FieldName = "gridRefNum";
            this.gridRefNum.Name = "gridRefNum";
            this.gridRefNum.Width = 66;
            // 
            // gridDeliveryFee
            // 
            this.gridDeliveryFee.Caption = "gridRefNum";
            this.gridDeliveryFee.FieldName = "gridDeliveryFee";
            this.gridDeliveryFee.Name = "gridDeliveryFee";
            this.gridDeliveryFee.Width = 66;
            // 
            // gridSurcharge
            // 
            this.gridSurcharge.Caption = "gridRefNum";
            this.gridSurcharge.FieldName = "gridSurcharge";
            this.gridSurcharge.Name = "gridSurcharge";
            this.gridSurcharge.Width = 66;
            // 
            // btnPrtKit
            // 
            this.btnPrtKit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnPrtKit.Appearance.Options.UseFont = true;
            this.btnPrtKit.Location = new System.Drawing.Point(869, 97);
            this.btnPrtKit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrtKit.Name = "btnPrtKit";
            this.btnPrtKit.Size = new System.Drawing.Size(161, 37);
            this.btnPrtKit.TabIndex = 43;
            this.btnPrtKit.Text = "Print Kitchen";
            this.btnPrtKit.Visible = false;
            this.btnPrtKit.Click += new System.EventHandler(this.btnPrtKit_Click);
            // 
            // btnPrtBill
            // 
            this.btnPrtBill.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnPrtBill.Appearance.Options.UseFont = true;
            this.btnPrtBill.Location = new System.Drawing.Point(869, 55);
            this.btnPrtBill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrtBill.Name = "btnPrtBill";
            this.btnPrtBill.Size = new System.Drawing.Size(161, 37);
            this.btnPrtBill.TabIndex = 42;
            this.btnPrtBill.Text = "Print Bill";
            this.btnPrtBill.Visible = false;
            this.btnPrtBill.Click += new System.EventHandler(this.btnPrtBill_Click);
            // 
            // btnPrtReceipt
            // 
            this.btnPrtReceipt.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnPrtReceipt.Appearance.Options.UseFont = true;
            this.btnPrtReceipt.Location = new System.Drawing.Point(869, 13);
            this.btnPrtReceipt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrtReceipt.Name = "btnPrtReceipt";
            this.btnPrtReceipt.Size = new System.Drawing.Size(161, 37);
            this.btnPrtReceipt.TabIndex = 41;
            this.btnPrtReceipt.Text = "Print Receipt";
            this.btnPrtReceipt.Visible = false;
            this.btnPrtReceipt.Click += new System.EventHandler(this.btnPrtReceipt_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOpen.Appearance.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Appearance.Options.UseBackColor = true;
            this.btnOpen.Appearance.Options.UseFont = true;
            this.btnOpen.Appearance.Options.UseForeColor = true;
            this.btnOpen.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnOpen.Location = new System.Drawing.Point(4, 23);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(161, 37);
            this.btnOpen.TabIndex = 50;
            this.btnOpen.Text = "OPEN";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnDelivery
            // 
            this.btnDelivery.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnDelivery.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnDelivery.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDelivery.Appearance.Options.UseBackColor = true;
            this.btnDelivery.Appearance.Options.UseFont = true;
            this.btnDelivery.Appearance.Options.UseForeColor = true;
            this.btnDelivery.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnDelivery.Location = new System.Drawing.Point(177, 7);
            this.btnDelivery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(87, 31);
            this.btnDelivery.TabIndex = 44;
            this.btnDelivery.Text = "DELIVERY";
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // btnCollection
            // 
            this.btnCollection.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnCollection.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnCollection.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCollection.Appearance.Options.UseBackColor = true;
            this.btnCollection.Appearance.Options.UseFont = true;
            this.btnCollection.Appearance.Options.UseForeColor = true;
            this.btnCollection.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnCollection.Location = new System.Drawing.Point(269, 7);
            this.btnCollection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Size = new System.Drawing.Size(101, 31);
            this.btnCollection.TabIndex = 45;
            this.btnCollection.Text = "COLLECTION";
            this.btnCollection.Click += new System.EventHandler(this.btnCollection_Click);
            // 
            // btnShop
            // 
            this.btnShop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnShop.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnShop.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnShop.Appearance.Options.UseBackColor = true;
            this.btnShop.Appearance.Options.UseFont = true;
            this.btnShop.Appearance.Options.UseForeColor = true;
            this.btnShop.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnShop.Location = new System.Drawing.Point(374, 7);
            this.btnShop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(70, 31);
            this.btnShop.TabIndex = 46;
            this.btnShop.Text = "SHOP";
            this.btnShop.Click += new System.EventHandler(this.btnShop_Click);
            // 
            // btnAll
            // 
            this.btnAll.Appearance.BackColor = System.Drawing.Color.Green;
            this.btnAll.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnAll.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAll.Appearance.Options.UseBackColor = true;
            this.btnAll.Appearance.Options.UseFont = true;
            this.btnAll.Appearance.Options.UseForeColor = true;
            this.btnAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnAll.Location = new System.Drawing.Point(868, 139);
            this.btnAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(162, 37);
            this.btnAll.TabIndex = 47;
            this.btnAll.Text = "All";
            this.btnAll.Visible = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnPay
            // 
            this.btnPay.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnPay.Appearance.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnPay.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPay.Appearance.Options.UseBackColor = true;
            this.btnPay.Appearance.Options.UseFont = true;
            this.btnPay.Appearance.Options.UseForeColor = true;
            this.btnPay.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPay.Location = new System.Drawing.Point(6, 390);
            this.btnPay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(165, 37);
            this.btnPay.TabIndex = 44;
            this.btnPay.Text = "PAY";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Appearance.Options.UseForeColor = true;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExit.Location = new System.Drawing.Point(9, 439);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(161, 37);
            this.btnExit.TabIndex = 48;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnPreview);
            this.panelControl3.Controls.Add(this.btnOpen);
            this.panelControl3.Controls.Add(this.btnPay);
            this.panelControl3.Controls.Add(this.btnExit);
            this.panelControl3.Location = new System.Drawing.Point(674, 9);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(176, 487);
            this.panelControl3.TabIndex = 49;
            // 
            // btnPreview
            // 
            this.btnPreview.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnPreview.Appearance.Font = new System.Drawing.Font("Calibri", 14F);
            this.btnPreview.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPreview.Appearance.Options.UseBackColor = true;
            this.btnPreview.Appearance.Options.UseFont = true;
            this.btnPreview.Appearance.Options.UseForeColor = true;
            this.btnPreview.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPreview.Location = new System.Drawing.Point(4, 74);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(165, 37);
            this.btnPreview.TabIndex = 51;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lueDriver
            // 
            this.lueDriver.Location = new System.Drawing.Point(197, 460);
            this.lueDriver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lueDriver.Name = "lueDriver";
            this.lueDriver.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueDriver.Properties.Appearance.Options.UseFont = true;
            this.lueDriver.Properties.AutoHeight = false;
            this.lueDriver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDriver.Size = new System.Drawing.Size(137, 31);
            this.lueDriver.TabIndex = 51;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 11F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(111, 460);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 31);
            this.labelControl1.TabIndex = 52;
            this.labelControl1.Text = "Show Driver";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.btnNotPaid);
            this.panelControl4.Controls.Add(this.btnSaveOrder);
            this.panelControl4.Controls.Add(this.txtTotal);
            this.panelControl4.Controls.Add(this.labelControl2);
            this.panelControl4.Controls.Add(this.btnDelivery);
            this.panelControl4.Controls.Add(this.btnCollection);
            this.panelControl4.Controls.Add(this.btnShop);
            this.panelControl4.Location = new System.Drawing.Point(10, 407);
            this.panelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(658, 47);
            this.panelControl4.TabIndex = 50;
            // 
            // btnNotPaid
            // 
            this.btnNotPaid.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnNotPaid.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnNotPaid.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnNotPaid.Appearance.Options.UseBackColor = true;
            this.btnNotPaid.Appearance.Options.UseFont = true;
            this.btnNotPaid.Appearance.Options.UseForeColor = true;
            this.btnNotPaid.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnNotPaid.Location = new System.Drawing.Point(552, 7);
            this.btnNotPaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNotPaid.Name = "btnNotPaid";
            this.btnNotPaid.Size = new System.Drawing.Size(101, 31);
            this.btnNotPaid.TabIndex = 50;
            this.btnNotPaid.Text = "Not Paid";
            this.btnNotPaid.Click += new System.EventHandler(this.btnNotPaid_Click);
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Appearance.BackColor = System.Drawing.Color.Orange;
            this.btnSaveOrder.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnSaveOrder.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSaveOrder.Appearance.Options.UseBackColor = true;
            this.btnSaveOrder.Appearance.Options.UseFont = true;
            this.btnSaveOrder.Appearance.Options.UseForeColor = true;
            this.btnSaveOrder.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnSaveOrder.Location = new System.Drawing.Point(450, 7);
            this.btnSaveOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(95, 31);
            this.btnSaveOrder.TabIndex = 49;
            this.btnSaveOrder.Text = "Save Orders";
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.EditValue = "0.00";
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(69, 10);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 16F);
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotal.Size = new System.Drawing.Size(88, 32);
            this.txtTotal.TabIndex = 48;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(4, 13);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 26);
            this.labelControl2.TabIndex = 47;
            this.labelControl2.Text = "Total:";
            // 
            // btnAssignDriver
            // 
            this.btnAssignDriver.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnAssignDriver.Appearance.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnAssignDriver.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAssignDriver.Appearance.Options.UseBackColor = true;
            this.btnAssignDriver.Appearance.Options.UseFont = true;
            this.btnAssignDriver.Appearance.Options.UseForeColor = true;
            this.btnAssignDriver.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnAssignDriver.Location = new System.Drawing.Point(15, 460);
            this.btnAssignDriver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAssignDriver.Name = "btnAssignDriver";
            this.btnAssignDriver.Size = new System.Drawing.Size(90, 31);
            this.btnAssignDriver.TabIndex = 49;
            this.btnAssignDriver.Text = "Assign Driver";
            this.btnAssignDriver.Click += new System.EventHandler(this.btnAssignDriver_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnShowAll.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnShowAll.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.Appearance.Options.UseBackColor = true;
            this.btnShowAll.Appearance.Options.UseFont = true;
            this.btnShowAll.Appearance.Options.UseForeColor = true;
            this.btnShowAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnShowAll.Location = new System.Drawing.Point(365, 460);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(79, 31);
            this.btnShowAll.TabIndex = 53;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnShowAssigned
            // 
            this.btnShowAssigned.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnShowAssigned.Appearance.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnShowAssigned.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnShowAssigned.Appearance.Options.UseBackColor = true;
            this.btnShowAssigned.Appearance.Options.UseFont = true;
            this.btnShowAssigned.Appearance.Options.UseForeColor = true;
            this.btnShowAssigned.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnShowAssigned.Location = new System.Drawing.Point(449, 460);
            this.btnShowAssigned.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowAssigned.Name = "btnShowAssigned";
            this.btnShowAssigned.Size = new System.Drawing.Size(96, 31);
            this.btnShowAssigned.TabIndex = 54;
            this.btnShowAssigned.Text = "Show Assigned";
            this.btnShowAssigned.Click += new System.EventHandler(this.btnShowAssigned_Click);
            // 
            // btnShowUnAssigned
            // 
            this.btnShowUnAssigned.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnShowUnAssigned.Appearance.Font = new System.Drawing.Font("Calibri", 11F);
            this.btnShowUnAssigned.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnShowUnAssigned.Appearance.Options.UseBackColor = true;
            this.btnShowUnAssigned.Appearance.Options.UseFont = true;
            this.btnShowUnAssigned.Appearance.Options.UseForeColor = true;
            this.btnShowUnAssigned.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnShowUnAssigned.Location = new System.Drawing.Point(550, 460);
            this.btnShowUnAssigned.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowUnAssigned.Name = "btnShowUnAssigned";
            this.btnShowUnAssigned.Size = new System.Drawing.Size(114, 31);
            this.btnShowUnAssigned.TabIndex = 55;
            this.btnShowUnAssigned.Text = "Show Unassigned";
            this.btnShowUnAssigned.Click += new System.EventHandler(this.btnShowUnAssigned_Click);
            // 
            // FrmTaPendOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 506);
            this.Controls.Add(this.btnShowUnAssigned);
            this.Controls.Add(this.btnShowAssigned);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.lueDriver);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnAssignDriver);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.btnPrtKit);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.btnPrtReceipt);
            this.Controls.Add(this.btnPrtBill);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmTaPendOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "s";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaPendOrder_Load);
            this.SizeChanged += new System.EventHandler(this.FrmTaPendOrder_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaPendOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaPendOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueDriver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlTaPendOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaPendOrder;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn CheckCode;
        private DevExpress.XtraGrid.Columns.GridColumn PayOrderType;
        private DevExpress.XtraGrid.Columns.GridColumn TotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn IsPaid;
        private DevExpress.XtraEditors.SimpleButton btnPrtKit;
        private DevExpress.XtraEditors.SimpleButton btnPrtBill;
        private DevExpress.XtraEditors.SimpleButton btnPrtReceipt;
        private DevExpress.XtraEditors.SimpleButton btnPay;
        private DevExpress.XtraEditors.SimpleButton btnDelivery;
        private DevExpress.XtraEditors.SimpleButton btnCollection;
        private DevExpress.XtraEditors.SimpleButton btnShop;
        private DevExpress.XtraEditors.SimpleButton btnAll;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn StaffName;
        private DevExpress.XtraGrid.Columns.GridColumn OrderTime;
        private DevExpress.XtraGrid.Columns.GridColumn PostCode;
        private DevExpress.XtraGrid.Columns.GridColumn PostCodeZone;
        private DevExpress.XtraGrid.Columns.GridColumn Addr;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerPhone;
        private DevExpress.XtraGrid.Columns.GridColumn DriverName;
        private DevExpress.XtraEditors.SimpleButton btnOpen;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueDriver;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnAssignDriver;
        private DevExpress.XtraEditors.SimpleButton btnShowAll;
        private DevExpress.XtraEditors.SimpleButton btnShowAssigned;
        private DevExpress.XtraEditors.SimpleButton btnShowUnAssigned;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraGrid.Columns.GridColumn menuAmount;
        private DevExpress.XtraGrid.Columns.GridColumn Discount;
        private DevExpress.XtraGrid.Columns.GridColumn DiscountPer;
        private DevExpress.XtraEditors.SimpleButton btnNotPaid;
        private DevExpress.XtraEditors.SimpleButton btnSaveOrder;
        private DevExpress.XtraGrid.Columns.GridColumn IsSave;
        private DevExpress.XtraGrid.Columns.GridColumn OrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn BusDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridRefNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridDeliveryFee;
        private DevExpress.XtraGrid.Columns.GridColumn gridSurcharge;
    }
}