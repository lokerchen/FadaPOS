namespace SuperPOS.UI.Sys
{
    partial class FrmKeyPadSet
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlKeypad = new DevExpress.XtraGrid.GridControl();
            this.gvKeypad = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KeyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KeyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtKeyName = new DevExpress.XtraEditors.TextEdit();
            this.txtKeyCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKeypad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKeypad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlKeypad);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(449, 513);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtKeyCode);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.txtKeyName);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(5, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(436, 56);
            this.panelControl2.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnDel);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Location = new System.Drawing.Point(5, 67);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(436, 48);
            this.panelControl3.TabIndex = 1;
            // 
            // gridControlKeypad
            // 
            this.gridControlKeypad.Location = new System.Drawing.Point(5, 121);
            this.gridControlKeypad.MainView = this.gvKeypad;
            this.gridControlKeypad.Name = "gridControlKeypad";
            this.gridControlKeypad.Size = new System.Drawing.Size(436, 387);
            this.gridControlKeypad.TabIndex = 2;
            this.gridControlKeypad.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvKeypad});
            // 
            // gvKeypad
            // 
            this.gvKeypad.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvKeypad.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvKeypad.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvKeypad.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvKeypad.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.KeyName,
            this.KeyCode});
            this.gvKeypad.GridControl = this.gridControlKeypad;
            this.gvKeypad.IndicatorWidth = 50;
            this.gvKeypad.Name = "gvKeypad";
            this.gvKeypad.OptionsBehavior.Editable = false;
            this.gvKeypad.OptionsMenu.EnableColumnMenu = false;
            this.gvKeypad.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvKeypad.OptionsView.EnableAppearanceEvenRow = true;
            this.gvKeypad.OptionsView.EnableAppearanceOddRow = true;
            this.gvKeypad.OptionsView.ShowGroupPanel = false;
            this.gvKeypad.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvKeypad_CustomDrawRowIndicator);
            this.gvKeypad.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvKeypad_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // KeyName
            // 
            this.KeyName.Caption = "Key Name";
            this.KeyName.FieldName = "KeyName";
            this.KeyName.Name = "KeyName";
            this.KeyName.Visible = true;
            this.KeyName.VisibleIndex = 0;
            // 
            // KeyCode
            // 
            this.KeyCode.Caption = "Key Code";
            this.KeyCode.FieldName = "KeyCode";
            this.KeyCode.Name = "KeyCode";
            this.KeyCode.Visible = true;
            this.KeyCode.VisibleIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(98, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Keypad Name:";
            // 
            // txtKeyName
            // 
            this.txtKeyName.Location = new System.Drawing.Point(111, 18);
            this.txtKeyName.Name = "txtKeyName";
            this.txtKeyName.Size = new System.Drawing.Size(100, 24);
            this.txtKeyName.TabIndex = 1;
            // 
            // txtKeyCode
            // 
            this.txtKeyCode.Location = new System.Drawing.Point(330, 15);
            this.txtKeyCode.Name = "txtKeyCode";
            this.txtKeyCode.Size = new System.Drawing.Size(100, 24);
            this.txtKeyCode.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(232, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(92, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Keypad Code:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(31, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(171, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(311, 14);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(95, 25);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // FrmKeyPadSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 513);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmKeyPadSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmKeyPadSet";
            this.Load += new System.EventHandler(this.FrmKeyPadSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKeypad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKeypad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlKeypad;
        private DevExpress.XtraGrid.Views.Grid.GridView gvKeypad;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn KeyName;
        private DevExpress.XtraGrid.Columns.GridColumn KeyCode;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.TextEdit txtKeyCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtKeyName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}