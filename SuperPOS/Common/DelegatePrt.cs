using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using SuperPOS.Dapper;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;

namespace SuperPOS.Common
{
    public delegate void DelegatePreview();

    public delegate void DelegateOrderItemSave(string strCheckId, string strBusDate, List<TaOrderItemInfo> lstOi);

    public delegate void DelegateOrderItemSaveAndDeleteOld(string strCheckId, string strBusDate, List<TaOrderItemInfo> lstOi);

    public delegate void DelegateSaveCheckOrder(TaCheckOrderInfo taCheckOrderInfo, bool isRefreshData);
    
    public delegate void DelegateSaveCheckOrderAndPrint(TaCheckOrderInfo taCheckOrderInfo, string strPrintType, List<TaOrderItemInfo> lstOI, WbPrtTemplataTa wbPrtTemplataTa, string strOrderType);

    public delegate void DelegateSaveOrderItemAndCheckOrder(string strCheckId, string strBusDate, List<TaOrderItemInfo> lstOi, TaCheckOrderInfo taCheckOrderInfo, bool isRefreshData);

    public delegate void DelegatePrintHtml(string checkID, string strBusDate, List<TaOrderItemInfo> lstOI, string strType, WbPrtTemplataTa wbPrtTemplataTa, string strOrderType);
    
    public delegate void DelegateRefresh(string iStatus, string strBusDate, string strCheckId);

    public delegate void DelegatePrtHtml(string strPrintType, List<TaOrderItemInfo> lstOI, WbPrtTemplataTa wbPrtTemplataTa, string strOrderType);

    public delegate void DelegatePrtHtmlAS(string strBusDate);

    public class DelegateMy
    {
        private static EntityControl _control = new EntityControl();
        
        #region Show Order模板
        //public static void SaveShowOrderModelPreview()
        //{
        //    try
        //    {string content = @"";

        //        TaPreviewInfo taPreview = new TaPreviewInfo();

        //        foreach (var f in new DirectoryInfo(PrtStatic.PRT_TEMPLATE_FILE_PATH).GetFiles().Where(s => s.Name.Equals(@"showorder.txt")))
        //        {
        //            if (f.Length > 0)
        //            {
        //                //switch (f.Name)
        //                //{
        //                //    case @"taKitchen.txt":
        //                //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_KITCHEN_PRE;
        //                //        break;
        //                //    case @"taReceipt.txt":
        //                //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_RECEIPT_PRE;
        //                //        break;
        //                //    case @"taBill.txt":
        //                //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_BILL_PRE;
        //                //        break;
        //                //    case @"ta.txt":
        //                //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_ALL_PRE;
        //                //        break;
        //                //    case @"showorder.txt":
        //                //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_SHOWORDER_PRE;
        //                //        break;
        //                //}
        //                taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_SHOWORDER_PRE;

        //                taPreview.PreviewFileName = f.Name;
        //                StreamReader objReader = new StreamReader(PrtStatic.PRT_TEMPLATE_FILE_PATH + f.Name, Encoding.UTF8);
        //                taPreview.PreviewContent = objReader.ReadToEnd();
        //                taPreview.PreviewContent = PrtTemplate.ReplacePrtKeysPreviewDefaultContent(taPreview.PreviewContent);
                        
        //                var lstTaPreview = CommonData.TaPreview.Where(s => s.PreviewType.Equals(taPreview.PreviewType));

        //                if (lstTaPreview.Any())
        //                {
        //                    taPreview.ID = lstTaPreview.FirstOrDefault(s => s.PreviewType.Equals(taPreview.PreviewType)).ID;
        //                    _control.UpdateEntity(taPreview);
        //                }
        //                else
        //                {
        //                    _control.AddEntity(taPreview);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex) { LogHelper.Error(@"CommonDAL", ex); }
        //}
        #endregion

        #region 打印
        //public static void PrtHtml(string checkID, string strBusDate, List<TaOrderItemInfo> lstOI, string strPrintType, WbPrtTemplataTa wbPrtTemplataTa, string strOrderType)
        //{
        //    WbPrtPrint.PrintHtml(strPrintType, lstOI, wbPrtTemplataTa, strOrderType);
        //}
        public static void PrtHtml(string strPrintType, List<TaOrderItemInfo> lstOI, WbPrtTemplataTa wbPrtTemplataTa, string strOrderType)
        {
            WbPrtPrint.PrintHtml(strPrintType, lstOI, wbPrtTemplataTa, strOrderType);
        }
        #endregion

        #region MyRegion

