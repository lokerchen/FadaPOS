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
    public partial class FrmTaPaymentType : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        //是否为Add
        private bool isAdd = false;

        public FrmTaPaymentType()
        {
            InitializeComponent();
        }

        public FrmTaPaymentType(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (gvTaPaymentType.RowCount >= 4)
            {
                CommonTool.ShowMessage("4 records are supported at most!");
                return;
            }

            isAdd = true;
            txtPayType.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPayType.Text))
            {
                CommonTool.ShowMessage("Payment Type can not NULL!");
                return;
            }

            new SystemData().GetTaPaymentType();

            TaPaymentTypeInfo taPaymentTypeInfo = new TaPaymentTypeInfo();
            taPaymentTypeInfo.PaymentType = txtPayType.Text;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taPaymentTypeInfo);
                    isAdd = false;
                }
                else
                {
                    taPaymentTypeInfo.ID = Convert.ToInt32(gvTaPaymentType.GetRowCellValue(gvTaPaymentType.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taPaymentTypeInfo);
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
                    _control.DeleteEntity(CommonData.TaPaymentType.FirstOrDefault(s => s.ID == Convert.ToInt32(gvTaPaymentType.GetRowCellValue(gvTaPaymentType.FocusedRowHandle, "ID"))));
                    CommonTool.ShowMessage("Delete successful!");
                    BindData();
                    isAdd = false;
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }
        }

        private void gvTaPaymentType_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvTaPaymentType_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtPayType.Text = gvTaPaymentType.GetRowCellValue(gvTaPaymentType.FocusedRowHandle, "PaymentType").ToString();
        }

        #region Grid数据源绑定
        private void BindData()
        {
            new SystemData().GetTaPaymentType();

            gridControlTaPaymentType.DataSource = CommonData.TaPaymentType.ToList();

            gvTaPaymentType.FocusedRowHandle = gvTaPaymentType.RowCount - 1;
        }
        #endregion

        private void FrmTaPaymentType_Load(object sender, EventArgs e)
        {
            BindData();
        }
    }
}