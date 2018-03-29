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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaSubMenu : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        //是否为Add
        private bool isAdd = false;

        public FrmTaSubMenu()
        {
            InitializeComponent();
        }

        public FrmTaSubMenu(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtSetMeal.Text = "";

            isAdd = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSetMeal.Text))
            {
                CommonTool.ShowMessage("Set Meal can not NULL!");
                return;
            }

            new SystemData().GetTaSubMenu();
            TaSubMenuInfo taSubMenuInfo = new TaSubMenuInfo();
            taSubMenuInfo.SetMeal = txtSetMeal.Text;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taSubMenuInfo);
                    isAdd = false;
                }
                else
                {
                    taSubMenuInfo.ID = Convert.ToInt32(gvTaSubMenu.GetRowCellValue(gvTaSubMenu.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taSubMenuInfo);
                }

                BindData();

            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaSubMenu();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaSubMenu.FirstOrDefault(s => s.ID == Convert.ToInt32(gvTaSubMenu.GetRowCellValue(gvTaSubMenu.FocusedRowHandle, "ID"))));
                    CommonTool.ShowMessage("Delete successful!");
                    BindData();
                    isAdd = false;
                }
                catch (Exception ex)
                {
                    LogHelper.Error(this.Name, ex);
                }
            }
        }

        private void BindData()
        {
            new SystemData().GetTaSubMenu();

            gridControlTaSubMenu.DataSource = CommonData.TaSubMenu.ToList();

            gvTaSubMenu.FocusedRowHandle = gvTaSubMenu.RowCount - 1;
        }

        private void FrmTaSubMenu_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void gvTaSubMenu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtSetMeal.Text = gvTaSubMenu.GetRowCellValue(gvTaSubMenu.FocusedRowHandle, "SetMeal").ToString();
        }

        private void gvTaSubMenu_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs arg = e as MouseEventArgs;

            if (arg == null) return;

            //获取鼠标坐标
            GridHitInfo hitInfo = gvTaSubMenu.CalcHitInfo(new Point(arg.X, arg.Y));

            if (hitInfo.RowHandle >= 0)
            {

                FrmTaSubMenuDetail frmTaSubMenuDetail = new FrmTaSubMenuDetail(Convert.ToInt32(gvTaSubMenu.GetRowCellValue(gvTaSubMenu.FocusedRowHandle, "ID")));
                frmTaSubMenuDetail.ShowDialog();

                BindData();
            }
        }
    }
}