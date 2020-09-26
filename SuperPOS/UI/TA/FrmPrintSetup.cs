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

namespace SuperPOS.UI.TA
{
    public partial class FrmPrintSetup : DevExpress.XtraEditors.XtraForm
    {

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
            asfc.controllInitializeSize(this);

            //FrmPrintSetupGeneral frmPrintSetupGeneral = new FrmPrintSetupGeneral();
            //frmPrintSetupGeneral.Location = panelBox.Location;
            //frmPrintSetupGeneral.Size = panelBox.Size;

            //btnGeneral_Click(sender, e);
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
    }
}