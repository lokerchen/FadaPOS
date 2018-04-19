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

namespace SuperPOS.UI.TaAdmin
{
    public partial class FrmTaConf : DevExpress.XtraEditors.XtraForm
    {
        //用户ID
        public int usrID = 0;
        //用户姓名
        public string usrName = "";

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private readonly EntityControl _control = new EntityControl();

        public FrmTaConf()
        {
            InitializeComponent();
        }

        public FrmTaConf(int uID, string sName)
        {
            InitializeComponent();
            usrID = uID;
            usrName = sName;
        }

        private void FrmTaConf_Load(object sender, EventArgs e)
        {
            asfc.controllInitializeSize(this);
        }

        private void FrmTaConf_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}