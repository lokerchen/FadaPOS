namespace SuperPOS.Print
{
    public class PrtStatic
    {
        //10号字体每行最多可打印字符数
        public static int PRT_LINE_SIZE = 39;

        //打印行高 1/100英寸
        public static int PRT_LINE_HEIGHT = 100;

        //字体大小 1/10英寸
        public static int PRT_FONT_SIZE = 10;

        //分割符
        public static string PRT_SPLIT_CHAR = "-";

        //15号字体每行最多可打印字符数
        public static int PRT_LINE_SIZE_15 = 27;

        //20号字体每行最多可打印字符数
        public static int PRT_LINE_SIZE_20 = 20;

        ////打印OrderItem详细列表时Code字符长度为3
        //public static int PRT_OI_DETAIL_CODE = 3;

        ////打印OrderItem详细列表时Code字符长度为3
        //public static int PRT_OI_DETAIL_CODE = 3;

        //公司名称
        public static string PRT_COMP_NAME = "Powered by Milpo Technologies(萬保科技)";

        //公司网址
        public static string PRT_COMP_WEBSITE = "http://www.milpo.co.uk";

        //不打印OrderItem的基准高度
        public static int PRT_PAPER_HIGHT = 415;

        //每一行OrderItem的高度
        public static int PRT_PAPER_ROWHIGHT = 20;

        //打印模板文件夹所在位置
        public static string PRT_TEMPLATE_FILE_PATH = System.Environment.CurrentDirectory + @"/PrintTemplate/";

        //TA打印模板
        public static string PRT_TEMPLATE_TA = @"ta.txt";

        //General Setting 1 Print Lanuage
        public static string PRT_GEN_SET1_LAN_ENG = @"English";
        public static string PRT_GEN_SET1_LAN_Other = @"Other";
        public static string PRT_GEN_SET1_LAN_Both = @"Both";

        //General Setting 1 FontSize
        public static string PRT_GEN_SET1_FONT_SIZE_8 = @"8";
        public static string PRT_GEN_SET1_FONT_SIZE_10 = @"10";
        public static string PRT_GEN_SET1_FONT_SIZE_12 = @"12";
        public static string PRT_GEN_SET1_FONT_SIZE_14 = @"14";
        public static string PRT_GEN_SET1_FONT_SIZE_16 = @"16";
        public static string PRT_GEN_SET1_FONT_SIZE_18 = @"18";
        public static string PRT_GEN_SET1_FONT_SIZE_20 = @"20";
    }
}