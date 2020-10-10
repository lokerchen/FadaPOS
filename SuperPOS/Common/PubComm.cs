
namespace SuperPOS.Common
{
    public class PubComm
    {
        //启动时错误提示
        public static string START_ONLY_ONE_APP = @"Only run one Application at a time!";
        //开启软件提示文字
        public static string INIT_MSG = @"Loading system data......";
        //log4net配置文件名
        public static string LOG4NET_CONFIG_FILE_NAME = @"log4net.config";

        //NHibernate配置文件
        public static string NHIBERNATE_CONFIG_FILE_NAME = @"hibernate.cfg.xml";

        //星期
        public static string[] WORD_DAY = new string[] { "Monday", "Tuesday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        //Menu Item中的其他属性
        public static string[] MENUITEM_OTHER_SET = new[] {"Unavailable", "Negative Price", "Discountable", "Without VAT", "Inventory Check"};

        //语言状态位
        //默认为1，即：英文
        public static int MENU_LANG_DEFAULT = 1;
        //其他语言
        public static int MENU_LANG_OTHER = 2;

        //菜品类型
        //主菜品
        public static int MENU_ITEM_MAIN = 1;
        //子菜品
        public static int MENU_ITEM_CHILD = 2;
        //改码
        public static int MENU_ITEM_APPEND = 3;

        //改码类型
        public static string[] EXTRA_MENU_EDIT_TYPE = new[] {"Vegetable", "Vegetable2", "Bean", "Meat", "Seafood", "Sauce", "Taste", "Fruit", "Cooking", "Others"};
        //改码Btn类型
        public static string[] EXTRA_MENU_BTN_TYPE = new[] {"Taste Item", "Drink Item"};
        //前端改码类型
        public static string[] FORM_BTN_TYPE = new[] {"LESS(-)", "ADD(+)", "MORE(++)", "WITHOUT(X)", "CHANGE(/)"};
        //前端实际使用类型
        public static string[] FORM_USE_TYPE = new[] {"-", "+", "++", "X", "/"};

        //订单类型
        public static string ORDER_TYPE_SHOP = "SHOP";
        public static string ORDER_TYPE_COLLECTION = "COLLECTION";
        public static string ORDER_TYPE_DELIVERY = "DELIVERY";
        public static string ORDER_TYPE_FAST_FOOD = "FAST FOOD";
        public static string ORDER_TYPE_EAT_IN = "EAT IN";

        //查询所有磁盘
        public static string SELECT_WIN32_LOGICALDISK = @"SELECT * FROM WIN32_LOGICALDISK";

        //权限类型
        public static string ACCESS_TAKEAWAY = "TAKEAWAY";
        public static string ACCESS_QUICKFOOD = "QUICKFOOD";
        public static string ACCESS_EATIN = "EATIN";
        public static string ACCESS_GENERAL = "GENERAL";

        //数据库名称，备份和还原数据库时使用，与配置文件中的数据库名称保持一致
        public static string DB_NAME = "SuperPOS2.db";

        #region 系统常量
        //账单
        public static string SYS_VALUE_CHECK_CODE = "1001";
        public static string SYS_DESC_CHECK_CODE = "CHECKCODE";

        //Free Food Item Amount
        public static string SYS_VALUE_FREE_FOOD_ITEM_AMOUNT = "1002";
        public static string SYS_DESC_FREE_FOOD_ITEM_AMOUNT = "FREEFOODITEMAMOUNT";

        //Business Date
        public static string SYS_VALUE_BUS_DATE = "1004";
        public static string SYS_DESC_BUS_DATE = "BUSINESS DATE";
        #endregion

        public static string[] PRT_NUMBER_OF_COPY = new[] {"1", "2", "3"};
        public static string[] PRT_LANGUAGE = new[] { "Both", "English", "Other"};
        public static string PRT_LANGUAGE_BOTH = "Both";
        public static string PRT_LANGUAGE_ENG = "English";
        public static string PRT_LANGUAGE_OTHER = "Other";
        public static string[] PRT_FONT_SIZE = new[] {"12","13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"};
        public static string[] PRT_KITCHEN_PRINT_PRICE_DISH_CODE = new[] {"Price", "Dish Code"};
        public static string[] PRT_KITCHEN_PRINT_PRICE = new[] {"Price", "Dish Code"};
        public static string[] PRT_KITCHEN_PRINT_DISH_CODE = new[] {"Price", "Dish Code"};

        public static string PRT_PARAM_DISPALY = "display:";
        public static string PRT_PARAM_DISPALY_NONE = "display:none";
        public static string PRT_PARAM_FONT_SIZE = "font-size:";
    }
}
