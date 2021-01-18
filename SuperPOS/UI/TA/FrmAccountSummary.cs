using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LinqToDB;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;
using HtmlAgilityPack;

namespace SuperPOS.UI.TA
{
    public partial class FrmAccountSummary : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

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
        
        private string PreviewContent = "";

        private int sItemCount = 0;
        private string sOrderType = "";

        private string checkBusDate = @"";

        private string strBusDate = "";

        private int intStaffID = 0;

        HtmlAgilityPack.HtmlDocument doc = null;

        private string sTendered = @"0.00";
        private string sChange = @"0.00";
        private string sRefNo = @" ";
        private string sDeliveryFee = @"0.00";
        private string sSurcharge = @"0.00";
        private decimal dTotalTA = 0.00m;
        private decimal dCollection = 0.00m;
        private decimal dDelivery = 0.00m;
        private decimal dShop = 0.00m;
        private decimal dFastFood = 0.00m;
        private decimal dEatIn = 0.00m;
        private decimal dTotalTaking = 0.00m;
        private decimal dTotalOrder = 0.00m;
        private decimal dDC = 0.00m;
        private decimal dSC = 0.00m;

        //默认为双语
        private string PrtLang = PrtStatic.PRT_GEN_SET1_LAN_Both;

        //默认语言标识状态位
        public int iLangStatusId = PubComm.MENU_LANG_DEFAULT;
        
        public FrmAccountSummary()
        {
            InitializeComponent();
        }

        public FrmAccountSummary(int id, string name)
        {
            InitializeComponent();

            usrID = id;
            usrName = name;
        }

        private void FrmAccountSummary_Load(object sender, EventArgs e)
        {
            SystemData sysData = new SystemData();

            sysData.GetTaCheckOrder();
            sysData.GetUsrBase();
            sysData.GetTaOrderItem();
            sysData.GetTaPreview();

            webBrowser2.Navigate("about:blank/");

            GetBindData(CommonDAL.GetBusDate());
            
            //richEditCtlPreview.Font = new Font(@"Courier New", 10f);

            //if (CommonData.TaPreview.Any())
            //{
            //    PreviewContent = CommonData.TaPreview.FirstOrDefault().PreviewContent;
            //}

            //richEditCtlPreview.Text = SetPreviewInfo(PreviewContent);

            var lstGsSet1 = CommonData.TaPrtSetupGeneralSet1;
            if (lstGsSet1.Any())
            {
                TaPrtSetupGeneralSet1Info taPrtSetupGeneralSet1Info = lstGsSet1.FirstOrDefault();
                PrtLang = taPrtSetupGeneralSet1Info.PrtLang;
            }

            deDay.Text = CommonDAL.GetBusDate();

            gvTaShowOrder.FocusedRowHandle = gvTaShowOrder.RowCount - 1;

            //RefreshPrtInfo();

            asfc.controllInitializeSize(this);
        }

        #region 窗口大小自动改变
        /// <summary>
        /// 窗口大小自动改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAccountSummary_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
        #endregion

