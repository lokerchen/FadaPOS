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

namespace SuperPOS.UI.TA
{
    public partial class FrmTaSummaryView : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        //默认语言标识状态位
        public int iLangStatusId = PubComm.MENU_LANG_DEFAULT;

        private string sTotalAmount = @"0.00";
        private string sStaff = @"";
        private string sDiscountPer = @"";
        private string sDiscount = @"0.00";
        private string sSubTotal = @"0.00";

        private int sItemCount = 0;
        private string sOrderType = "";

        private decimal dTsTotalTA = 0.00m;
        private decimal dTsCollection = 0.00m;
        private decimal dTsDelivery = 0.00m;
        private decimal dTsShop = 0.00m;
        private decimal dTsFastFood = 0.00m;
        private decimal dTsTotalOrder = 0.00m;
        private decimal dTsTotalCollection = 0.00m;
        private decimal dTsTotalDelivery = 0.00m;
        private decimal dTsTotalShop = 0.00m;
        private decimal dTsTotalFastFood = 0.00m;
        private decimal dTsTotalDc = 0.00m;
        private decimal dTsTotalDcCash = 0.00m;
        private decimal dTsTotalDcOther = 0.00m;

        private decimal dEsTotalEatIn = 0.00m;
        private decimal dEsSc = 0.00m;
        private decimal dEsTotalOrder = 0.00m;

        private decimal dStTotalTakings = 0.00m;
        private decimal dStTotalOrder = 0.00m;
        private decimal dStTotalVat = 0.00m;

        public FrmTaSummaryView()
        {
            InitializeComponent();
        }

        private void FrmTaSummaryView_Load(object sender, EventArgs e)
        {
            ChangeLang(iLangStatusId);
            asfc.controllInitializeSize(this);

            deDay.Text = CommonDAL.GetBusDate();

            txtCurrentTime.Text = DateTime.Now.ToLongTimeString();
            txtCurrentDate.Text = DateTime.Now.ToShortDateString();

            GetBindData(deDay.Text);
        }

