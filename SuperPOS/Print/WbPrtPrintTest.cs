using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Office;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using HtmlAgilityPack;
using Microsoft.Win32;
using NHibernate.Linq.Functions;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SuperPOS.Print
{
    public class WbPrtPrintTest
    {
        private static System.Threading.AutoResetEvent obj = new System.Threading.AutoResetEvent(false);

        [DllImport("kernel32.dll", EntryPoint = "GetSystemDefaultLCID")]
        public static extern int GetSystemDefaultLCID();
        [DllImport("kernel32.dll", EntryPoint = "SetLocaleInfoA")]
        public static extern int SetLocaleInfo(int Locale, int LCType, string lpLCData);
        public const int LOCALE_SLONGDATE = 0x20;
        public const int LOCALE_SSHORTDATE = 0x1F;
        public const int LOCALE_STIME = 0x1003;

        //public static WebBrowser wb = new WebBrowser();

        private static int iOffset = 0;

        private static string ShopOrderPrinterName = "";
        private static string ShopOrderPrintNum = "";

        private static string ReceiptHeadingWord = "";

        private static bool isPrintFF = false;

        private static string strDefaultPrintName = "";
        private static string strPrintName = "";

        private static bool isPrintDriverCopy = false;
        private static string strDriverCopyFont = "12";
        private static string countPrintDriverCopy = "0";

        private static void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            e.Handled = true;
        }

        #region 替代HtmlText中模板的关键字
        /// <summary>
        /// 替代HtmlText中模板的关键字
        /// </summary>
        /// <param name="strHtmlText">HtmlText</param>
        /// <param name="wbPrtTemplataTa">模板关键字类</param>
        /// <returns></returns>
        public static string ReplaceHtmlPrtKeysShop(string strHtmlText, WbPrtTemplataTa wbPrtTemplataTa)
        {
            //string htmlText = GetHtmlFileInfo(strType);

            //if (string.IsNullOrEmpty(htmlText)) return "";

            strHtmlText = strHtmlText.Replace("{PrintAddress}", wbPrtTemplataTa.PrintAddress);
            strHtmlText = strHtmlText.Replace("{PrintTel}", wbPrtTemplataTa.PrintTel);
            strHtmlText = strHtmlText.Replace("{VATNo}", wbPrtTemplataTa.VATNo);
            strHtmlText = strHtmlText.Replace("{ShopTime}", wbPrtTemplataTa.ShopTime);
            strHtmlText = strHtmlText.Replace("{OrderDate}", wbPrtTemplataTa.OrderDate);
            strHtmlText = strHtmlText.Replace("{OrderTime}", wbPrtTemplataTa.OrderTime);
            strHtmlText = strHtmlText.Replace("{Staff}", wbPrtTemplataTa.Staff);
            strHtmlText = strHtmlText.Replace("{OrderNo}", wbPrtTemplataTa.OrderNo);
            //OrderItem单独处理
            strHtmlText = strHtmlText.Replace("{ItemCount}", wbPrtTemplataTa.ItemCount);
            strHtmlText = strHtmlText.Replace("{SubTotal}", wbPrtTemplataTa.SubTotal);
            strHtmlText = strHtmlText.Replace("{Total}", wbPrtTemplataTa.Total);
            strHtmlText = strHtmlText.Replace("{PayType}", wbPrtTemplataTa.PayType);
            strHtmlText = strHtmlText.Replace("{Msg1}", wbPrtTemplataTa.Msg1);
            strHtmlText = strHtmlText.Replace("{Msg2}", wbPrtTemplataTa.Msg2);
            strHtmlText = strHtmlText.Replace("{Msg3}", wbPrtTemplataTa.Msg3);
            strHtmlText = strHtmlText.Replace("{Msg4}", wbPrtTemplataTa.Msg4);
            strHtmlText = strHtmlText.Replace("{Msg5}", wbPrtTemplataTa.Msg5);

            //FastFood
            strHtmlText = strHtmlText.Replace("{RefNo}", wbPrtTemplataTa.RefNo);

            //Receipt
            strHtmlText = strHtmlText.Replace("{HeadingWord}", ReceiptHeadingWord);
            strHtmlText = strHtmlText.Replace("{Tendered}", wbPrtTemplataTa.Tendered);
            strHtmlText = strHtmlText.Replace("{Change}", wbPrtTemplataTa.Change);
            strHtmlText = strHtmlText.Replace("{Rate1}", wbPrtTemplataTa.Rate1);
            strHtmlText = strHtmlText.Replace("{Net1}", wbPrtTemplataTa.Net1);
            strHtmlText = strHtmlText.Replace("{VatA}", wbPrtTemplataTa.VatA);
            strHtmlText = strHtmlText.Replace("{Gross1}", wbPrtTemplataTa.Gross1);
            strHtmlText = strHtmlText.Replace("{Rate2}", wbPrtTemplataTa.Rate2);
            strHtmlText = strHtmlText.Replace("{Net2}", wbPrtTemplataTa.Net2);
            strHtmlText = strHtmlText.Replace("{VatB}", wbPrtTemplataTa.VatB);
            strHtmlText = strHtmlText.Replace("{Gross2}", wbPrtTemplataTa.Gross2);

            //Kitchen
            strHtmlText = strHtmlText.Replace("{CustName}", wbPrtTemplataTa.CustName);
            strHtmlText = strHtmlText.Replace("{CustPhone}", wbPrtTemplataTa.CustPhone);
            strHtmlText = strHtmlText.Replace("{CustDist}", wbPrtTemplataTa.CustDist);
            strHtmlText = strHtmlText.Replace("{CustMapRef}", wbPrtTemplataTa.CustMapRef);
            strHtmlText = strHtmlText.Replace("{CustHouseNo}", wbPrtTemplataTa.CustHouseNo);
            strHtmlText = strHtmlText.Replace("{CustAddr}", wbPrtTemplataTa.CustAddr);
            strHtmlText = strHtmlText.Replace("{CustPostCode}", wbPrtTemplataTa.CustPostCode);
            strHtmlText = strHtmlText.Replace("{OrderType}", wbPrtTemplataTa.OrderType);

            //Delivery Fee
            strHtmlText = strHtmlText.Replace("{DeliveryFee}", wbPrtTemplataTa.DeliveryFee);

            strHtmlText = strHtmlText.Replace("{Discount}", wbPrtTemplataTa.Discount);

            strHtmlText = strHtmlText.Replace("{Surcharge}", wbPrtTemplataTa.Surcharge);

            return strHtmlText;
        }
        #endregion

        

        public static void PrintHtml(string strType, List<TaOrderItemInfo> lsTaOrderItemInfos, WbPrtTemplataTa wbPrtTemplataTa, string strOrderType)
        {
            try
            {
                strDefaultPrintName = GetDefaultPrintName();

                if (string.IsNullOrEmpty(strDefaultPrintName))
                {
                    LogHelper.Info("WbPrtPrint.PrintHtml");
                    return;
                }

                if (strType.Equals(WbPrtStatic.PRT_CLASS_KITCHEN))
                {
                    PrintOnlyKitchen(strOrderType, lsTaOrderItemInfos, wbPrtTemplataTa);

                }
                
            }
            catch (Exception ex)
            {
                LogHelper.Error("WbPrtPrint.PrintHtml", ex);
                return;
            }
        }

        public static void SetPrintPreview(IPrintable panel)
        {
            try
            {
                PrintingSystem ps = new PrintingSystem();
                PrintableComponentLink link = new PrintableComponentLink();
                ps.Links.Add(link);
                link.Component = panel;
                link.PaperKind = ps.PageSettings.PaperKind;
                //link.PaperKind = PaperKind.Custom;
                //link.CustomPaperSize = new PaperSize("自定义纸张", (textList.Count * (int)(58 / 25.4 * 100)), PRT_BILL_SHUANGYU_ROW_COUNT * 20 + 475);
                link.CustomPaperSize = new Size(Convert.ToInt32(ps.PageSettings.UsablePageSizeInPixels.Width), Convert.ToInt32(ps.PageSettings.UsablePageSizeInPixels.Height));

                link.MinMargins = new Margins(0, 0, 0, 0);

                //ps.PageSettings.UsablePageSize = 
                LogHelper.Info("MinMargins:" + ps.PageSettings.MinMargins.ToString()
                                                                                      + "PaperKind:" + ps.PageSettings.PaperKind.ToString() 
                                                                                      + " Width:" + ps.PageSettings.UsablePageSizeInPixels.Width.ToString() 
                                                                                      + " Height:" + ps.PageSettings.UsablePageSizeInPixels.Height.ToString());
                //link.CustomPaperSize = new Size(80, 297);
                //link.Margins = new Margins(1, 1, 1, 1);
                
                //link.CreateMarginalHeaderArea += Link_CreateMarginalHeaderArea;
                //ps.PreviewFormEx.PrintControl.PrintingSystem.SetCommandVisibility(
                //    new[]
                //    {
                //        PrintingSystemCommand.Save,
                //        PrintingSystemCommand.Print,
                //        PrintingSystemCommand.ExportXls,
                //        PrintingSystemCommand.ClosePreview,
                //        PrintingSystemCommand.ShowFirstPage,
                //        PrintingSystemCommand.ShowLastPage,
                //    }, CommandVisibility.Toolbar);

                link.CreateDocument();
                link.PrintingSystem.ShowMarginsWarning = false;
                ps.PreviewFormEx.Show();
                //ps.Print();
            }
            catch (Exception ex)
            {
                LogHelper.Error("CommonDAL/SetPrintPreview", ex.InnerException);
            }
        }

        #region 打印Shop
        /// <summary>
        /// 打印Shop
        /// </summary>
        /// <param name="strType">打印类型</param>
        /// <param name="lsTaOrderItemInfos">Order Item</param>
        /// <param name="wbPrtTemplataTa">wbPrtTemplataTa</param>
        /// <returns></returns>
        public static string PrintBill(string strType, List<TaOrderItemInfo> lsTaOrderItemInfos, WbPrtTemplataTa wbPrtTemplataTa)
        {
            HtmlWeb hw = new HtmlWeb();

            HtmlDocument doc;
            
            doc = string.IsNullOrEmpty(wbPrtTemplataTa.RefNo) 
                  ? hw.Load(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + strType + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX) 
                  : hw.Load(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SHOP_FASTFOOD + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX);

            string htmlText = doc.Text;

            if (string.IsNullOrEmpty(htmlText)) return "";

            //替换Logo信息
            htmlText = htmlText.Replace("logo.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\logo.jpg");

            //替换特有标识
            if (strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_COLLECTION))
            {
                htmlText = htmlText.Replace("phone.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\phone.jpg");
            }
            else if (strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_DELIVERY))
            {
                htmlText = htmlText.Replace("phone.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\delivery.jpg");
            }

            iOffset = 0;

            //打印基础信息判断
            htmlText = PrtGeneralInfo(htmlText);
            //Counter 1
            htmlText = PrtCountSetting1Info(strType, htmlText);
            //LogHelper.Info("2" + htmlText);

            htmlText = ReplaceHtmlPrtKeysShop(htmlText, wbPrtTemplataTa);

            htmlText = GetOrderItemInfo(doc, htmlText, lsTaOrderItemInfos, false);
            //File.Exists(Environment.CurrentDirectory + @"\PrintTemplate\img\logo.jpg");
            return htmlText;
        }
        #endregion
        
        #region Display增加none
        /// <summary>
        /// Display增加none
        /// </summary>
        /// <param name="strDisplay">原Display字段</param>
        /// <returns></returns>
        private static string MakeupDisplay(string strDisplay)
        {
            return strDisplay + WbPrtStatic.PRT_PRINT_DISPLAY_NONE;
        }
        #endregion

        #region 基础打印信息
        /// <summary>
        /// 基础打印信息
        /// </summary>
        /// <param name="strHtmlText">原始Html文本信息</param>
        /// <returns></returns>
        private static string PrtGeneralInfo(string strHtmlText)
        {
            TaSysPrtSetGeneralInfo taSysPrtSetGeneralInfo = WbPrtCommon.GetTaSysPrtSetupGeneral();

            if (!taSysPrtSetGeneralInfo.IsPrtLogo.Equals("Y"))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_LOGO, MakeupDisplay(WbPrtStatic.PRT_PRINT_LOGO));
                iOffset += 4;
            }

            if (!taSysPrtSetGeneralInfo.IsPrtTel.Equals("Y"))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TEL, MakeupDisplay(WbPrtStatic.PRT_PRINT_TEL));
                iOffset += 4;
            }

            if (!taSysPrtSetGeneralInfo.IsPrtAddr.Equals("Y"))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ADDR, MakeupDisplay(WbPrtStatic.PRT_PRINT_ADDR));
                iOffset += 4;
            }

            if (!taSysPrtSetGeneralInfo.IsPrtStaff.Equals("Y"))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_STAFF, MakeupDisplay(WbPrtStatic.PRT_PRINT_STAFF));
                iOffset += 4;
            }
                
            return strHtmlText;
        }
        #endregion

        #region Kitchen打印信息
        /// <summary>
        /// Shop Kitchen打印信息
        /// </summary>
        /// <param name="strHtmlText">原始Html文本信息</param>
        /// <returns></returns>
        private static string PrtKitchenSettingInfo(string strHtmlText)
        {
            TaSysPrtSetKitchenInfo taSysPrtSetKitchenInfo = WbPrtCommon.GetTaSysPrtSetKitchen();

            if (taSysPrtSetKitchenInfo.PrintLang.Equals(PubComm.PRT_LANGUAGE_BOTH))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                  WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG + taSysPrtSetKitchenInfo.EngFontSize);

                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                  WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER + taSysPrtSetKitchenInfo.OtherFontSize);
                iOffset += 4;
            }
            else if (taSysPrtSetKitchenInfo.PrintLang.Equals(PubComm.PRT_LANGUAGE_ENG))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                  WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER.Replace(PubComm.PRT_PARAM_DISPALY, PubComm.PRT_PARAM_DISPALY_NONE));
                
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                  WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG + taSysPrtSetKitchenInfo.EngFontSize);
                iOffset += 6;//6=4+2
            }
            else if (taSysPrtSetKitchenInfo.PrintLang.Equals(PubComm.PRT_LANGUAGE_OTHER))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                  WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG.Replace(PubComm.PRT_PARAM_DISPALY, PubComm.PRT_PARAM_DISPALY_NONE));

                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                  WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER + taSysPrtSetKitchenInfo.OtherFontSize);
                iOffset += 6;
            }

            //if (taSysPrtSetKitchenInfo.IsPrintDeliveryAddr.Equals("Y"))
            //{
            //    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_NAME,
            //        WbPrtStatic.PRT_PRINT_TD_CUST_NAME + taSysPrtSetKitchenInfo.DeliveryAddr);
            //    iOffset += 2;

            //    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_PHONE,
            //        WbPrtStatic.PRT_PRINT_TD_CUST_PHONE + taSysPrtSetKitchenInfo.DeliveryAddr);
            //    iOffset += 2;

            //    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_DIST,
            //        WbPrtStatic.PRT_PRINT_TD_CUST_DIST + taSysPrtSetKitchenInfo.DeliveryAddr);
            //    iOffset += 2;

            //    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_MAP_REF,
            //        WbPrtStatic.PRT_PRINT_TD_CUST_MAP_REF + taSysPrtSetKitchenInfo.DeliveryAddr);
            //    iOffset += 2;

            //    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_ADDR,
            //        WbPrtStatic.PRT_PRINT_TD_CUST_ADDR + taSysPrtSetKitchenInfo.DeliveryAddr);
            //    iOffset += 2;

            //    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_POST_CODE,
            //        WbPrtStatic.PRT_PRINT_TD_CUST_POST_CODE + taSysPrtSetKitchenInfo.DeliveryAddr);
            //    iOffset += 2;
            //}
            //else
            //{
            //    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TBL_CUST_BASIC, MakeupDisplay(WbPrtStatic.PRT_PRINT_TBL_CUST_BASIC));
            //    iOffset += 4;

            //    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TBL_CUST_INFO, MakeupDisplay(WbPrtStatic.PRT_PRINT_TBL_CUST_INFO));
            //    iOffset += 4;
            //}

            if (!taSysPrtSetKitchenInfo.IsPrintDate.Equals("Y"))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_DATE, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_DATE));
                iOffset += 4;
            }

            if (!taSysPrtSetKitchenInfo.IsPrintTime.Equals("Y"))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_TIME, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_TIME));
                iOffset += 4;
            }

            if (!taSysPrtSetKitchenInfo.IsPrintPayType.Equals("Y"))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TBL_PAY_TYPE, MakeupDisplay(WbPrtStatic.PRT_PRINT_TBL_PAY_TYPE));
                iOffset += 4;
            }

            //if (taSysPrtSetKitchenInfo.IsPrintAsc.Equals("Y"))
            //{
            //    //待补充
            //}

            return strHtmlText;
        }
        #endregion

        #region 获取Counter 1 Setting配置信息
        /// <summary>
        /// 获取Counter 1 Setting配置信息
        /// </summary>
        /// <param name="strHtmlText">原始Html信息</param>
        /// <returns></returns>
        private static string PrtCountSetting1Info(string strType, string strHtmlText)
        {
            if (strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SHOP) || strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SHOP_FASTFOOD))
            {
                TaSysPrtSetCounterSetting1Info taSysPrtSetCounterSetting1Info = WbPrtCommon.GetTaTaSysPrtSetCounterSetting1();

                #region Shop
                ShopOrderPrinterName = taSysPrtSetCounterSetting1Info.SoLocalPrinter;
                ShopOrderPrintNum = taSysPrtSetCounterSetting1Info.SoNumOfCopy;

                if (taSysPrtSetCounterSetting1Info.SoPrtLang.Equals(PubComm.PRT_LANGUAGE_BOTH))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG + taSysPrtSetCounterSetting1Info.SoEngFontSize);

                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER + taSysPrtSetCounterSetting1Info.SoOtherFontSize);
                    iOffset += 4;
                }
                else if (taSysPrtSetCounterSetting1Info.SoPrtLang.Equals(PubComm.PRT_LANGUAGE_ENG))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER.Replace(PubComm.PRT_PARAM_DISPALY, PubComm.PRT_PARAM_DISPALY_NONE));

                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG + taSysPrtSetCounterSetting1Info.SoEngFontSize);
                    iOffset += 6;//6=4+2
                }
                else if (taSysPrtSetCounterSetting1Info.SoPrtLang.Equals(PubComm.PRT_LANGUAGE_OTHER))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG.Replace(PubComm.PRT_PARAM_DISPALY, PubComm.PRT_PARAM_DISPALY_NONE));

                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER + taSysPrtSetCounterSetting1Info.SoOtherFontSize);
                    iOffset += 6;//6=4+2
                }

                if (!taSysPrtSetCounterSetting1Info.IsSoPrtDate.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_DATE, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_DATE));
                    iOffset += 4;
                }

                if (!taSysPrtSetCounterSetting1Info.IsSoPrtTime.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_TIME, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_TIME));
                    iOffset += 4;
                }

                if (!taSysPrtSetCounterSetting1Info.IsSoPrtOrderNoSlip.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_SHOPTIME,
                        MakeupDisplay(WbPrtStatic.PRT_PRINT_SHOPTIME));
                    iOffset += 4;
                }
                else
                {
                    isPrintFF = true;
                }

                if (!taSysPrtSetCounterSetting1Info.IsSoPrtVATNo.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_VATNO, MakeupDisplay(WbPrtStatic.PRT_PRINT_VATNO));
                    iOffset += 4;
                }

                if (!taSysPrtSetCounterSetting1Info.IsSoOrderNo.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_NO, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_NO));
                    iOffset += 4;
                }
                //if (!taSysPrtSetCounterSetting1Info.IsSoRefNum.Equals("Y"))
                //    //To do something

                strPrintName = !taSysPrtSetCounterSetting1Info.SoLocalPrinter.Equals("Y") ? taSysPrtSetCounterSetting1Info.SoLocalPrinter : strDefaultPrintName;
                #endregion
            }
            else if (strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_COLLECTION))
            {
                TaSysPrtSetCounterSetting1Info taSysPrtSetCounterSetting1Info = WbPrtCommon.GetTaTaSysPrtSetCounterSetting1();

                #region Collection
                ShopOrderPrinterName = taSysPrtSetCounterSetting1Info.CoLocalPrinter;
                ShopOrderPrintNum = taSysPrtSetCounterSetting1Info.CoNumOfCopy;

                if (taSysPrtSetCounterSetting1Info.CoPrtLang.Equals(PubComm.PRT_LANGUAGE_BOTH))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG + taSysPrtSetCounterSetting1Info.CoEngFontSize);

                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER + taSysPrtSetCounterSetting1Info.CoOtherFontSize);
                    iOffset += 4;
                }
                else if (taSysPrtSetCounterSetting1Info.CoPrtLang.Equals(PubComm.PRT_LANGUAGE_ENG))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER.Replace(PubComm.PRT_PARAM_DISPALY, PubComm.PRT_PARAM_DISPALY_NONE));

                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG + taSysPrtSetCounterSetting1Info.CoEngFontSize);
                    iOffset += 6;//6=4+2
                }
                else if (taSysPrtSetCounterSetting1Info.CoPrtLang.Equals(PubComm.PRT_LANGUAGE_OTHER))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG.Replace(PubComm.PRT_PARAM_DISPALY, PubComm.PRT_PARAM_DISPALY_NONE));

                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER + taSysPrtSetCounterSetting1Info.CoOtherFontSize);
                    iOffset += 6;//6=4+2
                }

                if (!taSysPrtSetCounterSetting1Info.IsCoPrtDate.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_DATE, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_DATE));
                    iOffset += 4;
                }

                if (!taSysPrtSetCounterSetting1Info.IsCoPrtTime.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_TIME, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_TIME));
                    iOffset += 4;
                }

                if (!taSysPrtSetCounterSetting1Info.IsCoPrtOrderNoSlip.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_SHOPTIME, MakeupDisplay(WbPrtStatic.PRT_PRINT_SHOPTIME));
                    iOffset += 4;
                }
                else
                {
                    isPrintFF = true;
                }

                if (!taSysPrtSetCounterSetting1Info.IsCoPrtVATNo.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_VATNO, MakeupDisplay(WbPrtStatic.PRT_PRINT_VATNO));
                    iOffset += 4;
                }

                if (!taSysPrtSetCounterSetting1Info.IsCoOrderNo.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_NO, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_NO));
                    iOffset += 4;
                }
                //if (!taSysPrtSetCounterSetting1Info.IsSoRefNum.Equals("Y"))
                //    //To do something

                strPrintName = !taSysPrtSetCounterSetting1Info.CoLocalPrinter.Equals("Y") ? taSysPrtSetCounterSetting1Info.CoLocalPrinter : strDefaultPrintName;
                #endregion
            }
            else if (strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_DELIVERY))
            {
                TaSysPrtSetCounterSetting2Info taSysPrtSetCounterSetting2Info = WbPrtCommon.GetTaTaSysPrtSetCounterSetting2();

                #region Delivery
                ShopOrderPrinterName = taSysPrtSetCounterSetting2Info.SoLocalPriter;
                ShopOrderPrintNum = taSysPrtSetCounterSetting2Info.SoNumOfCopy;

                if (taSysPrtSetCounterSetting2Info.SoPrintLang.Equals(PubComm.PRT_LANGUAGE_BOTH))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG + taSysPrtSetCounterSetting2Info.SoEngFontSize);

                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER + taSysPrtSetCounterSetting2Info.SoOtherLangFont);
                    iOffset += 4;
                }
                else if (taSysPrtSetCounterSetting2Info.SoPrintLang.Equals(PubComm.PRT_LANGUAGE_ENG))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER.Replace(PubComm.PRT_PARAM_DISPALY, PubComm.PRT_PARAM_DISPALY_NONE));

                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG + taSysPrtSetCounterSetting2Info.CoEngFontSize);
                    iOffset += 6;//6=4+2
                }
                else if (taSysPrtSetCounterSetting2Info.SoPrintLang.Equals(PubComm.PRT_LANGUAGE_OTHER))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG.Replace(PubComm.PRT_PARAM_DISPALY, PubComm.PRT_PARAM_DISPALY_NONE));

                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                      WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER + taSysPrtSetCounterSetting2Info.SoOtherLangFont);
                    iOffset += 6;//6=4+2
                }

                if (!taSysPrtSetCounterSetting2Info.IsSoPrintDate.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_DATE, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_DATE));
                    iOffset += 4;
                }

                if (!taSysPrtSetCounterSetting2Info.IsSoPrintTime.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_TIME, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_TIME));
                    iOffset += 4;
                }
                
                if (!taSysPrtSetCounterSetting2Info.IsSoPrintVATNo.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_VATNO, MakeupDisplay(WbPrtStatic.PRT_PRINT_VATNO));
                    iOffset += 4;
                }

                if (!taSysPrtSetCounterSetting2Info.SoDeliveryAddrFont.Equals("Y"))
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_NO, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_NO));
                    iOffset += 4;
                }
                //if (!taSysPrtSetCounterSetting1Info.IsSoRefNum.Equals("Y"))
                //    //To do something

                //taSysPrtSetCounterSetting2Info.SoDriverPrintoutCopy
                //taSysPrtSetCounterSetting2Info.SoDeliveryAddrFont

                strPrintName = !taSysPrtSetCounterSetting2Info.SoLocalPriter.Equals("Y") ? taSysPrtSetCounterSetting2Info.SoLocalPriter : strDefaultPrintName;
                #endregion
            }

            return strHtmlText;
        }
        #endregion

        #region 获取Counter 2 Setting配置信息
        /// <summary>
        /// 获取Counter 2 Setting配置信息
        /// </summary>
        /// <param name="strHtmlText">原始Html信息</param>
        /// <returns></returns>
        private static string PrtCountSetting2Info(string strHtmlText)
        {
            TaSysPrtSetCounterSetting2Info taSysPrtSetCounterSetting2Info = WbPrtCommon.GetTaTaSysPrtSetCounterSetting2();

            ShopOrderPrinterName = taSysPrtSetCounterSetting2Info.CoLocalPriter;

            if (!string.IsNullOrEmpty(taSysPrtSetCounterSetting2Info.CoHeadWord))
                ReceiptHeadingWord = taSysPrtSetCounterSetting2Info.CoHeadWord;

            if (taSysPrtSetCounterSetting2Info.CoPrintLang.Equals(PubComm.PRT_LANGUAGE_BOTH))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                  WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG + taSysPrtSetCounterSetting2Info.CoEngFontSize);

                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                  WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER + taSysPrtSetCounterSetting2Info.CoOtherLangFont);
                iOffset += 4;
            }
            else if (taSysPrtSetCounterSetting2Info.CoPrintLang.Equals(PubComm.PRT_LANGUAGE_ENG))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                  WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER.Replace(PubComm.PRT_PARAM_DISPALY, PubComm.PRT_PARAM_DISPALY_NONE));

                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                  WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG + taSysPrtSetCounterSetting2Info.CoEngFontSize);
                iOffset += 6;//6=4+2
            }
            else if (taSysPrtSetCounterSetting2Info.CoPrintLang.Equals(PubComm.PRT_LANGUAGE_OTHER))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG,
                                                  WbPrtStatic.PRT_PRINT_FONT_SIZE_ENG.Replace(PubComm.PRT_PARAM_DISPALY, PubComm.PRT_PARAM_DISPALY_NONE));

                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER,
                                                  WbPrtStatic.PRT_PRINT_FONT_SIZE_OTHER + taSysPrtSetCounterSetting2Info.CoOtherLangFont);
                iOffset += 6;//6=4+2
            }

            if (!taSysPrtSetCounterSetting2Info.IsCoPrintDate.Equals("Y"))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_DATE, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_DATE));
                iOffset += 4;
            }

            if (!taSysPrtSetCounterSetting2Info.IsCoPrintTime.Equals("Y"))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_TIME, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_TIME));
                iOffset += 4;
            }

            if (!taSysPrtSetCounterSetting2Info.IsCoPrintVATNo.Equals("Y"))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_VATNO, MakeupDisplay(WbPrtStatic.PRT_PRINT_VATNO));
                iOffset += 4;
            }

            if (!taSysPrtSetCounterSetting2Info.IsCoPrintOrderNo.Equals("Y"))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_ORDER_NO, MakeupDisplay(WbPrtStatic.PRT_PRINT_ORDER_NO));
                iOffset += 4;
            }

            if (!taSysPrtSetCounterSetting2Info.IsCoPrintVATCalculation.Equals("Y"))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TBL_VAT, MakeupDisplay(WbPrtStatic.PRT_PRINT_TBL_VAT));
            }
            
            strPrintName = !taSysPrtSetCounterSetting2Info.CoLocalPriter.Equals("Y") ? taSysPrtSetCounterSetting2Info.CoLocalPriter : strDefaultPrintName;

            return strHtmlText;
        }
        #endregion

        #region DriverCopy打印信息
        /// <summary>
        /// DriverCopy打印信息
        /// </summary>
        /// <param name="strHtmlText">原始Html文本信息</param>
        /// <returns></returns>
        private static string PrtDriverCopySettingInfo(string strHtmlText)
        {
            TaSysPrtSetCounterSetting2Info taSysPrtSetCounterSetting2Info = WbPrtCommon.GetTaTaSysPrtSetCounterSetting2();

            if (!taSysPrtSetCounterSetting2Info.SoDriverPrintoutCopy.Equals("0"))
            {
                isPrintDriverCopy = true;
                strDriverCopyFont = taSysPrtSetCounterSetting2Info.SoDeliveryAddrFont;
                countPrintDriverCopy = taSysPrtSetCounterSetting2Info.SoDriverPrintoutCopy;

                if (strHtmlText.Length > 0)
                {
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_DIST, WbPrtStatic.PRT_PRINT_TD_CUST_DIST + strDriverCopyFont);
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_MAP_REF, WbPrtStatic.PRT_PRINT_TD_CUST_MAP_REF + strDriverCopyFont);
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_ADDR, WbPrtStatic.PRT_PRINT_TD_CUST_ADDR + strDriverCopyFont);
                    strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_POST_CODE, WbPrtStatic.PRT_PRINT_TD_CUST_POST_CODE + strDriverCopyFont);
                    iOffset += 8;
                }
            }

            return strHtmlText;
        }
        #endregion

        #region 替换HtmlText中的Order Item信息
        /// <summary>
        /// 替换HtmlText中的Order Item信息
        /// </summary>
        /// <param name="document">Html文档对象</param>
        /// <param name="strHtmlText">Html格式化文本内容</param>
        /// <param name="lsTaOrderItemInfos">Order Item信息</param>
        /// <param name="isKitchen">是否为Kitchen单</param>
        /// <returns></returns>
        public static string GetOrderItemInfo(HtmlDocument document, string strHtmlText, List<TaOrderItemInfo> lsTaOrderItemInfos, bool isKitchen)
        {
            HtmlNode node;

            node = document.DocumentNode.SelectSingleNode("//tr[@id='" + WbPrtStatic.PRT_PARAM_TBL_ORDER_TR_ORDER_ITEM + "']");

            string strTr = strHtmlText.Substring(strHtmlText.IndexOf(WbPrtStatic.PRT_PRINT_ORDER_ITEM), node.OuterLength + iOffset);
            string strTrTemp = strTr;
            //for (int i = 0; i < lsTaOrderItemInfos.Count; i++)
            //{
            //    strTr.Replace("{MiCode}", lsTaOrderItemInfos[i].ItemCode);
            //    strTr.Replace("{MiQty}", lsTaOrderItemInfos[i].ItemQty);
            //    strTr.Replace("{MiEngName}", lsTaOrderItemInfos[i].ItemDishName);
            //    strTr.Replace("{MiOtherName}", lsTaOrderItemInfos[i].ItemDishOtherName);
            //    strTr.Replace("{MiPrice}", lsTaOrderItemInfos[i].ItemTotalPrice);
            //}

            int i = 0;
            int j = 0;
            foreach (var oi in lsTaOrderItemInfos)
            {
                if (oi.ItemParent.Length > 1) //套餐
                {
                    if (oi.ItemType.Equals(PubComm.MENU_ITEM_SUB_CHILD)) //套餐子菜品
                    {
                        var lstSm = CommonData.TaMenuItemSubMenu.Where(s => s.SmMiID == lsTaOrderItemInfos.FirstOrDefault(t => t.ItemID.Equals(oi.ItemParent)).MenuItemID);
                        if (lstSm.Any())
                        {
                            if (lstSm.FirstOrDefault().IsShowContentOnPrtOut.Equals("Y"))
                            {
                                strTr = strTr.Replace("{MiCode}", @" ");
                                strTr = strTr.Replace("{MiQty}", @" ");
                                strTr = strTr.Replace("{MiEngName}", oi.ItemDishName);
                                strTr = strTr.Replace("{MiOtherName}", oi.ItemDishOtherName);
                                strTr = strTr.Replace("{MiPrice}", @" ");
                            }
                            else
                            {
                                j++;
                                continue;
                            }
                        }
                        else
                        {
                            j++;
                            continue;
                        }
                    }
                    else if (oi.ItemType.Equals(PubComm.MENU_ITEM_CHILD)) //正常Other Choice
                    {
                        var lstOh = CommonData.TaMenuItemOtherChoice.Where(s => s.ID == oi.MenuItemID);
                        if (lstOh.Any())
                        {
                            TaMenuItemOtherChoiceInfo taMenuItemOtherChoiceInfo = lstOh.FirstOrDefault();

                            strTr = strTr.Replace("{MiCode}", @" ");
                            strTr = strTr.Replace("{MiQty}", oi.ItemQty);
                            strTr = strTr.Replace("{MiEngName}", taMenuItemOtherChoiceInfo.MiEngName);
                            strTr = strTr.Replace("{MiOtherName}", oi.ItemDishName.Replace(taMenuItemOtherChoiceInfo.MiEngName, taMenuItemOtherChoiceInfo.MiOtherName));
                            strTr = strTr.Replace("{MiPrice}", oi.ItemTotalPrice);
                        }
                        else
                        {
                            j++;
                            continue;
                        }
                    }
                    else if (oi.ItemType.Equals(PubComm.MENU_ITEM_INGRED_MODE))
                    {
                        var lstMi = CommonData.TaMenuItem.Where(s => s.ID == oi.MenuItemID);
                        if (lstMi.Any())
                        {
                            TaMenuItemInfo mi = lstMi.FirstOrDefault();
                            strTr = strTr.Replace("{MiCode}", @" ");
                            strTr = strTr.Replace("{MiQty}", @" ");
                            strTr = strTr.Replace("{MiEngName}", oi.ItemDishName);
                            strTr = strTr.Replace("{MiOtherName}", oi.ItemDishOtherName);
                            strTr = strTr.Replace("{MiPrice}", @" ");
                        }
                        else
                        {
                            j++;
                            continue;
                        }
                    }
                    else if (oi.ItemType.Equals(PubComm.MENU_ITEM_APPEND))
                    {
                        var lstAppend = CommonData.TaExtraMenu.Where(s => s.ID.ToString().Equals(oi.ItemCode));

                        if (lstAppend.Any())
                        {
                            TaExtraMenuInfo taExtraMenuInfo = lstAppend.FirstOrDefault();

                            strTr = strTr.Replace("{MiCode}", @" ");
                            strTr = strTr.Replace("{MiQty}", oi.ItemQty);
                            strTr = strTr.Replace("{MiEngName}", oi.ItemDishName);
                            strTr = strTr.Replace("{MiOtherName}", oi.ItemDishName.Replace(taExtraMenuInfo.eMenuEngName, taExtraMenuInfo.eMenuOtherName));
                            strTr = strTr.Replace("{MiPrice}", oi.ItemTotalPrice);
                        }
                        else
                        {
                            j++;
                            continue;
                        }
                    }
                }
                else //非套餐
                {
                    strTr = strTr.Replace("{MiCode}", oi.ItemCode);
                    strTr = strTr.Replace("{MiQty}", oi.ItemQty);
                    strTr = strTr.Replace("{MiEngName}", oi.ItemDishName);
                    strTr = strTr.Replace("{MiOtherName}", oi.ItemDishOtherName);
                    strTr = strTr.Replace("{MiPrice}", oi.ItemTotalPrice);
                }
                i++;

                if (i < (lsTaOrderItemInfos.Count - j)) strTr += strTrTemp;
            }

            if (j > 0) strTr = strTr.Replace(strTrTemp, "");

            return strHtmlText.Replace(strTrTemp, strTr);
        }
        #endregion


        #region 打印Fast Food
        #region 打印Fast Food
        /// <summary>
        /// 打印Shop
        /// </summary>
        /// <param name="strType">打印类型</param>
        /// <param name="lsTaOrderItemInfos">Order Item</param>
        /// <param name="wbPrtTemplataTa">wbPrtTemplataTa</param>
        /// <returns>Html文本</returns>
        public static string PrintShopFastFood(string strType, List<TaOrderItemInfo> lsTaOrderItemInfos, WbPrtTemplataTa wbPrtTemplataTa)
        {
            HtmlWeb hw = new HtmlWeb();

            HtmlDocument doc = hw.Load(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + strType + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX);

            string htmlText = doc.Text;

            if (string.IsNullOrEmpty(htmlText)) return "";

            iOffset = 0;

            //替换Logo信息
            htmlText = htmlText.Replace("logo.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\logo.jpg");

            //打印基础信息判断
            htmlText = PrtGeneralInfo(htmlText);
            //Counter 1
            htmlText = PrtCountSetting1Info(strType, htmlText);

            htmlText = ReplaceHtmlPrtKeysShop(htmlText, wbPrtTemplataTa);

            htmlText = GetOrderItemInfo(doc, htmlText, lsTaOrderItemInfos, false);
            //File.Exists(Environment.CurrentDirectory + @"\PrintTemplate\img\logo.jpg");
            return htmlText;
        }
        #endregion

        #region 打印FF
        /// <summary>
        /// 打印FF
        /// </summary>
        /// <param name="strType">打印类型</param>
        /// <param name="wbPrtTemplataTa">wbPrtTemplataTa</param>
        /// <returns>Html文本</returns>
        public static string PrintShopFF(string strType, WbPrtTemplataTa wbPrtTemplataTa)
        {
            HtmlWeb hw = new HtmlWeb();

            HtmlDocument doc = hw.Load(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + strType + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX);

            iOffset = 0;

            string htmlText = doc.Text;

            if (string.IsNullOrEmpty(htmlText)) return "";
            
            htmlText = ReplaceHtmlPrtKeysShop(htmlText, wbPrtTemplataTa);

            return htmlText;
        }
        #endregion
        #endregion

        #region 打印Kitchen
        /// <summary>
        /// 打印Kitchen
        /// </summary>
        /// <param name="strType">打印类型</param>
        /// <param name="lsTaOrderItemInfos">Order Item</param>
        /// <param name="wbPrtTemplataTa">wbPrtTemplataTa</param>
        /// <returns></returns>
        public static string PrintKitchen(string strType, List<TaOrderItemInfo> lsTaOrderItemInfos, WbPrtTemplataTa wbPrtTemplataTa, string strOrderType)
        {
            HtmlWeb hw = new HtmlWeb();

            HtmlDocument doc = hw.Load(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + strType + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX);

            iOffset = 0;

            string htmlText = doc.Text;

            if (string.IsNullOrEmpty(htmlText)) return "";

            //替换Logo信息
            htmlText = htmlText.Replace("logo.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\logo.jpg");

            //替换特有标识
            if (strOrderType.Equals(PubComm.ORDER_TYPE_COLLECTION))
            {
                htmlText = htmlText.Replace("phone.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\phone.jpg");
            }
            else if (strOrderType.Equals(PubComm.ORDER_TYPE_DELIVERY))
            {
                htmlText = htmlText.Replace("phone.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\delivery.jpg");
            }

            //打印基础信息判断
            htmlText = PrtGeneralInfo(htmlText);

            htmlText = PrtKitchenSettingInfo(htmlText);
            
            htmlText = ReplaceHtmlPrtKeysShop(htmlText, wbPrtTemplataTa);

            htmlText = GetOrderItemInfo(doc, htmlText, lsTaOrderItemInfos, true);
            //File.Exists(Environment.CurrentDirectory + @"\PrintTemplate\img\logo.jpg");

            isPrintDriverCopy = false;
            PrtDriverCopySettingInfo("");

            return htmlText;
        }
        #endregion

        #region 打印Collection Kitchen
        /// <summary>
        /// 打印Kitchen
        /// </summary>
        /// <param name="strType">打印类型</param>
        /// <param name="lsTaOrderItemInfos">Order Item</param>
        /// <param name="wbPrtTemplataTa">wbPrtTemplataTa</param>
        /// <returns></returns>
        public static string PrintCollectionKitchen(string strType, List<TaOrderItemInfo> lsTaOrderItemInfos, WbPrtTemplataTa wbPrtTemplataTa)
        {
            HtmlWeb hw = new HtmlWeb();

            HtmlDocument doc = hw.Load(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + strType + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX);

            iOffset = 0;

            string htmlText = doc.Text;

            if (string.IsNullOrEmpty(htmlText)) return "";

            //替换Logo信息
            htmlText = htmlText.Replace("logo.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\logo.jpg");

            //htmlText = htmlText.Replace("delivery.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\delivery.jpg");

            //打印基础信息判断
            htmlText = PrtGeneralInfo(htmlText);

            htmlText = PrtKitchenSettingInfo(htmlText);

            htmlText = ReplaceHtmlPrtKeysShop(htmlText, wbPrtTemplataTa);

            htmlText = GetOrderItemInfo(doc, htmlText, lsTaOrderItemInfos, true);
            //File.Exists(Environment.CurrentDirectory + @"\PrintTemplate\img\logo.jpg");
            return htmlText;
        }
        #endregion

        #region 打印Receipte
        /// <summary>
        /// 打印Receipte
        /// </summary>
        /// <param name="strType">打印类型</param>
        /// <param name="lsTaOrderItemInfos">Order Item</param>
        /// <param name="wbPrtTemplataTa">wbPrtTemplataTa</param>
        /// <returns></returns>
        public static string PrintReceipt(string strType, List<TaOrderItemInfo> lsTaOrderItemInfos, WbPrtTemplataTa wbPrtTemplataTa)
        {
            HtmlWeb hw = new HtmlWeb();

            HtmlDocument doc = hw.Load(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + strType + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX);

            iOffset = 0;

            string htmlText = doc.Text;

            if (string.IsNullOrEmpty(htmlText)) return "";

            //替换Logo信息
            htmlText = htmlText.Replace("logo.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\logo.jpg");

            //打印基础信息判断
            htmlText = PrtGeneralInfo(htmlText);
            //Counter 2
            htmlText = PrtCountSetting2Info(htmlText);

            htmlText = ReplaceHtmlPrtKeysShop(htmlText, wbPrtTemplataTa);

            htmlText = GetOrderItemInfo(doc, htmlText, lsTaOrderItemInfos, false);
            //File.Exists(Environment.CurrentDirectory + @"\PrintTemplate\img\logo.jpg");
            return htmlText;
        }
        #endregion

        #region 打印Driver Copy

        public static string PrintOnlyDriverCopy(string strOrderType, WbPrtTemplataTa wbPrtTemplataTa)
        {
            HtmlWeb hw = new HtmlWeb();

            HtmlDocument doc = hw.Load(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_DRIVER_COPY + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX);

            iOffset = 0;

            string htmlText = doc.Text;

            if (string.IsNullOrEmpty(htmlText)) return "";

            //替换Logo信息
            htmlText = htmlText.Replace("logo.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\logo.jpg");

            //替换特有标识
            if (strOrderType.Equals(PubComm.ORDER_TYPE_COLLECTION))
            {
                htmlText = htmlText.Replace("phone.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\phone.jpg");
            }
            else if (strOrderType.Equals(PubComm.ORDER_TYPE_DELIVERY))
            {
                htmlText = htmlText.Replace("phone.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\delivery.jpg");
            }

            //打印基础信息判断
            htmlText = PrtGeneralInfo(htmlText);

            htmlText = PrtDriverCopySettingInfo(htmlText);

            htmlText = ReplaceHtmlPrtKeysShop(htmlText, wbPrtTemplataTa);

            //htmlText = GetOrderItemInfo(doc, htmlText, lsTaOrderItemInfos, true);
            //File.Exists(Environment.CurrentDirectory + @"\PrintTemplate\img\logo.jpg");
            return htmlText;
        }
        #endregion

        #region 获得默认打印机名

        private static string GetDefaultPrintName()
        {
            new SystemData().GetSysValue();
            var lstSv = CommonData.SysValue.Where(s => s.ValueID.Equals(PubComm.SYS_VALUE_DEFAULT_PRINT_NAME));
            
            return lstSv.Any() ? lstSv.FirstOrDefault().ValueResult : "";
        }
        #endregion


        #region 打印Kitchen
        /// <summary>
        /// 打印Kitchen
        /// </summary>
        /// <param name="strOrderType">订单类型</param>
        /// <param name="lsTaOrderItemInfos">菜品清单</param>
        /// <param name="wbPrtTemplataTa">模板参数</param>
        private static void PrintOnlyKitchen(string strOrderType, List<TaOrderItemInfo> lsTaOrderItemInfos, WbPrtTemplataTa wbPrtTemplataTa)
        {
            string strText = "";
            if (strOrderType.Equals(PubComm.ORDER_TYPE_SHOP))
            {
                strText = PrintKitchen(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_KITCHEN_SHOP, lsTaOrderItemInfos, wbPrtTemplataTa, strOrderType);
            }
           

            //PrintContent();
            PrtRichEditDocumentServer(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_KITCHEN_SHOP + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX,
                                     strText);
        }
        #endregion

        private static void PrtRichEditDocumentServer(string strFileName, string strText)
        {
            RichEditDocumentServer server = new RichEditDocumentServer();
            server.LoadDocument(strFileName, DocumentFormat.Html);
            server.BeginUpdate();
            server.Document.HtmlText = strText;

            //PrintableComponentLink link = new PrintableComponentLink();
            //PrintingSystem ps = new PrintingSystem();
            //ps.Links.Add(link);

            server.Document.Unit = DocumentUnit.Point;

            foreach (Section section in server.Document.Sections)
            {
                //section.Page.PaperKind = PaperKind.Custom;
                section.Page.Landscape = false;
                section.Page.Width = 200;
                section.Margins.Left = 1f;
                section.Margins.Right = 1f;
                section.Margins.Top = 0f;
                section.Margins.Bottom = 0f;
            }

            server.Document.DefaultParagraphProperties.Alignment = ParagraphAlignment.Center;

            PrintableComponentLink link = new PrintableComponentLink();
            PrintingSystem ps = new PrintingSystem();
            ps.Links.Add(link);
            link.Component = server;
            link.PrintingSystem.ShowMarginsWarning = false;
            link.PrintingSystem.ShowPrintStatusDialog = false;
            
            //link.PaperKind = PaperKind.Custom;
            //link.CustomPaperSize = new Size(Convert.ToInt32(ps.PageSettings.UsablePageSizeInPixels.Width), Convert.ToInt32(ps.PageSettings.UsablePageSizeInPixels.Height));
            //link.Margins = new Margins(0, 0, 0, 0);
            ////server.Print();
            //link.Print();
            //ps.PreviewFormEx.PrintControl.PrintingSystem.SetCommandVisibility(
            //    new[]
            //    {
            //        PrintingSystemCommand.Save,
            //        PrintingSystemCommand.Print,
            //        PrintingSystemCommand.ExportXls,
            //        PrintingSystemCommand.ClosePreview,
            //        PrintingSystemCommand.ShowFirstPage,
            //        PrintingSystemCommand.ShowLastPage,
            //    }, CommandVisibility.Toolbar);

            link.CreateDocument();

            PrinterSettings pSet = new PrinterSettings();
            pSet.Copies = 2;
            //pSet.PrinterName = strDefaultPrintName;
            //ps.PreviewFormEx.Show();
            //link.ShowPreview();
            server.Print(pSet);
            //ps.PreviewFormEx.Show();
            //link.ShowPreview();
            //link.Print();
            //ps.Print();
            LogHelper.Info("########");
        }
    }
}
