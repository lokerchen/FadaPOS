namespace SuperPOS
{
    partial class FrmInit
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
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.timerData = new System.Windows.Forms.Timer(this.components);
            this.pgInit = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.picBoxLogo.Location = new System.Drawing.Point(12, 14);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Size = new System.Drawing.Size(500, 200);
            this.picBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxLogo.TabIndex = 0;
            this.picBoxLogo.TabStop = false;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(13, 225);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(159, 18);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "Loading system data...";
            // 
            // timerData
            // 
            this.timerData.Tick += new System.EventHandler(this.timerData_Tick);
            // 
            // pgInit
            // 
            this.pgInit.Location = new System.Drawing.Point(12, 255);
            this.pgInit.Name = "pgInit";
            this.pgInit.Size = new System.Drawing.Size(500, 23);
            this.pgInit.TabIndex = 3;
            // 
            // FrmLogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 291);
            this.Controls.Add(this.pgInit);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.picBoxLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmLogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogo";
            this.Load += new System.EventHandler(this.FrmLogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxLogo;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Timer timerData;
        private System.Windows.Forms.ProgressBar pgInit;
    }
}

