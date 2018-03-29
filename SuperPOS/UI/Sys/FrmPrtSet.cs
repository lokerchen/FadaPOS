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

namespace SuperPOS.UI.Sys
{
    public partial class FrmPrtSet : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        //是否为Add
        private bool isAdd = false;

        public FrmPrtSet()
        {
            InitializeComponent();
        }

        public FrmPrtSet(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        #region Add按钮点击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtPrtCode.Text = "";
            txtPrtName.Text = "";
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrtName.Text))
            {
                CommonTool.ShowMessage("Printer Name can not NULL!");
                return;
            }

            if (string.IsNullOrEmpty(txtPrtCode.Text))
            {
                CommonTool.ShowMessage("Printer Code can not NULL!");
                return;
            }

            new SystemData().GetSysPrtList();

            SysPrtSetInfo sysPrtSetInfo = new SysPrtSetInfo();
            sysPrtSetInfo.PrtCode = txtPrtCode.Text;
            sysPrtSetInfo.PrtName = txtPrtName.Text;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(sysPrtSetInfo);
                    isAdd = false;
                }
                else
                {
                    sysPrtSetInfo.ID = Convert.ToInt32(gvPrtSet.GetRowCellValue(gvPrtSet.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(sysPrtSetInfo);
                }

                BindData();
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetSysPrtList();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.SysPrt.FirstOrDefault(s => s.ID == Convert.ToInt32(gvPrtSet.GetRowCellValue(gvPrtSet.FocusedRowHandle, "ID"))));
                    CommonTool.ShowMessage("Delete successful!");
                    BindData();
                    isAdd = false;
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }
        }

        #region 绑定数据
        private void BindData()
        {
            new SystemData().GetSysPrtList();

            gridControlPrtSet.DataSource = CommonData.SysPrt.ToList();

            gvPrtSet.FocusedRowHandle = gvPrtSet.RowCount - 1;
        }
        #endregion

        #region 窗口加载事件
        private void FrmPrtSet_Load(object sender, EventArgs e)
        {
            BindData();
        }
        #endregion

        #region 焦点行变化事件
        private void gvPrtSet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtPrtCode.Text = gvPrtSet.GetRowCellValue(gvPrtSet.FocusedRowHandle, "PrtCode").ToString();
            txtPrtName.Text = gvPrtSet.GetRowCellValue(gvPrtSet.FocusedRowHandle, "PrtName").ToString();
        }
        #endregion

        private void gvPrtSet_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}