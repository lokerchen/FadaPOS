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

namespace SuperPOS.UI.TA
{
    public partial class FrmTaChangePrice : DevExpress.XtraEditors.XtraForm
    {
        private string miID = "";
        private string miOldPrice = "";

        private string txtName = "";

        public string NewPrice
        {
            get { return txtNewPrice.Text; }
            set { NewPrice = value; }
        }

        public FrmTaChangePrice()
        {
            InitializeComponent();
        }

        public FrmTaChangePrice(string sId, string sPrice)
        {
            InitializeComponent();
            miID = sId;
            miOldPrice = sPrice;
        }

        private void btnFree_Click(object sender, EventArgs e)
        {
            txtNewPrice.Text = "0.00";
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            //Discount
            if (txtName.Equals("txtDiscount"))
            {
                if (!txtDiscount.Text.EndsWith("%")) txtDiscount.Text += "%";

                if (txtDiscount.Text.Contains("%")) return;
            }

            //Increment
            if (txtName.Equals("txtIncrement"))
            {
                if (!txtIncrement.Text.EndsWith("%")) txtIncrement.Text += "%";

                if (txtIncrement.Text.Contains("%")) return;
            }
        }

        private void txtDiscount_MouseDown(object sender, MouseEventArgs e)
        {
            txtName = "txtDiscount";
            txtDiscount.SelectAll();
        }

        private void txtIncrement_MouseDown(object sender, MouseEventArgs e)
        {
            txtName = "txtIncrement";
            txtIncrement.SelectAll();
        }

