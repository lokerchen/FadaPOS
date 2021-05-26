namespace SuperPOS.UI.TA
{
    partial class FrmTaPrintSalesReprot
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
            this.btnPrintSummary = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.deDayTo = new DevExpress.XtraEditors.TimeEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deDayFrom = new DevExpress.XtraEditors.TimeEdit();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCurrentDate = new DevExpress.XtraEditors.TextEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCurrentTime = new DevExpress.XtraEditors.TextEdit();
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
            this.BusDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deDayTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDayFrom.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentDate.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaShowOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaShowOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrintSummary);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupBox1.Location = new System.Drawing.Point(9, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(380, 400);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print Sales Report";
            // 
            // btnPrintSummary
            // 
            this.btnPrintSummary.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPrintSummary.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.btnPrintSummary.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPrintSummary.Appearance.Options.UseBackColor = true;
            this.btnPrintSummary.Appearance.Options.UseFont = true;
            this.btnPrintSummary.Appearance.Options.UseForeColor = true;
            this.btnPrintSummary.Appearance.Options.UseTextOptions = true;
            this.btnPrintSummary.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPrintSummary.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnPrintSummary.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPrintSummary.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPrintSummary.Location = new System.Drawing.Point(8, 227);
            this.btnPrintSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintSummary.Name = "btnPrintSummary";
            this.btnPrintSummary.Size = new System.Drawing.Size(364, 75);
            this.btnPrintSummary.TabIndex = 88;
            this.btnPrintSummary.Text = "Print Summary";
            this.btnPrintSummary.Click += new System.EventHandler(this.btnPrintSummary_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Appearance.Options.UseForeColor = true;
            this.btnExit.Appearance.Options.UseTextOptions = true;
            this.btnExit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExit.Location = new System.Drawing.Point(8, 311);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(366, 75);
            this.btnExit.TabIndex = 87;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.deDayTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.deDayFrom);
            this.panel1.Location = new System.Drawing.Point(8, 103);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 106);
            this.panel1.TabIndex = 72;
            // 
            // deDayTo
            // 
            this.deDayTo.EditValue = new System.DateTime(2021, 2, 9, 20, 50, 20, 0);
            this.deDayTo.Location = new System.Drawing.Point(152, 73);
            this.deDayTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deDayTo.Name = "deDayTo";
            this.deDayTo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.deDayTo.Properties.Appearance.Options.UseFont = true;
            this.deDayTo.Properties.AutoHeight = false;
            this.deDayTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDayTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.deDayTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDayTo.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.deDayTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDayTo.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.deDayTo.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm";
            this.deDayTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.deDayTo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.deDayTo.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.deDayTo.Size = new System.Drawing.Size(164, 23);
            this.deDayTo.TabIndex = 93;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "To DateTime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "From DateTime";
            // 
            // deDayFrom
            // 
            this.deDayFrom.EditValue = new System.DateTime(2021, 2, 9, 20, 50, 20, 0);
            this.deDayFrom.Location = new System.Drawing.Point(152, 27);
            this.deDayFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deDayFrom.Name = "deDayFrom";
            this.deDayFrom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.deDayFrom.Properties.Appearance.Options.UseFont = true;
            this.deDayFrom.Properties.AutoHeight = false;
            this.deDayFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDayFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.deDayFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDayFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.deDayFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDayFrom.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.deDayFrom.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm";
            this.deDayFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.deDayFrom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.deDayFrom.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.deDayFrom.Size = new System.Drawing.Size(164, 23);
            this.deDayFrom.TabIndex = 92;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCurrentDate);
            this.groupBox3.Location = new System.Drawing.Point(200, 21);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(155, 78);
            this.groupBox3.TabIndex = 71;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Date";
            // 
            // txtCurrentDate
            // 
            this.txtCurrentDate.EditValue = "2020-09-26";
            this.txtCurrentDate.Location = new System.Drawing.Point(14, 39);
            this.txtCurrentDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCurrentDate.Name = "txtCurrentDate";
            this.txtCurrentDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtCurrentDate.Properties.Appearance.Options.UseFont = true;
            this.txtCurrentDate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCurrentDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCurrentDate.Size = new System.Drawing.Size(129, 30);
            this.txtCurrentDate.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCurrentTime);
            this.groupBox2.Location = new System.Drawing.Point(25, 21);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(155, 78);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Time";
            // 
            // txtCurrentTime
            // 
            this.txtCurrentTime.EditValue = "18:35:36";
            this.txtCurrentTime.Location = new System.Drawing.Point(14, 39);
            this.txtCurrentTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCurrentTime.Name = "txtCurrentTime";
            this.txtCurrentTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtCurrentTime.Properties.Appearance.Options.UseFont = true;
            this.txtCurrentTime.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCurrentTime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCurrentTime.Size = new System.Drawing.Size(129, 30);
            this.txtCurrentTime.TabIndex = 0;
            // 
            // gridControlTaShowOrder
            // 
            this.gridControlTaShowOrder.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlTaShowOrder.Location = new System.Drawing.Point(394, 12);
            this.gridControlTaShowOrder.MainView = this.gvTaShowOrder;
            this.gridControlTaShowOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlTaShowOrder.Name = "gridControlTaShowOrder";
            this.gridControlTaShowOrder.Size = new System.Drawing.Size(552, 355);
            this.gridControlTaShowOrder.TabIndex = 66;
            this.gridControlTaShowOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaShowOrder});
            this.gridControlTaShowOrder.Visible = false;
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
            this.SubToal,
            this.BusDate});
            this.gvTaShowOrder.GridControl = this.gridControlTaShowOrder;
            this.gvTaShowOrder.IndicatorWidth = 50;
            this.gvTaShowOrder.Name = "gvTaShowOrder";
            this.gvTaShowOrder.OptionsBehavior.Editable = false;
            this.gvTaShowOrder.OptionsMenu.EnableColumnMenu = false;
            this.gvTaShowOrder.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaShowOrder.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaShowOrder.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaShowOrder.OptionsView.ShowGroupPanel = false;
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
            this.CheckCode.FieldName = "CheckCode";
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
            this.OrderTime.Caption = "Order Time";
            this.OrderTime.FieldName = "PayTime";
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
            this.Payment.FieldName = "Paid";
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
            this.PayOrderType.FieldName = "PayOrderType";
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
            this.TotalAmount.FieldName = "TotalAmount";
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
            this.StaffName.FieldName = "UsrName";
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
            this.DriverName.FieldName = "DriverName";
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
            this.CustomerID.FieldName = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            // 
            // DiscountPer
            // 
            this.DiscountPer.Caption = "Discount Per";
            this.DiscountPer.FieldName = "PayPerDiscount";
            this.DiscountPer.Name = "DiscountPer";
            // 
            // Discount
            // 
            this.Discount.Caption = "Discount";
            this.Discount.FieldName = "PayDiscount";
            this.Discount.Name = "Discount";
            // 
            // SubToal
            // 
            this.SubToal.Caption = "SubTotal";
            this.SubToal.FieldName = "MenuAmount";
            this.SubToal.Name = "SubToal";
            // 
            // BusDate
            // 
            this.BusDate.Caption = "BusDate";
            this.BusDate.FieldName = "BusDate";
            this.BusDate.Name = "BusDate";
            // 
            // FrmTaPrintSalesReprot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 422);
            this.Controls.Add(this.gridControlTaShowOrder);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmTaPrintSalesReprot";
            this.Text = "FrmTaPrintSalesReprot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaPrintSalesReprot_Load);
            this.SizeChanged += new System.EventHandler(this.FrmTaPrintSalesReprot_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deDayTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDayFrom.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentDate.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaShowOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaShowOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.TextEdit txtCurrentDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.TextEdit txtCurrentTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnPrintSummary;
        private DevExpress.XtraEditors.TimeEdit deDayFrom;
        private DevExpress.XtraEditors.TimeEdit deDayTo;
        private DevExpress.XtraGrid.GridControl gridControlTaShowOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaShowOrder;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn CheckCode;
        private DevExpress.XtraGrid.Columns.GridColumn OrderTime;
        private DevExpress.XtraGrid.Columns.GridColumn Payment;
        private DevExpress.XtraGrid.Columns.GridColumn PayOrderType;
        private DevExpress.XtraGrid.Columns.GridColumn TotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn StaffName;
        private DevExpress.XtraGrid.Columns.GridColumn DriverName;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn DiscountPer;
        private DevExpress.XtraGrid.Columns.GridColumn Discount;
        private DevExpress.XtraGrid.Columns.GridColumn SubToal;
        private DevExpress.XtraGrid.Columns.GridColumn BusDate;
    }
}