        private void FrmTaSummaryView_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            iLangStatusId = iLangStatusId == PubComm.MENU_LANG_DEFAULT
                            ? PubComm.MENU_LANG_OTHER
                            : PubComm.MENU_LANG_DEFAULT;
            ChangeLang(iLangStatusId);
        }

        #region 按钮语言切换显示
        /// <summary>
        /// 按钮语言切换显示
        /// </summary>
        /// <param name="iLan">语言状态位</param>
        private void ChangeLang(int iLan)
        {
            if (iLan == PubComm.MENU_LANG_DEFAULT)
            {
                #region 英文

                lblTsTotalTA.Text = @"Total T/A";
                lblTsCollection.Text = @"Collection";
                lblTsDelivery.Text = @"Delivery";
                lblTsShop.Text = @"Shop";
                lblTsFastFood.Text = @"Fast Food";
                lblTsTotalOrder.Text = @"Total Order";
                lblTsTotalCol.Text = @"Total Col";
                lblTsTotalDel.Text = @"Total Del";
                lblTsTotalShop.Text = @"Total Shop";
                lblTsTotalFF.Text = @"Total FF";
                lblTsTotalDc.Text = @"Total D/C";
                lblTsDcCash.Text = @"D/C(Cash)";
                lblTsDcOther.Text = @"D/C(Other)";

                lblEsTotalEatIn.Text = @"Total Eat In";
                lblEsSc.Text = @"S/C";
                lblEsTotalOrder.Text = @"Total Order";

                lblStTotalTakings.Text = @"Total Takings";
                lblStTotalOrder.Text = @"Total Order";
                lblStTotalVat.Text = @"Total VAT";

                gbCurrentTime.Text = @"Current Time";
                gbCurrentDate.Text = @"Current Date";

                lblPtOrder1.Text = @"Order";
                lblPtTotal1.Text = @"Total";
                lblPtTips1.Text = @"Tips";

                lblPtOrder2.Text = @"Order";
                lblPtTotal2.Text = @"Total";
                lblPtTips2.Text = @"Tips";

                lblPtOrder3.Text = @"Order";
                lblPtTotal3.Text = @"Total";
                lblPtTips3.Text = @"Tips";

                lblPtOrder4.Text = @"Order";
                lblPtTotal4.Text = @"Total";
                lblPtTips4.Text = @"Tips";

                lblPtOrder5.Text = @"Order";
                lblPtTotal5.Text = @"Total";
                lblPtTips5.Text = @"Tips";

                btnLanguage.Text = @"LANGUAGE";
                btnExit.Text = @"Exit";

                #endregion
            }
            else
            {
                #region 汉语
                lblTsTotalTA.Text = @"外卖总数";
                lblTsCollection.Text = @"拿餐";
                lblTsDelivery.Text = @"送餐";
                lblTsShop.Text = @"现场";
                lblTsFastFood.Text = @"快餐";
                lblTsTotalOrder.Text = @"单总数";
                lblTsTotalCol.Text = @"拿餐总数";
                lblTsTotalDel.Text = @"送餐总数";
                lblTsTotalShop.Text = @"现场总数";
                lblTsTotalFF.Text = @"快餐总数";
                lblTsTotalDc.Text = @"送餐费总数";
                lblTsDcCash.Text = @"送餐费现金";
                lblTsDcOther.Text = @"送餐费其他";

                lblEsTotalEatIn.Text = @"堂吃总数";
                lblEsSc.Text = @"服务费";
                lblEsTotalOrder.Text = @"点单总数";

                lblStTotalTakings.Text = @"全部总数";
                lblStTotalOrder.Text = @"点单总数";
                lblStTotalVat.Text = @"VAT总数";

                gbCurrentTime.Text = @"当前时间";
                gbCurrentDate.Text = @"当前日期";

                lblPtOrder1.Text = @"单";
                lblPtTotal1.Text = @"总数";
                lblPtTips1.Text = @"";

                lblPtOrder2.Text = @"单";
                lblPtTotal2.Text = @"总数";
                lblPtTips2.Text = @"小费";

                lblPtOrder3.Text = @"单";
                lblPtTotal3.Text = @"总数";
                lblPtTips3.Text = @"小费";

                lblPtOrder4.Text = @"单";
                lblPtTotal4.Text = @"总数";
                lblPtTips4.Text = @"小费";

                lblPtOrder5.Text = @"单";
                lblPtTotal5.Text = @"总数";
                lblPtTips5.Text = @"小费";

                btnLanguage.Text = @"语言";
                btnExit.Text = @"退出";

                #endregion
            }

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
                            gridStaff = user.UsrName,
                            gridCustID = check.CustomerID,
                            gridDiscountPer = check.PayPerDiscount,
                            gridDisount = check.PayDiscount,
                            gridSubTotal = check.MenuAmount,
                            gridBusDate = check.BusDate,
                            gridSurcharge = check.PaySurcharge
                        };

            if (lstDb.Any())
            {
                dTsCollection = lstDb.ToList().Any(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_COLLECTION) && s.gridBusDate.Equals(busDate))
                              ? lstDb.ToList().Where(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_COLLECTION) && s.gridBusDate.Equals(busDate)).Sum(s => Convert.ToDecimal(s.gridTotal))
                              : 0.00m;
                txtTsCollection.Text = dTsCollection.ToString("0.00");

                dTsDelivery = lstDb.ToList().Any(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_DELIVERY) && s.gridBusDate.Equals(busDate))
                            ? lstDb.ToList().Where(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_DELIVERY) && s.gridBusDate.Equals(busDate)).Sum(s => Convert.ToDecimal(s.gridTotal))
                            : 0.00m;
                txtTsDelivery.Text = dTsDelivery.ToString("0.00");

                dTsShop = lstDb.ToList().Any(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_SHOP) && s.gridBusDate.Equals(busDate))
                        ? lstDb.ToList().Where(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_SHOP) && s.gridBusDate.Equals(busDate)).Sum(s => Convert.ToDecimal(s.gridTotal))
                        : 0.00m;
                txtTsShop.Text = dTsShop.ToString("0.00");

                dTsFastFood = lstDb.ToList().Any(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_FAST_FOOD) && s.gridBusDate.Equals(busDate))
                            ? lstDb.ToList().Where(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_FAST_FOOD) && s.gridBusDate.Equals(busDate)).Sum(s => Convert.ToDecimal(s.gridTotal))
                            : 0.00m;
                txtTsFastFood.Text = dTsFastFood.ToString("0.00");
                
                dTsTotalTA = dTsCollection + dTsDelivery + dTsShop + dTsFastFood;
                txtTsTotalTA.Text = dTsTotalTA.ToString("0.00");

                //dTsTotalOrder = lstDb.Count(s => s.gridBusDate.Equals(busDate));
                dTsTotalOrder = lstDb.Count();
                txtTsTotalOrder.Text = dTsTotalOrder.ToString("0.00");

                dTsTotalCollection = lstDb.ToList().Any(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_COLLECTION))
                              ? lstDb.ToList().Where(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_COLLECTION)).Sum(s => Convert.ToDecimal(s.gridTotal))
                              : 0.00m;
                txtTsTotalCol.Text = dTsTotalCollection.ToString("0.00");

                dTsTotalDelivery = lstDb.ToList().Any(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_DELIVERY))
                            ? lstDb.ToList().Where(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_DELIVERY)).Sum(s => Convert.ToDecimal(s.gridTotal))
                            : 0.00m;
                txtTsTotalDel.Text = dTsTotalDelivery.ToString("0.00");

                dTsTotalShop = lstDb.ToList().Any(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_SHOP))
                        ? lstDb.ToList().Where(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_SHOP)).Sum(s => Convert.ToDecimal(s.gridTotal))
                        : 0.00m;
                txtTsTotalShop.Text = dTsTotalShop.ToString("0.00");

                dTsTotalFastFood = lstDb.ToList().Any(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_FAST_FOOD))
                            ? lstDb.ToList().Where(s => s.gridOrderType.Equals(PubComm.ORDER_TYPE_FAST_FOOD)).Sum(s => Convert.ToDecimal(s.gridTotal))
                            : 0.00m;
                txtTsTotalFF.Text = dTsTotalFastFood.ToString("0.00");

                dTsTotalDc = lstDb.ToList().Sum(s => Convert.ToDecimal(s.gridDisount));
                txtTsTotalDc.Text = dTsTotalDc.ToString("0.00");
            }
            else
            {
                dTsTotalTA = 0.00m;
                txtTsTotalTA.Text = @"0.00";

                dTsCollection = 0.00m;
                txtTsCollection.Text = @"0.00";

                dTsDelivery = 0.00m;
                txtTsDelivery.Text = @"0.00";

                dTsShop = 0.00m;
                txtTsShop.Text = @"0.00";

                dTsFastFood = 0.00m;
                txtTsFastFood.Text = @"0.00";

                dTsTotalOrder = 0.00m;
                txtTsTotalOrder.Text = @"0.00";

                dTsTotalCollection = 0.00m;
                txtTsTotalCol.Text = @"0.00";

                dTsTotalDelivery = 0.00m;
                txtTsTotalDel.Text = @"0.00";

                dTsTotalShop = 0.00m;
                txtTsTotalShop.Text = @"0.00";

                dTsTotalFastFood = 0.00m;
                txtTsTotalFF.Text = @"0.00";

                dTsTotalDc = 0.00m;
                txtTsTotalDc.Text = @"0.00";

                dTsTotalDcCash = 0.00m;
                txtTsTotalDc.Text = @"0.00";

                dTsTotalDcOther = 0.00m;
                txtTsDcOther.Text = @"0.00";

                dEsTotalEatIn = 0.00m;
                txtEsTotalEatIn.Text = @"0.00";

                dEsSc = 0.00m;
                txtEsSc.Text = @"0.00";

                dEsTotalOrder = 0.00m;
                txtEsTotalOrder.Text = @"0";

                dStTotalTakings = 0.00m;
                txtStTotalTakings.Text = @"0.00";

                dStTotalOrder = 0.00m;
                txtStTotalOrder.Text =@"0.00";

                dStTotalVat = 0.00m;
                txtStTotalVat.Text = @"0.00";
            }
        }
        #endregion

        private string GetAllPayType(string s1, string s2)
        {
            return Convert.ToDecimal(s1) > 0.00m ? s2 : "";
        }

        private void tTimer_Tick(object sender, EventArgs e)
        {
            txtCurrentTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            deDay.Text = (Convert.ToDateTime(deDay.Text)).AddDays(-1).ToShortDateString();
            GetBindData(deDay.Text);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            deDay.Text = (Convert.ToDateTime(deDay.Text)).AddDays(1).ToShortDateString();
            GetBindData(deDay.Text);
        }
    }
}