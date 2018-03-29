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
    public partial class FrmTaCustomerInfo : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";
        //新增/更新
        private bool isAdd = false;

        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        //来电号码
        private string cusNum = "";

        public FrmTaCustomerInfo()
        {
            InitializeComponent();
        }

        public FrmTaCustomerInfo(string sComePhoe)
        {
            InitializeComponent();
            cusNum = sComePhoe;
        }

        private void FrmTaCustomerInfo_Load(object sender, EventArgs e)
        {
            BindData(cusNum);
            gvCompCustomer.BestFitColumns();
            asfc.controllInitializeSize(this);
        }

        private void gvCompCustomer_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvCompCustomer.RowCount < 1) return;
            txtPhone.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPhone").ToString();
            txtName.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusName").ToString();
            txtHouseNo.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusHouseNo").ToString();
            txtAddress.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusAddr").ToString();
            txtPostcode.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode").ToString();
            txtDistance.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDistance").ToString();
            txtPcZone.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPcZone").ToString();
            txtDelCharge.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDelCharge").ToString();
            txtReadyTime.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusReadyTime").ToString();
            txtIntNotes.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIntNotes").ToString();
            txtNotesOnBill.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusNotesOnBill").ToString();
            chkBlackListed.Checked = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIsBlack").ToString().Equals("Y") ? true : false;
        }

        private void BindData(string sPhone)
        {
            new SystemData().GetTaCustomer();

            gridControlCustomer.DataSource = string.IsNullOrEmpty(sPhone) ? CommonData.TaCustomer.ToList() : CommonData.TaCustomer.Where(s => s.cusPhone.Equals(sPhone)).ToList();
            gvCompCustomer.FocusedRowHandle = gvCompCustomer.RowCount - 1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtPhone.Text = "";
            txtName.Text = "";
            txtHouseNo.Text = "";
            txtAddress.Text = "";
            txtPostcode.Text = "";
            txtDistance.Text = "";
            txtPcZone.Text = "";
            txtDelCharge.Text = "";
            txtReadyTime.Text = "";
            txtIntNotes.Text = "";
            txtNotesOnBill.Text = "";
            chkBlackListed.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 空判断
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                CommonTool.ShowMessage("Phone can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                CommonTool.ShowMessage("Name can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtHouseNo.Text))
            {
                CommonTool.ShowMessage("HouseNo. can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                CommonTool.ShowMessage("Address can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtPostcode.Text))
            {
                CommonTool.ShowMessage("Postcode can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtDistance.Text))
            {
                CommonTool.ShowMessage("Distance can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtPcZone.Text))
            {
                CommonTool.ShowMessage("PC Zone can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtDelCharge.Text))
            {
                CommonTool.ShowMessage("Del Charge can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtReadyTime.Text))
            {
                CommonTool.ShowMessage("Ready Time can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtIntNotes.Text))
            {
                CommonTool.ShowMessage("Int Notes can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtNotesOnBill.Text))
            {
                CommonTool.ShowMessage("Notes On Bill can not empty!");
                return;
            }
            #endregion

            TaCustomerInfo taCustomerInfo = new TaCustomerInfo();
            taCustomerInfo.cusPhone = txtPhone.Text;
            taCustomerInfo.cusName = txtName.Text;
            taCustomerInfo.cusHouseNo = txtHouseNo.Text;
            taCustomerInfo.cusAddr = txtAddress.Text;
            taCustomerInfo.cusPostcode = txtPostcode.Text;
            taCustomerInfo.cusDistance = txtDistance.Text;
            taCustomerInfo.cusPcZone = txtPcZone.Text;
            taCustomerInfo.cusDelCharge = txtDelCharge.Text;
            taCustomerInfo.cusReadyTime = txtReadyTime.Text;
            taCustomerInfo.cusIntNotes = txtIntNotes.Text;
            taCustomerInfo.cusNotesOnBill = txtNotesOnBill.Text;
            taCustomerInfo.cusPhone = chkBlackListed.Checked ? "Y" : "N";

            try
            {
                if (isAdd) _control.AddEntity(taCustomerInfo);
                else
                {
                    taCustomerInfo.ID = Convert.ToInt32(gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taCustomerInfo);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            BindData("");

            isAdd = false;

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CommonTool.ConfirmDelete() == DialogResult.Cancel)
                return;
            else
            {
                if (gvCompCustomer.RowCount < 1) return;

                _control.DeleteEntity(CommonData.TaCustomer.FirstOrDefault(s => s.ID == Convert.ToInt32(gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "ID"))));
                BindData("");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (CommonTool.ConfirmDelete() == DialogResult.Cancel)
                return;
            else
            {
                if (gvCompCustomer.RowCount < 1) return;

                foreach (var taCustomerInfo in CommonData.TaCustomer)
                {
                    _control.DeleteEntity(taCustomerInfo);
                }
                BindData("");
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void FrmTaCustomerInfo_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}