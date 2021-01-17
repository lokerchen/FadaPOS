namespace SuperPOS.UI
{
    partial class FrmDesktopArea
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblTime = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.btnOrderScreen = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogout = new DevExpress.XtraEditors.SimpleButton();
            this.lblUsrName = new DevExpress.XtraEditors.LabelControl();
            this.btnCtlPanel = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowOrder = new DevExpress.XtraEditors.SimpleButton();
            this.lblSession = new DevExpress.XtraEditors.LabelControl();
            this.btnDrawer = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblTime);
            this.panelControl1.Controls.Add(this.lblDate);
            this.panelControl1.Controls.Add(this.btnOrderScreen);
            this.panelControl1.Controls.Add(this.btnLogout);
            this.panelControl1.Controls.Add(this.lblUsrName);
            this.panelControl1.Controls.Add(this.btnCtlPanel);
            this.panelControl1.Controls.Add(this.btnShowOrder);
            this.panelControl1.Controls.Add(this.lblSession);
            this.panelControl1.Controls.Add(this.btnDrawer);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(4, 5);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(758, 273);
            this.panelControl1.TabIndex = 0;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTime.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(24, 50);
            this.lblTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(80, 24);
            this.lblTime.TabIndex = 14;
            this.lblTime.Text = "08:08:08";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDate.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(24, 15);
            this.lblDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(102, 24);
            this.lblDate.TabIndex = 13;
            this.lblDate.Text = "2017-05-05";
            // 
            // btnOrderScreen
            // 
            this.btnOrderScreen.Appearance.BackColor = System.Drawing.Color.Lime;
            this.btnOrderScreen.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderScreen.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOrderScreen.Appearance.Options.UseBackColor = true;
            this.btnOrderScreen.Appearance.Options.UseFont = true;
            this.btnOrderScreen.Appearance.Options.UseForeColor = true;
            this.btnOrderScreen.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnOrderScreen.Location = new System.Drawing.Point(492, 194);
            this.btnOrderScreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrderScreen.Name = "btnOrderScreen";
            this.btnOrderScreen.Size = new System.Drawing.Size(166, 62);
            this.btnOrderScreen.TabIndex = 12;
            this.btnOrderScreen.Text = "Order Screen";
            this.btnOrderScreen.Click += new System.EventHandler(this.btnOrderScreen_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Appearance.Options.UseBackColor = true;
            this.btnLogout.Appearance.Options.UseFont = true;
            this.btnLogout.Appearance.Options.UseForeColor = true;
            this.btnLogout.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnLogout.Location = new System.Drawing.Point(284, 194);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(166, 62);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUsrName
            // 
            this.lblUsrName.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsrName.Location = new System.Drawing.Point(24, 147);
            this.lblUsrName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblUsrName.Name = "lblUsrName";
            this.lblUsrName.Size = new System.Drawing.Size(80, 29);
            this.lblUsrName.TabIndex = 11;
            this.lblUsrName.Text = "STAFF8";
            // 
            // btnCtlPanel
            // 
            this.btnCtlPanel.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnCtlPanel.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCtlPanel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCtlPanel.Appearance.Options.UseBackColor = true;
            this.btnCtlPanel.Appearance.Options.UseFont = true;
            this.btnCtlPanel.Appearance.Options.UseForeColor = true;
            this.btnCtlPanel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnCtlPanel.Location = new System.Drawing.Point(583, 107);
            this.btnCtlPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCtlPanel.Name = "btnCtlPanel";
            this.btnCtlPanel.Size = new System.Drawing.Size(166, 62);
            this.btnCtlPanel.TabIndex = 7;
            this.btnCtlPanel.Text = "Control Panel";
            this.btnCtlPanel.Click += new System.EventHandler(this.btnCtlPanel_Click);
            // 
            // btnShowOrder
            // 
            this.btnShowOrder.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnShowOrder.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowOrder.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnShowOrder.Appearance.Options.UseBackColor = true;
            this.btnShowOrder.Appearance.Options.UseFont = true;
            this.btnShowOrder.Appearance.Options.UseForeColor = true;
            this.btnShowOrder.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnShowOrder.Location = new System.Drawing.Point(395, 107);
            this.btnShowOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowOrder.Name = "btnShowOrder";
            this.btnShowOrder.Size = new System.Drawing.Size(166, 62);
            this.btnShowOrder.TabIndex = 8;
            this.btnShowOrder.Text = "Show Order";
            this.btnShowOrder.Click += new System.EventHandler(this.btnShowOrder_Click);
            // 
            // lblSession
            // 
            this.lblSession.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSession.Location = new System.Drawing.Point(24, 93);
            this.lblSession.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(86, 29);
            this.lblSession.TabIndex = 10;
            this.lblSession.Text = "DINNER";
            // 
            // btnDrawer
            // 
            this.btnDrawer.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnDrawer.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrawer.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDrawer.Appearance.Options.UseBackColor = true;
            this.btnDrawer.Appearance.Options.UseFont = true;
            this.btnDrawer.Appearance.Options.UseForeColor = true;
            this.btnDrawer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnDrawer.Location = new System.Drawing.Point(203, 107);
            this.btnDrawer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDrawer.Name = "btnDrawer";
            this.btnDrawer.Size = new System.Drawing.Size(166, 62);
            this.btnDrawer.TabIndex = 6;
            this.btnDrawer.Text = "Cash Drawer";
            this.btnDrawer.Click += new System.EventHandler(this.btnDrawer_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(318, 15);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(282, 68);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Home Page";
            // 
            // tTimer
            // 
            this.tTimer.Enabled = true;
            this.tTimer.Interval = 1000;
            this.tTimer.Tick += new System.EventHandler(this.tTimer_Tick);
            // 
            // FrmDesktopArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 283);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDesktopArea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDesktopArea_Load);
            this.SizeChanged += new System.EventHandler(this.FrmDesktopArea_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCtlPanel;
        private DevExpress.XtraEditors.SimpleButton btnDrawer;
        private DevExpress.XtraEditors.SimpleButton btnShowOrder;
        private DevExpress.XtraEditors.SimpleButton btnLogout;
        private DevExpress.XtraEditors.LabelControl lblUsrName;
        private DevExpress.XtraEditors.LabelControl lblSession;
        private DevExpress.XtraEditors.SimpleButton btnOrderScreen;
        private DevExpress.XtraEditors.LabelControl lblTime;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private System.Windows.Forms.Timer tTimer;
    }
}