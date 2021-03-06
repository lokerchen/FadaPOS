﻿namespace SuperPOS.UI.Sys
{
    partial class FrmTaSysFont
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMiFont = new DevExpress.XtraEditors.TextEdit();
            this.txtCateFont = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiFont.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCateFont.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 9);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(226, 22);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Menu Dish Button Font Size:";
            // 
            // txtMiFont
            // 
            this.txtMiFont.EditValue = "9";
            this.txtMiFont.Location = new System.Drawing.Point(269, 5);
            this.txtMiFont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMiFont.Name = "txtMiFont";
            this.txtMiFont.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiFont.Properties.Appearance.Options.UseFont = true;
            this.txtMiFont.Properties.Mask.EditMask = "f0";
            this.txtMiFont.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMiFont.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMiFont.Size = new System.Drawing.Size(88, 28);
            this.txtMiFont.TabIndex = 1;
            // 
            // txtCateFont
            // 
            this.txtCateFont.EditValue = "9";
            this.txtCateFont.Location = new System.Drawing.Point(269, 36);
            this.txtCateFont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCateFont.Name = "txtCateFont";
            this.txtCateFont.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCateFont.Properties.Appearance.Options.UseFont = true;
            this.txtCateFont.Properties.Mask.EditMask = "n0";
            this.txtCateFont.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCateFont.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCateFont.Size = new System.Drawing.Size(88, 28);
            this.txtCateFont.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(25, 40);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(213, 22);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Category Button Font Size:";
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.Green;
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(362, 7);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 55);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmTaSysFont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 72);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCateFont);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtMiFont);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmTaSysFont";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTaFont";
            this.Load += new System.EventHandler(this.FrmTaSysFont_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMiFont.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCateFont.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMiFont;
        private DevExpress.XtraEditors.TextEdit txtCateFont;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}