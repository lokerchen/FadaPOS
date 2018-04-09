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

        private readonly EntityControl _control = new EntityControl();

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
            SaveData();
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
            if (string.IsNullOrEmpty(isYesOrNo)) return false;
            else return isYesOrNo.Equals("Y") ? true : false;
        }

        private void SetData(string sPayName)
        {
            new SystemData().GetSysUsrMaintenance();
            var lstMaint = CommonData.SysUsrMaintenance.Where(s => s.UsrID == Convert.ToInt32(lueUsrName.EditValue));

            if (!lstMaint.Any())
            {
                #region 初始化

                chkTaControlPanel.Checked = false;
                chkTaChangePrice.Checked = false;
                chkTaPriceOff.Checked = false;
                chkTaShowOrderPrintAcctSum.Checked = false;
                chkTaShowOrderChangePaym.Checked = false;
                chkTaShowOrderEditOrder.Checked = false;
                chkTaShowOrderPrtReceipt.Checked = false;
                chkTaShowOrderExportData.Checked = false;

                chkEiControlPanel.Checked = false;
                chkEiChangePrice.Checked = false;
                chkEiPriceOff.Checked = false;
                chkEiPay.Checked = false;
                chkEiPrintBill.Checked = false;
                chkEiRemoveItemAfterPrint.Checked = false;
                chkEiTblBooking.Checked = false;
                chkEiShowOrderPrintAcctSum.Checked = false;
                chkEiShowOrderChangePaym.Checked = false;
                chkEiShowOrderEditOrder.Checked = false;
                chkEiShowOrderPrintReceipt.Checked = false;

                chkGaSysConf.Checked = false;
                chkGaSysUsrMaint.Checked = false;
                chkGaSysDataManager.Checked = false;
                chkGaSysCompactDb.Checked = false;
                chkGaRptReport.Checked = false;
                chkGaRptAccountSum.Checked = false;
                chkGaAccountSumView.Checked = false;
                chkGaLogExitPos.Checked = false;
                chkGaWriteAndEnableInventory.Checked = false;
                chkGaSysComputerAdd.Checked = false;
                chkGaSysShiftCode.Checked = false;
                chkGaTaConf.Checked = false;
                chkGaEiConf.Checked = false;
                chkGaTaPrintSetup.Checked = false;
                chkGaEiPrintSetup.Checked = false;
                chkGaAccountSumPrintSaleRpt.Checked = false;
                chkGaOpenCashDrawer.Checked = false;

                #endregion
            }
            else
            {
                SysUsrMaintenanceInfo usrMaintenance = new SysUsrMaintenanceInfo();

                usrMaintenance = lstMaint.FirstOrDefault();

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

        private void SaveData()
        {
            SysUsrMaintenanceInfo usrMaintenance = new SysUsrMaintenanceInfo();

            try
            {
                //xtpTa"
                usrMaintenance.TaControlPanel = ChangeBoolToYesOrNo(chkTaControlPanel.Checked);
                usrMaintenance.TaChangePrice = ChangeBoolToYesOrNo(chkTaChangePrice.Checked);
                usrMaintenance.TaPriceOff = ChangeBoolToYesOrNo(chkTaPriceOff.Checked);
                usrMaintenance.TaShowOrderPrtAcctSummary = ChangeBoolToYesOrNo(chkTaShowOrderPrintAcctSum.Checked);
                usrMaintenance.TaShowOrderChangePayment = ChangeBoolToYesOrNo(chkTaShowOrderChangePaym.Checked);
                usrMaintenance.TaShowOrderEditOrder = ChangeBoolToYesOrNo(chkTaShowOrderEditOrder.Checked);
                usrMaintenance.TaShowOrderPrtReceipt = ChangeBoolToYesOrNo(chkTaShowOrderPrtReceipt.Checked);
                usrMaintenance.TaShowOrderExportData = ChangeBoolToYesOrNo(chkTaShowOrderExportData.Checked);

                //xtpEi"
                usrMaintenance.EiControlPanel = ChangeBoolToYesOrNo(chkEiControlPanel.Checked);
                usrMaintenance.EiChangePrice = ChangeBoolToYesOrNo(chkEiChangePrice.Checked);
                usrMaintenance.EiPriceOff = ChangeBoolToYesOrNo(chkEiPriceOff.Checked);
                usrMaintenance.EiPay = ChangeBoolToYesOrNo(chkEiPay.Checked);
                usrMaintenance.EiPrtBill = ChangeBoolToYesOrNo(chkEiPrintBill.Checked);
                usrMaintenance.EiRemoveItemAfterPrt = ChangeBoolToYesOrNo(chkEiRemoveItemAfterPrint.Checked);
                usrMaintenance.EiTableBooking = ChangeBoolToYesOrNo(chkEiTblBooking.Checked);
                usrMaintenance.EiShowOrderPrtAcctSummary = ChangeBoolToYesOrNo(chkEiShowOrderPrintAcctSum.Checked);
                usrMaintenance.EiShowOrderChangePayment = ChangeBoolToYesOrNo(chkEiShowOrderChangePaym.Checked);
                usrMaintenance.EiShowOrderEditOrder = ChangeBoolToYesOrNo(chkEiShowOrderEditOrder.Checked);
                usrMaintenance.EiShowOrderPrtReceipt = ChangeBoolToYesOrNo(chkEiShowOrderPrintReceipt.Checked);

                //xtpGa"
                usrMaintenance.GaSysConf = ChangeBoolToYesOrNo(chkGaSysConf.Checked);
                usrMaintenance.GaSysUsrMaint = ChangeBoolToYesOrNo(chkGaSysUsrMaint.Checked);
                usrMaintenance.GaSysDataManager = ChangeBoolToYesOrNo(chkGaSysDataManager.Checked);
                usrMaintenance.GaSysCompactDb = ChangeBoolToYesOrNo(chkGaSysCompactDb.Checked);
                usrMaintenance.GaRptReport = ChangeBoolToYesOrNo(chkGaRptReport.Checked);
                usrMaintenance.GaRptAccountSummary = ChangeBoolToYesOrNo(chkGaRptAccountSum.Checked);
                usrMaintenance.GaAsSumView = ChangeBoolToYesOrNo(chkGaAccountSumView.Checked);
                usrMaintenance.GaLogonExit = ChangeBoolToYesOrNo(chkGaLogExitPos.Checked);
                usrMaintenance.GaWriteAndEnableInv = ChangeBoolToYesOrNo(chkGaWriteAndEnableInventory.Checked);
                usrMaintenance.GaSysComputerAdd = ChangeBoolToYesOrNo(chkGaSysComputerAdd.Checked);
                usrMaintenance.GaSysShiftCode = ChangeBoolToYesOrNo(chkGaSysShiftCode.Checked);
                usrMaintenance.GaTaConf = ChangeBoolToYesOrNo(chkGaTaConf.Checked);
                usrMaintenance.GaEiConf = ChangeBoolToYesOrNo(chkGaEiConf.Checked);
                usrMaintenance.GaTaPrtSetup = ChangeBoolToYesOrNo(chkGaTaPrintSetup.Checked);
                usrMaintenance.GaEiPrtSetup = ChangeBoolToYesOrNo(chkGaEiPrintSetup.Checked);
                usrMaintenance.GaAsPrtSaleRpt = ChangeBoolToYesOrNo(chkGaAccountSumPrintSaleRpt.Checked);
                usrMaintenance.GaOpenCashDrawer = ChangeBoolToYesOrNo(chkGaOpenCashDrawer.Checked);

                new SystemData().GetSysUsrMaintenance();
                var lstMaint = CommonData.SysUsrMaintenance.Where(s => s.UsrID == Convert.ToInt32(lueUsrName.EditValue));

                usrMaintenance.UsrID = Convert.ToInt32(lueUsrName.EditValue);

                if (lstMaint.Any())
                {
                    usrMaintenance.ID = lstMaint.FirstOrDefault().ID;
                    _control.UpdateEntity(usrMaintenance);
                }
                else
                {
                    _control.AddEntity(usrMaintenance);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }
    }
}