        public static void PrtHtmlAs(string strBusDate)
        {
            WbPrtPrint.PrintHtmlAccountSummary(strBusDate);
        }

        #endregion

        #region 存储OrderItem到数据库
        //public static void SaveOrderItem(string strCheckId, string strBusDate, List<TaOrderItemInfo> lstOi)
        //{
        //    new SystemData().GetTaOrderItem();

        //    var lstDelOi = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strCheckId) && s.BusDate.Equals(strBusDate));
        //    //删除原始数据
        //    foreach (var taOrderItemInfo in lstDelOi)
        //    {
        //        _control.DeleteEntity(taOrderItemInfo);
        //    }

        //    foreach (var taOrderItemInfo in lstOi)
        //    {
        //        //TaOrderItemInfo taOi = CommonData.TaOrderItem.FirstOrDefault(s => s.ID == taOrderItemInfo.ID);

        //        //if (taOi != null)
        //        //{
        //        //    _control.UpdateEntity(taOrderItemInfo);
        //        //}
        //        //else
        //        //{
        //        //    _control.AddEntity(taOrderItemInfo);
        //        //}
        //        _control.AddEntity(taOrderItemInfo);
        //    }
        //}
        #endregion

        //public static void SaveOrderItemAndDeleteOld(string strCheckId, string strBusDate, List<TaOrderItemInfo> lstOi)
        //{
        //    string strSql = "";

        //    strSql = "DELETE FROM Ta_OrderItem WHERE BusDate = '" + strBusDate + "' AND CheckCode = '" + strCheckId + "'";

        //    _control.ExecuteSql(strSql);

        //    foreach (var taOrderItemInfo in lstOi)
        //    {
        //        _control.AddEntity(taOrderItemInfo);
        //    }
        //}

