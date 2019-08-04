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
using SuperPOS.Common;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaPendOrder : DevExpress.XtraEditors.XtraForm
    {
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

        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmTaPendOrder()
        {
            InitializeComponent();
        }

        public FrmTaPendOrder(int uID)
        {
            InitializeComponent();
            usrID = uID;
        }

        private void GetBindData(string orderType, int iDriver)
        {
            var lstDb = from check in CommonData.TaCheckOrder
                        join user in CommonData.UsrBase
                            on check.StaffID equals user.ID
                        where !check.IsPaid.Equals("Y")
                        select new
                        {
                            ID = check.ID,
                            CheckCode = check.CheckCode,
                            OrderTime = check.PayTime,
                            PostCode = "",
                            PostCodeZone = "",
                            Addr = "",
                            PayOrderType = check.PayOrderType,
                            CustomerName = "",
                            CustomerPhone = "",
                            IsPaid = check.IsPaid,
                            TotalAmount = check.TotalAmount,
                            StaffName = user.UsrName,
                            Paid = check.Paid,
                            CustID = Convert.ToInt32(check.CustomerID),
                            DriverID = 0,
                            DriverName = "",
                        };

            if (iDriver != 0)
            {
                lstDb = from check in CommonData.TaCheckOrder
                        join cust in CommonData.TaCustomer
                            on check.CustomerID equals cust.ID.ToString()
                        join user in CommonData.UsrBase
                            on check.StaffID equals user.ID
                        join driver in CommonData.TaDriver
                            on check.DriverID equals driver.ID
                        where !check.IsPaid.Equals("Y")
                        select new
                        {
                            ID = check.ID,
                            CheckCode = check.CheckCode,
                            OrderTime = check.PayTime,
                            PostCode = cust.cusPostcode,
                            PostCodeZone = cust.cusPcZone,
                            Addr = cust.cusAddr,
                            PayOrderType = check.PayOrderType,
                            CustomerName = cust.cusName,
                            CustomerPhone = cust.cusPhone,
                            IsPaid = check.IsPaid,
                            TotalAmount = check.TotalAmount,
                            StaffName = user.UsrName,
                            Paid = check.Paid,
                            CustID = cust.ID,
                            DriverID = check.DriverID,
                            DriverName = driver.DriverName,
                        };
            }

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

            txtTotal.Text = lstTmp.Sum(s => Convert.ToDecimal(s.TotalAmount)).ToString();
        }

        private void FrmTaPendOrder_Load(object sender, EventArgs e)
        {
            SystemData systemData = new SystemData();
            systemData.GetTaCheckOrder();
            systemData.GetTaCustomer();
            systemData.GetUsrBase();
            systemData.GetTaOrderItem();

            GetBindData("", 0);

            BinLueDriver();

            asfc.controllInitializeSize(this);
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
            if (gvTaPendOrder.FocusedRowHandle <= 0) return;
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
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (checkOrderType.Equals(PubComm.ORDER_TYPE_SHOP))
            {
                FrmTaPaymentShop frmTaPaymentShop = new FrmTaPaymentShop(usrID, checkCode, checkOrderType, checkCustID.ToString(), SetPrtInfo());

                if (frmTaPaymentShop.ShowDialog() == DialogResult.OK)
                {
                    if (frmTaPaymentShop.returnPaid) GetBindData("", 0);
                }
            }
            else
            {
                FrmTaPayment frmTaPayment = new FrmTaPayment(usrID, checkCode, checkOrderType, checkCustID.ToString(), SetPrtInfo());

                if (frmTaPayment.ShowDialog() == DialogResult.OK)
                {
                    if (frmTaPayment.returnPaid) GetBindData("", 0);
                }
            }
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            GetBindData(PubComm.ORDER_TYPE_DELIVERY, 0);
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            GetBindData(PubComm.ORDER_TYPE_COLLECTION, 0);
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            GetBindData(PubComm.ORDER_TYPE_SHOP, 0);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            GetBindData("", 0);
        }

        #region 设置打印相关信息

        private Hashtable SetPrtInfo()
        {
            Hashtable htDetail = new Hashtable();

            new SystemData().GetUsrBase();

            htDetail["Staff"] = CommonData.UsrBase.Any(s => s.ID == usrID) ? CommonData.UsrBase.FirstOrDefault(s => s.ID == usrID).UsrName : "";

            var lstOi = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkCode));

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

            new SystemData().GetTaOrderItem();
            var lstOi = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkCode)).ToList();

            #region VAT计算
            if (CommonData.GenSet.Any())
            {
                ht["Rate1"] = CommonData.GenSet.FirstOrDefault().VATPer + @"%";

                var lstVAT = from oi in CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID))
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

            new SystemData().GetTaOrderItem();
            var lstOi = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkCode)).ToList();

            PrtPrint.PrtBillBilingual(lstOi, ht);
        }

        private void btnPrtKit_Click(object sender, EventArgs e)
        {
            Hashtable ht = SetPrtInfo();
            ht["ChkNum"] = checkCode;

            new SystemData().GetTaOrderItem();
            var lstOi = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkCode)).ToList();

            PrtPrint.PrtKitchen(lstOi, ht);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
            FrmTaMain frmTaMain = new FrmTaMain(usrID);
            frmTaMain.ShowDialog();
        }

        private void gvTaPendOrder_DoubleClick(object sender, EventArgs e)
        {
            Hide();
            FrmTaMain frmTaMain = new FrmTaMain(checkCode, usrID, checkCustID);
            frmTaMain.ShowDialog();
        }

        private void FrmTaPendOrder_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            GetBindData("", 0);
        }

        private void btnShowAssigned_Click(object sender, EventArgs e)
        {
            GetBindData("", 1);
        }

        private void btnShowUnAssigned_Click(object sender, EventArgs e)
        {
            GetBindData("", 2);
        }

        private void btnAssignDriver_Click(object sender, EventArgs e)
        {
            if (gvTaPendOrder.FocusedRowHandle <= 0) return;

            new SystemData().GetTaCheckOrder();
            var lstRec = CommonData.TaCheckOrder.Where(s => s.ID == Convert.ToInt32(gvTaPendOrder.GetRowCellValue(gvTaPendOrder.FocusedRowHandle, "ID").ToString()));

            if (lstRec.Any())
            {
                TaCheckOrderInfo taCheckOrderInfo = lstRec.FirstOrDefault();

                taCheckOrderInfo.DriverID = Convert.ToInt32(lueDriver.EditValue);
                
                _control.UpdateEntity(taCheckOrderInfo);
            }

            GetBindData("", 0);
        }
        #region 绑定Driver

        private void BinLueDriver()
        {
            new SystemData().GetTaDriver();

            var lstDriver = from td in CommonData.TaDriver
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
            FrmTaMain frmTaMain = new FrmTaMain(checkCode, usrID, checkCustID);
            frmTaMain.ShowDialog();
        }
    }
}