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
    public partial class FrmTaAppendItem : DevExpress.XtraEditors.XtraForm
    {
        SimpleButton[] btnModi = new SimpleButton[11];

        SimpleButton[] btnType = new SimpleButton[5];

        private const string BTN_TYPE = "All Item";

        private List<TaExtraResult> lstRusult = new List<TaExtraResult>();

        public List<TaExtraResult> LstResults => lstRusult;

        public FrmTaAppendItem()
        {
            InitializeComponent();
        }

        private void FrmTaAppendItem_Load(object sender, EventArgs e)
        {
            SetModiBtn();
            BindItemData(BTN_TYPE);

            SetTypeBtn();

            BindResultData();
        }

        #region 改码类别按钮
        /// <summary>
        /// 改码类别按钮
        /// </summary>
        private void SetModiBtn()
        {
            btnModi[0] = btnType0;
            btnModi[1] = btnType1;
            btnModi[2] = btnType2;
            btnModi[3] = btnType3;
            btnModi[4] = btnType4;
            btnModi[5] = btnType5;
            btnModi[6] = btnType6;
            btnModi[7] = btnType7;
            btnModi[8] = btnType8;
            btnModi[9] = btnType9;
            btnModi[10] = btnType10;

            for (int i = 0; i < 11; i++)
            {
                btnModi[i].Click += btnModi_Click;
            }

            btnModi[0].Text = BTN_TYPE;

            int j = 1;
            foreach (var sType in PubComm.EXTRA_MENU_EDIT_TYPE)
            {
                btnModi[j].Text = sType;
                j++;
            }
        }

        private void btnModi_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;

            BindItemData(btn.Text);
        }
        #endregion

        #region 绑定数据
        private void BindItemData(string sType)
        {
            new SystemData().GetTaExtraMenu();

            List<TaExtraMenuInfo> lstExtraMenu = new List<TaExtraMenuInfo>();

            string str = "";
            if (chkDrink.Checked && !chkTaste.Checked) str = "Drink Item";
            else if (!chkDrink.Checked && chkTaste.Checked) str = "Taste Item";
            else str = "";

            if (string.IsNullOrEmpty(str))
            {
                lstExtraMenu = CommonData.TaExtraMenu.ToList();
            }
            else
            {
                lstExtraMenu = CommonData.TaExtraMenu.Where(s => s.eMenuBtnName.Equals("str")).ToList();
            }

            gridControlTaExtraMenu.DataSource = sType.Equals(BTN_TYPE) ? lstExtraMenu : lstExtraMenu.Where(s => s.eMenuType.Equals(sType)).ToList();

            gvTaExtraMenu.FocusedRowHandle = gvTaExtraMenu.RowCount - 1;
        }

        private void BindResultData()
        {
            gridControlResult.DataSource = lstRusult;

            gvResult.FocusedRowHandle = gvResult.RowCount - 1;
        }
        #endregion

        private void gvTaExtraMenu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvResult_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        #region 改码类型按钮
        private void SetTypeBtn()
        {
            btnType[0] = btnTypeResult0;
            btnType[1] = btnTypeResult1;
            btnType[2] = btnTypeResult2;
            btnType[3] = btnTypeResult3;
            btnType[4] = btnTypeResult4;

            for (int i = 0; i < 5; i++)
            {
                btnType[i].Click += btnResult_Click;
            }

            int j = 0;
            foreach (var sType in PubComm.FORM_BTN_TYPE)
            {
                btnType[j].Text = sType;
                j++;
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;

            if (!string.IsNullOrEmpty(gvTaExtraMenu.GetRowCellValue(gvTaExtraMenu.FocusedRowHandle, "ID").ToString()))
            {
                TaExtraResult taExtraResultInfo = new TaExtraResult();
                taExtraResultInfo.rID = Convert.ToInt32(gvTaExtraMenu.GetRowCellValue(gvTaExtraMenu.FocusedRowHandle, "ID").ToString());
                taExtraResultInfo.rItemName = gvTaExtraMenu.GetRowCellValue(gvTaExtraMenu.FocusedRowHandle, "eMenuEngName").ToString();
                taExtraResultInfo.rType = btn.Text.Substring(btn.Text.IndexOf("(") + 1, btn.Text.IndexOf(")") - btn.Text.IndexOf("(") - 1);
                if (taExtraResultInfo.rType.Equals("+") || taExtraResultInfo.rType.Equals("++"))
                {
                    taExtraResultInfo.rPrice = gvTaExtraMenu.GetRowCellValue(gvTaExtraMenu.FocusedRowHandle, "eMenuPrice").ToString();
                }
                else
                {
                    taExtraResultInfo.rPrice = @"0.00";
                }
                lstRusult.Add(taExtraResultInfo);

                BindResultData();

                gvResult.RefreshData();
            }
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}