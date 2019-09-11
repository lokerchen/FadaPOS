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
    public partial class FrmTaMenuSelect : DevExpress.XtraEditors.XtraForm
    {
        SimpleButton[] btnMenuSet = new SimpleButton[5];

        public int msId = 0;

        private int menuSetId = 0;

        public int MenuSetId
        {
            get { return msId; }
            set { MenuSetId = value; }
        }

        public FrmTaMenuSelect()
        {
            InitializeComponent();
        }

        public FrmTaMenuSelect(int msMainId)
        {
            InitializeComponent();
            menuSetId = msMainId;
        }

        #region 改码类型按钮
        private void SetMsBtn()
        {
            btnMenuSet[0] = btnMs0;
            btnMenuSet[1] = btnMs1;
            btnMenuSet[2] = btnMs2;
            btnMenuSet[3] = btnMs3;
            btnMenuSet[4] = btnMs4;

            for (int i = 0; i < 5; i++)
            {
                btnMenuSet[i].Click += btnMs_Click;
            }

            new SystemData().GetTaMenuSet();

            btnMenuSet[0].Text = "ALL";

            int j = 1;
            foreach (var ms in CommonData.TaMenuSet)
            {
                if (ms.ID == menuSetId) btnMenuSet[j].Appearance.BackColor = Color.RoyalBlue;
                btnMenuSet[j].Text = ms.MSEngName;
                j++;
            }

            for (int i = j; i < 5; i++)
            {
                btnMenuSet[i].Visible = false;
            }
        }

        private void btnMs_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;

            if (btn.Text.Equals("ALL"))
                msId = 0;
            else
            {
                var lstMs = CommonData.TaMenuSet.Where(s => s.MSEngName.Equals(btn.Text));

                if (lstMs.Any())
                {
                    msId = lstMs.FirstOrDefault().ID;
                }
            }

            this.DialogResult = DialogResult.OK;
            Hide();

        }
        #endregion

        private void FrmTaMenuSelect_Load(object sender, EventArgs e)
        {
            SetMsBtn();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}