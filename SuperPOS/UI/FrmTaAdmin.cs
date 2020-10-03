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
using SuperPOS.UI.Sys;
using SuperPOS.UI.TaAdmin;
using SuperPOS.UI.TA;

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
            FrmTaAdminSysConf frmTaAdmin = new FrmTaAdminSysConf(usrID, usrName);
            frmTaAdmin.ShowDialog();
        }

        private void btnSysSetUsrMaint_Click(object sender, EventArgs e)
        {
            FrmTaAdminUsrMaintenance frmTaAdminUsrMaintenance = new FrmTaAdminUsrMaintenance(usrID, usrName);
            frmTaAdminUsrMaintenance.ShowDialog();
        }

        private void btnSysDataManager_Click(object sender, EventArgs e)
        {
            FrmDataManager frmDataManager = new FrmDataManager(usrID, usrName);
            frmDataManager.ShowDialog();
        }

        private void btnSysSetCompactDb_Click(object sender, EventArgs e)
        {

        }

        private void btnSysSetComputerAddr_Click(object sender, EventArgs e)
        {
            FrmCompAddr frmCompAddr = new FrmCompAddr(usrID, usrName);
            frmCompAddr.ShowDialog();
        }

        private void btnSysSetShiftCode_Click(object sender, EventArgs e)
        {
            FrmShiftCode frmShiftCode = new FrmShiftCode(usrID, usrName);
            frmShiftCode.ShowDialog();
        }
        #endregion

        #region Takeaway & Quick Dining Setting
        private void btnTaTaConf_Click(object sender, EventArgs e)
        {
            FrmTaConf frmTaConf = new FrmTaConf(usrID, usrName);
            frmTaConf.ShowDialog();
        }

        private void btnTaMenuCategory_Click(object sender, EventArgs e)
        {
            FrmTaMenuCate frmTaMenuCate = new FrmTaMenuCate(usrID, usrName);
            frmTaMenuCate.ShowDialog();
        }

        private void btnTaMenuItem_Click(object sender, EventArgs e)
        {
            FrmTaMenuItem frmTaMenuItem = new FrmTaMenuItem(usrID, usrName);
           frmTaMenuItem.ShowDialog();
        }

        private void btnTaManageMenuSet_Click(object sender, EventArgs e)
        {
            FrmTaMenuSet frmTaMenuSet = new FrmTaMenuSet(usrID, usrName);
            frmTaMenuSet.ShowDialog();
        }

        private void btnTaExtraMenuEdit_Click(object sender, EventArgs e)
        {
            FrmTaExtraMenuEdit frmTaExtraMenuEdit = new FrmTaExtraMenuEdit(usrID, usrName);
            frmTaExtraMenuEdit.ShowDialog();
        }

        private void btnTaPrtSetup_Click(object sender, EventArgs e)
        {
            FrmTaPrtSetup frmTaPrtSetup = new FrmTaPrtSetup(usrID, usrName);
            frmTaPrtSetup.ShowDialog();}

        private void btnTaDriverSetup_Click(object sender, EventArgs e)
        {
            FrmTaDriver frmTaDriver = new FrmTaDriver(usrID, usrName);
            frmTaDriver.ShowDialog();
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
            FrmTaMenuSet frmTaMenuSet = new FrmTaMenuSet(usrID, usrName);
            frmTaMenuSet.ShowDialog();
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
            FrmPrintSetup frmPrintSetup = new FrmPrintSetup();
            frmPrintSetup.ShowDialog();
        }
        #endregion

        #region Reporting
        private void btnRepAccountSum_Click(object sender, EventArgs e)
        {
            FrmAccountSummary frmAccountSummary = new FrmAccountSummary(usrID, usrName);
            frmAccountSummary.ShowDialog();
        }

        private void btnRepReport_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Other
        private void btnSysCtrl_Click(object sender, EventArgs e)
        {
            FrmSysCtrl frmSysCtrl = new FrmSysCtrl();
            frmSysCtrl.ShowDialog();
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