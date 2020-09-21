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

namespace SuperPOS.UI.TA
{
    public partial class FrmTaIngredMode : DevExpress.XtraEditors.XtraForm
    {
        private string ingredModeValue = "";

        public string modeValue
        {
            get { return ingredModeValue; }
            set { modeValue = value; }
        }
        public FrmTaIngredMode()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Hide();
        }

        private void FrmTaIngredMode_Load(object sender, EventArgs e)
        {
            btnNo.Click += btnMode_Click;
            btnLess.Click += btnMode_Click;
            btnChange.Click += btnMode_Click;
            btnAdd.Click += btnMode_Click;
            btnWO.Click += btnMode_Click;
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;

            switch (btn.Name)
            {
                case "btnNo":
                    ingredModeValue = "X";
                    break;
                case "btnLess":
                    ingredModeValue = @"-";
                    break;
                case "btnChange":
                    ingredModeValue = @"/";
                    break;
                case "btnAdd":
                    ingredModeValue = @"+";
                    break;
                case "btnWO":
                    ingredModeValue = @"x";
                    break;
                default:
                    ingredModeValue = "";
                    break;
            }

            this.DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Hide();
        }
    }
}