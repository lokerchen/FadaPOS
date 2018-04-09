using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.Sys
{
    public partial class FrmUsrSet : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int ID = 0;
        //登录用户名字
        private string usrName = "";
        //新增/更新
        private bool isAdd = false;

        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmUsrSet()
        {
            InitializeComponent();
        }

        public FrmUsrSet(int id, string sUsrName)
        {
            InitializeComponent();

            ID = id;
            usrName = sUsrName;
        }

        #region 绑定/刷新数据
        /// <summary>
        /// 绑定/刷新数据
        /// </summary>
        private void BindData()
        {
            SystemData sd = new SystemData();
            sd.GetUsrBase();
            sd.GetUsrAuthAccess();
            sd.GetUsrAuthGroup();

            var lstUsr = from ub in CommonData.UsrBase
                         join aa in CommonData.UsrAuthAccess
                             on ub.ID equals aa.UsrID
                         join ag in CommonData.UsrAuthGroup
                             on aa.AuthGrpID equals ag.ID
                         select new
                         {
                             ID = ub.ID,
                             UsrName = ub.UsrName,
                             UsrPwd = ub.UsrPwd,
                             UsrAuthGrpName = ag.GrpEngName,
                             CreateBy = ub.CreateBy,
                             CreateTime = ub.CreateTime,
                             UsrAuthGrpID = ag.ID,
                             UsrAccID = aa.ID
                         };
            //自动调整列宽
            gvUsrSet.BestFitColumns();
            gcUsr.DataSource = lstUsr.ToList();

            gvUsrSet.FocusedRowHandle = gvUsrSet.RowCount - 1;
        }
        #endregion

        private void FrmUsrSet_Load(object sender, EventArgs e)
        {
            BindComboData();

            BindData();

            asfc.controllInitializeSize(this);
        }

        private void gvUsrSet_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        #region 绑定User Authority Group数据
        /// <summary>
        /// 绑定User Authority Group数据
        /// </summary>
        private void BindComboData()
        {
            new SystemData().GetUsrAuthGroup();

            var lstUsrAuthGrp = from ag in CommonData.UsrAuthGroup
                                select new
                                {
                                    ID = ag.ID,
                                    GrpName = ag.GrpEngName
                                };

            lueUsrAuthGrp.Properties.DataSource = lstUsrAuthGrp.ToList();
            lueUsrAuthGrp.Properties.DisplayMember = "GrpName"; //指定显示字段
            lueUsrAuthGrp.Properties.ValueMember = "ID";  //实际存储字段

            lueUsrAuthGrp.Properties.PopulateColumns();

        }
        #endregion

        private void gvUsrSet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtUsrName.Text = gvUsrSet.GetRowCellValue(gvUsrSet.FocusedRowHandle, "UsrName").ToString();
            txtUsrPwd.Text = gvUsrSet.GetRowCellValue(gvUsrSet.FocusedRowHandle, "UsrPwd").ToString();
            lueUsrAuthGrp.EditValue = Convert.ToInt32(gvUsrSet.GetRowCellValue(gvUsrSet.FocusedRowHandle, "UsrAuthGrpID"));
            lueUsrAuthGrp.Text = gvUsrSet.GetRowCellValue(gvUsrSet.FocusedRowHandle, "UsrAuthGrpName").ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            txtUsrName.Text = "";
            txtUsrPwd.Text = "";
            lueUsrAuthGrp.ItemIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsrName.Text))
            {
                CommonTool.ShowMessage("User Name is empty,please enter!");
                return;
            }

            if (string.IsNullOrEmpty(txtUsrName.Text))
            {
                CommonTool.ShowMessage("User Password is empty,please enter!");
                return;
            }

            if (string.IsNullOrEmpty(lueUsrAuthGrp.EditValue.ToString()))
            {
                CommonTool.ShowMessage("Please select User Authority Group!");
                return;
            }

            new SystemData().GetUsrAuthAccess();

            UsrAuthAccessInfo usrAuthAccessInfo = new UsrAuthAccessInfo();
            usrAuthAccessInfo.UsrID = Convert.ToInt32(gvUsrSet.GetRowCellValue(gvUsrSet.FocusedRowHandle, "ID"));
            usrAuthAccessInfo.AuthGrpID = Convert.ToInt32(lueUsrAuthGrp.EditValue);
            usrAuthAccessInfo.CreateBy = usrName;
            usrAuthAccessInfo.CreateTime = DateTime.Now.ToString();

            UsrBaseInfo usrBaseInfo = new UsrBaseInfo();
            usrBaseInfo.UsrName = txtUsrName.Text;
            usrBaseInfo.UsrPwd = txtUsrPwd.Text;
            usrBaseInfo.CreateBy = usrName;
            usrBaseInfo.CreateTime = DateTime.Now.ToString();

            try
            {
                if (isAdd)
                {
                    _control.AddEntity(usrBaseInfo);

                    new SystemData().GetUsrBase();
                    usrAuthAccessInfo.UsrID = CommonData.UsrBase.Max(s => s.ID);
                    _control.AddEntity(usrAuthAccessInfo); //新增

                    isAdd = false;
                }
                else
                {
                    usrBaseInfo.ID = Convert.ToInt32(gvUsrSet.GetRowCellValue(gvUsrSet.FocusedRowHandle, "ID"));

                    _control.UpdateEntity(usrBaseInfo);

                    if (CommonData.UsrAuthAccess.Any(s => s.UsrID == Convert.ToInt32(gvUsrSet.GetRowCellValue(gvUsrSet.FocusedRowHandle, "ID"))))
                    {
                        usrAuthAccessInfo.ID = CommonData.UsrAuthAccess.FirstOrDefault(s => s.UsrID ==
                                               Convert.ToInt32(gvUsrSet.GetRowCellValue(gvUsrSet.FocusedRowHandle, "ID")))
                                               .ID;
                        _control.UpdateEntity(usrAuthAccessInfo);
                    }
                }

                BindData();
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            new SystemData().GetUsrBase();
            new SystemData().GetUsrAuthAccess();

            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                try
                {
                    _control.DeleteEntity(CommonData.UsrBase.FirstOrDefault(s => s.ID == Convert.ToInt32(gvUsrSet.GetRowCellValue(gvUsrSet.FocusedRowHandle, "ID"))));
                    _control.DeleteEntity(CommonData.UsrAuthAccess.FirstOrDefault(s => s.ID == Convert.ToInt32(gvUsrSet.GetRowCellValue(gvUsrSet.FocusedRowHandle, "UsrAccID"))));
                    CommonTool.ShowMessage("Delete successful!");
                    BindData();
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUsrSet_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}