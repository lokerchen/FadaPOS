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

        //Menu Item名字
        private string miEngName = "";

        private int miType = 2;

        #region Second Choice 
        //English Name文本框组
        private TextEdit[] txtScEngName = new TextEdit[20];
        //Other Name 文本框
        private TextEdit[] txtScOtherName = new TextEdit[20];
        //Add Price
        private TextEdit[] txtScAddPrice = new TextEdit[20];
        //Auto Append
        private CheckEdit[] chkScAutoAppend = new CheckEdit[20];
        #endregion

        #region Third Choice 
        //English Name文本框组
        private TextEdit[] txtTcEngName = new TextEdit[20];
        //Other Name 文本框
        private TextEdit[] txtTcOtherName = new TextEdit[20];
        //Add Price
        private TextEdit[] txtTcAddPrice = new TextEdit[20];
        //Auto Append
        private CheckEdit[] chkTcAutoAppend = new CheckEdit[20];
        #endregion

        #region Sub Menu
        private TextEdit[] txtSmEngName = new TextEdit[15];
        private TextEdit[] txtSmOtherName = new TextEdit[15];
        #endregion

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
            SetTxt();

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
        private void BindGridData(int menuSetID, string strDishCode, string strDishCate)
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
                //gridControlMenuItem.DataSource = menuSetID >= 0
                //    ? lstMenuItem.Where(s => s.MiMenuSetID == menuSetID).ToList()
                //    : lstMenuItem.ToList();
                if (string.IsNullOrEmpty(strDishCate))
                {
                    gridControlMenuItem.DataSource = menuSetID >= 0
                        ? lstMenuItem.Where(s => s.MiMenuSetID == menuSetID).ToList()
                        : lstMenuItem.ToList();
                }
                else
                {
                    gridControlMenuItem.DataSource = menuSetID >= 0
                    ? lstMenuItem.Where(s => s.MiMenuSetID == menuSetID && s.MiMenuCateID.Split(',').Contains(strDishCate)).ToList()
                    : lstMenuItem.ToList();
                }
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

            BindChkComboDishSearch();

            BindLuePrtName();
            //BindLuePrtOrder();
            //BindLueSupplyShift();
            //BinLueMenuSet();

            BindGridData(iMenuSetKey, "", "");
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
            BindChkComboDishSearch();
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
                BindGridData(iMenuSetKey, "", "");
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
            if (gvMenuItem.RowCount < 1 ) return;

            if (gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiDishCode") != null)
                miID = Convert.ToInt32(gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "ID"));
            txtDishCode.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiDishCode") == null ? "" : gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiDishCode").ToString();
            txtDispPosition.Text = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiPosition") == null ? "" : gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiPosition").ToString();
            if (gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiEngName") != null)
                miEngName = gvMenuItem.GetRowCellValue(gvMenuItem.FocusedRowHandle, "MiEngName").ToString();
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
            if (strRmk.Contains("Set Meal")) chk2.Checked = true;
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

                BindGridData(iMenuSetKey, "", "");
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

            BindGridData(iMenuSetKey, "", "");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridData(iMenuSetKey, txtSearchDishCode.Text, "");
        }

        private void BindOtherChoice(int iType, int miID)
        {
            new SystemData().GetTaMenuItemOtherChoice();

            var lstOtherChoice = CommonData.TaMenuItemOtherChoice.Where(s => s.MiType == iType && s.MiID == miID);

            //Second Choice
            if (iType == 2)
            {
                int i = 0;

                if (lstOtherChoice.Any())
                {
                    txtScNumOption.Text = lstOtherChoice.FirstOrDefault().OptionNum;
                    chkScEnableChoice.Checked = lstOtherChoice.FirstOrDefault().IsEnableChoice.Equals("Y")
                        ? true
                        : false;
                }
                else
                {
                    txtScNumOption.Text = "";
                    chkScEnableChoice.Checked = false;
                }

                foreach (var taMenuItemOtherChoiceInfo in lstOtherChoice)
                {
                    txtScEngName[i].Text = taMenuItemOtherChoiceInfo.MiEngName;
                    txtScOtherName[i].Text = taMenuItemOtherChoiceInfo.MiOtherName;
                    txtScAddPrice[i].Text = taMenuItemOtherChoiceInfo.MiPrice;
                    chkScEnableChoice.Checked = taMenuItemOtherChoiceInfo.IsEnableChoice.Equals("Y") ? true : false;
                    chkScAutoAppend[i].Checked = taMenuItemOtherChoiceInfo.IsAutoAppend.Equals("Y") ? true : false;
                    i++;
                }

                for (int j = i; j < 20; j++)
                {
                    txtScEngName[j].Text = "";
                    txtScOtherName[j].Text = "";
                    txtScAddPrice[j].Text = "";
                    chkScAutoAppend[j].Checked = false;
                }
            }

            //Third Choice
            if (iType == 3)
            {
                int i = 0;

                if (lstOtherChoice.Any())
                {
                    txtTcNumOption.Text = lstOtherChoice.FirstOrDefault().OptionNum;
                    chkTcEnableChoice.Checked = lstOtherChoice.FirstOrDefault().IsEnableChoice.Equals("Y")
                        ? true
                        : false;
                }
                else
                {
                    txtTcNumOption.Text = "";
                    chkTcEnableChoice.Checked = false;
                }

                foreach (var taMenuItemOtherChoiceInfo in lstOtherChoice)
                {
                    txtTcEngName[i].Text = taMenuItemOtherChoiceInfo.MiEngName;
                    txtTcOtherName[i].Text = taMenuItemOtherChoiceInfo.MiOtherName;
                    txtTcAddPrice[i].Text = taMenuItemOtherChoiceInfo.MiPrice;
                    chkTcEnableChoice.Checked = taMenuItemOtherChoiceInfo.IsEnableChoice.Equals("Y") ? true : false;
                    chkTcAutoAppend[i].Checked = taMenuItemOtherChoiceInfo.IsAutoAppend.Equals("Y") ? true : false;
                    i++;
                }

                for (int j = i; j < 20; j++)
                {
                    txtTcEngName[j].Text = "";
                    txtTcOtherName[j].Text = "";
                    txtTcAddPrice[j].Text = "";
                    chkTcAutoAppend[j].Checked = false;
                }
            }
            
        }

        private void xtpUsrAccess_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {
            miType = SelectPage(e.Page.Name);

            if (miType != 4) BindOtherChoice(miType, miID);
            else BindSubMenu(miID);
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
            else if (pageName.Equals("xtpSm")) return 4;
            else return 2;
        }
        #endregion

        private void btnScExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnScSave_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaMenuItemOtherChoice();

            var lstOc = CommonData.TaMenuItemOtherChoice.Where(s => s.MiType == miType && s.MiID == miID);

            foreach (var choiceInfo in lstOc)
            {
                _control.DeleteEntity(choiceInfo);
            }

            for (int i = 0; i < 20; i++)
            {
                //增加判断是否为一条正常记录：English Name + Other Name + Add Price
                if (string.IsNullOrEmpty(txtScEngName[i].Text) && string.IsNullOrEmpty(txtScOtherName[i].Text)) continue;

                try
                {
                    TaMenuItemOtherChoiceInfo taMenuItemOtherChoiceInfo = new TaMenuItemOtherChoiceInfo();

                    taMenuItemOtherChoiceInfo.MiEngName = txtScEngName[i].Text;
                    taMenuItemOtherChoiceInfo.MiOtherName = txtScOtherName[i].Text;
                    taMenuItemOtherChoiceInfo.MiPrice = string.IsNullOrEmpty(txtScAddPrice[i].Text) ? "0.00" : txtScAddPrice[i].Text;
                    taMenuItemOtherChoiceInfo.IsAutoAppend = chkScAutoAppend[i].Checked ? "Y" : "N";
                    taMenuItemOtherChoiceInfo.IsEnableChoice = chkScEnableChoice.Checked ? "Y" : "N";
                    taMenuItemOtherChoiceInfo.MiID = miID;
                    taMenuItemOtherChoiceInfo.MiType = miType;
                    taMenuItemOtherChoiceInfo.OptionNum = string.IsNullOrEmpty(txtScNumOption.Text) ? "0" : txtScNumOption.Text;

                    _control.AddEntity(taMenuItemOtherChoiceInfo);
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }

            BindOtherChoice(miType, miID);
            CommonTool.ShowMessage("Save successful!");
        }

        private void btnTcSave_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaMenuItemOtherChoice();

            var lstOc = CommonData.TaMenuItemOtherChoice.Where(s => s.MiType == miType && s.MiID == miID);

            foreach (var choiceInfo in lstOc)
            {
                _control.DeleteEntity(choiceInfo);
            }

            for (int i = 0; i < 20; i++)
            {
                //增加判断是否为一条正常记录：English Name + Other Name + Add Price
                if (string.IsNullOrEmpty(txtTcEngName[i].Text) && string.IsNullOrEmpty(txtTcOtherName[i].Text)) continue;

                try
                {
                    TaMenuItemOtherChoiceInfo taMenuItemOtherChoiceInfo = new TaMenuItemOtherChoiceInfo();

                    taMenuItemOtherChoiceInfo.MiEngName = txtTcEngName[i].Text;
                    taMenuItemOtherChoiceInfo.MiOtherName = txtTcOtherName[i].Text;
                    taMenuItemOtherChoiceInfo.MiPrice = string.IsNullOrEmpty(txtTcAddPrice[i].Text) ? "0.00" : txtTcAddPrice[i].Text;
                    taMenuItemOtherChoiceInfo.IsAutoAppend = chkTcAutoAppend[i].Checked ? "Y" : "N";
                    taMenuItemOtherChoiceInfo.IsEnableChoice = chkTcEnableChoice.Checked ? "Y" : "N";
                    taMenuItemOtherChoiceInfo.MiID = miID;
                    taMenuItemOtherChoiceInfo.MiType = miType;
                    taMenuItemOtherChoiceInfo.OptionNum = string.IsNullOrEmpty(txtTcNumOption.Text) ? "0" : txtTcNumOption.Text;

                    _control.AddEntity(taMenuItemOtherChoiceInfo);
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }

            BindOtherChoice(miType, miID);

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnTcExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtDishCode.Text = "";
            BindChkMenuCate(false);

            BindChkComboDishSearch();
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

        private void SetTxt()
        {
            #region Second Choice
            #region EnglishName
            txtScEngName[0] = txtScEngName1;
            txtScEngName[1] = txtScEngName2;
            txtScEngName[2] = txtScEngName3;
            txtScEngName[3] = txtScEngName4;
            txtScEngName[4] = txtScEngName5;
            txtScEngName[5] = txtScEngName6;
            txtScEngName[6] = txtScEngName7;
            txtScEngName[7] = txtScEngName8;
            txtScEngName[8] = txtScEngName9;
            txtScEngName[9] = txtScEngName10;
            txtScEngName[10] = txtScEngName11;
            txtScEngName[11] = txtScEngName12;
            txtScEngName[12] = txtScEngName13;
            txtScEngName[13] = txtScEngName14;
            txtScEngName[14] = txtScEngName15;
            txtScEngName[15] = txtScEngName16;
            txtScEngName[16] = txtScEngName17;
            txtScEngName[17] = txtScEngName18;
            txtScEngName[18] = txtScEngName19;
            txtScEngName[19] = txtScEngName20;
            #endregion

            #region OtherName
            txtScOtherName[0] = txtScOtherName1;
            txtScOtherName[1] = txtScOtherName2;
            txtScOtherName[2] = txtScOtherName3;
            txtScOtherName[3] = txtScOtherName4;
            txtScOtherName[4] = txtScOtherName5;
            txtScOtherName[5] = txtScOtherName6;
            txtScOtherName[6] = txtScOtherName7;
            txtScOtherName[7] = txtScOtherName8;
            txtScOtherName[8] = txtScOtherName9;
            txtScOtherName[9] = txtScOtherName10;
            txtScOtherName[10] = txtScOtherName11;
            txtScOtherName[11] = txtScOtherName12;
            txtScOtherName[12] = txtScOtherName13;
            txtScOtherName[13] = txtScOtherName14;
            txtScOtherName[14] = txtScOtherName15;
            txtScOtherName[15] = txtScOtherName16;
            txtScOtherName[16] = txtScOtherName17;
            txtScOtherName[17] = txtScOtherName18;
            txtScOtherName[18] = txtScOtherName19;
            txtScOtherName[19] = txtScOtherName20;
            #endregion

            #region Add Price
            txtScAddPrice[0] = txtScAddPrice1;
            txtScAddPrice[1] = txtScAddPrice2;
            txtScAddPrice[2] = txtScAddPrice3;
            txtScAddPrice[3] = txtScAddPrice4;
            txtScAddPrice[4] = txtScAddPrice5;
            txtScAddPrice[5] = txtScAddPrice6;
            txtScAddPrice[6] = txtScAddPrice7;
            txtScAddPrice[7] = txtScAddPrice8;
            txtScAddPrice[8] = txtScAddPrice9;
            txtScAddPrice[9] = txtScAddPrice10;
            txtScAddPrice[10] = txtScAddPrice11;
            txtScAddPrice[11] = txtScAddPrice12;
            txtScAddPrice[12] = txtScAddPrice13;
            txtScAddPrice[13] = txtScAddPrice14;
            txtScAddPrice[14] = txtScAddPrice15;
            txtScAddPrice[15] = txtScAddPrice16;
            txtScAddPrice[16] = txtScAddPrice17;
            txtScAddPrice[17] = txtScAddPrice18;
            txtScAddPrice[18] = txtScAddPrice19;
            txtScAddPrice[19] = txtScAddPrice20;
            #endregion

            #region chkScAutoAppend
            chkScAutoAppend[0] = chkScAutoAppend1;
            chkScAutoAppend[1] = chkScAutoAppend2;
            chkScAutoAppend[2] = chkScAutoAppend3;
            chkScAutoAppend[3] = chkScAutoAppend4;
            chkScAutoAppend[4] = chkScAutoAppend5;
            chkScAutoAppend[5] = chkScAutoAppend6;
            chkScAutoAppend[6] = chkScAutoAppend7;
            chkScAutoAppend[7] = chkScAutoAppend8;
            chkScAutoAppend[8] = chkScAutoAppend9;
            chkScAutoAppend[9] = chkScAutoAppend10;
            chkScAutoAppend[10] = chkScAutoAppend11;
            chkScAutoAppend[11] = chkScAutoAppend12;
            chkScAutoAppend[12] = chkScAutoAppend13;
            chkScAutoAppend[13] = chkScAutoAppend14;
            chkScAutoAppend[14] = chkScAutoAppend15;
            chkScAutoAppend[15] = chkScAutoAppend16;
            chkScAutoAppend[16] = chkScAutoAppend17;
            chkScAutoAppend[17] = chkScAutoAppend18;
            chkScAutoAppend[18] = chkScAutoAppend19;
            chkScAutoAppend[19] = chkScAutoAppend20;
            #endregion
            #endregion

            #region Third Choice
            #region EnglishName
            txtTcEngName[0] = txtTcEngName1;
            txtTcEngName[1] = txtTcEngName2;
            txtTcEngName[2] = txtTcEngName3;
            txtTcEngName[3] = txtTcEngName4;
            txtTcEngName[4] = txtTcEngName5;
            txtTcEngName[5] = txtTcEngName6;
            txtTcEngName[6] = txtTcEngName7;
            txtTcEngName[7] = txtTcEngName8;
            txtTcEngName[8] = txtTcEngName9;
            txtTcEngName[9] = txtTcEngName10;
            txtTcEngName[10] = txtTcEngName11;
            txtTcEngName[11] = txtTcEngName12;
            txtTcEngName[12] = txtTcEngName13;
            txtTcEngName[13] = txtTcEngName14;
            txtTcEngName[14] = txtTcEngName15;
            txtTcEngName[15] = txtTcEngName16;
            txtTcEngName[16] = txtTcEngName17;
            txtTcEngName[17] = txtTcEngName18;
            txtTcEngName[18] = txtTcEngName19;
            txtTcEngName[19] = txtTcEngName20;
            #endregion

            #region OtherName
            txtTcOtherName[0] = txtTcOtherName1;
            txtTcOtherName[1] = txtTcOtherName2;
            txtTcOtherName[2] = txtTcOtherName3;
            txtTcOtherName[3] = txtTcOtherName4;
            txtTcOtherName[4] = txtTcOtherName5;
            txtTcOtherName[5] = txtTcOtherName6;
            txtTcOtherName[6] = txtTcOtherName7;
            txtTcOtherName[7] = txtTcOtherName8;
            txtTcOtherName[8] = txtTcOtherName9;
            txtTcOtherName[9] = txtTcOtherName10;
            txtTcOtherName[10] = txtTcOtherName11;
            txtTcOtherName[11] = txtTcOtherName12;
            txtTcOtherName[12] = txtTcOtherName13;
            txtTcOtherName[13] = txtTcOtherName14;
            txtTcOtherName[14] = txtTcOtherName15;
            txtTcOtherName[15] = txtTcOtherName16;
            txtTcOtherName[16] = txtTcOtherName17;
            txtTcOtherName[17] = txtTcOtherName18;
            txtTcOtherName[18] = txtTcOtherName19;
            txtTcOtherName[19] = txtTcOtherName20;
            #endregion

            #region Add Price
            txtTcAddPrice[0] = txtTcAddPrice1;
            txtTcAddPrice[1] = txtTcAddPrice2;
            txtTcAddPrice[2] = txtTcAddPrice3;
            txtTcAddPrice[3] = txtTcAddPrice4;
            txtTcAddPrice[4] = txtTcAddPrice5;
            txtTcAddPrice[5] = txtTcAddPrice6;
            txtTcAddPrice[6] = txtTcAddPrice7;
            txtTcAddPrice[7] = txtTcAddPrice8;
            txtTcAddPrice[8] = txtTcAddPrice9;
            txtTcAddPrice[9] = txtTcAddPrice10;
            txtTcAddPrice[10] = txtTcAddPrice11;
            txtTcAddPrice[11] = txtTcAddPrice12;
            txtTcAddPrice[12] = txtTcAddPrice13;
            txtTcAddPrice[13] = txtTcAddPrice14;
            txtTcAddPrice[14] = txtTcAddPrice15;
            txtTcAddPrice[15] = txtTcAddPrice16;
            txtTcAddPrice[16] = txtTcAddPrice17;
            txtTcAddPrice[17] = txtTcAddPrice18;
            txtTcAddPrice[18] = txtScAddPrice19;
            txtTcAddPrice[19] = txtTcAddPrice20;
            #endregion

            #region chkTcAutoAppend
            chkTcAutoAppend[0] = chkTcAutoAppend1;
            chkTcAutoAppend[1] = chkTcAutoAppend2;
            chkTcAutoAppend[2] = chkTcAutoAppend3;
            chkTcAutoAppend[3] = chkTcAutoAppend4;
            chkTcAutoAppend[4] = chkTcAutoAppend5;
            chkTcAutoAppend[5] = chkTcAutoAppend6;
            chkTcAutoAppend[6] = chkTcAutoAppend7;
            chkTcAutoAppend[7] = chkTcAutoAppend8;
            chkTcAutoAppend[8] = chkTcAutoAppend9;
            chkTcAutoAppend[9] = chkTcAutoAppend10;
            chkTcAutoAppend[10] = chkTcAutoAppend11;
            chkTcAutoAppend[11] = chkTcAutoAppend12;
            chkTcAutoAppend[12] = chkTcAutoAppend13;
            chkTcAutoAppend[13] = chkTcAutoAppend14;
            chkTcAutoAppend[14] = chkTcAutoAppend15;
            chkTcAutoAppend[15] = chkTcAutoAppend16;
            chkTcAutoAppend[16] = chkTcAutoAppend17;
            chkTcAutoAppend[17] = chkTcAutoAppend18;
            chkTcAutoAppend[18] = chkTcAutoAppend19;
            chkTcAutoAppend[19] = chkTcAutoAppend20;
            #endregion
            #endregion

            #region Sub Menu
            #region EnglishName
            txtSmEngName[0] = txtSmEngName1;
            txtSmEngName[1] = txtSmEngName2;
            txtSmEngName[2] = txtSmEngName3;
            txtSmEngName[3] = txtSmEngName4;
            txtSmEngName[4] = txtSmEngName5;
            txtSmEngName[5] = txtSmEngName6;
            txtSmEngName[6] = txtSmEngName7;
            txtSmEngName[7] = txtSmEngName8;
            txtSmEngName[8] = txtSmEngName9;
            txtSmEngName[9] = txtSmEngName10;
            txtSmEngName[10] = txtSmEngName11;
            txtSmEngName[11] = txtSmEngName12;
            txtSmEngName[12] = txtSmEngName13;
            txtSmEngName[13] = txtSmEngName14;
            txtSmEngName[14] = txtSmEngName15;
            #endregion

            #region OtherName
            txtSmOtherName[0] = txtSmOtherName1;
            txtSmOtherName[1] = txtSmOtherName2;
            txtSmOtherName[2] = txtSmOtherName3;
            txtSmOtherName[3] = txtSmOtherName4;
            txtSmOtherName[4] = txtSmOtherName5;
            txtSmOtherName[5] = txtSmOtherName6;
            txtSmOtherName[6] = txtSmOtherName7;
            txtSmOtherName[7] = txtSmOtherName8;
            txtSmOtherName[8] = txtSmOtherName9;
            txtSmOtherName[9] = txtSmOtherName10;
            txtSmOtherName[10] = txtSmOtherName11;
            txtSmOtherName[11] = txtSmOtherName12;
            txtSmOtherName[12] = txtSmOtherName13;
            txtSmOtherName[13] = txtSmOtherName14;
            txtSmOtherName[14] = txtSmOtherName15;
            #endregion
            #endregion
        }

        private void BindSubMenu(int miID)
        {
            new SystemData().GetTaMenuItemSubMenu();

            var lstSm = CommonData.TaMenuItemSubMenu.Where(s => s.SmMiID == miID);

            if (!string.IsNullOrEmpty(miEngName)) lblSubMenuName.Text = miEngName;
            int i = 0;

            if (lstSm.Any())
            {
                chkSmAutoExpand.Checked = lstSm.FirstOrDefault().IsAutoExpand.Equals("Y");
                chkSmShowContentOnPrtOut.Checked = lstSm.FirstOrDefault().IsShowContentOnPrtOut.Equals("Y")
                    ? true
                    : false;
            }
            else
            {
                chkSmAutoExpand.Checked = false;
                chkSmShowContentOnPrtOut.Checked = false;
            }

            foreach (var taMenuItemSubMenuInfo in lstSm)
            {
                txtSmEngName[i].Text = taMenuItemSubMenuInfo.SmEngName;
                txtSmOtherName[i].Text = taMenuItemSubMenuInfo.SmOtherName;
                i++;
            }

            for (int j = i; j < 15; j++)
            {
                txtSmEngName[j].Text = "";
                txtSmOtherName[j].Text = "";
            }
        }

        private void btnSmExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSmSave_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaMenuItemSubMenu();

            var lstSm = CommonData.TaMenuItemSubMenu.Where(s => s.SmMiID == miID);

            foreach (var taMenuItemSubMenuInfo in lstSm)
            {
                _control.DeleteEntity(taMenuItemSubMenuInfo);
            }

            //标记是否发生过修改，发生修改则为套餐，否则为正常菜品
            bool isMod = false;

            for (int i = 0; i < 15; i++)
            {
                //增加判断是否为一条正常记录：English Name + Other Name + Add Price
                if (string.IsNullOrEmpty(txtSmEngName[i].Text) && string.IsNullOrEmpty(txtSmEngName[i].Text)) continue;

                try
                {
                    TaMenuItemSubMenuInfo taMenuItemSubMenuInfo = new TaMenuItemSubMenuInfo();

                    taMenuItemSubMenuInfo.SmEngName = txtSmEngName[i].Text;
                    taMenuItemSubMenuInfo.SmOtherName = txtSmOtherName[i].Text;
                    taMenuItemSubMenuInfo.IsAutoExpand = chkSmAutoExpand.Checked ? "Y" : "N";
                    taMenuItemSubMenuInfo.IsShowContentOnPrtOut = chkSmShowContentOnPrtOut.Checked ? "Y" : "N";
                    taMenuItemSubMenuInfo.SmMiID = miID;

                    _control.AddEntity(taMenuItemSubMenuInfo);

                    isMod = true;
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }

            //更新MenuItem为套餐
            try
            {
                if (isMod)
                {
                    TaMenuItemInfo smMenuItem = CommonData.TaMenuItem.FirstOrDefault(s => s.ID == miID);
                    smMenuItem.MiRmk = @"Set Meal";
                    _control.UpdateEntity(smMenuItem);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            BindSubMenu(miID);
            CommonTool.ShowMessage("Save successful!");
        }

        private void chkComboDishSearch_EditValueChanged(object sender, EventArgs e)
        {
            //BindChkComboDishSearch();
            BindGridData(iMenuSetKey, "", lueDishCateSearch.EditValue.ToString());
        }

        #region chkComboDishSearch
        /// <summary>
        /// 绑定chkMenuCate
        /// </summary>
        private void BindChkComboDishSearch()
        {
            new SystemData().GetTaMenuCate();

            var lstMenuCate = from mc in CommonData.TaMenuCate
                              select new
                              {
                                  McID = mc.ID,
                                  McName = mc.CateEngName,
                                  MCOtherName = mc.CateOtherName
                              };

            lueDishCateSearch.Properties.DataSource = lstMenuCate.ToList();
            lueDishCateSearch.Properties.ValueMember = "McID";
            lueDishCateSearch.Properties.DisplayMember = "McName";

            lueDishCateSearch.RefreshEditValue();
        }
        #endregion

        private void btnScCopyChoices_Click(object sender, EventArgs e)
        {
            FrmTaMenuItemCopyChoices frmTaMenuItemCopyChoices = new FrmTaMenuItemCopyChoices(iMenuSetKey, miID, 2);

            if (frmTaMenuItemCopyChoices.ShowDialog() == DialogResult.OK)
            {
                frmTaMenuItemCopyChoices.Close();
            }
        }

        private void btnTcCopyChoices_Click(object sender, EventArgs e)
        {
            FrmTaMenuItemCopyChoices frmTaMenuItemCopyChoices = new FrmTaMenuItemCopyChoices(iMenuSetKey, miID, 3);

            if (frmTaMenuItemCopyChoices.ShowDialog() == DialogResult.OK)
            {
                frmTaMenuItemCopyChoices.Close();
            }
        }
    }
}