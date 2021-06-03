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

namespace SuperPOS.UI
{
    public partial class FrmShow : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

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
            CommonDAL.IsBackupSysData();
            Close();
        }

        private void FrmShow_Load(object sender, EventArgs e)
        {
            picImg.Image = Image.FromFile(Environment.CurrentDirectory + @"\logo.jpg");
            asfc.controllInitializeSize(this);
        }

        private void FrmShow_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}