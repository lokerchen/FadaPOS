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
    public partial class FrmTaDeliveryNote : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        //是否为Add
        private bool isAdd = false;

        public FrmTaDeliveryNote()
        {
            InitializeComponent();
        }

        public FrmTaDeliveryNote(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (gvTaDeliveryNote.RowCount >= 4)
            {
                CommonTool.ShowMessage("4 records are supported at most!");
                return;
            }

            isAdd = true;
            txtDeliverNote.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDeliverNote.Text))
            {
                CommonTool.ShowMessage("Delivery Note can not NULL!");
                return;
            }

            new SystemData().GetTaDeliveryNote();

            TaDeliveryNoteInfo taDeliveryNoteInfo = new TaDeliveryNoteInfo();
            taDeliveryNoteInfo.DeliveryNote = txtDeliverNote.Text;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taDeliveryNoteInfo);
                    isAdd = false;
                }
                else
                {
                    taDeliveryNoteInfo.ID = Convert.ToInt32(gvTaDeliveryNote.GetRowCellValue(gvTaDeliveryNote.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taDeliveryNoteInfo);
                }

                BindData();
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaDeliveryNote.FirstOrDefault(s => s.ID == Convert.ToInt32(gvTaDeliveryNote.GetRowCellValue(gvTaDeliveryNote.FocusedRowHandle, "ID"))));
                    CommonTool.ShowMessage("Delete successful!");
                    BindData();
                    isAdd = false;
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }
        }

        private void FrmTaDeliveryNote_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void gvTaDeliveryNote_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvTaDeliveryNote_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtDeliverNote.Text = gvTaDeliveryNote.GetRowCellValue(gvTaDeliveryNote.FocusedRowHandle, "DeliveryNote").ToString();
        }

        #region Grid数据源绑定
        private void BindData()
        {
            new SystemData().GetTaDeliveryNote();

            gridControlTaDeliveryNote.DataSource = CommonData.TaDeliveryNote.ToList();

            gvTaDeliveryNote.FocusedRowHandle = gvTaDeliveryNote.RowCount - 1;
        }
        #endregion
    }
}