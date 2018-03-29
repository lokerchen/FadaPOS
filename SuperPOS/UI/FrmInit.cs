using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using SuperPOS.Common;
using SuperPOS.UI;

namespace SuperPOS
{
    public partial class FrmInit : DevExpress.XtraEditors.XtraForm
    {
        public FrmInit()
        {
            InitializeComponent();
        }

        private void FrmLogo_Load(object sender, EventArgs e)
        {
            //进度条初始化
            pgInit.Value = 0;
            pgInit.Minimum = 0;

            //加载系统数据
            CommonDAL.InitData();

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
    }
}
