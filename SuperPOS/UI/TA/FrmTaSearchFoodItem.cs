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
    public partial class FrmTaSearchFoodItem : DevExpress.XtraEditors.XtraForm
    {
        private string strId = "";

        public string sId => strId;

        public FrmTaSearchFoodItem()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            strId = txtKeyWord.Text;

            this.DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}