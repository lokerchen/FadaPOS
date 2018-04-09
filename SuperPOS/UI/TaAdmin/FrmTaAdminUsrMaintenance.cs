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

namespace SuperPOS.UI.TaAdmin
{
    public partial class FrmTaAdminUsrMaintenance : DevExpress.XtraEditors.XtraForm
    {
        //用户ID
        public int usrID = 0;
        //用户姓名
        public string usrName = "";

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private List<SysUsrMaintenanceInfo> lstUsrMain = new List<SysUsrMaintenanceInfo>(); 

        public FrmTaAdminUsrMaintenance()
        {
            InitializeComponent();
        }

        public FrmTaAdminUsrMaintenance(int uID, string sName)
        {
            InitializeComponent();
            usrID = uID;
            usrName = sName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTaAdminUsrMaintenance_Load(object sender, EventArgs e)
        {
            BindLueUsrData();

            new SystemData().GetSysUsrMaintenance();
            lstUsrMain = CommonData.SysUsrMaintenance.ToList();

            this.xtpUsrAccess.SelectedTabPageIndex = 0;

            asfc.controllInitializeSize(this);
        }

        private void FrmTaAdminUsrMaintenance_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        #region 绑定User列表
        /// <summary>
        /// 绑定User列表
        /// </summary>
        private void BindLueUsrData()
        {
            new SystemData().GetUsrBase();

            var lstShiftCode = from usr in CommonData.UsrBase
                               select new
                               {
                                   ScID = usr.ID,
                                   ScName = usr.UsrName
                               };
            lueUsrName.Properties.DataSource = lstShiftCode.ToList();
            lueUsrName.Properties.DisplayMember = "usrName";
            lueUsrName.Properties.ValueMember = "usrID";
        }
        #endregion

        private void lueUsrName_EditValueChanged(object sender, EventArgs e)
        {
            this.xtpUsrAccess.SelectedTabPageIndex = 0;
        }

        private void xtpUsrAccess_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {
            if (e.Page.Name.Equals("xtpTa"))
            {
                
            }
            else if (e.Page.Name.Equals("xtpEi"))
            {
                
            }
            else if (e.Page.Name.Equals("xtpGa"))
            {
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnAddUpdateUser_Click(object sender, EventArgs e)
        {

        }

        private string ChangeBoolToYesOrNo(bool isChecked)
        {
            return isChecked ? "Y" : "N";
        }

        private bool YesOrNoToBool(string isYesOrNo)
        {
            return isYesOrNo.Equals("Y") ? true : false;
        }
    }
}