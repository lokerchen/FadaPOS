namespace SuperPOS.UI.Report
{
    partial class RptMenuItemDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptMenuItemDelete));
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnLanguage = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlReport = new DevExpress.XtraGrid.GridControl();
            this.gvTaShowOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemDescriptions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StaffName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BusDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnDown = new DevExpress.XtraEditors.SimpleButton();
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
            this.RefNo,
            this.StaffName,
            this.OrderDate,
            this.OrderTime,
            this.ItemDescriptions,
            this.Quantity,
            this.Price,
            this.CustomerID,
            this.BusDate});
            this.gvTaShowOrder.GridControl = this.gridControlReport;
            this.gvTaShowOrder.IndicatorWidth = 50;
            this.gvTaShowOrder.Name = "gvTaShowOrder";
            this.gvTaShowOrder.OptionsBehavior.Editable = false;
            this.gvTaShowOrder.OptionsMenu.EnableColumnMenu = false;
            this.gvTaShowOrder.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaShowOrder.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaShowOrder.OptionsView.EnableAppearanceOddRow = true;
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
            // RefNo
            // 
            this.RefNo.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefNo.AppearanceCell.Options.UseFont = true;
            this.RefNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefNo.AppearanceHeader.Options.UseFont = true;
            this.RefNo.Caption = "Ref.No.";
            this.RefNo.FieldName = "gridRefNo";
            this.RefNo.Name = "RefNo";
            this.RefNo.Visible = true;
            this.RefNo.VisibleIndex = 0;
            // 
            // OrderDate
            // 
            this.OrderDate.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.OrderDate.AppearanceCell.Options.UseFont = true;
            this.OrderDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderDate.AppearanceHeader.Options.UseFont = true;
            this.OrderDate.Caption = "Date";
            this.OrderDate.FieldName = "gridOrderDate";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.Visible = true;
            this.OrderDate.VisibleIndex = 2;
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
            this.OrderTime.VisibleIndex = 3;
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
            this.ItemDescriptions.VisibleIndex = 4;
            // 
            // Quantity
            // 
            this.Quantity.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.AppearanceCell.Options.UseFont = true;
            this.Quantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.AppearanceHeader.Options.UseFont = true;
            this.Quantity.Caption = "Quantity";
            this.Quantity.FieldName = "gridQuantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.Visible = true;
            this.Quantity.VisibleIndex = 5;
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
            this.StaffName.VisibleIndex = 1;
            // 
            // Price
            // 
            this.Price.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Price.AppearanceCell.Options.UseFont = true;
            this.Price.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.AppearanceHeader.Options.UseFont = true;
            this.Price.Caption = "Price";
            this.Price.FieldName = "gridPrice";
            this.Price.Name = "Price";
            this.Price.Visible = true;
            this.Price.VisibleIndex = 6;
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
            // BusDate
            // 
            this.BusDate.Caption = "BusDate";
            this.BusDate.FieldName = "gridBusDate";
            this.BusDate.Name = "BusDate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 18);
            this.label1.TabIndex = 90;
            this.label1.Text = "Menu Item Delete Report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 18);
            this.label2.TabIndex = 91;
            this.label2.Text = "08/12/2020 ~ 08/14/2020";
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
            // RptMenuItemDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 656);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControlReport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RptMenuItemDelete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RptMenuItemDelete";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RptMenuItemDelete_Load);
            this.SizeChanged += new System.EventHandler(this.RptMenuItemDelete_SizeChanged);
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
        private DevExpress.XtraGrid.Columns.GridColumn RefNo;
        private DevExpress.XtraGrid.Columns.GridColumn OrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn OrderTime;
        private DevExpress.XtraGrid.Columns.GridColumn ItemDescriptions;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn StaffName;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn BusDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnUp;
        private DevExpress.XtraEditors.SimpleButton btnDown;
    }
}