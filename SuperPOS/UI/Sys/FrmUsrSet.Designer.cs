namespace SuperPOS.UI.Sys
{
    partial class FrmUsrSet
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
            this.gcUsr = new DevExpress.XtraGrid.GridControl();
            this.gvUsrSet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UsrID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UsrName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UsrPwd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UsrAuthGrpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UsrAuthGrp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UsrAccID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.lueUsrAuthGrp = new DevExpress.XtraEditors.LookUpEdit();
            this.txtUsrName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtUsrPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcUsr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsrSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueUsrAuthGrp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsrName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsrPwd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcUsr
            // 
            this.gcUsr.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcUsr.Location = new System.Drawing.Point(3, 105);
            this.gcUsr.MainView = this.gvUsrSet;
            this.gcUsr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcUsr.Name = "gcUsr";
            this.gcUsr.Size = new System.Drawing.Size(569, 205);
            this.gcUsr.TabIndex = 0;
            this.gcUsr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUsrSet});
            // 
            // gvUsrSet
            // 
            this.gvUsrSet.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvUsrSet.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvUsrSet.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvUsrSet.Appearance.OddRow.Options.UseBackColor = true;
            this.gvUsrSet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.UsrID,
            this.UsrName,
            this.UsrPwd,
            this.CreateBy,
            this.CreateTime,
            this.UsrAuthGrpName,
            this.UsrAuthGrp,
            this.UsrAccID});
            this.gvUsrSet.DetailHeight = 272;
            this.gvUsrSet.GridControl = this.gcUsr;
            this.gvUsrSet.IndicatorWidth = 44;
            this.gvUsrSet.Name = "gvUsrSet";
            this.gvUsrSet.OptionsBehavior.Editable = false;
            this.gvUsrSet.OptionsMenu.EnableColumnMenu = false;
            this.gvUsrSet.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvUsrSet.OptionsView.EnableAppearanceEvenRow = true;
            this.gvUsrSet.OptionsView.EnableAppearanceOddRow = true;
            this.gvUsrSet.OptionsView.ShowGroupPanel = false;
            this.gvUsrSet.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvUsrSet_CustomDrawRowIndicator);
            this.gvUsrSet.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvUsrSet_FocusedRowChanged);
            // 
            // UsrID
            // 
            this.UsrID.Caption = "User ID";
            this.UsrID.FieldName = "ID";
            this.UsrID.MinWidth = 17;
            this.UsrID.Name = "UsrID";
            this.UsrID.Width = 66;
            // 
            // UsrName
            // 
            this.UsrName.Caption = "User Name";
            this.UsrName.FieldName = "UsrName";
            this.UsrName.MinWidth = 17;
            this.UsrName.Name = "UsrName";
            this.UsrName.Visible = true;
            this.UsrName.VisibleIndex = 0;
            this.UsrName.Width = 88;
            // 
            // UsrPwd
            // 
            this.UsrPwd.Caption = "User Password";
            this.UsrPwd.FieldName = "UsrPwd";
            this.UsrPwd.MinWidth = 17;
            this.UsrPwd.Name = "UsrPwd";
            this.UsrPwd.Visible = true;
            this.UsrPwd.VisibleIndex = 1;
            this.UsrPwd.Width = 100;
            // 
            // CreateBy
            // 
            this.CreateBy.Caption = "Create By";
            this.CreateBy.FieldName = "CreateBy";
            this.CreateBy.MinWidth = 17;
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.Visible = true;
            this.CreateBy.VisibleIndex = 3;
            this.CreateBy.Width = 102;
            // 
            // CreateTime
            // 
            this.CreateTime.Caption = "Create Time";
            this.CreateTime.FieldName = "CreateTime";
            this.CreateTime.MinWidth = 17;
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.Visible = true;
            this.CreateTime.VisibleIndex = 4;
            this.CreateTime.Width = 151;
            // 
            // UsrAuthGrpName
            // 
            this.UsrAuthGrpName.Caption = "User Authority Group";
            this.UsrAuthGrpName.FieldName = "UsrAuthGrpName";
            this.UsrAuthGrpName.MinWidth = 17;
            this.UsrAuthGrpName.Name = "UsrAuthGrpName";
            this.UsrAuthGrpName.Visible = true;
            this.UsrAuthGrpName.VisibleIndex = 2;
            this.UsrAuthGrpName.Width = 144;
            // 
            // UsrAuthGrp
            // 
            this.UsrAuthGrp.Caption = "UsrAuthGrp";
            this.UsrAuthGrp.FieldName = "UsrAuthGrpID";
            this.UsrAuthGrp.MinWidth = 17;
            this.UsrAuthGrp.Name = "UsrAuthGrp";
            this.UsrAuthGrp.Width = 66;
            // 
            // UsrAccID
            // 
            this.UsrAccID.Caption = "UsrAccID";
            this.UsrAccID.MinWidth = 17;
            this.UsrAccID.Name = "UsrAccID";
            this.UsrAccID.Width = 66;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 3);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(582, 339);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Controls.Add(this.gcUsr);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(580, 313);
            this.xtraTabPage1.Text = "User Setting";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExit);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.lueUsrAuthGrp);
            this.panelControl1.Controls.Add(this.txtUsrName);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtUsrPwd);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Location = new System.Drawing.Point(4, 2);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(568, 98);
            this.panelControl1.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Appearance.Options.UseForeColor = true;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExit.Location = new System.Drawing.Point(441, 11);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 76);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnAdd);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Location = new System.Drawing.Point(330, 4);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(80, 90);
            this.panelControl2.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 7);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 18);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(8, 38);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 18);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(8, 68);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 18);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lueUsrAuthGrp
            // 
            this.lueUsrAuthGrp.Location = new System.Drawing.Point(134, 70);
            this.lueUsrAuthGrp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lueUsrAuthGrp.Name = "lueUsrAuthGrp";
            this.lueUsrAuthGrp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueUsrAuthGrp.Properties.NullText = "[Please select...]";
            this.lueUsrAuthGrp.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.lueUsrAuthGrp.Size = new System.Drawing.Size(150, 20);
            this.lueUsrAuthGrp.TabIndex = 6;
            this.lueUsrAuthGrp.Visible = false;
            // 
            // txtUsrName
            // 
            this.txtUsrName.Location = new System.Drawing.Point(134, 4);
            this.txtUsrName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsrName.Name = "txtUsrName";
            this.txtUsrName.Size = new System.Drawing.Size(150, 20);
            this.txtUsrName.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(3, 73);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(120, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "User Authority Group:";
            this.labelControl3.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(58, 9);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "User Name:";
            // 
            // txtUsrPwd
            // 
            this.txtUsrPwd.Location = new System.Drawing.Point(134, 35);
            this.txtUsrPwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsrPwd.Name = "txtUsrPwd";
            this.txtUsrPwd.Size = new System.Drawing.Size(150, 20);
            this.txtUsrPwd.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(38, 40);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(83, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "User Password:";
            // 
            // FrmUsrSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 341);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUsrSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Setting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmUsrSet_Load);
            this.SizeChanged += new System.EventHandler(this.FrmUsrSet_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gcUsr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsrSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueUsrAuthGrp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsrName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsrPwd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcUsr;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUsrSet;
        private DevExpress.XtraGrid.Columns.GridColumn UsrID;
        private DevExpress.XtraGrid.Columns.GridColumn UsrName;
        private DevExpress.XtraGrid.Columns.GridColumn UsrPwd;
        private DevExpress.XtraGrid.Columns.GridColumn CreateBy;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn UsrAuthGrpName;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtUsrName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueUsrAuthGrp;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtUsrPwd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn UsrAuthGrp;
        private DevExpress.XtraGrid.Columns.GridColumn UsrAccID;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}