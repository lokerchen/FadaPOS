using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPOS.Print
{
    public class WbPrtStatic
    {
        //打印模板文件夹所在位置
        public static string PRT_TEMPLATE_FILE_PATH = System.Environment.CurrentDirectory + @"/PrintTemplate/";

        //Shop文件名
        public static string PRT_TEMPLATE_FILE_NAME_SHOP = "Shop.html";

        #region Shop模板内参数为主
        //table Universal Print基本表格
        public static string PRT_PARAM_TBL_UNIVERSAL_PRINT = @"Tbl_UniversalPrint";

        //tr 餐厅Address
        public static string PRT_PARAM_TBL_UNIVERSAL_PRINT_TR_PRINT_ADDRESS = @"Tr_PrintAddress";
        //td 餐厅Address
        public static string PRT_PARAM_TBL_UNIVERSAL_PRINT_TR_TD_PRINT_ADDRESS = @"Td_PrintAddress";

        //tr 餐厅Telephone
        public static string PRT_PARAM_TBL_UNIVERSAL_PRINT_TR_PRINT_TEL = @"Tr_PrintTel";
        //td 餐厅Telephone
        public static string PRT_PARAM_TBL_UNIVERSAL_PRINT_TR_TD_PRINT_TEL = @"Td_PrintTel";

        //tr 餐厅VAT No.
        public static string PRT_PARAM_TBL_UNIVERSAL_PRINT_TR_VATNO = @"Tr_VATNo";
        //td 餐厅VAT No.
        public static string PRT_PARAM_TBL_UNIVERSAL_PRINT_TR_TD_VATNO = @"Td_VATNo";

        //Shop Time
        public static string PRT_PARAM_TBL_SHOP_TIME = @"Tbl_ShopTime";

        //基本订单信息
        public static string PRT_PARAM_TBL_BASIC_ORDER = "Tbl_BasicOrder";
        public static string PRT_PARAM_TBL_BASIC_ORDER_TD_ORDER_DATE = "Td_OrderDate";
        public static string PRT_PARAM_TBL_BASIC_ORDER_TD_ORDER_TIME = "Td_OrderTime";
        public static string PRT_PARAM_TBL_BASIC_ORDER_TD_STAFF = "Td_Staff";
        public static string PRT_PARAM_TBL_BASIC_ORDER_TD_ODER_NO = "Td_OrderNo";

        //订单信息
        public static string PRT_PARAM_TBL_ORDER_TR_ORDER_ITEM = "Tr_OrderItem";
        public static string PRT_PARAM_TBL_ORDER_TR_ORDER_ITEM_TD_MI_CODE = "Td_MiCode";
        public static string PRT_PARAM_TBL_ORDER_TR_ORDER_ITEM_TD_MI_QTY = "Td_MiQty";
        public static string PRT_PARAM_TBL_ORDER_TR_ORDER_ITEM_TD_MI_ENGNAME = "Td_MiEngName";
        public static string PRT_PARAM_TBL_ORDER_TR_ORDER_ITEM_TD_MI_OTHERNAME = "Span_MiOtherName";
        public static string PRT_PARAM_TBL_ORDER_TR_ORDER_ITEM_TD_MI_PRICE = "Td_MiPrice";

        public static string PRT_PARAM_TBL_ORDER_TD_ITEM_COUNT = "Td_ItemCount";
        public static string PRT_PARAM_TBL_ORDER_TD_SUB_TOTAL = "Td_SubTotal";
        public static string PRT_PARAM_TBL_ORDER_TD_TOTAL = "Td_Total";

        //付款方式
        public static string PRT_PARAM_TD_PAY_TYPE = "Td_PayType";

        //底部信息
        public static string PRT_PARAM_TD_MSG_1 = "Td_Msg1";
        public static string PRT_PARAM_TD_MSG_2 = "Td_Msg2";
        public static string PRT_PARAM_TD_MSG_3 = "Td_Msg3";
        public static string PRT_PARAM_TD_MSG_4 = "Td_Msg4";
        public static string PRT_PARAM_TD_MSG_5 = "Td_Msg5";

        #endregion
    }
}