        #region 保存CheckOrder
        public static void SaveCheckOrder(TaCheckOrderInfo taCheckOrderInfo, bool isRefreshData)
        {
            if (string.IsNullOrEmpty(taCheckOrderInfo.CheckCode) && string.IsNullOrEmpty(taCheckOrderInfo.BusDate))
            {
                _control.AddEntity(taCheckOrderInfo);
            }
            else
            {
                string strSqlWhere = "";
                DynamicParameters dynamicParams = new DynamicParameters();

                //new SystemData().GetTaCheckOrderByCheckCodeAndBusDate(taCheckOrderInfo.CheckCode, taCheckOrderInfo.BusDate);

                //TaCheckOrderInfo taCheck = CommonData.TaCheckOrderByCheckCodeAndBusDate;
                strSqlWhere = "CheckCode=@CheckCode AND BusDate=@BusDate";

                dynamicParams.Add("CheckCode", taCheckOrderInfo.CheckCode);
                dynamicParams.Add("BusDate", taCheckOrderInfo.BusDate);

                var taCheck = new SQLiteDbHelper().QueryFirstByWhere<TaCheckOrderInfo>("Ta_CheckOrder", strSqlWhere, dynamicParams);

                //new SystemData().GetTaCheckOrder();
                //TaCheckOrderInfo taCheck = CommonData.TaCheckOrder.FirstOrDefault(s =>
                //    s.CheckCode.Equals(taCheckOrderInfo.CheckCode) && s.BusDate.Equals(taCheckOrderInfo.BusDate));

                string strSql = "";

                
                if (taCheck != null)
                {
                    //_control.UpdateEntity(taCheckOrderInfo);
                    //strSql = "UPDATE Ta_CheckOrder SET ";
                    //strSql += "CheckCode='" + taCheckOrderInfo.CheckCode + "', ";
                    //strSql += "PayOrderType='" + taCheckOrderInfo.PayOrderType + "', ";
                    //strSql += "PayDelivery='" + taCheckOrderInfo.PayDelivery + "', ";
                    //strSql += "PayPerDiscount='" + taCheckOrderInfo.PayPerDiscount + "', ";
                    //strSql += "PayDiscount='" + taCheckOrderInfo.PayDiscount + "', ";
                    //strSql += "PayPerSurcharge='" + taCheckOrderInfo.PayPerSurcharge + "', ";
                    //strSql += "PaySurcharge='" + taCheckOrderInfo.PaySurcharge + "', ";
                    //strSql += "MenuAmount='" + taCheckOrderInfo.MenuAmount + "', ";
                    //strSql += "TotalAmount='" + taCheckOrderInfo.TotalAmount + "', ";
                    //strSql += "Paid='" + taCheckOrderInfo.Paid + "', ";
                    //strSql += "IsPaid='" + taCheckOrderInfo.IsPaid + "', ";
                    //strSql += "CustomerID='" + taCheckOrderInfo.CustomerID + "', ";
                    //strSql += "CustomerNote='" + taCheckOrderInfo.CustomerNote + "', ";
                    //strSql += "DriverID='" + taCheckOrderInfo.DriverID + "', ";
                    //strSql += "StaffID='" + taCheckOrderInfo.StaffID + "', ";
                    //strSql += "PayTime='" + taCheckOrderInfo.PayTime + "', ";
                    //strSql += "PayType1='" + taCheckOrderInfo.PayType1 + "', ";
                    //strSql += "PayTypePay1='" + taCheckOrderInfo.PayTypePay1 + "', ";
                    //strSql += "PayType2='" + taCheckOrderInfo.PayType2 + "', ";
                    //strSql += "PayTypePay2='" + taCheckOrderInfo.PayTypePay2 + "', ";
                    //strSql += "PayType3='" + taCheckOrderInfo.PayType3 + "', ";
                    //strSql += "PayTypePay3='" + taCheckOrderInfo.PayTypePay3 + "', ";
                    //strSql += "PayType4='" + taCheckOrderInfo.PayType4 + "', ";
                    //strSql += "PayTypePay4='" + taCheckOrderInfo.PayTypePay4 + "', ";
                    //strSql += "PayType5='" + taCheckOrderInfo.PayType5 + "', ";
                    //strSql += "PayTypePay5='" + taCheckOrderInfo.PayTypePay5 + "', ";
                    //strSql += "IsCancel='" + taCheckOrderInfo.IsCancel + "', ";
                    //strSql += "IsSave='" + taCheckOrderInfo.IsSave + "', ";
                    //strSql += "BusDate='" + taCheckOrderInfo.BusDate + "', ";
                    //strSql += "RefNum='" + taCheckOrderInfo.RefNum + "', ";
                    //strSql += "DeliveryFee='" + taCheckOrderInfo.DeliveryFee + "'";
                    //strSql += " WHERE ID = " + taCheck.ID;
                    taCheckOrderInfo.ID = taCheck.ID;

                    strSqlWhere = "ID=@ID";

                    new SQLiteDbHelper().Update<TaCheckOrderInfo>(@"Ta_CheckOrder", strSqlWhere, taCheckOrderInfo);
                }
                else
                {
                    //_control.AddEntity(taCheckOrderInfo);
                    //strSql = "INSERT INTO Ta_CheckOrder (CheckCode, PayOrderType, PayDelivery, PayPerDiscount, PayDiscount, PayPerSurcharge, PaySurcharge, " + 
                    //         "MenuAmount, TotalAmount, Paid, IsPaid, CustomerID, CustomerNote, DriverID, StaffID, PayTime, PayType1, PayTypePay1, PayType2, PayTypePay2, " +
                    //         "PayType3, PayTypePay3, PayType4, PayTypePay4, PayType5, PayTypePay5, IsCancel, IsSave, BusDate, RefNum, DeliveryFee) VALUES (";
                    //strSql += "'" + taCheckOrderInfo.CheckCode + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayOrderType + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayDelivery + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayPerDiscount + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayDiscount + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayPerSurcharge + "', ";
                    //strSql += "'" + taCheckOrderInfo.PaySurcharge + "', ";
                    //strSql += "'" + taCheckOrderInfo.MenuAmount + "', ";
                    //strSql += "'" + taCheckOrderInfo.TotalAmount + "', ";
                    //strSql += "'" + taCheckOrderInfo.Paid + "', ";
                    //strSql += "'" + taCheckOrderInfo.IsPaid + "', ";
                    //strSql += "'" + taCheckOrderInfo.CustomerID + "', ";
                    //strSql += "'" + taCheckOrderInfo.CustomerNote + "', ";
                    //strSql += "'" + taCheckOrderInfo.DriverID + "', ";
                    //strSql += "'" + taCheckOrderInfo.StaffID + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayTime + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayType1 + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayTypePay1 + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayType2 + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayTypePay2 + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayType3 + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayTypePay3 + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayType4 + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayTypePay4 + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayType5 + "', ";
                    //strSql += "'" + taCheckOrderInfo.PayTypePay5 + "', ";
                    //strSql += "'" + taCheckOrderInfo.IsCancel + "', ";
                    //strSql += "'" + taCheckOrderInfo.IsSave + "', ";
                    //strSql += "'" + taCheckOrderInfo.BusDate + "', ";
                    //strSql += "'" + taCheckOrderInfo.RefNum + "', ";
                    //strSql += "'" + taCheckOrderInfo.DeliveryFee + "'";
                    //strSql += ")";
                    strSqlWhere = "INSERT INTO Ta_CheckOrder (CheckCode, PayOrderType, PayDelivery, PayPerDiscount, PayDiscount, PayPerSurcharge, PaySurcharge, MenuAmount, TotalAmount, Paid, " +
                                  "IsPaid, CustomerID, CustomerNote, DriverID, StaffID, PayTime, PayType1, PayTypePay1, PayType2, PayTypePay2, PayType3, PayTypePay3, PayType4, PayTypePay4, " +
                                  "PayType5, PayTypePay5, IsCancel, IsSave, BusDate, RefNum, DeliveryFee) VALUES (@CheckCode, @PayOrderType, @PayDelivery, @PayPerDiscount, @PayDiscount, " +
                                  "@PayPerSurcharge, @PaySurcharge, @MenuAmount, @TotalAmount, @Paid, @IsPaid, @CustomerID, @CustomerNote, @DriverID, @StaffID, @PayTime, @PayType1, " +
                                  "@PayTypePay1, @PayType2, @PayTypePay2, @PayType3, @PayTypePay3, @PayType4, @PayTypePay4, @PayType5, @PayTypePay5, @IsCancel, @IsSave, @BusDate, @RefNum, @DeliveryFee)";
                    bool isSucess = new SQLiteDbHelper().Insert(strSqlWhere, taCheckOrderInfo);
                }
                
                //_control.ExecuteSql(strSql);

                if (isRefreshData) CommonDAL.RefreshSomeInfo("1", "", "");

            }

            //new SystemData().GetTaCheckOrder();
        }
        #endregion

