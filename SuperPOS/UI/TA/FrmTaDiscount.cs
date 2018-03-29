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
    public partial class FrmTaDiscount : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        public FrmTaDiscount()
        {
            InitializeComponent();
        }

        public FrmTaDiscount(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDiscount.Text))
            {
                CommonTool.ShowMessage("Discount(%) can not NULL!");
                return;
            }

            if (string.IsNullOrEmpty(txtDiscountThreshold.Text))
            {
                CommonTool.ShowMessage("Discount Threshold can not NULL!");
                return;
            }

            new SystemData().GetTaDiscount();

            TaDiscountInfo discount = new TaDiscountInfo();
            discount.TaType = txtTaType.Text;
            discount.TaDiscount = txtDiscount.Text;
            discount.TaDiscThre = txtDiscountThreshold.Text;

            try
            {
                discount.ID = Convert.ToInt32(gvTaDiscount.GetRowCellValue(gvTaDiscount.FocusedRowHandle, "ID"));
                _control.UpdateEntity(discount);

                BindData();
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void BindData()
        {
            new SystemData().GetTaDiscount();

            gridControlTaDiscount.DataSource = CommonData.TaDiscount.ToList();

            gvTaDiscount.FocusedRowHandle = gvTaDiscount.RowCount - 1;
        }

        private void FrmTaDiscount_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void gvTaDiscount_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvTaDiscount_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtTaType.Text = gvTaDiscount.GetRowCellValue(gvTaDiscount.FocusedRowHandle, "TaType").ToString();
            txtDiscount.Text = gvTaDiscount.GetRowCellValue(gvTaDiscount.FocusedRowHandle, "TaDiscount").ToString();
            txtDiscountThreshold.Text = gvTaDiscount.GetRowCellValue(gvTaDiscount.FocusedRowHandle, "TaDiscThre").ToString();
        }
    }
}