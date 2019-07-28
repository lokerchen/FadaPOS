using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SuperPOS.Common;

namespace SuperPOS.Print
{
    public class PrtCommon
    {
        #region 打印分隔符

        /// <summary>
        /// 打印分隔符
        /// </summary>
        /// <returns></returns>
        public static string GetSplit()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < PrtStatic.PRT_LINE_SIZE; i++)
            {
                sb.Append(PrtStatic.PRT_SPLIT_CHAR);
            }

            return sb.ToString();
        }

        #endregion

        #region 打印空格

        /// <summary>
        /// 打印空格
        /// </summary>
        /// <param name="i">空格数量</param>
        /// <returns></returns>
        public static StringBuilder GetSpace(int i)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < i; j++)
            {
                sb.Append(" ");
            }
            return sb;
        }

        #endregion

        #region 打印订单抬头


        #endregion

        #region 获得餐厅名称

        /// <summary>
        /// 获得餐厅名称
        /// </summary>
        /// <returns></returns>
        public static string GetRestName()
        {
            new SystemData().GetShopDetail();
            var firstOrDefault = CommonData.ShopDetail.FirstOrDefault();
            return firstOrDefault != null ? firstOrDefault.ShopName : "";
        }

        #endregion

        #region 获得餐厅地址

        /// <summary>
        /// 获得餐厅地址
        /// </summary>
        /// <returns></returns>
        public static string GetRestAddr()
        {
            new SystemData().GetShopDetail();
            var firstOrDefault = CommonData.ShopDetail.FirstOrDefault();
            return firstOrDefault != null ? firstOrDefault.ShopAddr : "";
        }

        #endregion

        #region 获得餐厅电话

        /// <summary>
        /// 获得餐厅电话
        /// </summary>
        /// <returns></returns>
        public static string GetRestTel()
        {
            new SystemData().GetShopDetail();
            var firstOrDefault = CommonData.ShopDetail.FirstOrDefault();
            //return firstOrDefault != null ? "Tel:" + firstOrDefault.ShopTelNo : "";
            return firstOrDefault != null ? firstOrDefault.ShopTelNo : "";
        }

        #endregion

        #region 获得餐厅VAT NO

        /// <summary>
        /// 获得餐厅VAT NO
        /// </summary>
        /// <returns></returns>
        public static string GetRestVATNo()
        {
            new SystemData().GetShopDetail();
            var firstOrDefault = CommonData.ShopDetail.FirstOrDefault();
            //return firstOrDefault != null ? "VAT No:" + firstOrDefault.ShopVATNo : "";
            return firstOrDefault != null ? firstOrDefault.ShopVATNo : "";
        }

        #endregion

        #region 获得打印时间和日期

        /// <summary>
        /// 打印时间和日期
        /// </summary>
        /// <returns></returns>
        public static string GetPrtDateTime()
        {
            //string s1 = "Date:" + DateTime.Now.ToShortDateString();
            //string s2 = "Time:" + DateTime.Now.ToShortTimeString();
            //return s1 + GetSpace(PrtStatic.PRT_LINE_SIZE - s1.Length - s2.Length) + s2;
            return DateTime.Now.ToShortDateString();
        }

        #endregion

        #region 获得账单显示时间

        /// <summary>
        /// 获得账单显示时间
        /// </summary>
        /// <returns></returns>
        public static string GetPrtTime()
        {
            return DateTime.Now.ToShortTimeString();
        }

        #endregion

        #region OrderItem格式

        public static StringBuilder GetTab(string sCode, string sQty, string sName, string sPrice)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(sCode + GetSpace(6 - sCode.Length) + sQty + GetSpace(5 - sQty.Length));
            if (sName.Length > 21)
            {
                sb.Append(sName.Substring(0, 20));
                sb.Append(GetSpace(1) + sPrice);
                sb.Append(Environment.NewLine);
                sb.Append(GetSpace(11) + sName.Substring(20, sName.Length - 21));
                sb.Append(Environment.NewLine);
            }
            else
            {
                sb.Append(sName + GetSpace(21 - sName.Length));
                sb.Append(sPrice);
            }

            return sb;
        }
        #endregion

        #region OrderItem格式

        public static StringBuilder GetTab(string sCode, string sQty, string sName)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(sCode + GetSpace(4 - sCode.Length) + sQty + GetSpace(3 - sQty.Length));
            if (sName.Length > 21)
            {
                sb.Append(sName.Substring(0, 20));
                sb.Append(Environment.NewLine);
                sb.Append(GetSpace(7) + sName.Substring(20, sName.Length - 21));
                sb.Append(Environment.NewLine);
            }
            else
            {
                sb.Append(sName + GetSpace(21 - sName.Length));
            }

            return sb;
        }
        #endregion

        public static StringBuilder GetHanZiTab(string sName)
        {
            StringBuilder sb = new StringBuilder();
            int s = (20 - GetHanNumFromString(sName)) / 2;
            sb.Append(GetSpace(11) + sName);
            return sb;
        }

        public static StringBuilder GetHanZiTab(string sName, string strFont)
        {
            //int ipNameLeng = PrtPrint.GetPrtNameLeng(strFont);
            StringBuilder sb = new StringBuilder();
            //int s = (ipNameLeng - 1 - GetHanNumFromString(sName)) / 2;
            // 10-18
            sb.Append(GetSpace(11) + sName);
            return sb;
        }

        public static StringBuilder GetHanZiTab(string sName, string strFont, int prtType)
        {
            StringBuilder sb = new StringBuilder();
            if (prtType == 1)
                sb.Append(GetSpace(6) + sName);
            else
                sb.Append(GetSpace(11) + sName);
            return sb;
        }

        public static StringBuilder GetHanZiTabKitchen(string sName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetSpace(7) + sName);
            return sb;
        }

        public static int GetHanNumFromString(string str)
        {
            int count = 0;
            Regex regex = new Regex(@"^[\u4E00-\u9FA5]{0,}$");
            for (int i = 0; i < str.Length; i++)
            {
                if (regex.IsMatch(str[i].ToString()))
                {
                    count++;
                }
            }
            return count;
        }

        public static StringBuilder GetItemTotal(string sItem, string sSubTotal)
        {
            StringBuilder sb = new StringBuilder();
            string s1 = "Items:(" + sItem + ")";
            string s2 = "Sub Total:" + sSubTotal;
            sb.Append(s1 + GetSpace(PrtStatic.PRT_LINE_SIZE - s1.Length - s2.Length - 1) + s2);

            return sb;
        }

        public static StringBuilder GetTotal(string sTotal)
        {
            StringBuilder sb = new StringBuilder();
            string s1 = "Total:" + sTotal;
            sb.Append(GetSpace((25 - s1.Length)) + s1);
            return sb;
        }

        public static StringBuilder GetPay(string sPay)
        {
            StringBuilder sb = new StringBuilder();
            string s1 = "Paid by " + sPay;
            sb.Append(GetSpace((27 - s1.Length) / 2) + s1);
            return sb;
        }

        public static StringBuilder GetText(string sText, string sTotal)
        {
            StringBuilder sb = new StringBuilder();
            string s1 = sText + sTotal;
            sb.Append(GetSpace((25 - s1.Length)) + s1);
            return sb;
        }

        public static StringBuilder GetText(string sText)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetSpace((27 - sText.Length) / 2) + sText);
            return sb;
        }
    }
}