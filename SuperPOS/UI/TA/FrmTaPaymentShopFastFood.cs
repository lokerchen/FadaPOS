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
    public partial class FrmTaPaymentShopFastFood : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private readonly EntityControl _control = new EntityControl();

        private string checkOrderId = "";

        private string strBusDate = "";

        public string RefNum
        {
            get { return txtRefNum.Text; }
            set { RefNum = value; }
        }

        public FrmTaPaymentShopFastFood()
        {
            InitializeComponent();
        }

        public FrmTaPaymentShopFastFood(string checkId, string sBusDate)
        {
            checkOrderId = checkId;
            strBusDate = sBusDate;
            InitializeComponent();
        }

        private void FrmTaPaymentShopFastFood_Load(object sender, EventArgs e)
        {
            SetClick();

            txtRefNum.AutoSize = false;

            try
            {
                new SystemData().GetTaCheckOrder();

                var lstCo = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(checkOrderId) && s.BusDate.Equals(strBusDate));

                if (lstCo.Any())
                {
                    TaCheckOrderInfo taCheckOrderInfo = lstCo.FirstOrDefault();
                    txtRefNum.Text = taCheckOrderInfo.RefNum;
                }
                else
                {
                    txtRefNum.Text = "";
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            asfc.controllInitializeSize(this);
        }

        private void FrmTaPaymentShopFastFood_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        #region 数字按钮Click
        /// <summary>
        ///     数字按钮Click
        /// </summary>
        private void SetClick()
        {
            btn1.Click += btn_Click;
            btn2.Click += btn_Click;
            btn3.Click += btn_Click;
            btn4.Click += btn_Click;
            btn5.Click += btn_Click;
            btn6.Click += btn_Click;
            btn7.Click += btn_Click;
            btn8.Click += btn_Click;
            btn9.Click += btn_Click;
            btn0.Click += btn_Click;
            btnS.Click += btn_Click;
            btnF.Click += btn_Click;
            btnB.Click += btn_Click;
            btnG.Click += btn_Click;
            btnC.Click += btn_Click;
            btnH.Click += btn_Click;
            btnD.Click += btn_Click;
            btnT.Click += btn_Click;
            btnM.Click += btn_Click;
            btnK.Click += btn_Click;
            btnClear.Click += btn_Click;
            btnDel.Click += btn_Click;
        }
        #endregion

        #region 数字按钮输入事件
        private void btn_Click(object sender, EventArgs e)
        {
            var btn = (SimpleButton)sender;

            if (btn.Name.Equals("btnClear"))
            {
                txtRefNum.Text = @"";
            }
            else if (btn.Name.Equals("btnDel"))
            {
                txtRefNum.Text = txtRefNum.Text.Length > 0 ? txtRefNum.Text.Substring(0, txtRefNum.Text.Length - 1) : "";
            }
            else
            {
                if (string.IsNullOrEmpty(txtRefNum.Text))
                    txtRefNum.Text = btn.Text;
                else
                    txtRefNum.Text += btn.Text;
            }
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(checkOrderId)) return;

            //if (string.IsNullOrEmpty(txtRefNum.Text)) return;

            try
            {
                new SystemData().GetTaCheckOrder();

                var lstCo = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(checkOrderId) && s.BusDate.Equals(strBusDate));

                if (lstCo.Any())
                {
                    TaCheckOrderInfo taCheckOrderInfo = lstCo.FirstOrDefault();
                    taCheckOrderInfo.RefNum = txtRefNum.Text;

                    _control.UpdateEntity(taCheckOrderInfo);

                    DialogResult = DialogResult.OK;
                    Hide();
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }
        }
    }
}