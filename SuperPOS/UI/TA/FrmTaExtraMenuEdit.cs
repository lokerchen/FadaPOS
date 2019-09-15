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
    public partial class FrmTaExtraMenuEdit : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        //新增/更新
        private bool isAdd = false;

        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private SimpleButton[] btnType = new SimpleButton[10];

        private string menuBtnName = "Taste Item";

        private string menuType = "";

        public FrmTaExtraMenuEdit()
        {
            InitializeComponent();
        }

        public FrmTaExtraMenuEdit(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        #region 绑定Grid数据

        public void BindGridData(string sMenuBtnName, string sMenuType)
        {
            new SystemData().GetTaExtraMenu();

            var lstExtraMenu = CommonData.TaExtraMenu;

            gridControlExtraMenu.DataSource = string.IsNullOrEmpty(sMenuBtnName) 
                                                ? lstExtraMenu.Where(s => s.eMenuBtnName.Equals(sMenuType)).ToList() 
                                                : lstExtraMenu.Where(s => s.eMenuType.Equals(sMenuType) && s.eMenuBtnName.Equals(sMenuBtnName)).ToList();

            gvExtraMenu.BestFitColumns();
            gvExtraMenu.RefreshData();
            gvExtraMenu.FocusedRowHandle = gvExtraMenu.RowCount - 1;
            gvExtraMenu_FocusedRowChanged(gvExtraMenu, null);
        }
        #endregion

        private void gvExtraMenu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvExtraMenu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvExtraMenu.RowCount < 1)
            {
                txtEngName.Text = "";
                txtOtherName.Text = "";
                txtPrice.Text = "";
                txtDispPosition.Text = "";
                return;
            }
            txtEngName.Text = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuEngName").ToString();
            txtOtherName.Text = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuOtherName").ToString();
            txtPrice.Text = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuPrice").ToString();
            txtDispPosition.Text = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuPosition").ToString();
            txtMenuType.Text = menuType = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuType").ToString();
            menuBtnName = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuBtnName").ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtEngName.Text = "";
            txtOtherName.Text = "";
            txtPrice.Text = "";
            txtDispPosition.Text = "";

            SetDefaultBtn(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 控制判断
            if (string.IsNullOrEmpty(txtEngName.Text))
            {
                CommonTool.ShowMessage("English Name can not NULL!");
                return;
            }

            if (string.IsNullOrEmpty(txtOtherName.Text))
            {
                CommonTool.ShowMessage("English Name can not NULL!");
                return;
            }

            if (string.IsNullOrEmpty(txtDispPosition.Text))
            {
                CommonTool.ShowMessage("Display Position can not NULL!");
                return;
            }
            #endregion

            new SystemData().GetTaExtraMenu();

            TaExtraMenuInfo taExtraMenuInfo = new TaExtraMenuInfo();
            taExtraMenuInfo.eMenuEngName = txtEngName.Text;
            taExtraMenuInfo.eMenuOtherName = txtOtherName.Text;
            taExtraMenuInfo.eMenuPrice = string.IsNullOrEmpty(txtPrice.Text) ? "0.00" : txtPrice.Text;
            taExtraMenuInfo.eMenuPosition = txtDispPosition.Text;
            taExtraMenuInfo.eMenuBtnName = menuBtnName;
            taExtraMenuInfo.eMenuType = menuType;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taExtraMenuInfo);
                    isAdd = false;
                }
                else
                {
                    taExtraMenuInfo.ID = Convert.ToInt32(gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taExtraMenuInfo);
                }

                BindGridData(menuBtnName, menuType);
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaExtraMenu();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaExtraMenu.FirstOrDefault(s => s.ID == Convert.ToInt32(gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "ID"))));
                    CommonTool.ShowMessage("Delete successful!");
                    BindGridData(menuBtnName, menuType);
                    isAdd = false;
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }

                SetDefaultBtn(true);
            }
        }

        private void FrmTaExtraMenuEdit_Load(object sender, EventArgs e)
        {
            asfc.controllInitializeSize(this);

            #region 按钮赋值
            btnType[0] = btnTi0;
            btnType[1] = btnTi1;
            btnType[2] = btnTi2;
            btnType[3] = btnTi3;
            btnType[4] = btnTi4;
            btnType[5] = btnTi5;
            btnType[6] = btnTi6;
            btnType[7] = btnTi7;
            btnType[8] = btnTi8;
            btnType[9] = btnTi9;

            btnTi0.Click += btnType_Click;
            btnTi1.Click += btnType_Click;
            btnTi2.Click += btnType_Click;
            btnTi3.Click += btnType_Click;
            btnTi4.Click += btnType_Click;
            btnTi5.Click += btnType_Click;
            btnTi6.Click += btnType_Click;
            btnTi7.Click += btnType_Click;
            btnTi8.Click += btnType_Click;
            btnTi9.Click += btnType_Click;

            //按钮赋值
            for (int i = 0; i < 10; i++)
            {
                btnType[i].Text = PubComm.EXTRA_MENU_EDIT_TYPE[i];
            }
            #endregion

            btnTi0.Appearance.BackColor = Color.Red;

            menuType = btnTi0.Text;
            txtMenuType.Text = btnTi0.Text;

            BindGridData(menuType, btnTi0.Text);
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;

            btn.Appearance.BackColor = Color.Red;

            foreach (var bt in btnType)
            {
                if (!bt.Text.Equals(btn.Text)) bt.Appearance.BackColor = Color.ForestGreen;
            }

            txtMenuType.Text = btn.Text;

            if (!isAdd) BindGridData(menuBtnName, btn.Text);
        }

        private void FrmTaExtraMenuEdit_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTasteItem_Click(object sender, EventArgs e)
        {
            SetDefaultBtn(true);

            if (!isAdd) BindGridData(menuBtnName, menuType);
        }

        private void btnDrinkItem_Click(object sender, EventArgs e)
        {
            SetDefaultBtn(false);

            if (!isAdd) BindGridData(menuBtnName, menuType);
        }

        private void SetDefaultBtn(bool isTastItem)
        {
            if (isTastItem)
            {
                menuBtnName = btnTasteItem.Text;
                btnTasteItem.Appearance.BackColor = Color.RoyalBlue;
                btnDrinkItem.Appearance.BackColor = Color.LightSteelBlue;
            }
            else
            {
                menuBtnName = btnDrinkItem.Text;
                btnTasteItem.Appearance.BackColor = Color.LightSteelBlue;
                btnDrinkItem.Appearance.BackColor = Color.RoyalBlue;
            }

            btnTi0.Appearance.BackColor = Color.Red;
            foreach (var bt in btnType)
            {
                if (!bt.Text.Equals(btnTi0.Text)) bt.Appearance.BackColor = Color.ForestGreen;
            }
            menuType = btnTi0.Text;
        }

        private void btnKeyBoard_Click(object sender, EventArgs e)
        {
            CommonDAL.OpenSysKeyBoard();
        }
    }
}