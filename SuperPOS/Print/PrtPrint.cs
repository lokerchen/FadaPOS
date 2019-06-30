using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.Print
{
    public class PrtPrint
    {
        private static List<string> textList;       //打印内容行

        //BILL双语中的行数
        private static int PRT_BILL_SHUANGYU_ROW_COUNT;

        #region 根据内容进行分行
        /// <summary>
        /// 根据内容进行分行
        /// </summary>
        /// <param name="linelen">每行字数</param>
        /// <param name="text">原文字行（段落）文字</param>
        /// <returns></returns>
        private static List<string> GetArr(int linelen, string text)
        {
            var list = new List<string>();
            int listcount = text.Length % linelen == 0 ? text.Length / linelen : (text.Length / linelen) + 1;
            for (int j = 0; j < listcount; j++)
            {
                try
                {
                    list.Add(text.Substring(j * linelen, linelen));
                }
                catch (Exception)
                {
                    list.Add(text.Substring(j * linelen));
                }
            }
            return list;
        }
        #endregion

        #region 打印Bill-双语

        public static string GetPrtStrBillBilingual(List<TaOrderItemInfo> lstOI, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            string L = PrtCommon.GetSplit();
            string L1 = PrtCommon.GetRestName();
            string L2 = PrtCommon.GetRestAddr();
            string L3 = PrtCommon.GetRestTel();
            string L4 = PrtCommon.GetRestVATNo();
            string L5 = PrtCommon.GetPrtTime();
            string L6 = PrtCommon.GetPrtDateTime();
            string L7 = "Staff:" + (ht["Staff"]).ToString() + "   " + @"Order No:" + (ht["OrderNo"]).ToString();

            //餐厅名称
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE_20 - L1.Length) / 2) + L1);
            sb.Append(Environment.NewLine);

            //餐厅地址
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L2.Length) / 2) + L2);
            sb.Append(Environment.NewLine);

            //Tel
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L3.Length) / 2) + L3);
            sb.Append(Environment.NewLine);

            //VAT
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L4.Length) / 2) + L4);
            sb.Append(Environment.NewLine);

            //分隔行
            sb.Append(L);
            sb.Append(Environment.NewLine);

            //时间
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE_20 - L5.Length) / 2) + L5);
            sb.Append(Environment.NewLine);

            //分隔行
            sb.Append(L);
            sb.Append(Environment.NewLine);

            //sb.Append(PrtCommon.GetSpace(6) + L6);
            sb.Append(L6);
            sb.Append(Environment.NewLine);
            //sb.Append(PrtCommon.GetSpace(6) + L7);
            sb.Append(L7);
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);

            sb.Append("Code" + PrtCommon.GetSpace(2) + "Qty" + PrtCommon.GetSpace(2) + "Name" + PrtCommon.GetSpace(17) + "Price" + PrtCommon.GetSpace(2));
            sb.Append(Environment.NewLine);

            PRT_BILL_SHUANGYU_ROW_COUNT = lstOI.Count * 2;

            foreach (var taOrderItemInfo in lstOI)
            {
                //涉及到多行需要计算行数
                //sb.Append(PrtCommon.GetTab(taOrderItemInfo.ItemCode, taOrderItemInfo.ItemQty,
                //    taOrderItemInfo.ItemDishName, taOrderItemInfo.ItemTotalPrice));
                sb.Append(GetTab(taOrderItemInfo.ItemCode, taOrderItemInfo.ItemQty,
                    taOrderItemInfo.ItemDishName, taOrderItemInfo.ItemTotalPrice));
                sb.Append(Environment.NewLine);
                //var CNameList = CommonData.TaMenuItem.Where(s => s.MiDishCode.Equals(taOrderItemInfo.ItemCode));
                //if (CNameList.Any())
                //{
                //    sb.Append(PrtCommon.GetHanZiTab(CNameList.FirstOrDefault().MiOtherName));
                //    sb.Append(Environment.NewLine);
                //}
                sb.Append(PrtCommon.GetHanZiTab(taOrderItemInfo.ItemDishOtherName));
                sb.Append(Environment.NewLine);
            }

            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetItemTotal((ht["ItemQty"]).ToString(), (ht["SubTotal"]).ToString()));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetTotal((ht["Total"]).ToString()));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);

            sb.Append(PrtCommon.GetText("Tendered:", (ht["Tendered"]).ToString()));
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetText("Change:", (ht["Change"]).ToString()));
            sb.Append(Environment.NewLine);
            sb.Append(L);

            sb.Append(PrtCommon.GetPay((ht["PayType"]).ToString()));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtStatic.PRT_COMP_NAME);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetSpace(8) + PrtStatic.PRT_COMP_WEBSITE);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
        #endregion

        #region 打印Bill内容事件
        /// <summary>
        /// 打印Bill内容事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Prt_Content_BillBilingual(object sender, PrintPageEventArgs e)
        {
            var mark = 0;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            foreach (var item in textList)
            {
                //e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), fontSize), System.Drawing.Brushes.Black, 0, mark * lineSize);
                if (mark == 0)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), Brushes.Black, 0, mark * 20);
                }
                else if (mark == 1)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 10), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == 5)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == textList.Count - 4)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == textList.Count - 6)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == textList.Count - 7)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == textList.Count - 9)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                else
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 10), Brushes.Black, 0, (mark + 1) * 20);
                }

                mark++;
            }
        }
        #endregion

        #region 打印Bill主体打印事件
        public static void PrtBillBilingual(List<TaOrderItemInfo> lstOI, Hashtable ht)
        {
            if (string.IsNullOrWhiteSpace(GetPrtStrBillBilingual(lstOI, ht)))
            {
                return;
            }

            //原文字行或者段落内容
            var sourceTexts = GetPrtStrBillBilingual(lstOI, ht).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            //重新把文字进行分行树立
            textList = new List<string>();
            foreach (var item in sourceTexts)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    if (item.Length > PrtStatic.PRT_LINE_SIZE)
                    {
                        textList.AddRange(GetArr(PrtStatic.PRT_LINE_SIZE, item));
                    }
                    else
                    {
                        textList.Add(item);
                    }
                }
            }


            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(Prt_Content_BillBilingual);
            //纸张设置默认
            //PaperSize pageSize = new PaperSize("自定义纸张", fontSize * lineSize, (textList.Count * (int)(58 / 25.4 * 100)));
            //PaperSize pageSize = new PaperSize("自定义纸张", (textList.Count * (int)(58 / 25.4 * 100)), 455);
            PaperSize pageSize = new PaperSize("自定义纸张", (textList.Count * (int)(58 / 25.4 * 100)), PRT_BILL_SHUANGYU_ROW_COUNT * 20 + 475);
            pd.DefaultPageSettings.PaperSize = pageSize;
            //pd.PrinterSettings.PrinterName
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印失败." + ex.Message);
            }
        }
        #endregion


        #region 打印Bill - 纯英文，无汉字
        public string GetPrtStrBillNoChinese(List<TaOrderItemInfo> lstOI, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            string L = PrtCommon.GetSplit();
            string L1 = PrtCommon.GetRestName();
            string L2 = PrtCommon.GetRestAddr();
            string L3 = PrtCommon.GetRestTel();
            string L4 = PrtCommon.GetRestVATNo();
            string L5 = PrtCommon.GetPrtTime();
            string L6 = PrtCommon.GetPrtDateTime();
            string L7 = "Staff:" + (string)ht["Staff"] + "   " + @"Order No:" + (string)ht["OrderNo"];

            //餐厅名称
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE_20 - L1.Length) / 2) + L1);
            sb.Append(Environment.NewLine);

            //餐厅地址
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L2.Length) / 2) + L2);
            sb.Append(Environment.NewLine);

            //Tel
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L3.Length) / 2) + L3);
            sb.Append(Environment.NewLine);

            //VAT
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L4.Length) / 2) + L4);
            sb.Append(Environment.NewLine);

            //分隔行
            sb.Append(L);
            sb.Append(Environment.NewLine);

            //时间
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE_20 - L5.Length) / 2) + L5);
            sb.Append(Environment.NewLine);

            //分隔行
            sb.Append(L);
            sb.Append(Environment.NewLine);

            sb.Append(PrtCommon.GetSpace(6) + L6);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetSpace(6) + L7);
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);

            sb.Append("Code" + PrtCommon.GetSpace(2) + "Qty" + PrtCommon.GetSpace(2) + "Name" + PrtCommon.GetSpace(17) + "Price" + PrtCommon.GetSpace(2));
            sb.Append(Environment.NewLine);

            foreach (var taOrderItemInfo in lstOI)
            {
                sb.Append(PrtCommon.GetTab(taOrderItemInfo.ItemCode, taOrderItemInfo.ItemQty,
                    taOrderItemInfo.ItemDishName, taOrderItemInfo.ItemTotalPrice));
                sb.Append(Environment.NewLine);
            }

            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetItemTotal((string)ht["ItemQty"], (string)ht["SubTotal"]));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetTotal((string)ht["Total"]));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetPay((string)ht["PayType"]));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtStatic.PRT_COMP_NAME);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetSpace(8) + PrtStatic.PRT_COMP_WEBSITE);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
        #endregion

        #region 打印Bill内容事件 - 纯英文，无汉字
        /// <summary>
        /// 打印Bill内容事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Prt_Content_BillNoChinese(object sender, PrintPageEventArgs e)
        {
            var mark = 0;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            foreach (var item in textList)
            {
                if (mark == 0)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), System.Drawing.Brushes.Black, 0, mark * 20);
                }
                else if (mark == 1)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), System.Drawing.Brushes.Black, 0, mark * 20);
                }
                else if (mark == 5)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), System.Drawing.Brushes.Black, 0, mark * 20);
                }
                else if (mark == textList.Count - 4)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), System.Drawing.Brushes.Black, 0, mark * 20);
                }
                else if (mark == textList.Count - 6)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), System.Drawing.Brushes.Black, 0, mark * 20);
                }
                else
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), System.Drawing.Brushes.Black, 0, mark * 20);
                }

                mark++;
            }
        }
        #endregion

        #region 打印Bill主体打印事件
        public void PrtBillNoChinese(List<TaOrderItemInfo> lstOI, Hashtable ht)
        {
            if (string.IsNullOrWhiteSpace(GetPrtStrBillNoChinese(lstOI, ht)))
            {
                return;
            }

            //原文字行或者段落内容
            var sourceTexts = GetPrtStrBillNoChinese(lstOI, ht).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            //重新把文字进行分行树立
            textList = new List<string>();
            foreach (var item in sourceTexts)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    if (item.Length > PrtStatic.PRT_LINE_SIZE)
                    {
                        textList.AddRange(GetArr(PrtStatic.PRT_LINE_SIZE, item));
                    }
                    else
                    {
                        textList.Add(item);
                    }
                }
            }


            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(Prt_Content_BillNoChinese);
            //纸张设置默认
            PaperSize pageSize = new PaperSize("自定义纸张", (textList.Count * (int)(58 / 25.4 * 100)), 600);
            pd.DefaultPageSettings.PaperSize = pageSize;
            //pd.PrinterSettings.PrinterName
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印失败." + ex.Message);
            }
        }
        #endregion


        #region 打印Receipt
        public static string GetPrtStrReceipt(List<TaOrderItemInfo> lstOI, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            string L = PrtCommon.GetSplit();
            string L1 = PrtCommon.GetRestName();
            string L2 = PrtCommon.GetRestAddr();
            string L3 = PrtCommon.GetRestTel();
            string L4 = PrtCommon.GetRestVATNo();
            //string L5 = PrtCommon.GetPrtTime();
            string L6 = PrtCommon.GetPrtDateTime();
            string L7 = "Staff:" + (string)ht["Staff"];

            //餐厅名称
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE_20 - L1.Length) / 2) + L1);
            sb.Append(Environment.NewLine);

            //餐厅地址
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L2.Length) / 2) + L2);
            sb.Append(Environment.NewLine);

            //Tel
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L3.Length) / 2) + L3);
            sb.Append(Environment.NewLine);

            //VAT
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L4.Length) / 2) + L4);
            sb.Append(Environment.NewLine);

            //分隔行
            sb.Append(L);
            sb.Append(Environment.NewLine);

            ////时间
            //sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE_20 - L5.Length) / 2) + L5);
            //sb.Append(Environment.NewLine);

            ////分隔行
            //sb.Append(L);
            //sb.Append(Environment.NewLine);

            sb.Append(L6);
            sb.Append(Environment.NewLine);
            sb.Append(L7);
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);

            sb.Append("Code" + PrtCommon.GetSpace(2) + "Qty" + PrtCommon.GetSpace(2) + "Name" + PrtCommon.GetSpace(17) + "Price" + PrtCommon.GetSpace(2));
            sb.Append(Environment.NewLine);

            foreach (var taOrderItemInfo in lstOI)
            {
                sb.Append(PrtCommon.GetTab(taOrderItemInfo.ItemCode, taOrderItemInfo.ItemQty,
                    taOrderItemInfo.ItemDishName, taOrderItemInfo.ItemTotalPrice));
                sb.Append(Environment.NewLine);
            }

            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetItemTotal((ht["ItemQty"]).ToString(), (ht["SubTotal"]).ToString()));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetTotal((string)ht["Total"]));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetText("Tendered:", (string)ht["Tendered"]));
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetText("Change:", (string)ht["Change"]));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetPay((string)ht["PayType"]));
            sb.Append(Environment.NewLine);
            sb.Append(L);

            sb.Append(PrtCommon.GetSpace(15) + "VAT SUMMARY");
            sb.Append(Environment.NewLine);
            sb.Append("Rate" + PrtCommon.GetSpace(7) + "Net" + PrtCommon.GetSpace(7) + "VAT-A" + PrtCommon.GetSpace(7) + "Gross");
            sb.Append(Environment.NewLine);
            sb.Append((string)ht["Rate1"] + PrtCommon.GetSpace(11 - ((string)ht["Rate1"]).Length)
                       + (string)ht["Net1"] + PrtCommon.GetSpace(10 - ((string)ht["Net1"]).Length)
                       + (string)ht["VAT-A"] + PrtCommon.GetSpace(12 - ((string)ht["VAT-A"]).Length)
                       + (string)ht["Gross1"]);
            sb.Append(Environment.NewLine);
            sb.Append("Rate" + PrtCommon.GetSpace(7) + "Net" + PrtCommon.GetSpace(7) + "VAT-B" + PrtCommon.GetSpace(7) + "Gross");
            sb.Append(Environment.NewLine);
            sb.Append((string)ht["Rate2"] + PrtCommon.GetSpace(11 - ((string)ht["Rate2"]).Length)
                       + (string)ht["Net2"] + PrtCommon.GetSpace(10 - ((string)ht["Net2"]).Length)
                       + (string)ht["VAT-B"] + PrtCommon.GetSpace(12 - ((string)ht["VAT-B"]).Length)
                       + (string)ht["Gross2"]);
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);

            sb.Append(PrtStatic.PRT_COMP_NAME);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetSpace(8) + PrtStatic.PRT_COMP_WEBSITE);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
        #endregion

        #region 打印Receipt内容事件
        /// <summary>
        /// 打印Receipt内容事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Prt_Content_Receipt(object sender, PrintPageEventArgs e)
        {
            var mark = 0;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            foreach (var item in textList)
            {
                if (mark == 0)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), Brushes.Black, 0, mark * 20);
                }
                //else if (mark == 1)
                //{
                //    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 0, (mark + 1) * 20);
                //}
                //else if (mark == 5)
                //{
                //    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), System.Drawing.Brushes.Black, 0, (mark + 1) * 20);
                //}
                else if (mark == textList.Count - 10)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == textList.Count - 12)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == textList.Count - 13)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == textList.Count - 15)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                else
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 10), Brushes.Black, 0, (mark + 1) * 20);
                }

                mark++;
            }
        }
        #endregion

        #region 打印Receipt主体打印事件
        public static void PrtReceipt(List<TaOrderItemInfo> lstOI, Hashtable ht)
        {
            if (string.IsNullOrWhiteSpace(GetPrtStrReceipt(lstOI, ht)))
            {
                return;
            }

            //原文字行或者段落内容
            var sourceTexts = GetPrtStrReceipt(lstOI, ht).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            //重新把文字进行分行树立
            textList = new List<string>();
            foreach (var item in sourceTexts)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    if (item.Length > PrtStatic.PRT_LINE_SIZE)
                    {
                        textList.AddRange(GetArr(PrtStatic.PRT_LINE_SIZE, item));
                    }
                    else
                    {
                        textList.Add(item);
                    }
                }
            }


            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(Prt_Content_Receipt);
            //纸张设置默认
            PaperSize pageSize = new PaperSize("自定义纸张", (textList.Count * (int)(58 / 25.4 * 100)), 700);
            pd.DefaultPageSettings.PaperSize = pageSize;
            //pd.PrinterSettings.PrinterName
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印失败." + ex.Message);
            }
        }
        #endregion

        #region 打印Cash双语
        public string GetPrtStrCashBilingual(List<TaOrderItemInfo> lstOI, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            string L = PrtCommon.GetSplit();
            string L1 = PrtCommon.GetRestName();
            string L2 = PrtCommon.GetRestAddr();
            string L3 = PrtCommon.GetRestTel();
            string L4 = PrtCommon.GetRestVATNo();
            string L5 = PrtCommon.GetPrtTime();
            string L6 = PrtCommon.GetPrtDateTime();
            string L7 = (string)ht["Staff"];

            //餐厅名称
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE_20 - L1.Length) / 2) + L1);
            sb.Append(Environment.NewLine);

            //餐厅地址
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L2.Length) / 2) + L2);
            sb.Append(Environment.NewLine);

            //Tel
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L3.Length) / 2) + L3);
            sb.Append(Environment.NewLine);

            //VAT
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L4.Length) / 2) + L4);
            sb.Append(Environment.NewLine);

            //分隔行
            sb.Append(L);
            sb.Append(Environment.NewLine);

            //时间
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE_20 - L5.Length) / 2) + L5);
            sb.Append(Environment.NewLine);

            //分隔行
            sb.Append(L);
            sb.Append(Environment.NewLine);

            sb.Append(PrtCommon.GetSpace(6) + L6);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetSpace(6) + L7);
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);

            sb.Append("Code" + PrtCommon.GetSpace(2) + "Qty" + PrtCommon.GetSpace(2) + "Name" + PrtCommon.GetSpace(17) + "Price" + PrtCommon.GetSpace(2));
            sb.Append(Environment.NewLine);

            foreach (var taOrderItemInfo in lstOI)
            {
                sb.Append(PrtCommon.GetTab(taOrderItemInfo.ItemCode, taOrderItemInfo.ItemQty,
                    taOrderItemInfo.ItemDishName, taOrderItemInfo.ItemTotalPrice));
                sb.Append(Environment.NewLine);
            }

            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetItemTotal((string)ht["ItemQty"], (string)ht["SubTotal"]));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetTotal((string)ht["Total"]));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetPay((string)ht["PayType"]));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtStatic.PRT_COMP_NAME);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetSpace(8) + PrtStatic.PRT_COMP_WEBSITE);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
        #endregion

        #region 打印Cash双语内容事件
        /// <summary>
        /// 打印Receipt内容事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Prt_Content_CashBilingual(object sender, PrintPageEventArgs e)
        {
            var mark = 0;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            foreach (var item in textList)
            {
                if (mark == 0)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), System.Drawing.Brushes.Black, 0, mark * 20);
                }
                else if (mark == 1)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), System.Drawing.Brushes.Black, 0, mark * 20);
                }
                else if (mark == 5)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), System.Drawing.Brushes.Black, 0, mark * 20);
                }
                else if (mark == textList.Count - 4)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), System.Drawing.Brushes.Black, 0, mark * 20);
                }
                else if (mark == textList.Count - 6)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), System.Drawing.Brushes.Black, 0, mark * 20);
                }
                else
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), System.Drawing.Brushes.Black, 0, mark * 20);
                }

                mark++;
            }
        }
        #endregion

        #region 打印Cash双语主体打印事件
        public void PrtCashBilingual(List<TaOrderItemInfo> lstOI, Hashtable ht)
        {
            if (string.IsNullOrWhiteSpace(GetPrtStrCashBilingual(lstOI, ht)))
            {
                return;
            }

            //原文字行或者段落内容
            var sourceTexts = GetPrtStrCashBilingual(lstOI, ht).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            //重新把文字进行分行树立
            textList = new List<string>();
            foreach (var item in sourceTexts)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    if (item.Length > PrtStatic.PRT_LINE_SIZE)
                    {
                        textList.AddRange(GetArr(PrtStatic.PRT_LINE_SIZE, item));
                    }
                    else
                    {
                        textList.Add(item);
                    }
                }
            }


            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(Prt_Content_CashBilingual);
            //纸张设置默认
            PaperSize pageSize = new PaperSize("自定义纸张", (textList.Count * (int)(58 / 25.4 * 100)), 700);
            pd.DefaultPageSettings.PaperSize = pageSize;
            //pd.PrinterSettings.PrinterName
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印失败." + ex.Message);
            }
        }
        #endregion

        #region 打印Kitchen厨房单
        public static string GetPrtStrKit(List<TaOrderItemInfo> lstOI, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            string L = PrtCommon.GetSplit();
            string L1 = (string)ht["ChkNum"];

            //账单号
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE_20 - L1.Length) / 2) + L1);
            sb.Append(Environment.NewLine);

            //分隔行
            sb.Append(L);
            sb.Append(Environment.NewLine);

            sb.Append("Code" + PrtCommon.GetSpace(2) + "Qty" + PrtCommon.GetSpace(2) + "Name" + PrtCommon.GetSpace(24));
            sb.Append(Environment.NewLine);

            //分隔行
            sb.Append(L);
            sb.Append(Environment.NewLine);

            PRT_BILL_SHUANGYU_ROW_COUNT = lstOI.Count * 2;

            foreach (var taOrderItemInfo in lstOI)
            {
                sb.Append(GetTab(taOrderItemInfo.ItemCode, taOrderItemInfo.ItemQty, taOrderItemInfo.ItemDishName));
                sb.Append(Environment.NewLine);
                //var CNameList = CommonData.TaMenuItem.Where(s => s.MiDishCode.Equals(taOrderItemInfo.ItemCode));
                //if (CNameList.Any())
                //{
                //    sb.Append(PrtCommon.GetHanZiTabKitchen(CNameList.FirstOrDefault().MiOtherName));
                //    sb.Append(Environment.NewLine);
                //}
                sb.Append(PrtCommon.GetHanZiTabKitchen(taOrderItemInfo.ItemDishOtherName));
                sb.Append(Environment.NewLine);
            }

            sb.Append(L);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
        #endregion

        #region 打印Kitchen内容事件
        /// <summary>
        /// 打印Kitchen内容事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Prt_Content_Kitchen(object sender, PrintPageEventArgs e)
        {
            var mark = 0;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            foreach (var item in textList)
            {
                //e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), fontSize), System.Drawing.Brushes.Black, 0, mark * lineSize);
                if (mark == 0)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), Brushes.Black, 0, mark * 20);
                }
                else if (mark == 1)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 10), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == 2)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 10), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == 3)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 10), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == textList.Count)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 10), Brushes.Black, 0, (mark + 1) * 20);
                }
                else
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                mark++;
            }
        }
        #endregion

        #region 打印Kitchen主体打印事件
        public static void PrtKitchen(List<TaOrderItemInfo> lstOI, Hashtable ht)
        {
            if (string.IsNullOrWhiteSpace(GetPrtStrKit(lstOI, ht)))
            {
                return;
            }

            //原文字行或者段落内容
            var sourceTexts = GetPrtStrKit(lstOI, ht).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            //重新把文字进行分行树立
            textList = new List<string>();
            foreach (var item in sourceTexts)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    if (item.Length > PrtStatic.PRT_LINE_SIZE)
                    {
                        textList.AddRange(GetArr(PrtStatic.PRT_LINE_SIZE, item));
                    }
                    else
                    {
                        textList.Add(item);
                    }
                }
            }


            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(Prt_Content_Kitchen);
            //纸张设置默认
            //PaperSize pageSize = new PaperSize("自定义纸张", fontSize * lineSize, (textList.Count * (int)(58 / 25.4 * 100)));
            //PaperSize pageSize = new PaperSize("自定义纸张", (textList.Count * (int)(58 / 25.4 * 100)), 455);
            PaperSize pageSize = new PaperSize("自定义纸张", (textList.Count * (int)(80 / 25.4 * 100)), PRT_BILL_SHUANGYU_ROW_COUNT * 20 + 120);
            pd.DefaultPageSettings.PaperSize = pageSize;
            //pd.PrinterSettings.PrinterName
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印失败." + ex.Message);
            }
        }
        #endregion

        public void PrtDrawStr(PrintPageEventArgs e, string strItem, int intFontSize, float fRow)
        {
            e.Graphics.DrawString(strItem, new Font(new FontFamily("宋体"), intFontSize), System.Drawing.Brushes.Black, 0, fRow);
        }

        public static StringBuilder GetTab(string sCode, string sQty, string sName, string sPrice)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(sCode + PrtCommon.GetSpace(6 - sCode.Length) + sQty + PrtCommon.GetSpace(5 - sQty.Length));
            if (sName.Length > 21)
            {
                sb.Append(sName.Substring(0, 20));
                sb.Append(PrtCommon.GetSpace(1) + sPrice);
                sb.Append(Environment.NewLine);
                sb.Append(PrtCommon.GetSpace(11) + sName.Substring(20, sName.Length - 20));
                sb.Append(Environment.NewLine);

                //字符超过21，有换行，所以+1
                PRT_BILL_SHUANGYU_ROW_COUNT += 1;
            }
            else
            {
                sb.Append(sName + PrtCommon.GetSpace(21 - sName.Length));
                sb.Append(sPrice);
            }

            return sb;
        }

        public static StringBuilder GetTab(string sCode, string sQty, string sName, string sPrice, bool isNew)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(sCode + PrtCommon.GetSpace(6 - sCode.Length) + sQty + PrtCommon.GetSpace(5 - sQty.Length));
            if (sName.Length > 21)
            {
                sb.Append(sName.Substring(0, 20));
                sb.Append(PrtCommon.GetSpace(1) + sPrice);
                sb.Append("\n");
                sb.Append(PrtCommon.GetSpace(11) + sName.Substring(20, sName.Length - 20));
            }
            else
            {
                sb.Append(sName + PrtCommon.GetSpace(21 - sName.Length));
                sb.Append(sPrice);
            }

            return sb;
        }

        public static StringBuilder GetTab(string sCode, string sQty, string sName)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(sCode + PrtCommon.GetSpace(4 - sCode.Length) + sQty + PrtCommon.GetSpace(3 - sQty.Length));
            if (sName.Length > 21)
            {
                sb.Append(sName.Substring(0, 20));
                sb.Append(Environment.NewLine);
                sb.Append(PrtCommon.GetSpace(7) + sName.Substring(20, sName.Length - 21));
                sb.Append(Environment.NewLine);

                PRT_BILL_SHUANGYU_ROW_COUNT += 1;
            }
            else
            {
                sb.Append(sName + PrtCommon.GetSpace(21 - sName.Length));
            }

            return sb;
        }

        #region 打印付款方式为Collection
        public static string GetPrtStrPayCollection(List<TaOrderItemInfo> lstOI, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            string L = PrtCommon.GetSplit();
            string L1 = PrtCommon.GetRestName();
            string L2 = PrtCommon.GetRestAddr();
            string L3 = PrtCommon.GetRestTel();
            string L4 = PrtCommon.GetRestVATNo();
            //string L5 = PrtCommon.GetPrtTime();
            string L51 = (string)ht["CustName"];
            string L52 = "[" + (string)ht["CustPhone"] + "]";
            string L6 = PrtCommon.GetPrtDateTime();
            string L7 = "Staff:" + (string)ht["Staff"];

            //餐厅名称
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE_20 - L1.Length) / 2) + L1);
            sb.Append(Environment.NewLine);

            //餐厅地址
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L2.Length) / 2) + L2);
            sb.Append(Environment.NewLine);

            //Tel
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L3.Length) / 2) + L3);
            sb.Append(Environment.NewLine);

            //VAT
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE - L4.Length) / 2) + L4);
            sb.Append(Environment.NewLine);

            //分隔行
            sb.Append(L);
            sb.Append(Environment.NewLine);

            //时间
            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE_15 - L51.Length) / 2) + L51);
            sb.Append(Environment.NewLine);

            sb.Append(PrtCommon.GetSpace((PrtStatic.PRT_LINE_SIZE_15 - L52.Length) / 2) + L52);
            sb.Append(Environment.NewLine);

            //分隔行
            sb.Append(L);
            sb.Append(Environment.NewLine);

            //sb.Append(PrtCommon.GetSpace(6) + L6);
            sb.Append(L6);
            sb.Append(Environment.NewLine);
            //sb.Append(PrtCommon.GetSpace(6) + L7);
            sb.Append(L7);
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);

            sb.Append("Code" + PrtCommon.GetSpace(2) + "Qty" + PrtCommon.GetSpace(2) + "Name" + PrtCommon.GetSpace(17) + "Price" + PrtCommon.GetSpace(2));
            sb.Append(Environment.NewLine);

            foreach (var taOrderItemInfo in lstOI)
            {
                //涉及到多行需要计算行数
                //sb.Append(PrtCommon.GetTab(taOrderItemInfo.ItemCode, taOrderItemInfo.ItemQty,
                //    taOrderItemInfo.ItemDishName, taOrderItemInfo.ItemTotalPrice));
                sb.Append(GetTab(taOrderItemInfo.ItemCode, taOrderItemInfo.ItemQty,
                    taOrderItemInfo.ItemDishName, taOrderItemInfo.ItemTotalPrice));
                sb.Append(Environment.NewLine);
            }

            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetItemTotal((string)ht["ItemQty"], (string)ht["SubTotal"]));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetTotal((string)ht["Total"]));
            sb.Append(Environment.NewLine);
            sb.Append(L);
            sb.Append(Environment.NewLine);

            sb.Append(PrtCommon.GetText("NOT PAID"));
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetText("[]CASH      []CARD"));
            sb.Append(Environment.NewLine);
            sb.Append(L);

            sb.Append(Environment.NewLine);
            sb.Append(PrtStatic.PRT_COMP_NAME);
            sb.Append(Environment.NewLine);
            sb.Append(PrtCommon.GetSpace(8) + PrtStatic.PRT_COMP_WEBSITE);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
        #endregion

        #region 打印付款方式为Collection内容事件
        /// <summary>
        /// 打印Bill内容事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Prt_Content_PayCollection(object sender, PrintPageEventArgs e)
        {
            var mark = 0;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            foreach (var item in textList)
            {
                //e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), fontSize), System.Drawing.Brushes.Black, 0, mark * lineSize);
                if (mark == 0)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 20), Brushes.Black, 0, mark * 20);
                }
                else if (mark == 5)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == 6)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == textList.Count - 4)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == textList.Count - 5)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                else if (mark == textList.Count - 7)
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 15), Brushes.Black, 0, (mark + 1) * 20);
                }
                else
                {
                    e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), 10), Brushes.Black, 0, (mark + 1) * 20);
                }

                mark++;
            }
        }
        #endregion

        #region 打印付款方式为Collection主体打印事件
        public static void PrtPayCollection(List<TaOrderItemInfo> lstOI, Hashtable ht)
        {
            if (string.IsNullOrWhiteSpace(GetPrtStrPayCollection(lstOI, ht)))
            {
                return;
            }

            //原文字行或者段落内容
            var sourceTexts = GetPrtStrPayCollection(lstOI, ht).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            //重新把文字进行分行树立
            textList = new List<string>();
            foreach (var item in sourceTexts)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    if (item.Length > PrtStatic.PRT_LINE_SIZE)
                    {
                        textList.AddRange(GetArr(PrtStatic.PRT_LINE_SIZE, item));
                    }
                    else
                    {
                        textList.Add(item);
                    }
                }
            }


            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(Prt_Content_PayCollection);
            //纸张设置默认
            //PaperSize pageSize = new PaperSize("自定义纸张", fontSize * lineSize, (textList.Count * (int)(58 / 25.4 * 100)));
            //PaperSize pageSize = new PaperSize("自定义纸张", (textList.Count * (int)(58 / 25.4 * 100)), 455);
            PaperSize pageSize = new PaperSize("自定义纸张", (textList.Count * (int)(58 / 25.4 * 100)), PRT_BILL_SHUANGYU_ROW_COUNT * 20 + 475);
            pd.DefaultPageSettings.PaperSize = pageSize;
            //pd.PrinterSettings.PrinterName
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印失败." + ex.Message);
            }
        }
        #endregion
    }
}