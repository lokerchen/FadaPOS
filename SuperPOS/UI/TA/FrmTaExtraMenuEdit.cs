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

        #region 绑定chkComboType
        /// <summary>
        /// 绑定chkComboType
        /// </summary>
        private void BindChkComboType(bool isClear)
        {
            if (isClear) chkComboType.Properties.Items.Clear();

            chkComboType.Properties.Items.AddRange(PubComm.EXTRA_MENU_EDIT_TYPE);
        }
        #endregion

        #region 绑定chkComboBtnType
        /// <summary>
        /// 绑定chkComboBtnType
        /// </summary>
        private void BindChkComboBtnType(bool isClear)
        {
            if (isClear) chkComboBtnType.Properties.Items.Clear();

            chkComboBtnType.Properties.Items.AddRange(PubComm.EXTRA_MENU_BTN_TYPE);
        }
        #endregion

        #region 绑定Grid数据

        public void BindGridData()
        {
            new SystemData().GetTaExtraMenu();

            gridControlExtraMenu.DataSource = CommonData.TaExtraMenu.ToList();

            gvExtraMenu.BestFitColumns();
            gvExtraMenu.FocusedRowHandle = gvExtraMenu.RowCount - 1;
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
            txtEngName.Text = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuEngName").ToString();
            txtOtherName.Text = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuOtherName").ToString();
            txtPrice.Text = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuPrice").ToString();
            txtDispPosition.Text = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuPosition").ToString();
            chkComboType.EditValue = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuType");
            chkComboType.Text = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuType").ToString();
            chkComboBtnType.EditValue = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuBtnName");
            chkComboBtnType.Text = gvExtraMenu.GetRowCellValue(gvExtraMenu.FocusedRowHandle, "eMenuBtnName").ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtEngName.Text = "";
            txtOtherName.Text = "";
            txtPrice.Text = "";
            txtDispPosition.Text = "";

            BindChkComboType(true);
            BindChkComboBtnType(true);
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

            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                CommonTool.ShowMessage("Price can not NULL!");
                return;
            }
            #endregion

            new SystemData().GetTaExtraMenu();

            TaExtraMenuInfo taExtraMenuInfo = new TaExtraMenuInfo();
            taExtraMenuInfo.eMenuEngName = txtEngName.Text;
            taExtraMenuInfo.eMenuOtherName = txtOtherName.Text;
            taExtraMenuInfo.eMenuPrice = txtPrice.Text;
            taExtraMenuInfo.eMenuPosition = txtDispPosition.Text;
            taExtraMenuInfo.eMenuBtnName = chkComboBtnType.EditValue.ToString();
            taExtraMenuInfo.eMenuType = chkComboType.EditValue.ToString();

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

                BindGridData();
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
                    BindGridData();
                    isAdd = false;
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }
        }

        private void FrmTaExtraMenuEdit_Load(object sender, EventArgs e)
        {
            asfc.controllInitializeSize(this);

            if (gvExtraMenu.RowCount <= 0)
            {
                isAdd = true;
                BindChkComboType(false);
                BindChkComboBtnType(false);
            }

            BindChkComboType(false);
            BindChkComboBtnType(false);

            BindGridData();
        }

        private void FrmTaExtraMenuEdit_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}