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
using SuperPOS.UI.TA;

namespace SuperPOS.UI
{
    public partial class FrmDesktopArea : DevExpress.XtraEditors.XtraForm
    {
        //用户ID
        public int usrID = 0;
        //用户姓名
        public string usrName = "";

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmDesktopArea()
        {
            InitializeComponent();
        }

        public FrmDesktopArea(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        private void btnCtlPanel_Click(object sender, EventArgs e)
        {
            FrmTaAdminMain frmTaAdminMain = new FrmTaAdminMain(usrID, usrName);
            frmTaAdminMain.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FrmDesktopArea_Load(object sender, EventArgs e)
        {
            lblUsrName.Text = usrName;

            new SystemData().GetTaShiftCodeList();

            var lstSession = CommonData.TaShiftCodeList.Where(s =>
                        DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToShortTimeString()), Convert.ToDateTime(s.DtFrom)) >= 0
                        && DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToShortTimeString()), Convert.ToDateTime(s.DtEnd)) <= 0);

            if (lstSession.Any())
            {
                lblSession.Text = lstSession.FirstOrDefault().ShiftName;
            }

            asfc.controllInitializeSize(this);
        }

        private void FrmDesktopArea_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            FrmTaMain frmTaMain = new FrmTaMain(usrID);
            frmTaMain.ShowDialog();
        }

        private void btnShowOrder_Click(object sender, EventArgs e)
        {
            
        }

        private void btnOrderScreen_Click(object sender, EventArgs e)
        {
            //显示订餐界面
            FrmTaMain frmTaMain = new FrmTaMain(usrID);
            frmTaMain.ShowDialog();
        }
    }
}