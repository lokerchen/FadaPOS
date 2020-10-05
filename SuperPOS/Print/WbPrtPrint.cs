using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SuperPOS.Print
{
    public class WbPrtPrint
    {
        public WebBrowser wb = new WebBrowser();

        public void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (wb.ReadyState < WebBrowserReadyState.Complete) return;

            string keyName = @"Software\Microsoft\Internet Explorer\PageSetup\";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null)
                {
                    key.SetValue("footer", ""); //设置页脚为空
                    key.SetValue("header", ""); //设置页眉为空
                    //key.SetValue("Print_Background", true); //设置打印背景颜色
                    key.SetValue("margin_bottom", 0); //设置下页边距为0
                    key.SetValue("margin_left", 0); //设置左页边距为0
                    key.SetValue("margin_right", 0); //设置右页边距为0
                    key.SetValue("margin_top", 0); //设置上页边距为0

                    wb.Print();
                    //isPrint = true;

                    wb.DocumentCompleted -= wb_DocumentCompleted;
                }
            }
        }
    }
}
