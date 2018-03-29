namespace SuperPOS.UI.TA
{
    partial class FrmTaChangeOrderType
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
            this.btnCollection = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelivery = new DevExpress.XtraEditors.SimpleButton();
            this.btnShop = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCollection);
            this.panelControl1.Controls.Add(this.btnDelivery);
            this.panelControl1.Controls.Add(this.btnShop);
            this.panelControl1.Location = new System.Drawing.Point(4, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(181, 193);
            this.panelControl1.TabIndex = 1;
            // 
            // btnCollection
            // 
            this.btnCollection.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCollection.Appearance.Options.UseFont = true;
            this.btnCollection.Location = new System.Drawing.Point(5, 131);
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Size = new System.Drawing.Size(171, 57);
            this.btnCollection.TabIndex = 2;
            this.btnCollection.Text = "COLLECTION";
            this.btnCollection.Click += new System.EventHandler(this.btnCollection_Click);
            // 
            // btnDelivery
            // 
            this.btnDelivery.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelivery.Appearance.Options.UseFont = true;
            this.btnDelivery.Location = new System.Drawing.Point(5, 68);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(171, 57);
            this.btnDelivery.TabIndex = 1;
            this.btnDelivery.Text = "DELIVERY";
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // btnShop
            // 
            this.btnShop.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShop.Appearance.Options.UseFont = true;
            this.btnShop.Location = new System.Drawing.Point(5, 5);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(171, 57);
            this.btnShop.TabIndex = 0;
            this.btnShop.Text = "SHOP";
            this.btnShop.Click += new System.EventHandler(this.btnShop_Click);
            // 
            // FrmTaChangeOrderType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 200);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaChangeOrderType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTaChangeOrderType";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCollection;
        private DevExpress.XtraEditors.SimpleButton btnDelivery;
        private DevExpress.XtraEditors.SimpleButton btnShop;
    }
}