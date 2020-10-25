﻿using System;
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
    public partial class FrmTaCustReadyTime : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private DateTime dt = DateTime.Now;

        //点击按钮名字
        private string objName = "txtHour";

        public string strShopTime
        {
            get { return txtHour.Text + @":" + txtMinute.Text; }
            set { strShopTime = value; }
        }

        public FrmTaCustReadyTime()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            strShopTime = @"";
            Close();
        }

        private void FrmTaCustReadyTime_Load(object sender, EventArgs e)
        {
            SetNumClick();
            SetAddClick();

            txtHour.Text = dt.Hour.ToString();
            txtMinute.Text = dt.Minute.ToString();

            asfc.controllInitializeSize(this);
        }

        private void FrmTaCustReadyTime_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        #region 数字按钮输入事件
        private void btnNum_Click(object sender, EventArgs e)
        {
            var btn = (SimpleButton)sender;

            string tmpHour = txtHour.Text;
            string tmpMinute = txtMinute.Text;

            if (objName.Equals("txtHour"))
            {
                if (txtHour.Text.Length >= 2)
                {
                    txtHour.Text = txtHour.Text.Substring(1, txtHour.Text.Length - 1) + btn.Text;
                }
                else
                    txtHour.Text += btn.Text;

                if (Convert.ToInt32(txtHour.Text) >= 24) txtHour.Text = tmpHour;
            }
            else if (objName.Equals("txtMinute"))
            {
                if (txtMinute.Text.Length >= 2)
                {
                    txtMinute.Text = txtMinute.Text.Substring(1, txtMinute.Text.Length - 1) + btn.Text;
                }
                else
                    txtMinute.Text += btn.Text;

                if (Convert.ToInt32(txtMinute.Text) >= 60) txtMinute.Text = tmpMinute;
            }
        }
        #endregion

        #region 增加分钟按钮输入事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var btn = (SimpleButton)sender;

            DateTime dtAdd = dt.AddMinutes(Convert.ToDouble(btn.Text.Replace("+", "")));

            txtHour.Text = dtAdd.Hour.ToString();
            txtMinute.Text = dtAdd.Minute.ToString();
        }
        #endregion

        #region 数字键盘点击事件赋值
        /// <summary>
        /// 数字键盘点击事件赋值
        /// </summary>
        private void SetNumClick()
        {
            btn1.Click += btnNum_Click;
            btn2.Click += btnNum_Click;
            btn3.Click += btnNum_Click;
            btn4.Click += btnNum_Click;
            btn5.Click += btnNum_Click;
            btn6.Click += btnNum_Click;
            btn7.Click += btnNum_Click;
            btn8.Click += btnNum_Click;
            btn9.Click += btnNum_Click;
            btn0.Click += btnNum_Click;
        }
        #endregion

        #region 增加分钟数点击事件赋值
        /// <summary>
        /// 增加分钟数点击事件赋值
        /// </summary>
        private void SetAddClick()
        {
            btnAdd5.Click += btnAdd_Click;
            btnAdd10.Click += btnAdd_Click;
            btnAdd15.Click += btnAdd_Click;
            btnAdd20.Click += btnAdd_Click;
            btnAdd25.Click += btnAdd_Click;
            btnAdd30.Click += btnAdd_Click;
            btnAdd35.Click += btnAdd_Click;
            btnAdd40.Click += btnAdd_Click;
            btnAdd45.Click += btnAdd_Click;
            btnAdd50.Click += btnAdd_Click;
            btnAdd55.Click += btnAdd_Click;
            btnAdd60.Click += btnAdd_Click;
        }
        #endregion

        private void btnClr_Click(object sender, EventArgs e)
        {
            if (objName.Equals("txtHour"))
            {
                txtHour.Text = "";
            }
            else if (objName.Equals("txtMinute"))
            {
                txtMinute.Text = "";
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}