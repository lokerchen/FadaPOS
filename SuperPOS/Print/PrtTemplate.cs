using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.Print
{
    public class PrtTemplate
    {
        public static void PrtTaBill(PrtTemplataTa prtTemplataTa, List<TaOrderItemInfo> lsTaOrderItemInfos)
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
                if (File.Exists(PrtStatic.PRT_TEMPLATE_FILE_PATH + PrtStatic.PRT_TEMPLATE_TA))
                {
                    StreamReader objReader = new StreamReader(PrtStatic.PRT_TEMPLATE_FILE_PATH + PrtStatic.PRT_TEMPLATE_TA, Encoding.UTF8);

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
                        content = content.Replace("{Rete1}", prtTemplataTa.Rete1);
                        content = content.Replace("{Change}", prtTemplataTa.Change);
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

                        //小号字体
                        if (fFontSize == 1)
                        {
                            
                        }
                        //中号字体
                        else if (fFontSize <= Convert.ToSingle(PrtStatic.PRT_GEN_SET1_FONT_SIZE_14))
                        {
                            strTitle = "Code" + PrtCommon.GetSpace(2) 
                                            + "Qty" + PrtCommon.GetSpace(2) 
                                            + "Name" + PrtCommon.GetSpace(17) 
                                            + "Price" + PrtCommon.GetSpace(2) + "\n";

                            foreach (var taOrderItemInfo in lsTaOrderItemInfos)
                            {
                                strContent += PrtPrint.GetTab(taOrderItemInfo.ItemCode, taOrderItemInfo.ItemQty,
                                    taOrderItemInfo.ItemDishName, taOrderItemInfo.ItemTotalPrice, true);
                                strContent += "\n";

                                if (strPrtLang.Equals(PrtStatic.PRT_GEN_SET1_LAN_Both))
                                {
                                    strContent += PrtCommon.GetHanZiTab(taOrderItemInfo.ItemDishOtherName);
                                    strContent += "\n";
                                }
                            }
                        }
                        //大号字体
                        else //iFontSize == 3
                        {
                            
                        }
                        content = content.Replace("{OrderItem}", strTitle + strContent);
                        List<string> lst = content.Split('\n').ToList();
                        Print(lst, fFontSize, strPrinterName);
                    }
                }
                else
                {
                    LogHelper.Error("Can not find File:" + PrtStatic.PRT_TEMPLATE_FILE_PATH + PrtStatic.PRT_TEMPLATE_TA);
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
                    e.Graphics.DrawString(item, new Font(SystemFonts.DefaultFont.Name, fontSize), Brushes.Black, new Point(0, fontheight));
                    fontheight += new Font(SystemFonts.DefaultFont.Name, fontSize).Height;
                }
            };
            printDocument.Print();
        }
        #endregion
    }
}
