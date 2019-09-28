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
            this.SuspendLayout();
            // 
            // richEditCtlPreview
            // 
            this.richEditCtlPreview.EnableToolTips = true;
            this.richEditCtlPreview.Location = new System.Drawing.Point(9, 9);
            this.richEditCtlPreview.Margin = new System.Windows.Forms.Padding(0);
            this.richEditCtlPreview.Name = "richEditCtlPreview";
            this.richEditCtlPreview.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never;
            this.richEditCtlPreview.Options.Fields.UpdateFieldsInTextBoxes = false;
            this.richEditCtlPreview.Options.HorizontalRuler.ShowTabs = false;
            this.richEditCtlPreview.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditCtlPreview.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richEditCtlPreview.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditCtlPreview.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richEditCtlPreview.Size = new System.Drawing.Size(490, 628);
            this.richEditCtlPreview.TabIndex = 4;
            this.richEditCtlPreview.Text = "rich";
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
            this.btnExit.Location = new System.Drawing.Point(9, 644);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(490, 48);
            this.btnExit.TabIndex = 49;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmTaPendOrderPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 700);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.richEditCtlPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaPendOrderPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPendOrderPreview";
            this.Load += new System.EventHandler(this.FrmPendOrderPreview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditCtlPreview;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}