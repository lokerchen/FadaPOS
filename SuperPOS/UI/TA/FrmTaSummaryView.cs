using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SuperPOS.Common;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaSummaryView : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        //默认语言标识状态位
        public int iLangStatusId = PubComm.MENU_LANG_DEFAULT;

        public FrmTaSummaryView()
        {
            InitializeComponent();
        }

        private void FrmTaSummaryView_Load(object sender, EventArgs e)
        {
            ChangeLang(iLangStatusId);
            asfc.controllInitializeSize(this);
        }

        private void FrmTaSummaryView_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            iLangStatusId = iLangStatusId == PubComm.MENU_LANG_DEFAULT
                            ? PubComm.MENU_LANG_OTHER
                            : PubComm.MENU_LANG_DEFAULT;
            ChangeLang(iLangStatusId);
        }

        #region 按钮语言切换显示
        /// <summary>
        /// 按钮语言切换显示
        /// </summary>
        /// <param name="iLan">语言状态位</param>
        private void ChangeLang(int iLan)
        {
            if (iLan == PubComm.MENU_LANG_DEFAULT)
            {
                #region 英文

                lblTsTotalTA.Text = @"Total T/A";
                lblTsCollection.Text = @"Collection";
                lblTsDelivery.Text = @"Delivery";
                lblTsShop.Text = @"Shop";
                lblTsFastFood.Text = @"Fast Food";
                lblTsTotalOrder.Text = @"Total Order";
                lblTsTotalCol.Text = @"Total Col";
                lblTsTotalDel.Text = @"Total Del";
                lblTsTotalShop.Text = @"Total Shop";
                lblTsTotalFF.Text = @"Total FF";
                lblTsTotalDc.Text = @"Total D/C";
                lblTsDcCash.Text = @"D/C(Cash)";
                lblTsDcCard.Text = @"D/C(Other)";

                lblEsTotalEatIn.Text = @"Total Eat In";
                lblEsSc.Text = @"S/C";
                lblEsTotalOrder.Text = @"Total Order";

                lblStTotalTakings.Text = @"Total Takings";
                lblStTotalOrder.Text = @"Total Order";
                lblStTotalVat.Text = @"Total VAT";

                gbCurrentTime.Text = @"Current Time";
                gbCurrentDate.Text = @"Current Date";

                lblPtOrder1.Text = @"Order";
                lblPtTotal1.Text = @"Total";
                lblPtTips1.Text = @"Tips";

                lblPtOrder2.Text = @"Order";
                lblPtTotal2.Text = @"Total";
                lblPtTips2.Text = @"Tips";

                lblPtOrder3.Text = @"Order";
                lblPtTotal3.Text = @"Total";
                lblPtTips3.Text = @"Tips";

                lblPtOrder4.Text = @"Order";
                lblPtTotal4.Text = @"Total";
                lblPtTips4.Text = @"Tips";

                lblPtOrder5.Text = @"Order";
                lblPtTotal5.Text = @"Total";
                lblPtTips5.Text = @"Tips";

                btnLanguage.Text = @"LANGUAGE";
                btnExit.Text = @"Exit";

                #endregion
            }
            else
            {
                #region 汉语
                lblTsTotalTA.Text = @"外卖总数";
                lblTsCollection.Text = @"拿餐";
                lblTsDelivery.Text = @"送餐";
                lblTsShop.Text = @"现场";
                lblTsFastFood.Text = @"快餐";
                lblTsTotalOrder.Text = @"单总数";
                lblTsTotalCol.Text = @"拿餐总数";
                lblTsTotalDel.Text = @"送餐总数";
                lblTsTotalShop.Text = @"现场总数";
                lblTsTotalFF.Text = @"快餐总数";
                lblTsTotalDc.Text = @"送餐费总数";
                lblTsDcCash.Text = @"送餐费现金";
                lblTsDcCard.Text = @"送餐费其他";

                lblEsTotalEatIn.Text = @"堂吃总数";
                lblEsSc.Text = @"服务费";
                lblEsTotalOrder.Text = @"点单总数";

                lblStTotalTakings.Text = @"全部总数";
                lblStTotalOrder.Text = @"点单总数";
                lblStTotalVat.Text = @"VAT总数";

                gbCurrentTime.Text = @"当前时间";
                gbCurrentDate.Text = @"当前日期";

                lblPtOrder1.Text = @"单";
                lblPtTotal1.Text = @"总数";
                lblPtTips1.Text = @"";

                lblPtOrder2.Text = @"单";
                lblPtTotal2.Text = @"总数";
                lblPtTips2.Text = @"小费";

                lblPtOrder3.Text = @"单";
                lblPtTotal3.Text = @"总数";
                lblPtTips3.Text = @"小费";

                lblPtOrder4.Text = @"单";
                lblPtTotal4.Text = @"总数";
                lblPtTips4.Text = @"小费";

                lblPtOrder5.Text = @"单";
                lblPtTotal5.Text = @"总数";
                lblPtTips5.Text = @"小费";

                btnLanguage.Text = @"语言";
                btnExit.Text = @"退出";

                #endregion
            }

        }
        #endregion
    }
}