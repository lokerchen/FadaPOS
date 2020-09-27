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

namespace SuperPOS.UI.Report
{
    public partial class RptCategoryPerformance : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public RptCategoryPerformance()
        {
            InitializeComponent();
        }

        private void RptCategoryPerformance_Load(object sender, EventArgs e)
        {
            asfc.controllInitializeSize(this);
        }

        private void RptCategoryPerformance_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}