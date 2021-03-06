﻿using System;
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
using HtmlAgilityPack;
using SuperPOS.Common;
using SuperPOS.Dapper;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaPendOrderPreview : DevExpress.XtraEditors.XtraForm
    {
        private string PreviewContent = "";

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

        private string PrtLang = "";

        private int sItemCount = 0;

        private string strBusDate = @"";

        private string sTendered = @"0.00";
        private string sChange = @"0.00";
        private string sRefNo = @" ";
        private string sDeliveryFee = @"0.00";
        private string sSurcharge = @"0.00";

        HtmlAgilityPack.HtmlDocument doc = null;

        public FrmTaPendOrderPreview()
        {
            InitializeComponent();
        }

        public FrmTaPendOrderPreview(string chkOrder, string totalAmount, string subTotal, string staffName, string discount, string discountPer)
        {
            InitializeComponent();

            strChkOrder = chkOrder;
            sTotalAmount = totalAmount;
            sSubTotal = subTotal;
            sStaff = staffName;
            sDiscount = discount;
            sDiscountPer = discountPer;
        }

        public FrmTaPendOrderPreview(string chkOrder, string totalAmount, string subTotal, string staffName, string discount, string discountPer, string sBusDate, string strTendered,
                                     string strChange, string strRefNo, string strDeliveryFee, string strSurcharge)
        {
            InitializeComponent();

            strChkOrder = chkOrder;
            sTotalAmount = totalAmount;
            sSubTotal = subTotal;
            sStaff = staffName;
            sDiscount = discount;
            sDiscountPer = discountPer;
            strBusDate = sBusDate;
            sTendered = strTendered;
            sChange = strChange;
            sRefNo = strRefNo;
            sDeliveryFee = strDeliveryFee;
            sSurcharge = strSurcharge;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FrmPendOrderPreview_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("about:blank/");

            //获得菜品数量
            sItemCount = GetItemCount(strChkOrder);

            RefreshPrtInfo();

            //var lstGsSet1 = CommonData.TaPrtSetupGeneralSet1;
            //if (lstGsSet1.Any())
            //{
            //    TaPrtSetupGeneralSet1Info taPrtSetupGeneralSet1Info = lstGsSet1.FirstOrDefault();
            //    PrtLang = taPrtSetupGeneralSet1Info.PrtLang;
            //}

            //if (CommonData.TaPreview.Any())
            //{
            //    PreviewContent = CommonData.TaPreview.FirstOrDefault().PreviewContent;
            //}

            //richEditCtlPreview.Font = new Font(@"Courier New", 10f);
            //richEditCtlPreview.Text = SetPreviewInfo(PreviewContent);    
        }

       private int GetItemCount(string checkOrderID)
        {
            return CommonData.TaOrderItem.Count(s => s.CheckCode.Equals(checkOrderID) && s.ItemType == 1 && s.BusDate.Equals(strBusDate));
        }

        private void RefreshPrtInfo()
        {
            if (string.IsNullOrEmpty(strChkOrder)) return;

            if (doc == null) doc = new HtmlWeb().Load(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"so" + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX);

            string strSqlWhere = "";
            DynamicParameters dynamicParams = new DynamicParameters();

            strSqlWhere = "CheckCode=@CheckCode AND BusDate=@BusDate";

            dynamicParams.Add("CheckCode", strChkOrder);
            dynamicParams.Add("BusDate", strBusDate);

            var lstOI = new SQLiteDbHelper().QueryMultiByWhere<TaOrderItemInfo>("Ta_OrderItem", strSqlWhere, dynamicParams);
            //new SystemData().GetTaOrderItem();
            //var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(strBusDate)).ToList();

            WbPrtTemplataTa wbPrtTemplataTa = new WbPrtTemplataTa();
            wbPrtTemplataTa = GetAllPrtInfo();
            
            string htmlText = doc.Text;

            if (string.IsNullOrEmpty(htmlText)) webBrowser1.DocumentText = "";

            htmlText = WbPrtPrint.ReplaceHtmlPrtKeysShop(htmlText, wbPrtTemplataTa);

            htmlText = WbPrtPrint.GetOrderItemInfo(doc, htmlText, lstOI, false);

            webBrowser1.DocumentText = htmlText;

            //webBrowser2.Refresh();
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
                new SystemData().GetTaCustomer();
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
            wbPrtTemplataTa.Staff = string.IsNullOrEmpty(sStaff) ? "" : sStaff;
            wbPrtTemplataTa.OrderNo = strChkOrder;
            wbPrtTemplataTa.ItemCount = sItemCount >= 1 ? sItemCount.ToString() : "0";
            wbPrtTemplataTa.SubTotal = sSubTotal;
            wbPrtTemplataTa.Total = sTotalAmount;
            string sPayType = CommonDAL.GetPayType(strChkOrder, strBusDate);
            wbPrtTemplataTa.PayType = sPayType;
            wbPrtTemplataTa.Tendered = sTendered;
            wbPrtTemplataTa.Change = string.IsNullOrEmpty(sChange) ? @"0.00" : (Convert.ToDecimal(sChange)).ToString("0.00");
            wbPrtTemplataTa.OrderType = sPayType;
            wbPrtTemplataTa.RefNo = sRefNo;
            wbPrtTemplataTa.DeliveryFee = sDeliveryFee;

            wbPrtTemplataTa.Discount = sDiscount;
            wbPrtTemplataTa.Surcharge = sSurcharge;

            string strSqlWhere = "";
            DynamicParameters dynamicParams = new DynamicParameters();

            strSqlWhere = " CheckCode=@CheckCode AND BusDate=@BusDate";

            dynamicParams.Add("BusDate", strBusDate);
            dynamicParams.Add("CheckCode", strChkOrder);

            var lstOi = new SQLiteDbHelper().QueryMultiByWhere<TaOrderItemInfo>("Ta_OrderItem", strSqlWhere, dynamicParams);

            #region VAT计算
            if (CommonData.GenSet.Any())
            {
                wbPrtTemplataTa.Rate1 = CommonData.GenSet.FirstOrDefault().VATPer + @"%";

                var lstVAT = from oi in lstOi
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

                wbPrtTemplataTa.VatA = dVat.ToString();
                //税前
                wbPrtTemplataTa.Net1 = dTotal.ToString();
                //总价
                wbPrtTemplataTa.Gross1 = (dTotal - dVat).ToString();
                wbPrtTemplataTa.Rate2 = "0.00%";
                wbPrtTemplataTa.Net2 = (Convert.ToDecimal(sSubTotal) - dTotal).ToString();
                wbPrtTemplataTa.VatB = "0.00";
                wbPrtTemplataTa.Gross2 = (Convert.ToDecimal(sSubTotal) - dTotal).ToString();
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
            #endregion

            return wbPrtTemplataTa;
        }
    }
}