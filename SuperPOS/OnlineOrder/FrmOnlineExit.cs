﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetServerEmail;
using SuperPOS.Dapper;
using SuperPOS.Domain.Entities;

namespace OnlineOrderPrint
{
    public partial class FrmOnlineExit : Form
    {
        public FrmOnlineExit()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //删除数据表中的数据
            SqlHelper.ClearData(@"DELETE FROM Mail_ID");

            //Application.Exit();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
