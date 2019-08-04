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
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.TA
{
    public partial class FrmTAOtherChoice : DevExpress.XtraEditors.XtraForm
    {
        //标注是Second:2还是Third Choices:3
        private int miType = 2; 

        //关联菜品ID
        private int miId = 0;

        //按钮
        private CheckEdit[] chkOtherChoice = new CheckEdit[20];

        //菜品列表
        private List<TaMenuItemOtherChoiceInfo>  lstOtherChoice = new List<TaMenuItemOtherChoiceInfo>();

        public List<TaMenuItemOtherChoiceInfo> lstReturnChoice = new List<TaMenuItemOtherChoiceInfo>();

        //No of Options
        public int NoOfOption = 0;

        public FrmTAOtherChoice()
        {
            InitializeComponent();
        }

        public FrmTAOtherChoice(int mType, int mID, List<TaMenuItemOtherChoiceInfo> lstList)
        {
            InitializeComponent();
            miType = mType;
            miId = mID;
            lstOtherChoice = lstList;

            if (lstList.Any())
            {
                NoOfOption = Convert.ToInt32(lstList.FirstOrDefault(s => s.MiID == mID && s.MiType == mType).OptionNum);
            }
        }

        private void FrmTAOtherChoice_Load(object sender, EventArgs e)
        {
            lblctlTxt.Text = miType == 2 ? @"Second Choice" : @"Third Choice";

            SetOtherChoiceBtn();

            int i = 0;

            foreach (var taMenuItemOtherChoiceInfo in lstOtherChoice)
            {
                chkOtherChoice[i].Text = taMenuItemOtherChoiceInfo.MiEngName;
                i++;
            }

            for (int j = i; j < 20; j++)
            {
                chkOtherChoice[j].Text = "";
                chkOtherChoice[j].Visible = false;
            }
        }

        #region 设置Other Choice按钮
        /// <summary>
        /// 设置Other Choice按钮
        /// </summary>
        private void SetOtherChoiceBtn()
        {
            chkOtherChoice[0] = chkOc0;
            chkOtherChoice[1] = chkOc1;
            chkOtherChoice[2] = chkOc2;
            chkOtherChoice[3] = chkOc3;
            chkOtherChoice[4] = chkOc4;
            chkOtherChoice[5] = chkOc5;
            chkOtherChoice[6] = chkOc6;
            chkOtherChoice[7] = chkOc7;
            chkOtherChoice[8] = chkOc8;
            chkOtherChoice[9] = chkOc9;
            chkOtherChoice[10] = chkOc10;
            chkOtherChoice[11] = chkOc11;
            chkOtherChoice[12] = chkOc12;
            chkOtherChoice[13] = chkOc13;
            chkOtherChoice[14] = chkOc14;
            chkOtherChoice[15] = chkOc15;
            chkOtherChoice[16] = chkOc16;
            chkOtherChoice[17] = chkOc17;
            chkOtherChoice[18] = chkOc18;
            chkOtherChoice[19] = chkOc19;

            //for (int i = 0; i < 20; i++)
            //{
            //    chkOtherChoice[i].Click += chkOtherChoice_Click;
            //}
        }
        #endregion

        //#region Other Choice 点击
        ///// <summary>
        ///// Other Choice 点击
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void chkOtherChoice_Click(object sender, EventArgs e)
        //{
        //    CheckButton btn = sender as CheckButton;

        //    btn.Checked = !btn.Checked;
        //}

        //#endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (NoOfOption <= 0)
            {
                this.DialogResult = DialogResult.OK;

                Hide();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (NoOfOption > 0)
            {
                if (chkOtherChoice.Count(s => s.Checked == true) >= NoOfOption)
                {
                    foreach (var ce in chkOtherChoice.Where(s => s.Checked == true))
                    {
                        if (lstOtherChoice.Any(s => s.MiEngName.Equals(ce.Text)))
                        {
                            lstReturnChoice.Add(lstOtherChoice.FirstOrDefault(s => s.MiEngName.Equals(ce.Text)));
                        }
                    }

                    this.DialogResult = DialogResult.OK;

                    Hide();
                }
            }
            else
            {
                foreach (var ce in chkOtherChoice.Where(s => s.Checked == true))
                {
                    if (lstOtherChoice.Any(s => s.MiEngName.Equals(ce.Text)))
                    {
                        lstReturnChoice.Add(lstOtherChoice.FirstOrDefault(s => s.MiEngName.Equals(ce.Text)));
                    }
                }

                this.DialogResult = DialogResult.OK;

                Hide();
            }
            
        }
    }
}