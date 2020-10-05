using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.TA
{
    public partial class FrmPrintSetup : DevExpress.XtraEditors.XtraForm
    {
        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();
        
        public FrmPrintSetup()
        {
            InitializeComponent();
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            //FrmPrintSetupGeneral frmPrintSetupGeneral = new FrmPrintSetupGeneral();
            //frmPrintSetupGeneral.Location = panelBox.Location;
            //frmPrintSetupGeneral.Size = panelBox.Size;

            //if (frmPrintSetupGeneral.ShowDialog() == DialogResult.OK)
            //{
                
            //}
        }

        private void FrmPrintSetup_Load(object sender, EventArgs e)
        {
            new SystemData().GetTaSysPrtSetGeneral();

            var lstGen = CommonData.TaSysPrtSetGeneral;

            if (lstGen.Any())
            {
                TaSysPrtSetGeneralInfo generalInfo = lstGen.FirstOrDefault();

                chkPrtLogo.Checked = generalInfo.IsPrtLogo.Equals("Y");
                if (chkPrtLogo.Checked)
                {
                    lblFilePath.Visible = true;
                    lblFileUpload.Visible = true;
                    btnFileUpload.Visible = true;
                }
                else
                {
                    lblFilePath.Visible = false;
                    lblFileUpload.Visible = false;
                    btnFileUpload.Visible = false;
                }

                chkPrtStaff.Checked = generalInfo.IsPrtStaff.Equals("Y");
                chkPrtTel.Checked = generalInfo.IsPrtTel.Equals("Y");
                chkPrtAddr.Checked = generalInfo.IsPrtAddr.Equals("Y");

                txtTelNo.Text = generalInfo.TelNo;
                txtVatNo.Text = generalInfo.VATNo;
                txtMsg1.Text = generalInfo.Msg1;
                txtMsg2.Text = generalInfo.Msg2;
                txtMsg3.Text = generalInfo.Msg3;
                txtMsg4.Text = generalInfo.Msg4;
                txtMsg5.Text = generalInfo.Msg5;
            }
            else
            {
                chkPrtLogo.Checked = false;
                lblFilePath.Visible = false;
                lblFileUpload.Visible = false;
                btnFileUpload.Visible = false;

                chkPrtStaff.Checked = false;
                chkPrtTel.Checked = false;
                chkPrtAddr.Checked = false;

                txtTelNo.Text = @"";
                txtVatNo.Text = @"";
                txtMsg1.Text = @"";
                txtMsg2.Text = @"";
                txtMsg3.Text = @"";
                txtMsg4.Text = @"";
                txtMsg5.Text = @"";
            }

            asfc.controllInitializeSize(this);
        }

        private void FrmPrintSetup_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnCounterSetting1_Click(object sender, EventArgs e)
        {
            FrmPrintSetupCounterSetting1 frmPrintSetupCounterSetting1 = new FrmPrintSetupCounterSetting1();
            frmPrintSetupCounterSetting1.Location = panelBox.Location;
            frmPrintSetupCounterSetting1.Size = panelBox.Size;

            if (frmPrintSetupCounterSetting1.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnCounterSetting2_Click(object sender, EventArgs e)
        {
            FrmPrintSetupCounterSetting2 frmPrintSetupCounterSetting2 = new FrmPrintSetupCounterSetting2();
            frmPrintSetupCounterSetting2.Location = panelBox.Location;
            frmPrintSetupCounterSetting2.Size = panelBox.Size;

            if (frmPrintSetupCounterSetting2.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnKitchenSetting_Click(object sender, EventArgs e)
        {
            FrmPrintSetupKitchenSetting frmPrintSetupKitchenSetting = new FrmPrintSetupKitchenSetting();
            frmPrintSetupKitchenSetting.Location = panelBox.Location;
            frmPrintSetupKitchenSetting.Size = panelBox.Size;

            if (frmPrintSetupKitchenSetting.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void chkPrtLogo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrtLogo.Checked)
            {
                lblFilePath.Visible = true;
                lblFileUpload.Visible = true;
                btnFileUpload.Visible = true;
            }
            else
            {
                lblFilePath.Visible = false;
                lblFileUpload.Visible = false;
                btnFileUpload.Visible = false;
            }
        }

        private void btnGenSave_Click(object sender, EventArgs e)
        {
            TaSysPrtSetGeneralInfo generalInfo = new TaSysPrtSetGeneralInfo();

            generalInfo.IsPrtLogo = chkPrtLogo.Checked ? "Y" : "N";
            generalInfo.LogoFilePath = lblFilePath.Text;
            

            generalInfo.IsPrtStaff = chkPrtStaff.Checked ? "Y" : "N";
            generalInfo.IsPrtTel = chkPrtTel.Checked ? "Y" : "N";
            generalInfo.IsPrtAddr = chkPrtAddr.Checked ? "Y" : "N";

            generalInfo.TelNo = txtTelNo.Text;
            generalInfo.VATNo = txtVatNo.Text;
            generalInfo.Msg1 = txtMsg1.Text;
            generalInfo.Msg2 = txtMsg2.Text;
            generalInfo.Msg3 = txtMsg3.Text;
            generalInfo.Msg4 = txtMsg4.Text;
            generalInfo.Msg5 = txtMsg5.Text;

            try
            {
                new SystemData().GetTaSysPrtSetGeneral();

                var lstGen = CommonData.TaSysPrtSetGeneral;

                if (lstGen.Any())
                {
                    generalInfo.ID = lstGen.FirstOrDefault().ID;
                    _control.UpdateEntity(generalInfo);
                }else
                {
                    _control.AddEntity(generalInfo);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnGenExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnFileUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Title = @"Please Select Image";
            //ofd.Filter = @"Image Files(*.jpg)|*.jpg|Image Files(*.jpeg)|*.jpeg|Image Files(*.bmp)|*.bmp";
            ofd.Filter = @"Image Files(*.jpg)|*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(Environment.CurrentDirectory + @"\\PrintTemplate\\logo.jpg"))
                {
                    if (ofd.FileName.Equals(Environment.CurrentDirectory + @"\\PrintTemplate\\logo.jpg")) return;

                    File.Delete(Environment.CurrentDirectory + @"\\PrintTemplate\\logo.jpg");
                    File.Copy(ofd.FileName, Environment.CurrentDirectory + @"\\PrintTemplate\\logo.jpg");
                }
                else
                    File.Copy(ofd.FileName, Environment.CurrentDirectory + @"\\PrintTemplate\\logo.jpg");

                lblFilePath.Text = ofd.FileName;
            }
        }
    }
}