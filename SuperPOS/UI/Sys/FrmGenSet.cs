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

namespace SuperPOS.UI.Sys
{
    public partial class FrmGenSet : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        public FrmGenSet()
        {
            InitializeComponent();
        }

        public FrmGenSet(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        #region Save保存事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GenSetInfo genSetInfo = new GenSetInfo();
                genSetInfo.TillNum = txtTillNum.Text;
                genSetInfo.CheckCurrency = txtCheckCurrency.Text;
                genSetInfo.VATPer = txtVatPer.Text;
                genSetInfo.IsShowItemCode = chkDisplayCode.Checked ? "Y" : "N";
                genSetInfo.IsBackup = chkIsBackup.Checked ? "Y" : "N";

                if (chkIsBackup.Checked)
                {
                    genSetInfo.BackupDriver = lueBackUpDriver.EditValue.ToString();
                }
                else
                    genSetInfo.BackupDriver = "";

                if (CommonData.GenSet.Any())
                {
                    genSetInfo.ID = CommonData.GenSet.FirstOrDefault().ID;
                    _control.UpdateEntity(genSetInfo);
                }
                else
                {
                    _control.AddEntity(genSetInfo);
                }

                new SystemData().GetSysValue();
                var lstValue = CommonData.SysValue.Where(s => s.ValueID.Equals(PubComm.SYS_VALUE_CHECK_CODE));
                SysValueInfo sysValueInfo = new SysValueInfo();

                if (lstValue.Any())
                {
                    sysValueInfo = lstValue.FirstOrDefault();
                    sysValueInfo.ValueResult = txtTillNum.Text;
                    _control.UpdateEntity(sysValueInfo);
                }
                else
                {
                    sysValueInfo.ValueID = PubComm.SYS_VALUE_CHECK_CODE;
                    sysValueInfo.ValueDesc = "CHECKCODE";
                    sysValueInfo.ValueResult = txtTillNum.Text;
                    _control.AddEntity(sysValueInfo);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
        }
        #endregion

        #region 窗口加载事件
        private void FrmGenSet_Load(object sender, EventArgs e)
        {
            new SystemData().GenSet();

            try
            {
                if (CommonData.GenSet.Any())
                {
                    GenSetInfo genSetInfo = new GenSetInfo();
                    genSetInfo = CommonData.GenSet.FirstOrDefault();
                    txtTillNum.Text = genSetInfo.TillNum;
                    txtCheckCurrency.Text = genSetInfo.CheckCurrency;
                    txtVatPer.Text = genSetInfo.VATPer;
                    chkDisplayCode.Checked = genSetInfo.IsShowItemCode.Equals("Y");
                    if (string.IsNullOrEmpty(genSetInfo.IsBackup))
                    {
                        chkIsBackup.Checked = false;
                        lueBackUpDriver.Properties.NullText = "";
                        lueBackUpDriver.EditValue = "";
                    }
                    else
                    {
                        chkIsBackup.Checked = genSetInfo.IsBackup.Equals("Y");

                        if (chkIsBackup.Checked) lueBackUpDriver.EditValue = genSetInfo.BackupDriver;
                    }
                    
                }
                else
                {
                    txtTillNum.Text = "";
                    txtCheckCurrency.Text = "";
                    txtVatPer.Text = "";
                    chkDisplayCode.Checked = false;
                    chkIsBackup.Checked = false;
                    lueBackUpDriver.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.Name, ex);
            }
        }
        #endregion

        private void chkIsBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDisplayCode.Checked) lueBackUpDriver.Enabled = false;
            else
            {
                lueBackUpDriver.Enabled = true;
                BindSysCol();
            }
        }

        #region 绑定系统盘符

        private void BindSysCol()
        {
            lueBackUpDriver.Properties.DataSource = CommonDAL.GetSysDir().ToList();
        }
        #endregion
    }
}