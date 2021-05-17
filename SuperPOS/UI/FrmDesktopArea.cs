using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;
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

        private string strBusDate = "";

        private FrmTaMain frmTaMain;

        [DllImport("Drawcash.dll")]
        private static extern bool OpenDriverCash2(int code1, int code2, int code3, int code4, int code5, string printerName);

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
            //DelegateRefresh hd = DelegateMy.RefreshSomeInfo;
            //IAsyncResult rt = hd.BeginInvoke("9", strBusDate, "", null, null);
            CommonDAL.RefreshSomeInfo("9", strBusDate, "");

            FrmTaAdmin frmTaAdminMain = new FrmTaAdmin(usrID, usrName);
            frmTaAdminMain.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FrmDesktopArea_Load(object sender, EventArgs e)
        {
            lblUsrName.Text = usrName;

            //Date
            lblDate.Text = DateTime.Now.ToShortDateString();
            //Time
            lblTime.Text = DateTime.Now.ToShortTimeString();

            new SystemData().GetTaShiftCodeList();

            var lstSession = CommonData.TaShiftCodeList.Where(s =>
                        DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToShortTimeString()), Convert.ToDateTime(s.DtFrom)) >= 0
                        && DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToShortTimeString()), Convert.ToDateTime(s.DtEnd)) <= 0);

            if (lstSession.Any())
            {
                lblSession.Text = lstSession.FirstOrDefault().ShiftName;
            }

            strBusDate = CommonDAL.GetBusDate();

            this.TopMost = true;

            asfc.controllInitializeSize(this);
        }

        private void FrmDesktopArea_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            FrmTaMain frmTaMain = new FrmTaMain(usrID, PubComm.MENU_LANG_DEFAULT);
            frmTaMain.ShowDialog();
        }

        private void btnShowOrder_Click(object sender, EventArgs e)
        {
            //DelegateRefresh hd = DelegateMy.RefreshSomeInfo;
            //IAsyncResult rt = hd.BeginInvoke("8", strBusDate, "", null, null);
            CommonDAL.RefreshSomeInfo("8", strBusDate, "");

            this.TopMost = false;

            FrmTaShowOrder frmTaShowOrder = new FrmTaShowOrder(usrID, strBusDate);
            frmTaShowOrder.ShowDialog();
        }

        private void btnOrderScreen_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            ////显示订餐界面
            //FrmTaMain frmTaMain = new FrmTaMain(usrID, PubComm.MENU_LANG_DEFAULT);

            //frmTaMain.ShowDialog();

            //DelegateRefresh handler = DelegateMy.RefreshSomeInfo;
            //IAsyncResult result = handler.BeginInvoke("10", "", "", null, null);
            CommonDAL.RefreshSomeInfo("10", "", "");

            if (frmTaMain == null)
            {
                frmTaMain = new FrmTaMain(usrID, PubComm.MENU_LANG_DEFAULT);
                frmTaMain.Show();
            }
            else
            {
                if (frmTaMain.IsDisposed)
                {
                    frmTaMain = new FrmTaMain(usrID, PubComm.MENU_LANG_DEFAULT);
                    frmTaMain.Show();
                }
                else
                {
                    frmTaMain.isGetPhone = false;
                    frmTaMain.Activate();
                    frmTaMain.Show();
                }
            }
        }

        private void tTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnDrawer_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaCashDrawSet();
            TaCashDrawSetInfo taCashDrawSetInfo = CommonData.TaCashDrawSet.FirstOrDefault();

            if (taCashDrawSetInfo != null)
            {
                if (taCashDrawSetInfo.IsUseCashDraw.Equals("Y"))
                {
                    FrmCashDraw frmCashDraw = new FrmCashDraw();

                    frmCashDraw.ShowDialog();
                }
                else
                {
                    string strPrtName = taCashDrawSetInfo.ReportPrinter;
                    OpenDriverCash2(27, 112, 48, 55, 121, strPrtName);
                }
            }
            
        }
    }
}