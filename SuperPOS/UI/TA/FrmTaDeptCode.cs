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
    public partial class FrmTaDeptCode : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        //是否为Add
        private bool isAdd = false;

        public FrmTaDeptCode()
        {
            InitializeComponent();
        }

        public FrmTaDeptCode(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        #region Add点击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtEngName.Text = "";
            txtOtherName.Text = "";
        }
        #endregion

        #region Save点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEngName.Text))
            {
                CommonTool.ShowMessage("Name can not NULL!");
                return;
            }

            if (string.IsNullOrEmpty(txtOtherName.Text))
            {
                CommonTool.ShowMessage("Other Name can not NULL!");
                return;
            }

            new SystemData().GetTaDeptCode();

            TaDeptCodeInfo taDeptCodeInfo = new TaDeptCodeInfo();
            taDeptCodeInfo.DeptEngName = txtEngName.Text;
            taDeptCodeInfo.DeptOtherName = txtOtherName.Text;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taDeptCodeInfo);
                    isAdd = false;
                }
                else
                {
                    taDeptCodeInfo.ID = Convert.ToInt32(gvTaDeptCode.GetRowCellValue(gvTaDeptCode.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taDeptCodeInfo);
                }

                BindData();
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }
        #endregion

        #region Delete按钮点击事件
        private void btnDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaDeptCode();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaDeptCode.FirstOrDefault(s => s.ID ==
                                Convert.ToInt32(gvTaDeptCode.GetRowCellValue(gvTaDeptCode.FocusedRowHandle, "ID"))));
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
        #endregion

        #region 绑定数据
        private void BindData()
        {
            new SystemData().GetTaDeptCode();

            gridControlTaDeptCode.DataSource = CommonData.TaDeptCode.ToList();

            gvTaDeptCode.FocusedRowHandle = gvTaDeptCode.RowCount - 1;
        }
        #endregion

        #region 窗口加载
        private void FrmTaDeptCode_Load(object sender, EventArgs e)
        {
            BindData();
        }
        #endregion

        private void gvTaDeptCode_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvTaDeptCode_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtEngName.Text = gvTaDeptCode.GetRowCellValue(gvTaDeptCode.FocusedRowHandle, "DeptEngName").ToString();
            txtOtherName.Text = gvTaDeptCode.GetRowCellValue(gvTaDeptCode.FocusedRowHandle, "DeptOtherName").ToString();
        }
    }
}