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
using SuperPOS.UI.TaAdmin;

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

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private string[] arrayMenuCate;

        private CheckEdit[] chk = new CheckEdit[3];

        private int[] MenuSetKey = new int[4];

        private int iMenuSetKey = 1;

        private int miID = 1;

        private int miType = 2;

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
            #region btnMenuSet赋值
            Button[] btnMenuSet = new Button[4];
            btnMenuSet[0] = btnMenuSet1;
            btnMenuSet[1] = btnMenuSet2;
            btnMenuSet[2] = btnMenuSet3;
            btnMenuSet[3] = btnMenuSet4;

            btnMenuSet1.Click += BtnMenuSet_Click;
            btnMenuSet2.Click += BtnMenuSet_Click;
            btnMenuSet3.Click += BtnMenuSet_Click;
            btnMenuSet4.Click += BtnMenuSet_Click;

            new SystemData().GetTaMenuSet();
            int i = 0;
            foreach (var taMenuSet in CommonData.TaMenuSet)
            {
                if (i >= 4) break;

                btnMenuSet[i].Text = taMenuSet.MSEngName;
                MenuSetKey[i] = taMenuSet.ID;

                if (i == 0) iMenuSetKey = MenuSetKey[i];
                i++;
            }

            iMenuSetKey = i >= 0 ? MenuSetKey[0] : 1;

            for (int j = i; j < 4; j++)
            {
                btnMenuSet[j].Visible = false;
            }
            #endregion

            BindData();

            btnMenuSet1.BackColor = Color.CornflowerBlue;
            btnMenuSet1.Select();
            btnMenuSet2.BackColor = Color.Gray;
            btnMenuSet3.BackColor = Color.Gray;
            btnMenuSet4.BackColor = Color.Gray;

            asfc.controllInitializeSize(this);
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
        private void BindGridData(int menuSetID, string strDishCode)
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

            if (string.IsNullOrEmpty(strDishCode))
            {
                gridControlMenuItem.DataSource = menuSetID >= 0
                    ? lstMenuItem.Where(s => s.MiMenuSetID == menuSetID).ToList()
                    : lstMenuItem.ToList();
            }
            else
            {
                gridControlMenuItem.DataSource = menuSetID >= 0
                    ? lstMenuItem.Where(s => s.MiMenuSetID == menuSetID && s.MiDishCode.ToString().Contains(strDishCode)).ToList()
                    : lstMenuItem.ToList();
            }

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
            //BindChkWorkDay(false);
            //BindChkComboOtherSet(false);

            BindLuePrtName();
            //BindLuePrtOrder();
            //BindLueSupplyShift();
            //BinLueMenuSet();

            BindGridData(iMenuSetKey, "");
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
            txtLargePrice.Text = "";
            txtSmallPrice.Text = "";
            txtSpecailRegularPrice.Text = "";
            lueSuppleShift.ItemIndex = 0;
            luePrtName.ItemIndex = 0;
            luePrtOrder.ItemIndex = 0;
            lueMenuSet.ItemIndex = 0;

            BindChkMenuCate(true);
            //BindChkWorkDay(true);
            //BindChkComboOtherSet(true);
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

            //if (string.IsNullOrEmpty(txtSpecailRegularPrice.Text))
            //{
            //    CommonTool.ShowMessage("Specail Regular Price is empty,please enter!");
            //    return;
            //}

            if (string.IsNullOrEmpty(txtLargePrice.Text)) { txtLargePrice.Text = @"0.00"; }
            if (string.IsNullOrEmpty(txtSmallPrice.Text)) { txtSmallPrice.Text = @"0.00"; }
            #endregion
            new SystemData().GetTaMenuItem();

            TaMenuItemInfo taMenuItemInfo = new TaMenuItemInfo();
            taMenuItemInfo.MiDishCode = txtDishCode.Text;
            taMenuItemInfo.MiPosition = txtDispPosition.Text;
            taMenuItemInfo.MiEngName = txtEngName.Text;
            taMenuItemInfo.MiOtherName = txtOtherName.Text;
            taMenuItemInfo.MiRegularPrice = txtRegularPrice.Text;
            taMenuItemInfo.MiLargePrice = txtLargePrice.Text;
            taMenuItemInfo.MiSmallPrice = txtSmallPrice.Text;
            taMenuItemInfo.MiSpecialPrice = txtSpecailRegularPrice.Text;
            taMenuItemInfo.MiMenuSetID = iMenuSetKey;
            //taMenuItemInfo.MiSuppleShiftID = Convert.ToInt32(lueSuppleShift.EditValue);
            taMenuItemInfo.MiPrintID = Convert.ToInt32(luePrtName.EditValue);
            //taMenuItemInfo.MiDeptCodeID = Convert.ToInt32(luePrtOrder.EditValue);
            //taMenuItemInfo.MiWorkDay = chkComboWorkDay.EditValue.ToString();
            taMenuItemInfo.MiMenuCateID = chkComboMenuCate.EditValue.ToString();
            string strTmp = "";
            if (chk1.Checked) strTmp += ",Without VAT";
            if (chk2.Checked) strTmp += ",Set Meal";
            if (chk3.Checked) strTmp += ",Discountable";
            taMenuItemInfo.MiRmk = strTmp;

            taMenuItemInfo.MiBtnColor = colorEditBtn.Text;

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
                BindGridData(iMenuSetKey, "");
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
            if (gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiDishCode") != null) miID = Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "ID"));
            txtDishCode.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiDishCode") == null ? "" : gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiDishCode").ToString();
            txtDispPosition.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiPosition") == null ? "" : gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiPosition").ToString();
            txtEngName.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiEngName") == null ? "" : gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiEngName").ToString();
            txtOtherName.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiOtherName") == null ? "" : gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiOtherName").ToString();
            txtRegularPrice.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiRegularPrice").ToString();
            //txtSpecailRegularPrice.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiSpecialPrice").ToString();
            //lueMenuSet.EditValue = Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiMenuSetID"));
            //lueMenuSet.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiMenuSet").ToString();
            //lueSuppleShift.EditValue = Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiSuppleShiftID"));
            //lueSuppleShift.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiSuppleShift").ToString();
            luePrtName.EditValue = Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiPrintID"));
            luePrtName.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiPrint") == null ? "" : gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiPrint").ToString();
            //luePrtOrder.EditValue = Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiDeptCodeID"));
            //luePrtOrder.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiDeptCode").ToString();
            //chkComboWorkDay.EditValue = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiWorkDay");
            //chkComboWorkDay.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiWorkDay").ToString();
            chkComboMenuCate.EditValue = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiMenuCateID") == null ? "" : gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiMenuCateID").ToString();
            chkComboMenuCate.SetEditValue(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiMenuCateID") == null ? "" : gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiMenuCateID").ToString());
            //chkComboOtherSet.EditValue = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiRmk");
            string strRmk = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiRmk") == null ? "" : gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiRmk").ToString();
            chk1.Checked = false;
            chk2.Checked = false;
            chk3.Checked = false;
            if (strRmk.Contains("Without VAT")) chk1.Checked = true;
            if (strRmk.Contains("Set Meal")) chk1.Checked = true;
            if (strRmk.Contains("Discountable")) chk3.Checked = true;
            
            txtLargePrice.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiLargePrice") == null ? "" : gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiLargePrice").ToString();
            txtSmallPrice.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiSmallPrice") == null ? "" : gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiSmallPrice").ToString();

            colorEditBtn.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiBtnColor") == null ? @"Gold" : gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiBtnColor").ToString();
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

                BindGridData(iMenuSetKey, "");
            }
        }
        #endregion

        private void FrmTaMenuItem_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMenuSet_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btnMenuSet1":
                    iMenuSetKey = MenuSetKey[0];
                    btn.BackColor = Color.CornflowerBlue;
                    btnMenuSet2.BackColor = Color.Gray;
                    btnMenuSet3.BackColor = Color.Gray;
                    btnMenuSet4.BackColor = Color.Gray;
                    break;
                case "btnMenuSet2":
                    iMenuSetKey = MenuSetKey[1];
                    btnMenuSet1.BackColor = Color.Gray;
                    btn.BackColor = Color.CornflowerBlue;
                    btnMenuSet3.BackColor = Color.Gray;
                    btnMenuSet4.BackColor = Color.Gray;
                    break;
                case "btnMenuSet3":
                    iMenuSetKey = MenuSetKey[2];
                    btnMenuSet1.BackColor = Color.Gray;
                    btnMenuSet2.BackColor = Color.Gray;
                    btn.BackColor = Color.CornflowerBlue;
                    btnMenuSet4.BackColor = Color.Gray;
                    break;
                case "btnMenuSet4":
                    iMenuSetKey = MenuSetKey[3];
                    btnMenuSet1.BackColor = Color.Gray;
                    btnMenuSet2.BackColor = Color.Gray;
                    btnMenuSet3.BackColor = Color.Gray;
                    btn.BackColor = Color.CornflowerBlue;
                    break;
                default:
                    iMenuSetKey = MenuSetKey[0];
                    btnMenuSet1.BackColor = Color.CornflowerBlue;
                    btnMenuSet1.Select();
                    btnMenuSet2.BackColor = Color.Gray;
                    btnMenuSet3.BackColor = Color.Gray;
                    btnMenuSet4.BackColor = Color.Gray;
                    break;
            }

            BindGridData(iMenuSetKey, "");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridData(iMenuSetKey, txtSearchDishCode.Text);
        }

        private void BindOtherChoice(int iType, int miID)
        {
            new SystemData().GetTaMenuItemOtherChoice();

            var lstOtherChoice = CommonData.TaMenuItemOtherChoice.Where(s => s.MiType == iType && s.MiID == miID);

            gridControlSecondChoice.DataSource = lstOtherChoice.ToList();
            gvSecondChoice.FocusedRowHandle = gvSecondChoice.RowCount - 1;
            gridControlThirdChoice.DataSource = lstOtherChoice.ToList();
            gvThirdChoice.FocusedRowHandle = gvThirdChoice.RowCount - 1;
        }

        private void xtpUsrAccess_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {
            miType = SelectPage(e.Page.Name);

            BindOtherChoice(miType, miID);
        }

        #region 根据Tab Page判断MenuItem类型
        /// <summary>
        /// 根据Tab Page判断MenuItem类型
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        private int SelectPage(string pageName)
        {
            if (pageName.Equals("xtpSc")) return 2;
            else if (pageName.Equals("xtpTc")) return 3;
            else return 2;
        }
        #endregion

        private void btnScExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnScAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtScEngName.Text = "";
            txtScOtherName.Text = "";
            txtScAddPrice.Text = "";
            chkScAutoAppend.Checked = false;
            chkScEnableChoice.Checked = false;
            txtScNumOption.Text = "1";
        }

        private void gvSecondChoice_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvSecondChoice.RowCount > 0)
            {
                txtScEngName.Text = gvSecondChoice.GetRowCellValue(gvSecondChoice.FocusedRowHandle, "MiEngName").ToString();
                txtScOtherName.Text = gvSecondChoice.GetRowCellValue(gvSecondChoice.FocusedRowHandle, "MiOtherName").ToString();
                txtScAddPrice.Text = gvSecondChoice.GetRowCellValue(gvSecondChoice.FocusedRowHandle, "MiPrice").ToString();
                chkScAutoAppend.Checked = gvSecondChoice.GetRowCellValue(gvSecondChoice.FocusedRowHandle, "IsAutoAppend").ToString().Equals("Y");
                chkScEnableChoice.Checked = gvSecondChoice.GetRowCellValue(gvSecondChoice.FocusedRowHandle, "IsEnableChoice").ToString().Equals("Y");
                txtScNumOption.Text = gvSecondChoice.GetRowCellValue(gvSecondChoice.FocusedRowHandle, "OptionNum") == null ? "" : gvSecondChoice.GetRowCellValue(gvSecondChoice.FocusedRowHandle, "OptionNum").ToString();
            }
            else
            {
                txtScEngName.Text = "";
                txtScOtherName.Text = "";
                txtScAddPrice.Text = "";
                chkScAutoAppend.Checked = false;
                chkScEnableChoice.Checked = false;
                txtScNumOption.Text = "";
            }
        }

        private void btnScSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtScEngName.Text))
            {
                CommonTool.ShowMessage("English Name can not NULL!");
                return;
            }

            if (string.IsNullOrEmpty(txtScOtherName.Text))
            {
                CommonTool.ShowMessage("Other Name can not NULL!");
                return;
            }

            TaMenuItemOtherChoiceInfo taMenuItemOtherChoiceInfo = new TaMenuItemOtherChoiceInfo();

            taMenuItemOtherChoiceInfo.MiEngName = txtScEngName.Text;
            taMenuItemOtherChoiceInfo.MiOtherName = txtScOtherName.Text;
            taMenuItemOtherChoiceInfo.MiPrice = string.IsNullOrEmpty(txtScAddPrice.Text) ? "0.00" : txtScAddPrice.Text;
            taMenuItemOtherChoiceInfo.IsAutoAppend = chkScAutoAppend.Checked ? "Y" : "N";
            taMenuItemOtherChoiceInfo.IsEnableChoice = chkScEnableChoice.Checked ? "Y" : "N";
            taMenuItemOtherChoiceInfo.MiID = miID;
            taMenuItemOtherChoiceInfo.MiType = miType;
            taMenuItemOtherChoiceInfo.OptionNum = txtScNumOption.Text;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taMenuItemOtherChoiceInfo);
                    isAdd = false;
                }
                else
                {
                    taMenuItemOtherChoiceInfo.ID = Convert.ToInt32(gvSecondChoice.GetRowCellValue(gvSecondChoice.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taMenuItemOtherChoiceInfo);
                }

                BindOtherChoice(miType, miID);
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnScDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaMenuItemOtherChoice();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaMenuItemOtherChoice.FirstOrDefault(s => s.ID == Convert.ToInt32(gvSecondChoice.GetRowCellValue(gvSecondChoice.FocusedRowHandle, "ID"))));
                    CommonTool.ShowMessage("Delete successful!");
                    BindOtherChoice(miType, miID);
                    isAdd = false;
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }
        }

        private void btnTcAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtTcEngName.Text = "";
            txtTcOtherName.Text = "";
            txtTcAddPrice.Text = "";
            chkTcAutoAppend.Checked = false;
            chkTcEnableChoice.Checked = false;
            txtTcNumOption.Text = "1";
        }

        private void btnTcSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTcEngName.Text))
            {
                CommonTool.ShowMessage("English Name can not NULL!");
                return;
            }

            if (string.IsNullOrEmpty(txtTcOtherName.Text))
            {
                CommonTool.ShowMessage("Other Name can not NULL!");
                return;
            }

            TaMenuItemOtherChoiceInfo taMenuItemOtherChoiceInfo = new TaMenuItemOtherChoiceInfo();

            taMenuItemOtherChoiceInfo.MiEngName = txtTcEngName.Text;
            taMenuItemOtherChoiceInfo.MiOtherName = txtTcOtherName.Text;
            taMenuItemOtherChoiceInfo.MiPrice = string.IsNullOrEmpty(txtTcAddPrice.Text) ? "0.00" : txtTcAddPrice.Text;
            taMenuItemOtherChoiceInfo.IsAutoAppend = chkTcAutoAppend.Checked ? "Y" : "N";
            taMenuItemOtherChoiceInfo.IsEnableChoice = chkTcEnableChoice.Checked ? "Y" : "N";
            taMenuItemOtherChoiceInfo.MiID = miID;
            taMenuItemOtherChoiceInfo.MiType = miType;
            taMenuItemOtherChoiceInfo.OptionNum = txtTcNumOption.Text;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taMenuItemOtherChoiceInfo);
                    isAdd = false;
                }
                else
                {
                    taMenuItemOtherChoiceInfo.ID = Convert.ToInt32(gvThirdChoice.GetRowCellValue(gvThirdChoice.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taMenuItemOtherChoiceInfo);
                }

                BindOtherChoice(miType, miID);
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnTcDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaMenuItemOtherChoice();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaMenuItemOtherChoice.FirstOrDefault(s => s.ID == Convert.ToInt32(gvThirdChoice.GetRowCellValue(gvThirdChoice.FocusedRowHandle, "ID"))));
                    CommonTool.ShowMessage("Delete successful!");
                    BindOtherChoice(miType, miID);
                    isAdd = false;
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }
        }

        private void btnTcExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gvThirdChoice_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvThirdChoice.RowCount > 0)
            {
                txtTcEngName.Text = gvThirdChoice.GetRowCellValue(gvThirdChoice.FocusedRowHandle, "MiEngName").ToString();
                txtTcOtherName.Text = gvThirdChoice.GetRowCellValue(gvThirdChoice.FocusedRowHandle, "MiOtherName").ToString();
                txtTcAddPrice.Text = gvThirdChoice.GetRowCellValue(gvThirdChoice.FocusedRowHandle, "MiPrice").ToString();
                chkTcAutoAppend.Checked = gvThirdChoice.GetRowCellValue(gvThirdChoice.FocusedRowHandle, "IsAutoAppend").ToString().Equals("Y");
                chkTcEnableChoice.Checked = gvThirdChoice.GetRowCellValue(gvThirdChoice.FocusedRowHandle, "IsEnableChoice").ToString().Equals("Y");
                txtTcNumOption.Text = gvThirdChoice.GetRowCellValue(gvThirdChoice.FocusedRowHandle, "OptionNum") == null ? "" : gvSecondChoice.GetRowCellValue(gvSecondChoice.FocusedRowHandle, "OptionNum").ToString();
            }
            else
            {
                txtTcEngName.Text = "";
                txtTcOtherName.Text = "";
                txtTcAddPrice.Text = "";
                chkTcAutoAppend.Checked = false;
                chkTcEnableChoice.Checked = false;
                txtTcNumOption.Text = "";
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtDishCode.Text = "";
            BindChkMenuCate(false);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            gvMenuItem.FocusedRowHandle = gvMenuItem.FocusedRowHandle >= gvMenuItem.RowCount
                ? gvMenuItem.RowCount - 1
                : gvMenuItem.FocusedRowHandle + 1;

            gvMenuItem.SelectRow(gvMenuItem.FocusedRowHandle);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            gvMenuItem.FocusedRowHandle = gvMenuItem.FocusedRowHandle - 1 <= 0
                ? 0
                : gvMenuItem.FocusedRowHandle - 1;

            gvMenuItem.SelectRow(gvMenuItem.FocusedRowHandle);
        }
    }
}