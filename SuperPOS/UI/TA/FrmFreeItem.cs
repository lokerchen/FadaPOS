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
using DevExpress.XtraRichEdit.Commands.Internal;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.TA
{
    public partial class FrmFreeItem : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private SimpleButton[] btnFree = new SimpleButton[4];
        private Label[] lblId = new Label[4];

        private int iLangeStatus = PubComm.MENU_LANG_DEFAULT;

        private TaMenuItemInfo taMiFree = null;

        public TaMenuItemInfo TaMiFreeMi
        {
            get { return taMiFree; }
            set { taMiFree = value; }
        }

        public FrmFreeItem()
        {
            InitializeComponent();
        }

        public FrmFreeItem(int iLang)
        {
            InitializeComponent();

            iLangeStatus = iLang;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            taMiFree = null;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FrmFreeItem_Load(object sender, EventArgs e)
        {
            SetCtl();

            asfc.controllInitializeSize(this);
        }

        private void FrmFreeItem_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void SetCtl()
        {
            btnFree[0] = btn1;
            btnFree[1] = btn2;
            btnFree[2] = btn3;
            btnFree[3] = btn4;

            lblId[0] = lblID1;
            lblId[1] = lblID2;
            lblId[2] = lblID3;
            lblId[3] = lblID4;

            var lstFreeId = CommonData.TaFreeFood.Where(s => !string.IsNullOrEmpty(s.DishCode));

            var lstFree = from fi in lstFreeId
                          join mi in CommonData.TaMenuItem
                          on fi.DishCode equals mi.MiDishCode
                          select new
                          {
                              ID = mi.ID,
                              EngName = mi.MiEngName,
                              OtherName = mi.MiOtherName,
                              DishCode = mi.MiDishCode
                          };
            int i = 0;

            int tmpId = 0;

            foreach (var taFreeFoodInfo in lstFree)
            {
                btnFree[i].Text = iLangeStatus == PubComm.MENU_LANG_DEFAULT
                                ? @"(" + taFreeFoodInfo.DishCode + @")" + taFreeFoodInfo.EngName
                                : @"(" + taFreeFoodInfo.DishCode + @")" + taFreeFoodInfo.OtherName;
                lblId[i].Text = taFreeFoodInfo.ID.ToString();

                if (i == 0) tmpId = taFreeFoodInfo.ID;

                i++;
            }

            btn1.Click += btnFree_Click;
            btn2.Click += btnFree_Click;
            btn3.Click += btnFree_Click;
            btn4.Click += btnFree_Click;

            if (tmpId > 0)
            {
                btnFree[0].Appearance.BackColor = Color.DarkGreen;
                taMiFree = CommonData.TaMenuItem.FirstOrDefault(s => s.ID == tmpId);
            }
        }

        private void btnFree_Click(object sender, EventArgs e)
        {
            var btn = (SimpleButton)sender;

            if (!string.IsNullOrEmpty(btn.Text))
            {
                btn.Appearance.BackColor = Color.DarkGreen;

                string strBtnId = btn.Name.Replace(@"btn", "");

                for (int i = 0; i < 4; i++)
                {
                    if (!(i + 1).ToString().Equals(strBtnId)) btnFree[i].Appearance.BackColor = Color.FromArgb(255, 255, 128);
                }
                
                string strLblId = "0";
                if (strBtnId.Equals("1")) { strLblId = lblID1.Text; }
                else if (strBtnId.Equals("2")) { strLblId = lblID2.Text; }
                else if (strBtnId.Equals("3")) { strLblId = lblID3.Text; }
                else if (strBtnId.Equals("4")) { strLblId = lblID4.Text; }

                taMiFree = CommonData.TaMenuItem.FirstOrDefault(s => s.ID.ToString().Equals(strLblId));
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}