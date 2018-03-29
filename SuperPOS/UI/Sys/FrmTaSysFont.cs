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
    public partial class FrmTaSysFont : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        public FrmTaSysFont()
        {
            InitializeComponent();
        }

        public FrmTaSysFont(int id, string name)
        {
            InitializeComponent();

            usrID = id;
            usrName = name;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMiFont.Text))
            {
                txtMiFont.Text = "9";
            }

            if (string.IsNullOrEmpty(txtCateFont.Text))
            {
                txtCateFont.Text = "9";
            }

            TaSysFontInfo taSysFontInfo = new TaSysFontInfo();
            taSysFontInfo.miFont = txtMiFont.Text;
            taSysFontInfo.cateFont = txtCateFont.Text;
            taSysFontInfo.ID = CommonData.TaSysFont.FirstOrDefault().ID;
            _control.UpdateEntity(taSysFontInfo);
        }

        private void FrmTaSysFont_Load(object sender, EventArgs e)
        {
            new SystemData().GetTaSysFont();

            var lstTaSysFont = CommonData.TaSysFont;

            if (lstTaSysFont.Any())
            {
                txtMiFont.Text = lstTaSysFont.FirstOrDefault().miFont;
                txtCateFont.Text = lstTaSysFont.FirstOrDefault().cateFont;
            }
            else
            {
                txtMiFont.Text = "9";
                txtCateFont.Text = "9";

                TaSysFontInfo taSysFontInfo = new TaSysFontInfo();
                taSysFontInfo.miFont = "9";
                taSysFontInfo.cateFont = "9";
                _control.AddEntity(taSysFontInfo);
            }
        }
    }
}