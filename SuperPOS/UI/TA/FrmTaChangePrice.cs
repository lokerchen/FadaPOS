using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LinqToDB;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaChangePrice : DevExpress.XtraEditors.XtraForm
    {
        private string miID = "";
        private string miOldPrice = "";

        //默认文本框为New Price
        private string txtName = "txtNewPrice";

        private string sItemEngName = "";
        private string sItemOtherName = "";

        private int iLange = PubComm.MENU_LANG_DEFAULT;

        private SimpleButton[] btnMenuAttr = new SimpleButton[20];

        private string miLargePrice = "";
        private string miSmallPrice = "";
        private string miRegPrice = "";

        private string strMenuAttrEng = "";
        private string strMenuAttrOther = "";

        private Hashtable hsMenuName = new Hashtable();

        public string MenuAttrEng
        {
            get { return strMenuAttrEng; }
            set { MenuAttrEng = value; }
        }

        public string MenuAttrOther
        {
            get { return strMenuAttrOther; }
            set { strMenuAttrOther = value; }
        }

        public string NewPrice
        {
            get { return txtNewPrice.Text; }
            set { NewPrice = value; }
        }

        public FrmTaChangePrice()
        {
            InitializeComponent();
        }

        public FrmTaChangePrice(string sId, string sPrice, int language)
        {
            InitializeComponent();
            miID = sId;
            miOldPrice = sPrice;
            iLange = language;
        }

        public FrmTaChangePrice(string sId, string itemEngName, string itemOtherName, string sPrice, int language)
        {
            InitializeComponent();
            miID = sId;
            miOldPrice = sPrice;
            iLange = language;
            sItemEngName = itemEngName;
            sItemOtherName = itemOtherName;
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
            #region 数字键盘
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
            #endregion

            #region 菜品修改后缀
            btnMenuAttr[0] = btnAttr1;
            btnMenuAttr[1] = btnAttr2;
            btnMenuAttr[2] = btnAttr3;
            btnMenuAttr[3] = btnAttr4;
            btnMenuAttr[4] = btnAttr5;
            btnMenuAttr[5] = btnAttr6;
            btnMenuAttr[6] = btnAttr7;
            btnMenuAttr[7] = btnAttr8;
            btnMenuAttr[8] = btnAttr9;
            btnMenuAttr[9] = btnAttr10;
            btnMenuAttr[10] = btnAttr11;
            btnMenuAttr[11] = btnAttr12;
            btnMenuAttr[12] = btnAttr13;
            btnMenuAttr[13] = btnAttr14;
            btnMenuAttr[14] = btnAttr15;
            btnMenuAttr[15] = btnAttr16;
            btnMenuAttr[16] = btnAttr17;
            btnMenuAttr[17] = btnAttr18;
            btnMenuAttr[18] = btnAttr19;
            btnMenuAttr[19] = btnAttr20;

            new SystemData().GetTaChangeMenuAttr();

            int i = 0;
            foreach (var taChangeMenuAttrInfo in CommonData.TaChangeMenuAttr)
            {
                hsMenuName.Add(taChangeMenuAttrInfo.MenuAttrEnglishName, string.IsNullOrEmpty(taChangeMenuAttrInfo.MenuAttrOtherName) ? "" : taChangeMenuAttrInfo.MenuAttrOtherName);

                btnMenuAttr[i].Text = iLange == PubComm.MENU_LANG_DEFAULT 
                                        ? taChangeMenuAttrInfo.MenuAttrEnglishName
                                        : taChangeMenuAttrInfo.MenuAttrOtherName;
                btnMenuAttr[i].Click += BtnAttr_Click;
                i++;
            }

            for (int j = i; j < 20; j++)
            {
                btnMenuAttr[j].Visible = false;
            }
            #endregion

            var lstMi = CommonData.TaMenuItem.Where(s => s.MiDishCode.Equals(miID)).ToList();

            if (lstMi.Any())
            {
                TaMenuItemInfo taMenuItemInfo = lstMi.FirstOrDefault();
                txtEngName.Text = sItemEngName;
                txtOtherName.Text = sItemOtherName;

                txtOriginalPrice.Text = miOldPrice;
                //默认价格
                txtNewPrice.Text = miOldPrice;

                miLargePrice = string.IsNullOrEmpty(taMenuItemInfo.MiLargePrice) ||
                               Convert.ToDecimal(taMenuItemInfo.MiLargePrice) <= 0m
                    ? miOldPrice
                    : taMenuItemInfo.MiLargePrice;

                miSmallPrice = string.IsNullOrEmpty(taMenuItemInfo.MiSmallPrice) ||
                               Convert.ToDecimal(taMenuItemInfo.MiSmallPrice) <= 0m
                    ? miOldPrice
                    : taMenuItemInfo.MiSmallPrice;

                miRegPrice = string.IsNullOrEmpty(taMenuItemInfo.MiRegularPrice) ||
                             Convert.ToDecimal(taMenuItemInfo.MiRegularPrice) <= 0m
                    ? miOldPrice
                    : taMenuItemInfo.MiRegularPrice;
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

                    decimal d = Convert.ToDecimal(txtNewPrice.Text) * (100 - Convert.ToDecimal(sDiscount)) / 100;

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

                    decimal d = Convert.ToDecimal(txtNewPrice.Text) - Convert.ToDecimal(sDiscount);
                    txtNewPrice.Text = d <= 0 ? "0.00" : d.ToString();
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message, ex);
                    throw;
                }
            }

            //txtIncrement.Text = @"0.00";
        }

        private void txtIncrement_EditValueChanged(object sender, EventArgs e)
        {
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

                    decimal d = Convert.ToDecimal(txtNewPrice.Text) * (100 + Convert.ToDecimal(sDiscount)) / 100;

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

                    decimal d = Convert.ToDecimal(txtNewPrice.Text) + Convert.ToDecimal(sDiscount);
                    txtNewPrice.Text = d <= 0 ? "0.00" : d.ToString();
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message, ex);
                    throw;
                }
            }

            //txtDiscount.Text = @"0.00";
        }

        private void BtnAttr_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtEngName.Text))
            {
                SimpleButton btn = (SimpleButton)sender;

                string eName = "";
                string oName = "";

                if (iLange == PubComm.MENU_LANG_DEFAULT)
                {
                    if (hsMenuName.ContainsKey(btn.Text))
                    {
                        eName = btn.Text;
                        oName = hsMenuName[btn.Text].ToString();
                    }
                    strMenuAttrEng += @" " + eName;
                }
                else
                {
                    if (hsMenuName.ContainsValue(btn.Text))
                    {
                        foreach (DictionaryEntry kv in hsMenuName)
                        {
                            if (kv.Value.Equals(btn.Text))
                            {
                                eName = kv.Key.ToString();
                                oName = btn.Text;
                                break;
                            }
                        }

                        strMenuAttrEng += @" " + oName;
                    }
                }
                
                txtEngName.Text += @" " + eName;
                txtOtherName.Text += @" " + oName;

                txtIncrement.Text = GetIncrementPrice(btn.Text, iLange);

                if (string.IsNullOrEmpty(txtIncrement.Text))
                {
                    txtIncrement.Text = @"0.00";
                }

                //txtNewPrice.Text = (Convert.ToDecimal(txtNewPrice.Text) + Convert.ToDecimal(txtIncrement.Text)).ToString();
            }
        }

        private void btnLarge_Click(object sender, EventArgs e)
        {
            //txtOriginalPrice.Text = miLargePrice;
            txtNewPrice.Text = (Convert.ToDecimal(miLargePrice) + Convert.ToDecimal(txtIncrement.Text)).ToString();
        }

        private void btnSmall_Click(object sender, EventArgs e)
        {
            //txtOriginalPrice.Text = miSmallPrice;
            txtNewPrice.Text = (Convert.ToDecimal(miSmallPrice) + Convert.ToDecimal(txtIncrement.Text)).ToString(); ;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            //txtOriginalPrice.Text = miRegPrice;
            txtNewPrice.Text = (Convert.ToDecimal(miRegPrice) + Convert.ToDecimal(txtIncrement.Text)).ToString(); ;
        }

        private string GetIncrementPrice(string name, int iLang)
        {
            var lstIp = iLang == PubComm.MENU_LANG_DEFAULT
                ? CommonData.TaChangeMenuAttr.Where(s => s.MenuAttrEnglishName.Equals(name))
                : CommonData.TaChangeMenuAttr.Where(s => s.MenuAttrOtherName.Equals(name));

            if (lstIp.Any())
            {
                TaChangeMenuAttrInfo taChangeMenuAttrInfo = lstIp.FirstOrDefault();
                strMenuAttrOther = string.IsNullOrWhiteSpace(taChangeMenuAttrInfo.MenuAttrOtherName) ? "" : taChangeMenuAttrInfo.MenuAttrOtherName;
                return string.IsNullOrEmpty(taChangeMenuAttrInfo.IncrementPrice) ? "0.00" : taChangeMenuAttrInfo.IncrementPrice;
            }
            else
                return @"0.00";
        }

        private void txtOriginalPrice_EditValueChanged(object sender, EventArgs e)
        {
            decimal origPrice = 0.0m;
            decimal discount = 0.0m;
            decimal incrementPrice = 0.0m;

            if (string.IsNullOrEmpty(txtOriginalPrice.Text)) return;

            origPrice = Convert.ToDecimal(txtOriginalPrice.Text);

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

                    discount = Convert.ToDecimal(txtNewPrice.Text) * (100 - Convert.ToDecimal(sDiscount)) / 100;
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message, ex);
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

                    discount = Convert.ToDecimal(sDiscount);
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message, ex);
                }
            }

            incrementPrice = Convert.ToDecimal(txtIncrement.Text);

            txtNewPrice.Text = (origPrice - discount + incrementPrice).ToString("0.00");
        }

        private void FrmTaChangePrice_Activated(object sender, EventArgs e)
        {
            txtNewPrice.Focus();
        }
    }
}