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
    public partial class FrmPrintSetupKitchenSetting : DevExpress.XtraEditors.XtraForm
    {
        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmPrintSetupKitchenSetting()
        {
            InitializeComponent();
        }

        private void FrmPrintSetupKitchenSetting_Load(object sender, EventArgs e)
        {
            BindLueAll();

            new SystemData().GetTaSysPrtSetKitchen();

            var lstKit = CommonData.TaSysPrtSetKitchen;

            if (lstKit.Any())
            {
                TaSysPrtSetKitchenInfo taSysPrtSetKitchen = lstKit.FirstOrDefault();

                luePrintLang.EditValue = taSysPrtSetKitchen.PrintLang;
                luePrintPrice.EditValue = taSysPrtSetKitchen.PrintPriceDishCode;
                lueEngFontSize.EditValue = taSysPrtSetKitchen.EngFontSize;
                lueOtherFontSize.EditValue = taSysPrtSetKitchen.OtherFontSize;
                lueDeliveryAddr.EditValue = taSysPrtSetKitchen.DeliveryAddr;

                chkPrintAsc.Checked = taSysPrtSetKitchen.IsPrintAsc.Equals("Y");
                chkPrintDate.Checked = taSysPrtSetKitchen.IsPrintDate.Equals("Y");
                chkPrintTime.Checked = taSysPrtSetKitchen.IsPrintTime.Equals("Y");
                chkPrintPayType.Checked = taSysPrtSetKitchen.IsPrintPayType.Equals("Y");
                chkPrintDeliveryAddr.Checked = taSysPrtSetKitchen.IsPrintDeliveryAddr.Equals("Y");
                chkPrintOrderNo.Checked = taSysPrtSetKitchen.IsPrintOrderNo.Equals("Y");
            }
            
            asfc.controllInitializeSize(this);
        }

        private void FrmPrintSetupKitchenSetting_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void BindLueAll()
        {
            luePrintLang.Properties.DataSource = new List<string>(PubComm.PRT_LANGUAGE);
            luePrintPrice.Properties.DataSource = new List<string>(PubComm.PRT_KITCHEN_PRINT_PRICE_DISH_CODE);
            lueEngFontSize.Properties.DataSource = new List<string>(PubComm.PRT_KITCHEN_FONT_SIZE);
            lueOtherFontSize.Properties.DataSource = new List<string>(PubComm.PRT_KITCHEN_FONT_SIZE);
            lueDeliveryAddr.Properties.DataSource = new List<string>(PubComm.PRT_KITCHEN_FONT_SIZE);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TaSysPrtSetKitchenInfo taSysPrtSetKitchen = new TaSysPrtSetKitchenInfo();

            taSysPrtSetKitchen.PrintLang = luePrintLang.EditValue.ToString();
            taSysPrtSetKitchen.PrintPriceDishCode = luePrintPrice.EditValue.ToString();
            taSysPrtSetKitchen.EngFontSize = lueEngFontSize.EditValue.ToString();
            taSysPrtSetKitchen.OtherFontSize = lueOtherFontSize.EditValue.ToString();
            taSysPrtSetKitchen.DeliveryAddr = lueDeliveryAddr.EditValue.ToString();

            taSysPrtSetKitchen.IsPrintAsc = chkPrintAsc.Checked ? "Y" : "N";
            taSysPrtSetKitchen.IsPrintDate = chkPrintDate.Checked ? "Y" : "N";
            taSysPrtSetKitchen.IsPrintTime = chkPrintTime.Checked ? "Y" : "N";
            taSysPrtSetKitchen.IsPrintPayType = chkPrintPayType.Checked ? "Y" : "N";
            taSysPrtSetKitchen.IsPrintDeliveryAddr = chkPrintDeliveryAddr.Checked ? "Y" : "N";
            taSysPrtSetKitchen.IsPrintOrderNo = chkPrintOrderNo.Checked ? "Y" : "N";

            try
            {
                new SystemData().GetTaSysPrtSetKitchen();

                var lstKit = CommonData.TaSysPrtSetKitchen;

                if (lstKit.Any())
                {
                    taSysPrtSetKitchen.ID = lstKit.FirstOrDefault().ID;
                    _control.UpdateEntity(taSysPrtSetKitchen);
                }
                else
                {
                    _control.AddEntity(taSysPrtSetKitchen);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Hide();}
    }
}