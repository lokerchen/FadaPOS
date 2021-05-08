using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList.Nodes;
using HtmlAgilityPack;
using SuperPOS.Common;
using SuperPOS.Dapper;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;
using SuperPOS.UI.TA;
using HtmlDocument = System.Windows.Forms.HtmlDocument;
using Dapper;

namespace SuperPOS.UI
{
    public partial class FrmTaShowOrder : DevExpress.XtraEditors.XtraForm
    {
        //用户ID
        private int usrID;

        //记录账单号Order No
        private string strChkOrder = "";
        //记录会员ID
        private int intCusID = 0;

        private int intChkID = 0;

        private string sTotalAmount = @"0.00";
        private string sStaff = @"";
        private string sDiscountPer = @"";
        private string sDiscount = @"0.00";
        private string sSubTotal = @"0.00";
        private string sTendered = @"0.00";
        private string sChange = @"0.00";
        private string sRefNo = @" ";
        private string sDeliveryFee = @"0.00";
        private string sSurcharge = @"0.00";

        private string sPayType = @"";
        
        private PrtTemplataTa ptl = new PrtTemplataTa();
        private string ptl_Msg1 = "";
        private string ptl_Msg2 = "";
        private string ptl_Msg3 = "";
        private string ptl_Msg4 = "";
        private string ptl_Msg5 = "";
        private string ptl_MsgAtBotton = "";
        private string ptl_RestaurantName = "";
        private string ptl_Addr = "";
        private string ptl_Telephone = "";
        private string ptl_VatNo = "";
        private string ptl_OrderTime = "";
        private string ptl_OrderDate = "";
        private string PrtLang = "";

        private string PreviewContent = "";

        private int sItemCount = 0;
        private string sOrderType = "";

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private string checkBusDate = @"";

        private string strBusDate = "";

        private int intStaffID = 0;

        private WbPrtTemplataTa wbPtl = null;

        HtmlAgilityPack.HtmlDocument doc = null;

        public FrmTaShowOrder()
        {
            InitializeComponent();
        }

        public FrmTaShowOrder(int uId, string sBusDate)
        {
            InitializeComponent();

            usrID = uId;
            strBusDate = sBusDate;
        }

        private void FrmTaShowOrder_Load(object sender, EventArgs e)
        {
            CommonDAL.ShowMessage(this);

            //new SystemData().GetTaOrderItem();
            //new SystemData().GetShowAndPendOrderData("", strBusDate);

            webBrowser2.Navigate("about:blank/");
            GetBindData("", true);

            asfc.controllInitializeSize(this);

            CommonDAL.HideMessage(this);
        }

        #region 绑定初始数据
        /// <summary>
        /// 绑定初始数据
        /// </summary>
        /// <param name="orderType">账单类型</param>
        private void GetBindData(string orderType, bool isNeedStaff)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //new SystemData().GetShowAndPendOrderData("", strBusDate);
            string strSqlWhere = "";
            DynamicParameters dynamicParams = new DynamicParameters();

            strSqlWhere = "IsPaid=@IsPaid AND BusDate=@BusDate";
            //strSqlWhere = "IsPaid=@IsPaid";

            dynamicParams.Add("IsPaid", "Y");
            dynamicParams.Add("BusDate", strBusDate);

            if (!string.IsNullOrEmpty(orderType))
            {
                strSqlWhere += " AND PayOrderType=@PayOrderType";
                dynamicParams.Add("PayOrderType", orderType);
            }

            List<ShowAndPendOrderDataInfo> lst = new SQLiteDbHelper().QueryMultiByWhere<ShowAndPendOrderDataInfo>("VIEW_ShowAndPendOrder", strSqlWhere, dynamicParams);

            //var lstTmp = lst.Where(s => s.IsPaid.Equals(@"Y"));
            //var lstDb = from sPod in lst
            //            select new
            //            {
            //                ID = sPod.ID,
            //                gridOrderNo = sPod.CheckCode,
            //                gridPayType = sPod.PayType.Trim(),
            //                gridOrderType = sPod.PayOrderType,
            //                gridOrderTime = sPod.PayTime,
            //                gridTotal = sPod.TotalAmount,
            //                gridDriver = sPod.DriverName,
            //                //gridDriver = "",
            //                gridStaff = sPod.UsrName,
            //                gridCustID = sPod.CustID,
            //                gridDiscountPer = sPod.PayPerDiscount,
            //                gridDisount = sPod.PayDiscount,
            //                gridSubTotal = sPod.MenuAmount,
            //                gridBusDate = sPod.BusDate,
            //                gridTendered = sPod.Paid,
            //                gridChange = sPod.Change,
            //                gridRefNo = sPod.RefNum,
            //                gridDeliveryFee = sPod.DeliveryFee,
            //                gridStaffId = sPod.StaffID,
            //                gridSurcharge = sPod.PaySurcharge
            //            };

