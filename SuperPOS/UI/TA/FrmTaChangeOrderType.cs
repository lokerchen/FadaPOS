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
    public partial class FrmTaChangeOrderType : DevExpress.XtraEditors.XtraForm
    {
        //默认为SHOP
        private string strOrderType = PubComm.ORDER_TYPE_SHOP;

        public string OrderType
        {
            get { return strOrderType; }
            set { OrderType = value; }
        }

        public FrmTaChangeOrderType()
        {
            InitializeComponent();
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            strOrderType = PubComm.ORDER_TYPE_SHOP;
            this.DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            strOrderType = PubComm.ORDER_TYPE_DELIVERY;
            this.DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            strOrderType = PubComm.ORDER_TYPE_COLLECTION;
            this.DialogResult = DialogResult.OK;
            Hide();
        }
    }
}