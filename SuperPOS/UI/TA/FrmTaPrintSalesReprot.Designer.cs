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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaPrintSalesReprot));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCurrentDate = new DevExpress.XtraEditors.TextEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCurrentTime = new DevExpress.XtraEditors.TextEdit();
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textEdit6 = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDateLeft = new DevExpress.XtraEditors.SimpleButton();
            this.btnDateRight = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnLanguage = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintSummary = new DevExpress.XtraEditors.SimpleButton();
            this.btnViewSummaryOnly = new DevExpress.XtraEditors.SimpleButton();
            this.btnExprotSalesToCSV = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentDate.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExprotSalesToCSV);
            this.groupBox1.Controls.Add(this.btnViewSummaryOnly);
            this.groupBox1.Controls.Add(this.btnPrintSummary);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnLanguage);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dateNavigator1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 656);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print Sales Report";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textEdit1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.simpleButton2);
            this.panel1.Controls.Add(this.textEdit6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnDateLeft);
            this.panel1.Controls.Add(this.btnDateRight);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 331);
            this.panel1.TabIndex = 72;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCurrentDate);
            this.groupBox3.Location = new System.Drawing.Point(600, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(177, 100);
            this.groupBox3.TabIndex = 71;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Date";
            // 
            // txtCurrentDate
            // 
            this.txtCurrentDate.EditValue = "2020-09-26";
            this.txtCurrentDate.Location = new System.Drawing.Point(16, 50);
            this.txtCurrentDate.Name = "txtCurrentDate";
            this.txtCurrentDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtCurrentDate.Properties.Appearance.Options.UseFont = true;
            this.txtCurrentDate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCurrentDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCurrentDate.Size = new System.Drawing.Size(147, 34);
            this.txtCurrentDate.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCurrentTime);
            this.groupBox2.Location = new System.Drawing.Point(400, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 100);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Time";
            // 
            // txtCurrentTime
            // 
            this.txtCurrentTime.EditValue = "18:35:36";
            this.txtCurrentTime.Location = new System.Drawing.Point(16, 50);
            this.txtCurrentTime.Name = "txtCurrentTime";
            this.txtCurrentTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtCurrentTime.Properties.Appearance.Options.UseFont = true;
            this.txtCurrentTime.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCurrentTime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCurrentTime.Size = new System.Drawing.Size(147, 34);
            this.txtCurrentTime.TabIndex = 0;
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dateNavigator1.Appearance.Options.UseFont = true;
            this.dateNavigator1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.dateNavigator1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.dateNavigator1.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dateNavigator1.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            this.dateNavigator1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dateNavigator1.Location = new System.Drawing.Point(428, 133);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.ShowClearButton = true;
            this.dateNavigator1.ShowHeader = false;
            this.dateNavigator1.ShowWeekNumbers = false;
            this.dateNavigator1.Size = new System.Drawing.Size(349, 331);
            this.dateNavigator1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(127, 34);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 32);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(127, 92);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 32);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "To Date";
            // 
            // textEdit6
            // 
            this.textEdit6.EditValue = "10:00";
            this.textEdit6.Location = new System.Drawing.Point(208, 151);
            this.textEdit6.Name = "textEdit6";
            this.textEdit6.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.textEdit6.Properties.Appearance.Options.UseFont = true;
            this.textEdit6.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit6.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit6.Size = new System.Drawing.Size(82, 30);
            this.textEdit6.TabIndex = 87;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 84;
            this.label5.Text = "From Time";
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
            this.btnDateLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnDateLeft.Image")));
            this.btnDateLeft.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDateLeft.Location = new System.Drawing.Point(18, 150);
            this.btnDateLeft.Name = "btnDateLeft";
            this.btnDateLeft.Size = new System.Drawing.Size(60, 35);
            this.btnDateLeft.TabIndex = 85;
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
            this.btnDateRight.Image = ((System.Drawing.Image)(resources.GetObject("btnDateRight.Image")));
            this.btnDateRight.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDateRight.Location = new System.Drawing.Point(307, 150);
            this.btnDateRight.Name = "btnDateRight";
            this.btnDateRight.Size = new System.Drawing.Size(60, 35);
            this.btnDateRight.TabIndex = 86;
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "10:00";
            this.textEdit1.Location = new System.Drawing.Point(208, 205);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit1.Size = new System.Drawing.Size(82, 30);
            this.textEdit1.TabIndex = 91;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 24);
            this.label3.TabIndex = 88;
            this.label3.Text = "To Time";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.Red;
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Appearance.Options.UseTextOptions = true;
            this.simpleButton1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButton1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.simpleButton1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(18, 204);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(60, 35);
            this.simpleButton1.TabIndex = 89;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.BackColor = System.Drawing.Color.Red;
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.Appearance.Options.UseTextOptions = true;
            this.simpleButton2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButton2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.simpleButton2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton2.Location = new System.Drawing.Point(307, 204);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(60, 35);
            this.simpleButton2.TabIndex = 90;
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
            this.btnExit.Location = new System.Drawing.Point(667, 582);
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
            this.btnLanguage.Location = new System.Drawing.Point(445, 608);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(162, 42);
            this.btnLanguage.TabIndex = 86;
            this.btnLanguage.Text = "LANGUAGE";
            // 
            // btnPrintSummary
            // 
            this.btnPrintSummary.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPrintSummary.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnPrintSummary.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPrintSummary.Appearance.Options.UseBackColor = true;
            this.btnPrintSummary.Appearance.Options.UseFont = true;
            this.btnPrintSummary.Appearance.Options.UseForeColor = true;
            this.btnPrintSummary.Appearance.Options.UseTextOptions = true;
            this.btnPrintSummary.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPrintSummary.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnPrintSummary.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPrintSummary.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPrintSummary.Location = new System.Drawing.Point(64, 544);
            this.btnPrintSummary.Name = "btnPrintSummary";
            this.btnPrintSummary.Size = new System.Drawing.Size(109, 97);
            this.btnPrintSummary.TabIndex = 88;
            this.btnPrintSummary.Text = "Print Summary";
            // 
            // btnViewSummaryOnly
            // 
            this.btnViewSummaryOnly.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnViewSummaryOnly.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnViewSummaryOnly.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnViewSummaryOnly.Appearance.Options.UseBackColor = true;
            this.btnViewSummaryOnly.Appearance.Options.UseFont = true;
            this.btnViewSummaryOnly.Appearance.Options.UseForeColor = true;
            this.btnViewSummaryOnly.Appearance.Options.UseTextOptions = true;
            this.btnViewSummaryOnly.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnViewSummaryOnly.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnViewSummaryOnly.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnViewSummaryOnly.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnViewSummaryOnly.Location = new System.Drawing.Point(179, 544);
            this.btnViewSummaryOnly.Name = "btnViewSummaryOnly";
            this.btnViewSummaryOnly.Size = new System.Drawing.Size(109, 97);
            this.btnViewSummaryOnly.TabIndex = 89;
            this.btnViewSummaryOnly.Text = "View Summary Only";
            // 
            // btnExprotSalesToCSV
            // 
            this.btnExprotSalesToCSV.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnExprotSalesToCSV.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnExprotSalesToCSV.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExprotSalesToCSV.Appearance.Options.UseBackColor = true;
            this.btnExprotSalesToCSV.Appearance.Options.UseFont = true;
            this.btnExprotSalesToCSV.Appearance.Options.UseForeColor = true;
            this.btnExprotSalesToCSV.Appearance.Options.UseTextOptions = true;
            this.btnExprotSalesToCSV.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnExprotSalesToCSV.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnExprotSalesToCSV.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnExprotSalesToCSV.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExprotSalesToCSV.Location = new System.Drawing.Point(294, 544);
            this.btnExprotSalesToCSV.Name = "btnExprotSalesToCSV";
            this.btnExprotSalesToCSV.Size = new System.Drawing.Size(109, 97);
            this.btnExprotSalesToCSV.TabIndex = 90;
            this.btnExprotSalesToCSV.Text = "Export Sales To CSV";
            // 
            // FrmTaPrintSalesReprot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 687);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaPrintSalesReprot";
            this.Text = "FrmTaPrintSalesReprot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaPrintSalesReprot_Load);
            this.SizeChanged += new System.EventHandler(this.FrmTaPrintSalesReprot_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentDate.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.TextEdit txtCurrentDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.TextEdit txtCurrentTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit textEdit6;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton btnDateLeft;
        private DevExpress.XtraEditors.SimpleButton btnDateRight;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnLanguage;
        private DevExpress.XtraEditors.SimpleButton btnExprotSalesToCSV;
        private DevExpress.XtraEditors.SimpleButton btnViewSummaryOnly;
        private DevExpress.XtraEditors.SimpleButton btnPrintSummary;
    }
}