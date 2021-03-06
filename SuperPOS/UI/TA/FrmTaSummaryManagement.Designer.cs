﻿namespace SuperPOS.UI.TA
{
    partial class FrmTaSummaryManagement
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaSummaryManagement));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnLanguage = new DevExpress.XtraEditors.SimpleButton();
            this.deDay = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDateLeft = new DevExpress.XtraEditors.SimpleButton();
            this.btnDateRight = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtRemainingTotalAmt = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemainingOrderQty = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSelectedAmount = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSelectedOrders = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnArchiveDayRecord = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAllOrders = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintAllOrders = new DevExpress.XtraEditors.SimpleButton();
            this.btnAmendOrder = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintAccountSummary = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefreshOrders = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCurrentDate = new DevExpress.XtraEditors.TextEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCurrentTime = new DevExpress.XtraEditors.TextEdit();
            this.gridControlTaSummaryManagement = new DevExpress.XtraGrid.GridControl();
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
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deDay.Properties)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingTotalAmt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingOrderQty.Properties)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSelectedAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSelectedOrders.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentDate.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaSummaryManagement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaShowOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnLanguage);
            this.groupBox1.Controls.Add(this.deDay);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnDateLeft);
            this.groupBox1.Controls.Add(this.btnDateRight);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.btnUp);
            this.groupBox1.Controls.Add(this.btnDown);
            this.groupBox1.Controls.Add(this.btnArchiveDayRecord);
            this.groupBox1.Controls.Add(this.btnSelectAllOrders);
            this.groupBox1.Controls.Add(this.btnPrintAllOrders);
            this.groupBox1.Controls.Add(this.btnAmendOrder);
            this.groupBox1.Controls.Add(this.btnPrintAccountSummary);
            this.groupBox1.Controls.Add(this.btnRefreshOrders);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.gridControlTaSummaryManagement);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupBox1.Location = new System.Drawing.Point(9, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(976, 532);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summary Management";
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Appearance.Options.UseForeColor = true;
            this.btnExit.Appearance.Options.UseTextOptions = true;
            this.btnExit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExit.Location = new System.Drawing.Point(865, 462);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 53);
            this.btnExit.TabIndex = 85;
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
            this.btnLanguage.Location = new System.Drawing.Point(671, 482);
            this.btnLanguage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(142, 33);
            this.btnLanguage.TabIndex = 84;
            this.btnLanguage.Text = "LANGUAGE";
            // 
            // deDay
            // 
            this.deDay.EditValue = "2020-09-26";
            this.deDay.Location = new System.Drawing.Point(709, 402);
            this.deDay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deDay.Name = "deDay";
            this.deDay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.deDay.Properties.Appearance.Options.UseFont = true;
            this.deDay.Properties.Appearance.Options.UseTextOptions = true;
            this.deDay.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.deDay.Properties.AutoHeight = false;
            this.deDay.Size = new System.Drawing.Size(130, 30);
            this.deDay.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(665, 402);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 31);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDateLeft
            // 
            this.btnDateLeft.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnDateLeft.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDateLeft.Appearance.Options.UseBackColor = true;
            this.btnDateLeft.Appearance.Options.UseForeColor = true;
            this.btnDateLeft.Appearance.Options.UseTextOptions = true;
            this.btnDateLeft.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnDateLeft.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnDateLeft.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDateLeft.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnDateLeft.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDateLeft.ImageOptions.Image")));
            this.btnDateLeft.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDateLeft.Location = new System.Drawing.Point(592, 402);
            this.btnDateLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDateLeft.Name = "btnDateLeft";
            this.btnDateLeft.Size = new System.Drawing.Size(70, 30);
            this.btnDateLeft.TabIndex = 81;
            this.btnDateLeft.Click += new System.EventHandler(this.btnDateLeft_Click);
            // 
            // btnDateRight
            // 
            this.btnDateRight.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnDateRight.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDateRight.Appearance.Options.UseBackColor = true;
            this.btnDateRight.Appearance.Options.UseForeColor = true;
            this.btnDateRight.Appearance.Options.UseTextOptions = true;
            this.btnDateRight.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnDateRight.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnDateRight.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnDateRight.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnDateRight.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDateRight.ImageOptions.Image")));
            this.btnDateRight.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDateRight.Location = new System.Drawing.Point(844, 402);
            this.btnDateRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDateRight.Name = "btnDateRight";
            this.btnDateRight.Size = new System.Drawing.Size(70, 30);
            this.btnDateRight.TabIndex = 82;
            this.btnDateRight.Click += new System.EventHandler(this.btnDateRight_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtRemainingTotalAmt);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtRemainingOrderQty);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(350, 434);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(262, 86);
            this.groupBox5.TabIndex = 80;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Remaining";
            // 
            // txtRemainingTotalAmt
            // 
            this.txtRemainingTotalAmt.EditValue = "0.00";
            this.txtRemainingTotalAmt.Location = new System.Drawing.Point(139, 54);
            this.txtRemainingTotalAmt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRemainingTotalAmt.Name = "txtRemainingTotalAmt";
            this.txtRemainingTotalAmt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtRemainingTotalAmt.Properties.Appearance.Options.UseFont = true;
            this.txtRemainingTotalAmt.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRemainingTotalAmt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtRemainingTotalAmt.Size = new System.Drawing.Size(105, 30);
            this.txtRemainingTotalAmt.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Amt";
            // 
            // txtRemainingOrderQty
            // 
            this.txtRemainingOrderQty.EditValue = "0";
            this.txtRemainingOrderQty.Location = new System.Drawing.Point(15, 54);
            this.txtRemainingOrderQty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRemainingOrderQty.Name = "txtRemainingOrderQty";
            this.txtRemainingOrderQty.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtRemainingOrderQty.Properties.Appearance.Options.UseFont = true;
            this.txtRemainingOrderQty.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRemainingOrderQty.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtRemainingOrderQty.Size = new System.Drawing.Size(105, 30);
            this.txtRemainingOrderQty.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Order Qty";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSelectedAmount);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtSelectedOrders);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(70, 434);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(262, 86);
            this.groupBox4.TabIndex = 78;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Selected";
            // 
            // txtSelectedAmount
            // 
            this.txtSelectedAmount.EditValue = "0.00";
            this.txtSelectedAmount.Location = new System.Drawing.Point(139, 54);
            this.txtSelectedAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedAmount.Name = "txtSelectedAmount";
            this.txtSelectedAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtSelectedAmount.Properties.Appearance.Options.UseFont = true;
            this.txtSelectedAmount.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSelectedAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSelectedAmount.Size = new System.Drawing.Size(105, 30);
            this.txtSelectedAmount.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amount";
            // 
            // txtSelectedOrders
            // 
            this.txtSelectedOrders.EditValue = "0";
            this.txtSelectedOrders.Location = new System.Drawing.Point(15, 54);
            this.txtSelectedOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedOrders.Name = "txtSelectedOrders";
            this.txtSelectedOrders.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtSelectedOrders.Properties.Appearance.Options.UseFont = true;
            this.txtSelectedOrders.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSelectedOrders.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSelectedOrders.Size = new System.Drawing.Size(105, 30);
            this.txtSelectedOrders.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orders";
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
            this.btnUp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.ImageOptions.Image")));
            this.btnUp.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnUp.Location = new System.Drawing.Point(15, 434);
            this.btnUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(48, 47);
            this.btnUp.TabIndex = 76;
            this.btnUp.Text = ">>";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
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
            this.btnDown.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.ImageOptions.Image")));
            this.btnDown.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDown.Location = new System.Drawing.Point(15, 485);
            this.btnDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(48, 47);
            this.btnDown.TabIndex = 77;
            this.btnDown.Text = "<<";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnArchiveDayRecord
            // 
            this.btnArchiveDayRecord.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnArchiveDayRecord.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnArchiveDayRecord.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnArchiveDayRecord.Appearance.Options.UseBackColor = true;
            this.btnArchiveDayRecord.Appearance.Options.UseFont = true;
            this.btnArchiveDayRecord.Appearance.Options.UseForeColor = true;
            this.btnArchiveDayRecord.Appearance.Options.UseTextOptions = true;
            this.btnArchiveDayRecord.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnArchiveDayRecord.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnArchiveDayRecord.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnArchiveDayRecord.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnArchiveDayRecord.Location = new System.Drawing.Point(752, 303);
            this.btnArchiveDayRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnArchiveDayRecord.Name = "btnArchiveDayRecord";
            this.btnArchiveDayRecord.Size = new System.Drawing.Size(120, 73);
            this.btnArchiveDayRecord.TabIndex = 75;
            this.btnArchiveDayRecord.Text = "Archive Day Record";
            // 
            // btnSelectAllOrders
            // 
            this.btnSelectAllOrders.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSelectAllOrders.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnSelectAllOrders.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSelectAllOrders.Appearance.Options.UseBackColor = true;
            this.btnSelectAllOrders.Appearance.Options.UseFont = true;
            this.btnSelectAllOrders.Appearance.Options.UseForeColor = true;
            this.btnSelectAllOrders.Appearance.Options.UseTextOptions = true;
            this.btnSelectAllOrders.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnSelectAllOrders.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnSelectAllOrders.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSelectAllOrders.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnSelectAllOrders.Location = new System.Drawing.Point(604, 303);
            this.btnSelectAllOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectAllOrders.Name = "btnSelectAllOrders";
            this.btnSelectAllOrders.Size = new System.Drawing.Size(120, 73);
            this.btnSelectAllOrders.TabIndex = 74;
            this.btnSelectAllOrders.Text = "Select All Orders";
            this.btnSelectAllOrders.Click += new System.EventHandler(this.btnSelectAllOrders_Click);
            // 
            // btnPrintAllOrders
            // 
            this.btnPrintAllOrders.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPrintAllOrders.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnPrintAllOrders.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPrintAllOrders.Appearance.Options.UseBackColor = true;
            this.btnPrintAllOrders.Appearance.Options.UseFont = true;
            this.btnPrintAllOrders.Appearance.Options.UseForeColor = true;
            this.btnPrintAllOrders.Appearance.Options.UseTextOptions = true;
            this.btnPrintAllOrders.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPrintAllOrders.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnPrintAllOrders.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPrintAllOrders.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPrintAllOrders.Location = new System.Drawing.Point(752, 210);
            this.btnPrintAllOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintAllOrders.Name = "btnPrintAllOrders";
            this.btnPrintAllOrders.Size = new System.Drawing.Size(120, 73);
            this.btnPrintAllOrders.TabIndex = 73;
            this.btnPrintAllOrders.Text = "Print All Orders";
            // 
            // btnAmendOrder
            // 
            this.btnAmendOrder.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAmendOrder.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnAmendOrder.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAmendOrder.Appearance.Options.UseBackColor = true;
            this.btnAmendOrder.Appearance.Options.UseFont = true;
            this.btnAmendOrder.Appearance.Options.UseForeColor = true;
            this.btnAmendOrder.Appearance.Options.UseTextOptions = true;
            this.btnAmendOrder.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnAmendOrder.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnAmendOrder.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnAmendOrder.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnAmendOrder.Location = new System.Drawing.Point(604, 210);
            this.btnAmendOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAmendOrder.Name = "btnAmendOrder";
            this.btnAmendOrder.Size = new System.Drawing.Size(120, 73);
            this.btnAmendOrder.TabIndex = 72;
            this.btnAmendOrder.Text = "Amend Order";
            this.btnAmendOrder.Click += new System.EventHandler(this.btnAmendOrder_Click);
            // 
            // btnPrintAccountSummary
            // 
            this.btnPrintAccountSummary.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPrintAccountSummary.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnPrintAccountSummary.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPrintAccountSummary.Appearance.Options.UseBackColor = true;
            this.btnPrintAccountSummary.Appearance.Options.UseFont = true;
            this.btnPrintAccountSummary.Appearance.Options.UseForeColor = true;
            this.btnPrintAccountSummary.Appearance.Options.UseTextOptions = true;
            this.btnPrintAccountSummary.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPrintAccountSummary.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnPrintAccountSummary.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPrintAccountSummary.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPrintAccountSummary.Location = new System.Drawing.Point(752, 121);
            this.btnPrintAccountSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintAccountSummary.Name = "btnPrintAccountSummary";
            this.btnPrintAccountSummary.Size = new System.Drawing.Size(120, 73);
            this.btnPrintAccountSummary.TabIndex = 71;
            this.btnPrintAccountSummary.Text = "Print Account Summary";
            this.btnPrintAccountSummary.Click += new System.EventHandler(this.btnPrintAccountSummary_Click);
            // 
            // btnRefreshOrders
            // 
            this.btnRefreshOrders.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRefreshOrders.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnRefreshOrders.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRefreshOrders.Appearance.Options.UseBackColor = true;
            this.btnRefreshOrders.Appearance.Options.UseFont = true;
            this.btnRefreshOrders.Appearance.Options.UseForeColor = true;
            this.btnRefreshOrders.Appearance.Options.UseTextOptions = true;
            this.btnRefreshOrders.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnRefreshOrders.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnRefreshOrders.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnRefreshOrders.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnRefreshOrders.Location = new System.Drawing.Point(604, 121);
            this.btnRefreshOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefreshOrders.Name = "btnRefreshOrders";
            this.btnRefreshOrders.Size = new System.Drawing.Size(120, 73);
            this.btnRefreshOrders.TabIndex = 70;
            this.btnRefreshOrders.Text = "Refresh Orders";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCurrentDate);
            this.groupBox3.Location = new System.Drawing.Point(752, 23);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(155, 78);
            this.groupBox3.TabIndex = 69;
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
            this.groupBox2.Location = new System.Drawing.Point(569, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(155, 78);
            this.groupBox2.TabIndex = 67;
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
            // gridControlTaSummaryManagement
            // 
            this.gridControlTaSummaryManagement.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlTaSummaryManagement.Font = new System.Drawing.Font("Calibri", 14F);
            this.gridControlTaSummaryManagement.Location = new System.Drawing.Point(15, 32);
            this.gridControlTaSummaryManagement.MainView = this.gvTaShowOrder;
            this.gridControlTaSummaryManagement.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlTaSummaryManagement.Name = "gridControlTaSummaryManagement";
            this.gridControlTaSummaryManagement.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckedComboBoxEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gridControlTaSummaryManagement.Size = new System.Drawing.Size(528, 397);
            this.gridControlTaSummaryManagement.TabIndex = 66;
            this.gridControlTaSummaryManagement.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaShowOrder});
            // 
            // gvTaShowOrder
            // 
            this.gvTaShowOrder.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvTaShowOrder.Appearance.EvenRow.Font = new System.Drawing.Font("Calibri", 12F);
            this.gvTaShowOrder.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTaShowOrder.Appearance.EvenRow.Options.UseFont = true;
            this.gvTaShowOrder.Appearance.FocusedRow.BackColor = System.Drawing.Color.RoyalBlue;
            this.gvTaShowOrder.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvTaShowOrder.Appearance.HeaderPanel.Font = new System.Drawing.Font("Calibri", 12F);
            this.gvTaShowOrder.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvTaShowOrder.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvTaShowOrder.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvTaShowOrder.Appearance.OddRow.Font = new System.Drawing.Font("Calibri", 12F);
            this.gvTaShowOrder.Appearance.OddRow.Options.UseFont = true;
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
            this.gvTaShowOrder.GridControl = this.gridControlTaSummaryManagement;
            this.gvTaShowOrder.IndicatorWidth = 50;
            this.gvTaShowOrder.Name = "gvTaShowOrder";
            this.gvTaShowOrder.OptionsBehavior.Editable = false;
            this.gvTaShowOrder.OptionsMenu.EnableColumnMenu = false;
            this.gvTaShowOrder.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTaShowOrder.OptionsSelection.MultiSelect = true;
            this.gvTaShowOrder.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvTaShowOrder.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTaShowOrder.OptionsView.EnableAppearanceOddRow = true;
            this.gvTaShowOrder.OptionsView.ShowGroupPanel = false;
            this.gvTaShowOrder.OptionsView.ShowIndicator = false;
            this.gvTaShowOrder.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvTaShowOrder_CustomDrawRowIndicator);
            this.gvTaShowOrder.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvTaShowOrder_SelectionChanged);
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
            this.CheckCode.VisibleIndex = 1;
            // 
            // OrderTime
            // 
            this.OrderTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.OrderTime.AppearanceCell.Options.UseFont = true;
            this.OrderTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderTime.AppearanceHeader.Options.UseFont = true;
            this.OrderTime.Caption = "Time";
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
            this.PayOrderType.VisibleIndex = 4;
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
            this.TotalAmount.VisibleIndex = 5;
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
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.ValueChecked = "1";
            this.repositoryItemCheckEdit2.ValueUnchecked = "0";
            // 
            // tTimer
            // 
            this.tTimer.Enabled = true;
            this.tTimer.Interval = 1000;
            this.tTimer.Tick += new System.EventHandler(this.tTimer_Tick);
            // 
            // FrmTaSummaryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 549);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmTaSummaryManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTaSummaryManagement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaSummaryManagement_Load);
            this.SizeChanged += new System.EventHandler(this.FrmTaSummaryManagement_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deDay.Properties)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingTotalAmt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingOrderQty.Properties)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSelectedAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSelectedOrders.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentDate.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaSummaryManagement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaShowOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl gridControlTaSummaryManagement;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.TextEdit txtCurrentDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.TextEdit txtCurrentTime;
        private DevExpress.XtraEditors.SimpleButton btnPrintAllOrders;
        private DevExpress.XtraEditors.SimpleButton btnAmendOrder;
        private DevExpress.XtraEditors.SimpleButton btnPrintAccountSummary;
        private DevExpress.XtraEditors.SimpleButton btnRefreshOrders;
        private DevExpress.XtraEditors.SimpleButton btnArchiveDayRecord;
        private DevExpress.XtraEditors.SimpleButton btnSelectAllOrders;
        private System.Windows.Forms.GroupBox groupBox5;
        private DevExpress.XtraEditors.TextEdit txtRemainingTotalAmt;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtRemainingOrderQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraEditors.TextEdit txtSelectedAmount;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtSelectedOrders;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnUp;
        private DevExpress.XtraEditors.SimpleButton btnDown;
        private DevExpress.XtraEditors.TextEdit deDay;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton btnDateLeft;
        private DevExpress.XtraEditors.SimpleButton btnDateRight;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnLanguage;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private System.Windows.Forms.Timer tTimer;
    }
}