        private void txtNewPrice_MouseDown(object sender, MouseEventArgs e)
        {
            txtName = "txtNewPrice";
            txtNewPrice.SelectAll();
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            //Discount
            if (txtName.Equals("txtDiscount"))
            {
                if (!txtDiscount.Text.Contains(".")) txtDiscount.Text += ".";
                else return;
            }
            else if (txtName.Equals("txtIncrement")) //Increment
            {
                if (!txtIncrement.Text.Contains(".")) txtDiscount.Text += ".";
                else return;
            }
            else if (txtName.Equals("txtNewPrice")) //New Price
            {
                if (!txtNewPrice.Text.Contains(".")) txtNewPrice.Text += ".";
                else return;
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            //Discount
            if (txtName.Equals("txtDiscount"))
            {
                txtDiscount.Text = txtDiscount.Text.Length > 0
                    ? txtDiscount.Text.Substring(0, txtDiscount.Text.Length - 1)
                    : "";
            }
            else if (txtName.Equals("txtIncrement")) //Increment
            {
                txtIncrement.Text = txtIncrement.Text.Length > 0
                    ? txtIncrement.Text.Substring(0, txtIncrement.Text.Length - 1)
                    : "";
            }
            else if (txtName.Equals("txtNewPrice")) //New Price
            {
                txtNewPrice.Text = txtNewPrice.Text.Length > 0
                    ? txtNewPrice.Text.Substring(0, txtNewPrice.Text.Length - 1)
                    : "";
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            //Discount
            if (txtName.Equals("txtDiscount"))
            {
                txtDiscount.Text = @"0.00";
            }
            else if (txtName.Equals("txtIncrement")) //Increment
            {
                txtIncrement.Text = @"0.00";
            }
            else if (txtName.Equals("txtNewPrice")) //New Price
            {
                txtNewPrice.Text = @"0.00";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            txtNewPrice.Text = txtOriginalPrice.Text;
            Hide();
        }

        private void FrmTaChangePrice_Load(object sender, EventArgs e)
        {
            btn0.Click += BtnNum_Click;
            btn1.Click += BtnNum_Click;
            btn2.Click += BtnNum_Click;
            btn3.Click += BtnNum_Click;
            btn4.Click += BtnNum_Click;
            btn5.Click += BtnNum_Click;
            btn6.Click += BtnNum_Click;
            btn7.Click += BtnNum_Click;
            btn8.Click += BtnNum_Click;
            btn9.Click += BtnNum_Click;

            var lstMi = CommonData.TaMenuItem.Where(s => s.MiDishCode.Equals(miID)).ToList();

            if (lstMi.Any())
            {
                txtEngName.Text = lstMi.FirstOrDefault().MiEngName;
                txtOtherName.Text = lstMi.FirstOrDefault().MiOtherName;
                txtOriginalPrice.Text = miOldPrice;
            }
            else 
                Hide();
        }

        private void BtnNum_Click(object sender, EventArgs e)
        {
            SimpleButton btn = (SimpleButton) sender;

            //Discount
            if (txtName.Equals("txtDiscount"))
            {
                if (txtDiscount.Text.Equals("0.00") || txtDiscount.Text.Equals("0.0") || txtDiscount.Text.Equals("0") ||
                    string.IsNullOrEmpty(txtDiscount.Text)) txtDiscount.Text = btn.Text;
                else
                {
                    if (txtDiscount.Text.EndsWith("%"))
                        txtDiscount.Text = txtDiscount.Text.Substring(0, txtDiscount.Text.Length - 1) + btn.Text + "%";
                    else
                        txtDiscount.Text += btn.Text;
                }
            }
            else if (txtName.Equals("txtIncrement")) //Increment
            {
                if (txtIncrement.Text.Equals("0.00") || txtIncrement.Text.Equals("0.0") || txtIncrement.Text.Equals("0") ||
                    string.IsNullOrEmpty(txtIncrement.Text)) txtIncrement.Text = btn.Text;
                else
                {
                    if (txtIncrement.Text.EndsWith("%"))
                        txtIncrement.Text = txtIncrement.Text.Substring(0, txtIncrement.Text.Length - 1) + btn.Text + "%";
                    else
                        txtIncrement.Text += btn.Text;
                }
            }
            else if (txtName.Equals("txtNewPrice")) //New Price
            {
                if (txtNewPrice.Text.Equals("0.00") || txtNewPrice.Text.Equals("0.0") || txtNewPrice.Text.Equals("0") ||
                    string.IsNullOrEmpty(txtNewPrice.Text)) txtNewPrice.Text = btn.Text;
                else
                    txtNewPrice.Text += btn.Text;
            }
        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {
            txtIncrement.Text = @"0.00";
            if (txtDiscount.Text.EndsWith("%"))
            {
                try
                {
                    string sDiscount = "";
                    if (txtDiscount.Text.Length > 2)
                    {
                        sDiscount = txtDiscount.Text.Substring(0, txtDiscount.Text.Length - 1).EndsWith(".")
                            ? txtDiscount.Text.Substring(0, txtDiscount.Text.Length - 2) + "0"
                            : txtDiscount.Text.Substring(0, txtDiscount.Text.Length - 1);
                    }
                    else if (txtDiscount.Text.Length == 2)
                    {
                        sDiscount = txtDiscount.Text.Substring(0, txtDiscount.Text.Length - 1).EndsWith(".") ? "0" : txtDiscount.Text.Substring(0, txtDiscount.Text.Length - 1);
                    }
                    else
                    {
                        sDiscount = "0";
                    }

                    decimal d = Convert.ToDecimal(txtOriginalPrice.Text) * (100 - Convert.ToDecimal(sDiscount)) / 100;

                    txtNewPrice.Text = d <= 0 ? "0.00" : d.ToString();
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message, ex);
                    throw;
                }
            }
            else
            {
                try
                {
                    string sDiscount = "0";
                    if (txtDiscount.Text.Length >= 2)
                    {
                        if (txtDiscount.Text.Substring(0, txtDiscount.Text.Length - 2).EndsWith("."))
                            sDiscount = txtDiscount.Text.Substring(0, txtDiscount.Text.Length - 1) + "0";
                        else
                            sDiscount = txtDiscount.Text;
                    }
                    else
                        sDiscount = txtDiscount.Text;

                    decimal d = Convert.ToDecimal(txtOriginalPrice.Text) - Convert.ToDecimal(sDiscount);
                    txtNewPrice.Text = d <= 0 ? "0.00" : d.ToString();
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message, ex);
                    throw;
                }
            }
        }

        private void txtIncrement_EditValueChanged(object sender, EventArgs e)
        {
            txtDiscount.Text = @"0.00";
            if (txtIncrement.Text.EndsWith("%"))
            {
                try
                {
                    string sDiscount = "";
                    if (txtIncrement.Text.Length > 2)
                    {
                        sDiscount = txtIncrement.Text.Substring(0, txtIncrement.Text.Length - 1).EndsWith(".")
                            ? txtIncrement.Text.Substring(0, txtIncrement.Text.Length - 2) + "0"
                            : txtIncrement.Text.Substring(0, txtIncrement.Text.Length - 1);
                    }
                    else if (txtIncrement.Text.Length == 2)
                    {
                        sDiscount = txtIncrement.Text.Substring(0, txtIncrement.Text.Length - 1).EndsWith(".") ? "0" : txtIncrement.Text.Substring(0, txtIncrement.Text.Length - 1);
                    }
                    else
                    {
                        sDiscount = "0";
                    }

                    decimal d = Convert.ToDecimal(txtOriginalPrice.Text) * (100 + Convert.ToDecimal(sDiscount)) / 100;

                    txtNewPrice.Text = d <= 0 ? "0.00" : d.ToString();
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message, ex);
                    throw;
                }
            }
            else
            {
                try
                {
                    string sDiscount = "0";
                    if (txtIncrement.Text.Length >= 2)
                    {
                        if (txtIncrement.Text.Substring(0, txtIncrement.Text.Length - 2).EndsWith("."))
                            sDiscount = txtIncrement.Text.Substring(0, txtIncrement.Text.Length - 1) + "0";
                        else
                            sDiscount = txtIncrement.Text;
                    }
                    else
                        sDiscount = txtIncrement.Text;

                    decimal d = Convert.ToDecimal(txtOriginalPrice.Text) + Convert.ToDecimal(sDiscount);
                    txtNewPrice.Text = d <= 0 ? "0.00" : d.ToString();
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message, ex);
                    throw;
                }
            }
        }
    }
}