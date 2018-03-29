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

namespace SuperPOS.UI.Sys
{
    public partial class FrmKeyPadSet : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        //是否为Add
        private bool isAdd = false;

        public FrmKeyPadSet()
        {
            InitializeComponent();
        }

        public FrmKeyPadSet(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        #region 行颜色
        private void gvKeypad_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #endregion

        #region Grid数据源绑定

        private void BindData()
        {
            new SystemData().GetKeypadList();

            gridControlKeypad.DataSource = CommonData.Keypad.ToList();

            gvKeypad.FocusedRowHandle = gvKeypad.RowCount - 1;
        }
        #endregion

        private void FrmKeyPadSet_Load(object sender, EventArgs e)
        {
            BindData();
        }

        #region 焦点行变化事件
        private void gvKeypad_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtKeyName.Text = gvKeypad.GetRowCellValue(gvKeypad.FocusedRowHandle, "KeyName").ToString();
            txtKeyCode.Text = gvKeypad.GetRowCellValue(gvKeypad.FocusedRowHandle, "KeyCode").ToString();
        }
        #endregion

        #region Add按钮点击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //限制最高增加10行
            if (gvKeypad.RowCount >= 10)
            {
                CommonTool.ShowMessage("10 records are supported at most!");
                return;
            }

            isAdd = true;
            txtKeyName.Text = "";
            txtKeyCode.Text = "";
        }
        #endregion

        #region Save按钮事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeyName.Text))
            {
                CommonTool.ShowMessage("Keypad Name can not NULL!");
                return;
            }

            if (string.IsNullOrEmpty(txtKeyCode.Text))
            {
                CommonTool.ShowMessage("Keypad Name can not NULL!");
                return;
            }

            new SystemData().GetKeypadList();

            KeypadInfo keypadInfo = new KeypadInfo();
            keypadInfo.KeyName = txtKeyName.Text;
            keypadInfo.KeyCode = txtKeyCode.Text;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(keypadInfo);
                    isAdd = false;
                }
                else
                {
                    keypadInfo.ID = Convert.ToInt32(gvKeypad.GetRowCellValue(gvKeypad.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(keypadInfo);
                }

                BindData();
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }
        #endregion

        #region Delete按钮点击事件
        private void btnDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetKeypadList();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.Keypad.FirstOrDefault(s => s.ID == Convert.ToInt32(gvKeypad.GetRowCellValue(gvKeypad.FocusedRowHandle, "ID"))));
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