            gridControlTaShowOrder.DataSource = lst;

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine(@"FrmTaShowOrder/GetBindData Time {0}", ts.TotalMilliseconds);

            gvTaShowOrder.Columns["PayTime"].BestFit();
            gvTaShowOrder.FocusedRowHandle = gvTaShowOrder.RowCount - 1;

            
        }
        #endregion

        private void gvTaShowOrder_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvTaShowOrder_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvTaShowOrder.RowCount <= 0)
            {
                webBrowser2.DocumentText = "";
                return;
            }

            intChkID = Convert.ToInt32(gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "ID").ToString());
            strChkOrder = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "CheckCode").ToString();
            intCusID = Convert.ToInt32(gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "CustID").ToString());
            sTotalAmount = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "TotalAmount").ToString();
            sStaff = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "UsrName").ToString();
            sDiscountPer = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "PayPerDiscount").ToString();
            sDiscount = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "PayDiscount").ToString();
            sSubTotal = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "MenuAmount").ToString();
            sOrderType = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "PayOrderType").ToString();
            checkBusDate = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "BusDate").ToString();

            sTendered = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "Paid").ToString();
            sChange = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "Change").ToString();
            sRefNo = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "RefNum") == null ? "" : gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "RefNum").ToString();
            sDeliveryFee = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "DeliveryFee") == null ? "" : gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "DeliveryFee").ToString();

            intStaffID = Convert.ToInt32(gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "StaffID").ToString());

            sSurcharge = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "PaySurcharge") == null ? "0.00" : gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "PaySurcharge").ToString();

            sPayType = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "PayType") == null ? "" : gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "PayType").ToString().Trim();

            sItemCount = GetItemCount(checkBusDate, strChkOrder);
            
            //Stopwatch st1 = new Stopwatch();//实例化类
            //st1.Start();//开始计时

            RefreshPrtInfo(checkBusDate, strChkOrder);

            //st1.Stop();//终止计时
            //Console.WriteLine(@"Time2:" + st1.ElapsedMilliseconds.ToString());//输出时间。
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FrmTaShowOrder_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        #region 打印
        private void btnPrtReceipt_Click(object sender, EventArgs e)
        {
            string strSqlWhere = "";
            DynamicParameters dynamicParams = new DynamicParameters();

            strSqlWhere = "CheckCode=@CheckCode AND BusDate=@BusDate";

            dynamicParams.Add("CheckCode", strChkOrder);
            dynamicParams.Add("BusDate", checkBusDate);

            var lstOI = new SQLiteDbHelper().QueryMultiByWhere<TaOrderItemInfo>("Ta_OrderItem", strSqlWhere, dynamicParams);

            //new SystemData().GetTaOrderItem();
            //var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(checkBusDate)).ToList();

            WbPrtTemplataTa wbPrtTemplataTa = new WbPrtTemplataTa();

            wbPrtTemplataTa = GetAllPrtInfo();

            //WbPrtPrint.PrintHtml(WbPrtStatic.PRT_CLASS_RECEIPT, lstOI, wbPrtTemplataTa, sOrderType);
            DelegatePrtHtml handler = DelegateMy.PrtHtml;
            IAsyncResult result = handler.BeginInvoke(WbPrtStatic.PRT_CLASS_RECEIPT, lstOI, wbPrtTemplataTa, sOrderType, null, null);
        }

        private void btnPrtBill_Click(object sender, EventArgs e)
        {
            string strSqlWhere = "";
            DynamicParameters dynamicParams = new DynamicParameters();

            strSqlWhere = "CheckCode=@CheckCode AND BusDate=@BusDate";

            dynamicParams.Add("CheckCode", strChkOrder);
            dynamicParams.Add("BusDate", checkBusDate);

            var lstOI = new SQLiteDbHelper().QueryMultiByWhere<TaOrderItemInfo>("Ta_OrderItem", strSqlWhere, dynamicParams);

            //new SystemData().GetTaOrderItem();
            //var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(checkBusDate)).ToList();

            WbPrtTemplataTa wbPrtTemplataTa = new WbPrtTemplataTa();

            wbPrtTemplataTa = GetAllPrtInfo();

            //WbPrtPrint.PrintHtml( WbPrtStatic.PRT_CLASS_BILL, lstOI, wbPrtTemplataTa, sOrderType);
            DelegatePrtHtml handler = DelegateMy.PrtHtml;
            IAsyncResult result = handler.BeginInvoke(WbPrtStatic.PRT_CLASS_BILL, lstOI, wbPrtTemplataTa, sOrderType, null, null);
        }

        private void btnPrtKit_Click(object sender, EventArgs e)
        {
            string strSqlWhere = "";
            DynamicParameters dynamicParams = new DynamicParameters();

            strSqlWhere = "CheckCode=@CheckCode AND BusDate=@BusDate";

            dynamicParams.Add("CheckCode", strChkOrder);
            dynamicParams.Add("BusDate", checkBusDate);

            var lstOI = new SQLiteDbHelper().QueryMultiByWhere<TaOrderItemInfo>("Ta_OrderItem", strSqlWhere, dynamicParams);

            //new SystemData().GetTaOrderItem();
            //var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(checkBusDate)).ToList();

            WbPrtTemplataTa wbPrtTemplataTa = new WbPrtTemplataTa();

            wbPrtTemplataTa = GetAllPrtInfo();

            //WbPrtPrint.PrintHtml( WbPrtStatic.PRT_CLASS_KITCHEN, lstOI, wbPrtTemplataTa, sOrderType);
            DelegatePrtHtml handler = DelegateMy.PrtHtml;
            IAsyncResult result = handler.BeginInvoke(WbPrtStatic.PRT_CLASS_KITCHEN, lstOI, wbPrtTemplataTa, sOrderType, null, null);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 列表过滤
        private void btnAll_Click(object sender, EventArgs e)
        {
            GetBindData("", true);
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            GetBindData(PubComm.ORDER_TYPE_COLLECTION, true);
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            GetBindData(PubComm.ORDER_TYPE_DELIVERY, true);
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            GetBindData(PubComm.ORDER_TYPE_SHOP, true);
        }
        #endregion
        private int GetItemCount(string sBusDate, string sCheckCode)
        {
            
            ////return CommonData.TaOrderItem.Count(s => s.CheckCode.Equals(chkCode) && s.ItemType == 1 && s.BusDate.Equals(checkBusDate));
            //string strSqlWhere = "";
            //DynamicParameters dynamicParams = new DynamicParameters();

            //strSqlWhere = "CheckCode=@CheckCode AND BusDate=@BusDate AND ItemType=@ItemType";

            //dynamicParams.Add("BusDate", sBusDate);
            //dynamicParams.Add("CheckCode", sCheckCode);
            //dynamicParams.Add("ItemType", "1");

            ////var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(checkBusDate)).ToList();
            //var lsOI = new SQLiteDbHelper().QueryMultiByWhere<TaOrderItemInfo>("Ta_OrderItem", strSqlWhere, dynamicParams);

            //return lsOI.Sum(s => int.Parse(s.ItemQty));

            return CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(sCheckCode) && s.ItemType == 1 && s.BusDate.Equals(sBusDate)).Sum(s => int.Parse(s.ItemQty));
        }

        #region 设置打印相关信息

        private Hashtable SetPrtInfo(List<TaOrderItemInfo> lstOi)
        {
            Hashtable htDetail = new Hashtable();

            //new SystemData().GetUsrBase();

            htDetail["Staff"] = sStaff;

            htDetail["ItemQty"] = sItemCount;
            htDetail["SubTotal"] = sTotalAmount;
            htDetail["Total"] = sTotalAmount;

            return htDetail;
        }
        #endregion

        private void btnChangePayment_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaOrderItem();
            TaCheckOrderInfo taCheckOrderInfo = CommonData.TaCheckOrder.FirstOrDefault(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(checkBusDate));
            FrmTaPaymentShop frmTaPaymentShop = new FrmTaPaymentShop(usrID, 
                                                                     strChkOrder, 
                                                                     sOrderType, 
                                                                     SetPrtInfo(CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(checkBusDate)).ToList()),
                                                                     checkBusDate,
                                                                     taCheckOrderInfo);

            frmTaPaymentShop.ShowDialog();

            GetBindData("", true);
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            Hide();
            FrmTaMain frmTaMain = new FrmTaMain(strChkOrder, usrID, intCusID, checkBusDate, PubComm.MENU_LANG_DEFAULT);
            frmTaMain.ShowDialog();
        }

        private void btnShowDriver_Click(object sender, EventArgs e)
        {
            FrmTaShowOrderDriver frmTaShowOrderDriver = new FrmTaShowOrderDriver();
            frmTaShowOrderDriver.Location = panelControl4.Location;
            frmTaShowOrderDriver.Width = panelControl4.Width;
            frmTaShowOrderDriver.Height = panelControl4.Height - panelControl6.Height;
            frmTaShowOrderDriver.ShowDialog();
        }

        private WbPrtTemplataTa GetAllPrtInfo()
        {
            WbPrtTemplataTa wbPrtTemplataTa = new WbPrtTemplataTa();
            new SystemData().GetTaSysPrtSetGeneral();
            var lstGen = CommonData.TaSysPrtSetGeneral;
            if (lstGen.Any())
            {
                TaSysPrtSetGeneralInfo taSysPrtSetGeneralInfo = lstGen.FirstOrDefault();

                //wbPrtTemplataTa.PrintAddress = taSysPrtSetGeneralInfo.IsPrtAddr;
                new SystemData().GetTaSysCtrl();
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

            if (!string.IsNullOrEmpty(intCusID.ToString()))
            {
                //new SystemData().GetTaCustomer();
                var lstCust = CommonData.TaCustomer.Where(s => s.ID == intCusID);
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
                    wbPrtTemplataTa.ShopTime = taCustomerInfo.cusReadyTime;
                }
            }

            wbPrtTemplataTa.OrderDate = DateTime.Now.ToShortDateString();
            wbPrtTemplataTa.OrderTime = DateTime.Now.ToShortTimeString();
            wbPrtTemplataTa.Staff = sStaff;
            wbPrtTemplataTa.OrderNo = strChkOrder;
            wbPrtTemplataTa.ItemCount = sItemCount >= 1 ? sItemCount.ToString() : "0";
            wbPrtTemplataTa.SubTotal = sSubTotal;
            wbPrtTemplataTa.Total = sTotalAmount;
            wbPrtTemplataTa.PayType = sPayType;
            wbPrtTemplataTa.Tendered = sTendered;
            wbPrtTemplataTa.Change = sChange;
            wbPrtTemplataTa.OrderType = sOrderType;
            wbPrtTemplataTa.RefNo = sRefNo;
            wbPrtTemplataTa.DeliveryFee = sDeliveryFee;

            wbPrtTemplataTa.Discount = sDiscount;
            wbPrtTemplataTa.Surcharge = sSurcharge;

            return wbPrtTemplataTa;
        }

        private void RefreshPrtInfo(string sBusDate, string sCheckCode)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            if (string.IsNullOrEmpty(sCheckCode)) return;

            if (doc == null) doc = new HtmlWeb().Load(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"so" + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX);

            string strSqlWhere = "";
            DynamicParameters dynamicParams = new DynamicParameters();

            strSqlWhere = "CheckCode=@CheckCode AND BusDate=@BusDate";

            dynamicParams.Add("BusDate", sBusDate);
            dynamicParams.Add("CheckCode", sCheckCode);

            //var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(checkBusDate)).ToList();
            var lstOI = new SQLiteDbHelper().QueryMultiByWhere<TaOrderItemInfo>("Ta_OrderItem", strSqlWhere, dynamicParams);

            string htmlText = doc.Text;

            wbPtl = GetAllPrtInfo();

            if (string.IsNullOrEmpty(htmlText)) webBrowser2.DocumentText = "";

            htmlText = WbPrtPrint.ReplaceHtmlPrtKeysShop(htmlText, wbPtl);
            htmlText = WbPrtPrint.GetOrderItemInfo(doc, htmlText, lstOI, false);
            webBrowser2.DocumentText = htmlText;

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine(@"FrmTaShowOrder/RefreshPrtInfo Time:{0}", ts.TotalMilliseconds);

            //webBrowser2.Refresh();
        }

        
    }
}