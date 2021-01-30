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
using SuperPOS.UI.Report;

namespace SuperPOS.UI.TA
{
    public partial class FrmReports : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmReports()
        {
            InitializeComponent();
        }

        private void FrmReports_Load(object sender, EventArgs e)
        {
            asfc.controllInitializeSize(this);
        }

        private void FrmReports_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnMenuItemListing_Click(object sender, EventArgs e)
        {
            RptMenuItemListing rptMenuItemListing = new RptMenuItemListing();
            rptMenuItemListing.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}