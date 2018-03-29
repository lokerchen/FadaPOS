using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.Sys
{
    public partial class FrmUsrAuthRule : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";
        //新增/更新
        private bool isAdd = false;

        private readonly EntityControl _control = new EntityControl();

        //默认为ACCESS_TAKEAWAY
        private string curClass = PubComm.ACCESS_TAKEAWAY;

        public FrmUsrAuthRule()
        {
            InitializeComponent();
        }

        public FrmUsrAuthRule(int uId, string uName)
        {
            InitializeComponent();
            usrID = uId;
            usrName = uName;
        }

        private void BindData(int GrpId, string strAccess)
        {
            new SystemData().GetUsrAuthRule();

            var lstData = CommonData.UsrAuthRule;

            if (GrpId != 0 && !string.IsNullOrEmpty(strAccess))
                lstData = CommonData.UsrAuthRule.Where(s => s.AccessDept.Equals(strAccess) && s.GrpID.Equals(lueAuthGrp.EditValue.ToString())).ToList();

            gridControlAccess.DataSource = lstData.ToList();

            gvAccess.FocusedRowHandle = gvAccess.RowCount - 1;
        }

        private void BindComboxData()
        {
            new SystemData().GetUsrAuthGroup();

            var lstGrp = from uag in CommonData.UsrAuthGroup
                        select new
                        {
                            GroupID = uag.ID,
                            GroupName = uag.GrpEngName
                        };
            lueAuthGrp.Properties.DataSource = lstGrp.ToList();

            lueAuthGrp.Properties.DisplayMember = "GroupName";
            lueAuthGrp.Properties.ValueMember = "GroupID";
            lueAuthGrp.ItemIndex = 0;
        }

        private void FrmUsrAuthRule_Load(object sender, EventArgs e)
        {
            BindComboxData();

            BindData(Convert.ToInt32(lueAuthGrp.EditValue), PubComm.ACCESS_TAKEAWAY);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvAccess.RowCount; i++)
                {
                    UsrAuthRuleInfo usrAuthRuleInfo = new UsrAuthRuleInfo();
                    usrAuthRuleInfo.GrpID = gvAccess.GetRowCellValue(i, "GrpID").ToString();
                    usrAuthRuleInfo.AccessDept = gvAccess.GetRowCellValue(i, "AccessDept").ToString();
                    usrAuthRuleInfo.AccessDetail = gvAccess.GetRowCellValue(i, "AccessDetail").ToString();
                    //usrAuthRuleInfo.AccessBtnID = gvAccess.GetRowCellValue(i, "AccessBtnID").ToString();
                    usrAuthRuleInfo.IsAccess = gvAccess.GetRowCellValue(i, "IsAccess").ToString();

                    new SystemData().GetUsrAuthRule();

                    var lstAr = CommonData.UsrAuthRule.Where(s => s.ID == Convert.ToInt32(lueAuthGrp.EditValue));

                    if (lstAr.Any())
                    {
                        usrAuthRuleInfo.ID = Convert.ToInt32(gvAccess.GetRowCellValue(i, "ID"));
                        _control.UpdateEntity(usrAuthRuleInfo);
                    }
                    else
                    {
                        _control.AddEntity(usrAuthRuleInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.Name, ex);
            }

            CommonTool.ShowMessage("Save successful!");
        }

        private void xtcOtherChoice_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {
            if (e.Page.Name.Equals("xtraTabPageTakeaway")) curClass = PubComm.ACCESS_TAKEAWAY;
            else if (e.Page.Name.Equals("xtraTabPageQuickFood")) curClass = PubComm.ACCESS_QUICKFOOD;
            else if (e.Page.Name.Equals("xtraTabPageEatIn")) curClass = PubComm.ACCESS_EATIN;
            else if (e.Page.Name.Equals("xtraTabPageGeneral")) curClass = PubComm.ACCESS_GENERAL;
            else curClass = PubComm.ACCESS_TAKEAWAY;

            BindData(Convert.ToInt32(lueAuthGrp.EditValue), curClass);
        }

        private void lueAuthGrp_EditValueChanged(object sender, EventArgs e)
        {
            BindData(Convert.ToInt32(lueAuthGrp.EditValue), curClass);
        }
    }
}