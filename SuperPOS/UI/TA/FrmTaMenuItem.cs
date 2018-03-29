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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;
using SuperPOS.UI.Sys;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaMenuItem : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";
        //新增/更新
        private bool isAdd = false;

        private readonly EntityControl _control = new EntityControl();

        private string[] arrayMenuCate;

        public FrmTaMenuItem()
        {
            InitializeComponent();
        }

        public FrmTaMenuItem(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        private void FrmTaMenuItem_Load(object sender, EventArgs e)
        {
            BindData();
        }

        #region 绑定chkWorkDay
        /// <summary>
        /// 绑定chkWorkDay
        /// </summary>
        private void BindChkWorkDay(bool isClear)
        {
            if (isClear) chkComboWorkDay.Properties.Items.Clear();
            chkComboWorkDay.Properties.Items.AddRange(PubComm.WORD_DAY);
        }
        #endregion

        #region 绑定chkMenuCate
        /// <summary>
        /// 绑定chkMenuCate
        /// </summary>
        private void BindChkMenuCate(bool isClear)
        {
            if (isClear) chkComboMenuCate.Properties.Items.Clear();

            new SystemData().GetTaMenuCate();

            var lstMenuCate = from mc in CommonData.TaMenuCate
                              select new
                              {
                                  McID = mc.ID,
                                  McName = mc.CateEngName
                              };

            chkComboMenuCate.Properties.DataSource = lstMenuCate.ToList();
            chkComboMenuCate.Properties.ValueMember = "McID";
            chkComboMenuCate.Properties.DisplayMember = "McName";

            chkComboMenuCate.RefreshEditValue();
        }
        #endregion

        #region 绑定Grid
        /// <summary>
        /// 绑定Grid
        /// </summary>
        private void BindGridData()
        {
            new SystemData().GetTaMenuItem();

            var lstMenuItem = from mi in CommonData.TaMenuItem
                join sc in CommonData.TaShiftCodeList on mi.MiSuppleShiftID equals sc.ID
                join prt in CommonData.SysPrt on mi.MiPrintID equals prt.ID
                join ms in CommonData.TaMenuSet on mi.MiMenuSetID equals ms.ID
                join dc in CommonData.TaDeptCode on mi.MiDeptCodeID equals dc.ID
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
                    MiSuppleShift = sc.ShiftName,
                    MiPrintID = mi.MiPrintID,
                    MiPrint = prt.PrtName,
                    MiDeptCodeID = mi.MiDeptCodeID,
                    MiDeptCode = dc.DeptEngName,
                    MiWorkDay = mi.MiWorkDay,
                    MiMenuCateID = mi.MiMenuCateID,
                    MiRmk = mi.MiRmk,
                    MiMenuSetID = mi.MiMenuSetID,
                    MiMenuSet = ms.MSEngName
                };
            
            gvMenuItem.BestFitColumns();
            gridControlMenuItem.DataSource = lstMenuItem.ToList();
            gvMenuItem.FocusedRowHandle = gvMenuItem.RowCount - 1;
        }
        #endregion

        #region 绑定Supply Shift
        /// <summary>
        /// 绑定Supply Shift
        /// </summary>
        private void BindLueSupplyShift()
        {
            new SystemData().GetTaShiftCodeList();

            var lstShiftCode = from sc in CommonData.TaShiftCodeList
                select new
                {
                    ScID = sc.ID,
                    ScName = sc.ShiftName
                };
            lueSuppleShift.Properties.DataSource = lstShiftCode.ToList();
            lueSuppleShift.Properties.DisplayMember = "ScName";
            lueSuppleShift.Properties.ValueMember = "ScID";
        }
        #endregion

        #region 绑定Print Name
        /// <summary>
        /// 绑定Print Name
        /// </summary>
        private void BindLuePrtName()
        {
            new SystemData().GetSysPrtList();

            var lstPrt = from prt in CommonData.SysPrt
                         select new
                         {
                             PrtID = prt.ID,
                             PrtName = prt.PrtName
                         };
            luePrtName.Properties.DataSource = lstPrt.ToList();
            luePrtName.Properties.DisplayMember = "PrtName";
            luePrtName.Properties.ValueMember = "PrtID";
        }
        #endregion

        #region 绑定Print Order
        /// <summary>
        /// 绑定Print Order
        /// </summary>
        private void BindLuePrtOrder()
        {
            new SystemData().GetTaDeptCode();

            var lstDeptCode = from dc in CommonData.TaDeptCode
                              select new
                              {
                                  DcID = dc.ID,
                                  DcName = dc.DeptEngName
                              };
            luePrtOrder.Properties.DataSource = lstDeptCode.ToList();
            luePrtOrder.Properties.DisplayMember = "DcName";
            luePrtOrder.Properties.ValueMember = "DcID";
        }
        #endregion

        #region 绑定MenuSet

        private void BinLueMenuSet()
        {
            new SystemData().GetTaMenuSet();

            var lstMenuSet = from ms in CommonData.TaMenuSet
                select new
                {
                    MsID = ms.ID,
                    MsName = ms.MSEngName
                };
            lueMenuSet.Properties.DataSource = lstMenuSet.ToList();
            lueMenuSet.Properties.DisplayMember = "MsName";
            lueMenuSet.Properties.ValueMember = "MsID";
        }
        #endregion

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            BindChkMenuCate(false);
            BindChkWorkDay(false);
            BindChkComboOtherSet(false);

            BindLuePrtName();
            BindLuePrtOrder();
            BindLueSupplyShift();
            BinLueMenuSet();

            BindGridData();
        }
        #endregion

        #region 绑定chkComboOtherSet
        /// <summary>
        /// 绑定chkComboOtherSet
        /// </summary>
        private void BindChkComboOtherSet(bool isClear)
        {
            if (isClear) chkComboOtherSet.Properties.Items.Clear();

            chkComboOtherSet.Properties.Items.AddRange(PubComm.MENUITEM_OTHER_SET);
        }
        #endregion

        #region Add按钮事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtDishCode.Text = "";
            txtDispPosition.Text = "";
            txtEngName.Text = "";
            txtOtherName.Text = "";
            txtRegularPrice.Text = "";
            txtSpecailRegularPrice.Text = "";
            lueSuppleShift.ItemIndex = 0;
            luePrtName.ItemIndex = 0;
            luePrtOrder.ItemIndex = 0;
            lueMenuSet.ItemIndex = 0;

            BindChkMenuCate(true);
            BindChkWorkDay(true);
            BindChkComboOtherSet(true);
        }
        #endregion

        #region Save按钮事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 判断空值
            if (string.IsNullOrEmpty(txtDishCode.Text))
            {
                CommonTool.ShowMessage("Dish Code is empty,please enter!");
                return;
            }

            if (string.IsNullOrEmpty(txtDispPosition.Text))
            {
                CommonTool.ShowMessage("Display Position is empty,please enter!");
                return;
            }

            if (string.IsNullOrEmpty(txtEngName.Text))
            {
                CommonTool.ShowMessage("English Name is empty,please enter!");
                return;
            }

            if (string.IsNullOrEmpty(txtOtherName.Text))
            {
                CommonTool.ShowMessage("Other Name is empty,please enter!");
                return;
            }

            if (string.IsNullOrEmpty(txtRegularPrice.Text))
            {
                CommonTool.ShowMessage("Regular Price is empty,please enter!");
                return;
            }

            if (string.IsNullOrEmpty(txtSpecailRegularPrice.Text))
            {
                CommonTool.ShowMessage("Specail Regular Price is empty,please enter!");
                return;
            }
            #endregion
            new SystemData().GetTaMenuItem();

            TaMenuItemInfo taMenuItemInfo = new TaMenuItemInfo();
            taMenuItemInfo.MiDishCode = txtDishCode.Text;
            taMenuItemInfo.MiPosition = txtDispPosition.Text;
            taMenuItemInfo.MiEngName = txtEngName.Text;
            taMenuItemInfo.MiOtherName = txtOtherName.Text;
            taMenuItemInfo.MiRegularPrice = txtRegularPrice.Text;
            taMenuItemInfo.MiSpecialPrice = txtSpecailRegularPrice.Text;
            taMenuItemInfo.MiMenuSetID = Convert.ToInt32(lueMenuSet.EditValue);
            taMenuItemInfo.MiSuppleShiftID = Convert.ToInt32(lueSuppleShift.EditValue);
            taMenuItemInfo.MiPrintID = Convert.ToInt32(luePrtName.EditValue);
            taMenuItemInfo.MiDeptCodeID = Convert.ToInt32(luePrtOrder.EditValue);
            taMenuItemInfo.MiWorkDay = chkComboWorkDay.EditValue.ToString();
            taMenuItemInfo.MiMenuCateID = chkComboMenuCate.EditValue.ToString();
            taMenuItemInfo.MiRmk = chkComboOtherSet.EditValue.ToString();

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taMenuItemInfo);
                    isAdd = false;
                }
                else
                {
                    taMenuItemInfo.ID = Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taMenuItemInfo);
                }

                //BindData();
                BindGridData();
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.Name, ex);
            }

            CommonTool.ShowMessage("Save successful!");
        }
        #endregion

        #region Del按钮事件
        private void btnDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaMenuItem();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaMenuItem.FirstOrDefault(s => s.ID == Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "ID"))));
                }
                catch (Exception ex)
                {
                    LogHelper.Error(this.Name, ex);
                }
            }
        }
        #endregion

        private void gvMenuItem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvMenuItem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtDishCode.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiDishCode").ToString();
            txtDispPosition.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiPosition").ToString();
            txtEngName.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiEngName").ToString();
            txtOtherName.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiOtherName").ToString();
            txtRegularPrice.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiRegularPrice").ToString();
            txtSpecailRegularPrice.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiSpecialPrice").ToString();
            lueMenuSet.EditValue = Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiMenuSetID"));
            lueMenuSet.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiMenuSet").ToString();
            lueSuppleShift.EditValue = Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiSuppleShiftID"));
            lueSuppleShift.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiSuppleShift").ToString();
            luePrtName.EditValue = Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiPrintID"));
            luePrtName.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiPrint").ToString();
            luePrtOrder.EditValue = Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiDeptCodeID"));
            luePrtOrder.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiDeptCode").ToString();
            chkComboWorkDay.EditValue = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiWorkDay");
            chkComboWorkDay.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiWorkDay").ToString();
            chkComboMenuCate.EditValue = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiMenuCateID").ToString();
            chkComboMenuCate.SetEditValue(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiMenuCateID").ToString());
            chkComboOtherSet.EditValue = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiRmk");
            chkComboOtherSet.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiRmk").ToString();
        }

        #region Grid单元格双击事件
        private void gvMenuItem_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs arg = e as MouseEventArgs;

            if (arg == null) return;

            //获取鼠标坐标
            GridHitInfo hitInfo = gvMenuItem.CalcHitInfo(new Point(arg.X, arg.Y));

            if (hitInfo.RowHandle >= 0)
            {
                //FrmShiftCodeDetail frmShiftCodeDetail = new FrmShiftCodeDetail(Convert.ToInt32(gvShiftCode.GetRowCellValue(gvShiftCode.FocusedRowHandle, "ID")));
                //frmShiftCodeDetail.ShowDialog();

                FrmTaMenuItemDetail frmTaMenuItemDetail = new FrmTaMenuItemDetail(Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "ID")));
                frmTaMenuItemDetail.ShowDialog();

                BindGridData();
            }
        }
        #endregion
    }
}