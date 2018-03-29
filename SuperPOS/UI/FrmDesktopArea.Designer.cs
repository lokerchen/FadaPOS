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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnLogout = new DevExpress.XtraEditors.SimpleButton();
            this.lblUsrName = new DevExpress.XtraEditors.LabelControl();
            this.btnCtlPanel = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowOrder = new DevExpress.XtraEditors.SimpleButton();
            this.lblSession = new DevExpress.XtraEditors.LabelControl();
            this.btnDrawer = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOrderScreen = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnOrderScreen);
            this.panelControl1.Controls.Add(this.btnLogout);
            this.panelControl1.Controls.Add(this.lblUsrName);
            this.panelControl1.Controls.Add(this.btnCtlPanel);
            this.panelControl1.Controls.Add(this.btnShowOrder);
            this.panelControl1.Controls.Add(this.lblSession);
            this.panelControl1.Controls.Add(this.btnDrawer);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(4, 7);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(866, 351);
            this.panelControl1.TabIndex = 0;
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
            this.btnLogout.Location = new System.Drawing.Point(324, 250);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(190, 80);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUsrName
            // 
            this.lblUsrName.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsrName.Location = new System.Drawing.Point(28, 189);
            this.lblUsrName.Name = "lblUsrName";
            this.lblUsrName.Size = new System.Drawing.Size(101, 36);
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
            this.btnCtlPanel.Location = new System.Drawing.Point(666, 138);
            this.btnCtlPanel.Name = "btnCtlPanel";
            this.btnCtlPanel.Size = new System.Drawing.Size(190, 80);
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
            this.btnShowOrder.Location = new System.Drawing.Point(451, 138);
            this.btnShowOrder.Name = "btnShowOrder";
            this.btnShowOrder.Size = new System.Drawing.Size(190, 80);
            this.btnShowOrder.TabIndex = 8;
            this.btnShowOrder.Text = "Show Order";
            this.btnShowOrder.Click += new System.EventHandler(this.btnShowOrder_Click);
            // 
            // lblSession
            // 
            this.lblSession.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSession.Location = new System.Drawing.Point(28, 119);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(108, 36);
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
            this.btnDrawer.Location = new System.Drawing.Point(232, 138);
            this.btnDrawer.Name = "btnDrawer";
            this.btnDrawer.Size = new System.Drawing.Size(190, 80);
            this.btnDrawer.TabIndex = 6;
            this.btnDrawer.Text = "Cash Drawer";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(364, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(355, 84);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Home Page";
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
            this.btnOrderScreen.Location = new System.Drawing.Point(562, 250);
            this.btnOrderScreen.Name = "btnOrderScreen";
            this.btnOrderScreen.Size = new System.Drawing.Size(190, 80);
            this.btnOrderScreen.TabIndex = 12;
            this.btnOrderScreen.Text = "Order Screen";
            this.btnOrderScreen.Click += new System.EventHandler(this.btnOrderScreen_Click);
            // 
            // FrmDesktopArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 364);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
    }
}