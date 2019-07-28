using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SuperPOS.Common;
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
        private readonly LabelControl[] lblPayType = new LabelControl[4];

        //点击按钮名字
        private string objName = "txtPayTypePay1";

        private TextEdit objTxt = null;
        //操作类型
        private string orderType = "";
        //付款方式对应金额
        private TextEdit[] txtPayTypePay = new TextEdit[4];
        //用户ID
        private int usrID;

        //四种不同付款方式
        private decimal ptPay1 = 0.00m;
        private decimal ptPay2 = 0.00m;
        private decimal ptPay3 = 0.00m;
        private decimal ptPay4 = 0.00m;

        //所有菜单总价格
        private decimal menuAmout = 0.00m;

        //是否已付款完成
        private bool IsPaid = false;

        //是否已经付完款
        public bool returnPaid = false;

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

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

        private void FrmTaPaymentShop_Load(object sender, EventArgs e)
        {
            //订单类型
            lblTypeName.Text = PubComm.ORDER_TYPE_SHOP;

            SetPayType();

            SetClick();

            #region 查询账单
            new SystemData().GetTaCheckOrder();

            if (CommonData.TaCheckOrder.Any(s => s.CheckCode.Equals(checkID) && s.IsPaid.Equals("N")))
            {
                TaCheckOrderInfo taCheckOrder =
                    CommonData.TaCheckOrder.FirstOrDefault(s => s.CheckCode.Equals(checkID) && s.IsPaid.Equals("N"));

                txtPayTypePay1.Text = taCheckOrder.PayTypePay1;
                txtPayTypePay2.Text = taCheckOrder.PayTypePay2;
                txtPayTypePay3.Text = taCheckOrder.PayTypePay3;
                txtPayTypePay4.Text = taCheckOrder.PayTypePay4;

                txtPercentDiscount.Text = taCheckOrder.PayPerDiscount;
                txtDiscount.Text = taCheckOrder.PayDiscount;

                txtPercentSurcharge.Text = taCheckOrder.PayPerSurcharge;
                txtSurcharge.Text = taCheckOrder.PaySurcharge;

                txtTendered.Text = "0.00";
                txtToPay.Text = taCheckOrder.TotalAmount;
                menuAmout = Convert.ToDecimal(taCheckOrder.MenuAmount);
                txtChange.Text = "0.00";

                GetAllAmount();
            }
            #endregion

            //默认为PayType1
            objTxt = txtPayTypePay1;
            objName = @"txtPayTypePay1";

            asfc.controllInitializeSize(this);
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

            txtPayTypePay[0] = txtPayTypePay1;
            txtPayTypePay[1] = txtPayTypePay2;
            txtPayTypePay[2] = txtPayTypePay3;
            txtPayTypePay[3] = txtPayTypePay4;

            var i = 0;
            foreach (var taPaymentTypeInfo in CommonData.TaPaymentType)
            {
                lblPayType[i].Text = taPaymentTypeInfo.PaymentType;
                txtPayTypePay[i].Text = @"0.00";
                i++;

                if (i > 3) break;
            }

            for (var j = i; j < 4; j++)
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
        }

        #endregion

        #region 数字按钮输入事件

        private void btn_Click(object sender, EventArgs e)
        {
            var btn = (SimpleButton) sender;

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
            else
            {
                //不为%
                if (!objTxt.Name.Equals("txtPercentDiscount") || !objTxt.Name.Equals("txtPercentSurcharge"))
                {
                    if (objTxt.Text.Equals("0.00") || objTxt.Text.Equals("0.0") || objTxt.Text.Equals("0") || string.IsNullOrEmpty(objTxt.Text))
                        objTxt.Text = btn.Text;
                    else
                        objTxt.Text += btn.Text;
                }
                else
                {
                    if (!objTxt.Text.Contains(@"%")) objTxt.Text = btn.Text;
                }
            }
        }

        #endregion

        #region 获得账单信息

        /// <summary>
        ///     获得账单信息
        /// </summary>
        /// <param name="chkId">账单编号</param>
        private void GetChk(string chkId)
        {
            new SystemData().GetTaCheckOrder();

            var lstChk = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(chkId));
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
                ? lstDetail.Where(s => s.CheckOrder.Equals(chkId)).Sum(s => Convert.ToDecimal(s.PayAmount))
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
            }
            else
            {
                //需付款
                txtToPay.Text = (menuAmout - discount + surcharge).ToString("0.00");

                //已付款金额
                txtTendered.Text = (ptPay1 + ptPay2 + ptPay3 + ptPay4).ToString("0.00");

                //找零
                decimal change = Convert.ToDecimal(txtTendered.Text) - Convert.ToDecimal(txtToPay.Text);
                txtChange.Text = change < 0 ? "0.00" : change.ToString("0.00");
            }

            if (Convert.ToDecimal(txtTendered.Text) >= Convert.ToDecimal(txtToPay.Text))
            {
                IsPaid = true;
                //taPaymentInfo.IsPaid = "Y";
                //_control.UpdateEntity(taPaymentInfo);
                //this.DialogResult = DialogResult.OK;
                //Hide();
            }
            else IsPaid = false;
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
            if (txtPercentDiscount.Text.EndsWith(@"%"))
            {
                try
                {
                    return Convert.ToDecimal(txtDiscount.Text) >= 100
                        ? dTotal
                        : (string.IsNullOrEmpty(txtDiscount.Text) || Convert.ToDecimal(txtDiscount.Text) <= 0 
                            ? 0.00m
                            : dTotal*(Convert.ToDecimal(txtDiscount.Text)/100));
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message, ex);
                    return 0.0m;
                }
            }
            else
            {
                try
                {
                    return Convert.ToDecimal(txtDiscount.Text);
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message, ex);
                    return 0.0m;
                }
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
            if (txtPercentSurcharge.Text.EndsWith(@"%"))
            {
                try
                {
                    return Convert.ToDecimal(txtSurcharge.Text) >= 100
                        ? dTotal
                        : (string.IsNullOrEmpty(txtSurcharge.Text) || Convert.ToDecimal(txtSurcharge.Text) <= 0
                            ? 0.00m
                            : dTotal * (Convert.ToDecimal(txtSurcharge.Text) / 100));
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message, ex);
                    return 0.0m;
                }
            }
            else
            {
                try
                {
                    return Convert.ToDecimal(txtSurcharge.Text);
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message, ex);
                    return 0.0m;
                }
            }
        }

        #endregion

        #region 重新计算所有账单

        private void RefreshAmount()
        {
            GetPayTypePayment();

            txtTendered.Text = (ptPay1 + ptPay2 + ptPay3 + ptPay4).ToString("0.00");

            GetAllAmount();
        }

        #endregion

        #region PayType Click事件
        private void lblPayType1_Click(object sender, EventArgs e)
        {
            txtPayTypePay1.Text = txtToPay.Text;

            //if (!txtPayTypePay1.Text.Equals(txtToPay.Text)) txtPayTypePay1.Text = txtToPay.Text;
            RefreshAmount();
        }

        private void lblPayType2_Click(object sender, EventArgs e)
        {
            txtPayTypePay2.Text = txtToPay.Text;

            //if (!txtPayTypePay2.Text.Equals(txtToPay.Text)) txtPayTypePay2.Text = txtToPay.Text;
            RefreshAmount();
        }

        private void lblPayType3_Click(object sender, EventArgs e)
        {
            txtPayTypePay3.Text = txtToPay.Text;

            //if (!txtPayTypePay3.Text.Equals(txtToPay.Text)) txtPayTypePay3.Text = txtToPay.Text;
            RefreshAmount();
        }

        private void lblPayType4_Click(object sender, EventArgs e)
        {
            txtPayTypePay4.Text = txtToPay.Text;

            //if (!txtPayTypePay4.Text.Equals(txtToPay.Text)) txtPayTypePay4.Text = txtToPay.Text;
            RefreshAmount();
        }
        #endregion

        #region 鼠标按下事件
        private void txtPayTypePay1_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtPayTypePay1";
            objTxt = txtPayTypePay1;
        }

        private void txtPayTypePay2_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtPayTypePay2";
            objTxt = txtPayTypePay2;
        }

        private void txtPayTypePay3_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtPayTypePay3";
            objTxt = txtPayTypePay3;
        }

        private void txtPayTypePay4_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtPayTypePay4";
            objTxt = txtPayTypePay4;
        }

        private void txtPercentDiscount_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtPercentDiscount";
            objTxt = txtPercentDiscount;
        }

        private void txtDiscount_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtDiscount";
            objTxt = txtDiscount;
        }

        private void txtPercentSurcharge_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtPercentSurcharge";
            objTxt = txtPercentSurcharge;
        }

        private void txtSurcharge_MouseDown(object sender, MouseEventArgs e)
        {
            objName = "txtSurcharge";
            objTxt = txtSurcharge;
        }
        #endregion

        #region 保存账单

        private void SaveOrder()
        {

            new SystemData().GetTaCheckOrder();
            var lstChk = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(checkID));

            if (lstChk.Any())
            {
                TaCheckOrderInfo taCheckOrder = lstChk.FirstOrDefault();

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
                taCheckOrder.TotalAmount = Math.Round(Convert.ToDecimal(txtToPay.Text), 2).ToString(@"0.00");
                taCheckOrder.Paid = Math.Round(Convert.ToDecimal(txtTendered.Text), 2).ToString(@"0.00");
                taCheckOrder.IsPaid = IsPaid ? @"Y" : @"N";

                _control.UpdateEntity(taCheckOrder);
            }

            if (IsPaid)
            {
                returnPaid = true;

                this.DialogResult = DialogResult.OK;

                Hide();
            }
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
            SaveOrder();

            //未完成付款
            if (!IsPaid) return;
            
            new SystemData().GetTaOrderItem();
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID)).ToList();

            PrtTemplataTa prtTemplataTa = new PrtTemplataTa();
            prtTemplataTa.RestaurantName = PrtCommon.GetRestName();
            prtTemplataTa.Addr = PrtCommon.GetRestAddr();
            prtTemplataTa.Telephone = PrtCommon.GetRestTel();
            prtTemplataTa.VatNo = PrtCommon.GetRestVATNo();
            prtTemplataTa.OrderTime = PrtCommon.GetPrtTime();
            prtTemplataTa.OrderDate = PrtCommon.GetPrtDateTime();
            prtTemplataTa.OrderNo = checkID;
            prtTemplataTa.PayType = GetPayType();
            prtTemplataTa.TotalAmount = txtToPay.Text; 
            prtTemplataTa.SubTotal = htDetail["SubTotal"].ToString();
            prtTemplataTa.StaffName = htDetail["Staff"].ToString();
            prtTemplataTa.ItemCount = htDetail["ItemQty"].ToString();
            prtTemplataTa.Discount = txtDiscount.Text + txtPercentDiscount.Text;

            PrtTemplate.PrtTa(prtTemplataTa, lstOI, PrtStatic.PRT_TEMPLATE_TA_ALL_TYPE);
        }

        private string GetPayType()
        {
            new SystemData().GetTaCheckOrder();
            var lstChk = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(checkID));

            string strPt = "";

            if (lstChk.Any())
            {
                TaCheckOrderInfo taCheckOrder = lstChk.FirstOrDefault();

                if (Convert.ToDecimal(taCheckOrder.PayTypePay1) > 0)
                {
                    strPt += taCheckOrder.PayType1 + " ";
                }

                if (Convert.ToDecimal(taCheckOrder.PayTypePay2) > 0)
                {
                    strPt += taCheckOrder.PayType2 + " ";
                }

                if (Convert.ToDecimal(taCheckOrder.PayTypePay3) > 0)
                {
                    strPt += taCheckOrder.PayType3 + " ";
                }

                if (Convert.ToDecimal(taCheckOrder.PayTypePay4) > 0)
                {
                    strPt += taCheckOrder.PayType4 + " ";
                }
            }

            return strPt;
        }

        private void btnPrtAllReceipt_Click(object sender, EventArgs e)
        {
            //保存账单信息
            SaveOrder();

            //未完成付款
            if (!IsPaid) return;

            new SystemData().GetTaOrderItem();
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID)).ToList();

            PrtTemplataTa prtTemplataTa = new PrtTemplataTa();
            prtTemplataTa.RestaurantName = PrtCommon.GetRestName();
            prtTemplataTa.Addr = PrtCommon.GetRestAddr();
            prtTemplataTa.Telephone = PrtCommon.GetRestTel();
            prtTemplataTa.VatNo = PrtCommon.GetRestVATNo();
            prtTemplataTa.OrderTime = PrtCommon.GetPrtTime();
            prtTemplataTa.OrderDate = PrtCommon.GetPrtDateTime();
            prtTemplataTa.OrderNo = checkID;
            prtTemplataTa.PayType = GetPayType();
            prtTemplataTa.TotalAmount = txtToPay.Text;
            prtTemplataTa.SubTotal = htDetail["SubTotal"].ToString();
            prtTemplataTa.StaffName = htDetail["Staff"].ToString();
            prtTemplataTa.ItemCount = htDetail["ItemQty"].ToString();
            prtTemplataTa.Discount = txtDiscount.Text + txtPercentDiscount.Text;

            #region VAT计算
            if (CommonData.GenSet.Any())
            {
                prtTemplataTa.Rete1 = CommonData.GenSet.FirstOrDefault().VATPer + @"%";

                var lstVAT = from oi in CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID))
                                join mi in CommonData.TaMenuItem on oi.ItemCode equals mi.MiDishCode
                                where !string.IsNullOrEmpty(mi.MiRmk) && mi.MiRmk.Contains(@"Without VAT")
                                select new
                                {
                                    itemTotalPrice = oi.ItemTotalPrice
                                };

                decimal dTotal = 0;
                decimal dVatTmp = 0;
                decimal dVat = 0;

                if (lstVAT.Any())
                {
                    dTotal = lstVAT.ToList().Sum(vat => Convert.ToDecimal(vat.itemTotalPrice));
                    //交税
                    dVatTmp = (Convert.ToDecimal(CommonData.GenSet.FirstOrDefault().VATPer) / 100) * dTotal;

                    dVat = Math.Round(dVatTmp, 2, MidpointRounding.AwayFromZero);
                }

                prtTemplataTa.VatA = dVat.ToString();
                //税前
                prtTemplataTa.Net1 = dTotal.ToString();
                //总价
                prtTemplataTa.Gross1 = (dTotal - dVat).ToString();
                prtTemplataTa.Rate2 = "0.00%";
                prtTemplataTa.Net2 = (Convert.ToDecimal(htDetail["SubTotal"]) - dTotal).ToString();
                prtTemplataTa.VatB = "0.00";
                prtTemplataTa.Gross2 = (Convert.ToDecimal(htDetail["SubTotal"]) - dTotal).ToString();
            }
            else
            {
                prtTemplataTa.Rete1 = "0.00%";
                prtTemplataTa.Net1 = "0.00";
                prtTemplataTa.VatA = "0.00";
                prtTemplataTa.Gross1 = "0.00";
                prtTemplataTa.Rate2 = "0.00%";
                prtTemplataTa.Net2 = "0.00";
                prtTemplataTa.VatB = "0.00";
                prtTemplataTa.Gross2 = "0.00";
            }
            #endregion

            PrtTemplate.PrtTa(prtTemplataTa, lstOI, PrtStatic.PRT_TEMPLATE_TA_ALL_AND_RECEIPT_TYPE);
        }

        private void btnPrtBillOnly_Click(object sender, EventArgs e)
        {
            //保存账单信息
            SaveOrder();

            //未完成付款
            if (!IsPaid) return;

            new SystemData().GetTaOrderItem();
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID)).ToList();

            PrtTemplataTa prtTemplataTa = new PrtTemplataTa();
            prtTemplataTa.RestaurantName = PrtCommon.GetRestName();
            prtTemplataTa.Addr = PrtCommon.GetRestAddr();
            prtTemplataTa.Telephone = PrtCommon.GetRestTel();
            prtTemplataTa.VatNo = PrtCommon.GetRestVATNo();
            prtTemplataTa.OrderTime = PrtCommon.GetPrtTime();
            prtTemplataTa.OrderDate = PrtCommon.GetPrtDateTime();
            prtTemplataTa.OrderNo = checkID;
            prtTemplataTa.PayType = GetPayType();
            prtTemplataTa.TotalAmount = txtToPay.Text;
            prtTemplataTa.SubTotal = htDetail["SubTotal"].ToString();
            prtTemplataTa.StaffName = htDetail["Staff"].ToString();
            prtTemplataTa.ItemCount = htDetail["ItemQty"].ToString();
            prtTemplataTa.Discount = txtDiscount.Text + txtPercentDiscount.Text;

            PrtTemplate.PrtTa(prtTemplataTa, lstOI, PrtStatic.PRT_TEMPLATE_TA_BILL_TYPE);
        }

        private void btnPrtKitOnly_Click(object sender, EventArgs e)
        {
            //保存账单信息
            SaveOrder();

            //未完成付款
            if (!IsPaid) return;

            new SystemData().GetTaOrderItem();
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID)).ToList();

            PrtTemplataTa prtTemplataTa = new PrtTemplataTa();
            prtTemplataTa.RestaurantName = PrtCommon.GetRestName();
            prtTemplataTa.Addr = PrtCommon.GetRestAddr();
            prtTemplataTa.Telephone = PrtCommon.GetRestTel();
            prtTemplataTa.VatNo = PrtCommon.GetRestVATNo();
            prtTemplataTa.OrderTime = PrtCommon.GetPrtTime();
            prtTemplataTa.OrderDate = PrtCommon.GetPrtDateTime();
            prtTemplataTa.OrderNo = checkID;
            prtTemplataTa.PayType = GetPayType();
            prtTemplataTa.TotalAmount = txtToPay.Text;
            prtTemplataTa.SubTotal = htDetail["SubTotal"].ToString();
            prtTemplataTa.StaffName = htDetail["Staff"].ToString();
            prtTemplataTa.ItemCount = htDetail["ItemQty"].ToString();
            prtTemplataTa.Discount = txtDiscount.Text + txtPercentDiscount.Text;

            PrtTemplate.PrtTa(prtTemplataTa, lstOI, PrtStatic.PRT_TEMPLATE_TA_KITCHEN_TYPE);
        }
    }
}