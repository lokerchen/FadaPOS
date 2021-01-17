using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaMenuItemCopyChoices : DevExpress.XtraEditors.XtraForm
    {
        //源MenuItem ID
        private int miID = 1;

        //Menu Set ID
        private int msID = 0;

        //目标MenuItem ID
        private int saveMiID = 1;

        //Type
        private int miOtherType = 2;

        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmTaMenuItemCopyChoices()
        {
            InitializeComponent();
        }

        public FrmTaMenuItemCopyChoices(int menuSetID, int menuItemID, int miOtherChoiceType)
        {
            InitializeComponent();
            msID = menuSetID;
            miID = menuItemID;
            miOtherType = miOtherChoiceType;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaMenuItemOtherChoice();

            var lstMiOther = CommonData.TaMenuItemOtherChoice.Where(s => s.MiID == miID && s.MiType == miOtherType);

            foreach (var taMiOther in lstMiOther)
            {
                try
                {
                    TaMenuItemOtherChoiceInfo taMenuItemOtherChoiceInfo = new TaMenuItemOtherChoiceInfo();

                    taMenuItemOtherChoiceInfo.MiEngName = taMiOther.MiEngName;
                    taMenuItemOtherChoiceInfo.MiOtherName = taMiOther.MiOtherName;
                    taMenuItemOtherChoiceInfo.MiPrice = taMiOther.MiPrice;
                    taMenuItemOtherChoiceInfo.IsAutoAppend = taMiOther.IsAutoAppend;
                    taMenuItemOtherChoiceInfo.IsEnableChoice = taMiOther.IsEnableChoice;
                    taMenuItemOtherChoiceInfo.MiType = miOtherType;
                    taMenuItemOtherChoiceInfo.OptionNum = taMiOther.OptionNum;

                    int[] iSelectRows = gvMenuItem.GetSelectedRows();

                    foreach (int rows in iSelectRows)
                    {
                        taMenuItemOtherChoiceInfo.MiID = Convert.ToInt32(gvMenuItem.GetRowCellValue(rows, "ID"));
                        _control.AddEntity(taMenuItemOtherChoiceInfo);
                    }
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }

            CommonTool.ShowMessage("Save successful!");

            this.DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void gvMenuItem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiDishCode") != null)
            //    saveMiID = Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "ID"));
        }

        private void gvMenuItem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        #region 绑定Grid
        /// <summary>
        /// 绑定Grid
        /// </summary>
        private void BindGridData(int menuSetID)
        {
            new SystemData().GetTaMenuItem();

            var lstMenuItem = from mi in CommonData.TaMenuItem
                                  //join sc in CommonData.TaShiftCodeList on mi.MiSuppleShiftID equals sc.ID
                              join prt in CommonData.SysPrt on mi.MiPrintID equals prt.ID
                              join ms in CommonData.TaMenuSet on mi.MiMenuSetID equals ms.ID
                              //join dc in CommonData.TaDeptCode on mi.MiDeptCodeID equals dc.ID
                              select new
                              {
                                  ID = mi.ID,
                                  MiDishCode = mi.MiDishCode,
                                  MiPosition = mi.MiPosition,
                                  MiEngName = mi.MiEngName,
                                  MiOtherName = mi.MiOtherName,
                                  MiRegularPrice = mi.MiRegularPrice,
                                  MiSpecialPrice = mi.MiSpecialPrice,
                                  MiSuppleShiftID = mi.MiSuppleShiftID,
                                  //MiSuppleShift = sc.ShiftName,
                                  MiPrintID = mi.MiPrintID,
                                  MiPrint = prt.PrtName,
                                  MiDeptCodeID = mi.MiDeptCodeID,
                                  //MiDeptCode = dc.DeptEngName,
                                  MiWorkDay = mi.MiWorkDay,
                                  MiMenuCateID = mi.MiMenuCateID,
                                  MiRmk = mi.MiRmk,
                                  MiMenuSetID = mi.MiMenuSetID,
                                  MiMenuSet = ms.MSEngName,
                                  MiLargePrice = mi.MiLargePrice,
                                  MiSmallPrice = mi.MiSmallPrice,
                                  MiBtnColor = mi.MiBtnColor
                              };

            gvMenuItem.BestFitColumns();

            if (msID > 0)
                gridControlMenuItem.DataSource = menuSetID >= 0
                            ? lstMenuItem.Where(s => s.MiMenuSetID == menuSetID && s.ID != miID).ToList()
                            : lstMenuItem.ToList();

            gvMenuItem.FocusedRowHandle = gvMenuItem.RowCount - 1;
        }
        #endregion

        private void FrmTaMenuItemCopyChoices_Load(object sender, EventArgs e)
        {
            BindGridData(msID);

            asfc.controllInitializeSize(this);
        }

        private void FrmTaMenuItemCopyChoices_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}