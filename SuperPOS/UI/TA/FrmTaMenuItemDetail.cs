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
using DevExpress.XtraTab;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaMenuItemDetail : DevExpress.XtraEditors.XtraForm
    {
        //Menu Item ID
        private int miID = 0;
        //新增/更新
        private bool isAdd = false;

        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        //MenuItem Type,默认为xtraTabPageSecond，即：2
        private int miType = 2;

        public FrmTaMenuItemDetail()
        {
            InitializeComponent();
        }

        public FrmTaMenuItemDetail(int id)
        {
            InitializeComponent();
            miID = id;
        }

        private void xtcOtherChoice_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {
            miType = SelectPage(e.Page.Name);

            BindData(miType);
        }

        private void FrmTaMenuItemDetail_Load(object sender, EventArgs e)
        {
            miType = SelectPage(xtcOtherChoice.SelectedTabPage.Name);

            BindData(miType);

            asfc.controllInitializeSize(this);
        }

        #region 根据Tab Page判断MenuItem类型
        /// <summary>
        /// 根据Tab Page判断MenuItem类型
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        private int SelectPage(string pageName)
        {
            if (pageName.Equals("xtraTabPageSecond")) return 2;
            else if (pageName.Equals("xtraTabPageThird")) return 3;
            else if (pageName.Equals("xtraTabPageTasteHandle")) return 4;
            else return 2;
        }
        #endregion

        #region Add按钮事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtEngName.Text = "";
            txtOtherName.Text = "";
            txtAddPrice.Text = "";
            chkEditAppend.Checked = false;
            chkEditEnableChoice.Checked = false;
        }
        #endregion

        #region Save按钮事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEngName.Text))
            {
                CommonTool.ShowMessage("English Name can not NULL!");
                return;
            }

            if (string.IsNullOrEmpty(txtOtherName.Text))
            {
                CommonTool.ShowMessage("Other Name can not NULL!");
                return;
            }

            TaMenuItemOtherChoiceInfo taMenuItemOtherChoiceInfo = new TaMenuItemOtherChoiceInfo();

            taMenuItemOtherChoiceInfo.MiEngName = txtEngName.Text;
            taMenuItemOtherChoiceInfo.MiOtherName = txtOtherName.Text;
            taMenuItemOtherChoiceInfo.MiPrice = string.IsNullOrEmpty(txtAddPrice.Text) ? "0.00" : txtAddPrice.Text;
            taMenuItemOtherChoiceInfo.IsAutoAppend = chkEditAppend.Checked ? "Y" : "N";
            taMenuItemOtherChoiceInfo.IsEnableChoice = chkEditEnableChoice.Checked ? "Y" : "N";
            taMenuItemOtherChoiceInfo.MiID = miID;
            taMenuItemOtherChoiceInfo.MiType = miType;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taMenuItemOtherChoiceInfo);
                    isAdd = false;
                }
                else
                {
                    taMenuItemOtherChoiceInfo.ID = Convert.ToInt32(gvOtherChoice.GetRowCellValue(gvOtherChoice.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taMenuItemOtherChoiceInfo);
                }

                BindData(miType);
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }
        #endregion

        #region Delete删除按钮
        private void btnDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaMenuItemOtherChoice();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaMenuItemOtherChoice.FirstOrDefault(s => s.ID == Convert.ToInt32(gvOtherChoice.GetRowCellValue(gvOtherChoice.FocusedRowHandle, "ID"))));
                    CommonTool.ShowMessage("Delete successful!");
                    BindData(miType);
                    isAdd = false;
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// 2:Second Choice
        /// 3:Third Choice
        /// 4:Taste Handling
        /// </summary>
        /// <param name="iType">MenuItem Type</param>
        private void BindData(int iType)
        {
            new SystemData().GetTaMenuItemOtherChoice();

            var lstOtherChoice = CommonData.TaMenuItemOtherChoice.Where(s => s.MiType == iType);

            gridControlOtherChoice.DataSource = lstOtherChoice.ToList();

            gvOtherChoice.FocusedRowHandle = gvOtherChoice.RowCount - 1;
        }
        #endregion

        private void gvOtherChoice_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvOtherChoice_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvOtherChoice.RowCount > 0)
            {
                txtEngName.Text = gvOtherChoice.GetRowCellValue(gvOtherChoice.FocusedRowHandle, "MiEngName").ToString();
                txtOtherName.Text = gvOtherChoice.GetRowCellValue(gvOtherChoice.FocusedRowHandle, "MiOtherName").ToString();
                txtAddPrice.Text = gvOtherChoice.GetRowCellValue(gvOtherChoice.FocusedRowHandle, "MiPrice").ToString();
                chkEditAppend.Checked = gvOtherChoice.GetRowCellValue(gvOtherChoice.FocusedRowHandle, "IsAutoAppend").ToString().Equals("Y");
                chkEditEnableChoice.Checked = gvOtherChoice.GetRowCellValue(gvOtherChoice.FocusedRowHandle, "IsEnableChoice").ToString().Equals("Y");
            }
            else
            {
                txtEngName.Text = "";
                txtOtherName.Text = "";
                txtAddPrice.Text = "";
                chkEditAppend.Checked = false;
                chkEditEnableChoice.Checked = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTaMenuItemDetail_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}