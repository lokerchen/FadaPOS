using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SuperPOS.Common;

namespace SuperPOS.UI.TA
{
    public partial class FrmCashDraw : Form
    {
        public FrmCashDraw()
        {
            InitializeComponent();
        }

        #region Clear按钮
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPwd.Text = "";
        }

        #endregion

        #region 数字按钮输入事件
        private void btn_Click(object sender, EventArgs e)
        {
            SimpleButton btn = (SimpleButton)sender;

            txtPwd.Text += btn.Text;
        }
        #endregion

        private void FrmCashDraw_Load(object sender, EventArgs e)
        {
            #region 数字按钮Click
            btn1.Click += this.btn_Click;
            btn2.Click += this.btn_Click;
            btn3.Click += this.btn_Click;
            btn4.Click += this.btn_Click;
            btn5.Click += this.btn_Click;
            btn6.Click += this.btn_Click;
            btn7.Click += this.btn_Click;
            btn8.Click += this.btn_Click;
            btn9.Click += this.btn_Click;
            btn0.Click += this.btn_Click;
            #endregion
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool isOpenCashDrawSuccess = CommonDAL.OpenCashDraw(true, txtPwd.Text);

            if (!isOpenCashDrawSuccess)
                MessageBox.Show(PubComm.CASH_DRAW_INFO, PubComm.CASH_DRAW_TEXT_TITLE, MessageBoxButtons.OK);
            else
                this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
