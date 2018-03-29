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
    }
}