namespace SuperPOS.UI.Report
{
    partial class RptCategoryPerformance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptCategoryPerformance));
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnLanguage = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlReport = new DevExpress.XtraGrid.GridControl();
            this.gvTaShowOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Category = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.btnExit.Location = new System.Drawing.Point(654, 448);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 53);
            this.btnExit.TabIndex = 87;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.btnLanguage.Location = new System.Drawing.Point(459, 468);
            this.btnLanguage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(142, 33);
            this.btnLanguage.TabIndex = 86;
            this.btnLanguage.Text = "LANGUAGE";
            this.btnLanguage.Visible = false;
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
            this.btnPrint.Location = new System.Drawing.Point(10, 9);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(117, 33);
            this.btnPrint.TabIndex = 88;
            this.btnPrint.Text = "Print(A4)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gridControlReport
            // 
            this.gridControlReport.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlReport.Location = new System.Drawing.Point(10, 68);
            this.gridControlReport.MainView = this.gvTaShowOrder;
            this.gridControlReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlReport.Name = "gridControlReport";
            this.gridControlReport.Size = new System.Drawing.Size(672, 376);
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
            this.Category,
            this.TotalQuantity,
            this.TotalAmount});
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
            // Category
            // 
            this.Category.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Category.AppearanceCell.Options.UseFont = true;
            this.Category.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Category.AppearanceHeader.Options.UseFont = true;
            this.Category.Caption = "Category";
            this.Category.FieldName = "gridCategory";
            this.Category.Name = "Category";
            this.Category.Visible = true;
            this.Category.VisibleIndex = 0;
            // 
            // TotalQuantity
            // 
            this.TotalQuantity.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.TotalQuantity.AppearanceCell.Options.UseFont = true;
            this.TotalQuantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalQuantity.AppearanceHeader.Options.UseFont = true;
            this.TotalQuantity.Caption = "Total Quantity";
            this.TotalQuantity.FieldName = "gridTotalQuantity";
            this.TotalQuantity.Name = "TotalQuantity";
            this.TotalQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "gridTotalQuantity", "Total:{0}")});
            this.TotalQuantity.Visible = true;
            this.TotalQuantity.VisibleIndex = 1;
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
            this.TotalAmount.VisibleIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 14);
            this.label1.TabIndex = 90;
            this.label1.Text = "Food Category Performance Report";
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
            this.btnUp.Location = new System.Drawing.Point(700, 176);
            this.btnUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(48, 47);
            this.btnUp.TabIndex = 92;
            this.btnUp.Text = ">>";
            this.btnUp.Visible = false;
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
            this.btnDown.Location = new System.Drawing.Point(700, 265);
            this.btnDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(48, 47);
            this.btnDown.TabIndex = 93;
            this.btnDown.Text = "<<";
            this.btnDown.Visible = false;
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
            this.btnRefresh.Location = new System.Drawing.Point(559, 9);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 33);
            this.btnRefresh.TabIndex = 99;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Visible = false;
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
            this.btnTakeaway.Location = new System.Drawing.Point(368, 9);
            this.btnTakeaway.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTakeaway.Name = "btnTakeaway";
            this.btnTakeaway.Size = new System.Drawing.Size(117, 33);
            this.btnTakeaway.TabIndex = 98;
            this.btnTakeaway.Text = "Takeaway";
            this.btnTakeaway.Visible = false;
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
            this.btnEatIn.Location = new System.Drawing.Point(231, 9);
            this.btnEatIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEatIn.Name = "btnEatIn";
            this.btnEatIn.Size = new System.Drawing.Size(117, 33);
            this.btnEatIn.TabIndex = 97;
            this.btnEatIn.Text = "Eat In";
            this.btnEatIn.Visible = false;
            // 
            // RptCategoryPerformance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 510);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RptCategoryPerformance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RptCategoryPerformance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RptCategoryPerformance_Load);
            this.SizeChanged += new System.EventHandler(this.RptCategoryPerformance_SizeChanged);
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
        private DevExpress.XtraGrid.Columns.GridColumn Category;
        private DevExpress.XtraGrid.Columns.GridColumn TotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn TotalQuantity;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnUp;
        private DevExpress.XtraEditors.SimpleButton btnDown;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnTakeaway;
        private DevExpress.XtraEditors.SimpleButton btnEatIn;
    }
}