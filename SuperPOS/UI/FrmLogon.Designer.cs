namespace SuperPOS.UI
{
    partial class FrmLogon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogon));
            this.txtPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btn0 = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btn9 = new DevExpress.XtraEditors.SimpleButton();
            this.btn8 = new DevExpress.XtraEditors.SimpleButton();
            this.btn7 = new DevExpress.XtraEditors.SimpleButton();
            this.btn6 = new DevExpress.XtraEditors.SimpleButton();
            this.btn5 = new DevExpress.XtraEditors.SimpleButton();
            this.btn4 = new DevExpress.XtraEditors.SimpleButton();
            this.btn3 = new DevExpress.XtraEditors.SimpleButton();
            this.btn2 = new DevExpress.XtraEditors.SimpleButton();
            this.btn1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblSession = new DevExpress.XtraEditors.LabelControl();
            this.lblTime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tTimer = new System.Windows.Forms.Timer(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPwd
            // 
            this.txtPwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPwd.EditValue = "";
            this.txtPwd.Location = new System.Drawing.Point(482, 231);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPwd.Properties.Appearance.Options.UseFont = true;
            this.txtPwd.Properties.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(225, 34);
            this.txtPwd.TabIndex = 12;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Location = new System.Drawing.Point(376, 237);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(103, 28);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Password:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btn0);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.btn9);
            this.groupBox1.Controls.Add(this.btn8);
            this.groupBox1.Controls.Add(this.btn7);
            this.groupBox1.Controls.Add(this.btn6);
            this.groupBox1.Controls.Add(this.btn5);
            this.groupBox1.Controls.Add(this.btn4);
            this.groupBox1.Controls.Add(this.btn3);
            this.groupBox1.Controls.Add(this.btn2);
            this.groupBox1.Controls.Add(this.btn1);
            this.groupBox1.Location = new System.Drawing.Point(371, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 227);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClear.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClear.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClear.Appearance.Options.UseBackColor = true;
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Appearance.Options.UseForeColor = true;
            this.btnClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnClear.Location = new System.Drawing.Point(114, 176);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 45);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "CLEAR";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btn0
            // 
            this.btn0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn0.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btn0.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn0.Appearance.Options.UseBackColor = true;
            this.btn0.Appearance.Options.UseFont = true;
            this.btn0.Appearance.Options.UseForeColor = true;
            this.btn0.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn0.Location = new System.Drawing.Point(7, 176);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(101, 45);
            this.btn0.TabIndex = 11;
            this.btn0.Text = "0";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Appearance.Options.UseForeColor = true;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExit.Location = new System.Drawing.Point(217, 125);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 96);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "EXIT";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.Appearance.BackColor = System.Drawing.Color.SeaGreen;
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Appearance.Options.UseForeColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnOK.Location = new System.Drawing.Point(217, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 100);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btn9
            // 
            this.btn9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn9.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btn9.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn9.Appearance.Options.UseBackColor = true;
            this.btn9.Appearance.Options.UseFont = true;
            this.btn9.Appearance.Options.UseForeColor = true;
            this.btn9.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn9.Location = new System.Drawing.Point(147, 125);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(60, 45);
            this.btn9.TabIndex = 8;
            this.btn9.Text = "9";
            // 
            // btn8
            // 
            this.btn8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn8.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btn8.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn8.Appearance.Options.UseBackColor = true;
            this.btn8.Appearance.Options.UseFont = true;
            this.btn8.Appearance.Options.UseForeColor = true;
            this.btn8.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn8.Location = new System.Drawing.Point(77, 125);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(60, 45);
            this.btn8.TabIndex = 7;
            this.btn8.Text = "8";
            // 
            // btn7
            // 
            this.btn7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn7.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btn7.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn7.Appearance.Options.UseBackColor = true;
            this.btn7.Appearance.Options.UseFont = true;
            this.btn7.Appearance.Options.UseForeColor = true;
            this.btn7.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn7.Location = new System.Drawing.Point(7, 125);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(60, 45);
            this.btn7.TabIndex = 6;
            this.btn7.Text = "7";
            // 
            // btn6
            // 
            this.btn6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn6.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btn6.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn6.Appearance.Options.UseBackColor = true;
            this.btn6.Appearance.Options.UseFont = true;
            this.btn6.Appearance.Options.UseForeColor = true;
            this.btn6.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn6.Location = new System.Drawing.Point(147, 70);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(60, 45);
            this.btn6.TabIndex = 5;
            this.btn6.Text = "6";
            // 
            // btn5
            // 
            this.btn5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn5.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btn5.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn5.Appearance.Options.UseBackColor = true;
            this.btn5.Appearance.Options.UseFont = true;
            this.btn5.Appearance.Options.UseForeColor = true;
            this.btn5.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn5.Location = new System.Drawing.Point(77, 70);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(60, 45);
            this.btn5.TabIndex = 4;
            this.btn5.Text = "5";
            // 
            // btn4
            // 
            this.btn4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn4.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btn4.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn4.Appearance.Options.UseBackColor = true;
            this.btn4.Appearance.Options.UseFont = true;
            this.btn4.Appearance.Options.UseForeColor = true;
            this.btn4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn4.Location = new System.Drawing.Point(7, 70);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(60, 45);
            this.btn4.TabIndex = 3;
            this.btn4.Text = "4";
            // 
            // btn3
            // 
            this.btn3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn3.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btn3.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn3.Appearance.Options.UseBackColor = true;
            this.btn3.Appearance.Options.UseFont = true;
            this.btn3.Appearance.Options.UseForeColor = true;
            this.btn3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn3.Location = new System.Drawing.Point(147, 15);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(60, 45);
            this.btn3.TabIndex = 2;
            this.btn3.Text = "3";
            // 
            // btn2
            // 
            this.btn2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn2.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btn2.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn2.Appearance.Options.UseBackColor = true;
            this.btn2.Appearance.Options.UseFont = true;
            this.btn2.Appearance.Options.UseForeColor = true;
            this.btn2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn2.Location = new System.Drawing.Point(77, 15);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(60, 45);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "2";
            // 
            // btn1
            // 
            this.btn1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn1.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btn1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn1.Appearance.Options.UseBackColor = true;
            this.btn1.Appearance.Options.UseFont = true;
            this.btn1.Appearance.Options.UseForeColor = true;
            this.btn1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn1.Location = new System.Drawing.Point(7, 15);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(60, 45);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "1";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.lblSession);
            this.groupControl1.Controls.Add(this.lblTime);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.lblDate);
            this.groupControl1.Location = new System.Drawing.Point(17, 237);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(348, 256);
            this.groupControl1.TabIndex = 9;
            // 
            // lblSession
            // 
            this.lblSession.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSession.Appearance.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSession.Location = new System.Drawing.Point(160, 173);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(99, 36);
            this.lblSession.TabIndex = 5;
            this.lblSession.Text = "LUNCH";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTime.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(160, 131);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(102, 30);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "08:08:08";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl5.Location = new System.Drawing.Point(32, 173);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(110, 36);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Session:";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDate.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(160, 80);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(130, 30);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "2017-05-05";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Location = new System.Drawing.Point(401, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(306, 196);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(348, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // tTimer
            // 
            this.tTimer.Enabled = true;
            this.tTimer.Interval = 1000;
            this.tTimer.Tick += new System.EventHandler(this.tTimer_Tick);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl2.Location = new System.Drawing.Point(32, 127);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(76, 36);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Time:";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Location = new System.Drawing.Point(32, 76);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 36);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Date:";
            // 
            // FrmLogon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 507);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.Name = "FrmLogon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmLogon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtPwd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.SimpleButton btn1;
        private DevExpress.XtraEditors.LabelControl lblSession;
        private DevExpress.XtraEditors.LabelControl lblTime;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btn2;
        private DevExpress.XtraEditors.SimpleButton btn9;
        private DevExpress.XtraEditors.SimpleButton btn8;
        private DevExpress.XtraEditors.SimpleButton btn7;
        private DevExpress.XtraEditors.SimpleButton btn6;
        private DevExpress.XtraEditors.SimpleButton btn5;
        private DevExpress.XtraEditors.SimpleButton btn4;
        private DevExpress.XtraEditors.SimpleButton btn3;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btn0;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.Timer tTimer;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}