        #region 绑定初始数据
        /// <summary>
        /// 绑定初始数据
        /// </summary>
        /// <param name="busDate">营业日</param>
        private void GetBindData(string busDate)
        {
            var lstDb = from check in CommonData.TaCheckOrder
                        join user in CommonData.UsrBase
                            on check.StaffID equals user.ID
                        join driver in CommonData.TaDriver
                            on check.DriverID equals driver.ID
                        where check.IsPaid.Equals("Y")
                        select new
                        {
                            ID = check.ID,
                            gridOrderNo = check.CheckCode,
                            gridPayType = (GetAllPayType(check.PayTypePay1, check.PayType1) + @" "
                                            + GetAllPayType(check.PayTypePay2, check.PayType2) + @" "
                                            + GetAllPayType(check.PayTypePay3, check.PayType3) + @" "
                                            + GetAllPayType(check.PayTypePay4, check.PayType4) + @" "
                                            + GetAllPayType(check.PayTypePay5, check.PayType5)).Trim(),
                            gridOrderType = check.PayOrderType,
                            gridOrderTime = check.PayTime,
                            gridTotal = check.TotalAmount,
                            gridDriver = driver.DriverName,
                            //gridDriver = "",
                            gridStaff = user.UsrName,
                            gridCustID = check.CustomerID,
                            gridDiscountPer = check.PayPerDiscount,
                            gridDisount = check.PayDiscount,
                            gridSubTotal = check.MenuAmount,
                            gridBusDate = check.BusDate,
                            gridTendered = check.Paid,
                            gridChange =
                                (Convert.ToDecimal(check.Paid) - Convert.ToDecimal(check.TotalAmount)) <= 0
                                    ? "0.0"
                                    : (Convert.ToDecimal(check.Paid) - Convert.ToDecimal(check.TotalAmount)).ToString(),
                            gridRefNo = check.RefNum,
                            gridDeliveryFee = check.DeliveryFee,
                            gridStaffId = check.StaffID,
                            gridSurcharge = check.PaySurcharge
                        };

            gridControlTaShowOrder.DataSource = !string.IsNullOrEmpty(busDate)
                                                ? lstDb.Where(s => s.gridBusDate.Equals(busDate)).ToList()
                                                : lstDb.ToList();
            gvTaShowOrder.Columns["gridOrderTime"].BestFit();
            gvTaShowOrder.FocusedRowHandle = gvTaShowOrder.RowCount - 1;

            #region 数据计算
            if (lstDb.Any())
            {
                dDelivery = lstDb.ToList().Any(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_DELIVERY) && s.gridBusDate.Equals(busDate))
                            ? lstDb.ToList().Where(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_DELIVERY) && s.gridBusDate.Equals(busDate)).Sum(s => Convert.ToDecimal(s.gridTotal))
                            : 0.00m;
                txtDelivery.Text = dDelivery.ToString("0.00");

