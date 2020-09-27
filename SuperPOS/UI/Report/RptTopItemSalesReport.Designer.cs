namespace SuperPOS.UI.Report
{
    partial class RptTopItemSalesReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptTopItemSalesReport));
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnLanguage = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlReport = new DevExpress.XtraGrid.GridControl();
            this.gvTaShowOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DishCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OtherLanguage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemDescriptions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BusDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnTakeaway = new DevExpress.XtraEditors.SimpleButton();
            this.btnEatIn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaShowOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Appearance.Options.UseForeColor = true;
            this.btnExit.Appearance.Options.UseTextOptions = true;
            this.btnExit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExit.Location = new System.Drawing.Point(747, 576);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 68);
            this.btnExit.TabIndex = 87;
            this.btnExit.Text = "Exit";
            // 
            // btnLanguage
            // 
            this.btnLanguage.Appearance.BackColor = System.Drawing.Color.LimeGreen;
            this.btnLanguage.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLanguage.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLanguage.Appearance.Options.UseBackColor = true;
            this.btnLanguage.Appearance.Options.UseFont = true;
            this.btnLanguage.Appearance.Options.UseForeColor = true;
            this.btnLanguage.Appearance.Options.UseTextOptions = true;
            this.btnLanguage.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnLanguage.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnLanguage.Location = new System.Drawing.Point(525, 602);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(162, 42);
            this.btnLanguage.TabIndex = 86;
            this.btnLanguage.Text = "LANGUAGE";
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Appearance.Options.UseBackColor = true;
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Appearance.Options.UseForeColor = true;
            this.btnPrint.Appearance.Options.UseTextOptions = true;
            this.btnPrint.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPrint.Location = new System.Drawing.Point(12, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(134, 42);
            this.btnPrint.TabIndex = 88;
            this.btnPrint.Text = "Print(A4)";
            // 
            // gridControlReport
            // 
            this.gridControlReport.Location = new System.Drawing.Point(12, 88);
            this.gridControlReport.MainView = this.gvTaShowOrder;
            this.gridControlReport.Name = "gridControlReport";
            this.gridControlReport.Size = new System.Drawing.Size(768, 483);
            this.gridControlReport.TabIndex = 89;
            this.gridControlReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.DishCode,
            this.ItemDescriptions,
            this.OtherLanguage,
            this.TotalQuantity,
            this.TotalAmount,
            this.BusDate});
            this.gvTaShowOrder.GridControl = this.gridControlReport;
            this.gvTaShowOrder.IndicatorWidth = 50;
            this.gvTaShowOrder.Name = "gvTaShowOrder";
            this.gvTaShowOrder.OptionsBehavior.Editable = false;
            this.gvTaShowOrder.OptionsMenu.EnableColumnMenu = false;
            this.gvTaShowOrder.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaShowOrder.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaShowOrder.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaShowOrder.OptionsView.ShowFooter = true;
            this.gvTaShowOrder.OptionsView.ShowGroupPanel = false;
            this.gvTaShowOrder.OptionsView.ShowIndicator = false;
            // 
            // ID
            // 
            this.ID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.AppearanceCell.Options.UseFont = true;
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // DishCode
            // 
            this.DishCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DishCode.AppearanceCell.Options.UseFont = true;
            this.DishCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DishCode.AppearanceHeader.Options.UseFont = true;
            this.DishCode.Caption = "Dish Code";
            this.DishCode.FieldName = "gridDishCode";
            this.DishCode.Name = "DishCode";
            this.DishCode.Visible = true;
            this.DishCode.VisibleIndex = 0;
            // 
            // OtherLanguage
            // 
            this.OtherLanguage.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.OtherLanguage.AppearanceCell.Options.UseFont = true;
            this.OtherLanguage.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherLanguage.AppearanceHeader.Options.UseFont = true;
            this.OtherLanguage.Caption = "Other Language";
            this.OtherLanguage.FieldName = "gridOtherLanguage";
            this.OtherLanguage.Name = "OtherLanguage";
            this.OtherLanguage.Visible = true;
            this.OtherLanguage.VisibleIndex = 2;
            // 
            // TotalAmount
            // 
            this.TotalAmount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.TotalAmount.AppearanceCell.Options.UseFont = true;
            this.TotalAmount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalAmount.AppearanceHeader.Options.UseFont = true;
            this.TotalAmount.Caption = "Total Amount";
            this.TotalAmount.FieldName = "gridTotalAmount";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "gridTotalAmount", "Total:{0}")});
            this.TotalAmount.Visible = true;
            this.TotalAmount.VisibleIndex = 4;
            // 
            // ItemDescriptions
            // 
            this.ItemDescriptions.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemDescriptions.AppearanceCell.Options.UseFont = true;
            this.ItemDescriptions.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemDescriptions.AppearanceHeader.Options.UseFont = true;
            this.ItemDescriptions.Caption = "Item Descriptions";
            this.ItemDescriptions.FieldName = "gridItemDescriptions";
            this.ItemDescriptions.Name = "ItemDescriptions";
            this.ItemDescriptions.Visible = true;
            this.ItemDescriptions.VisibleIndex = 1;
            // 
            // TotalQuantity
            // 
            this.TotalQuantity.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalQuantity.AppearanceCell.Options.UseFont = true;
            this.TotalQuantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalQuantity.AppearanceHeader.Options.UseFont = true;
            this.TotalQuantity.Caption = "Total Quantity";
            this.TotalQuantity.FieldName = "gridTotalQuantity";
            this.TotalQuantity.Name = "TotalQuantity";
            this.TotalQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "gridQuantity", "Total:{0}")});
            this.TotalQuantity.Visible = true;
            this.TotalQuantity.VisibleIndex = 3;
            // 
            // BusDate
            // 
            this.BusDate.Caption = "BusDate";
            this.BusDate.FieldName = "gridBusDate";
            this.BusDate.Name = "BusDate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 18);
            this.label1.TabIndex = 90;
            this.label1.Text = "Top Item Sales Report";
            // 
            // btnUp
            // 
            this.btnUp.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnUp.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnUp.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnUp.Appearance.Options.UseBackColor = true;
            this.btnUp.Appearance.Options.UseFont = true;
            this.btnUp.Appearance.Options.UseForeColor = true;
            this.btnUp.Appearance.Options.UseTextOptions = true;
            this.btnUp.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnUp.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnUp.Location = new System.Drawing.Point(800, 226);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(55, 60);
            this.btnUp.TabIndex = 92;
            this.btnUp.Text = ">>";
            // 
            // btnDown
            // 
            this.btnDown.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnDown.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnDown.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDown.Appearance.Options.UseBackColor = true;
            this.btnDown.Appearance.Options.UseFont = true;
            this.btnDown.Appearance.Options.UseForeColor = true;
            this.btnDown.Appearance.Options.UseTextOptions = true;
            this.btnDown.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDown.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDown.Location = new System.Drawing.Point(800, 341);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(55, 60);
            this.btnDown.TabIndex = 93;
            this.btnDown.Text = "<<";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Appearance.Options.UseForeColor = true;
            this.btnRefresh.Appearance.Options.UseTextOptions = true;
            this.btnRefresh.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRefresh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnRefresh.Location = new System.Drawing.Point(647, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(134, 42);
            this.btnRefresh.TabIndex = 99;
            this.btnRefresh.Text = "Refresh";
            // 
            // btnTakeaway
            // 
            this.btnTakeaway.Appearance.BackColor = System.Drawing.Color.Navy;
            this.btnTakeaway.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakeaway.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTakeaway.Appearance.Options.UseBackColor = true;
            this.btnTakeaway.Appearance.Options.UseFont = true;
            this.btnTakeaway.Appearance.Options.UseForeColor = true;
            this.btnTakeaway.Appearance.Options.UseTextOptions = true;
            this.btnTakeaway.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnTakeaway.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTakeaway.Location = new System.Drawing.Point(428, 12);
            this.btnTakeaway.Name = "btnTakeaway";
            this.btnTakeaway.Size = new System.Drawing.Size(134, 42);
            this.btnTakeaway.TabIndex = 98;
            this.btnTakeaway.Text = "Takeaway";
            // 
            // btnEatIn
            // 
            this.btnEatIn.Appearance.BackColor = System.Drawing.Color.Navy;
            this.btnEatIn.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEatIn.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnEatIn.Appearance.Options.UseBackColor = true;
            this.btnEatIn.Appearance.Options.UseFont = true;
            this.btnEatIn.Appearance.Options.UseForeColor = true;
            this.btnEatIn.Appearance.Options.UseTextOptions = true;
            this.btnEatIn.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEatIn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnEatIn.Location = new System.Drawing.Point(272, 12);
            this.btnEatIn.Name = "btnEatIn";
            this.btnEatIn.Size = new System.Drawing.Size(134, 42);
            this.btnEatIn.TabIndex = 97;
            this.btnEatIn.Text = "Eat In";
            // 
            // RptTopItemSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 656);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnTakeaway);
            this.Controls.Add(this.btnEatIn);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControlReport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RptTopItemSalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RptTopItemSalesReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RptTopItemSalesReport_Load);
            this.SizeChanged += new System.EventHandler(this.RptTopItemSalesReport_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaShowOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnLanguage;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.GridControl gridControlReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaShowOrder;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn DishCode;
        private DevExpress.XtraGrid.Columns.GridColumn TotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn ItemDescriptions;
        private DevExpress.XtraGrid.Columns.GridColumn TotalQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn OtherLanguage;
        private DevExpress.XtraGrid.Columns.GridColumn BusDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnUp;
        private DevExpress.XtraEditors.SimpleButton btnDown;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnTakeaway;
        private DevExpress.XtraEditors.SimpleButton btnEatIn;
    }
}