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
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.TaAdmin
{
    public partial class FrmSysCtrl : DevExpress.XtraEditors.XtraForm
    {
        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmSysCtrl()
        {
            InitializeComponent();
        }

        #region Save保存事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TaSysCtrlInfo taSysCtrl = new TaSysCtrlInfo();
                 
                taSysCtrl.ShopName = txtShopName.Text;
                taSysCtrl.ShopAddress = txtShopAddress.Text;
                taSysCtrl.IsShopDetailsReadOnly = chkShopDetailReadOnly.Checked ? "Y" : "N";

                new SystemData().GetTaSysCtrl();
                var lstTaSysCtrl = CommonData.TaSysCtrl;

                if (lstTaSysCtrl.Any())
                {
                    taSysCtrl.ID = lstTaSysCtrl.FirstOrDefault().ID;
                    _control.UpdateEntity(taSysCtrl);
                }
                else
                {
                    _control.AddEntity(taSysCtrl);
                }

                CommonTool.ShowMessage(@"Save successful!");
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSysCtrl_Load(object sender, EventArgs e)
        {
            try
            {
                new SystemData().GetTaSysCtrl();
                var lstTaSysCtrl = CommonData.TaSysCtrl;

                if (lstTaSysCtrl.Any())
                {
                    TaSysCtrlInfo taSysCtrl = new TaSysCtrlInfo();
                    taSysCtrl = lstTaSysCtrl.FirstOrDefault();
                    txtShopName.Text = taSysCtrl.ShopName;
                    txtShopAddress.Text = taSysCtrl.ShopAddress;
                    chkShopDetailReadOnly.Checked = taSysCtrl.IsShopDetailsReadOnly.Equals("Y");
                }
                else
                {
                    txtShopName.Text = "";
                    txtShopAddress.Text = "";
                    chkShopDetailReadOnly.Checked = false;
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            asfc.controllInitializeSize(this);
        }

        private void FrmSysCtrl_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}