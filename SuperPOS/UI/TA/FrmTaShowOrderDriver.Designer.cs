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
            this.txtTotalDeliveryCharge = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControlTaDriver = new DevExpress.XtraGrid.GridControl();
            this.gvTaPendOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeliveryCharge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DriverID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnShowAllDriver = new System.Windows.Forms.Button();
            this.lueDriver = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.DriverName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDeliveryCharge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaPendOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDriver.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotalDeliveryCharge);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.gridControlTaDriver);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnShowAllDriver);
            this.groupBox1.Controls.Add(this.lueDriver);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupBox1.Location = new System.Drawing.Point(6, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(513, 345);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delivery Charges";
            // 
            // txtTotalDeliveryCharge
            // 
            this.txtTotalDeliveryCharge.EditValue = "0.00";
            this.txtTotalDeliveryCharge.Location = new System.Drawing.Point(200, 310);
            this.txtTotalDeliveryCharge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotalDeliveryCharge.Name = "txtTotalDeliveryCharge";
            this.txtTotalDeliveryCharge.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTotalDeliveryCharge.Properties.Appearance.Options.UseFont = true;
            this.txtTotalDeliveryCharge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalDeliveryCharge.Size = new System.Drawing.Size(141, 26);
            this.txtTotalDeliveryCharge.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "Total Delivery Charge:";
            // 
            // gridControlTaDriver
            // 
            this.gridControlTaDriver.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlTaDriver.Location = new System.Drawing.Point(13, 72);
            this.gridControlTaDriver.MainView = this.gvTaPendOrder;
            this.gridControlTaDriver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlTaDriver.Name = "gridControlTaDriver";
            this.gridControlTaDriver.Size = new System.Drawing.Size(457, 216);
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
            this.OrderTime,
            this.OrderNo,
            this.DeliveryCharge,
            this.DriverID,
            this.DriverName});
            this.gvTaPendOrder.GridControl = this.gridControlTaDriver;
            this.gvTaPendOrder.IndicatorWidth = 50;
            this.gvTaPendOrder.Name = "gvTaPendOrder";
            this.gvTaPendOrder.OptionsBehavior.Editable = false;
            this.gvTaPendOrder.OptionsMenu.EnableColumnMenu = false;
            this.gvTaPendOrder.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaPendOrder.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaPendOrder.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaPendOrder.OptionsView.ShowGroupPanel = false;
            this.gvTaPendOrder.OptionsView.ShowIndicator = false;
            // 
            // ID
            // 
            this.ID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.AppearanceCell.Options.UseFont = true;
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // OrderTime
            // 
            this.OrderTime.Caption = "Time";
            this.OrderTime.FieldName = "OrderTime";
            this.OrderTime.Name = "OrderTime";
            this.OrderTime.Visible = true;
            this.OrderTime.VisibleIndex = 0;
            // 
            // OrderNo
            // 
            this.OrderNo.Caption = "Order No.";
            this.OrderNo.FieldName = "CheckCode";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.Visible = true;
            this.OrderNo.VisibleIndex = 1;
            // 
            // DeliveryCharge
            // 
            this.DeliveryCharge.Caption = "Delivery Charge";
            this.DeliveryCharge.FieldName = "DeliveryFee";
            this.DeliveryCharge.Name = "DeliveryCharge";
            this.DeliveryCharge.Visible = true;
            this.DeliveryCharge.VisibleIndex = 2;
            // 
            // DriverID
            // 
            this.DriverID.Caption = "Driver";
            this.DriverID.FieldName = "DriverID";
            this.DriverID.Name = "DriverID";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Green;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(405, 294);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 44);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnShowAllDriver
            // 
            this.btnShowAllDriver.BackColor = System.Drawing.Color.Navy;
            this.btnShowAllDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAllDriver.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnShowAllDriver.ForeColor = System.Drawing.Color.White;
            this.btnShowAllDriver.Location = new System.Drawing.Point(380, 36);
            this.btnShowAllDriver.Name = "btnShowAllDriver";
            this.btnShowAllDriver.Size = new System.Drawing.Size(128, 29);
            this.btnShowAllDriver.TabIndex = 17;
            this.btnShowAllDriver.Text = "Show All Driver";
            this.btnShowAllDriver.UseVisualStyleBackColor = false;
            this.btnShowAllDriver.Click += new System.EventHandler(this.btnShowAllDriver_Click);
            // 
            // lueDriver
            // 
            this.lueDriver.Location = new System.Drawing.Point(121, 41);
            this.lueDriver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lueDriver.Name = "lueDriver";
            this.lueDriver.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lueDriver.Properties.Appearance.Options.UseFont = true;
            this.lueDriver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDriver.Properties.NullText = "[Please select...]";
            this.lueDriver.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.lueDriver.Size = new System.Drawing.Size(181, 26);
            this.lueDriver.TabIndex = 15;
            this.lueDriver.EditValueChanged += new System.EventHandler(this.lueDriver_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Location = new System.Drawing.Point(13, 46);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Show Driver";
            // 
            // DriverName
            // 
            this.DriverName.Caption = "Driver";
            this.DriverName.FieldName = "DriverName";
            this.DriverName.Name = "DriverName";
            this.DriverName.Visible = true;
            this.DriverName.VisibleIndex = 3;
            // 
            // FrmTaShowOrderDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 356);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmTaShowOrderDriver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmTaShowOrderDriver";
            this.Load += new System.EventHandler(this.FrmTaShowOrderDriver_Load);
            this.SizeChanged += new System.EventHandler(this.FrmTaShowOrderDriver_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDeliveryCharge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaPendOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDriver.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn OrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn OrderTime;
        private DevExpress.XtraGrid.Columns.GridColumn DeliveryCharge;
        private DevExpress.XtraGrid.Columns.GridColumn DriverID;
        private DevExpress.XtraEditors.TextEdit txtTotalDeliveryCharge;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn DriverName;
    }
}