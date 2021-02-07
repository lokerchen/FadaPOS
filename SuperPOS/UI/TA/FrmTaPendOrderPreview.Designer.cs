namespace SuperPOS.UI.TA
{
    partial class FrmTaPendOrderPreview
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
            this.richEditCtlPreview = new DevExpress.XtraRichEdit.RichEditControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // richEditCtlPreview
            // 
            this.richEditCtlPreview.Location = new System.Drawing.Point(451, 32);
            this.richEditCtlPreview.Margin = new System.Windows.Forms.Padding(0);
            this.richEditCtlPreview.Name = "richEditCtlPreview";
            this.richEditCtlPreview.Options.HorizontalRuler.ShowTabs = false;
            this.richEditCtlPreview.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditCtlPreview.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richEditCtlPreview.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditCtlPreview.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richEditCtlPreview.Size = new System.Drawing.Size(42, 42);
            this.richEditCtlPreview.TabIndex = 4;
            this.richEditCtlPreview.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = System.Drawing.Color.Olive;
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Appearance.Options.UseForeColor = true;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExit.Location = new System.Drawing.Point(8, 501);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(429, 37);
            this.btnExit.TabIndex = 49;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(8, 13);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(429, 483);
            this.webBrowser1.TabIndex = 50;
            // 
            // FrmTaPendOrderPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 544);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.richEditCtlPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmTaPendOrderPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPendOrderPreview";
            this.Load += new System.EventHandler(this.FrmPendOrderPreview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditCtlPreview;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}