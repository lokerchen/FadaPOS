using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;
using SuperPOS.UI.TA;

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

        public FrmTaShowOrder()
        {
            InitializeComponent();
        }

        public FrmTaShowOrder(int uId)
        {
            InitializeComponent();

            usrID = uId;
        }

        private void FrmTaShowOrder_Load(object sender, EventArgs e)
        {
            SystemData sysData = new SystemData();

            sysData.GetTaCheckOrder();
            //sysData.GetTaCustomer();
            sysData.GetUsrBase();
            sysData.GetTaOrderItem();
            //sysData.GetTaPaymentDetail();
            sysData.GetTaPreview();

            GetBindData("");
            
            //richEditCtlPreview.Font = new Font(@"Courier New", PrtStatic.PRT_GEN_SET1_FONT_SIZE_10);
            richEditCtlPreview.Font = new Font(@"Courier New", 10f);

            //richEditCtlPreview.Margin.Left = 0;

            //SetPrtTmpInfo();

            if (CommonData.TaPreview.Any())
            {
                PreviewContent = CommonData.TaPreview.FirstOrDefault().PreviewContent;
            }

            richEditCtlPreview.Text = SetPreviewInfo(PreviewContent);

            var lstGsSet1 = CommonData.TaPrtSetupGeneralSet1;
            if (lstGsSet1.Any())
            {
                TaPrtSetupGeneralSet1Info taPrtSetupGeneralSet1Info = lstGsSet1.FirstOrDefault();
                PrtLang = taPrtSetupGeneralSet1Info.PrtLang;
            }

            asfc.controllInitializeSize(this);
        }

        #region 绑定初始数据
        /// <summary>
        /// 绑定初始数据
        /// </summary>
        /// <param name="orderType">账单类型</param>
        private void GetBindData(string orderType)
        {
            var lstDb = from check in CommonData.TaCheckOrder
                        join user in CommonData.UsrBase
                            on check.StaffID equals user.ID
                        join driver in CommonData.TaDriver
                            on check.DriverID equals driver.ID
                        where check.IsPaid.Equals("Y")
                              && check.BusDate.Equals(CommonDAL.GetBusDate())
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
                            gridStaff = user.UsrName,
                            gridCustID = check.CustomerID,
                            gridDiscountPer = check.PayPerDiscount,
                            gridDisount = check.PayDiscount,
                            gridSubTotal = check.MenuAmount,
                            gridBusDate = check.BusDate
                        };

            gridControlTaShowOrder.DataSource = !string.IsNullOrEmpty(orderType)
                                                ? lstDb.Where(s => s.gridOrderType.Equals(orderType)).ToList()
                                                : lstDb.ToList();
            gvTaShowOrder.Columns["gridOrderTime"].BestFit();
            gvTaShowOrder.FocusedRowHandle = gvTaShowOrder.RowCount - 1;
        }
        #endregion

        private string GetAllPayType(string s1, string s2)
        {
            return Convert.ToDecimal(s1) > 0.00m ? s2 : "";
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
                richEditCtlPreview.Text = "";
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

            sItemCount = GetItemCount(strChkOrder);


            richEditCtlPreview.Font = new Font(@"Courier New", 10f);
            ////预览信息
            ////richEditCtlPreview.Text = SetPreviewInfo();
            //if (CommonData.TaPreview.Any())
            //{
            //    richEditCtlPreview.Text = SetPreviewInfo(CommonData.TaPreview.FirstOrDefault().PreviewContent);
            //}
            richEditCtlPreview.Text = SetPreviewInfo(PreviewContent);
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
            new SystemData().GetTaOrderItem();
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder)).ToList();

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

                var lstVAT = from oi in CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder))
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
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder)).ToList();

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
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder)).ToList();

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
        #endregion

        #region 列表过滤
        private void btnAll_Click(object sender, EventArgs e)
        {
            GetBindData("");
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            GetBindData(PubComm.ORDER_TYPE_COLLECTION);
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            GetBindData(PubComm.ORDER_TYPE_DELIVERY);
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            GetBindData(PubComm.ORDER_TYPE_SHOP);
        }

        private void btnEatIn_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private string GetPayType(string sChkId)
        {
            new SystemData().GetTaCheckOrder();
            var lstChk = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(sChkId));

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

        private string SetPreviewInfo(string content)
        {
            new SystemData().GetTaOrderItem();
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder)).ToList();

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

                var lstVAT = from oi in CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder))
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

        private string SetPreviewInfo()
        {
            new SystemData().GetTaOrderItem();
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder)).ToList();

            PrtTemplataTa prtTemplataTa = new PrtTemplataTa();
            prtTemplataTa = ptl;
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

                var lstVAT = from oi in CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder))
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

            return PrtTemplate.ReplacePrtKeysPreview(prtTemplataTa, lstOI);
        }

        private void SetPrtTmpInfo()
        {
            int iFontSize = 2;
            //int iLang = 2;

            new SystemData().GetTaPrtSetupGeneral();
            if (CommonData.TaPrtSetupGeneral.Any())
            {
                TaPrtSetupGeneralInfo taPrtSetupGeneralInfo = CommonData.TaPrtSetupGeneral.FirstOrDefault();
                ptl.Msg1 = taPrtSetupGeneralInfo.Msg1;
                ptl.Msg2 = taPrtSetupGeneralInfo.Msg2;
                ptl.Msg3 = taPrtSetupGeneralInfo.Msg3;
                ptl.Msg4 = taPrtSetupGeneralInfo.Msg4;
                ptl.Msg5 = taPrtSetupGeneralInfo.Msg5;
            }

            new SystemData().GetTaPrtSetupGetSet1();
            var lstGsSet1 = CommonData.TaPrtSetupGeneralSet1;
            //打印字体
            float fFontSize = 10.5F;
            //打印机名称
            string strPrinterName = "";
            //单/双语
            PrtLang = PrtStatic.PRT_GEN_SET1_LAN_Both;

            if (lstGsSet1.Any())
            {
                TaPrtSetupGeneralSet1Info taPrtSetupGeneralSet1Info = lstGsSet1.FirstOrDefault();
                //FontSize
                fFontSize = string.IsNullOrEmpty(taPrtSetupGeneralSet1Info.PrtFontSize) ? 10.5F : Convert.ToSingle(taPrtSetupGeneralSet1Info.PrtFontSize);
                //strPrinterName
                //TO-DO Something
                //单/双语
                PrtLang = taPrtSetupGeneralSet1Info.PrtLang;
                //Message At Bottom
                ptl.MsgAtBotton = taPrtSetupGeneralSet1Info.PrtMsgAtBottom;
            }

            ptl.RestaurantName = PrtCommon.GetRestName();
            ptl.Addr = PrtCommon.GetRestAddr();
            ptl.Telephone = PrtCommon.GetRestTel();
            ptl.VatNo = PrtCommon.GetRestVATNo();
            ptl.OrderTime = PrtCommon.GetPrtTime();
            ptl.OrderDate = PrtCommon.GetPrtDateTime();
        }

        private int GetItemCount(string chkCode)
        {
            return CommonData.TaOrderItem.Count(s => s.CheckCode.Equals(chkCode) && s.ItemType == 1);
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

        private void btnChangePayment_Click(object sender, EventArgs e)
        {
            FrmTaPaymentShop frmTaPaymentShop = new FrmTaPaymentShop(usrID, strChkOrder, sOrderType, SetPrtInfo(CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder)).ToList()));

            frmTaPaymentShop.ShowDialog();

            GetBindData("");
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            Hide();
            FrmTaMain frmTaMain = new FrmTaMain(strChkOrder, usrID, intCusID);
            frmTaMain.ShowDialog();
        }
    }
}