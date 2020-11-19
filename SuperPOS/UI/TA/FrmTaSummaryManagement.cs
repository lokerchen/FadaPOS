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
    public partial class FrmTaSummaryManagement : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmTaSummaryManagement()
        {
            InitializeComponent();
        }

        private void FrmTaSummaryManagement_Load(object sender, EventArgs e)
        {
            asfc.controllInitializeSize(this);
        }

        private void FrmTaSummaryManagement_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}