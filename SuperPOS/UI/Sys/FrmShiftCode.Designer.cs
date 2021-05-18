namespace SuperPOS.UI.Sys
{
    partial class FrmShiftCode
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
            this.gcShiftCode = new DevExpress.XtraGrid.GridControl();
            this.gvShiftCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ShiftCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShiftName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OtherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DtFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DtEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsSpecial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SpecialContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcShiftCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShiftCode)).BeginInit();
            this.SuspendLayout();
            // 
            // gcShiftCode
            // 
            this.gcShiftCode.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcShiftCode.Location = new System.Drawing.Point(11, 10);
            this.gcShiftCode.MainView = this.gvShiftCode;
            this.gcShiftCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcShiftCode.Name = "gcShiftCode";
            this.gcShiftCode.Size = new System.Drawing.Size(825, 460);
            this.gcShiftCode.TabIndex = 0;
            this.gcShiftCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvShiftCode});
            this.gcShiftCode.DoubleClick += new System.EventHandler(this.gcShiftCode_DoubleClick);
            // 
            // gvShiftCode
            // 
            this.gvShiftCode.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gvShiftCode.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvShiftCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ShiftCode,
            this.ShiftName,
            this.OtherName,
            this.DtFrom,
            this.DtEnd,
            this.IsSpecial,
            this.SpecialContent,
            this.ID});
            this.gvShiftCode.DetailHeight = 272;
            this.gvShiftCode.GridControl = this.gcShiftCode;
            this.gvShiftCode.IndicatorWidth = 44;
            this.gvShiftCode.Name = "gvShiftCode";
            this.gvShiftCode.OptionsBehavior.Editable = false;
            this.gvShiftCode.OptionsMenu.EnableColumnMenu = false;
            this.gvShiftCode.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvShiftCode.OptionsView.EnableAppearanceEvenRow = true;
            this.gvShiftCode.OptionsView.EnableAppearanceOddRow = true;
            this.gvShiftCode.OptionsView.ShowGroupPanel = false;
            this.gvShiftCode.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvShiftCode_CustomDrawRowIndicator);
            // 
            // ShiftCode
            // 
            this.ShiftCode.Caption = "Shift Code";
            this.ShiftCode.FieldName = "ShiftCode";
            this.ShiftCode.MinWidth = 17;
            this.ShiftCode.Name = "ShiftCode";
            this.ShiftCode.Visible = true;
            this.ShiftCode.VisibleIndex = 0;
            this.ShiftCode.Width = 66;
            // 
            // ShiftName
            // 
            this.ShiftName.Caption = "Shift Name";
            this.ShiftName.FieldName = "ShiftName";
            this.ShiftName.MinWidth = 17;
            this.ShiftName.Name = "ShiftName";
            this.ShiftName.Visible = true;
            this.ShiftName.VisibleIndex = 1;
            this.ShiftName.Width = 66;
            // 
            // OtherName
            // 
            this.OtherName.Caption = "Other Name";
            this.OtherName.FieldName = "OtherName";
            this.OtherName.MinWidth = 17;
            this.OtherName.Name = "OtherName";
            this.OtherName.Visible = true;
            this.OtherName.VisibleIndex = 2;
            this.OtherName.Width = 66;
            // 
            // DtFrom
            // 
            this.DtFrom.Caption = "Time From";
            this.DtFrom.FieldName = "DtFrom";
            this.DtFrom.MinWidth = 17;
            this.DtFrom.Name = "DtFrom";
            this.DtFrom.Visible = true;
            this.DtFrom.VisibleIndex = 3;
            this.DtFrom.Width = 66;
            // 
            // DtEnd
            // 
            this.DtEnd.Caption = "Time To";
            this.DtEnd.FieldName = "DtEnd";
            this.DtEnd.MinWidth = 17;
            this.DtEnd.Name = "DtEnd";
            this.DtEnd.Visible = true;
            this.DtEnd.VisibleIndex = 4;
            this.DtEnd.Width = 66;
            // 
            // IsSpecial
            // 
            this.IsSpecial.Caption = "Special Price";
            this.IsSpecial.FieldName = "IsSpecial";
            this.IsSpecial.MinWidth = 17;
            this.IsSpecial.Name = "IsSpecial";
            this.IsSpecial.Visible = true;
            this.IsSpecial.VisibleIndex = 5;
            this.IsSpecial.Width = 66;
            // 
            // SpecialContent
            // 
            this.SpecialContent.Caption = "Special Details";
            this.SpecialContent.FieldName = "SpecialContent";
            this.SpecialContent.MinWidth = 17;
            this.SpecialContent.Name = "SpecialContent";
            this.SpecialContent.Visible = true;
            this.SpecialContent.VisibleIndex = 6;
            this.SpecialContent.Width = 66;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.MinWidth = 17;
            this.ID.Name = "ID";
            this.ID.Width = 66;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Appearance.Options.UseForeColor = true;
            this.btnExit.Appearance.Options.UseTextOptions = true;
            this.btnExit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExit.Location = new System.Drawing.Point(842, 432);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 39);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmShiftCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 480);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.gcShiftCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmShiftCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmShiftCode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmShiftCode_Load);
            this.SizeChanged += new System.EventHandler(this.FrmShiftCode_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gcShiftCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShiftCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcShiftCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gvShiftCode;
        private DevExpress.XtraGrid.Columns.GridColumn ShiftCode;
        private DevExpress.XtraGrid.Columns.GridColumn ShiftName;
        private DevExpress.XtraGrid.Columns.GridColumn OtherName;
        private DevExpress.XtraGrid.Columns.GridColumn DtFrom;
        private DevExpress.XtraGrid.Columns.GridColumn DtEnd;
        private DevExpress.XtraGrid.Columns.GridColumn IsSpecial;
        private DevExpress.XtraGrid.Columns.GridColumn SpecialContent;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}