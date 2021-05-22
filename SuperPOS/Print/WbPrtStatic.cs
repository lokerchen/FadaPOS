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
        public static string PRT_TEMPLATE_FILE_PATH = Environment.CurrentDirectory + @"\PrintTemplate\";

        //Shop文件名
        public static string PRT_TEMPLATE_FILE_NAME_SHOP = "Shop";
        public static string PRT_TEMPLATE_FILE_NAME_KITCHEN_SHOP = "ShopKitchen";
        //Collection文件名
        public static string PRT_TEMPLATE_FILE_NAME_COLLECTION = "Collection";
        public static string PRT_TEMPLATE_FILE_NAME_KITCHEN_COLLECTION = "CollectionKitchen";
        //Delivery文件名
        public static string PRT_TEMPLATE_FILE_NAME_DELIVERY = "Delivery";
        public static string PRT_TEMPLATE_FILE_NAME_KITCHEN_DELIVERY = "DeliveryKitchen";
        //Fast Food
        public static string PRT_TEMPLATE_FILE_NAME_SHOP_FASTFOOD = "FastFood";
        public static string PRT_TEMPLATE_FILE_NAME_KITCHEN_FASTFOOD = "FastFoodKitchen";

        public static string PRT_TEMPLATE_FILE_NAME_SHOP_FF = "ff";
        public static string PRT_TEMPLATE_FILE_NAME_KITCHEN = "Kitchen";
        public static string PRT_TEMPLATE_FILE_NAME_RECEIPT = "Receipt";
        public static string PRT_TEMPLATE_FILE_ALL_SHOP = "AllShop";
        public static string PRT_TEMPLATE_FILE_ALL_SHOP_FASTFOOD = "AllShopFastFood";
        public static string PRT_TEMPLATE_FILE_ALL_SHOP_RECEIPT = "AllShopReceipt";
        public static string PRT_TEMPLATE_FILE_ALL_SHOP_RECEIPT_FASTFOOD = "AllShopReceiptFastFood";

        public static string PRT_TEMPLATE_FILE_NAME_DRIVER_COPY = "dc";

        public static string PRT_CLASS_BILL = @"Bill";
        public static string PRT_CLASS_KITCHEN = @"Kitchen";
        public static string PRT_CLASS_RECEIPT = @"Receipt";
        public static string PRT_CLASS_ALL = @"All";
        public static string PRT_CLASS_ALL_AND_RECEIPT = @"AllReceipt";

        public static string PRT_AS = @"as";

        public static string PRT_TEMPLATE_FILE_NAME_SUFFIX = ".html";
        
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

        #region Shop模板中需要替换的字符串

        public static string PRT_PRINT_DISPLAY = "display:";
        public static string PRT_PRINT_DISPLAY_NONE = "none";
        
        public static string PRT_PRINT_LOGO = "<div style=\"display:";
        public static string PRT_PRINT_ADDR = "<td id=\"Td_PrintAddress\" style=\"display:";
        public static string PRT_PRINT_TEL = "<td id=\"Td_PrintTel\" style=\"display:";
        public static string PRT_PRINT_VATNO = "<td id=\"Td_VATNo\" style=\"display:";
        public static string PRT_PRINT_SHOPTIME = "<table id=\"Tbl_ShopTime\" style=\"display:";
        public static string PRT_PRINT_ORDER_DATE = "<td id=\"Td_OrderDate\" style=\"display:";
        public static string PRT_PRINT_ORDER_TIME = "<td id=\"Td_OrderTime\" style=\"display:";
        public static string PRT_PRINT_STAFF = "<td id=\"Td_Staff\" style=\"display:";
        public static string PRT_PRINT_ORDER_NO = "<td id=\"Td_OrderNo\" style=\"display:";
        public static string PRT_PRINT_ORDER_ITEM = "<tr id=\"Tr_OrderItem\"";
        //public static string PRT_PRINT_ITEM_COUNT = "<td id=\"Td_ItemCount\"";
        //public static string PRT_PRINT_SUB_TOTAL = "<td id=\"Td_SubTotal\"";
        //public static string PRT_PRINT_TOTAL = "<td id=\"Td_Total\"";
        //public static string PRT_PRINT_PAY_TYPE = "<td id=\"Td_PayType\"";

        public static string PRT_PRINT_FONT_SIZE_ENG = "<span id=\"Span_MiEngName\" style=\"display:;font-size:";
        public static string PRT_PRINT_FONT_SIZE_OTHER = "<span id=\"Span_MiOtherName\" style=\"display:;font-size:";

        public static string PRT_PRINT_REFNO = "<table id=\"Tbl_RefNo\" style=\"display:";

        public static string PRT_PRINT_TBL_CUST_BASIC = "<table id=\"Tbl_CustBasic\" style=\"display:\"";
        public static string PRT_PRINT_TBL_CUST_INFO = "<table id=\"Tbl_CustInfo\" style=\"display:\"";

        public static string PRT_PRINT_TD_CUST_NAME = "<td id=\"Td_CustName\" style=\"font-size:\"";
        public static string PRT_PRINT_TD_CUST_PHONE = "<td id=\"Td_CustPhone\" style=\"font-size:\"";
        public static string PRT_PRINT_TD_CUST_DIST = "<td id=\"Td_CustDist\" style=\"font-size:";
        public static string PRT_PRINT_TD_CUST_MAP_REF = "<td id=\"Td_CustMapRef\" style=\"font-size:";
        public static string PRT_PRINT_TD_CUST_ADDR = "<td id=\"Td_CustAddr\" style=\"font-size:";
        public static string PRT_PRINT_TD_CUST_POST_CODE = "<td id=\"Td_CustPostCode\" style=\"font-size:";
        public static string PRT_PRINT_TBL_PAY_TYPE = "<table id=\"Tbl_PayType\" style=\"display:\"";
        public static string PRT_PRINT_TBL_VAT = "<table id=\"Tbl_Vat\" style=\"display:\"";
        
        #endregion
    }
}
