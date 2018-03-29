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
    public partial class FrmTaPostCodeSet : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        //是否为Add
        private bool isAdd = false;

        public FrmTaPostCodeSet()
        {
            InitializeComponent();
        }

        public FrmTaPostCodeSet(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        private void BindData()
        {
            new SystemData().GetTaPostcodeSet();

            gridControlPCSet.DataSource = CommonData.TaPostcodeSet.ToList();

            gvPCSet.FocusedRowHandle = gvPCSet.RowCount - 1;
        }

        private void FrmTaPostCodeSet_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtPostCode.Text = "";
            txtPCZone.Text = "";
            txtPCDist.Text = "";
            txtPCAddr.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 判断是否为空
            if (string.IsNullOrEmpty(txtPostCode.Text))
            {
                CommonTool.ShowMessage("Postcode can not NULL");
                return;
            }

            if (string.IsNullOrEmpty(txtPCZone.Text))
            {
                CommonTool.ShowMessage("PC Zone can not NULL");
                return;
            }

            if (string.IsNullOrEmpty(txtPCDist.Text))
            {
                CommonTool.ShowMessage("Distance can not NULL");
                return;
            }

            if (string.IsNullOrEmpty(txtPCAddr.Text))
            {
                CommonTool.ShowMessage("Address can not NULL");
                return;
            }
            #endregion

            new SystemData().GetTaPostcodeSet();

            TaPostcodeSetInfo taPostcodeSetInfo = new TaPostcodeSetInfo();
            taPostcodeSetInfo.PostCode = txtPostCode.Text;
            taPostcodeSetInfo.PCZone = txtPCZone.Text;
            taPostcodeSetInfo.PCDist = txtPCDist.Text;
            taPostcodeSetInfo.PCAddr = txtPCAddr.Text;

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(taPostcodeSetInfo);
                    isAdd = false;
                }
                else
                {
                    taPostcodeSetInfo.ID = Convert.ToInt32(gvPCSet.GetRowCellValue(gvPCSet.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taPostcodeSetInfo);
                }

                CommonTool.ShowMessage("Save successful!");

                BindData();
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.TaPostcodeSet.FirstOrDefault(s => s.ID == Convert.ToInt32(gvPCSet.GetRowCellValue(gvPCSet.FocusedRowHandle, "ID"))));
                    CommonTool.ShowMessage("Delete successful!");
                    BindData();
                    isAdd = false;
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }
        }

        private void gvPCSet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtPostCode.Text = gvPCSet.GetRowCellValue(gvPCSet.FocusedRowHandle, "PostCode").ToString();
            txtPCZone.Text = gvPCSet.GetRowCellValue(gvPCSet.FocusedRowHandle, "PCZone").ToString();
            txtPCDist.Text = gvPCSet.GetRowCellValue(gvPCSet.FocusedRowHandle, "PCDist").ToString();
            txtPCAddr.Text = gvPCSet.GetRowCellValue(gvPCSet.FocusedRowHandle, "PCAddr").ToString();
        }
    }
}