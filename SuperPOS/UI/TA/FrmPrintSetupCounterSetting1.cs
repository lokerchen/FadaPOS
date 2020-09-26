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
    public partial class FrmPrintSetupCounterSetting1 : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmPrintSetupCounterSetting1()
        {
            InitializeComponent();
        }

        private void FrmPrintSetupCounterSetting1_Load(object sender, EventArgs e)
        {
            asfc.controllInitializeSize(this);
        }

        private void FrmPrintSetupCounterSetting1_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}