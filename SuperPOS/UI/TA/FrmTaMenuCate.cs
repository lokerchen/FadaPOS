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

        private int[] MenuSetKey = new int[4];

        private int iMenuSetKey = 1;

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
            BindLueMenuSet();
            BindLueDeptCode();

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

            BindGridData(iMenuSetKey);

            btnMenuSet1.BackColor = Color.CornflowerBlue;
            btnMenuSet1.Select();
            btnMenuSet2.BackColor = Color.Gray;
            btnMenuSet3.BackColor = Color.Gray;
            btnMenuSet4.BackColor = Color.Gray;

            asfc.controllInitializeSize(this);
        }

        private void gvMenuCate_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void BindGridData(int msId)
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

            gridControlMenuCate.DataSource = msId <= 0 ? lstMenuCate.ToList() : lstMenuCate.Where(s => s.MenuSetID == msId).ToList();
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

            //taMenuCateInfo.DeptCodeID = Convert.ToInt32(lueDeptCode.EditValue);
            taMenuCateInfo.DeptCodeID = 1;
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

                BindGridData(1);
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

            BindGridData(iMenuSetKey);
        }
    }
}