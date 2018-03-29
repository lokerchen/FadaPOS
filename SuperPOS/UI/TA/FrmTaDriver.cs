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
    public partial class FrmTaDriver : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        //是否为Add
        private bool isAdd = false;

        public FrmTaDriver()
        {
            InitializeComponent();
        }

        public FrmTaDriver(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        private void FrmTaDriver_Load(object sender, EventArgs e)
        {
            BindChkWorkDay(false);

            BindData();
        }

        #region 绑定chkWorkDay
        /// <summary>
        /// 绑定chkWorkDay
        /// </summary>
        private void BindChkWorkDay(bool isClear)
        {
            if (isClear) chkWorkDay.Properties.Items.Clear();
            chkWorkDay.Properties.Items.AddRange(PubComm.WORD_DAY);
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtDriverName.Text = "";
            txtPhoneNum.Text = "";

            BindChkWorkDay(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDriverName.Text))
            {
                CommonTool.ShowMessage("Driver Name can not NULL!");
                return;
            }

            if (string.IsNullOrEmpty(txtPhoneNum.Text))
            {
                CommonTool.ShowMessage("Phone Number can not NULL!");
                return;
            }

            new SystemData().GetTaDriver();

            TaDriverInfo taDriverInfo = new TaDriverInfo();
            taDriverInfo.DriverName = txtDriverName.Text;
            taDriverInfo.DriverNumber = txtPhoneNum.Text;
            taDriverInfo.DriverWorkDay = chkWorkDay.EditValue.ToString();

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taDriverInfo);
                    isAdd = false;
                }
                else
                {
                    taDriverInfo.ID = Convert.ToInt32(gvTaDriver.GetRowCellValue(gvTaDriver.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taDriverInfo);
                }

                BindData();
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            new SystemData().GetTaDriver();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaDriver.FirstOrDefault(s => s.ID ==
                                Convert.ToInt32(gvTaDriver.GetRowCellValue(gvTaDriver.FocusedRowHandle, "ID"))));
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

        private void BindData()
        {
            new SystemData().GetTaDriver();

            gridControlTaDriver.DataSource = CommonData.TaDriver.ToList();

            gvTaDriver.FocusedRowHandle = gvTaDriver.RowCount - 1;
        }

        private void gvTaDriver_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvTaDriver_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtDriverName.Text = gvTaDriver.GetRowCellValue(gvTaDriver.FocusedRowHandle, "DriverName").ToString();
            txtPhoneNum.Text = gvTaDriver.GetRowCellValue(gvTaDriver.FocusedRowHandle, "DriverNumber").ToString();
            chkWorkDay.EditValue = gvTaDriver.GetRowCellValue(gvTaDriver.FocusedRowHandle, "DriverWorkDay");
            chkWorkDay.Text = gvTaDriver.GetRowCellValue(gvTaDriver.FocusedRowHandle, "DriverWorkDay").ToString();
        }
    }
}