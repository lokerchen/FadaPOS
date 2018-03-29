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
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.Sys
{
    public partial class FrmShopDetail : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        public FrmShopDetail()
        {
            InitializeComponent();
        }

        public FrmShopDetail(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        #region 保存按钮
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtShopName.Text))
            {
                CommonTool.ShowMessage("Shift Name is empty,please enter!");
                return;
            }

            if (string.IsNullOrEmpty(txtShopAddr.Text))
            {
                CommonTool.ShowMessage("Shift Addr is empty,please enter!");
                return;
            }

            if (string.IsNullOrEmpty(txtTelNo.Text))
            {
                CommonTool.ShowMessage("Telephone No. is empty,please enter!");
                return;
            }

            if (string.IsNullOrEmpty(txtVatNo.Text))
            {
                CommonTool.ShowMessage("VAT No. is empty,please enter!");
                return;
            }

            try
            {
                ShopDetailInfo shopDetailInfo = new ShopDetailInfo();
                shopDetailInfo.ShopName = txtShopName.Text;
                shopDetailInfo.ShopAddr = txtShopAddr.Text;
                shopDetailInfo.ShopTelNo = txtTelNo.Text;
                shopDetailInfo.ShopVATNo = txtVatNo.Text;

                if (CommonData.ShopDetail.Any())
                {
                    shopDetailInfo.ID = CommonData.ShopDetail.FirstOrDefault().ID;
                    _control.UpdateEntity(shopDetailInfo);
                }
                else
                {
                    _control.AddEntity(shopDetailInfo);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }
        #endregion

        #region 窗口加载
        private void FrmShopDetail_Load(object sender, EventArgs e)
        {
            new SystemData().GetShopDetail();

            try
            {
                if (CommonData.ShopDetail.Any())
                {
                    ShopDetailInfo shopDetailInfo = new ShopDetailInfo();
                    shopDetailInfo = CommonData.ShopDetail.FirstOrDefault();
                    txtShopName.Text = shopDetailInfo.ShopName;
                    txtShopAddr.Text = shopDetailInfo.ShopAddr;
                    txtTelNo.Text = shopDetailInfo.ShopTelNo;
                    txtVatNo.Text = shopDetailInfo.ShopVATNo;
                }
                else
                {
                    txtShopName.Text = "";
                    txtShopAddr.Text = "";
                    txtTelNo.Text = "";
                    txtVatNo.Text = "";
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.Name, ex);
            }

        }
        #endregion
    }
}