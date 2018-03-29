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
    public partial class FrmUsrAuthGrp : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        //是否为Add
        private bool isAdd = false;

        public FrmUsrAuthGrp()
        {
            InitializeComponent();
        }

        public FrmUsrAuthGrp(int uId, string uName)
        {
            InitializeComponent();
            usrID = uId;
            usrName = uName;
        }

        private void FrmUsrAuthGrp_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            new SystemData().GetUsrAuthGroup();

            gridControlUsrAuthGrp.DataSource = CommonData.UsrAuthGroup.ToList();

            gvUsrAuthGrp.FocusedRowHandle = gvUsrAuthGrp.RowCount - 1;
        }

        private void gvUsrAuthGrp_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvUsrAuthGrp_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtEngName.Text = gvUsrAuthGrp.GetRowCellValue(gvUsrAuthGrp.FocusedRowHandle, "GrpEngName").ToString();
            txtOtherName.Text = gvUsrAuthGrp.GetRowCellValue(gvUsrAuthGrp.FocusedRowHandle, "GrpOtherName").ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtEngName.Text = "";
            txtOtherName.Text = "";
        }

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

            new SystemData().GetUsrAuthGroup();

            UsrAuthGroupInfo usrAuthGroupInfo = new UsrAuthGroupInfo();
            usrAuthGroupInfo.GrpEngName = txtEngName.Text;
            usrAuthGroupInfo.GrpOtherName = txtOtherName.Text;

            usrAuthGroupInfo.CreateBy = usrName;
            usrAuthGroupInfo.CreateTime = DateTime.Now.ToString();

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(usrAuthGroupInfo);
                    isAdd = false;
                }
                else
                {
                    usrAuthGroupInfo.ID = Convert.ToInt32(gvUsrAuthGrp.GetRowCellValue(gvUsrAuthGrp.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(usrAuthGroupInfo);
                }

                BindData();
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetUsrAuthGroup();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.UsrAuthGroup.FirstOrDefault(s => s.ID ==
                                Convert.ToInt32(gvUsrAuthGrp.GetRowCellValue(gvUsrAuthGrp.FocusedRowHandle, "ID"))));
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
    }
}