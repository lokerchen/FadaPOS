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

namespace SuperPOS.UI.TA
{
    public partial class FrmTaCashDrawSet : DevExpress.XtraEditors.XtraForm
    {
        private readonly EntityControl _control = new EntityControl();

        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        public FrmTaCashDrawSet()
        {
            InitializeComponent();
        }

        public FrmTaCashDrawSet(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;}

        private void FrmTaCashDrawSet_Load(object sender, EventArgs e)
        {
            new SystemData().GetTaCashDrawSet();

            if (CommonData.TaCashDrawSet.Any())
            {
                var lstTaCashDraw = CommonData.TaCashDrawSet.FirstOrDefault();
                chkCashDrawSet.Checked = lstTaCashDraw.IsUseCashDraw.Equals("Y");
                if (chkCashDrawSet.Checked)
                {
                    txtPwd.Enabled = true;
                    txtPwd.Text = lstTaCashDraw.CashDrawPwd;
                }
                else
                {
                    txtPwd.Enabled = false;
                    txtPwd.Text = "";
                }
            }
            else
            {
                chkCashDrawSet.Checked = false;
                txtPwd.Enabled = false;
                txtPwd.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TaCashDrawSetInfo taCashDrawSetInfo = new TaCashDrawSetInfo();

            taCashDrawSetInfo.IsUseCashDraw = chkCashDrawSet.Checked ? "Y" : "N";

            taCashDrawSetInfo.CashDrawPwd = chkCashDrawSet.Checked ? txtPwd.Text : "";

            new SystemData().GetTaCashDrawSet();

            try
            {
                if (CommonData.TaCashDrawSet.Any())
                {
                    taCashDrawSetInfo.ID = CommonData.TaCashDrawSet.FirstOrDefault().ID;
                    _control.UpdateEntity(taCashDrawSetInfo);
                }
                else
                {
                    _control.AddEntity(taCashDrawSetInfo);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void chkCashDrawSet_CheckedChanged(object sender, EventArgs e)
        {
            txtPwd.Enabled = chkCashDrawSet.Checked;
        }
    }
}