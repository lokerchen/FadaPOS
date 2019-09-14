namespace SuperPOS.UI.TA
{
    partial class FrmTaMenuSelect
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
            this.btnMs3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnMs2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnMs1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnMs0 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMs3
            // 
            this.btnMs3.Appearance.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnMs3.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMs3.Appearance.Options.UseBackColor = true;
            this.btnMs3.Appearance.Options.UseFont = true;
            this.btnMs3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnMs3.Location = new System.Drawing.Point(468, 25);
            this.btnMs3.Name = "btnMs3";
            this.btnMs3.Size = new System.Drawing.Size(148, 57);
            this.btnMs3.TabIndex = 3;
            this.btnMs3.Text = "4";
            // 
            // btnMs2
            // 
            this.btnMs2.Appearance.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnMs2.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMs2.Appearance.Options.UseBackColor = true;
            this.btnMs2.Appearance.Options.UseFont = true;
            this.btnMs2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnMs2.Location = new System.Drawing.Point(314, 25);
            this.btnMs2.Name = "btnMs2";
            this.btnMs2.Size = new System.Drawing.Size(148, 57);
            this.btnMs2.TabIndex = 2;
            this.btnMs2.Text = "3";
            // 
            // btnMs1
            // 
            this.btnMs1.Appearance.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnMs1.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMs1.Appearance.Options.UseBackColor = true;
            this.btnMs1.Appearance.Options.UseFont = true;
            this.btnMs1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnMs1.Location = new System.Drawing.Point(160, 25);
            this.btnMs1.Name = "btnMs1";
            this.btnMs1.Size = new System.Drawing.Size(148, 57);
            this.btnMs1.TabIndex = 1;
            this.btnMs1.Text = "2";
            // 
            // btnMs0
            // 
            this.btnMs0.Appearance.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnMs0.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMs0.Appearance.Options.UseBackColor = true;
            this.btnMs0.Appearance.Options.UseFont = true;
            this.btnMs0.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnMs0.Location = new System.Drawing.Point(6, 25);
            this.btnMs0.Name = "btnMs0";
            this.btnMs0.Size = new System.Drawing.Size(148, 57);
            this.btnMs0.TabIndex = 0;
            this.btnMs0.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMs0);
            this.groupBox1.Controls.Add(this.btnMs1);
            this.groupBox1.Controls.Add(this.btnMs2);
            this.groupBox1.Controls.Add(this.btnMs3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 94);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select a menu";
            // 
            // FrmTaMenuSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 115);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaMenuSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTaMenuSelect";
            this.Load += new System.EventHandler(this.FrmTaMenuSelect_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnMs3;
        private DevExpress.XtraEditors.SimpleButton btnMs2;
        private DevExpress.XtraEditors.SimpleButton btnMs1;
        private DevExpress.XtraEditors.SimpleButton btnMs0;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}