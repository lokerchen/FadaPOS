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
    public partial class FrmTaFreeItem : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        //是否为Add
        private bool isAdd = false;

        public FrmTaFreeItem()
        {
            InitializeComponent();
        }

        public FrmTaFreeItem(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        #region 行颜色
        private void gvFreeFoodItem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #endregion

        #region 绑定数据源

        private void BindData()
        {
            new SystemData().GetTaFreeFood();

            gridControlFreeFood.DataSource = CommonData.TaFreeFood.ToList();

            gvFreeFoodItem.FocusedRowHandle = gvFreeFoodItem.RowCount - 1;
        }
        #endregion

        private void FrmTaFreeItem_Load(object sender, EventArgs e)
        {
            BindData();

            txtTotalAmount.Text = CommonDAL.GetSysValue(PubComm.SYS_VALUE_FREE_FOOD_ITEM_AMOUNT, PubComm.SYS_DESC_FREE_FOOD_ITEM_AMOUNT, "");
        }

        #region 焦点行变化事件
        private void gvFreeFoodItem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtDishCode.Text = gvFreeFoodItem.GetRowCellValue(gvFreeFoodItem.FocusedRowHandle, "DishCode").ToString();
        }
        #endregion

        #region Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (gvFreeFoodItem.RowCount >= 4)
            {
                CommonTool.ShowMessage("4 records are supported at most!");
                return;
            }

            isAdd = true;

            txtDishCode.Text = "";
        }
        #endregion

        #region Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDishCode.Text))
            {
                CommonTool.ShowMessage("Dish Code can not NULL!");
                return;
            }

            new SystemData().GetTaFreeFood();

            TaFreeFoodInfo taFreeFoodInfo = new TaFreeFoodInfo();
            taFreeFoodInfo.DishCode = txtDishCode.Text;

            try
            {
                if (!string.IsNullOrEmpty(txtTotalAmount.Text))
                {
                    CommonDAL.GetSysValue(PubComm.SYS_VALUE_FREE_FOOD_ITEM_AMOUNT, PubComm.SYS_DESC_FREE_FOOD_ITEM_AMOUNT, txtTotalAmount.Text);
                }

                if (isAdd)
                {
                    _control.AddEntity(taFreeFoodInfo);
                    isAdd = false;
                }
                else
                {
                    taFreeFoodInfo.ID = Convert.ToInt32(gvFreeFoodItem.GetRowCellValue(gvFreeFoodItem.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taFreeFoodInfo);
                }

                BindData();
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }
        #endregion

        #region Del
        private void btnDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaFreeFood();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.Keypad.FirstOrDefault(s => s.ID == Convert.ToInt32(gvFreeFoodItem.GetRowCellValue(gvFreeFoodItem.FocusedRowHandle, "ID"))));
                    CommonTool.ShowMessage("Delete successful!");
                    BindData();
                    isAdd = false;
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            }
        }
        #endregion
    }
}