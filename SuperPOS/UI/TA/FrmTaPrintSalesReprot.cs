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

namespace SuperPOS.UI.TA
{
    public partial class FrmTaPrintSalesReprot : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private IList<AccountSummaryInfo> lstAccountSummaryInfos = null;

        public FrmTaPrintSalesReprot()
        {
            InitializeComponent();
        }

        public FrmTaPrintSalesReprot(IList<AccountSummaryInfo> lstAsI)
        {
            InitializeComponent();
            this.lstAccountSummaryInfos = lstAsI;
        }

        private void FrmTaPrintSalesReprot_Load(object sender, EventArgs e)
        {
            new SystemData().GetAccountSummary("", "");
            lstAccountSummaryInfos = CommonData.GetAccountSummaryInfos;

            asfc.controllInitializeSize(this);
        }

        private void FrmTaPrintSalesReprot_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            new SystemData().GetAccountSummary(deDayFrom.Text, deDayTo.Text);
            lstAccountSummaryInfos = CommonData.GetAccountSummaryInfos;

            GetBindData();

            CommonDAL.SetPrintPreview(gridControlTaShowOrder);
        }

        #region 绑定初始数据
        /// <summary>
        /// 绑定初始数据
        /// </summary>
        /// <param name="busDate">营业日</param>
        private void GetBindData()
        {
            var lstDb = lstAccountSummaryInfos;

            gridControlTaShowOrder.DataSource = lstDb.ToList();
            gvTaShowOrder.Columns["PayTime"].BestFit();
            gvTaShowOrder.FocusedRowHandle = gvTaShowOrder.RowCount - 1;
        }
        #endregion
    }
}