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
    public partial class FrmCompAddr : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";
        //新增/更新
        private bool isAdd = false;

        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmCompAddr()
        {
            InitializeComponent();
        }

        public FrmCompAddr(int id, string sUsrName)
        {
            InitializeComponent();
            usrID = id;
            usrName = sUsrName;
        }

        private void FrmCompAddr_Load(object sender, EventArgs e)
        {
            gvCompAddr.BestFitColumns();
            BindData();

            asfc.controllInitializeSize(this);
        }

        private void gvCompAddr_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtAddrCode.Text = "";
            txtCompName.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddrCode.Text))
            {
                CommonTool.ShowMessage("Address Code can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtCompName.Text))
            {
                CommonTool.ShowMessage("Computer Name can not empty!");
                return;
            }
            CompAddrInfo compAddrInfo = new CompAddrInfo();
            compAddrInfo.AddrCode = txtAddrCode.Text;
            compAddrInfo.CompName = txtCompName.Text;

            try
            {
                if (isAdd)
                    _control.AddEntity(compAddrInfo);
                else
                {
                    compAddrInfo.ID = Convert.ToInt32(gvCompAddr.GetRowCellValue(gvCompAddr.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(compAddrInfo);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }


            BindData();

            isAdd = false;

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CommonTool.ConfirmDelete() == DialogResult.Cancel)
                return;
            else
            {
                _control.DeleteEntity(CommonData.CompAddr.FirstOrDefault(s => s.ID == Convert.ToInt32(gvCompAddr.GetRowCellValue(gvCompAddr.FocusedRowHandle, "ID"))));
                BindData();
            }
        }

        private void BindData()
        {
            new SystemData().GetCompAddr();

            gridControlCompAddr.DataSource = CommonData.CompAddr.ToList();

            gvCompAddr.FocusedRowHandle = gvCompAddr.RowCount - 1;
        }

        private void gvCompAddr_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtAddrCode.Text = gvCompAddr.GetRowCellValue(gvCompAddr.FocusedRowHandle, "AddrCode").ToString();
            txtCompName.Text = gvCompAddr.GetRowCellValue(gvCompAddr.FocusedRowHandle, "CompName").ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCompAddr_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}