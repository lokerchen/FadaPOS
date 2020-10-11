﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.Win32;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SuperPOS.Print
{
    public class WbPrtPrint
    {
        private static System.Threading.AutoResetEvent obj = new System.Threading.AutoResetEvent(false);

        [DllImport("kernel32.dll", EntryPoint = "GetSystemDefaultLCID")]
        public static extern int GetSystemDefaultLCID();
        [DllImport("kernel32.dll", EntryPoint = "SetLocaleInfoA")]
        public static extern int SetLocaleInfo(int Locale, int LCType, string lpLCData);
        public const int LOCALE_SLONGDATE = 0x20;
        public const int LOCALE_SSHORTDATE = 0x1F;
        public const int LOCALE_STIME = 0x1003;

        public static WebBrowser wb = new WebBrowser();

        private static int iOffset = 0;

        private static string ShopOrderPrinterName = "";
        private static string ShopOrderPrintNum = "";

        private static string ReceiptHeadingWord = "";

        private static bool isPrintFF = false;

        private static string strDefaultPrintName = "";
        private static string strPrintName = "";

        #region WebBrowser基本打印内容
        /// <summary>
        /// WebBrowser基本打印内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (wb.ReadyState < WebBrowserReadyState.Complete) return;

            string keyName = @"Software\Microsoft\Internet Explorer\PageSetup\";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null)
                {
                    key.SetValue("footer", ""); //设置页脚为空
                    key.SetValue("header", ""); //设置页眉为空
                    //key.SetValue("Print_Background", true); //设置打印背景颜色
                    key.SetValue("margin_bottom", 0); //设置下页边距为0
                    key.SetValue("margin_left", 0); //设置左页边距为0
                    key.SetValue("margin_right", 0); //设置右页边距为0
                    key.SetValue("margin_top", 0); //设置上页边距为0

                    if (string.IsNullOrEmpty(ShopOrderPrintNum))
                    {
                        wb.Print();
                    }
                    else
                    {
                        //循环打印次数
                        for (int i = 0; i < Convert.ToInt32(ShopOrderPrintNum); i++)
                        {
                            wb.Print();
                        }
                    }
                }
            }
        }
        #endregion

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

            return strHtmlText;
        }
        #endregion

        #region 打印Html主体方法
        /// <summary>
        /// 打印Html主体方法
        /// </summary>
        /// <param name="webBrowser">WebBrowser容器</param>
        /// <param name="strType">打印类型</param>
        /// <param name="lsTaOrderItemInfos">OrderItem信息</param>
        /// <param name="wbPrtTemplataTa">打印模板类内容</param>
        /// <param name="isPrintFF">是否需要打印Fast Food</param>
        public static void PrintHtml(WebBrowser webBrowser, string strType, List<TaOrderItemInfo> lsTaOrderItemInfos, WbPrtTemplataTa wbPrtTemplataTa)
        {
            try
            {
                wb = webBrowser;

                strDefaultPrintName = GetDefaultPrintName();

                if (string.IsNullOrEmpty(strDefaultPrintName))
                {
                    LogHelper.Info("WbPrtPrint.PrintHtml");
                    return;
                }

                if (strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SHOP))
                {
                    wb.DocumentText = PrintShop(strType, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();
                }
                else if (strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SHOP_FASTFOOD))
                {
                    wb.DocumentText = PrintShopFastFood(strType, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();

                    if (isPrintFF)
                    {
                        wb.DocumentText = PrintShopFF(strType, wbPrtTemplataTa);
                        PrintContent();
                    }
                }
                else if (strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_KITCHEN))
                {
                    wb.DocumentText = PrintKitchen(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_KITCHEN, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();
                }
                else if (strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_RECEIPT))
                {
                    wb.DocumentText = PrintReceipt(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_RECEIPT, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();
                }
                else if (strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_ALL_SHOP))
                {
                    wb.DocumentText = PrintShop(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SHOP, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();

                    wb.DocumentText = PrintKitchen(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_KITCHEN, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();
                }
                else if (strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_ALL_SHOP_FASTFOOD))
                {
                    wb.DocumentText = PrintShopFastFood(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SHOP_FASTFOOD, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();

                    if (isPrintFF)
                    {
                        wb.DocumentText = PrintShopFF(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SHOP_FF, wbPrtTemplataTa);
                        PrintContent();
                    }

                    wb.DocumentText = PrintKitchen(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_KITCHEN, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();
                }
                else if (strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_ALL_SHOP_RECEIPT))
                {
                    wb.DocumentText = PrintShop(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SHOP, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();

                    wb.DocumentText = PrintKitchen(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_KITCHEN, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();

                    wb.DocumentText = PrintReceipt(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_RECEIPT, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();
                }
                else if (strType.Equals(WbPrtStatic.PRT_TEMPLATE_FILE_ALL_SHOP_RECEIPT_FASTFOOD))
                {
                    wb.DocumentText = PrintShopFastFood(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SHOP_FASTFOOD, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();

                    if (isPrintFF)
                    {
                        wb.DocumentText = PrintShopFF(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SHOP_FF, wbPrtTemplataTa);
                        PrintContent();
                    }

                    wb.DocumentText = PrintKitchen(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_KITCHEN, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();

                    wb.DocumentText = PrintReceipt(WbPrtStatic.PRT_TEMPLATE_FILE_NAME_RECEIPT, lsTaOrderItemInfos, wbPrtTemplataTa);
                    PrintContent();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("WbPrtPrint.PrintHtml", ex);
                return;
            }
            
            //PrintContent();

            //if (isPrintFF)
            //{
            //    wb.DocumentText = PrintShopFF(strType, wbPrtTemplataTa);
            //    PrintContent();
            //}
        }
        #endregion

        #region 打印Shop
        /// <summary>
        /// 打印Shop
        /// </summary>
        /// <param name="strType">打印类型</param>
        /// <param name="lsTaOrderItemInfos">Order Item</param>
        /// <param name="wbPrtTemplataTa">wbPrtTemplataTa</param>
        /// <returns></returns>
        public static string PrintShop(string strType, List<TaOrderItemInfo> lsTaOrderItemInfos, WbPrtTemplataTa wbPrtTemplataTa)
        {
            HtmlWeb hw = new HtmlWeb();

            HtmlDocument doc = hw.Load(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + strType + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX);

            string htmlText = doc.Text;

            if (string.IsNullOrEmpty(htmlText)) return "";

            //替换Logo信息
            htmlText = htmlText.Replace("logo.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\logo.jpg");

            iOffset = 0;

            //打印基础信息判断
            htmlText = PrtGeneralInfo(htmlText);
            //Counter 1
            htmlText = PrtCountSetting1Info(htmlText);
            //LogHelper.Info("2" + htmlText);

            htmlText = ReplaceHtmlPrtKeysShop(htmlText, wbPrtTemplataTa);

            htmlText = GetOrderItemInfo(doc, htmlText, lsTaOrderItemInfos);
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
        /// Kitchen打印信息
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

            if (taSysPrtSetKitchenInfo.IsPrintDeliveryAddr.Equals("Y"))
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_NAME,
                    WbPrtStatic.PRT_PRINT_TD_CUST_NAME + taSysPrtSetKitchenInfo.DeliveryAddr);
                iOffset += 2;

                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_PHONE,
                    WbPrtStatic.PRT_PRINT_TD_CUST_PHONE + taSysPrtSetKitchenInfo.DeliveryAddr);
                iOffset += 2;

                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_DIST,
                    WbPrtStatic.PRT_PRINT_TD_CUST_DIST + taSysPrtSetKitchenInfo.DeliveryAddr);
                iOffset += 2;

                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_MAP_REF,
                    WbPrtStatic.PRT_PRINT_TD_CUST_MAP_REF + taSysPrtSetKitchenInfo.DeliveryAddr);
                iOffset += 2;

                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_ADDR,
                    WbPrtStatic.PRT_PRINT_TD_CUST_ADDR + taSysPrtSetKitchenInfo.DeliveryAddr);
                iOffset += 2;

                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TD_CUST_POST_CODE,
                    WbPrtStatic.PRT_PRINT_TD_CUST_POST_CODE + taSysPrtSetKitchenInfo.DeliveryAddr);
                iOffset += 2;
            }
            else
            {
                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TBL_CUST_BASIC, MakeupDisplay(WbPrtStatic.PRT_PRINT_TBL_CUST_BASIC));
                iOffset += 4;

                strHtmlText = strHtmlText.Replace(WbPrtStatic.PRT_PRINT_TBL_CUST_INFO, MakeupDisplay(WbPrtStatic.PRT_PRINT_TBL_CUST_INFO));
                iOffset += 4;
            }

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
        private static string PrtCountSetting1Info(string strHtmlText)
        {
            TaSysPrtSetCounterSetting1Info taSysPrtSetCounterSetting1Info = WbPrtCommon.GetTaTaSysPrtSetCounterSetting1();

            ShopOrderPrinterName = taSysPrtSetCounterSetting1Info.CoLocalPrinter;
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

        #region 替换HtmlText中的Order Item信息
        /// <summary>
        /// 替换HtmlText中的Order Item信息
        /// </summary>
        /// <param name="document">Html文档对象</param>
        /// <param name="strHtmlText">Html格式化文本内容</param>
        /// <param name="lsTaOrderItemInfos">Order Item信息</param>
        /// <returns></returns>
        private static string GetOrderItemInfo(HtmlDocument document, string strHtmlText, List<TaOrderItemInfo> lsTaOrderItemInfos)
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
            foreach (var oi in lsTaOrderItemInfos)
            {
                strTr = strTr.Replace("{MiCode}", oi.ItemCode);
                strTr = strTr.Replace("{MiQty}", oi.ItemQty);
                strTr = strTr.Replace("{MiEngName}", oi.ItemDishName);
                strTr = strTr.Replace("{MiOtherName}", oi.ItemDishOtherName);
                strTr = strTr.Replace("{MiPrice}", oi.ItemTotalPrice);
                i++;

                if (i < lsTaOrderItemInfos.Count) strTr += strTrTemp;
            }

            return strHtmlText.Replace(strTrTemp, strTr);
        }
        #endregion

        #region WebBrowser基本打印方法
        /// <summary>
        /// WebBrowser基本打印方法
        /// </summary>
        private static void PrintContent()
        {
            //wb.Navigate("about:blank");
            //wb.Document.OpenNew(false);
            //wb.Document.Write(PrintShop(strType, lsTaOrderItemInfos, wbPrtTemplataTa));
            //wb.Refresh();

            //string st = PrintShop(strType, lsTaOrderItemInfos, wbPrtTemplataTa);
            //wb.DocumentText = st.Replace("logo.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\logo.jpg");
            //wb.Navigate("about:blank");
            //wb.Document.OpenNew(false);
            //wb.Document.Write(st);
            //wb.Refresh();

            //For 循环打印次数
            //for (int i = 0; i < Convert.ToInt32(ShopOrderPrintNum); i++)
            //{
            
            wb.DocumentCompleted += wb_DocumentCompleted;
            obj.Reset();
            //while (obj.WaitOne(10, false) == false)
            //{
            Application.DoEvents();
            obj.Set();
            wb.DocumentCompleted -= wb_DocumentCompleted;
            //}

            //打印完成后恢复默认打印机
            PrinterExterns.SetDefaultPrinter(strDefaultPrintName);
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
            LogHelper.Info("1" + htmlText);
            //Counter 1
            htmlText = PrtCountSetting1Info(htmlText);
            LogHelper.Info("2" + htmlText);

            htmlText = ReplaceHtmlPrtKeysShop(htmlText, wbPrtTemplataTa);
            LogHelper.Info("3" + htmlText);

            htmlText = GetOrderItemInfo(doc, htmlText, lsTaOrderItemInfos);
            LogHelper.Info("4" + htmlText);
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
        public static string PrintKitchen(string strType, List<TaOrderItemInfo> lsTaOrderItemInfos, WbPrtTemplataTa wbPrtTemplataTa)
        {
            HtmlWeb hw = new HtmlWeb();

            HtmlDocument doc = hw.Load(WbPrtStatic.PRT_TEMPLATE_FILE_PATH + strType + WbPrtStatic.PRT_TEMPLATE_FILE_NAME_SUFFIX);

            iOffset = 0;

            string htmlText = doc.Text;

            if (string.IsNullOrEmpty(htmlText)) return "";

            //替换Logo信息
            htmlText = htmlText.Replace("logo.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\logo.jpg");

            htmlText = htmlText.Replace("delivery.jpg", WbPrtStatic.PRT_TEMPLATE_FILE_PATH + @"img\delivery.jpg");

            //打印基础信息判断
            htmlText = PrtGeneralInfo(htmlText);

            htmlText = PrtKitchenSettingInfo(htmlText);
            
            htmlText = ReplaceHtmlPrtKeysShop(htmlText, wbPrtTemplataTa);

            htmlText = GetOrderItemInfo(doc, htmlText, lsTaOrderItemInfos);
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

            htmlText = GetOrderItemInfo(doc, htmlText, lsTaOrderItemInfos);
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
    }
}
