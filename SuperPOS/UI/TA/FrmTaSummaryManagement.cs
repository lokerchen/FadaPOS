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
    public partial class FrmTaSummaryManagement : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmTaSummaryManagement()
        {
            InitializeComponent();
        }

        private void FrmTaSummaryManagement_Load(object sender, EventArgs e)
        {
            SystemData sysData = new SystemData();

            sysData.GetTaCheckOrder();
            sysData.GetUsrBase();
            sysData.GetTaOrderItem();
            sysData.GetTaPreview();

            GetBindData(CommonDAL.GetBusDate());

            deDay.Text = CommonDAL.GetBusDate();

            gvTaShowOrder.FocusedRowHandle = gvTaShowOrder.RowCount - 1;

            asfc.controllInitializeSize(this);
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
            var lstDb = from check in CommonData.TaCheckOrder
                        join user in CommonData.UsrBase
                            on check.StaffID equals user.ID
                        join driver in CommonData.TaDriver
                            on check.DriverID equals driver.ID
                        where check.IsPaid.Equals("Y")
                        select new
                        {
                            RowCheck = "0",
                            ID = check.ID,
                            gridOrderNo = check.CheckCode,
                            gridPayType = (GetAllPayType(check.PayTypePay1, check.PayType1) + @" "
                                           + GetAllPayType(check.PayTypePay2, check.PayType2) + @" "
                                           + GetAllPayType(check.PayTypePay3, check.PayType3) + @" "
                                           + GetAllPayType(check.PayTypePay4, check.PayType4) + @" "
                                           + GetAllPayType(check.PayTypePay5, check.PayType5)).Trim(),
                            gridOrderType = check.PayOrderType,
                            gridOrderTime = check.PayTime,
                            gridTotal = check.TotalAmount,
                            gridDriver = driver.DriverName,
                            //gridDriver = "",
                            gridStaff = user.UsrName,
                            gridCustID = check.CustomerID,
                            gridDiscountPer = check.PayPerDiscount,
                            gridDisount = check.PayDiscount,
                            gridSubTotal = check.MenuAmount,
                            gridBusDate = check.BusDate,
                            gridTendered = check.Paid,
                            gridChange =
                                (Convert.ToDecimal(check.Paid) - Convert.ToDecimal(check.TotalAmount)) <= 0
                                    ? "0.0"
                                    : (Convert.ToDecimal(check.Paid) - Convert.ToDecimal(check.TotalAmount)).ToString(),
                            gridRefNo = check.RefNum,
                            gridDeliveryFee = check.DeliveryFee,
                            gridStaffId = check.StaffID,
                            gridSurcharge = check.PaySurcharge
                        };

            gridControlTaSummaryManagement.DataSource = !string.IsNullOrEmpty(busDate)
                                                        ? lstDb.Where(s => s.gridBusDate.Equals(busDate)).ToList()
                                                        : lstDb.ToList();
            gvTaShowOrder.Columns["gridOrderTime"].BestFit();
            gvTaShowOrder.FocusedRowHandle = gvTaShowOrder.RowCount - 1;
        }
        #endregion

        private string GetAllPayType(string s1, string s2)
        {
            return Convert.ToDecimal(s1) > 0.00m ? s2 : "";
        }

        private void btnDateLeft_Click(object sender, EventArgs e)
        {
            deDay.Text = (Convert.ToDateTime(deDay.Text)).AddDays(-1).ToShortDateString();
            GetBindData(deDay.Text);
        }

        private void btnDateRight_Click(object sender, EventArgs e)
        {
            deDay.Text = (Convert.ToDateTime(deDay.Text)).AddDays(1).ToShortDateString();
            GetBindData(deDay.Text);
        }

        private void gvTaShowOrder_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvTaShowOrder_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //Console.WriteLine(@"2");

            //gvTaShowOrder.GetFocusedRowCellValue("ID");
            //gvTaShowOrder.FocusedColumn = gvTaShowOrder.Columns[1];

            if (gvTaShowOrder.RowCount < 1) return;

            int[] iSelectRows = gvTaShowOrder.GetSelectedRows();

            //所有行数
            int iAllOrder = gvTaShowOrder.RowCount;

            decimal dAllTotal = 0.0m;
            for (int i = 0; i < gvTaShowOrder.RowCount; i++)
            {
                dAllTotal += Convert.ToDecimal(gvTaShowOrder.GetRowCellValue(i, "gridTotal"));
            }

            //被选中的行数
            int iSelectOrder = iSelectRows.Length;
            //被选中的订单总和
            decimal dSelectTotal = iSelectRows.Sum(s => Convert.ToDecimal(gvTaShowOrder.GetRowCellValue(s, "gridTotal")));

            txtSelectedOrders.Text = iSelectOrder.ToString();
            txtSelectedAmount.Text = dSelectTotal.ToString("0.00");

            txtRemainingOrderQty.Text = (iAllOrder - iSelectOrder).ToString();
            txtRemainingTotalAmt.Text = (dAllTotal - dSelectTotal).ToString("0.00");
        }
    }
}