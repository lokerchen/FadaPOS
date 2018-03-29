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
    public partial class FrmTaDeliverySet : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        //是否为Add
        private bool isAdd = false;

        public FrmTaDeliverySet()
        {
            InitializeComponent();
        }

        public FrmTaDeliverySet(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        private void FrmTaDeliverySet_Load(object sender, EventArgs e)
        {
            BindData();

            GetOtherData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtDistFrom.Text = "";
            txtDistTo.Text = "";
            txtAmountToPay.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 保存Delivery Set 
            new SystemData().GetTaDeliverySet();

            var lstTds = CommonData.TaDeliverySet.ToList();

            TaDeliverySetInfo taDeliverySetInfo = new TaDeliverySetInfo();
            taDeliverySetInfo.PerMile = txtPerMile.Text;
            taDeliverySetInfo.IsDeliveryCharge = chkDeliveryChge.Checked ? "Y" : "N";
            taDeliverySetInfo.DeliveryMile = txtMile.Text;
            taDeliverySetInfo.IsIgnoreDelivery = chkIgnoreDelivery.Checked ? "Y" : "N";
            taDeliverySetInfo.OrderThreshold = txtOrderThreshold.Text;
            taDeliverySetInfo.SurchargeAmount = txtSurchargeAmount.Text;

            try
            {
                if (lstTds.Any())
                {
                    taDeliverySetInfo.ID = lstTds.FirstOrDefault().ID;
                    _control.UpdateEntity(taDeliverySetInfo);
                }
                else
                {
                    _control.AddEntity(taDeliverySetInfo);
                }

            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            if (!isAdd) return;
            #endregion

            #region 保存Delivery Set Detail
            if (string.IsNullOrEmpty(txtDistFrom.Text))
            {
                CommonTool.ShowMessage("Distance From can not NULL!");
                return;
            }

            if (string.IsNullOrEmpty(txtDistTo.Text))
            {
                CommonTool.ShowMessage("Distance To can not NULL!");
                return;
            }

            if (string.IsNullOrEmpty(txtAmountToPay.Text))
            {
                CommonTool.ShowMessage("Amount To Pay can not NULL!");
                return;
            }

            new SystemData().GetTaDeliverySetDetail();

            TaDeliverySetDetailInfo taDeliverySetDetailInfo = new TaDeliverySetDetailInfo();
            taDeliverySetDetailInfo.DistFrom = txtDistFrom.Text;
            taDeliverySetDetailInfo.DistTo = txtDistTo.Text;
            taDeliverySetDetailInfo.AmountToPay = txtAmountToPay.Text;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taDeliverySetDetailInfo);
                    isAdd = false;
                }
                else
                {
                    taDeliverySetDetailInfo.ID = Convert.ToInt32(gvDeliverySet.GetRowCellValue(gvDeliverySet.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taDeliverySetDetailInfo);
                }

                CommonTool.ShowMessage("Save successful!");

                BindData();
                GetOtherData();
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            #endregion
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaDeliverySetDetail.FirstOrDefault(s => s.ID == Convert.ToInt32(gvDeliverySet.GetRowCellValue(gvDeliverySet.FocusedRowHandle, "ID"))));
                    CommonTool.ShowMessage("Delete successful!");
                    BindData();
                    isAdd = false;
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }
        }

        private void BindData()
        {
            new SystemData().GetTaDeliverySetDetail();

            gridControlDeliverySet.DataSource = CommonData.TaDeliverySetDetail.ToList();

            gvDeliverySet.FocusedRowHandle = gvDeliverySet.RowCount - 1;
        }

        private void gvDeliverySet_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvDeliverySet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtDistFrom.Text = gvDeliverySet.GetRowCellValue(gvDeliverySet.FocusedRowHandle, "DistFrom").ToString();
            txtDistTo.Text = gvDeliverySet.GetRowCellValue(gvDeliverySet.FocusedRowHandle, "DistTo").ToString();
            txtAmountToPay.Text = gvDeliverySet.GetRowCellValue(gvDeliverySet.FocusedRowHandle, "AmountToPay").ToString();
        }

        private void GetOtherData()
        {
            new SystemData().GetTaDeliverySet();

            var lstTds = CommonData.TaDeliverySet.ToList();

            if (lstTds.Any())
            {
                TaDeliverySetInfo taDeliverySetInfo = lstTds.FirstOrDefault();
                txtPerMile.Text = taDeliverySetInfo.PerMile;
                chkDeliveryChge.Checked = taDeliverySetInfo.IsDeliveryCharge.Equals("Y");
                txtMile.Text = taDeliverySetInfo.DeliveryMile;
                chkIgnoreDelivery.Checked = taDeliverySetInfo.IsIgnoreDelivery.Equals("Y");
                txtOrderThreshold.Text = taDeliverySetInfo.OrderThreshold;
                txtSurchargeAmount.Text = taDeliverySetInfo.SurchargeAmount;
            }
            else
            {
                txtPerMile.Text = "";
                chkDeliveryChge.Checked = false;
                txtMile.Text = "";
                chkIgnoreDelivery.Checked = false;
                txtOrderThreshold.Text = "";
                txtSurchargeAmount.Text = "";
            }
        }
    }
}