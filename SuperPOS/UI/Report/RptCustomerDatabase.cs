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
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.Report
{
    public partial class RptCustomerDatabase : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public RptCustomerDatabase()
        {
            InitializeComponent();
        }

        private void RptCustomerDatabase_Load(object sender, EventArgs e)
        {
            new SystemData().GetTaCustomer();

            GetBindData();

            asfc.controllInitializeSize(this);
        }

        private void RptCustomerDatabase_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        #region 绑定初始数据
        /// <summary>
        /// 绑定初始数据
        /// </summary>
        /// <param name="busDate">营业日</param>
        private void GetBindData()
        {
            List<TaCustomerInfo> lstCust = CommonData.TaCustomer.ToList();
            
            var lstDb = from cust in lstCust
                        select new
                        {
                            ID = cust.ID,
                            gridCustName = cust.cusName,
                            gridPhoneNo1 = cust.cusPhone,
                            gridAddress1 = cust.cusAddr,
                            gridPostcode1 = cust.cusPostcode,
                            gridDistance  = cust.cusDistance,
                            gridMap = cust.cusPcZone,
                            gridBlackListed = cust.cusIsBlack
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CommonDAL.SetPrintPreview(gridControlReport);
        }
    }
}