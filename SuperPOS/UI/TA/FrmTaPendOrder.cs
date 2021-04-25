using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using DevExpress.XtraEditors;
using SuperPOS.Common;
using SuperPOS.Dapper;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaPendOrder : DevExpress.XtraEditors.XtraForm
    {
        #region 定义
        //用户ID
        private int usrID;

        //账单ID
        private int checkID;
        //账单号
        private string checkCode;

        //账单总价
        private string checkTotalAmount;
        //已付款
        private string checkPaid;
        //是否已付
        private string checkIsPaid;
        //下单用户
        private string checkUsrName;
        //来电ID
        private int checkCustID;
        //司机ID
        private int checkDriverID;
        //下单时间
        private string checkOrderTime;
        //PostCode
        private string checkPostCode;
        //PostCodeZone
        private string checkPostCodeZone;
        //Addr
        private string checkAddr;
        //账单类型
        private string checkOrderType;
        //CustomerName
        private string checkCustomerName;
        //CustomerPhone
        private string checkCustomerPhone;
        //DriverName
        private string checkDriverName;
        //Menu Total
        private string checkMenuTotal;
        //Discount
        private string checkDiscount;
        //Discount Per
        private string checkDiscountPer;
        //Is Save Order
        private string checkIsSave;
        //营业日
        private string checkBusDate;

        private string checkRefNum;
        private string checkDeliveryFee;
        private string checkSurcharge;

        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private string strOrderNo = "";
        private string strBusDate = "";
        private string strCustPhone = "";

        //语言状态位
        private int iLang = PubComm.MENU_LANG_DEFAULT;

        private bool isConnectPhone = false;

        public string rCheckCode
        {
            get { return checkCode; }
            set { rCheckCode = value; }
        }

        public int rUserID
        {
            get { return usrID; }
            set { rUserID = value; }
        }

        public int rCheckCustID
        {
            get { return checkCustID; }
            set { rCheckCustID = value; }
        }

        public string rCheckBusDate
        {
            get { return checkBusDate; }
            set { rCheckBusDate = value; }
        }

        public int rLang
        {
            get { return iLang; }
            set { rLang = value; }
        }
        #endregion

        public FrmTaPendOrder()
        {
            InitializeComponent();
        }

        public FrmTaPendOrder(int uID, int iLanguage, bool isFrmConnectPhone, string sBusDate)
        {
            InitializeComponent();
            usrID = uID;
            iLang = iLanguage;
            isConnectPhone = isFrmConnectPhone;
            //strBusDate = sBusDate;
        }

        public FrmTaPendOrder(string sOrderNo, string sBusDate, string sCustPhone)
        {
            InitializeComponent();
            strOrderNo = sOrderNo;
            strBusDate = sBusDate;
            strCustPhone = sCustPhone;
        }

        private void GetBindData(string orderType, int iDriver, bool isSaveOrder)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            CommonDAL.ShowMessage(this);

            var lstDb = from sPod in CommonData.GetShowAndPendOrderData
                where !sPod.IsPaid.Equals(@"Y") && !sPod.IsCancel.Equals(@"Y")
                select new
                {
                    ID = sPod.ID,
                    CheckCode = sPod.CheckCode,
                    OrderTime = sPod.PayTime,
                    PostCode = sPod.CustPostCode,
                    PostCodeZone = string.IsNullOrEmpty(sPod.CustPcZone) ? "" : sPod.CustPcZone,
                    Addr = string.IsNullOrEmpty(sPod.CustAddr) ? "" : sPod.CustAddr,
                    PayOrderType = sPod.PayOrderType,
                    CustomerName = sPod.CustName,
                    CustomerPhone = string.IsNullOrEmpty(sPod.CustPhone) ? "" : sPod.CustPhone,
                    IsPaid = sPod.IsPaid,
                    TotalAmount = sPod.TotalAmount,
                    StaffName = sPod.UsrName,
                    Paid = sPod.Paid,
                    CustID = Convert.ToInt32(sPod.CustID),
                    DriverID = sPod.DriverID,
                    DriverName = string.IsNullOrEmpty(sPod.DriverName) ? "" : sPod.DriverName,
                    MenuAmount = sPod.MenuAmount,
                    Discount = string.IsNullOrEmpty(sPod.PayDiscount) ? "" : sPod.PayDiscount,
                    DiscountPer = string.IsNullOrEmpty(sPod.PayPerDiscount) ? "" : sPod.PayPerDiscount,
                    IsSave = sPod.IsSave,
                    OtherCheckCode = !sPod.IsSave.Equals("N") ? " " : sPod.CheckCode,
                    gridBusDate = sPod.BusDate,
                    gridRefNum = sPod.RefNum,
                    gridDeliveryFee = sPod.DeliveryFee,
                    gridSurcharge = sPod.PaySurcharge
                };

            if (isSaveOrder)
                lstDb = lstDb.Where(s => s.IsSave.Equals("Y"));

            var lstTmp = lstDb;

            switch (iDriver)
            {
                case 1:
                    lstTmp = lstDb.Where(s => !string.IsNullOrEmpty(s.DriverName));
                    break;
                case 2:
                    lstTmp = lstDb.Where(s => string.IsNullOrEmpty(s.DriverName));
                    break;
                default:
                    lstTmp = lstDb;
                    break;
            }

            gridControlTaPendOrder.DataSource = !string.IsNullOrEmpty(orderType) 
                                                ? lstTmp.Where(s => s.PayOrderType.Equals(orderType) && string.IsNullOrEmpty(s.DriverName)).ToList() 
                                                : lstTmp.ToList();
            gvTaPendOrder.FocusedRowHandle = gvTaPendOrder.RowCount - 1;
            gvTaPendOrder.Columns["OrderTime"].BestFit();
            
            txtTotal.Text = lstTmp.Sum(s => Convert.ToDecimal(string.IsNullOrEmpty(s.TotalAmount)? "0.00" : s.TotalAmount)).ToString();

            if (!string.IsNullOrEmpty(strOrderNo) && !string.IsNullOrEmpty(strBusDate) && !string.IsNullOrEmpty(strCustPhone))
            {
                if (gvTaPendOrder.FocusedRowHandle >= 0)
                {
                    for (int i = 0; i < gvTaPendOrder.RowCount; i++)
                    {
                        string colValue = gvTaPendOrder.GetRowCellValue(i, "CheckCode").ToString();

                        if (colValue.Equals(strCustPhone))
                        {
                            gvTaPendOrder.FocusedRowHandle = i;
                            break;
                        }
                    }
                }
            }

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            LogHelper.Info(@"FrmTaPendOrder GetBindData Time " + ts.TotalMilliseconds);

            CommonDAL.HideMessage(this);
        }

        private void GetBindData(List<ShowAndPendOrderDataInfo> lstShowAndPendOrderDataInfos, string orderType, int iDriver, bool isSaveOrder)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            CommonDAL.ShowMessage(this);

            var lstDb = from sPod in lstShowAndPendOrderDataInfos
                        where !sPod.IsPaid.Equals(@"Y") && !sPod.IsCancel.Equals(@"Y")
                        select new
                        {
                            ID = sPod.ID,
                            CheckCode = sPod.CheckCode,
                            OrderTime = sPod.PayTime,
                            PostCode = string.IsNullOrEmpty(sPod.CustPostCode) ? "" : sPod.CustPostCode,
                            PostCodeZone = string.IsNullOrEmpty(sPod.CustPcZone) ? "" : sPod.CustPcZone,
                            Addr = string.IsNullOrEmpty(sPod.CustAddr) ? "" : sPod.CustAddr,
                            PayOrderType = sPod.PayOrderType,
                            CustomerName = string.IsNullOrEmpty(sPod.CustName) ? "" : sPod.CustName,
                            CustomerPhone = string.IsNullOrEmpty(sPod.CustPhone) ? "" : sPod.CustPhone,
                            IsPaid = sPod.IsPaid,
                            TotalAmount = sPod.TotalAmount,
                            StaffName = string.IsNullOrEmpty(sPod.UsrName) ? "" : sPod.UsrName,
                            Paid = string.IsNullOrEmpty(sPod.Paid) ? "" : sPod.Paid,
                            CustID = Convert.ToInt32(sPod.CustID),
                            DriverID = sPod.DriverID,
                            DriverName = string.IsNullOrEmpty(sPod.DriverName) ? "" : sPod.DriverName,
                            MenuAmount = sPod.MenuAmount,
                            Discount = string.IsNullOrEmpty(sPod.PayDiscount) ? "" : sPod.PayDiscount,
                            DiscountPer = string.IsNullOrEmpty(sPod.PayPerDiscount) ? "" : sPod.PayPerDiscount,
                            IsSave = string.IsNullOrEmpty(sPod.IsSave) ? "" : sPod.IsSave,
                            OtherCheckCode = !sPod.IsSave.Equals("N") ? " " : sPod.CheckCode,
                            gridBusDate = sPod.BusDate,
                            gridRefNum = string.IsNullOrEmpty(sPod.RefNum) ? "" : sPod.RefNum,
                            gridDeliveryFee = string.IsNullOrEmpty(sPod.DeliveryFee) ? "" : sPod.DeliveryFee,
                            gridSurcharge = string.IsNullOrEmpty(sPod.PaySurcharge) ? "" : sPod.PaySurcharge
                        };

            if (isSaveOrder)
                lstDb = lstDb.Where(s => s.IsSave.Equals("Y"));

            var lstTmp = lstDb;

            switch (iDriver)
            {
                case 1:
                    lstTmp = lstDb.Where(s => !string.IsNullOrEmpty(s.DriverName));
                    break;
                case 2:
                    lstTmp = lstDb.Where(s => string.IsNullOrEmpty(s.DriverName));
                    break;
                default:
                    lstTmp = lstDb;
                    break;
            }

            gridControlTaPendOrder.DataSource = !string.IsNullOrEmpty(orderType)
                                                ? lstTmp.Where(s => s.PayOrderType.Equals(orderType) && string.IsNullOrEmpty(s.DriverName)).ToList()
                                                : lstTmp.ToList();
            gvTaPendOrder.FocusedRowHandle = gvTaPendOrder.RowCount - 1;
            gvTaPendOrder.Columns["OrderTime"].BestFit();

            txtTotal.Text = lstTmp.Sum(s => Convert.ToDecimal(string.IsNullOrEmpty(s.TotalAmount) ? "0.00" : s.TotalAmount)).ToString();

            if (!string.IsNullOrEmpty(strOrderNo) && !string.IsNullOrEmpty(strBusDate) && !string.IsNullOrEmpty(strCustPhone))
            {
                if (gvTaPendOrder.FocusedRowHandle >= 0)
                {
                    for (int i = 0; i < gvTaPendOrder.RowCount; i++)
                    {
                        string colValue = gvTaPendOrder.GetRowCellValue(i, "CheckCode").ToString();

                        if (colValue.Equals(strCustPhone))
                        {
                            gvTaPendOrder.FocusedRowHandle = i;
                            break;
                        }
                    }
                }
            }

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            LogHelper.Info(@"FrmTaPendOrder GetBindData Time " + ts.TotalMilliseconds);

            CommonDAL.HideMessage(this);
        }

        private void FrmTaPendOrder_Load(object sender, EventArgs e)
        {
            //CommonDAL.ShowMessage(this);

            //SystemData systemData = new SystemData();
            //systemData.GetTaCheckOrder();
            //systemData.GetTaCustomer();
            //systemData.GetUsrBase();
            //systemData.GetTaOrderItem();

            //systemData.GetShowAndPendOrderData("", strBusDate);
            //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //sw.Start();

            //new SystemData().GetShowAndPendOrderData("", strBusDate);
            //GetBindData("", 0, false);

            //sw.Stop();
            //TimeSpan ts = sw.Elapsed;
            //Console.WriteLine(@"FrmTaPendOrder_Load Time " + ts.TotalMilliseconds);


            System.Diagnostics.Stopwatch sw1 = new System.Diagnostics.Stopwatch();
            sw1.Start();
            
            List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

            GetBindData(lstTmp, "", 0, false);

            sw1.Stop();
            TimeSpan ts1 = sw1.Elapsed;
            Console.WriteLine(@"FrmTaPendOrder_Load Time1:" + ts1.TotalMilliseconds);
            LogHelper.Info(@"FrmTaPendOrder_Load Time1:" + ts1.TotalMilliseconds);
            
            BinLueDriver();

            //异步刷新CheckOrder和OrderItem
            //DelegateRefresh hd = DelegateMy.RefreshSomeInfo;
            //IAsyncResult rt = hd.BeginInvoke("3", strBusDate, "", null, null);

            asfc.controllInitializeSize(this);

            //CommonDAL.HideMessage(this);
        }

        private void gvTaPendOrder_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvTaPendOrder_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvTaPendOrder.RowCount <= 0) return;
            //账单ID
            checkID = Convert.ToInt32(gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "ID").ToString());
            //账单号
            checkCode = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "CheckCode").ToString();
            //订单时间
            checkOrderTime = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "OrderTime").ToString();
            //PostCode
            checkPostCode = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "PostCode").ToString();
            //PostCodeZone
            //checkPostCodeZone = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "PostCodeZone").ToString();
            //Addr
            checkAddr = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "Addr").ToString();
            //账单类型
            checkOrderType = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "PayOrderType").ToString();
            //CustomerName
            checkCustomerName = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "CustomerName").ToString();
            //CustomerPhone
            checkCustomerPhone = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "CustomerPhone").ToString();
            //DriverName
            checkDriverName = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "DriverName").ToString();
            //账单总价
            checkTotalAmount = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "TotalAmount").ToString();
            //已付款
            checkPaid = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "Paid").ToString();
            //已付
            checkIsPaid = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "IsPaid").ToString();
            //下单用户
            checkUsrName = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "StaffName").ToString();
            //来电ID
            checkCustID = Convert.ToInt32(gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "CustID").ToString());
            //司机ID
            checkDriverID = Convert.ToInt32(gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "DriverID").ToString());
            //菜单总价
            checkMenuTotal = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "MenuAmount").ToString();
            //Discount 
            checkDiscount = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "Discount").ToString();
            //DiscountPer
            checkDiscountPer = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "DiscountPer").ToString();
            //Is Save
            checkIsSave = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "IsSave").ToString();
            //营业日
            checkBusDate = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "gridBusDate").ToString();

            checkRefNum = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "gridRefNum") == null 
                          ? ""
                          : gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "gridRefNum").ToString();

            checkDeliveryFee = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "gridDeliveryFee").ToString();
            checkSurcharge = gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "gridSurcharge").ToString();

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string strSqlWhere = "";
            DynamicParameters dynamicParams = new DynamicParameters();

            strSqlWhere = "CheckCode=@CheckCode AND BusDate=@BusDate";

            dynamicParams.Add("BusDate", checkBusDate);
            dynamicParams.Add("CheckCode", checkCode);
            
            List<TaOrderItemInfo> lstOi = new SQLiteDbHelper().QueryMultiByWhere<TaOrderItemInfo>("Ta_OrderItem", strSqlWhere, dynamicParams);

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine("Time {0}", ts.TotalMilliseconds);

            //SystemData systemData = new SystemData();
            //systemData.GetTaCheckOrder();
            TaCheckOrderInfo taCheckOrderInfo = CommonData.TaCheckOrder.FirstOrDefault(s => s.CheckCode.Equals(checkCode) && s.BusDate.Equals(checkBusDate));

            if (checkOrderType.Equals(PubComm.ORDER_TYPE_SHOP))
            {
                FrmTaPaymentShop frmTaPaymentShop = new FrmTaPaymentShop(lstOi, usrID, checkCode, checkOrderType, checkCustID.ToString(), SetPrtInfo(), checkBusDate, taCheckOrderInfo, "");

                if (frmTaPaymentShop.ShowDialog() == DialogResult.OK)
                {
                    if (frmTaPaymentShop.returnPaid)
                    {
                        //new SystemData().GetShowAndPendOrderData("", strBusDate);
                        //GetBindData("", 0, false);
                        List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

                        GetBindData(lstTmp, "", 0, false);
                    }
                }
            }
            else if (checkOrderType.Equals(PubComm.ORDER_TYPE_DELIVERY))
            {
                FrmTaPaymentDelivery frmTaPaymentDelivery = new FrmTaPaymentDelivery(lstOi, usrID, checkCode, checkOrderType, checkCustID.ToString(), SetPrtInfo(), checkBusDate, taCheckOrderInfo, "");

                if (frmTaPaymentDelivery.ShowDialog() == DialogResult.OK)
                {
                    if (frmTaPaymentDelivery.returnPaid)
                    {
                        //new SystemData().GetShowAndPendOrderData("", strBusDate);
                        //GetBindData("", 0, false);

                        List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

                        GetBindData(lstTmp, "", 0, false);
                    }
                }
            }
            else if (checkOrderType.Equals(PubComm.ORDER_TYPE_COLLECTION))
            {
                FrmTaPaymentCollection frmTaPaymentCollection = new FrmTaPaymentCollection(lstOi, usrID, checkCode, checkOrderType, checkCustID.ToString(), SetPrtInfo(), checkBusDate, taCheckOrderInfo, "");

                if (frmTaPaymentCollection.ShowDialog() == DialogResult.OK)
                {
                    if (frmTaPaymentCollection.returnPaid)
                    {
                        //new SystemData().GetShowAndPendOrderData("", strBusDate);
                        //GetBindData("", 0, false);

                        List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

                        GetBindData(lstTmp, "", 0, false);
                    }
                }
            }
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

            GetBindData(lstTmp, PubComm.ORDER_TYPE_DELIVERY, 0, false);
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

            GetBindData(lstTmp, PubComm.ORDER_TYPE_COLLECTION, 0, false);
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

            GetBindData(lstTmp, PubComm.ORDER_TYPE_SHOP, 0, false);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

            GetBindData(lstTmp, "", 0, false);
        }

        #region 设置打印相关信息

        private Hashtable SetPrtInfo()
        {
            Hashtable htDetail = new Hashtable();

            new SystemData().GetUsrBase();

            htDetail["Staff"] = CommonData.UsrBase.Any(s => s.ID == usrID) ? CommonData.UsrBase.FirstOrDefault(s => s.ID == usrID).UsrName : "";

            var lstOi = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkCode) && s.BusDate.Equals(checkBusDate));

            htDetail["ItemQty"] = lstOi.Count(s => s.ItemType == 1);
            htDetail["SubTotal"] = checkTotalAmount;
            htDetail["Total"] = checkTotalAmount;
            htDetail["PayType"] = checkOrderType;
            htDetail["OrderNo"] = checkCode;

            return htDetail;
        }
        #endregion

        private void btnPrtReceipt_Click(object sender, EventArgs e)
        {
            Hashtable ht = SetPrtInfo();
            ht["Tendered"] = checkPaid;

            ht["Change"] = "0.00";

            //new SystemData().GetTaOrderItem();
            var lstOi = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkCode) && s.BusDate.Equals(checkBusDate)).ToList();

            #region VAT计算
            if (CommonData.GenSet.Any())
            {
                ht["Rate1"] = CommonData.GenSet.FirstOrDefault().VATPer + @"%";

                var lstVAT = from oi in CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(checkBusDate))
                                join mi in CommonData.TaMenuItem on oi.ItemCode equals mi.MiDishCode
                                where !string.IsNullOrEmpty(mi.MiRmk) && mi.MiRmk.Contains(@"Without VAT")
                                select new
                                {
                                    itemTotalPrice = oi.ItemTotalPrice
                                };

                decimal dTotal = 0.00m;
                decimal dVatTmp = 0.00m;
                decimal dVat = 0.00m;

                if (lstVAT.Any())
                {
                    dTotal = lstVAT.ToList().Sum(vat => Convert.ToDecimal(vat.itemTotalPrice));
                    //交税
                    dVatTmp = (Convert.ToDecimal(CommonData.GenSet.FirstOrDefault().VATPer) / 100) * dTotal;

                    dVat = Math.Round(dVatTmp, 2, MidpointRounding.AwayFromZero);
                }

                ht["VAT-A"] = dVat.ToString();
                //税前
                ht["Net1"] = dTotal.ToString();
                //总价
                ht["Gross1"] = (dTotal - dVat).ToString();
                ht["Rate2"] = "0.00%";
                ht["Net2"] = (Convert.ToDecimal(checkTotalAmount) - dTotal).ToString();
                ht["VAT-B"] = "0.00";
                ht["Gross2"] = (Convert.ToDecimal(checkTotalAmount) - dTotal).ToString();
            }
            else
            {
                ht["Rate1"] = "0.00%";
                ht["Net1"] = "0.00";
                ht["VAT-A"] = "0.00";
                ht["Gross1"] = "0.00";
                ht["Rate2"] = "0.00%";
                ht["Net2"] = "0.00";
                ht["VAT-B"] = "0.00";
                ht["Gross2"] = "0.00";
            }
            #endregion

            PrtPrint.PrtReceipt(lstOi, ht);
        }

        private void btnPrtBill_Click(object sender, EventArgs e)
        {
            Hashtable ht = SetPrtInfo();
            ht["Tendered"] = checkPaid;

            ht["Change"] = "0.00";

            //new SystemData().GetTaOrderItem();
            var lstOi = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkCode) && s.BusDate.Equals(checkBusDate)).ToList();

            PrtPrint.PrtBillBilingual(lstOi, ht);
        }

        private void btnPrtKit_Click(object sender, EventArgs e)
        {
            Hashtable ht = SetPrtInfo();
            ht["ChkNum"] = checkCode;

            //new SystemData().GetTaOrderItem();
            var lstOi = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkCode) && s.BusDate.Equals(checkBusDate)).ToList();

            PrtPrint.PrtKitchen(lstOi, ht);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
            //FrmTaMain frmTaMain = new FrmTaMain(usrID, iLang, isConnectPhone);
            //frmTaMain.ShowDialog();
        }

        private void gvTaPendOrder_DoubleClick(object sender, EventArgs e)
        {
            Hide();
            //FrmTaMain frmTaMain = new FrmTaMain(checkCode, usrID, checkCustID, checkBusDate, iLang);
            //frmTaMain.ShowDialog();
            this.DialogResult = DialogResult.OK;
        }

        private void FrmTaPendOrder_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

            GetBindData(lstTmp, "", 0, false);
        }

        private void btnShowAssigned_Click(object sender, EventArgs e)
        {
            List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

            GetBindData(lstTmp, "", 1, false);
        }

        private void btnShowUnAssigned_Click(object sender, EventArgs e)
        {
            List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

            GetBindData(lstTmp, "", 2, false);
        }

        private void btnAssignDriver_Click(object sender, EventArgs e)
        {
            if (gvTaPendOrder.FocusedRowHandle < 0) return;

            //new SystemData().GetTaCheckOrder();
            var lstRec = CommonData.TaCheckOrder.Where(s => s.ID == Convert.ToInt32(gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "ID").ToString()) && s.BusDate.Equals(checkBusDate));

            if (lstRec.Any())
            {
                TaCheckOrderInfo taCheckOrderInfo = lstRec.FirstOrDefault();

                taCheckOrderInfo.DriverID = Convert.ToInt32(lueDriver.EditValue);

                DelegateSaveCheckOrder handler = DelegateMy.SaveCheckOrder;
                IAsyncResult result = handler.BeginInvoke(taCheckOrderInfo, true,null, null);

                //_control.UpdateEntity(taCheckOrderInfo);
            }

            List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

            GetBindData(lstTmp, "", 0, false);
        }

        #region 绑定Driver

        private void BinLueDriver()
        {
            //new SystemData().GetTaDriver();

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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Hide();
            //FrmTaMain frmTaMain = new FrmTaMain(checkCode, usrID, checkCustID, checkBusDate, iLang);
            //frmTaMain.ShowDialog();
            this.DialogResult = DialogResult.OK;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            decimal dChange = (Convert.ToDecimal(checkPaid) - Convert.ToDecimal(checkTotalAmount)) <= 0
                                ? 0m
                                : (Convert.ToDecimal(checkPaid) - Convert.ToDecimal(checkPaid));
            FrmTaPendOrderPreview frmTaPendOrderPreview = new FrmTaPendOrderPreview(checkCode, checkTotalAmount, checkMenuTotal, checkUsrName, checkDiscount, checkDiscountPer, checkBusDate, checkPaid,
                dChange.ToString("0.00"), checkRefNum, checkDeliveryFee, checkSurcharge);
            frmTaPendOrderPreview.ShowDialog();
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

            GetBindData(lstTmp, "", 0, false);
        }

        private void btnNotPaid_Click(object sender, EventArgs e)
        {
            List<ShowAndPendOrderDataInfo> lstTmp = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", "", null);

            GetBindData(lstTmp, "", 0, false);
        }
    }
}