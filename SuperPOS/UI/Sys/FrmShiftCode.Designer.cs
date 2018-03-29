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
            ((System.ComponentModel.ISupportInitialize)(this.gcShiftCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShiftCode)).BeginInit();
            this.SuspendLayout();
            // 
            // gcShiftCode
            // 
            this.gcShiftCode.Location = new System.Drawing.Point(13, 13);
            this.gcShiftCode.MainView = this.gvShiftCode;
            this.gcShiftCode.Name = "gcShiftCode";
            this.gcShiftCode.Size = new System.Drawing.Size(943, 592);
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
            this.gvShiftCode.GridControl = this.gcShiftCode;
            this.gvShiftCode.IndicatorWidth = 50;
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
            this.ShiftCode.Name = "ShiftCode";
            this.ShiftCode.Visible = true;
            this.ShiftCode.VisibleIndex = 0;
            // 
            // ShiftName
            // 
            this.ShiftName.Caption = "Shift Name";
            this.ShiftName.FieldName = "ShiftName";
            this.ShiftName.Name = "ShiftName";
            this.ShiftName.Visible = true;
            this.ShiftName.VisibleIndex = 1;
            // 
            // OtherName
            // 
            this.OtherName.Caption = "Other Name";
            this.OtherName.FieldName = "OtherName";
            this.OtherName.Name = "OtherName";
            this.OtherName.Visible = true;
            this.OtherName.VisibleIndex = 2;
            // 
            // DtFrom
            // 
            this.DtFrom.Caption = "Time From";
            this.DtFrom.FieldName = "DtFrom";
            this.DtFrom.Name = "DtFrom";
            this.DtFrom.Visible = true;
            this.DtFrom.VisibleIndex = 3;
            // 
            // DtEnd
            // 
            this.DtEnd.Caption = "Time To";
            this.DtEnd.FieldName = "DtEnd";
            this.DtEnd.Name = "DtEnd";
            this.DtEnd.Visible = true;
            this.DtEnd.VisibleIndex = 4;
            // 
            // IsSpecial
            // 
            this.IsSpecial.Caption = "Special Price";
            this.IsSpecial.FieldName = "IsSpecial";
            this.IsSpecial.Name = "IsSpecial";
            this.IsSpecial.Visible = true;
            this.IsSpecial.VisibleIndex = 5;
            // 
            // SpecialContent
            // 
            this.SpecialContent.Caption = "Special Details";
            this.SpecialContent.FieldName = "SpecialContent";
            this.SpecialContent.Name = "SpecialContent";
            this.SpecialContent.Visible = true;
            this.SpecialContent.VisibleIndex = 6;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // FrmShiftCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 617);
            this.Controls.Add(this.gcShiftCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmShiftCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmShiftCode";
            this.Load += new System.EventHandler(this.FrmShiftCode_Load);
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
    }
}