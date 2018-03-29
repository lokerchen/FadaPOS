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
    public partial class FrmTaPostCode : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        //是否为Add
        private bool isAdd = false;

        //标识为那个TabelPage
        private int iTblPage = 1;

        public FrmTaPostCode()
        {
            InitializeComponent();
        }

        public FrmTaPostCode(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        private void BindData(int iPage)
        {
            new SystemData().GetTaPostcodeCharge();
            new SystemData().GetTaPostcodeZone();

            if (iPage == 2)
            {
                var lstZone = CommonData.TaPostcodeZone.ToList();

                gridControlZone.DataSource = lstZone;
                gvZone.FocusedRowHandle = gvZone.RowCount - 1;
            }
            else
            {
                var lstCharge = CommonData.TaPostcodeCharge.ToList();

                gridControlCharge.DataSource = lstCharge;
                gvCharge.FocusedRowHandle = gvCharge.RowCount - 1;
            }
        }

        private void FrmTaPostCode_Load(object sender, EventArgs e)
        {
            BindData(iTblPage);
        }

        private void gvCharge_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvZone_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvCharge_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvCharge.RowCount > 0)
            {
                txtPostCodeCharge.Text = gvCharge.GetRowCellValue(gvCharge.FocusedRowHandle, "PostCode").ToString();
                txtCharge.Text = gvCharge.GetRowCellValue(gvCharge.FocusedRowHandle, "PostCharge").ToString();
            }
            else
            {
                txtPostCodeCharge.Text = "";
                txtCharge.Text = "";
            }
        }

        private void gvZone_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvZone.RowCount > 0)
            {
                txtPostCodeZone.Text = gvZone.GetRowCellValue(gvZone.FocusedRowHandle, "PostCode").ToString();
                txtZone.Text = gvZone.GetRowCellValue(gvZone.FocusedRowHandle, "Zone").ToString();
            }
            else
            {
                txtPostCodeZone.Text = "";
                txtZone.Text = "";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (iTblPage == 1)
            {
                txtPostCodeCharge.Text = "";
                txtCharge.Text = "";
            }
            else
            {
                txtPostCodeZone.Text = "";
                txtZone.Text = "";
            }

            isAdd = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (iTblPage == 1)
            {
                if (string.IsNullOrEmpty(txtPostCodeCharge.Text))
                {
                    CommonTool.ShowMessage("Postcode can not NULL!");
                    return;
                }

                if (string.IsNullOrEmpty(txtCharge.Text))
                {
                    CommonTool.ShowMessage("Charge can not NULL!");
                    return;
                }

                new SystemData().GetTaPostcodeCharge();

                TaPostcodeChargeInfo taPostcodeChargeInfo = new TaPostcodeChargeInfo();
                taPostcodeChargeInfo.PostCode = txtPostCodeCharge.Text;
                taPostcodeChargeInfo.PostCharge = txtCharge.Text;

                try
                {
                    if (isAdd)
                    {
                        _control.AddEntity(taPostcodeChargeInfo);
                        isAdd = false;
                    }
                    else
                    {
                        taPostcodeChargeInfo.ID = Convert.ToInt32(gvCharge.GetRowCellValue(gvCharge.FocusedRowHandle, "ID"));
                        _control.UpdateEntity(taPostcodeChargeInfo);
                    }

                    CommonTool.ShowMessage("Save successful!");

                    BindData(iTblPage);
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }
            else
            {
                if (string.IsNullOrEmpty(txtPostCodeZone.Text))
                {
                    CommonTool.ShowMessage("Postcode can not NULL!");
                    return;
                }

                if (string.IsNullOrEmpty(txtZone.Text))
                {
                    CommonTool.ShowMessage("Zone can not NULL!");
                    return;
                }

                new SystemData().GetTaPostcodeZone();

                TaPostcodeZoneInfo taPostcodeZoneInfo = new TaPostcodeZoneInfo();
                taPostcodeZoneInfo.PostCode = txtPostCodeZone.Text;
                taPostcodeZoneInfo.Zone = txtZone.Text;

                try
                {
                    if (isAdd)
                    {
                        _control.AddEntity(taPostcodeZoneInfo);
                        isAdd = false;
                    }
                    else
                    {
                        taPostcodeZoneInfo.ID = Convert.ToInt32(gvZone.GetRowCellValue(gvZone.FocusedRowHandle, "ID"));
                        _control.UpdateEntity(taPostcodeZoneInfo);
                    }

                    CommonTool.ShowMessage("Save successful!");

                    BindData(iTblPage);
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                if (iTblPage == 1)
                {
                    try
                    {
                        _control.DeleteEntity(CommonData.TaPostcodeCharge.FirstOrDefault(s => s.ID == Convert.ToInt32(gvCharge.GetRowCellValue(gvCharge.FocusedRowHandle, "ID"))));
                        CommonTool.ShowMessage("Delete successful!");
                        BindData(iTblPage);
                        isAdd = false;
                    }
                    catch (Exception ex) { LogHelper.Error(this.Name, ex); }
                }
                else
                {
                    try
                    {
                        _control.DeleteEntity(CommonData.TaPostcodeZone.FirstOrDefault(s => s.ID == Convert.ToInt32(gvZone.GetRowCellValue(gvZone.FocusedRowHandle, "ID"))));
                        CommonTool.ShowMessage("Delete successful!");
                        BindData(iTblPage);
                        isAdd = false;
                    }
                    catch (Exception ex) { LogHelper.Error(this.Name, ex); }
                }
            }
        }

        private void xtcOtherChoice_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {
            iTblPage = 1;
        }

        private void xtcPostcodeCharge_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {
            iTblPage = e.Page.Name.Equals("xtraTabPageCharge") ? 1 : 2;

            BindData(iTblPage);
        }
    }
}