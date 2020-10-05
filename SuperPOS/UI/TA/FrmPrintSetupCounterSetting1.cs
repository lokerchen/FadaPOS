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
    public partial class FrmPrintSetupCounterSetting1 : DevExpress.XtraEditors.XtraForm
    {
        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmPrintSetupCounterSetting1()
        {
            InitializeComponent();
        }

        private void FrmPrintSetupCounterSetting1_Load(object sender, EventArgs e)
        {
            BindLueAll();

            new SystemData().GetTaSysPrtSetCountSetting1();

            var lstcs1 = CommonData.TaSysPrtSetCounterSetting1;

            if (lstcs1.Any())
            {
                TaSysPrtSetCounterSetting1Info taSysPrtSetCounterSetting1 = lstcs1.FirstOrDefault();

                lueSOLocalPrinter.EditValue = taSysPrtSetCounterSetting1.SoLocalPrinter;
                lueSONumOfCopy.EditValue = taSysPrtSetCounterSetting1.SoNumOfCopy;
                lueSOPrtLang.EditValue = taSysPrtSetCounterSetting1.SoPrtLang;
                lueSOEngFontSize.EditValue = taSysPrtSetCounterSetting1.SoEngFontSize;
                lueSOOtherFontSize.EditValue = taSysPrtSetCounterSetting1.SoOtherFontSize;
                chkSOPrtDate.Checked = taSysPrtSetCounterSetting1.IsSoPrtDate.Equals("Y");
                chkSOPrtOrderNoSlip.Checked = taSysPrtSetCounterSetting1.IsSoPrtOrderNoSlip.Equals("Y");
                chkSOPrtVATNo.Checked = taSysPrtSetCounterSetting1.IsSoPrtVATNo.Equals("Y");
                chkSOPrtRefNum.Checked = taSysPrtSetCounterSetting1.IsSoRefNum.Equals("Y");
                chkSOPrtOrderNo.Checked = taSysPrtSetCounterSetting1.IsSoOrderNo.Equals("Y");

                lueCOLocalPrinter.EditValue = taSysPrtSetCounterSetting1.CoLocalPrinter;
                lueCONumOfCopy.EditValue = taSysPrtSetCounterSetting1.CoNumOfCopy;
                lueCOPrtLang.EditValue = taSysPrtSetCounterSetting1.CoPrtLang;
                lueCOEngFontSize.EditValue = taSysPrtSetCounterSetting1.CoEngFontSize;
                lueCOOtherFontSize.EditValue = taSysPrtSetCounterSetting1.CoOtherFontSize;
                chkCOPrtDate.Checked = taSysPrtSetCounterSetting1.IsCoPrtDate.Equals("Y");
                chkCOPrtOrderNoSlip.Checked = taSysPrtSetCounterSetting1.IsCoPrtOrderNoSlip.Equals("Y");
                chkCOPrtVATNo.Checked = taSysPrtSetCounterSetting1.IsCoPrtVATNo.Equals("Y");
                chkCOPrtRefNum.Checked = taSysPrtSetCounterSetting1.IsCoRefNum.Equals("Y");
                chkCOPrtOrderNo.Checked = taSysPrtSetCounterSetting1.IsCoOrderNo.Equals("Y");
            }

            asfc.controllInitializeSize(this);
        }

        private void FrmPrintSetupCounterSetting1_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TaSysPrtSetCounterSetting1Info taSysPrtSetCounterSetting1 = new TaSysPrtSetCounterSetting1Info();

            taSysPrtSetCounterSetting1.SoLocalPrinter = lueSOLocalPrinter.EditValue.ToString();
            taSysPrtSetCounterSetting1.SoNumOfCopy = lueSONumOfCopy.EditValue.ToString();
            taSysPrtSetCounterSetting1.SoPrtLang = lueSOPrtLang.EditValue.ToString();
            taSysPrtSetCounterSetting1.SoEngFontSize = lueSOEngFontSize.EditValue.ToString();
            taSysPrtSetCounterSetting1.SoOtherFontSize = lueSOOtherFontSize.EditValue.ToString();
            taSysPrtSetCounterSetting1.IsSoPrtDate = chkSOPrtDate.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting1.IsSoPrtOrderNoSlip = chkSOPrtOrderNoSlip.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting1.IsSoPrtVATNo = chkSOPrtVATNo.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting1.IsSoRefNum = chkSOPrtRefNum.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting1.IsSoOrderNo = chkSOPrtOrderNo.Checked ? "Y" : "N";

            taSysPrtSetCounterSetting1.CoLocalPrinter = lueCOLocalPrinter.EditValue.ToString();
            taSysPrtSetCounterSetting1.CoNumOfCopy = lueCONumOfCopy.EditValue.ToString();
            taSysPrtSetCounterSetting1.CoPrtLang = lueCOPrtLang.EditValue.ToString();
            taSysPrtSetCounterSetting1.CoEngFontSize = lueCOEngFontSize.EditValue.ToString();
            taSysPrtSetCounterSetting1.CoOtherFontSize = lueCOOtherFontSize.EditValue.ToString();
            taSysPrtSetCounterSetting1.IsCoPrtDate = chkCOPrtDate.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting1.IsCoPrtOrderNoSlip = chkCOPrtOrderNoSlip.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting1.IsCoPrtVATNo = chkCOPrtVATNo.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting1.IsCoRefNum = chkCOPrtRefNum.Checked ? "Y" : "N";
            taSysPrtSetCounterSetting1.IsCoOrderNo = chkCOPrtOrderNo.Checked ? "Y" : "N";

            try
            {
                new SystemData().GetTaSysPrtSetCountSetting1();

                var lstcs1 = CommonData.TaSysPrtSetCounterSetting1;

                if (lstcs1.Any())
                {
                    taSysPrtSetCounterSetting1.ID = lstcs1.FirstOrDefault().ID;
                    _control.UpdateEntity(taSysPrtSetCounterSetting1);
                }
                else
                {
                    _control.AddEntity(taSysPrtSetCounterSetting1);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void BindLueAll()
        {
            lueSOLocalPrinter.Properties.DataSource = PrinterSettings.InstalledPrinters;
            lueCOLocalPrinter.Properties.DataSource = PrinterSettings.InstalledPrinters;

            lueSONumOfCopy.Properties.DataSource = new List<string>(PubComm.PRT_NUMBER_OF_COPY);
            lueCONumOfCopy.Properties.DataSource = new List<string>(PubComm.PRT_NUMBER_OF_COPY);

            lueSOPrtLang.Properties.DataSource = new List<string>(PubComm.PRT_LANGUAGE);
            lueCOPrtLang.Properties.DataSource = new List<string>(PubComm.PRT_LANGUAGE);

            lueSOEngFontSize.Properties.DataSource = new List<string>(PubComm.PRT_FONT_SIZE);
            lueSOOtherFontSize.Properties.DataSource = new List<string>(PubComm.PRT_FONT_SIZE);
            lueCOEngFontSize.Properties.DataSource = new List<string>(PubComm.PRT_FONT_SIZE);
            lueCOOtherFontSize.Properties.DataSource = new List<string>(PubComm.PRT_FONT_SIZE);
        }
    }
}