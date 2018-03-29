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
    public partial class FrmTaMenuSet : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        //是否为Add
        private bool isAdd = false;

        public FrmTaMenuSet()
        {
            InitializeComponent();
        }

        public FrmTaMenuSet(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        #region 显示Grid的行号
        private void gvTaMenuSet_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #endregion

        #region Grid焦点行改变事件
        private void gvTaMenuSet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtEngName.Text = gvTaMenuSet.GetRowCellValue(gvTaMenuSet.FocusedRowHandle, "MSEngName").ToString();
            txtOtherName.Text = gvTaMenuSet.GetRowCellValue(gvTaMenuSet.FocusedRowHandle, "MSOtherName").ToString();
        }
        #endregion

        #region Add点击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtEngName.Text = "";
            txtOtherName.Text = "";
        }
        #endregion

        #region Save保存事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEngName.Text))
            {
                CommonTool.ShowMessage("Name can not NULL!");
                return;
            }

            if (string.IsNullOrEmpty(txtOtherName.Text))
            {
                CommonTool.ShowMessage("Other Name can not NULL!");
                return;
            }

            new SystemData().GetTaMenuSet();
            TaMenuSetInfo taMenuSetInfo = new TaMenuSetInfo();
            taMenuSetInfo.MSEngName = txtEngName.Text;
            taMenuSetInfo.MSOtherName = txtOtherName.Text;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taMenuSetInfo);
                    isAdd = false;
                }
                else
                {
                    taMenuSetInfo.ID = Convert.ToInt32(gvTaMenuSet.GetRowCellValue(gvTaMenuSet.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taMenuSetInfo);
                }

                BindData();

            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }
        #endregion

        #region Delete删除事件
        private void btnDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaMenuSet();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaMenuSet.FirstOrDefault(s => s.ID == Convert.ToInt32(gvTaMenuSet.GetRowCellValue(gvTaMenuSet.FocusedRowHandle, "ID"))));
                    CommonTool.ShowMessage("Delete successful!");
                    BindData();
                    isAdd = false;
                }
                catch (Exception ex)
                {
                    LogHelper.Error(this.Name, ex);
                }
            }
        }
        #endregion

        #region 绑定数据源
        private void BindData()
        {
            new SystemData().GetTaMenuSet();

            gridControlTaMenuSet.DataSource = CommonData.TaMenuSet.ToList();

            gvTaMenuSet.FocusedRowHandle = gvTaMenuSet.RowCount - 1;
        }
        #endregion

        private void FrmTaMenuSet_Load(object sender, EventArgs e)
        {
            BindData();
        }
    }
}