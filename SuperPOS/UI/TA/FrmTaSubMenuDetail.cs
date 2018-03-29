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
    public partial class FrmTaSubMenuDetail : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int subMenuID = 0;

        private readonly EntityControl _control = new EntityControl();

        private bool isAdd = false;

        public FrmTaSubMenuDetail()
        {
            InitializeComponent();
        }

        public FrmTaSubMenuDetail(int id)
        {
            InitializeComponent();

            subMenuID = id;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtEngName.Text = "";
            txtOtherName.Text = "";

            isAdd = true;
        }

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

            new SystemData().GetTaSubMenuDetail();
            TaSubMenuDetailInfo taSubMenuDetailInfo = new TaSubMenuDetailInfo();
            taSubMenuDetailInfo.smID = subMenuID;
            taSubMenuDetailInfo.EngName = txtEngName.Text;
            taSubMenuDetailInfo.OtherName = txtOtherName.Text;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taSubMenuDetailInfo);
                    isAdd = false;
                }
                else
                {
                    taSubMenuDetailInfo.ID = Convert.ToInt32(gvTaSubMenuDetail.GetRowCellValue(gvTaSubMenuDetail.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taSubMenuDetailInfo);
                }

                BindData();

            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaSubMenuDetail();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaSubMenuDetail.FirstOrDefault(s => s.ID == Convert.ToInt32(gvTaSubMenuDetail.GetRowCellValue(gvTaSubMenuDetail.FocusedRowHandle, "ID"))));
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

        private void gvTaSubMenuDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtEngName.Text = gvTaSubMenuDetail.GetRowCellValue(gvTaSubMenuDetail.FocusedRowHandle, "EngName").ToString();
            txtOtherName.Text = gvTaSubMenuDetail.GetRowCellValue(gvTaSubMenuDetail.FocusedRowHandle, "OtherName").ToString();
        }

        private void BindData()
        {
            new SystemData().GetTaSubMenuDetail();

            gridControlTaSubMenuDetail.DataSource = CommonData.TaSubMenuDetail.Where(s => s.smID == subMenuID).ToList();

            gvTaSubMenuDetail.FocusedRowHandle = gvTaSubMenuDetail.RowCount - 1;
        }

        private void FrmTaSubMenuDetail_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}