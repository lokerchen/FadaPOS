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
    public partial class FrmTaShowOrderDriver : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmTaShowOrderDriver()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FrmTaShowOrderDriver_Load(object sender, EventArgs e)
        {
            BinLueDriver();

            asfc.controllInitializeSize(this);
        }

        private void FrmTaShowOrderDriver_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        #region 绑定Driver

        private void BinLueDriver()
        {
            new SystemData().GetTaDriver();

            var lstDriver = from td in CommonData.TaDriver.Where(s => !string.IsNullOrEmpty(s.DriverName))
                            select new
                            {
                                driverID = td.ID,
                                driverName = td.DriverName
                            };
            lueDriver.Properties.DataSource = lstDriver.ToList();
            lueDriver.Properties.DisplayMember = "driverName";
            lueDriver.Properties.ValueMember = "driverID";

            lueDriver.ItemIndex = 0;
        }
        #endregion

        #region 数据绑定
        private void GetBindData(int iDriver)
        {
            var lstCheck = CommonData.TaCheckOrder.Where(s => s.PayOrderType.Equals(PubComm.ORDER_TYPE_DELIVERY));

            var lstDb = from check in lstCheck
                join driver in CommonData.TaDriver
                    on check.DriverID equals driver.ID
                select new
                {
                    ID = check.ID,
                    CheckCode = check.CheckCode,
                    OrderTime = check.PayTime,
                    DeliveryFee = check.DeliveryFee,
                    DriverID = check.DriverID,
                    DriverName = string.IsNullOrEmpty(driver.DriverName) ? "" : driver.DriverName,
                };

            gridControlTaDriver.DataSource = iDriver == 0
                                             ? lstDb.ToList()
                                             : lstDb.Where(s => s.DriverID == iDriver).ToList();
            gvTaPendOrder.FocusedRowHandle = gvTaPendOrder.RowCount - 1;
            gvTaPendOrder.BestFitColumns();

            txtTotalDeliveryCharge.Text = iDriver == 0
                                            ? lstDb.Sum(s => Convert.ToDecimal(s.DeliveryFee)).ToString("0.00")
                                            : lstDb.Where(s => s.DriverID == iDriver).Sum(s => Convert.ToDecimal(s.DeliveryFee)).ToString("0.00");
        }
        #endregion

        private void lueDriver_EditValueChanged(object sender, EventArgs e)
        {
            GetBindData(Convert.ToInt32(lueDriver.EditValue));
        }

        private void btnShowAllDriver_Click(object sender, EventArgs e)
        {
            lueDriver.Text = "";
            lueDriver.EditValue = 0;

            GetBindData(0);
        }
    }
}