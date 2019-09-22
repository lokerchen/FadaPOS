using System;
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
            sysData.GetTaCustomer();
            sysData.GetUsrBase();
            sysData.GetTaOrderItem();
            sysData.GetTaPaymentDetail();

            GetBindData("");

            //加载会员信息
            GetCustInfo(intCusID);

            //richEditCtlPreview.Font = new Font(@"Courier New", PrtStatic.PRT_GEN_SET1_FONT_SIZE_10);
            richEditCtlPreview.Font = new Font(@"Courier New", 10f);

            //richEditCtlPreview.Margin.Left = 0;

            SetPrtTmpInfo();

            //预览信息
            richEditCtlPreview.Text = SetPreviewInfo();
            
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
                        select new
                        {
                            ID = check.ID,
                            gridOrderNo = check.CheckCode,
                            gridPayType = check.PayOrderType,
                            gridOrderType = check.PayOrderType,
                            gridOrderTime = check.PayTime,
                            gridTotal = check.TotalAmount,
                            gridDriver = driver.DriverName,
                            gridStaff = user.UsrName,
                            gridCustID = check.CustomerID,
                            gridDiscountPer = check.PayPerDiscount,
                            gridDisount = check.PayDiscount,
                            gridSubTotal = check.MenuAmount
                        };

            gridControlTaShowOrder.DataSource = !string.IsNullOrEmpty(orderType)
                                                ? lstDb.Where(s => s.gridOrderType.Equals(orderType)).ToList()
                                                : lstDb.ToList();
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
            if (gvTaShowOrder.RowCount <= 0) return;

            intChkID = Convert.ToInt32(gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "ID").ToString());
            strChkOrder = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridOrderNo").ToString();
            intCusID = Convert.ToInt32(gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridCustID").ToString());
            sTotalAmount = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridTotal").ToString();
            sStaff = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridStaff").ToString();
            sDiscountPer = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridDiscountPer").ToString();
            sDiscount = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridDisount").ToString();
            sSubTotal = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridSubTotal").ToString();
            
            //加载OrderItem信息
            InitGrid(CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder)).ToList());

            //加载会员信息
            GetCustInfo(intCusID);

            richEditCtlPreview.Font = new Font(@"Courier New", 10f);
            //预览信息
            richEditCtlPreview.Text = SetPreviewInfo();
        }

        private void GetCustInfo(int cID)
        {
            if (cID <= 0)
            {
                lblCusName.Text = "";
                lblCusPhone.Text = "";
                lblCusAddr.Text = "";
                lblCusPostcode.Text = "";
                lblCusDistance.Text = "";
                lblDeliveryFee.Text = "";
            }
            else
            {
                new SystemData().GetTaCustomer();

                var lstCust = CommonData.TaCustomer.Where(s => s.ID == cID);

                if (lstCust.Any())
                {
                    TaCustomerInfo taCustomerInfo = lstCust.FirstOrDefault();

                    lblCusName.Text = taCustomerInfo.cusName;
                    lblCusPhone.Text = taCustomerInfo.cusPhone;
                    lblCusAddr.Text = taCustomerInfo.cusAddr;
                    lblCusPostcode.Text = taCustomerInfo.cusPostcode;
                    lblCusDistance.Text = taCustomerInfo.cusDistance;
                    lblDeliveryFee.Text = taCustomerInfo.cusDelCharge;
                }
                else
                {
                    lblCusName.Text = "";
                    lblCusPhone.Text = "";
                    lblCusAddr.Text = "";
                    lblCusPostcode.Text = "";
                    lblCusDistance.Text = "";
                    lblDeliveryFee.Text = "";
                }
            }
        }

        private void InitGrid(List<TaOrderItemInfo> lst)
        {
            TreeListNode node = null;

            //清除TreeList
            treeListOrder.ClearNodes();

            foreach (var taOrderItemInfo in lst)
            {
                if (taOrderItemInfo.ItemType == 1)
                    node = AddTreeListNode(taOrderItemInfo);
                else
                    AddTreeListChild(taOrderItemInfo, node);
            }
        }

        #region 增加TreeList子节点
        /// <summary>
        /// 增加TreeList子节点
        /// </summary>
        /// <param name="taOrderItemInfo">OrderItem信息</param>
        /// <param name="node">父节点</param>
        private void AddTreeListChild(TaOrderItemInfo taOrderItemInfo, TreeListNode node)
        {
            treeListOrder.BeginUnboundLoad();

            TreeListNode node1 = treeListOrder.AppendNode(new object[]
            {
                taOrderItemInfo.ID,
                taOrderItemInfo.ItemID,
                taOrderItemInfo.ItemCode,
                taOrderItemInfo.ItemDishName,
                taOrderItemInfo.ItemDishOtherName,
                taOrderItemInfo.ItemQty,
                taOrderItemInfo.ItemPrice,
                taOrderItemInfo.ItemTotalPrice,
                taOrderItemInfo.CheckCode,
                taOrderItemInfo.ItemType,
                taOrderItemInfo.ItemParent,
                taOrderItemInfo.OrderTime,
                taOrderItemInfo.OrderStaff
            }, node);

            Console.WriteLine(node1["ItemParent"].ToString());

            treeListOrder.EndUnboundLoad();

            treeListOrder.ExpandAll();
        }
        #endregion

        #region 增加TreeList节点
        private TreeListNode AddTreeListNode(TaOrderItemInfo taOrderItemInfo)
        {
            treeListOrder.BeginUnboundLoad();

            TreeListNode node = treeListOrder.AppendNode(new object[]
            {
                taOrderItemInfo.ID,
                taOrderItemInfo.ItemID,
                taOrderItemInfo.ItemCode,
                taOrderItemInfo.ItemDishName,
                taOrderItemInfo.ItemDishOtherName,
                taOrderItemInfo.ItemQty,
                taOrderItemInfo.ItemPrice,
                taOrderItemInfo.ItemTotalPrice,
                taOrderItemInfo.CheckCode,
                taOrderItemInfo.ItemType,
                taOrderItemInfo.ItemParent,
                taOrderItemInfo.OrderTime,
                taOrderItemInfo.OrderStaff
            }, -1);

            treeListOrder.EndUnboundLoad();

            treeListOrder.ExpandAll();

            return node;
        }
        #endregion

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
            prtTemplataTa.ItemCount = treeListOrder.Nodes.Count >= 1 ? treeListOrder.Nodes.Count.ToString() : "0";
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
            prtTemplataTa.ItemCount = treeListOrder.Nodes.Count >= 1 ? treeListOrder.Nodes.Count.ToString() : "0";
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
            prtTemplataTa.ItemCount = treeListOrder.Nodes.Count >= 1 ? treeListOrder.Nodes.Count.ToString() : "0";
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
            //加载会员信息
            GetCustInfo(intCusID);

            if (gvTaShowOrder.RowCount < 1) treeListOrder.Nodes.Clear();
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            GetBindData(PubComm.ORDER_TYPE_COLLECTION);
            //加载会员信息
            GetCustInfo(intCusID);

            if (gvTaShowOrder.RowCount < 1) treeListOrder.Nodes.Clear();
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            GetBindData(PubComm.ORDER_TYPE_DELIVERY);
            //加载会员信息
            GetCustInfo(intCusID);

            if (gvTaShowOrder.RowCount < 1) treeListOrder.Nodes.Clear();
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            GetBindData(PubComm.ORDER_TYPE_SHOP);
            //加载会员信息
            GetCustInfo(intCusID);

            if (gvTaShowOrder.RowCount < 1) treeListOrder.Nodes.Clear();
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
            prtTemplataTa.ItemCount = treeListOrder.Nodes.Count >= 1 ? treeListOrder.Nodes.Count.ToString() : "0";
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
            string strPrtLang = PrtStatic.PRT_GEN_SET1_LAN_Both;

            if (lstGsSet1.Any())
            {
                TaPrtSetupGeneralSet1Info taPrtSetupGeneralSet1Info = lstGsSet1.FirstOrDefault();
                //FontSize
                fFontSize = string.IsNullOrEmpty(taPrtSetupGeneralSet1Info.PrtFontSize) ? 10.5F : Convert.ToSingle(taPrtSetupGeneralSet1Info.PrtFontSize);
                //strPrinterName
                //TO-DO Something
                //单/双语
                strPrtLang = taPrtSetupGeneralSet1Info.PrtLang;
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

    }
}