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
    public partial class FrmTAOtherChoice : DevExpress.XtraEditors.XtraForm
    {
        //标注是Second:2还是Third Choices:3
        private int miType = 2; 

        //关联菜品ID
        private int miId = 0;

        //按钮
        private SimpleButton[] btnChoice = new SimpleButton[20];

        //菜品列表
        private List<TaMenuItemOtherChoiceInfo>  lstOtherChoice = new List<TaMenuItemOtherChoiceInfo>();

        public List<TaMenuItemOtherChoiceInfo> lstReturnChoice = new List<TaMenuItemOtherChoiceInfo>();

        //No of Options
        public int NoOfOption = 0;

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

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
                btnChoice[i].Text = taMenuItemOtherChoiceInfo.MiEngName;
                btnChoice[i].Appearance.BackColor = Color.Orange;
                i++;
            }

            for (int j = i; j < 20; j++)
            {
                btnChoice[j].Text = "";
                btnChoice[j].Visible = false;
                btnChoice[j].Appearance.BackColor = Color.Orange;
            }

            btn1.Click += btnChoice_Click;
            btn2.Click += btnChoice_Click;
            btn3.Click += btnChoice_Click;
            btn4.Click += btnChoice_Click;
            btn5.Click += btnChoice_Click;
            btn6.Click += btnChoice_Click;
            btn7.Click += btnChoice_Click;
            btn8.Click += btnChoice_Click;
            btn9.Click += btnChoice_Click;
            btn10.Click += btnChoice_Click;
            btn11.Click += btnChoice_Click;
            btn12.Click += btnChoice_Click;
            btn13.Click += btnChoice_Click;
            btn14.Click += btnChoice_Click;
            btn15.Click += btnChoice_Click;
            btn16.Click += btnChoice_Click;
            btn17.Click += btnChoice_Click;
            btn18.Click += btnChoice_Click;
            btn19.Click += btnChoice_Click;
            btn20.Click += btnChoice_Click;

            asfc.controllInitializeSize(this);
        }

        #region 设置Other Choice按钮
        /// <summary>
        /// 设置Other Choice按钮
        /// </summary>
        private void SetOtherChoiceBtn()
        {
            btnChoice[0] = btn1;
            btnChoice[1] = btn2;
            btnChoice[2] = btn3;
            btnChoice[3] = btn4;
            btnChoice[4] = btn5;
            btnChoice[5] = btn6;
            btnChoice[6] = btn7;
            btnChoice[7] = btn8;
            btnChoice[8] = btn9;
            btnChoice[9] = btn10;
            btnChoice[10] = btn11;
            btnChoice[11] = btn12;
            btnChoice[12] = btn13;
            btnChoice[13] = btn14;
            btnChoice[14] = btn15;
            btnChoice[15] = btn16;
            btnChoice[16] = btn17;
            btnChoice[17] = btn18;
            btnChoice[18] = btn19;
            btnChoice[19] = btn20;

            //for (int i = 0; i < 20; i++)
            //{
            //    chkOtherChoice[i].Click += chkOtherChoice_Click;
            //}
        }
        #endregion

        #region 按钮点击事件

        private void btnChoice_Click(object sender, EventArgs e)
        {
            SimpleButton btn = (SimpleButton)sender;

            btn.Appearance.BackColor = btn.Appearance.BackColor == Color.Orange ? Color.LightGreen : Color.Orange;

            btnOK_Click(sender, e);
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
                if (btnChoice.Count(btn => btn.Appearance.BackColor == Color.LightGreen) == NoOfOption)
                {
                    foreach (var btn in btnChoice.Where(btn => btn.Appearance.BackColor == Color.LightGreen))
                    {
                        if (lstOtherChoice.Any(s => s.MiEngName.Equals(btn.Text)))
                        {
                            lstReturnChoice.Add(lstOtherChoice.FirstOrDefault(s => s.MiEngName.Equals(btn.Text)));
                        }
                    }

                    this.DialogResult = DialogResult.OK;

                    Hide();
                }
            }
            else
            {
                foreach (var btn in btnChoice.Where(btn => btn.Appearance.BackColor == Color.LightGreen))
                {
                    if (lstOtherChoice.Any(s => s.MiEngName.Equals(btn.Text)))
                    {
                        lstReturnChoice.Add(lstOtherChoice.FirstOrDefault(s => s.MiEngName.Equals(btn.Text)));
                    }
                }

                this.DialogResult = DialogResult.OK;

                Hide();
            }
            
        }

        private void FrmTAOtherChoice_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}