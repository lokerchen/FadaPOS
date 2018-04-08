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
    public partial class FrmTaAdmin : DevExpress.XtraEditors.XtraForm
    {
        //用户ID
        public int usrID = 0;
        //用户姓名
        public string usrName = "";

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmTaAdmin()
        {
            InitializeComponent();
        }

        public FrmTaAdmin(int uID, string sName)
        {
            InitializeComponent();
            usrID = uID;
            usrName = sName;
        }


        #region System Setting
        private void btnSysSetSysConf_Click(object sender, EventArgs e)
        {

        }

        private void btnSysSetUsrMaint_Click(object sender, EventArgs e)
        {

        }

        private void btnSysDataManager_Click(object sender, EventArgs e)
        {

        }

        private void btnSysSetCompactDb_Click(object sender, EventArgs e)
        {

        }

        private void btnSysSetComputerAddr_Click(object sender, EventArgs e)
        {

        }

        private void btnSysSetShiftCode_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Takeaway & Quick Dining Setting
        private void btnTaTaConf_Click(object sender, EventArgs e)
        {

        }

        private void btnTaMenuCategory_Click(object sender, EventArgs e)
        {

        }

        private void btnTaMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnTaManageMenuSet_Click(object sender, EventArgs e)
        {

        }

        private void btnTaExtraMenuEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnTaPrtSetup_Click(object sender, EventArgs e)
        {

        }

        private void btnTaDriverSetup_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Eat In Setting
        private void btnEiConf_Click(object sender, EventArgs e)
        {

        }

        private void btnEiMenuCategory_Click(object sender, EventArgs e)
        {

        }

        private void btnEiMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnEiManageMenuSet_Click(object sender, EventArgs e)
        {

        }

        private void btnEiExtraMenuEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnEiOrderCtrl_Click(object sender, EventArgs e)
        {

        }

        private void btnEiDeptCode_Click(object sender, EventArgs e)
        {

        }

        private void btnEiTblSetup_Click(object sender, EventArgs e)
        {

        }

        private void btnEiPrtOrderEntry_Click(object sender, EventArgs e)
        {

        }

        private void btnEiPrtSetup_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Reporting
        private void btnRepAccountSum_Click(object sender, EventArgs e)
        {

        }

        private void btnRepReport_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Other
        private void btnSysCtrl_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Method

        #endregion

        private void FrmTaAdmin_Load(object sender, EventArgs e)
        {
            asfc.controllInitializeSize(this);
        }

        private void FrmTaAdmin_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}