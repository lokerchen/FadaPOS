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
    public partial class FrmCaller : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        //点击按钮名字
        private string objName = "txtHour";
        //private DateTime dt = DateTime.Now;

        private PanelControl[] pcCust = new PanelControl[8];
        private PanelControl[] pcOrder= new PanelControl[5];

        private LabelControl[] lblCustPhone = new LabelControl[8];
        private LabelControl[] lblCustInfo = new LabelControl[8];
        private string[] strCustID = new string[8];
        private LabelControl[] lblOderNo = new LabelControl[5];
        private LabelControl[] lblOrderTime = new LabelControl[5];

        private int[] iUsrID = new int[5];
        private int[] iCustID = new int[5];

        private readonly EntityControl _control = new EntityControl();

        private string strOrderType = "";
        private TaCustomerInfo taCust = new TaCustomerInfo();

        public string CallNum
        {
            get { return txtTelNum.Text; }
            set { CallNum = value; }
        }

        public TaCustomerInfo TaCustomer
        {
            get { return taCust; }
            set { TaCustomer = value; }
        }

        public string OrderType
        {
            get { return strOrderType; }
            set { OrderType = value; }
        }

        public string ReadyTime
        {
            get { return txtHour.Text + @":" + txtMinute.Text; }
            set { ReadyTime = value; }
        }

        private int usrId = 0;

        private string strCallPhone = "";

        private string strBustDate = "";

        private string strReadyTime = "";

        public FrmCaller()
        {
            InitializeComponent();
        }

        public FrmCaller(int uId, string sBusDate)
        {
            InitializeComponent();
            usrId = uId;
            strBustDate = sBusDate;
        }

        public FrmCaller(string sCallerPhoneNum, string sBusDate, string sOrderType, string sReadyTime)
        {
            InitializeComponent();
            strCallPhone = sCallerPhoneNum;
            strBustDate = sBusDate;
            strOrderType = sOrderType;

            strReadyTime = sReadyTime;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            taCust = null;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FrmCaller_Load(object sender, EventArgs e)
        {
            string strDt = string.IsNullOrEmpty(strReadyTime) ? DateTime.Now.ToShortTimeString() : strReadyTime;

            string[] sRt = strDt.Split(':');
            txtHour.Text = sRt[0];
            txtMinute.Text = sRt[1];
            #region 设置Panel

            #region 控件赋值
            pcCust[0] = pcCust1;
            lblCustPhone[0] = lblCustPhone1;
            lblCustInfo[0] = lblCustInfo1;
            pcCust[1] = pcCust2;
            lblCustPhone[1] = lblCustPhone2;
            lblCustInfo[1] = lblCustInfo2;
            pcCust[2] = pcCust3;
            lblCustPhone[2] = lblCustPhone3;
            lblCustInfo[2] = lblCustInfo3;
            pcCust[3] = pcCust4;
            lblCustPhone[3] = lblCustPhone4;
            lblCustInfo[3] = lblCustInfo4;
            pcCust[4] = pcCust5;
            lblCustPhone[4] = lblCustPhone5;
            lblCustInfo[4] = lblCustInfo5;
            pcCust[5] = pcCust6;
            lblCustPhone[5] = lblCustPhone6;
            lblCustInfo[5] = lblCustInfo6;
            pcCust[6] = pcCust7;
            lblCustPhone[6] = lblCustPhone7;
            lblCustInfo[6] = lblCustInfo7;
            pcCust[7] = pcCust8;
            lblCustPhone[7] = lblCustPhone8;
            lblCustInfo[7] = lblCustInfo8;

            pcOrder[0] = pcOrder1;
            lblOderNo[0] = lblOrderNo1;
            lblOrderTime[0] = lblOrderTime1;
            pcOrder[1] = pcOrder2;
            lblOderNo[1] = lblOrderNo2;
            lblOrderTime[1] = lblOrderTime2;
            pcOrder[2] = pcOrder3;
            lblOderNo[2] = lblOrderNo3;
            lblOrderTime[2] = lblOrderTime3;
            pcOrder[3] = pcOrder4;
            lblOderNo[3] = lblOrderNo4;
            lblOrderTime[3] = lblOrderTime4;
            pcOrder[4] = pcOrder5;
            lblOderNo[4] = lblOrderNo5;
            lblOrderTime[4] = lblOrderTime5;
            #endregion
            
            #endregion

            SetNumClick();
            SetAddClick();

            SetPanelCustInfo();
            SetPanelOrderInfo();

            lblCallInfo.Text = DateTime.Now.ToShortDateString() + @" " + DateTime.Now.ToShortTimeString();

            txtTelNum.Text = strCallPhone.Trim();

            SetUsrComePhoneAndIsNewUser(txtTelNum.Text);

            asfc.controllInitializeSize(this);
            
            LogHelper.Info(@"FrmCaller_Load");
        }

        private void FrmCaller_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmTaCustomerInfo frmTaCustomerInfo = new FrmTaCustomerInfo(txtTelNum.Text.Trim());
            if (frmTaCustomerInfo.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(frmTaCustomerInfo.strReadyTime))
                {
                    string[] sRt = frmTaCustomerInfo.strReadyTime.Split(':');
                    txtHour.Text = sRt[0];
                    txtMinute.Text = sRt[1];
                }
            }

            SetUsrComePhoneAndIsNewUser(txtTelNum.Text.Trim());
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            if ((txtHour.Text.Length + txtMinute.Text.Length) < 4) return;
            strOrderType = PubComm.ORDER_TYPE_DELIVERY;
            taCust = GetCustInfo(txtTelNum.Text.Trim());
            SetReadyTime();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            if((txtHour.Text.Length +txtMinute.Text.Length) < 4) return;
            strOrderType = PubComm.ORDER_TYPE_COLLECTION;
            taCust = GetCustInfo(txtTelNum.Text.Trim());
            SetReadyTime();
            DialogResult = DialogResult.OK;
            Close();
        }

        private TaCustomerInfo GetCustInfo(string custPhone)
        {
            new SystemData().GetTaCustomer();

            var lstCust = CommonData.TaCustomer.Where(s => s.cusPhone.Equals(custPhone));

            return lstCust.Any() ? lstCust.FirstOrDefault() : null;
        }

        #region 数字按钮输入事件

        private void btnNum_Click(object sender, EventArgs e)
        {
            var btn = (SimpleButton) sender;
            
            if (objName.Equals("txtHour"))
            {
                if (txtHour.Text.Length >= 2)
                {
                    txtHour.Text = txtHour.Text.Substring(1, txtHour.Text.Length - 1) + btn.Text;

                    if (Convert.ToInt32(txtHour.Text) >= 24)
                    {
                        txtHour.Text = btn.Text;
                    }
                    else
                    {
                        objName = "txtMinute";
                    }
                }
                else
                {
                    txtHour.Text += btn.Text;

                    if (txtHour.Text.Length >= 2) objName = "txtMinute";
                }

            }
            else if (objName.Equals("txtMinute"))
            {
                if (txtMinute.Text.Length >= 2)
                {
                    txtMinute.Text = txtMinute.Text.Substring(1, txtMinute.Text.Length - 1) + btn.Text;

                    if (Convert.ToInt32(txtMinute.Text) >= 60) txtMinute.Text = btn.Text;
                }
                else
                    txtMinute.Text += btn.Text;
            }
            else if (objName.Equals("txtTelNum"))
            {
                txtTelNum.Text += btn.Text;
            }
        }

        #endregion

        #region 增加分钟按钮输入事件

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var btn = (SimpleButton) sender;

            DateTime dt = string.IsNullOrEmpty(strReadyTime) 
                          ? Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())
                          : Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + strReadyTime);
            DateTime dtAdd = dt.AddMinutes(Convert.ToDouble(btn.Text.Replace("+", "")));

            txtHour.Text = dtAdd.Hour.ToString();
            txtMinute.Text = dtAdd.Minute.ToString();
        }

        #endregion

        #region 数字键盘点击事件赋值

        /// <summary>
        /// 数字键盘点击事件赋值
        /// </summary>
        private void SetNumClick()
        {
            btn1.Click += btnNum_Click;
            btn2.Click += btnNum_Click;
            btn3.Click += btnNum_Click;
            btn4.Click += btnNum_Click;
            btn5.Click += btnNum_Click;
            btn6.Click += btnNum_Click;
            btn7.Click += btnNum_Click;
            btn8.Click += btnNum_Click;
            btn9.Click += btnNum_Click;
            btn0.Click += btnNum_Click;
        }

        #endregion

        #region 增加分钟数点击事件赋值

        /// <summary>
        /// 增加分钟数点击事件赋值
        /// </summary>
        private void SetAddClick()
        {
            btnAdd5.Click += btnAdd_Click;
            btnAdd10.Click += btnAdd_Click;
            btnAdd15.Click += btnAdd_Click;
            btnAdd20.Click += btnAdd_Click;
            btnAdd25.Click += btnAdd_Click;
            btnAdd30.Click += btnAdd_Click;
            btnAdd35.Click += btnAdd_Click;
            btnAdd40.Click += btnAdd_Click;
            btnAdd45.Click += btnAdd_Click;
            btnAdd50.Click += btnAdd_Click;
            btnAdd55.Click += btnAdd_Click;
            btnAdd60.Click += btnAdd_Click;
        }

        #endregion

        private void btnClr_Click(object sender, EventArgs e)
        {
            //if (objName.Equals("txtHour"))
            //{
            //    txtHour.Text = "";
            //}
            //else if (objName.Equals("txtMinute"))
            //{
            //    txtMinute.Text = "";
            //}

            txtHour.Text = "";
            txtMinute.Text = "";
        }

        private void SetPanelCustInfo()
        {
            pcCust1.Click += btnPanelCustInfo_Click;
            pcCust2.Click += btnPanelCustInfo_Click;
            pcCust3.Click += btnPanelCustInfo_Click;
            pcCust4.Click += btnPanelCustInfo_Click;
            pcCust5.Click += btnPanelCustInfo_Click;
            pcCust6.Click += btnPanelCustInfo_Click;
            pcCust7.Click += btnPanelCustInfo_Click;
            pcCust8.Click += btnPanelCustInfo_Click;

            lblCustPhone1.Click += btnPanelCustPhone_Click;
            lblCustPhone2.Click += btnPanelCustPhone_Click;
            lblCustPhone3.Click += btnPanelCustPhone_Click;
            lblCustPhone4.Click += btnPanelCustPhone_Click;
            lblCustPhone5.Click += btnPanelCustPhone_Click;
            lblCustPhone6.Click += btnPanelCustPhone_Click;
            lblCustPhone7.Click += btnPanelCustPhone_Click;
            lblCustPhone8.Click += btnPanelCustPhone_Click;

            new SystemData().GetComePhoneInfo();

            int i = 0;
            foreach (var tcpi in CommonData.TaComePhoneInfo.OrderByDescending(s => s.ID).Take(8))
            {
                pcCust[i].Visible = true;
                lblCustInfo[i].Text = tcpi.ComePhoneTime;
                lblCustPhone[i].Text = tcpi.CustPhoneNo;
                i++;
            }
        }

        private void SetPanelOrderInfo()
        {
            //pcOrder1.Click += btnPanelOrder_Click;
            //pcOrder2.Click += btnPanelOrder_Click;
            //pcOrder3.Click += btnPanelOrder_Click;
            //pcOrder4.Click += btnPanelOrder_Click;
            //pcOrder5.Click += btnPanelOrder_Click;

            lblOrderNo1.Click += btnPanelOrder_Click;
            lblOrderNo2.Click += btnPanelOrder_Click;
            lblOrderNo3.Click += btnPanelOrder_Click;
            lblOrderNo4.Click += btnPanelOrder_Click;
            lblOrderNo5.Click += btnPanelOrder_Click;
        }

        private void btnPanelCustPhone_Click(object sender, EventArgs e)
        {
            var btn = (LabelControl)sender;

            int iNum = Convert.ToInt32(btn.Name.Replace("lblCustPhone", ""));

            txtTelNum.Text = lblCustPhone[iNum - 1].Text;
        }

        private void btnPanelCustInfo_Click(object sender, EventArgs e)
        {
            var btn = (PanelControl)sender;

            int iNum = Convert.ToInt32(btn.Name.Replace("pcCust", ""));

            txtTelNum.Text = lblCustPhone[iNum - 1].Text;
        }

        private void btnPanelOrder_Click(object sender, EventArgs e)
        {
            //var btn = (PanelControl)sender;
            var btn = (LabelControl)sender;

            int iNum = Convert.ToInt32(btn.Name.Replace("lblOrderNo", ""));

            new SystemData().GetTaCheckOrder();
            var lstCo = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(lblOderNo[iNum - 1].Text));

            if (lstCo.Any())
            {
                TaCheckOrderInfo taCheckOrderInfo = lstCo.FirstOrDefault();
                FrmTaMain frmTaMain = new FrmTaMain(lblOderNo[iNum - 1].Text, taCheckOrderInfo.StaffID,
                    Convert.ToInt32(taCheckOrderInfo.CustomerID), strBustDate, true);
                this.Hide();
                frmTaMain.ShowDialog();
            }
            else
            {
                FrmTaPendOrder frmTaPendOrder = new FrmTaPendOrder(lblOderNo[iNum - 1].Text, strBustDate, txtTelNum.Text);
                this.Hide();
                frmTaPendOrder.ShowDialog();
            }
        }

        private void SetReadyTime()
        {
            if (!string.IsNullOrEmpty(txtTelNum.Text))
            {
                new SystemData().GetTaCustomer();
                TaCustomerInfo taCustomerInfo = new TaCustomerInfo();

                var lstCust = CommonData.TaCustomer.Where(s => s.cusPhone.Equals(txtTelNum.Text));

                string strReadyTime = (!string.IsNullOrEmpty(txtHour.Text) && !string.IsNullOrEmpty(txtMinute.Text))
                    ? txtHour.Text + @":" + txtMinute.Text
                    : " ";

                if (lstCust.Any())
                {
                    taCustomerInfo = lstCust.FirstOrDefault();
                    taCustomerInfo.cusReadyTime = strReadyTime;
                    _control.UpdateEntity(taCustomerInfo);
                }
                else
                {
                    taCustomerInfo.cusPhone = txtTelNum.Text.Trim();
                    taCustomerInfo.cusReadyTime = strReadyTime;
                    _control.AddEntity(taCustomerInfo);
                }
            }
        }

        private void txtMinute_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtMinute";
        }

        private void txtHour_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtHour";
        }

        private void txtTelNum_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtTelNum";
        }

        private void txtTelNum_EditValueChanged(object sender, EventArgs e)
        {
            LogHelper.Info("txtTelNum_EditValueChanged");
            SetUsrComePhoneAndIsNewUser(txtTelNum.Text.Trim());
        }

        private void SetUsrComePhoneAndIsNewUser(string sCallPhone)
        {
            int iCustID = 0;

            if (!string.IsNullOrEmpty(sCallPhone))
            {
                new SystemData().GetComePhoneInfo();
                var lstCp =
                    CommonData.TaComePhoneInfo.Where(
                        s => s.CustPhoneNo.Equals(txtTelNum.Text.Trim()) && s.BusDate.Equals(strBustDate))
                        .OrderByDescending(s => Convert.ToDateTime(s.ComePhoneTime))
                        .Take(8);

                if (lstCp.Any())
                {
                    int i = 0;
                    foreach (var taComePhoneInfo in lstCp)
                    {
                        pcCust[0].Visible = true;
                        lblCustPhone[i].Text = taComePhoneInfo.CustPhoneNo;
                        lblCustInfo[i].Text = taComePhoneInfo.ComePhoneTime;
                        //strCustID[i] = taCustomerInfo.ID.ToString();

                        i++;
                    }
                }

                new SystemData().GetTaCustomer();
                TaCustomerInfo taCustomerInfo = new TaCustomerInfo();

                var lstCust = CommonData.TaCustomer.Where(s => s.cusPhone.Equals(txtTelNum.Text.Trim()));
                if (!lstCust.Any())
                {
                    //taCustomerInfo = lstCust.FirstOrDefault();
                    lblNew.Visible = true;
                    btnDelivery.Enabled = false;
                    btnCollection.Enabled = false;
                }
                else
                {
                    iCustID = lstCust.FirstOrDefault().ID;
                    lblNew.Visible = false;
                    btnDelivery.Enabled = true;
                    btnCollection.Enabled = true;
                }

                if (iCustID > 0)
                {
                    new SystemData().GetTaCheckOrder();

                    var lstCo = CommonData.TaCheckOrder.Where(s => s.BusDate.Equals(strBustDate) && !s.IsPaid.Equals("Y")).OrderByDescending(s => Convert.ToDateTime(s.PayTime)).Take(5);

                    if (lstCo.Any())
                    {
                        int j = 0;

                        var lstCheck = iCustID <= 0 ? lstCo : lstCo.Where(s => s.CustomerID.Equals(iCustID.ToString()));

                        foreach (var taCheckOrderInfo in lstCheck)
                        {
                            pcOrder[j].Visible = true;
                            lblOderNo[j].Text = taCheckOrderInfo.CheckCode;
                            lblOrderTime[j].Text = taCheckOrderInfo.PayTime;

                            if (taCheckOrderInfo.PayOrderType.Equals(PubComm.ORDER_TYPE_DELIVERY))
                            {
                                pcOrder[j].BackColor = Color.ForestGreen;
                            }
                            else if (taCheckOrderInfo.PayOrderType.Equals(PubComm.ORDER_TYPE_SHOP))
                            {
                                pcOrder[j].BackColor = Color.HotPink;
                            }
                            else if (taCheckOrderInfo.PayOrderType.Equals(PubComm.ORDER_TYPE_COLLECTION))
                            {
                                pcOrder[j].BackColor = Color.Turquoise;
                            }

                            j++;
                        }
                    }
                }
            }
        }
    }
}