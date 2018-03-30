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
    public partial class FrmCaller : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public string CallNum
        {
            get { return txtTelNum.Text; }
            set { CallNum = value; }
        }

        private int usrId = 0;

        public FrmCaller()
        {
            InitializeComponent();
        }

        public FrmCaller(int uId)
        {
            InitializeComponent();
            usrId = uId;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCaller_Load(object sender, EventArgs e)
        {
            asfc.controllInitializeSize(this);
        }

        private void FrmCaller_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}