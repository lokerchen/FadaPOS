namespace SuperPOS.UI.Report
{
    partial class RptCustomerDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptCustomerDatabase));
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlReport = new DevExpress.XtraGrid.GridControl();
            this.gvTaShowOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhoneNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhoneNo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Address1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Address2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Postcode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Postcode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Distance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Map = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.BlackListed = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.btnExit.Location = new System.Drawing.Point(998, 570);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 68);
            this.btnExit.TabIndex = 87;
            this.btnExit.Text = "Exit";
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.BackColor = System.Drawing.Color.Green;
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
            this.gridControlReport.Location = new System.Drawing.Point(15, 88);
            this.gridControlReport.MainView = this.gvTaShowOrder;
            this.gridControlReport.Name = "gridControlReport";
            this.gridControlReport.Size = new System.Drawing.Size(1030, 464);
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
            this.Name,
            this.PhoneNo1,
            this.PhoneNo2,
            this.Address1,
            this.Address2,
            this.Postcode1,
            this.Postcode2,
            this.Distance,
            this.Map,
            this.BlackListed});
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
            // Name
            // 
            this.Name.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name.AppearanceCell.Options.UseFont = true;
            this.Name.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name.AppearanceHeader.Options.UseFont = true;
            this.Name.Caption = "Name";
            this.Name.FieldName = "gridName";
            this.Name.Name = "Name";
            this.Name.Visible = true;
            this.Name.VisibleIndex = 0;
            // 
            // PhoneNo1
            // 
            this.PhoneNo1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.PhoneNo1.AppearanceCell.Options.UseFont = true;
            this.PhoneNo1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNo1.AppearanceHeader.Options.UseFont = true;
            this.PhoneNo1.Caption = "Phone No.1";
            this.PhoneNo1.FieldName = "gridPhoneNo1";
            this.PhoneNo1.Name = "PhoneNo1";
            this.PhoneNo1.Visible = true;
            this.PhoneNo1.VisibleIndex = 1;
            // 
            // PhoneNo2
            // 
            this.PhoneNo2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.PhoneNo2.AppearanceCell.Options.UseFont = true;
            this.PhoneNo2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNo2.AppearanceHeader.Options.UseFont = true;
            this.PhoneNo2.Caption = "Phone No.2";
            this.PhoneNo2.FieldName = "gridPhoneNo2";
            this.PhoneNo2.Name = "PhoneNo2";
            this.PhoneNo2.Visible = true;
            this.PhoneNo2.VisibleIndex = 2;
            // 
            // Address1
            // 
            this.Address1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Address1.AppearanceCell.Options.UseFont = true;
            this.Address1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Address1.AppearanceHeader.Options.UseFont = true;
            this.Address1.Caption = "Address #1";
            this.Address1.FieldName = "gridAddress1";
            this.Address1.Name = "Address1";
            this.Address1.Visible = true;
            this.Address1.VisibleIndex = 3;
            // 
            // Address2
            // 
            this.Address2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Address2.AppearanceCell.Options.UseFont = true;
            this.Address2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Address2.AppearanceHeader.Options.UseFont = true;
            this.Address2.Caption = "Address #2";
            this.Address2.FieldName = "gridAddress2";
            this.Address2.Name = "Address2";
            this.Address2.Visible = true;
            this.Address2.VisibleIndex = 4;
            // 
            // Postcode1
            // 
            this.Postcode1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Postcode1.AppearanceCell.Options.UseFont = true;
            this.Postcode1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Postcode1.AppearanceHeader.Options.UseFont = true;
            this.Postcode1.Caption = "Postcode #1";
            this.Postcode1.FieldName = "gridPostcode1";
            this.Postcode1.Name = "Postcode1";
            this.Postcode1.Visible = true;
            this.Postcode1.VisibleIndex = 5;
            // 
            // Postcode2
            // 
            this.Postcode2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Postcode2.AppearanceCell.Options.UseFont = true;
            this.Postcode2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Postcode2.AppearanceHeader.Options.UseFont = true;
            this.Postcode2.Caption = "Postcode #2";
            this.Postcode2.FieldName = "gridPostcode2";
            this.Postcode2.Name = "Postcode2";
            this.Postcode2.Visible = true;
            this.Postcode2.VisibleIndex = 6;
            // 
            // Distance
            // 
            this.Distance.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Distance.AppearanceCell.Options.UseFont = true;
            this.Distance.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Distance.AppearanceHeader.Options.UseFont = true;
            this.Distance.Caption = "Distance";
            this.Distance.FieldName = "gridDistance";
            this.Distance.Name = "Distance";
            // 
            // Map
            // 
            this.Map.Caption = "Map";
            this.Map.FieldName = "gridMap";
            this.Map.Name = "Map";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 18);
            this.label1.TabIndex = 90;
            this.label1.Text = "Customer Database";
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
            this.btnUp.Location = new System.Drawing.Point(1051, 220);
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
            this.btnDown.Location = new System.Drawing.Point(1051, 335);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(55, 60);
            this.btnDown.TabIndex = 93;
            this.btnDown.Text = "<<";
            // 
            // btnExport
            // 
            this.btnExport.Appearance.BackColor = System.Drawing.Color.Navy;
            this.btnExport.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.Appearance.Options.UseTextOptions = true;
            this.btnExport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnExport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExport.Location = new System.Drawing.Point(892, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(134, 42);
            this.btnExport.TabIndex = 96;
            this.btnExport.Text = "Export CSV";
            // 
            // BlackListed
            // 
            this.BlackListed.Caption = "BlackListed";
            this.BlackListed.FieldName = "gridBlackListed";
            this.BlackListed.Name = "BlackListed";
            this.BlackListed.Visible = true;
            this.BlackListed.VisibleIndex = 7;
            // 
            // RptCustomerDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 656);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControlReport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RptCustomerDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RptCustomerDatabase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RptCustomerDatabase_Load);
            this.SizeChanged += new System.EventHandler(this.RptCustomerDatabase_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaShowOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.GridControl gridControlReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaShowOrder;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn Name;
        private DevExpress.XtraGrid.Columns.GridColumn PhoneNo2;
        private DevExpress.XtraGrid.Columns.GridColumn Address1;
        private DevExpress.XtraGrid.Columns.GridColumn Address2;
        private DevExpress.XtraGrid.Columns.GridColumn Postcode1;
        private DevExpress.XtraGrid.Columns.GridColumn PhoneNo1;
        private DevExpress.XtraGrid.Columns.GridColumn Postcode2;
        private DevExpress.XtraGrid.Columns.GridColumn Distance;
        private DevExpress.XtraGrid.Columns.GridColumn Map;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnUp;
        private DevExpress.XtraEditors.SimpleButton btnDown;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn BlackListed;
    }
}