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

namespace SuperPOS.UI.TaAdmin
{
    public partial class FrmTaAdminUsrMaintenance : DevExpress.XtraEditors.XtraForm
    {
        //用户ID
        public int usrID = 0;
        //用户姓名
        public string usrName = "";

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private List<SysUsrMaintenanceInfo> lstUsrMain = new List<SysUsrMaintenanceInfo>(); 

        public FrmTaAdminUsrMaintenance()
        {
            InitializeComponent();
        }

        public FrmTaAdminUsrMaintenance(int uID, string sName)
        {
            InitializeComponent();
            usrID = uID;
            usrName = sName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTaAdminUsrMaintenance_Load(object sender, EventArgs e)
        {
            BindLueUsrData();

            lueUsrName.ItemIndex = 0;

            this.xtpUsrAccess.SelectedTabPageIndex = 0;

            asfc.controllInitializeSize(this);
        }

        private void FrmTaAdminUsrMaintenance_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        #region 绑定User列表
        /// <summary>
        /// 绑定User列表
        /// </summary>
        private void BindLueUsrData()
        {
            new SystemData().GetUsrBase();

            var lstShiftCode = from usr in CommonData.UsrBase
                               select new
                               {
                                   ScID = usr.ID,
                                   ScName = usr.UsrName
                               };
            lueUsrName.Properties.DataSource = lstShiftCode.ToList();
            lueUsrName.Properties.DisplayMember = "ScName";
            lueUsrName.Properties.ValueMember = "ScID";
        }
        #endregion

        private void lueUsrName_EditValueChanged(object sender, EventArgs e)
        {
            this.xtpUsrAccess.SelectedTabPageIndex = 0;

            SetData(xtpUsrAccess.SelectedTabPage.Name);
        }

        private void xtpUsrAccess_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {
            SetData(e.Page.Name);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnAddUpdateUser_Click(object sender, EventArgs e)
        {

        }

        private string ChangeBoolToYesOrNo(bool isChecked)
        {
            return isChecked ? "Y" : "N";
        }

        private bool YesOrNoToBool(string isYesOrNo)
        {
            return isYesOrNo.Equals("Y") ? true : false;
        }

        private void SetData(string sPayName)
        {
            new SystemData().GetSysUsrMaintenance();
            var lstMaint = CommonData.SysUsrMaintenance.Where(s => s.UsrID == Convert.ToInt32(lueUsrName.EditValue));

            if (!lstMaint.Any()) return;

            SysUsrMaintenanceInfo usrMaintenance = new SysUsrMaintenanceInfo();

            if (sPayName.Equals("xtpTa"))
            {
                chkTaControlPanel.Checked = YesOrNoToBool(usrMaintenance.TaControlPanel);
                chkTaChangePrice.Checked = YesOrNoToBool(usrMaintenance.TaChangePrice);
                chkTaPriceOff.Checked = YesOrNoToBool(usrMaintenance.TaPriceOff);
                chkTaShowOrderPrintAcctSum.Checked = YesOrNoToBool(usrMaintenance.TaShowOrderPrtAcctSummary);
                chkTaShowOrderChangePaym.Checked = YesOrNoToBool(usrMaintenance.TaShowOrderChangePayment);
                chkTaShowOrderEditOrder.Checked = YesOrNoToBool(usrMaintenance.TaShowOrderEditOrder);
                chkTaShowOrderPrtReceipt.Checked = YesOrNoToBool(usrMaintenance.TaShowOrderPrtReceipt);
                chkTaShowOrderExportData.Checked = YesOrNoToBool(usrMaintenance.TaShowOrderExportData);
            }
            else if (sPayName.Equals("xtpEi"))
            {
                chkEiControlPanel.Checked = YesOrNoToBool(usrMaintenance.EiControlPanel);
                chkEiChangePrice.Checked = YesOrNoToBool(usrMaintenance.EiChangePrice);
                chkEiPriceOff.Checked = YesOrNoToBool(usrMaintenance.EiPriceOff);
                chkEiPay.Checked = YesOrNoToBool(usrMaintenance.EiPay);
                chkEiPrintBill.Checked = YesOrNoToBool(usrMaintenance.EiPrtBill);
                chkEiRemoveItemAfterPrint.Checked = YesOrNoToBool(usrMaintenance.EiRemoveItemAfterPrt);
                chkEiTblBooking.Checked = YesOrNoToBool(usrMaintenance.EiTableBooking);
                chkEiShowOrderPrintAcctSum.Checked = YesOrNoToBool(usrMaintenance.EiShowOrderPrtAcctSummary);
                chkEiShowOrderChangePaym.Checked = YesOrNoToBool(usrMaintenance.EiShowOrderChangePayment);
                chkEiShowOrderEditOrder.Checked = YesOrNoToBool(usrMaintenance.EiShowOrderEditOrder);
                chkEiShowOrderPrintReceipt.Checked = YesOrNoToBool(usrMaintenance.EiShowOrderPrtReceipt);
            }
            else if (sPayName.Equals("xtpGa"))
            {
                chkGaSysConf.Checked = YesOrNoToBool(usrMaintenance.GaSysConf);
                chkGaSysUsrMaint.Checked = YesOrNoToBool(usrMaintenance.GaSysUsrMaint);
                chkGaSysDataManager.Checked = YesOrNoToBool(usrMaintenance.GaSysDataManager);
                chkGaSysCompactDb.Checked = YesOrNoToBool(usrMaintenance.GaSysCompactDb);
                chkGaRptReport.Checked = YesOrNoToBool(usrMaintenance.GaRptReport);
                chkGaRptAccountSum.Checked = YesOrNoToBool(usrMaintenance.GaRptAccountSummary);
                chkGaAccountSumView.Checked = YesOrNoToBool(usrMaintenance.GaAsSumView);
                chkGaLogExitPos.Checked = YesOrNoToBool(usrMaintenance.GaLogonExit);
                chkGaWriteAndEnableInventory.Checked = YesOrNoToBool(usrMaintenance.GaWriteAndEnableInv);
                chkGaSysComputerAdd.Checked = YesOrNoToBool(usrMaintenance.GaSysComputerAdd);
                chkGaSysShiftCode.Checked = YesOrNoToBool(usrMaintenance.GaSysShiftCode);
                chkGaTaConf.Checked = YesOrNoToBool(usrMaintenance.GaTaConf);
                chkGaEiConf.Checked = YesOrNoToBool(usrMaintenance.GaEiConf);
                chkGaTaPrintSetup.Checked = YesOrNoToBool(usrMaintenance.GaTaPrtSetup);
                chkGaEiPrintSetup.Checked = YesOrNoToBool(usrMaintenance.GaEiPrtSetup);
                chkGaAccountSumPrintSaleRpt.Checked = YesOrNoToBool(usrMaintenance.GaAsPrtSaleRpt);
                chkGaOpenCashDrawer.Checked = YesOrNoToBool(usrMaintenance.GaOpenCashDrawer);
            }
        }
    }
}