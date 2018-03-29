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

namespace SuperPOS.UI
{
    public partial class FrmShow : DevExpress.XtraEditors.XtraForm
    {
        public FrmShow()
        {
            InitializeComponent();
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogon frmLogon = new FrmLogon();
            frmLogon.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}