namespace SuperPOS.UI
{
    partial class FrmTaShowOrder
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
            this.richEditCtlPreview = new DevExpress.XtraRichEdit.RichEditControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.btnAccount = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrtReceipt = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrtKit = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrtBill = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.btnShowDriver = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditOrder = new DevExpress.XtraEditors.SimpleButton();
            this.btnChangePayment = new DevExpress.XtraEditors.SimpleButton();
            this.btnEatIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelivery = new DevExpress.XtraEditors.SimpleButton();
            this.btnShop = new DevExpress.XtraEditors.SimpleButton();
            this.btnCollection = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlTaShowOrder = new DevExpress.XtraGrid.GridControl();
            this.gvTaShowOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CheckCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Payment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PayOrderType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StaffName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DriverName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiscountPer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Discount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SubToal = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaShowOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaShowOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.richEditCtlPreview);
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Location = new System.Drawing.Point(6, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1189, 638);
            this.panelControl1.TabIndex = 0;
            // 
            // richEditCtlPreview
            // 
            this.richEditCtlPreview.EnableToolTips = true;
            this.richEditCtlPreview.Location = new System.Drawing.Point(7, 5);
            this.richEditCtlPreview.Margin = new System.Windows.Forms.Padding(0);
            this.richEditCtlPreview.Name = "richEditCtlPreview";
            this.richEditCtlPreview.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never;
            this.richEditCtlPreview.Options.Fields.UpdateFieldsInTextBoxes = false;
            this.richEditCtlPreview.Options.HorizontalRuler.ShowTabs = false;
            this.richEditCtlPreview.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditCtlPreview.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richEditCtlPreview.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditCtlPreview.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richEditCtlPreview.Size = new System.Drawing.Size(368, 628);
            this.richEditCtlPreview.TabIndex = 3;
            this.richEditCtlPreview.Text = "rich";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.panelControl5);
            this.panelControl4.Controls.Add(this.btnExit);
            this.panelControl4.Controls.Add(this.panelControl6);
            this.panelControl4.Controls.Add(this.gridControlTaShowOrder);
            this.panelControl4.Location = new System.Drawing.Point(381, 5);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(801, 627);
            this.panelControl4.TabIndex = 2;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.btnAccount);
            this.panelControl5.Controls.Add(this.btnPrtReceipt);
            this.panelControl5.Controls.Add(this.btnPrtKit);
            this.panelControl5.Controls.Add(this.btnPrtBill);
            this.panelControl5.Location = new System.Drawing.Point(664, 56);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(130, 393);
            this.panelControl5.TabIndex = 64;
            // 
            // btnAccount
            // 
            this.btnAccount.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAccount.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnAccount.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAccount.Appearance.Options.UseBackColor = true;
            this.btnAccount.Appearance.Options.UseFont = true;
            this.btnAccount.Appearance.Options.UseForeColor = true;
            this.btnAccount.Appearance.Options.UseTextOptions = true;
            this.btnAccount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnAccount.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnAccount.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnAccount.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnAccount.Location = new System.Drawing.Point(8, 297);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(115, 90);
            this.btnAccount.TabIndex = 55;
            this.btnAccount.Text = "Print Account Summary";
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnPrtReceipt
            // 
            this.btnPrtReceipt.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPrtReceipt.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnPrtReceipt.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPrtReceipt.Appearance.Options.UseBackColor = true;
            this.btnPrtReceipt.Appearance.Options.UseFont = true;
            this.btnPrtReceipt.Appearance.Options.UseForeColor = true;
            this.btnPrtReceipt.Appearance.Options.UseTextOptions = true;
            this.btnPrtReceipt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPrtReceipt.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnPrtReceipt.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPrtReceipt.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPrtReceipt.Location = new System.Drawing.Point(8, 6);
            this.btnPrtReceipt.Name = "btnPrtReceipt";
            this.btnPrtReceipt.Size = new System.Drawing.Size(115, 90);
            this.btnPrtReceipt.TabIndex = 52;
            this.btnPrtReceipt.Text = "Print Receipt";
            this.btnPrtReceipt.Click += new System.EventHandler(this.btnPrtReceipt_Click);
            // 
            // btnPrtKit
            // 
            this.btnPrtKit.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPrtKit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnPrtKit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPrtKit.Appearance.Options.UseBackColor = true;
            this.btnPrtKit.Appearance.Options.UseFont = true;
            this.btnPrtKit.Appearance.Options.UseForeColor = true;
            this.btnPrtKit.Appearance.Options.UseTextOptions = true;
            this.btnPrtKit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPrtKit.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnPrtKit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPrtKit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPrtKit.Location = new System.Drawing.Point(8, 201);
            this.btnPrtKit.Name = "btnPrtKit";
            this.btnPrtKit.Size = new System.Drawing.Size(115, 90);
            this.btnPrtKit.TabIndex = 54;
            this.btnPrtKit.Text = "Print Kitchen Paper";
            this.btnPrtKit.Click += new System.EventHandler(this.btnPrtKit_Click);
            // 
            // btnPrtBill
            // 
            this.btnPrtBill.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPrtBill.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnPrtBill.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPrtBill.Appearance.Options.UseBackColor = true;
            this.btnPrtBill.Appearance.Options.UseFont = true;
            this.btnPrtBill.Appearance.Options.UseForeColor = true;
            this.btnPrtBill.Appearance.Options.UseTextOptions = true;
            this.btnPrtBill.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPrtBill.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnPrtBill.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPrtBill.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPrtBill.Location = new System.Drawing.Point(8, 105);
            this.btnPrtBill.Name = "btnPrtBill";
            this.btnPrtBill.Size = new System.Drawing.Size(115, 90);
            this.btnPrtBill.TabIndex = 53;
            this.btnPrtBill.Text = "Print Bill";
            this.btnPrtBill.Click += new System.EventHandler(this.btnPrtBill_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = System.Drawing.Color.Olive;
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Appearance.Options.UseForeColor = true;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExit.Location = new System.Drawing.Point(671, 530);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 86);
            this.btnExit.TabIndex = 61;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.btnShowDriver);
            this.panelControl6.Controls.Add(this.btnEditOrder);
            this.panelControl6.Controls.Add(this.btnChangePayment);
            this.panelControl6.Controls.Add(this.btnEatIn);
            this.panelControl6.Controls.Add(this.btnAll);
            this.panelControl6.Controls.Add(this.btnDelivery);
            this.panelControl6.Controls.Add(this.btnShop);
            this.panelControl6.Controls.Add(this.btnCollection);
            this.panelControl6.Location = new System.Drawing.Point(5, 525);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(652, 95);
            this.panelControl6.TabIndex = 66;
            // 
            // btnShowDriver
            // 
            this.btnShowDriver.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnShowDriver.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowDriver.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnShowDriver.Appearance.Options.UseBackColor = true;
            this.btnShowDriver.Appearance.Options.UseFont = true;
            this.btnShowDriver.Appearance.Options.UseForeColor = true;
            this.btnShowDriver.Appearance.Options.UseTextOptions = true;
            this.btnShowDriver.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnShowDriver.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnShowDriver.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnShowDriver.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnShowDriver.Location = new System.Drawing.Point(459, 51);
            this.btnShowDriver.Name = "btnShowDriver";
            this.btnShowDriver.Size = new System.Drawing.Size(143, 40);
            this.btnShowDriver.TabIndex = 63;
            this.btnShowDriver.Text = "Show Driver D/C";
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEditOrder.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditOrder.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnEditOrder.Appearance.Options.UseBackColor = true;
            this.btnEditOrder.Appearance.Options.UseFont = true;
            this.btnEditOrder.Appearance.Options.UseForeColor = true;
            this.btnEditOrder.Appearance.Options.UseTextOptions = true;
            this.btnEditOrder.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnEditOrder.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnEditOrder.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEditOrder.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnEditOrder.Location = new System.Drawing.Point(355, 51);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(98, 40);
            this.btnEditOrder.TabIndex = 62;
            this.btnEditOrder.Text = "Edit Order";
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // btnChangePayment
            // 
            this.btnChangePayment.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnChangePayment.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePayment.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnChangePayment.Appearance.Options.UseBackColor = true;
            this.btnChangePayment.Appearance.Options.UseFont = true;
            this.btnChangePayment.Appearance.Options.UseForeColor = true;
            this.btnChangePayment.Appearance.Options.UseTextOptions = true;
            this.btnChangePayment.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnChangePayment.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnChangePayment.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnChangePayment.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnChangePayment.Location = new System.Drawing.Point(211, 51);
            this.btnChangePayment.Name = "btnChangePayment";
            this.btnChangePayment.Size = new System.Drawing.Size(138, 40);
            this.btnChangePayment.TabIndex = 61;
            this.btnChangePayment.Text = "Change Payment";
            this.btnChangePayment.Click += new System.EventHandler(this.btnChangePayment_Click);
            // 
            // btnEatIn
            // 
            this.btnEatIn.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEatIn.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnEatIn.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnEatIn.Appearance.Options.UseBackColor = true;
            this.btnEatIn.Appearance.Options.UseFont = true;
            this.btnEatIn.Appearance.Options.UseForeColor = true;
            this.btnEatIn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnEatIn.Location = new System.Drawing.Point(512, 5);
            this.btnEatIn.Name = "btnEatIn";
            this.btnEatIn.Size = new System.Drawing.Size(90, 40);
            this.btnEatIn.TabIndex = 60;
            this.btnEatIn.Text = "Eat In";
            this.btnEatIn.Click += new System.EventHandler(this.btnEatIn_Click);
            // 
            // btnAll
            // 
            this.btnAll.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAll.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAll.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAll.Appearance.Options.UseBackColor = true;
            this.btnAll.Appearance.Options.UseFont = true;
            this.btnAll.Appearance.Options.UseForeColor = true;
            this.btnAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnAll.Location = new System.Drawing.Point(16, 5);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(98, 40);
            this.btnAll.TabIndex = 59;
            this.btnAll.Text = "Show All";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnDelivery
            // 
            this.btnDelivery.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDelivery.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDelivery.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDelivery.Appearance.Options.UseBackColor = true;
            this.btnDelivery.Appearance.Options.UseFont = true;
            this.btnDelivery.Appearance.Options.UseForeColor = true;
            this.btnDelivery.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnDelivery.Location = new System.Drawing.Point(279, 5);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(131, 40);
            this.btnDelivery.TabIndex = 56;
            this.btnDelivery.Text = "DELIVERY";
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // btnShop
            // 
            this.btnShop.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnShop.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnShop.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnShop.Appearance.Options.UseBackColor = true;
            this.btnShop.Appearance.Options.UseFont = true;
            this.btnShop.Appearance.Options.UseForeColor = true;
            this.btnShop.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnShop.Location = new System.Drawing.Point(416, 5);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(90, 40);
            this.btnShop.TabIndex = 58;
            this.btnShop.Text = "SHOP";
            this.btnShop.Click += new System.EventHandler(this.btnShop_Click);
            // 
            // btnCollection
            // 
            this.btnCollection.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCollection.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnCollection.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCollection.Appearance.Options.UseBackColor = true;
            this.btnCollection.Appearance.Options.UseFont = true;
            this.btnCollection.Appearance.Options.UseForeColor = true;
            this.btnCollection.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnCollection.Location = new System.Drawing.Point(129, 5);
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Size = new System.Drawing.Size(144, 40);
            this.btnCollection.TabIndex = 57;
            this.btnCollection.Text = "COLLECTION";
            this.btnCollection.Click += new System.EventHandler(this.btnCollection_Click);
            // 
            // gridControlTaShowOrder
            // 
            this.gridControlTaShowOrder.Location = new System.Drawing.Point(5, 13);
            this.gridControlTaShowOrder.MainView = this.gvTaShowOrder;
            this.gridControlTaShowOrder.Name = "gridControlTaShowOrder";
            this.gridControlTaShowOrder.Size = new System.Drawing.Size(653, 506);
            this.gridControlTaShowOrder.TabIndex = 65;
            this.gridControlTaShowOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaShowOrder});
            // 
            // gvTaShowOrder
            // 
            this.gvTaShowOrder.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvTaShowOrder.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTaShowOrder.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvTaShowOrder.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTaShowOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.CheckCode,
            this.OrderTime,
            this.Payment,
            this.PayOrderType,
            this.TotalAmount,
            this.StaffName,
            this.DriverName,
            this.CustomerID,
            this.DiscountPer,
            this.Discount,
            this.SubToal});
            this.gvTaShowOrder.GridControl = this.gridControlTaShowOrder;
            this.gvTaShowOrder.IndicatorWidth = 50;
            this.gvTaShowOrder.Name = "gvTaShowOrder";
            this.gvTaShowOrder.OptionsBehavior.Editable = false;
            this.gvTaShowOrder.OptionsMenu.EnableColumnMenu = false;
            this.gvTaShowOrder.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaShowOrder.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaShowOrder.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaShowOrder.OptionsView.ShowGroupPanel = false;
            this.gvTaShowOrder.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvTaShowOrder_CustomDrawRowIndicator);
            this.gvTaShowOrder.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvTaShowOrder_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.AppearanceCell.Options.UseFont = true;
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // CheckCode
            // 
            this.CheckCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckCode.AppearanceCell.Options.UseFont = true;
            this.CheckCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckCode.AppearanceHeader.Options.UseFont = true;
            this.CheckCode.Caption = "Order No.";
            this.CheckCode.FieldName = "gridOrderNo";
            this.CheckCode.Name = "CheckCode";
            this.CheckCode.Visible = true;
            this.CheckCode.VisibleIndex = 0;
            // 
            // OrderTime
            // 
            this.OrderTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.OrderTime.AppearanceCell.Options.UseFont = true;
            this.OrderTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderTime.AppearanceHeader.Options.UseFont = true;
            this.OrderTime.Caption = "Time";
            this.OrderTime.FieldName = "gridOrderTime";
            this.OrderTime.Name = "OrderTime";
            this.OrderTime.Visible = true;
            this.OrderTime.VisibleIndex = 2;
            // 
            // Payment
            // 
            this.Payment.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Payment.AppearanceCell.Options.UseFont = true;
            this.Payment.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Payment.AppearanceHeader.Options.UseFont = true;
            this.Payment.Caption = "Payment";
            this.Payment.FieldName = "gridPayType";
            this.Payment.Name = "Payment";
            this.Payment.Visible = true;
            this.Payment.VisibleIndex = 3;
            // 
            // PayOrderType
            // 
            this.PayOrderType.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayOrderType.AppearanceCell.Options.UseFont = true;
            this.PayOrderType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayOrderType.AppearanceHeader.Options.UseFont = true;
            this.PayOrderType.Caption = "Type";
            this.PayOrderType.FieldName = "gridOrderType";
            this.PayOrderType.Name = "PayOrderType";
            this.PayOrderType.Visible = true;
            this.PayOrderType.VisibleIndex = 1;
            // 
            // TotalAmount
            // 
            this.TotalAmount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalAmount.AppearanceCell.Options.UseFont = true;
            this.TotalAmount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalAmount.AppearanceHeader.Options.UseFont = true;
            this.TotalAmount.Caption = "Total";
            this.TotalAmount.FieldName = "gridTotal";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.Visible = true;
            this.TotalAmount.VisibleIndex = 4;
            // 
            // StaffName
            // 
            this.StaffName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.StaffName.AppearanceCell.Options.UseFont = true;
            this.StaffName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffName.AppearanceHeader.Options.UseFont = true;
            this.StaffName.Caption = "Staff";
            this.StaffName.FieldName = "gridStaff";
            this.StaffName.Name = "StaffName";
            this.StaffName.Visible = true;
            this.StaffName.VisibleIndex = 6;
            // 
            // DriverName
            // 
            this.DriverName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.DriverName.AppearanceCell.Options.UseFont = true;
            this.DriverName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriverName.AppearanceHeader.Options.UseFont = true;
            this.DriverName.Caption = "Driver";
            this.DriverName.FieldName = "gridDriver";
            this.DriverName.Name = "DriverName";
            this.DriverName.Visible = true;
            this.DriverName.VisibleIndex = 5;
            // 
            // CustomerID
            // 
            this.CustomerID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.CustomerID.AppearanceCell.Options.UseFont = true;
            this.CustomerID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerID.AppearanceHeader.Options.UseFont = true;
            this.CustomerID.Caption = "CustomerID";
            this.CustomerID.FieldName = "gridCustID";
            this.CustomerID.Name = "CustomerID";
            // 
            // DiscountPer
            // 
            this.DiscountPer.Caption = "Discount Per";
            this.DiscountPer.FieldName = "gridDiscountPer";
            this.DiscountPer.Name = "DiscountPer";
            // 
            // Discount
            // 
            this.Discount.Caption = "Discount";
            this.Discount.FieldName = "gridDiscount";
            this.Discount.Name = "Discount";
            // 
            // SubToal
            // 
            this.SubToal.Caption = "SubTotal";
            this.SubToal.FieldName = "gridSubTotal";
            this.SubToal.Name = "SubToal";
            // 
            // FrmTaShowOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 646);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaShowOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTaShowOrder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaShowOrder_Load);
            this.SizeChanged += new System.EventHandler(this.FrmTaShowOrder_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaShowOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaShowOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAll;
        private DevExpress.XtraEditors.SimpleButton btnPrtKit;
        private DevExpress.XtraEditors.SimpleButton btnPrtReceipt;
        private DevExpress.XtraEditors.SimpleButton btnPrtBill;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnDelivery;
        private DevExpress.XtraEditors.SimpleButton btnCollection;
        private DevExpress.XtraEditors.SimpleButton btnShop;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraGrid.GridControl gridControlTaShowOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaShowOrder;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn CheckCode;
        private DevExpress.XtraGrid.Columns.GridColumn OrderTime;
        private DevExpress.XtraGrid.Columns.GridColumn PayOrderType;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn TotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn StaffName;
        private DevExpress.XtraGrid.Columns.GridColumn DriverName;
        private DevExpress.XtraGrid.Columns.GridColumn Payment;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SimpleButton btnChangePayment;
        private DevExpress.XtraEditors.SimpleButton btnEatIn;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.SimpleButton btnAccount;
        private DevExpress.XtraEditors.SimpleButton btnShowDriver;
        private DevExpress.XtraEditors.SimpleButton btnEditOrder;
        private DevExpress.XtraGrid.Columns.GridColumn DiscountPer;
        private DevExpress.XtraGrid.Columns.GridColumn Discount;
        private DevExpress.XtraGrid.Columns.GridColumn SubToal;
        private DevExpress.XtraRichEdit.RichEditControl richEditCtlPreview;
    }
}