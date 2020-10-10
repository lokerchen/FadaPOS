using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;
using SuperPOS.UI;

namespace SuperPOS
{
    public partial class FrmInit : DevExpress.XtraEditors.XtraForm
    {
        private static EntityControl _control = new EntityControl();

        public FrmInit()
        {
            InitializeComponent();
        }

        private void FrmLogo_Load(object sender, EventArgs e)
        {
            //进度条初始化
            pgInit.Value = 0;
            pgInit.Minimum = 0;

            //打印模板
            //new SystemData().GetTaPreview();

            //DelegatePreview handler = DelegatePrt.SaveShowOrderModelPreview;
            //IAsyncResult result = handler.BeginInvoke(null, null);

            //加载系统数据
            CommonDAL.InitData();

            //handler.EndInvoke(result);


            //加载设置图片
            string imgLogo = "";

            timerData.Enabled = true;
        }

        private void timerData_Tick(object sender, EventArgs e)
        {
            if (pgInit.Value < pgInit.Maximum)
            {
                pgInit.Value++;
                lblMsg.Text = PubComm.INIT_MSG + pgInit.Value + @"%";
            }
            else
            {
                timerData.Enabled = false;
                this.Hide();

                FrmShow frmShow = new FrmShow();
                frmShow.ShowDialog();}
        }

        #region Show Order模板
        public static void SaveShowOrderModelPreview()
        {
            try
            {
                string content = @"";

                TaPreviewInfo taPreview = new TaPreviewInfo();

                foreach (var f in new DirectoryInfo(PrtStatic.PRT_TEMPLATE_FILE_PATH).GetFiles())
                {
                    if (f.Length > 0)
                    {
                        switch (f.Name)
                        {
                            case @"taKitchen.txt":
                                taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_KITCHEN_PRE;
                                break;
                            case @"taReceipt.txt":
                                taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_RECEIPT_PRE;
                                break;
                            case @"taBill.txt":
                                taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_BILL_PRE;
                                break;
                            case @"ta.txt":
                                taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_ALL_PRE;
                                break;
                            case @"showorder.txt":
                                taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_SHOWORDER_PRE;
                                break;
                        }

                        taPreview.PreviewFileName = f.Name;
                        StreamReader objReader = new StreamReader(PrtStatic.PRT_TEMPLATE_FILE_PATH + f.Name, Encoding.UTF8);
                        taPreview.PreviewContent = objReader.ReadToEnd();

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
    }
}
