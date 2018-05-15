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
    public partial class FrmTaMenuCate : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";
        //新增/更新
        private bool isAdd = false;

        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmTaMenuCate()
        {
            InitializeComponent();
        }

        public FrmTaMenuCate(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        private void FrmTaMenuCategory_Load(object sender, EventArgs e)
        {
            BindGridData();
            BindLueMenuSet();
            BindLueDeptCode();

            asfc.controllInitializeSize(this);
        }

        private void gvMenuCate_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void BindGridData()
        {
            new SystemData().GetTaMenuCate();
            new SystemData().GetTaMenuSet();
            new SystemData().GetTaDeptCode();

            var lstMenuCate = from mc in CommonData.TaMenuCate
                join dc in CommonData.TaDeptCode
                    on mc.DeptCodeID equals dc.ID
                join ms in CommonData.TaMenuSet
                    on mc.MenuSetID equals ms.ID
                select new
                {
                    ID = mc.ID,
                    CateEngName = mc.CateEngName,
                    CateOtherName = mc.CateOtherName,
                    CatePosition = mc.CatePosition,
                    DeptCodeID = mc.DeptCodeID,
                    MenuSetID = mc.MenuSetID,
                    IsHotKey = mc.IsHotKey,
                    HotKeyDishCode = mc.HotKeyDishCode,
                    DeptCode = dc.DeptEngName,
                    MenuSet = ms.MSEngName
                };

            gvMenuCate.BestFitColumns();
            gridControlMenuCate.DataSource = lstMenuCate.ToList();
            gvMenuCate.FocusedRowHandle = gvMenuCate.RowCount - 1;
        }

        private void BindLueDeptCode()
        {
            new SystemData().GetTaDeptCode();

            var lstDeptCode = from dc in CommonData.TaDeptCode
                select new
                {
                    DcID = dc.ID,
                    DcName = dc.DeptEngName
                };
            lueDeptCode.Properties.DataSource = lstDeptCode.ToList();
            lueDeptCode.Properties.DisplayMember = "DcName";
            lueDeptCode.Properties.ValueMember = "DcID";
        }

        private void BindLueMenuSet()
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

        private void gvMenuCate_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtEngName.Text = gvMenuCate.GetRowCellValue(gvMenuCate.FocusedRowHandle, "CateEngName").ToString();
            txtOtherName.Text = gvMenuCate.GetRowCellValue(gvMenuCate.FocusedRowHandle, "CateOtherName").ToString();
            txtPosition.Text = gvMenuCate.GetRowCellValue(gvMenuCate.FocusedRowHandle, "CatePosition").ToString();
            lueDeptCode.EditValue = Convert.ToInt32(gvMenuCate.GetRowCellValue(gvMenuCate.FocusedRowHandle, "DeptCodeID"));
            lueDeptCode.Text = gvMenuCate.GetRowCellValue(gvMenuCate.FocusedRowHandle, "DeptCode").ToString();
            lueMenuSet.EditValue = Convert.ToInt32(gvMenuCate.GetRowCellValue(gvMenuCate.FocusedRowHandle, "MenuSetID"));
            lueMenuSet.Text = gvMenuCate.GetRowCellValue(gvMenuCate.FocusedRowHandle, "MenuSet").ToString();
            chkHotKey.Checked = txtHotKeyDishCode.Enabled = gvMenuCate.GetRowCellValue(gvMenuCate.FocusedRowHandle, "IsHotKey").ToString().Equals("Y");
            txtHotKeyDishCode.Text = gvMenuCate.GetRowCellValue(gvMenuCate.FocusedRowHandle, "HotKeyDishCode") == null ? "" : gvMenuCate.GetRowCellValue(gvMenuCate.FocusedRowHandle, "HotKeyDishCode").ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtEngName.Text = "";
            txtOtherName.Text = "";
            txtPosition.Text = "";

            lueDeptCode.ItemIndex = 0;
            lueMenuSet.ItemIndex = 0;

            chkHotKey.Checked = false;
            txtHotKeyDishCode.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 空值判断
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

            if (string.IsNullOrEmpty(txtPosition.Text))
            {
                CommonTool.ShowMessage("Display Position is empty,please enter!");
                return;
            }

            if (string.IsNullOrEmpty(lueDeptCode.EditValue.ToString()))
            {
                CommonTool.ShowMessage("Please select Department Code!");
                return;
            }

            if (string.IsNullOrEmpty(lueMenuSet.EditValue.ToString()))
            {
                CommonTool.ShowMessage("Please select Menu Set!");
                return;
            }
            #endregion

            new SystemData().GetTaMenuCate();

            TaMenuCateInfo taMenuCateInfo = new TaMenuCateInfo();
            taMenuCateInfo.CateEngName = txtEngName.Text;
            taMenuCateInfo.CateOtherName = txtOtherName.Text;
            taMenuCateInfo.CatePosition = txtPosition.Text;

            taMenuCateInfo.DeptCodeID = Convert.ToInt32(lueDeptCode.EditValue);
            taMenuCateInfo.MenuSetID = Convert.ToInt32(lueMenuSet.EditValue);

            taMenuCateInfo.IsHotKey = chkHotKey.Checked ? "Y" : "N";
            taMenuCateInfo.HotKeyDishCode = txtHotKeyDishCode.Text;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taMenuCateInfo);

                    isAdd = false;
                }
                else
                {
                    taMenuCateInfo.ID = Convert.ToInt32(gvMenuCate.GetRowCellValue(gvMenuCate.FocusedRowHandle, "ID"));

                    _control.UpdateEntity(taMenuCateInfo);
                }

                BindGridData();
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.Name, ex);
            }

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaMenuCate();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaMenuCate.FirstOrDefault(
                            s => s.ID == Convert.ToInt32(gvMenuCate.GetRowCellValue(gvMenuCate.FocusedRowHandle, "ID"))));
                }
                catch (Exception ex)
                {
                    LogHelper.Error(this.Name, ex);
                }
            }
        }

        private void FrmTaMenuCate_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkHotKey_CheckedChanged(object sender, EventArgs e)
        {
            txtHotKeyDishCode.Enabled = chkHotKey.Checked;

            if (chkHotKey.Checked == false)
            {
                txtHotKeyDishCode.Text = "";
            }
        }
    }
}