                dCollection = lstDb.ToList().Any(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_COLLECTION) && s.gridBusDate.Equals(busDate))
                              ? lstDb.ToList().Where(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_COLLECTION) && s.gridBusDate.Equals(busDate)).Sum(s => Convert.ToDecimal(s.gridTotal))
                              : 0.00m;
                txtCollection.Text = dCollection.ToString("0.00");

                dShop = lstDb.ToList().Any(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_SHOP) && s.gridBusDate.Equals(busDate))
                        ? lstDb.ToList().Where(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_SHOP) && s.gridBusDate.Equals(busDate)).Sum(s => Convert.ToDecimal(s.gridTotal))
                        : 0.00m;
                txtShop.Text = dShop.ToString("0.00");

                dFastFood = lstDb.ToList().Any(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_FAST_FOOD) && s.gridBusDate.Equals(busDate))
                            ? lstDb.ToList().Where(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_FAST_FOOD) && s.gridBusDate.Equals(busDate)).Sum(s => Convert.ToDecimal(s.gridTotal))
                            : 0.00m;
                txtFastFood.Text = dFastFood.ToString("0.00");

                //dEatIn = lstDb.ToList().Any(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_EAT_IN) && s.gridBusDate.Equals(busDate))
                //         ? lstDb.ToList().Where(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_EAT_IN) && s.gridBusDate.Equals(busDate)).Sum(s => Convert.ToDecimal(s.gridTotal))
                //         : 0.00m;
                dEatIn = 0.00m;
                txtEatIn.Text = dEatIn.ToString("0.00");

                dTotalTA = dDelivery + dCollection + dShop;
                txtTotalTA.Text = dTotalTA.ToString("0.00");

                dTotalTaking = dTotalTA + dEatIn;
                txtTotalTaking.Text = dTotalTaking.ToString("0.00");

                dTotalOrder = lstDb.Count(s => s.gridBusDate.Equals(busDate));
                txtTotalOrder.Text = dTotalOrder.ToString("0.00");

                dDC = lstDb.ToList().Where(s => s.gridBusDate.Equals(busDate)).Sum(s => Convert.ToDecimal(s.gridDisount));
                txtDc.Text = dDC.ToString("0.00");

                dSC = lstDb.ToList().Where(s => s.gridBusDate.Equals(busDate)).Sum(s => Convert.ToDecimal(s.gridSurcharge));
                txtSc.Text = dSC.ToString("0.00");
            }
            else
            {
                dDelivery = 0.00m;
                txtDelivery.Text = @"0.00";

                dCollection = 0.00m;
                txtCollection.Text = @"0.00";

                dShop = 0.00m;
                txtShop.Text = @"0.00";

                dFastFood = 0.00m;
                txtFastFood.Text = @"0.00";

                dEatIn = 0.00m;
                txtEatIn.Text = @"0.00";

                dTotalTA = dDelivery + dCollection + dShop;
                txtTotalTA.Text = @"0.00";

                dTotalTaking = dTotalTA + dEatIn;
                txtTotalTaking.Text = @"0.00";

                dTotalOrder = 0.00m;
                txtTotalOrder.Text = @"0.00";

                dDC = 0.00m;
                txtDc.Text = @"0.00";

                dSC = 0.00m;
                txtSc.Text = @"0.00";
            }
            #endregion
        }
        #endregion

        private string GetAllPayType(string s1, string s2)
        {
            return Convert.ToDecimal(s1) > 0.00m ? s2 : "";
        }

        private string SetPreviewInfo(string content)
        {
            new SystemData().GetTaOrderItem();
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(deDay.Text)).ToList();

            PrtTemplataTa prtTemplataTa = new PrtTemplataTa();
            //prtTemplataTa = ptl;
            prtTemplataTa.OrderNo = strChkOrder;
            prtTemplataTa.PayType = GetPayType(strChkOrder);
            prtTemplataTa.TotalAmount = sTotalAmount;
            prtTemplataTa.SubTotal = sSubTotal;
            prtTemplataTa.StaffName = sStaff;
            prtTemplataTa.ItemCount = sItemCount >= 1 ? sItemCount.ToString() : "0";
            prtTemplataTa.Discount = sDiscount + sDiscountPer;

            #region VAT计算
            if (CommonData.GenSet.Any())
            {
                prtTemplataTa.Rete1 = CommonData.GenSet.FirstOrDefault().VATPer + @"%";

                var lstVAT = from oi in CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(deDay.Text))
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
                prtTemplataTa.Net2 = (Convert.ToDecimal(sSubTotal) - dTotal).ToString();
                prtTemplataTa.VatB = "0.00";
                prtTemplataTa.Gross2 = (Convert.ToDecimal(sSubTotal) - dTotal).ToString();
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

            return PrtTemplate.ReplacePrtKeysPreviewContent(content, prtTemplataTa, lstOI, PrtLang);
        }

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
            strChkOrder = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridOrderNo").ToString();
            intCusID = Convert.ToInt32(gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridCustID").ToString());
            sTotalAmount = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridTotal").ToString();
            sStaff = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridStaff").ToString();
            sDiscountPer = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridDiscountPer").ToString();
            sDiscount = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridDisount").ToString();
            sSubTotal = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridSubTotal").ToString();
            sOrderType = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridOrderType").ToString();
            checkBusDate = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridBusDate").ToString();

            sTendered = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridTendered").ToString();
            sChange = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridChange").ToString();
            sRefNo = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridRefNo") == null ? "" : gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridRefNo").ToString();
            sDeliveryFee = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridDeliveryFee") == null ? "" : gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridDeliveryFee").ToString();

            intStaffID = Convert.ToInt32(gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridStaffId").ToString());

            sSurcharge = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridSurcharge") == null ? "0.00" : gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridSurcharge").ToString();

            sItemCount = GetItemCount(strChkOrder);


            //richEditCtlPreview.Font = new Font(@"Courier New", 10f);
            ////预览信息
            ////richEditCtlPreview.Text = SetPreviewInfo();
            //if (CommonData.TaPreview.Any())
            //{
            //    richEditCtlPreview.Text = SetPreviewInfo(CommonData.TaPreview.FirstOrDefault().PreviewContent);
            //}
            //richEditCtlPreview.Text = SetPreviewInfo(PreviewContent);
            RefreshPrtInfo();


            //richEditCtlPreview.Font = new Font(@"Courier New", 10f);

            //richEditCtlPreview.Text = SetPreviewInfo(PreviewContent);
        }

        private void RefreshPrtInfo()
        {
            if (string.IsNullOrEmpty(strChkOrder)) return;

            if (doc == null) doc = new HtmlWeb().Load(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"so" + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX);

            new SystemData().GetTaOrderItem();
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(checkBusDate)).ToList();

            WbPrtTemplataTa wbPrtTemplataTa = new WbPrtTemplataTa();
            wbPrtTemplataTa = CommonDAL.GetAllPrtInfo(intCusID <= 0 ? "" : intCusID.ToString(),
                                                      sStaff,
                                                      intStaffID.ToString(),
                                                      strChkOrder,
                                                      sItemCount,
                                                      sSubTotal,
                                                      sTotalAmount,
                                                      sTendered,
                                                      sChange,
                                                      sRefNo,
                                                      sDeliveryFee,
                                                      sDiscount,
                                                      sSurcharge,
                                                      checkBusDate);

            string htmlText = doc.Text;

            if (string.IsNullOrEmpty(htmlText)) webBrowser2.DocumentText = "";

            htmlText = WbPrtPrint.ReplaceHtmlPrtKeysShop(htmlText, wbPrtTemplataTa);

            htmlText = WbPrtPrint.GetOrderItemInfo(doc, htmlText, lstOI, false);

            webBrowser2.DocumentText = htmlText;

            //webBrowser2.Refresh();
        }

        private int GetItemCount(string chkCode)
        {
            return CommonData.TaOrderItem.Count(s => s.CheckCode.Equals(chkCode) && s.ItemType == 1 && s.BusDate.Equals(deDay.Text));
        }

        private string GetPayType(string sChkId)
        {
            new SystemData().GetTaCheckOrder();
            var lstChk = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(sChkId) && s.BusDate.Equals(deDay.Text));

            string strPt = "Paid By ";

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

                if (Convert.ToDecimal(taCheckOrder.PayTypePay5) > 0)
                {
                    strPt += taCheckOrder.PayType5 + " ";
                }
            }

            return strPt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnPrtReceipt_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaOrderItem();
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(deDay.Text)).ToList();

            PrtTemplataTa prtTemplataTa = new PrtTemplataTa();
            prtTemplataTa.RestaurantName = PrtCommon.GetRestName();
            prtTemplataTa.Addr = PrtCommon.GetRestAddr();
            prtTemplataTa.Telephone = PrtCommon.GetRestTel();
            prtTemplataTa.VatNo = PrtCommon.GetRestVATNo();
            prtTemplataTa.OrderTime = PrtCommon.GetPrtTime();
            prtTemplataTa.OrderDate = PrtCommon.GetPrtDateTime();
            prtTemplataTa.OrderNo = strChkOrder;
            prtTemplataTa.PayType = GetPayType(strChkOrder);
            prtTemplataTa.TotalAmount = sTotalAmount;
            prtTemplataTa.SubTotal = sSubTotal;
            prtTemplataTa.StaffName = sStaff;
            prtTemplataTa.ItemCount = sItemCount >= 1 ? sItemCount.ToString() : "0";
            prtTemplataTa.Discount = sDiscount + sDiscountPer;

            #region VAT计算
            if (CommonData.GenSet.Any())
            {
                prtTemplataTa.Rete1 = CommonData.GenSet.FirstOrDefault().VATPer + @"%";

                var lstVAT = from oi in CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(deDay.Text))
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
                prtTemplataTa.Net2 = (Convert.ToDecimal(sSubTotal) - dTotal).ToString();
                prtTemplataTa.VatB = "0.00";
                prtTemplataTa.Gross2 = (Convert.ToDecimal(sSubTotal) - dTotal).ToString();
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

            PrtTemplate.PrtTa(prtTemplataTa, lstOI, PrtStatic.PRT_TEMPLATE_TA_RECEIPT_TYPE);
        }

        private void btnPrtBill_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaOrderItem();
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(deDay.Text)).ToList();

            PrtTemplataTa prtTemplataTa = new PrtTemplataTa();
            prtTemplataTa.RestaurantName = PrtCommon.GetRestName();
            prtTemplataTa.Addr = PrtCommon.GetRestAddr();
            prtTemplataTa.Telephone = PrtCommon.GetRestTel();
            prtTemplataTa.VatNo = PrtCommon.GetRestVATNo();
            prtTemplataTa.OrderTime = PrtCommon.GetPrtTime();
            prtTemplataTa.OrderDate = PrtCommon.GetPrtDateTime();
            prtTemplataTa.OrderNo = strChkOrder;
            prtTemplataTa.PayType = GetPayType(strChkOrder);
            prtTemplataTa.TotalAmount = sTotalAmount;
            prtTemplataTa.SubTotal = sSubTotal;
            prtTemplataTa.StaffName = sStaff;
            prtTemplataTa.ItemCount = sItemCount >= 1 ? sItemCount.ToString() : "0";
            prtTemplataTa.Discount = sDiscount + sDiscountPer;

            PrtTemplate.PrtTa(prtTemplataTa, lstOI, PrtStatic.PRT_TEMPLATE_TA_BILL_TYPE);
        }

        private void btnPrtKit_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaOrderItem();
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(deDay.Text)).ToList();

            PrtTemplataTa prtTemplataTa = new PrtTemplataTa();
            prtTemplataTa.RestaurantName = PrtCommon.GetRestName();
            prtTemplataTa.Addr = PrtCommon.GetRestAddr();
            prtTemplataTa.Telephone = PrtCommon.GetRestTel();
            prtTemplataTa.VatNo = PrtCommon.GetRestVATNo();
            prtTemplataTa.OrderTime = PrtCommon.GetPrtTime();
            prtTemplataTa.OrderDate = PrtCommon.GetPrtDateTime();
            prtTemplataTa.OrderNo = strChkOrder;
            prtTemplataTa.PayType = GetPayType(strChkOrder);
            prtTemplataTa.TotalAmount = sTotalAmount;
            prtTemplataTa.SubTotal = sSubTotal;
            prtTemplataTa.StaffName = sStaff;
            prtTemplataTa.ItemCount = sItemCount >= 1 ? sItemCount.ToString() : "0";
            prtTemplataTa.Discount = sDiscount + sDiscountPer;

            PrtTemplate.PrtTa(prtTemplataTa, lstOI, PrtStatic.PRT_TEMPLATE_TA_KITCHEN_TYPE);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            iLangStatusId = iLangStatusId == PubComm.MENU_LANG_DEFAULT
                            ? PubComm.MENU_LANG_OTHER
                            : PubComm.MENU_LANG_DEFAULT;
            //英文
            if (iLangStatusId == PubComm.MENU_LANG_DEFAULT)
            {
                btnLanguage.Text = @"LANGUAGE";
                btnAmendOrder.Text = @"Amend Order";
                btnVoidOrder.Text = @"Void Order";
                btnChangePayment.Text = @"Change Payment";

                btnSummaryView.Text = @"Summary View";
                btnPrtSalesRpt.Text = @"Print Sales Report";
                
                lblTotalTA.Text = @"Total T/A";
                lblCollection.Text = @"Collection";
                lblDelivery.Text = @"Delivery";
                lblShop.Text = @"Shop";
                lblFastFood.Text = @"Fast Food";
                lblEatIn.Text = @"Eat In";
                lblTotalTaking.Text = @"Total Takings";
                lblTotalOrder.Text = @"Total Order";
                lblDc.Text = @"D/C";
                lblSc.Text = @"S/C";

                btnPrtReceipt.Text = @"Print Receipt";
                btnPrtBill.Text = @"Print Bill";
                btnPrtKit.Text = @"Print Kitchen Paper";
                btnAccount.Text = @"Print Account Summary";

                btnExit.Text = @"Exit";
            }
            else
            {
                btnLanguage.Text = @"语言";
                btnAmendOrder.Text = @"修改单";
                btnVoidOrder.Text = @"废除单";
                btnChangePayment.Text = @"修改付款";

                btnSummaryView.Text = @"总结概览";
                btnPrtSalesRpt.Text = @"销售资料";

                lblTotalTA.Text = @"外卖总数";
                lblCollection.Text = @"拿餐";
                lblDelivery.Text = @"送餐";
                lblShop.Text = @"现场";
                lblFastFood.Text = @"快餐";
                lblEatIn.Text = @"堂食";
                lblTotalTaking.Text = @"全部总数";
                lblTotalOrder.Text = @"点单总数";
                lblDc.Text = @"送餐费";
                lblSc.Text = @"服务费";

                btnPrtReceipt.Text = @"打印发票";
                btnPrtBill.Text = @"打印账单";
                btnPrtKit.Text = @"打印厨房单";
                btnAccount.Text = @"打印账目概要";

                btnExit.Text = @"退出";
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            deDay.Text = (Convert.ToDateTime(deDay.Text)).AddDays(1).ToShortDateString();
            GetBindData(deDay.Text);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            deDay.Text = (Convert.ToDateTime(deDay.Text)).AddDays(-1).ToShortDateString();
            GetBindData(deDay.Text);
        }

        private void btnSummaryView_Click(object sender, EventArgs e)
        {
            FrmTaSummaryView frmTaSummaryView = new FrmTaSummaryView();
            frmTaSummaryView.ShowDialog();
        }

        private void btnChangePayment_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaOrderItem();
            TaCheckOrderInfo taCheckOrderInfo = CommonData.TaCheckOrder.FirstOrDefault(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(strBusDate));
            FrmTaPaymentShop frmTaPaymentShop = new FrmTaPaymentShop(usrID, 
                                                                     strChkOrder, 
                                                                     sOrderType, 
                                                                     SetPrtInfo(CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(deDay.Text)).ToList()),
                                                                     strBusDate,
                                                                     taCheckOrderInfo);

            frmTaPaymentShop.ShowDialog();

            GetBindData(CommonDAL.GetBusDate());
        }

        #region 设置打印相关信息

        private Hashtable SetPrtInfo(List<TaOrderItemInfo> lstOi)
        {
            Hashtable htDetail = new Hashtable();

            new SystemData().GetUsrBase();

            htDetail["Staff"] = CommonData.UsrBase.Any(s => s.ID == usrID) ? CommonData.UsrBase.FirstOrDefault(s => s.ID == usrID).UsrName : "";

            htDetail["ItemQty"] = GetItemCount(strChkOrder);
            htDetail["SubTotal"] = sTotalAmount;
            htDetail["Total"] = sTotalAmount;

            return htDetail;
        }
        #endregion

        private void btnAmendOrder_Click(object sender, EventArgs e)
        {
            //Hide();
            FrmTaMain frmTaMain = new FrmTaMain(strChkOrder, usrID, intCusID, deDay.Text, PubComm.MENU_LANG_DEFAULT);
            frmTaMain.ShowDialog();
        }
        
        private void FrmAccountSummary_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.Modifiers == ((int)Keys.Control + ((int)Keys.Shift)) && e.KeyCode == Keys.P)
            {
                FrmTaSummaryManagement frmTaSummaryManagement = new FrmTaSummaryManagement();
                frmTaSummaryManagement.ShowDialog();
            }
        }
    }
}