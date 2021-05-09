using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using DevExpress.XtraEditors;
using SuperPOS.Common;
using SuperPOS.Dapper;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaSummaryManagement : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private IList<AccountSummaryInfo> lstAccountSummaryInfos = new List<AccountSummaryInfo>();

        public FrmTaSummaryManagement()
        {
            InitializeComponent();
        }

        public FrmTaSummaryManagement(IList<AccountSummaryInfo> lstAsi)
        {
            InitializeComponent();
            lstAccountSummaryInfos = lstAsi;
        }

        private void FrmTaSummaryManagement_Load(object sender, EventArgs e)
        {
            //sysData.GetTaCheckOrder();
            //sysData.GetUsrBase();
            //sysData.GetTaPreview();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            txtCurrentDate.Text = DateTime.Now.ToShortDateString();

            deDay.Text = CommonDAL.GetBusDate();

            GetBindData(deDay.Text);
            
            gvTaShowOrder.FocusedRowHandle = gvTaShowOrder.RowCount - 1;

            asfc.controllInitializeSize(this);

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine(@"#FrmTaSummaryManagement_Load# Time {0}", ts.TotalMilliseconds);

            //sysData.GetTaOrderItem();
        }

        private void FrmTaSummaryManagement_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region 绑定初始数据
        /// <summary>
        /// 绑定初始数据
        /// </summary>
        /// <param name="busDate">营业日</param>
        private void GetBindData(string busDate)
        {
            var lstDb = lstAccountSummaryInfos;
            gridControlTaSummaryManagement.DataSource = !string.IsNullOrEmpty(busDate)
                                                        ? lstDb.Where(s => s.BusDate.Equals(busDate)).ToList()
                                                        : lstDb.ToList();
            gvTaShowOrder.Columns["PayTime"].BestFit();
            gvTaShowOrder.FocusedRowHandle = gvTaShowOrder.RowCount - 1;
        }
        #endregion

        private string GetAllPayType(string s1, string s2)
        {
            return Convert.ToDecimal(s1) > 0.00m ? s2 : "";
        }

        private void btnDateLeft_Click(object sender, EventArgs e)
        {
            deDay.Text = CommonDAL.SetDateTimeFormat(deDay.Text, -1);
            GetBindData(deDay.Text);
        }

        private void btnDateRight_Click(object sender, EventArgs e)
        {
            deDay.Text = CommonDAL.SetDateTimeFormat(deDay.Text, 1);
            GetBindData(deDay.Text);
        }

        private void gvTaShowOrder_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (gvTaShowOrder.RowCount > 1)
            {
                gvTaShowOrder.FocusedRowHandle -= 1;
                //gvTaShowOrder.MovePrev();
                //gvTaShowOrder.SetFocusedRowModified();
                //gvTaShowOrder.RefreshRow(gvTaShowOrder.FocusedRowHandle);
                gvTaShowOrder.Focus();
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (gvTaShowOrder.FocusedRowHandle < gvTaShowOrder.RowCount - 1)
            {
                gvTaShowOrder.FocusedRowHandle += 1;
                //gvTaShowOrder.MoveNext();
                gvTaShowOrder.Focus();
            }
        }

        private void tTimer_Tick(object sender, EventArgs e)
        {
            txtCurrentTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void gvTaShowOrder_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gvTaShowOrder.RowCount < 1) return;

            int[] iSelectRows = gvTaShowOrder.GetSelectedRows();

            //所有行数
            int iAllOrder = gvTaShowOrder.RowCount;

            decimal dAllTotal = 0.0m;
            for (int i = 0; i < gvTaShowOrder.RowCount; i++)
            {
                dAllTotal += Convert.ToDecimal(gvTaShowOrder.GetRowCellValue(i, "Paid"));
            }

            //被选中的行数
            int iSelectOrder = iSelectRows.Length;
            //被选中的订单总和
            decimal dSelectTotal = iSelectRows.Sum(s => Convert.ToDecimal(gvTaShowOrder.GetRowCellValue(s, "Paid")));

            txtSelectedOrders.Text = iSelectOrder.ToString();
            txtSelectedAmount.Text = dSelectTotal.ToString("0.00");

            txtRemainingOrderQty.Text = (iAllOrder - iSelectOrder).ToString();
            txtRemainingTotalAmt.Text = (dAllTotal - dSelectTotal).ToString("0.00");
        }

        private void btnSelectAllOrders_Click(object sender, EventArgs e)
        {
            gvTaShowOrder.SelectAll();
        }

        private void btnAmendOrder_Click(object sender, EventArgs e)
        {
            if (txtSelectedOrders.Text.Equals("1"))
            {
                string strChkOrder = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "CheckCode").ToString();
                int usrID = Convert.ToInt32(gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "StaffID").ToString());
                int intCusID = Convert.ToInt32(gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "CustomerID").ToString());

                FrmTaMain frmTaMain = new FrmTaMain(strChkOrder, usrID, intCusID, deDay.Text, PubComm.MENU_LANG_DEFAULT);
                frmTaMain.ShowDialog();
            }
        }

        private void btnPrintAccountSummary_Click(object sender, EventArgs e)
        {
            int[] iSelectRows = gvTaShowOrder.GetSelectedRows();

            string strOrder = "";
            if (gvTaShowOrder.SelectedRowsCount == 1)
            {
                strOrder = "'" + gvTaShowOrder.GetRowCellValue(0, "Paid") + "'";
            }
            else
            {
                for (int i = 0; i < iSelectRows.Length; i++)
                {
                    strOrder += i == iSelectRows.Length - 1
                        ? "'" + gvTaShowOrder.GetRowCellValue(i, "CheckCode") + "'"
                        : "'" + gvTaShowOrder.GetRowCellValue(i, "CheckCode") + "',";
                }
            }

            new SystemData().GetPrtAccountSummary(strOrder, deDay.Text);
            PrtAccountSummaryInfo prtAsi = CommonData.GetPrtAccountSummaryInfos;

            //临时设置为0
            prtAsi.TotalVAT = "0.00";
            prtAsi.NotPaid = "0.00";

            prtAsi.PayType1 = "Cash";
            prtAsi.PayType2 = "Card";
            prtAsi.PayType3 = "Other";
            prtAsi.PayType4 = "VISA";
            prtAsi.PayType5 = "PayPal";

            CommonDAL.ExportToExcel(prtAsi);
        }
    }
}