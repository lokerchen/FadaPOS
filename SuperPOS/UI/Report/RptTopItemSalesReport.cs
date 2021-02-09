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

namespace SuperPOS.UI.Report
{
    public partial class RptTopItemSalesReport : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public RptTopItemSalesReport()
        {
            InitializeComponent();
        }

        private void RptTopItemSalesReport_Load(object sender, EventArgs e)
        {
            string strBusDate = CommonDAL.GetBusDate();
            GetBindData(strBusDate);
            asfc.controllInitializeSize(this);
        }

        private void RptTopItemSalesReport_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CommonDAL.SetPrintPreview(gridControlReport);
        }

        #region 绑定初始数据
        /// <summary>
        /// 绑定初始数据
        /// </summary>
        /// <param name="strBusDate">营业日</param>
        private void GetBindData(string strBusDate)
        {
            new SystemData().GetRptTotalSales(strBusDate);

            var lstDb = from rptTsi in CommonData.GetRptTotalSalesInfo
                        select new
                        {
                            gridDishCode = rptTsi.ItemCode,
                            gridItemDescriptions = rptTsi.ItemDishName,
                            gridOtherLanguage = rptTsi.ItemDishOtherName,
                            gridTotalQuantity = rptTsi.ItemQty,
                            gridTotalAmount = rptTsi.ItemTotalPrice
                        };

            gridControlReport.DataSource = lstDb.ToList();
            //gvTaShowOrder.BestFitColumns();
            //gvTaShowOrder.Columns["gridItemDescriptions"].BestFit();
            gvTaShowOrder.FocusedRowHandle = gvTaShowOrder.RowCount - 1;
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}