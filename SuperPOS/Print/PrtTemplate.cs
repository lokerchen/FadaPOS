using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.Print
{
    public class PrtTemplate
    {
        public static void PrtTa(PrtTemplataTa prtTemplataTa, List<TaOrderItemInfo> lsTaOrderItemInfos, int prtType)
        {
            int iFontSize = 2;
            //int iLang = 2;

            new SystemData().GetTaPrtSetupGeneral();
            if (CommonData.TaPrtSetupGeneral.Any())
            {
                TaPrtSetupGeneralInfo taPrtSetupGeneralInfo = CommonData.TaPrtSetupGeneral.FirstOrDefault();
                prtTemplataTa.Msg1 = taPrtSetupGeneralInfo.Msg1;
                prtTemplataTa.Msg2 = taPrtSetupGeneralInfo.Msg2;
                prtTemplataTa.Msg3 = taPrtSetupGeneralInfo.Msg3;
                prtTemplataTa.Msg4 = taPrtSetupGeneralInfo.Msg4;
                prtTemplataTa.Msg5 = taPrtSetupGeneralInfo.Msg5;
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
                prtTemplataTa.MsgAtBotton = taPrtSetupGeneralSet1Info.PrtMsgAtBottom;
            }

            try
            {
                if (prtType == PrtStatic.PRT_TEMPLATE_TA_ALL_TYPE)
                {
                    List<string> lst = new List<string>();
                    lst = ReplacePrtKeys(prtTemplataTa, lsTaOrderItemInfos, fFontSize, strPrtLang, PrtStatic.PRT_TEMPLATE_TA_KITCHEN_TYPE);
                    Print(lst, fFontSize, strPrinterName);
                    lst = ReplacePrtKeys(prtTemplataTa, lsTaOrderItemInfos, fFontSize, strPrtLang, PrtStatic.PRT_TEMPLATE_TA_BILL_TYPE);
                    Print(lst, fFontSize, strPrinterName);
                }
                else if (prtType == PrtStatic.PRT_TEMPLATE_TA_ALL_AND_RECEIPT_TYPE)
                {
                    List<string> lst = new List<string>();
                    lst = ReplacePrtKeys(prtTemplataTa, lsTaOrderItemInfos, fFontSize, strPrtLang, PrtStatic.PRT_TEMPLATE_TA_KITCHEN_TYPE);
                    Print(lst, fFontSize, strPrinterName);
                    lst = ReplacePrtKeys(prtTemplataTa, lsTaOrderItemInfos, fFontSize, strPrtLang, PrtStatic.PRT_TEMPLATE_TA_BILL_TYPE);
                    Print(lst, fFontSize, strPrinterName);
                    lst = ReplacePrtKeys(prtTemplataTa, lsTaOrderItemInfos, fFontSize, strPrtLang, PrtStatic.PRT_TEMPLATE_TA_RECEIPT_TYPE);
                    Print(lst, fFontSize, strPrinterName);
                }
                else if (prtType == PrtStatic.PRT_TEMPLATE_TA_RECEIPT_TYPE) //增加Recipt打印
                {
                    List<string> lst = new List<string>();
                    lst = ReplacePrtKeys(prtTemplataTa, lsTaOrderItemInfos, fFontSize, strPrtLang, PrtStatic.PRT_TEMPLATE_TA_RECEIPT_TYPE);
                    Print(lst, fFontSize, strPrinterName);
                }
                else
                {
                    List<string> lst = new List<string>();
                    lst = ReplacePrtKeys(prtTemplataTa, lsTaOrderItemInfos, fFontSize, strPrtLang, prtType);
                    Print(lst, fFontSize, strPrinterName);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
            }
        }

        #region 打印主体方法
        /// <summary>
        /// 打印主体方法
        /// </summary>
        /// <param name="lstStr">打印内容</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="strPrinterName">打印机名称</param>
        public static void Print(List<string> lstStr, float fontSize, string strPrinterName)
        {
            PrintDocument printDocument = new PrintDocument();

            //若没有指定打印机，则使用默认打印机
            if (!string.IsNullOrEmpty(strPrinterName))
                printDocument.PrinterSettings.PrinterName = strPrinterName;

            printDocument.PrintPage += (sender, e) =>
            {
                int fontheight = 0;
                foreach (var item in lstStr)
                {
                    //e.Graphics.DrawString(item, new Font(SystemFonts.DefaultFont.Name, fontSize), Brushes.Black, new Point(0, fontheight));
                    //e.Graphics.DrawString(item, new Font(@"SimSun", fontSize), Brushes.Black, new Point(0, fontheight));
                    //e.Graphics.DrawString(item, new Font(@"Consolas", fontSize), Brushes.Black, new Point(0, fontheight));
                    //e.Graphics.DrawString(item, new Font(@"Calibri", fontSize), Brushes.Black, new Point(0, fontheight));
                    //e.Graphics.DrawString(item, new Font(@"Tahoma", fontSize), Brushes.Black, new Point(0, fontheight));
                    e.Graphics.DrawString(item, new Font(@"Courier New", fontSize), Brushes.Black, new Point(0, fontheight));
                    fontheight += new Font(@"Courier New", fontSize).Height;
                }
            };
            printDocument.Print();
        }
        #endregion

        #region 替换打印模板关键字
        /// <summary>
        /// 替换打印模板关键字
        /// </summary>
        /// <param name="prtTemplataTa">模板变量</param>
        /// <param name="lsTaOrderItemInfos">OrderItem</param>
        /// <param name="fFontSize">打印字体</param>
        /// <param name="strPrtLang">打印语言</param>
        /// <returns></returns>
        public static List<string> ReplacePrtKeys(PrtTemplataTa prtTemplataTa, List<TaOrderItemInfo> lsTaOrderItemInfos, float fFontSize, string strPrtLang, int prtType)
        {
            try
            {
                string filePath = "";

                if (prtType == PrtStatic.PRT_TEMPLATE_TA_KITCHEN_TYPE)
                {
                    filePath = PrtStatic.PRT_TEMPLATE_FILE_PATH + PrtStatic.PRT_TEMPLATE_TA_KITCHEN;
                }
                else if (prtType == PrtStatic.PRT_TEMPLATE_TA_RECEIPT_TYPE)
                {
                    filePath = PrtStatic.PRT_TEMPLATE_FILE_PATH + PrtStatic.PRT_TEMPLATE_TA_RECEIPT;
                }
                else if (prtType == PrtStatic.PRT_TEMPLATE_TA_BILL_TYPE)
                {
                    filePath = PrtStatic.PRT_TEMPLATE_FILE_PATH + PrtStatic.PRT_TEMPLATE_TA_BILL;
                }

                if (!File.Exists(filePath))
                {
                    LogHelper.Error("Can not find File:" + filePath);
                    return null;
                }

                StreamReader objReader = new StreamReader(filePath, Encoding.UTF8);

                string content = objReader.ReadToEnd();

                if (!string.IsNullOrEmpty(content))
                {
                    content = content.Replace("{RestaurantName}", prtTemplataTa.RestaurantName);
                    content = content.Replace("{StaffName}", prtTemplataTa.StaffName);
                    content = content.Replace("{Telephone}", prtTemplataTa.Telephone);
                    content = content.Replace("{Addr}", prtTemplataTa.Addr);
                    content = content.Replace("{VatNo}", prtTemplataTa.VatNo);
                    content = content.Replace("{Msg1}", prtTemplataTa.Msg1);
                    content = content.Replace("{Msg2}", prtTemplataTa.Msg2);
                    content = content.Replace("{Msg3}", prtTemplataTa.Msg3);
                    content = content.Replace("{Msg4}", prtTemplataTa.Msg4);
                    content = content.Replace("{Msg5}", prtTemplataTa.Msg5);
                    content = content.Replace("{OrderDate}", prtTemplataTa.OrderDate);
                    content = content.Replace("{OrderTime}", prtTemplataTa.OrderTime);
                    content = content.Replace("{OrderNo}", prtTemplataTa.OrderNo);
                    content = content.Replace("{MsgAtBotton}", prtTemplataTa.MsgAtBotton);
                    content = content.Replace("{ItemCount}", prtTemplataTa.ItemCount);
                    content = content.Replace("{SubTotal}", prtTemplataTa.SubTotal);
                    content = content.Replace("{TotalAmount}", prtTemplataTa.TotalAmount);
                    content = content.Replace("{PayType}", prtTemplataTa.PayType.Trim());
                    content = content.Replace("{Tendred}", prtTemplataTa.Tendred);
                    content = content.Replace("{Change}", prtTemplataTa.Change);
                    content = content.Replace("{Rete1}", prtTemplataTa.Rete1);
                    content = content.Replace("{VatA}", prtTemplataTa.VatA);
                    content = content.Replace("{Net1}", prtTemplataTa.Net1);
                    content = content.Replace("{Gross1}", prtTemplataTa.Gross1);
                    content = content.Replace("{Rate2}", prtTemplataTa.Rate2);
                    content = content.Replace("{Net2}", prtTemplataTa.Net2);
                    content = content.Replace("{VatB}", prtTemplataTa.VatB);
                    content = content.Replace("{Gross2}", prtTemplataTa.Gross2);
                    content = content.Replace("{ChkNum}", prtTemplataTa.ChkNum);
                    content = content.Replace("{Discount}", prtTemplataTa.Discount);

                    string strTitle = "";
                    string strContent = "";

                    if (prtType == PrtStatic.PRT_TEMPLATE_TA_KITCHEN_TYPE) //PRT_TEMPLATE_TA_KITCHEN
                    {
                        strTitle = "Qty" + PrtCommon.GetSpace(2)
                                    + "Name" + PrtCommon.GetSpace(PrtPrint.GetPrtNameLeng(fFontSize.ToString()) + 6 - 4 + 1)
                                    + "Price" + PrtCommon.GetSpace(2) + "\n";

                        foreach (var taOrderItemInfo in lsTaOrderItemInfos)
                        {
                            strContent += PrtPrint.GetTab(taOrderItemInfo.ItemCode, taOrderItemInfo.ItemQty,
                                taOrderItemInfo.ItemDishName, taOrderItemInfo.ItemTotalPrice, fFontSize.ToString(), prtType);
                            strContent += "\n";

                            if (strPrtLang.Equals(PrtStatic.PRT_GEN_SET1_LAN_Both))
                            {
                                strContent += PrtCommon.GetHanZiTab(taOrderItemInfo.ItemDishOtherName, fFontSize.ToString(), prtType);
                                strContent += "\n";
                            }
                        }
                    }
                    else //if (prtType == 2 || prtType == 3) //PRT_TEMPLATE_TA_RECEIPT
                    {
                        strTitle = "Code" + PrtCommon.GetSpace(2)
                                    + "Qty" + PrtCommon.GetSpace(2)
                                    + "Name" + PrtCommon.GetSpace(PrtPrint.GetPrtNameLeng(fFontSize.ToString()) - 4 + 1)
                                    + "Price" + PrtCommon.GetSpace(2) + "\n";

                        foreach (var taOrderItemInfo in lsTaOrderItemInfos)
                        {
                            strContent += PrtPrint.GetTab(taOrderItemInfo.ItemCode, taOrderItemInfo.ItemQty,
                                taOrderItemInfo.ItemDishName, taOrderItemInfo.ItemTotalPrice, fFontSize.ToString());
                            strContent += "\n";

                            if (strPrtLang.Equals(PrtStatic.PRT_GEN_SET1_LAN_Both))
                            {
                                strContent += PrtCommon.GetHanZiTab(taOrderItemInfo.ItemDishOtherName, fFontSize.ToString());
                                strContent += "\n";
                            }
                        }
                    }

                    //删除最后一个多余换行
                    strContent = strContent.Remove(strContent.LastIndexOf("\n"));

                    content = content.Replace("{OrderItem}", strTitle + strContent);

                    if (prtType == PrtStatic.PRT_TEMPLATE_TA_RECEIPT_TYPE)
                    {
                        strContent = "";

                        strContent = "Rate" + PrtCommon.GetSpace(7) + "Net" + PrtCommon.GetSpace(7) + "VAT-A" +
                                   PrtCommon.GetSpace(7) + "Gross" + "\n";
                        strContent += prtTemplataTa.Rete1 + PrtCommon.GetSpace(11 - prtTemplataTa.Rete1.Length)
                                     + prtTemplataTa.Net1 + PrtCommon.GetSpace(10 - prtTemplataTa.Net1.Length)
                                     + prtTemplataTa.VatA + PrtCommon.GetSpace(12 - prtTemplataTa.VatA.Length)
                                     + prtTemplataTa.Gross1 + PrtCommon.GetSpace(10 - prtTemplataTa.Gross1.Length) + "\n";

                        strContent += "Rate" + PrtCommon.GetSpace(7) + "Net" + PrtCommon.GetSpace(7) + "VAT-B" +
                                   PrtCommon.GetSpace(7) + "Gross" + "\n";
                        strContent += prtTemplataTa.Rate2 + PrtCommon.GetSpace(11 - prtTemplataTa.Rate2.Length)
                                     + prtTemplataTa.Net2 + PrtCommon.GetSpace(10 - prtTemplataTa.Net2.Length)
                                     + prtTemplataTa.VatB + PrtCommon.GetSpace(12 - prtTemplataTa.VatB.Length)
                                     + prtTemplataTa.Gross2 + PrtCommon.GetSpace(10 - prtTemplataTa.Gross2.Length) + "\n";

                        content = content.Replace("{VatInfo}", strContent);
                    }

                    List<string> lst = content.Split('\n').ToList();
                    return lst;
                }
                else return null;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
                return null;
            }
        }

        #endregion
    }
}
