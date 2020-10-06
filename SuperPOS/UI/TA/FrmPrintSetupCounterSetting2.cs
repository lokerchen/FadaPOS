using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.TA
{
    public partial class FrmPrintSetupCounterSetting2 : DevExpress.XtraEditors.XtraForm
    {
        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmPrintSetupCounterSetting2()
        {
            InitializeComponent();
        }

        private void FrmPrintSetupCounterSetting2_Load(object sender, EventArgs e)
        {
            BindLueAll();

            new SystemData().GetTaSysPrtSetCountSetting2();

            var lstcs2 = CommonData.TaSysPrtSetCounterSetting2;

            if (lstcs2.Any())
            {
                TaSysPrtSetCounterSetting2Info taSysPrtSetCounterSetting2 = lstcs2.FirstOrDefault();

                lueSoLocalPrinter.EditValue = taSysPrtSetCounterSetting2.SoLocalPriter;
                lueSoNumOfCopy.EditValue = taSysPrtSetCounterSetting2.SoNumOfCopy;
                lueSoPrtLang.EditValue = taSysPrtSetCounterSetting2.SoPrintLang;
                lueSoEngFontSize.EditValue = taSysPrtSetCounterSetting2.SoEngFontSize;
                lueSoOtherLangFont.EditValue = taSysPrtSetCounterSetting2.SoOtherLangFont;
                chkSoPrintDate.Checked = taSysPrtSetCounterSetting2.IsSoPrintDate.Equals("Y");
                chkSoPrintTime.Checked = taSysPrtSetCounterSetting2.IsSoPrintTime.Equals("Y");
                chkSoPrtVATNo.Checked = taSysPrtSetCounterSetting2.IsSoPrintVATNo.Equals("Y");
                lueSoDriverPrintoutCopy.EditValue = taSysPrtSetCounterSetting2.SoDriverPrintoutCopy;
                lueSoDeliveryAddressFont.EditValue = taSysPrtSetCounterSetting2.SoDeliveryAddrFont;
                chkSoPrintOrderNo.Checked = taSysPrtSetCounterSetting2.IsSoPrintOrderNo.Equals("Y");

                lueCoLocalPrinter.EditValue = taSysPrtSetCounterSetting2.CoLocalPriter;
                txtCoHeadWord.Text = taSysPrtSetCounterSetting2.CoHeadWord;
                lueCoPrtLang.EditValue = taSysPrtSetCounterSetting2.CoPrintLang;
                lueCoEngFontSize.EditValue = taSysPrtSetCounterSetting2.CoEngFontSize;
                lueCoOtherLangFont.EditValue = taSysPrtSetCounterSetting2.CoOtherLangFont;
                chkCoPrintDate.Checked = taSysPrtSetCounterSetting2.IsCoPrintDate.Equals("Y");
                chkCoPrintTime.Checked = taSysPrtSetCounterSetting2.IsCoPrintTime.Equals("Y");
                chkCoPrintOrderNo.Checked = taSysPrtSetCounterSetting2.IsCoPrintOrderNo.Equals("Y");
                chkCoPrtVATNo.Checked = taSysPrtSetCounterSetting2.IsCoPrintVATNo.Equals("Y");
                chkCoPrintVATCalculation.Checked = taSysPrtSetCounterSetting2.IsCoPrintVATCalculation.Equals("Y");
            }

            asfc.controllInitializeSize(this);
        }

        private void FrmPrintSetupCounterSetting2_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void BindLueAll()
        {
            lueSoLocalPrinter.Properties.DataSource = PrinterSettings.InstalledPrinters;
            lueCoLocalPrinter.Properties.DataSource = PrinterSettings.InstalledPrinters;

            lueSoNumOfCopy.Properties.DataSource = new List<string>(PubComm.PRT_NUMBER_OF_COPY);

            lueSoPrtLang.Properties.DataSource = new List<string>(PubComm.PRT_LANGUAGE);
            lueCoPrtLang.Properties.DataSource = new List<string>(PubComm.PRT_LANGUAGE);

            lueSoEngFontSize.Properties.DataSource = new List<string>(PubComm.PRT_FONT_SIZE);
            lueCoEngFontSize.Properties.DataSource = new List<string>(PubComm.PRT_FONT_SIZE);

            lueSoOtherLangFont.Properties.DataSource = new List<string>(PubComm.PRT_FONT_SIZE);
            lueCoOtherLangFont.Properties.DataSource = new List<string>(PubComm.PRT_FONT_SIZE);

            lueSoDriverPrintoutCopy.Properties.DataSource = new List<string>(PubComm.PRT_NUMBER_OF_COPY);

            lueSoDeliveryAddressFont.Properties.DataSource = new List<string>(PubComm.PRT_FONT_SIZE);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TaSysPrtSetCounterSetting2Info taSysPrtSetCounterSetting2 = new TaSysPrtSetCounterSetting2Info();

            taSysPrtSetCounterSetting2.SoLocalPriter = lueSoLocalPrinter.EditValue.ToString();
            taSysPrtSetCounterSetting2.SoNumOfCopy = lueSoNumOfCopy.EditValue.ToString();
            taSysPrtSetCounterSetting2.SoPrintLang = lueSoPrtLang.EditValue.ToString();
            taSysPrtSetCounterSetting2.SoEngFontSize = lueSoEngFontSize.EditValue.ToString();
            taSysPrtSetCounterSetting2.SoOtherLangFont = lueSoOtherLangFont.EditValue.ToString();
            taSysPrtSetCounterSetting2.IsSoPrintDate = chkSoPrintDate.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting2.IsSoPrintTime = chkSoPrintTime.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting2.IsSoPrintVATNo = chkSoPrtVATNo.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting2.SoDriverPrintoutCopy = lueSoDriverPrintoutCopy.EditValue.ToString();
            taSysPrtSetCounterSetting2.SoDeliveryAddrFont = lueSoDeliveryAddressFont.EditValue.ToString();
            taSysPrtSetCounterSetting2.IsSoPrintOrderNo = chkSoPrintOrderNo.Checked ? "Y" : "N";

            taSysPrtSetCounterSetting2.CoLocalPriter = lueCoLocalPrinter.EditValue.ToString();
            taSysPrtSetCounterSetting2.CoHeadWord = txtCoHeadWord.Text;
            taSysPrtSetCounterSetting2.CoPrintLang = lueCoPrtLang.EditValue.ToString();
            taSysPrtSetCounterSetting2.CoEngFontSize = lueCoEngFontSize.EditValue.ToString();
            taSysPrtSetCounterSetting2.CoOtherLangFont = lueCoOtherLangFont.EditValue.ToString();
            taSysPrtSetCounterSetting2.IsCoPrintDate = chkCoPrintDate.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting2.IsCoPrintTime = chkCoPrintTime.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting2.IsCoPrintOrderNo = chkCoPrintOrderNo.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting2.IsCoPrintVATNo = chkCoPrtVATNo.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting2.IsCoPrintVATCalculation = chkCoPrintVATCalculation.Checked ? "Y" : "N";

            try
            {
                new SystemData().GetTaSysPrtSetCountSetting2();

                var lstcs2 = CommonData.TaSysPrtSetCounterSetting2;

                if (lstcs2.Any())
                {
                    taSysPrtSetCounterSetting2.ID = lstcs2.FirstOrDefault().ID;
                    _control.UpdateEntity(taSysPrtSetCounterSetting2);
                }
                else
                {
                    _control.AddEntity(taSysPrtSetCounterSetting2);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Hide();
        }
    }
}