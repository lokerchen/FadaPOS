using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;

namespace SuperPOS.Common
{
    public delegate void DelegatePreview();

    public delegate void DelegateOrder(string strCheckId, string strBusDate, List<TaOrderItemInfo> lstOi);

    public delegate void DelegateSaveCheckOrder(TaCheckOrderInfo taCheckOrderInfo);

    public delegate void DelegatePrintHtml(string checkID, string strBusDate, WebBrowser webBrowser, string strType, WbPrtTemplataTa wbPrtTemplataTa, string strOrderType);

    public delegate void DelegateRefresh(string iStatus, string strBusDate, string strCheckId);

    public class DelegatePrt
    {
        private static EntityControl _control = new EntityControl();
        //private Action saveShowOrderModelPreview;

        //public DelegatePrt(Action saveShowOrderModelPreview)
        //{
        //    this.saveShowOrderModelPreview = saveShowOrderModelPreview;
        //}

        #region Show Order模板
        public static void SaveShowOrderModelPreview()
        {
            try
            {string content = @"";

                TaPreviewInfo taPreview = new TaPreviewInfo();

                foreach (var f in new DirectoryInfo(PrtStatic.PRT_TEMPLATE_FILE_PATH).GetFiles().Where(s => s.Name.Equals(@"showorder.txt")))
                {
                    if (f.Length > 0)
                    {
                        //switch (f.Name)
                        //{
                        //    case @"taKitchen.txt":
                        //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_KITCHEN_PRE;
                        //        break;
                        //    case @"taReceipt.txt":
                        //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_RECEIPT_PRE;
                        //        break;
                        //    case @"taBill.txt":
                        //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_BILL_PRE;
                        //        break;
                        //    case @"ta.txt":
                        //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_ALL_PRE;
                        //        break;
                        //    case @"showorder.txt":
                        //        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_SHOWORDER_PRE;
                        //        break;
                        //}
                        taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_SHOWORDER_PRE;

                        taPreview.PreviewFileName = f.Name;
                        StreamReader objReader = new StreamReader(PrtStatic.PRT_TEMPLATE_FILE_PATH + f.Name, Encoding.UTF8);
                        taPreview.PreviewContent = objReader.ReadToEnd();
                        taPreview.PreviewContent = PrtTemplate.ReplacePrtKeysPreviewDefaultContent(taPreview.PreviewContent);
                        
                        var lstTaPreview = CommonData.TaPreview.Where(s => s.PreviewType.Equals(taPreview.PreviewType));

                        if (lstTaPreview.Any())
                        {
                            taPreview.ID = lstTaPreview.FirstOrDefault(s => s.PreviewType.Equals(taPreview.PreviewType)).ID;
                            _control.UpdateEntity(taPreview);
                        }
                        else
                        {
                            _control.AddEntity(taPreview);
                        }
                    }
                }
            }
            catch (Exception ex) { LogHelper.Error(@"CommonDAL", ex); }
        }
        #endregion

        public static void PrtHtml(string checkID, string strBusDate, WebBrowser webBrowser, string strType, WbPrtTemplataTa wbPrtTemplataTa, string strOrderType)
        {
            new SystemData().GetTaOrderItem();
            var lstOI = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate)).ToList();

            WbPrtPrint.PrintHtml(webBrowser, strType, lstOI, wbPrtTemplataTa, PubComm.ORDER_TYPE_SHOP);
        }
    }

    public class DelegateOrderOpt
    {
        private static EntityControl _control = new EntityControl();

        #region 存储OrderItem到数据库
        public static void SaveOrder(string strCheckId, string strBusDate, List<TaOrderItemInfo> lstOi)
        {
            new SystemData().GetTaOrderItem();

            var lstDelOi = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strCheckId) && s.BusDate.Equals(strBusDate));
            //删除原始数据
            foreach (var taOrderItemInfo in lstDelOi)
            {
                _control.DeleteEntity(taOrderItemInfo);
            }

            foreach (var taOrderItemInfo in lstOi)
            {
                //TaOrderItemInfo taOi = CommonData.TaOrderItem.FirstOrDefault(s => s.ID == taOrderItemInfo.ID);

                //if (taOi != null)
                //{
                //    _control.UpdateEntity(taOrderItemInfo);
                //}
                //else
                //{
                //    _control.AddEntity(taOrderItemInfo);
                //}
                _control.AddEntity(taOrderItemInfo);
            }
        }
        #endregion
    }

    public class DelegateMy
    {
        private static EntityControl _control = new EntityControl();

        public static void SaveCheckOrder(TaCheckOrderInfo taCheckOrderInfo)
        {
            _control.AddEntity(taCheckOrderInfo);

            new SystemData().GetTaCheckOrder();
        }

        public static void UpdateCheckOrder(TaCheckOrderInfo taCheckOrderInfo)
        {
            _control.UpdateEntity(taCheckOrderInfo);

            new SystemData().GetTaCheckOrder();
        }

        #region 后台刷新数据库内容
        public static void RefreshSomeInfo(string iStatus, string strBusDate, string strCheckId)
        {
            SystemData systemData = new SystemData();

            switch (iStatus)
            {
                case "1":
                    systemData.GetTaCheckOrder();
                    break;
                case "2":
                    systemData.GetTaOrderItem();
                    break;
                case "3":
                    systemData.GetTaCheckOrder();
                    systemData.GetTaOrderItem();
                    break;
                case "4":
                    systemData.GetTaMenuCate();
                    break;
                case "5":
                    systemData.GetTaCustomer();
                    break;
                case "6":
                    systemData.GetTaDriver();
                    break;
                case "7":
                    systemData.GetTaMenuItem();
                    break;
                case "8":
                    systemData.GetShowAndPendOrderData(strBusDate, strCheckId);
                    break;
                default:
                    systemData.GetTaCheckOrder();
                    systemData.GetTaOrderItem();
                    systemData.GetTaMenuItem();
                    systemData.GetTaMenuCate();
                    systemData.GetTaCustomer();
                    systemData.GetTaDriver();
                    systemData.GetTaMenuItemOtherChoice();
                    break;
            }
        }
        #endregion

    }
}
