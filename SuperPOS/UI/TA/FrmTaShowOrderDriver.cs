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

namespace SuperPOS.UI.TA
{
    public partial class FrmTaShowOrderDriver : DevExpress.XtraEditors.XtraForm
    {
        public FrmTaShowOrderDriver()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}