        #region 保存OrderItem和CheckOrder

        //public static void SaveOrderItemAndCheckOrder(string strCheckId, string strBusDate, List<TaOrderItemInfo> lstOi,
        //    TaCheckOrderInfo taCheckOrderInfo, bool isRefreshData)
        //{
        //    SaveOrderItemAndDeleteOld(strCheckId, strBusDate, lstOi);

        //    SaveCheckOrder(taCheckOrderInfo, isRefreshData);
        //}

        #endregion

        #region 后台刷新数据库内容
        //public static void RefreshSomeInfo(string iStatus, string strBusDate, string strCheckId)
        //{
        //    SystemData systemData = new SystemData();

        //    switch (iStatus)
        //    {
        //        case "1":
        //            systemData.GetTaCheckOrder();
        //            break;
        //        case "2":
        //            systemData.GetTaOrderItem();
        //            break;
        //        case "3":
        //            systemData.GetTaCheckOrder();
        //            systemData.GetTaOrderItem();
        //            break;
        //        case "4":
        //            systemData.GetTaMenuCate();
        //            break;
        //        case "5":
        //            systemData.GetTaCustomer();
        //            break;
        //        case "6":
        //            systemData.GetTaDriver();
        //            break;
        //        case "7":
        //            systemData.GetTaMenuItem();
        //            break;
        //        case "8":
        //            systemData.GetShowAndPendOrderData(strCheckId, strBusDate);
        //            break;
        //        case "9":
        //            systemData.GetShowAndPendOrderData(strCheckId, strBusDate);
        //            systemData.GetTaCheckOrder();
        //            systemData.GetTaOrderItem();
        //            break;
        //        case "10":
        //            systemData.GetTaCheckOrder();
        //            systemData.GetTaOrderItem();
        //            systemData.GetTaCustomer();
        //            systemData.GetTaDriver();
        //            systemData.GetShowAndPendOrderData(strCheckId, strBusDate);
        //            break;
        //        default:
        //            systemData.GetTaCheckOrder();
        //            systemData.GetTaOrderItem();
        //            systemData.GetTaMenuItem();
        //            systemData.GetTaMenuCate();
        //            systemData.GetTaCustomer();
        //            systemData.GetTaDriver();
        //            systemData.GetTaMenuItemOtherChoice();
        //            systemData.GetShowAndPendOrderData(strCheckId, strBusDate);
        //            break;
        //    }
        //}
        #endregion

        #region 保存CheckOrder并打印

        public static void CheckOrderSaveAndPrint(TaCheckOrderInfo taCheckOrderInfo, string strPrintType, List<TaOrderItemInfo> lstOI, WbPrtTemplataTa wbPrtTemplataTa, string strOrderType)
        {
            SaveCheckOrder(taCheckOrderInfo, false);

            WbPrtPrint.PrintHtml(strPrintType, lstOI, wbPrtTemplataTa, strOrderType);
        }

        #endregion

    }
}
