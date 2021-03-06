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
    public partial class FrmCancelOrder : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmCancelOrder()
        {
            InitializeComponent();
        }

        private void FrmCancelOrder_Load(object sender, EventArgs e)
        {
            asfc.controllInitializeSize(this);
        }

        private void FrmCancelOrder_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
        
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}