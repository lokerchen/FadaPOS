using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using DevExpress.XtraEditors;
using SuperPOS.Common;
using SuperPOS.Dapper;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaPaymentShop : XtraForm
    {
        private readonly EntityControl _control = new EntityControl();
        //呼入电话ID
        private string callerID = "";
        //账单编号
        private string checkID = "";

        private Hashtable htDetail = new Hashtable();

        //付款方式数组
        private readonly LabelControl[] lblPayType = new LabelControl[5];

        //点击按钮名字
        private string objName = "txtPayTypePay1";

        private TextEdit objTxt = null;
        //操作类型
        private string orderType = "";
        //付款方式对应金额
        private TextEdit[] txtPayTypePay = new TextEdit[5];
        //用户ID
        private int usrID;

        //五种不同付款方式
        private decimal ptPay1 = 0.00m;
        private decimal ptPay2 = 0.00m;
        private decimal ptPay3 = 0.00m;
        private decimal ptPay4 = 0.00m;
        private decimal ptPay5 = 0.00m;

        //所有菜单总价格
        private decimal menuAmout = 0.00m;

        //是否已付款完成
        private bool IsPaid = false;

        //是否已经付完款
        public bool returnPaid = false;

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private bool IsNotPaid = false;

        private string strBusDate = @"";

        private string RefNum = "";

        private string strReadyTime = "";

        //在Main中被保存的账单
        private TaCheckOrderInfo saveTaCheckOrderInfo = new TaCheckOrderInfo();

        private List<TaOrderItemInfo> lstOrderItemInfos = null;

        public FrmTaPaymentShop()
        {
            InitializeComponent();
        }

        public FrmTaPaymentShop(int id, string chkId, string type, string caller, Hashtable ht)
        {
            InitializeComponent();

            usrID = id;
            checkID = chkId;
            orderType = type;
            callerID = caller;
            htDetail = ht;
        }
        
        public FrmTaPaymentShop(List<TaOrderItemInfo> lsOi, int id, string chkId, string type, string caller, Hashtable ht, string sBusDate, TaCheckOrderInfo taCheckOrder, string sReadyTime)
        {
            InitializeComponent();

            usrID = id;
            checkID = chkId;
            orderType = type;
            callerID = caller;
            htDetail = ht;
            strBusDate = sBusDate;
            saveTaCheckOrderInfo = taCheckOrder;
            strReadyTime = sReadyTime;
            lstOrderItemInfos = lsOi;
        }

        public FrmTaPaymentShop(int id, string chkId, string type, Hashtable ht, string sBusDate, TaCheckOrderInfo taCheckOrder)
        {
            InitializeComponent();

            usrID = id;
            checkID = chkId;
            orderType = type;
            htDetail = ht;
            strBusDate = sBusDate;
            saveTaCheckOrderInfo = taCheckOrder;
        }

        private void FrmTaPaymentShop_Load(object sender, EventArgs e)
        {
            //DelegateRefresh hd = DelegateMy.RefreshSomeInfo;
            //hd.BeginInvoke("5", strBusDate, "", null, null);
            //hd.BeginInvoke("1", strBusDate, "", null, null);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            DelegateRefresh hd = DelegateMy.RefreshSomeInfo;
            IAsyncResult rt = hd.BeginInvoke("1", "", "", null, null);
            //CommonDAL.RefreshSomeInfo("1", "", "");

            //订单类型
            lblTypeName.Text = PubComm.ORDER_TYPE_SHOP;

            if (lstOrderItemInfos == null)
            {
                string strSqlWhere = "";
                DynamicParameters dynamicParams = new DynamicParameters();

                strSqlWhere = " CheckCode=@CheckCode AND BusDate=@BusDate";

                dynamicParams.Add("BusDate", strBusDate);
                dynamicParams.Add("CheckCode", checkID);

                lstOrderItemInfos = new SQLiteDbHelper().QueryMultiByWhere<TaOrderItemInfo>("Ta_OrderItem", strSqlWhere, dynamicParams);
            }

            SetPayType();

            SetClick();

            #region 查询账单
            if (saveTaCheckOrderInfo == null) return;
            TaCheckOrderInfo taCheckOrder = saveTaCheckOrderInfo;

            txtPayTypePay1.Text = taCheckOrder.PayTypePay1;
            txtPayTypePay2.Text = taCheckOrder.PayTypePay2;
            txtPayTypePay3.Text = taCheckOrder.PayTypePay3;
            txtPayTypePay4.Text = taCheckOrder.PayTypePay4;
            txtPayTypePay5.Text = taCheckOrder.PayTypePay5;

            txtPercentDiscount.Text = string.IsNullOrEmpty(taCheckOrder.PayPerDiscount)
                                        ? taCheckOrder.PayPerDiscount
                                        : taCheckOrder.PayPerDiscount.Substring(0, taCheckOrder.PayPerDiscount.Length - 1);
            txtDiscount.Text = taCheckOrder.PayDiscount;

            txtPercentSurcharge.Text = string.IsNullOrEmpty(taCheckOrder.PayPerSurcharge)
                                        ? taCheckOrder.PayPerSurcharge
                                        : taCheckOrder.PayPerSurcharge.Substring(0, taCheckOrder.PayPerSurcharge.Length - 1);
            txtSurcharge.Text = taCheckOrder.PaySurcharge;

            txtTendered.Text = "0.00";
            txtToPay.Text = taCheckOrder.TotalAmount;
            menuAmout = Convert.ToDecimal(taCheckOrder.MenuAmount);
            txtChange.Text = "0.00";
            
            GetAllAmount();
            #endregion

            //默认为PayType1
            objTxt = txtPayTypePay1;
            objName = @"txtPayTypePay1";

            txtReadyTime.Text = strReadyTime;
            
            asfc.controllInitializeSize(this);

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine("#FrmTaPaymentShop_Load# Time {0}", ts.TotalMilliseconds);
            LogHelper.Info("#FrmTaPaymentShop_Load# Time:" + ts.TotalMilliseconds);
        }

        #region 获得Pay Type

        /// <summary>
        ///     获得Pay Type
        /// </summary>
        private void SetPayType()
        {
            lblPayType[0] = lblPayType1;
            lblPayType[1] = lblPayType2;
            lblPayType[2] = lblPayType3;
            lblPayType[3] = lblPayType4;
            lblPayType[4] = lblPayType5;

            txtPayTypePay[0] = txtPayTypePay1;
            txtPayTypePay[1] = txtPayTypePay2;
            txtPayTypePay[2] = txtPayTypePay3;
            txtPayTypePay[3] = txtPayTypePay4;
            txtPayTypePay[4] = txtPayTypePay5;

            var i = 0;
            foreach (var taPaymentTypeInfo in CommonData.TaPaymentType)
            {
                lblPayType[i].Text = taPaymentTypeInfo.PaymentType;
                txtPayTypePay[i].Text = @"0.00";
                i++;

                if (i > 4) break;
            }

            for (var j = i; j < 5; j++)
            {
                lblPayType[j].Visible = false;
                txtPayTypePay[j].Visible = false;
                txtPayTypePay[j].Text = @"0.00";
            }
        }

        #endregion

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
            btnClear.Click += btn_Click;
            btnDel.Click += btn_Click;
            btnPoint.Click += btn_Click;
        }

        #endregion

        #region 数字按钮输入事件
        private void btn_Click(object sender, EventArgs e)
        {
            var btn = (SimpleButton)sender;

            if (btn.Name.Equals("btnClear"))
            {
                objTxt.Text = "0.00";

                if (objTxt.Name.Equals("txtPercentDiscount"))
                {
                    txtPercentDiscount.Text = "";
                    txtDiscount.Text = @"0.00";
                }

                if (objTxt.Name.Equals("txtPercentSurcharge"))
                {
                    txtPercentSurcharge.Text = "";
                    txtSurcharge.Text = @"0.00";
                }
            }
            else if (btn.Name.Equals("btnDel"))
            {
                objTxt.Text = objTxt.Text.Length > 0 ? objTxt.Text.Substring(0, objTxt.Text.Length - 1) : "";
            }
            else if (btn.Name.Equals("btnPoint"))
            {
                if (!objTxt.Text.Contains(".")) objTxt.Text += btn.Text;
            }
            else
            {
                if (objTxt.Text.Equals("0.00") || objTxt.Text.Equals("0.0") || objTxt.Text.Equals("0") || string.IsNullOrEmpty(objTxt.Text))
                    objTxt.Text = btn.Text;
                else
                    objTxt.Text += btn.Text;
            }
        }
        #endregion
        
        #region 获得账单明细

        /// <summary>
        ///     获得账单明细
        /// </summary>
        /// <param name="chkId">账单编号</param>
        /// <returns></returns>
        private decimal GetPayDetail(string chkId)
        {
            new SystemData().GetTaPaymentDetail();

            var lstDetail = CommonData.TaPaymentDetail.Where(s => s.CheckOrder.Equals(chkId));

            return lstDetail.Any()
                ? lstDetail.Sum(s => Convert.ToDecimal(s.PayAmount))
                : 0.00m;
        }

        #endregion

        #region 不同付款方式各自付款
        /// <summary>
        /// 不同付款方式各自付款
        /// </summary>
        private void GetPayTypePayment()
        {
            if (lblPayType1.Visible)
            {
                ptPay1 = TxtToDecimal(txtPayTypePay1);
            }

            if (lblPayType2.Visible)
            {
                ptPay2 = TxtToDecimal(txtPayTypePay2);
            }

            if (lblPayType3.Visible)
            {
                ptPay3 = TxtToDecimal(txtPayTypePay3);
            }

            if (lblPayType4.Visible)
            {
                ptPay4 = TxtToDecimal(txtPayTypePay4);
            }

            if (lblPayType5.Visible)
            {
                ptPay5 = TxtToDecimal(txtPayTypePay5);
            }
        }

        #endregion

        #region 根据文本框返回具体数字
        /// <summary>
        /// 根据文本框返回具体数字
        /// </summary>
        /// <param name="txt">文本框</param>
        /// <returns></returns>
        private decimal TxtToDecimal(TextEdit txt)
        {
            try
            {
                return Convert.ToDecimal(string.IsNullOrEmpty(txt.Text) ? @"0.00" : txt.Text);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
                return 0.0m;
            }
        }
        #endregion

        #region 退出

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Save按钮

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 注释代码
            //new SystemData().GetTaCheckOrder();

            //TaCheckOrderInfo taCheckOrderInfo = new TaCheckOrderInfo
            //{
            //    CheckCode = checkID,
            //    PayOrderType = orderType,
            //    PayDelivery = @"0.00",
            //    PayDiscount = txtDiscount.Text,
            //    PaySurcharge = txtSurcharge.Text,
            //    MenuAmount = "",
            //    TotalAmount = txtToPay.Text,
            //    Paid = txtTendered.Text,
            //    IsPaid = "N",
            //    CustomerID = callerID,
            //    CustomerNote = "",
            //    DriverID = 1,
            //    StaffID = usrID,
            //    PayTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            //    PayType1 = lblPayType1.Text,
            //    PayTypePay1 = txtPayTypePay1.Text,
            //    PayType2 = lblPayType2.Text,
            //    PayTypePay2 = txtPayTypePay2.Text,
            //    PayType3 = lblPayType3.Text,
            //    PayTypePay3 = txtPayTypePay3.Text,
            //    PayType4 = lblPayType4.Text,
            //    PayTypePay4 = txtPayTypePay4.Text
            //};

            //if (Convert.ToDecimal(txtTendered.Text) >= Convert.ToDecimal(txtToPay.Text))
            //{
            //    IsPaid = true;
            //    taCheckOrderInfo.IsPaid = "Y";
            //}

            //if (CommonData.TaCheckOrder.Any(s => s.CheckCode.Equals(checkID)))
            //{
            //    taCheckOrderInfo.ID = CommonData.TaCheckOrder.FirstOrDefault(s => s.CheckCode.Equals(checkID)).ID;
            //    _control.UpdateEntity(taCheckOrderInfo);
            //}
            //else
            //{
            //    _control.AddEntity(taCheckOrderInfo);
            //}
            //DialogResult = DialogResult.OK;
            //Hide();
            #endregion
           
            SaveOrder();
        }

        #endregion

        #region Text编辑事件
        private void txtPayTypePay1_EditValueChanged(object sender, EventArgs e)
        {
            RefreshAmount();
        }

        private void txtPayTypePay2_EditValueChanged(object sender, EventArgs e)
        {
            RefreshAmount();
        }

        private void txtPayTypePay3_EditValueChanged(object sender, EventArgs e)
        {
            RefreshAmount();
        }

        private void txtPayTypePay4_EditValueChanged(object sender, EventArgs e)
        {
            RefreshAmount();
        }

        private void txtPayTypePay5_EditValueChanged(object sender, EventArgs e)
        {
            RefreshAmount();
        }

        private void txtPercentDiscount_EditValueChanged(object sender, EventArgs e)
        {
            RefreshAmount();
        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {
            RefreshAmount();
        }

        private void txtPercentSurcharge_EditValueChanged(object sender, EventArgs e)
        {
            RefreshAmount();
        }

        private void txtSurcharge_EditValueChanged(object sender, EventArgs e)
        {
            RefreshAmount();
        }
        #endregion

        #region 计算所有账单

        private void GetAllAmount()
        {
            decimal discount = 0.00m;
            decimal surcharge = 0.00m;

            //菜单总金额
            //decimal menuTotal = menuAmout;

            discount = GetDiscount(menuAmout);
            surcharge = GetSurcharge(menuAmout);

            //折扣 > 菜单总价 = 免单
            if (discount >= menuAmout)
            {
                surcharge = 0.00m;
                txtToPay.Text = @"0.00";
                txtTendered.Text = @"0.00";
                txtChange.Text = @"0.00";

                lblCtlDiscount.Text = menuAmout.ToString("0.00");
            }
            else
            {
                //需付款
                txtToPay.Text = (menuAmout - discount + surcharge).ToString("0.00");

                //已付款金额
                txtTendered.Text = (ptPay1 + ptPay2 + ptPay3 + ptPay4 + ptPay5).ToString("0.00");

                //找零
                decimal change = Convert.ToDecimal(txtTendered.Text) - Convert.ToDecimal(txtToPay.Text);
                txtChange.Text = change.ToString("0.00");

                lblCtlDiscount.Text = discount.ToString("0.00");
            }

            lblCtlSurcharge.Text = surcharge.ToString("0.00");

            IsPaid = Convert.ToDecimal(txtTendered.Text) >= Convert.ToDecimal(txtToPay.Text);
        }
        #endregion

        #region 计算折扣
        /// <summary>
        /// 计算折扣
        /// </summary>
        /// <param name="dTotal">菜单总金额</param>
        /// <returns></returns>
        private decimal GetDiscount(decimal dTotal)
        {
            //百分比折扣
            try
            {
                if (!string.IsNullOrEmpty(txtPercentDiscount.Text))
                {
                    if (Convert.ToDecimal(txtPercentDiscount.Text) >= 100)
                    {
                        return dTotal;
                    }
                    else
                    {
                        if (Convert.ToDecimal(txtPercentDiscount.Text) <= 0)
                        {
                            return 0.0m;
                        }
                        else
                        {
                            decimal tmpDiscount = dTotal * (Convert.ToDecimal(txtPercentDiscount.Text) / 100);
                            txtDiscount.Text = tmpDiscount.ToString("F");
                            return tmpDiscount;
                        }
                    }
                }
                else
                {
                    return Convert.ToDecimal(txtDiscount.Text);
                }
                //return string.IsNullOrEmpty(txtDiscount.Text) ? 0.00m : Convert.ToDecimal(txtDiscount.Text);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
                return 0.0m;
            }
        }

        #endregion

        #region 计算Surcharge
        /// <summary>
        /// 计算Surcharge
        /// </summary>
        /// <param name="dTotal">菜单金额</param>
        /// <returns></returns>
        private decimal GetSurcharge(decimal dTotal)
        {
            //百分比折扣
            try
            {
                if (!string.IsNullOrEmpty(txtPercentSurcharge.Text))
                {
                    if (Convert.ToDecimal(txtPercentSurcharge.Text) >= 100)
                    {
                        return dTotal;
                    }
                    else
                    {
                        if (Convert.ToDecimal(txtPercentSurcharge.Text) <= 0)
                        {
                            return 0.0m;
                        }
                        else
                        {
                            decimal tmpDiscount = dTotal * (Convert.ToDecimal(txtPercentSurcharge.Text) / 100);
                            txtSurcharge.Text = tmpDiscount.ToString("F");
                            return tmpDiscount;
                        }
                    }
                }
                else
                {
                    return Convert.ToDecimal(txtSurcharge.Text);
                }
                //return string.IsNullOrEmpty(txtSurcharge.Text) ? 0.00m : Convert.ToDecimal(txtSurcharge.Text);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
                return 0.0m;
            }
        }

        #endregion

        #region 重新计算所有账单

        private void RefreshAmount()
        {
            GetPayTypePayment();

            txtTendered.Text = (ptPay1 + ptPay2 + ptPay3 + ptPay4 + ptPay5).ToString("0.00");

            GetAllAmount();
        }

        #endregion

        #region PayType Click事件
        private void lblPayType1_Click(object sender, EventArgs e)
        {
            txtPayTypePay1.Text = Convert.ToDecimal(txtToPay.Text) > Convert.ToDecimal(txtTendered.Text)
                ? (Convert.ToDecimal(txtToPay.Text) - Convert.ToDecimal(txtTendered.Text)).ToString("0.00")
                : "0.00";

            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;

            //if (!txtPayTypePay1.Text.Equals(txtToPay.Text)) txtPayTypePay1.Text = txtToPay.Text;
            
            //txtPayTypePay2.Text = @"0.00";
            //txtPayTypePay3.Text = @"0.00";
            //txtPayTypePay4.Text = @"0.00";
            //txtPayTypePay5.Text = @"0.00";
            RefreshAmount();
        }

        private void lblPayType2_Click(object sender, EventArgs e)
        {
            txtPayTypePay2.Text = Convert.ToDecimal(txtToPay.Text) > Convert.ToDecimal(txtTendered.Text)
                ? (Convert.ToDecimal(txtToPay.Text) - Convert.ToDecimal(txtTendered.Text)).ToString("0.00")
                : "0.00";

            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;

            //if (!txtPayTypePay2.Text.Equals(txtToPay.Text)) txtPayTypePay2.Text = txtToPay.Text;

            //txtPayTypePay1.Text = @"0.00";
            
            //txtPayTypePay3.Text = @"0.00";
            //txtPayTypePay4.Text = @"0.00";
            //txtPayTypePay5.Text = @"0.00";

            RefreshAmount();
        }

        private void lblPayType3_Click(object sender, EventArgs e)
        {
            txtPayTypePay3.Text = Convert.ToDecimal(txtToPay.Text) > Convert.ToDecimal(txtTendered.Text)
                ? (Convert.ToDecimal(txtToPay.Text) - Convert.ToDecimal(txtTendered.Text)).ToString("0.00")
                : "0.00";

            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;
            //if (!txtPayTypePay3.Text.Equals(txtToPay.Text)) txtPayTypePay3.Text = txtToPay.Text;

            //txtPayTypePay1.Text = @"0.00";
            //txtPayTypePay2.Text = @"0.00";
            
            //txtPayTypePay4.Text = @"0.00";
            //txtPayTypePay5.Text = @"0.00";

            RefreshAmount();
        }

        private void lblPayType4_Click(object sender, EventArgs e)
        {
            txtPayTypePay4.Text = Convert.ToDecimal(txtToPay.Text) > Convert.ToDecimal(txtTendered.Text)
                ? (Convert.ToDecimal(txtToPay.Text) - Convert.ToDecimal(txtTendered.Text)).ToString("0.00")
                : "0.00";

            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;
            //if (!txtPayTypePay4.Text.Equals(txtToPay.Text)) txtPayTypePay4.Text = txtToPay.Text;

            //txtPayTypePay1.Text = @"0.00";
            //txtPayTypePay2.Text = @"0.00";
            //txtPayTypePay3.Text = @"0.00";
            
            //txtPayTypePay5.Text = @"0.00";

            RefreshAmount();
        }

        private void lblPayType5_Click(object sender, EventArgs e)
        {
            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;
            txtPayTypePay5.Text = Convert.ToDecimal(txtToPay.Text) > Convert.ToDecimal(txtTendered.Text)
                ? (Convert.ToDecimal(txtToPay.Text) - Convert.ToDecimal(txtTendered.Text)).ToString("0.00")
                : "0.00";

            //txtPayTypePay1.Text = @"0.00";
            //txtPayTypePay2.Text = @"0.00";
            //txtPayTypePay3.Text = @"0.00";
            //txtPayTypePay4.Text = @"0.00";

            RefreshAmount();
        }
        #endregion

        #region 鼠标按下事件
        private void txtPayTypePay1_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtPayTypePay1";
            objTxt = txtPayTypePay1;
            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;
        }

        private void txtPayTypePay2_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtPayTypePay2";
            objTxt = txtPayTypePay2;
            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;
        }

        private void txtPayTypePay3_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtPayTypePay3";
            objTxt = txtPayTypePay3;
            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;
        }

        private void txtPayTypePay4_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtPayTypePay4";
            objTxt = txtPayTypePay4;
            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;
        }

        private void txtPayTypePay5_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtPayTypePay5";
            objTxt = txtPayTypePay5;
            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;
        }

        private void txtPercentDiscount_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtPercentDiscount";
            objTxt = txtPercentDiscount;
            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;
        }

        private void txtDiscount_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtDiscount";
            objTxt = txtDiscount;
            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;
        }

        private void txtPercentSurcharge_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtPercentSurcharge";
            objTxt = txtPercentSurcharge;
            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;
        }

        private void txtSurcharge_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtSurcharge";
            objTxt = txtSurcharge;
            IsNotPaid = false;
            btnNotPaid.Appearance.BackColor = Color.Red;
        }
        #endregion

        #region 保存账单

        private void SaveOrder()
        {
            if (txtReadyTime.Text.Length > 0)
            {
                if (txtReadyTime.Text.Length != 5)
                {
                    MessageBox.Show("Ready Time INPUT Error", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            //new SystemData().GetTaCheckOrder();
            //var lstChk = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate));
            //new SystemData().GetTaCheckOrderByCheckCodeAndBusDate(checkID, strBusDate);

            //var lstChk = CommonData.TaCheckOrderByCheckCodeAndBusDate;

            //if (lstChk.Any())
            //{
            //    TaCheckOrderInfo taCheckOrder = lstChk.FirstOrDefault();

            if (saveTaCheckOrderInfo != null)
            {
                TaCheckOrderInfo taCheckOrder = saveTaCheckOrderInfo;

                taCheckOrder.PayTime = DateTime.Now.ToString();
                taCheckOrder.PayPerDiscount = txtPercentDiscount.Text;
                taCheckOrder.PayDiscount = Math.Round(Convert.ToDecimal(txtDiscount.Text), 2).ToString(@"0.00");
                taCheckOrder.PayPerSurcharge = txtPercentSurcharge.Text;
                taCheckOrder.PaySurcharge = Math.Round(Convert.ToDecimal(txtSurcharge.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType1 = lblPayType1.Text;
                taCheckOrder.PayTypePay1 = Math.Round(Convert.ToDecimal(txtPayTypePay1.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType2 = lblPayType2.Text;
                taCheckOrder.PayTypePay2 = Math.Round(Convert.ToDecimal(txtPayTypePay2.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType3 = lblPayType3.Text;
                taCheckOrder.PayTypePay3 = Math.Round(Convert.ToDecimal(txtPayTypePay3.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType4 = lblPayType4.Text;
                taCheckOrder.PayTypePay4 = Math.Round(Convert.ToDecimal(txtPayTypePay4.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType5 = lblPayType5.Text;
                taCheckOrder.PayTypePay5 = Math.Round(Convert.ToDecimal(txtPayTypePay5.Text), 2).ToString(@"0.00");
                taCheckOrder.TotalAmount = Math.Round(Convert.ToDecimal(txtToPay.Text), 2).ToString(@"0.00");
                taCheckOrder.Paid = Math.Round(Convert.ToDecimal(txtTendered.Text), 2).ToString(@"0.00");
                taCheckOrder.IsPaid = IsPaid ? @"Y" : @"N";

                taCheckOrder.BusDate = strBusDate;

                taCheckOrder.RefNum = RefNum;

                taCheckOrder.DeliveryFee = @"0.00";

                //_control.UpdateEntity(taCheckOrder);
                //DelegateSaveCheckOrder handler = DelegateMy.SaveCheckOrder;
                //IAsyncResult result = handler.BeginInvoke(taCheckOrder, true,null, null);
                CommonDAL.SaveOrUpdateCheckOrder(taCheckOrder);
            }

            bool isOpenCashDrawSuccess = CommonDAL.OpenCashDraw(false, "");

            if (!isOpenCashDrawSuccess)
                MessageBox.Show(PubComm.CASH_DRAW_INFO, PubComm.CASH_DRAW_TEXT_TITLE, MessageBoxButtons.OK);

            if (IsPaid)
            {
                returnPaid = true;

                this.DialogResult = DialogResult.OK;

                Hide();
            }
            else
            {
                if (IsNotPaid)
                {
                    returnPaid = true;

                    this.DialogResult = DialogResult.OK;

                    Hide();
                }
            }
        }

        #endregion

        #region Not Paid时
        private void SaveOrder(bool isPaid)
        {
            if (txtReadyTime.Text.Length > 0)
            {
                if (txtReadyTime.Text.Length != 5)
                {
                    MessageBox.Show("Ready Time INPUT Error", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            //new SystemData().GetTaCheckOrder();
            //var lstChk = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate));
            //new SystemData().GetTaCheckOrderByCheckCodeAndBusDate(checkID, strBusDate);

            //var lstChk = CommonData.TaCheckOrderByCheckCodeAndBusDate;

            //if (lstChk.Any())
            //{
            //    TaCheckOrderInfo taCheckOrder = lstChk.FirstOrDefault();
            if (saveTaCheckOrderInfo != null)
            {
                TaCheckOrderInfo taCheckOrder = saveTaCheckOrderInfo;

                taCheckOrder.PayTime = DateTime.Now.ToString();
                taCheckOrder.PayPerDiscount = txtPercentDiscount.Text;
                taCheckOrder.PayDiscount = Math.Round(Convert.ToDecimal(txtDiscount.Text), 2).ToString(@"0.00");
                taCheckOrder.PayPerSurcharge = txtPercentSurcharge.Text;
                taCheckOrder.PaySurcharge = Math.Round(Convert.ToDecimal(txtSurcharge.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType1 = lblPayType1.Text;
                taCheckOrder.PayTypePay1 = Math.Round(Convert.ToDecimal(txtPayTypePay1.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType2 = lblPayType2.Text;
                taCheckOrder.PayTypePay2 = Math.Round(Convert.ToDecimal(txtPayTypePay2.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType3 = lblPayType3.Text;
                taCheckOrder.PayTypePay3 = Math.Round(Convert.ToDecimal(txtPayTypePay3.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType4 = lblPayType4.Text;
                taCheckOrder.PayTypePay4 = Math.Round(Convert.ToDecimal(txtPayTypePay4.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType5 = lblPayType5.Text;
                taCheckOrder.PayTypePay5 = Math.Round(Convert.ToDecimal(txtPayTypePay5.Text), 2).ToString(@"0.00");
                taCheckOrder.TotalAmount = Math.Round(Convert.ToDecimal(txtToPay.Text), 2).ToString(@"0.00");
                taCheckOrder.Paid = Math.Round(Convert.ToDecimal(txtTendered.Text), 2).ToString(@"0.00");
                taCheckOrder.IsPaid = isPaid ? @"Y" : @"N";

                taCheckOrder.BusDate = strBusDate;

                taCheckOrder.DeliveryFee = @"0.00";

                taCheckOrder.RefNum = RefNum;

                saveTaCheckOrderInfo = taCheckOrder;

                //_control.UpdateEntity(taCheckOrder);
                //DelegateSaveCheckOrder handler = DelegateMy.SaveCheckOrder;
                //IAsyncResult result = handler.BeginInvoke(taCheckOrder, true,null, null);
                CommonDAL.SaveOrUpdateCheckOrder(taCheckOrder);
            }

            returnPaid = true;

            //this.DialogResult = DialogResult.OK;

            //Hide();
        }
        #endregion

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (objTxt.Name.Equals("txtPercentDiscount") || objTxt.Name.Equals("txtPercentSurcharge"))
                objTxt.Text = "%";
        }

        private void FrmTaPaymentShop_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnPrtAll_Click(object sender, EventArgs e)
        {
            //保存账单信息
            //SaveOrder();
            
            ////未完成付款
            //if (!IsPaid) return;

            //new SystemData().GetTaOrderItem();
            //var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate)).ToList();

            //WbPrtTemplataTa wbPrtTemplataTa = new WbPrtTemplataTa();

            //wbPrtTemplataTa = GetAllPrtInfo();

            //WbPrtPrint.PrintHtml(webBrowser1,
            //    string.IsNullOrEmpty(RefNum)
            //        ? WbPrtStatic.PRT_TEMPLATE_FILE_ALL_SHOP
            //        : WbPrtStatic.PRT_TEMPLATE_FILE_ALL_SHOP_FASTFOOD, lstOI, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP);

            //WbPrtPrint.PrintHtml( WbPrtStatic.PRT_CLASS_ALL, lstOI, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP);

            //DelegatePrintHtml handler = DelegateMy.PrtHtml;
            //IAsyncResult result = handler.BeginInvoke(checkID, strBusDate, lstOrderItemInfos, WbPrtStatic.PRT_CLASS_ALL, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP, null, null);
            SaveOrderAndPrint(WbPrtStatic.PRT_CLASS_ALL);
        }
        
        private void btnPrtAllReceipt_Click(object sender, EventArgs e)
        {
            //保存账单信息
            //SaveOrder();

            ////未完成付款
            //if (!IsPaid) return;

            //new SystemData().GetTaOrderItem();
            //var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate)).ToList();

            //WbPrtTemplataTa wbPrtTemplataTa = new WbPrtTemplataTa();

            //wbPrtTemplataTa = GetAllPrtInfo();

            //WbPrtPrint.PrintHtml(webBrowser1,
            //    string.IsNullOrEmpty(RefNum)
            //        ? WbPrtStatic.PRT_TEMPLATE_FILE_ALL_SHOP
            //        : WbPrtStatic.PRT_TEMPLATE_FILE_ALL_SHOP_FASTFOOD, lstOI, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP);

            //WbPrtPrint.PrintHtml(webBrowser1, WbPrtStatic.PRT_CLASS_ALL, lstOI, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP);

            //DelegatePrintHtml handler = DelegateMy.PrtHtml;
            //IAsyncResult result = handler.BeginInvoke(checkID, strBusDate, lstOrderItemInfos, WbPrtStatic.PRT_CLASS_ALL_AND_RECEIPT, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP, null, null);
            SaveOrderAndPrint(WbPrtStatic.PRT_CLASS_ALL_AND_RECEIPT);
        }

        private void btnPrtBillOnly_Click(object sender, EventArgs e)
        {
            //保存账单信息
            //SaveOrder();

            ////未完成付款
            //if (!IsPaid) return;

            //new SystemData().GetTaOrderItem();
            //var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate)).ToList();

            //WbPrtTemplataTa wbPrtTemplataTa = new WbPrtTemplataTa();

            //wbPrtTemplataTa = GetAllPrtInfo();

            //WbPrtPrint.PrintHtml(webBrowser1,
            //    string.IsNullOrEmpty(RefNum)
            //        ? WbPrtStatic.PRT_TEMPLATE_FILE_ALL_SHOP
            //        : WbPrtStatic.PRT_TEMPLATE_FILE_ALL_SHOP_FASTFOOD, lstOI, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP);

            //WbPrtPrint.PrintHtml(webBrowser1, WbPrtStatic.PRT_CLASS_ALL, lstOI, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP);

            //DelegatePrintHtml handler = DelegateMy.PrtHtml;
            //IAsyncResult result = handler.BeginInvoke(checkID, strBusDate, lstOrderItemInfos, WbPrtStatic.PRT_CLASS_BILL, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP, null, null);
            SaveOrderAndPrint(WbPrtStatic.PRT_CLASS_BILL);
        }

        private void btnPrtKitOnly_Click(object sender, EventArgs e)
        {
            //保存账单信息
            //SaveOrder();

            ////未完成付款
            //if (!IsPaid) return;

            //new SystemData().GetTaOrderItem();
            //var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate)).ToList();

            //WbPrtTemplataTa wbPrtTemplataTa = new WbPrtTemplataTa();

            //wbPrtTemplataTa = GetAllPrtInfo();

            //WbPrtPrint.PrintHtml(webBrowser1,
            //    string.IsNullOrEmpty(RefNum)
            //        ? WbPrtStatic.PRT_TEMPLATE_FILE_ALL_SHOP
            //        : WbPrtStatic.PRT_TEMPLATE_FILE_ALL_SHOP_FASTFOOD, lstOI, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP);

            //WbPrtPrint.PrintHtml(webBrowser1, WbPrtStatic.PRT_CLASS_ALL, lstOI, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP);

            //DelegatePrintHtml handler = DelegateMy.PrtHtml;

            //IAsyncResult result = handler.BeginInvoke(checkID, strBusDate, lstOrderItemInfos, WbPrtStatic.PRT_CLASS_KITCHEN, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP, null, null);

            //WbPrtPrint.PrintHtml(webBrowser1, WbPrtStatic.PRT_CLASS_KITCHEN, lstOI, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP);

            //WbPrtPrintTest.PrintHtml(WbPrtStatic.PRT_CLASS_KITCHEN, lstOrderItemInfos, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP);
            SaveOrderAndPrint(WbPrtStatic.PRT_CLASS_KITCHEN);
        }

        private void btnNotPaid_Click(object sender, EventArgs e)
        {
            //DelegateRefresh hd = DelegateMy.RefreshSomeInfo;
            //IAsyncResult rt = hd.BeginInvoke("1", "", "", null, null);
            CommonDAL.RefreshSomeInfo("1", "", "");

            SaveOrder(false);

            btnNotPaid.Appearance.BackColor = Color.ForestGreen;

            IsNotPaid = true;
            IsPaid = false;
        }

        private WbPrtTemplataTa GetAllPrtInfo(string strPrintType)
        {
            WbPrtTemplataTa wbPrtTemplataTa = new WbPrtTemplataTa();
            //new SystemData().GetTaSysPrtSetGeneral();
            TaSysPrtSetGeneralInfo taSysPrtSetGeneralInfo = CommonData.TaSysPrtSetGeneral.FirstOrDefault(); ;
            
            if (taSysPrtSetGeneralInfo != null)
            {
                //wbPrtTemplataTa.PrintAddress = taSysPrtSetGeneralInfo.IsPrtAddr;
                //new SystemData().GetTaSysCtrl();
                var lstTaSysCtrl = CommonData.TaSysCtrl;

                if (lstTaSysCtrl.Any())
                {
                    wbPrtTemplataTa.PrintAddress = lstTaSysCtrl.FirstOrDefault().ShopAddress;
                }
                wbPrtTemplataTa.PrintTel = taSysPrtSetGeneralInfo.TelNo;
                wbPrtTemplataTa.VATNo = taSysPrtSetGeneralInfo.VATNo;
                wbPrtTemplataTa.Msg1 = taSysPrtSetGeneralInfo.Msg1;
                wbPrtTemplataTa.Msg2 = taSysPrtSetGeneralInfo.Msg2;
                wbPrtTemplataTa.Msg3 = taSysPrtSetGeneralInfo.Msg3;
                wbPrtTemplataTa.Msg4 = taSysPrtSetGeneralInfo.Msg4;
                wbPrtTemplataTa.Msg5 = taSysPrtSetGeneralInfo.Msg5;
            }

            if (!string.IsNullOrEmpty(callerID))
            {
                //new SystemData().GetTaCustomer();
                var lstCust = CommonData.TaCustomer.Where(s => s.ID.ToString().Equals(callerID));
                if (lstCust.Any())
                {
                    TaCustomerInfo taCustomerInfo = lstCust.FirstOrDefault();
                    wbPrtTemplataTa.CustName = taCustomerInfo.cusName;
                    wbPrtTemplataTa.CustPhone = taCustomerInfo.cusPhone;
                    wbPrtTemplataTa.CustDist = taCustomerInfo.cusDistance;
                    wbPrtTemplataTa.CustMapRef = taCustomerInfo.cusPcZone;
                    wbPrtTemplataTa.CustHouseNo = taCustomerInfo.cusHouseNo;
                    wbPrtTemplataTa.CustAddr = taCustomerInfo.cusAddr;
                    wbPrtTemplataTa.CustPostCode = taCustomerInfo.cusPostcode;
                    //wbPrtTemplataTa.ShopTime = taCustomerInfo.cusReadyTime;
                }
            }
            


            wbPrtTemplataTa.ShopTime = string.IsNullOrEmpty(txtReadyTime.Text) ? "ASAP" : txtReadyTime.Text;

            wbPrtTemplataTa.OrderDate = DateTime.Now.ToShortDateString();
            wbPrtTemplataTa.OrderTime = DateTime.Now.ToShortTimeString();
            wbPrtTemplataTa.Staff = htDetail["Staff"].ToString();
            wbPrtTemplataTa.OrderNo = checkID;
            wbPrtTemplataTa.ItemCount = htDetail["ItemQty"].ToString();
            wbPrtTemplataTa.SubTotal = htDetail["SubTotal"].ToString();
            wbPrtTemplataTa.Total = txtToPay.Text;
            wbPrtTemplataTa.PayType = IsNotPaid ? @"NOT PAID" : CommonDAL.GetPayType(saveTaCheckOrderInfo);
            wbPrtTemplataTa.Tendered = txtTendered.Text;
            wbPrtTemplataTa.Change = string.IsNullOrEmpty(txtChange.Text) ? "0.00" : (Convert.ToDecimal(txtChange.Text)).ToString("0.00");
            wbPrtTemplataTa.OrderType = orderType;
            wbPrtTemplataTa.RefNo = RefNum;
            wbPrtTemplataTa.DeliveryFee = @"0.00";
            wbPrtTemplataTa.Discount = txtDiscount.Text;
            wbPrtTemplataTa.Surcharge = txtSurcharge.Text;

            #region VAT计算

            if (strPrintType.Equals(WbPrtStatic.PRT_CLASS_ALL_AND_RECEIPT))
            {
                GenSetInfo gsi = CommonData.GenSet.FirstOrDefault();

                if (gsi != null)
                {
                    var lstVAT = from oi in lstOrderItemInfos
                                 join mi in CommonData.TaMenuItem on oi.ItemCode equals mi.MiDishCode
                        select new
                        {
                            VatInfo = mi.MiRmk,
                            ItemTotalPrice = oi.ItemTotalPrice
                        };
                    //new SystemData().GetOrderItemMatchVat(checkID, strBusDate);
                    //var lstVAT = CommonData.GetOrderItemMatchVat;

                    decimal dTotal = 0;
                    decimal dVatTmp = 0;
                    decimal dVat = 0;

                    if (lstVAT.Any())
                    {
                        //VAT1
                        wbPrtTemplataTa.Rate1 = gsi.VATPer + @"%";

                        dTotal = lstVAT.Where(s => !s.VatInfo.Contains("Without VAT")).ToList().Sum(vat => Convert.ToDecimal(vat.ItemTotalPrice));
                        //交税
                        dVatTmp = dTotal / ((100 + Convert.ToDecimal(gsi.VATPer)) / 100);
                        dVat = Math.Round(dVatTmp, 2, MidpointRounding.AwayFromZero);
                        //
                        wbPrtTemplataTa.Net1 = dVat.ToString("0.00");

                        wbPrtTemplataTa.VatA = (dTotal - dVat).ToString("0.00");

                        wbPrtTemplataTa.Gross1 = dTotal.ToString("0.00");

                        //VAT2
                        dTotal = lstVAT.Where(s => s.VatInfo.Contains("Without VAT")).ToList().Sum(vat => Convert.ToDecimal(vat.ItemTotalPrice));
                        wbPrtTemplataTa.Rate2 = @"0.0%";
                        wbPrtTemplataTa.Net2 = dTotal.ToString("0.00");
                        wbPrtTemplataTa.VatB = @"0.00";
                        wbPrtTemplataTa.Gross2 = dTotal.ToString("0.00");
                    }
                }
                else
                {
                    wbPrtTemplataTa.Rate1 = "0.00%";
                    wbPrtTemplataTa.Net1 = "0.00";
                    wbPrtTemplataTa.VatA = "0.00";
                    wbPrtTemplataTa.Gross1 = "0.00";
                    wbPrtTemplataTa.Rate2 = "0.00%";
                    wbPrtTemplataTa.Net2 = "0.00";
                    wbPrtTemplataTa.VatB = "0.00";
                    wbPrtTemplataTa.Gross2 = "0.00";
                }
            }
            #endregion

            return wbPrtTemplataTa;
        }

        private void btnFastFood_Click(object sender, EventArgs e)
        {
            SaveOrder(false);

            FrmTaPaymentShopFastFood frmTaPaymentShopFastFood = new FrmTaPaymentShopFastFood(checkID, strBusDate);
            frmTaPaymentShopFastFood.Location = groupBox1.PointToScreen(groupBox1.Location);
            frmTaPaymentShopFastFood.Size = this.Size;

            if (frmTaPaymentShopFastFood.ShowDialog() == DialogResult.OK)
            {
                RefNum = frmTaPaymentShopFastFood.RefNum;
            }
        }

        private void txtReadyTime_Click(object sender, EventArgs e)
        {
            FrmTaCustReadyTime frmTaCustReadyTime = new FrmTaCustReadyTime();
            frmTaCustReadyTime.Location = new Point(this.txtReadyTime.Location.X + this.Location.X, txtReadyTime.Location.Y - frmTaCustReadyTime.Height);

            if (frmTaCustReadyTime.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(frmTaCustReadyTime.strShopTime))
                {
                    txtReadyTime.Text = frmTaCustReadyTime.strShopTime;
                }
            }
        }

        #region 保存账单并打印
        private void SaveOrderAndPrint(string strPrintType)
        {
            if (txtReadyTime.Text.Length > 0)
            {
                if (txtReadyTime.Text.Length != 5)
                {
                    MessageBox.Show("Ready Time INPUT Error", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (saveTaCheckOrderInfo != null)
            {
                TaCheckOrderInfo taCheckOrder = saveTaCheckOrderInfo;

                taCheckOrder.PayTime = DateTime.Now.ToString();
                taCheckOrder.PayPerDiscount = txtPercentDiscount.Text;
                taCheckOrder.PayDiscount = Math.Round(Convert.ToDecimal(txtDiscount.Text), 2).ToString(@"0.00");
                taCheckOrder.PayPerSurcharge = txtPercentSurcharge.Text;
                taCheckOrder.PaySurcharge = Math.Round(Convert.ToDecimal(txtSurcharge.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType1 = lblPayType1.Text;
                taCheckOrder.PayTypePay1 = Math.Round(Convert.ToDecimal(txtPayTypePay1.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType2 = lblPayType2.Text;
                taCheckOrder.PayTypePay2 = Math.Round(Convert.ToDecimal(txtPayTypePay2.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType3 = lblPayType3.Text;
                taCheckOrder.PayTypePay3 = Math.Round(Convert.ToDecimal(txtPayTypePay3.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType4 = lblPayType4.Text;
                taCheckOrder.PayTypePay4 = Math.Round(Convert.ToDecimal(txtPayTypePay4.Text), 2).ToString(@"0.00");
                taCheckOrder.PayType5 = lblPayType5.Text;
                taCheckOrder.PayTypePay5 = Math.Round(Convert.ToDecimal(txtPayTypePay5.Text), 2).ToString(@"0.00");
                taCheckOrder.TotalAmount = Math.Round(Convert.ToDecimal(txtToPay.Text), 2).ToString(@"0.00");
                taCheckOrder.Paid = Math.Round(Convert.ToDecimal(txtTendered.Text), 2).ToString(@"0.00");
                taCheckOrder.IsPaid = IsPaid ? @"Y" : @"N";

                taCheckOrder.BusDate = strBusDate;

                taCheckOrder.RefNum = RefNum;

                taCheckOrder.DeliveryFee = @"0.00";

                WbPrtTemplataTa wbPrtTemplataTa = new WbPrtTemplataTa();

                if (lstOrderItemInfos.Count < 1)
                    lstOrderItemInfos = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate)).ToList();

                wbPrtTemplataTa = GetAllPrtInfo(strPrintType);

                //_control.UpdateEntity(taCheckOrder);
                DelegateSaveCheckOrderAndPrint handler = DelegateMy.CheckOrderSaveAndPrint;
                IAsyncResult result = handler.BeginInvoke(taCheckOrder, strPrintType, lstOrderItemInfos,
                    wbPrtTemplataTa, taCheckOrder.PayOrderType, null, null);
            }

            bool isOpenCashDrawSuccess = CommonDAL.OpenCashDraw(false, "");

            if (!isOpenCashDrawSuccess)
                MessageBox.Show(PubComm.CASH_DRAW_INFO, PubComm.CASH_DRAW_TEXT_TITLE, MessageBoxButtons.OK);

            if (IsPaid)
            {
                returnPaid = true;

                this.DialogResult = DialogResult.OK;

                Hide();
            }
            else
            {
                if (IsNotPaid)
                {
                    returnPaid = true;

                    this.DialogResult = DialogResult.OK;

                    Hide();
                }
            }
        }
        #endregion
    }
}