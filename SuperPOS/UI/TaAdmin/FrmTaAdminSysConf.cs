using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.TaAdmin
{
    public partial class FrmTaAdminSysConf : DevExpress.XtraEditors.XtraForm
    {
        //用户ID
        public int usrID = 0;
        //用户姓名
        public string usrName = "";

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private readonly EntityControl _control = new EntityControl();

        private TextEdit[] txtGsPayType = new TextEdit[5];

        //Keypad 控件数组
        private TextEdit[] txtKey = new TextEdit[10];

        public FrmTaAdminSysConf()
        {
            InitializeComponent();
        }

        public FrmTaAdminSysConf(int uID, string sName)
        {
            InitializeComponent();
            usrID = uID;
            usrName = sName;
        }

        private void FrmTaAdminSysConf_Load(object sender, EventArgs e)
        {
            #region Keypad 控件
            txtKey[0] = txtKeySet1;
            txtKey[1] = txtKeySet2;
            txtKey[2] = txtKeySet3;
            txtKey[3] = txtKeySet4;
            txtKey[4] = txtKeySet5;
            txtKey[5] = txtKeySet6;
            txtKey[6] = txtKeySet7;
            txtKey[7] = txtKeySet8;
            txtKey[8] = txtKeySet9;
            txtKey[9] = txtKeySet10;
            #endregion
            //获得Shop Detail信息
            GetShopDetail();

            //获得General Setting信息
            GetGeneralSetting();

            //绑定打印机信息
            BindPrtOpLueData();

            //获得Cash Drawer信息
            GetCashDrawer();

            //获得Caller ID Port Setting
            GetCallIdPortSet();

            //获得Keypad Setting
            GetKeypadSet();

            #region Payment Type
            txtGsPayType[0] = txtPayType1;
            txtGsPayType[1] = txtPayType2;
            txtGsPayType[2] = txtPayType3;
            txtGsPayType[3] = txtPayType4;
            txtGsPayType[4] = txtPayType5;

            SystemData systemData = new SystemData();
            systemData.GetTaPaymentType();
            int i = 0;
            foreach (var taPaymentTypeInfo in CommonData.TaPaymentType)
            {
                txtGsPayType[i].Text = taPaymentTypeInfo.PaymentType;
                i++;
            }

            for (int j = i; j < 5; j++)
            {
                txtGsPayType[j].Text = "";
            }
            #endregion

            asfc.controllInitializeSize(this);
        }

        private void FrmTaAdminSysConf_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        #region 获取信息

        #region 获得Shop Detail信息
        /// <summary>
        /// 获得Shop Detail信息
        /// </summary>
        private void GetShopDetail()
        {
            new SystemData().GetShopDetail();

            try
            {
                if (CommonData.ShopDetail.Any())
                {
                    ShopDetailInfo shopDetailInfo = new ShopDetailInfo();
                    shopDetailInfo = CommonData.ShopDetail.FirstOrDefault();
                    txtShopName.Text = shopDetailInfo.ShopName;
                    txtShopAddr.Text = shopDetailInfo.ShopAddr;
                }
                else
                {
                    txtShopName.Text = "";
                    txtShopAddr.Text = "";
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.Name, ex);
            }
        }
        #endregion

        #region 获得General Setting信息
        /// <summary>
        /// 获得General Setting信息
        /// </summary>
        private void GetGeneralSetting()
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

        #region 获得Cash Drawer信息
        /// <summary>
        /// 获得Cash Drawer信息
        /// </summary>
        private void GetCashDrawer()
        {
            new SystemData().GetTaCashDrawSet();

            if (CommonData.TaCashDrawSet.Any())
            {
                var lstTaCashDraw = CommonData.TaCashDrawSet.FirstOrDefault();
                chkCashDrawSet.Checked = lstTaCashDraw.IsUseCashDraw.Equals("Y");
                if (chkCashDrawSet.Checked)
                {
                    txtPwd.Enabled = true;
                    txtPwd.Text = lstTaCashDraw.CashDrawPwd;
                }
                else
                {
                    txtPwd.Enabled = false;
                    txtPwd.Text = "";
                }
            }
            else
            {
                chkCashDrawSet.Checked = false;
                txtPwd.Enabled = false;
                txtPwd.Text = "";
            }
        }
        #endregion

        #region 获得Caller ID Port Setting
        /// <summary>
        /// 获得Caller ID Port Setting
        /// </summary>
        private void GetCallIdPortSet()
        {
            //To do Something
        }
        #endregion

        #region 获得Keypad Setting
        /// <summary>
        /// 获得Keypad Setting
        /// </summary>
        private void GetKeypadSet()
        {
            new SystemData().GetKeypadList();

            int i = 0;
            foreach (var keypadInfo in CommonData.Keypad.OrderBy(s => s.ID))
            {
                if (!string.IsNullOrEmpty(keypadInfo.KeyCode))
                {
                    txtKey[i].Text = keypadInfo.KeyCode;
                    i++;
                }
                else break;
            }
        }
        #endregion

        #endregion

        #region 保存

        #region 保存Shop Detail信息
        /// <summary>
        /// 保存Shop Detail信息
        /// </summary>
        private void SaveShopDetail()
        {
            try
            {
                ShopDetailInfo shopDetailInfo = new ShopDetailInfo();
                shopDetailInfo.ShopName = txtShopName.Text;
                shopDetailInfo.ShopAddr = txtShopAddr.Text;

                if (CommonData.ShopDetail.Any())
                {
                    shopDetailInfo.ID = CommonData.ShopDetail.FirstOrDefault().ID;
                    _control.UpdateEntity(shopDetailInfo);
                }
                else
                {
                    _control.AddEntity(shopDetailInfo);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }
        }
        #endregion

        #region 保存General Setting信息
        /// <summary>
        /// 保存General Setting信息
        /// </summary>
        private void SaveGeneralSetting()
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
        }
        #endregion

        #region 保存Cash Drawer信息
        /// <summary>
        /// 保存Cash Drawer信息
        /// </summary>
        private void SaveCashDrawer()
        {
            TaCashDrawSetInfo taCashDrawSetInfo = new TaCashDrawSetInfo();

            taCashDrawSetInfo.IsUseCashDraw = chkCashDrawSet.Checked ? "Y" : "N";

            taCashDrawSetInfo.CashDrawPwd = chkCashDrawSet.Checked ? txtPwd.Text : "";

            new SystemData().GetTaCashDrawSet();

            try
            {
                if (CommonData.TaCashDrawSet.Any())
                {
                    taCashDrawSetInfo.ID = CommonData.TaCashDrawSet.FirstOrDefault().ID;
                    _control.UpdateEntity(taCashDrawSetInfo);
                }
                else
                {
                    _control.AddEntity(taCashDrawSetInfo);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

        }
        #endregion

        #region 保存Caller ID Port Setting
        /// <summary>
        /// 保存Caller ID Port Setting
        /// </summary>
        private void SaveCallIdPortSet()
        {
            //To do Something
        }
        #endregion

        #region 保存Print Options

        private void SavePrtOp()
        {
            //To do Something
        }
        #endregion

        #region 保存Keypad Setting
        /// <summary>
        /// 保存Keypad Setting
        /// </summary>
        private void SaveKeypadSet()
        {
            new SystemData().GetKeypadList();

            for (int i = 0; i < 10; i++)
            {
                KeypadInfo keypadInfo = new KeypadInfo();
                keypadInfo.KeyName = @"Key" + (i + 1);
                keypadInfo.KeyCode = txtKey[i].Text;

                try
                {
                    if (CommonData.Keypad.Any(s => s.KeyName.Equals(keypadInfo.KeyName)))
                    {
                        keypadInfo.ID = CommonData.Keypad.FirstOrDefault(s => s.KeyName.Equals(keypadInfo.KeyName)).ID;
                        _control.UpdateEntity(keypadInfo);
                    }
                    else { _control.AddEntity(keypadInfo); }
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }
        }
        #endregion

        #endregion

        #region Print Options LUE控件绑定打印机列表信息
        /// <summary>
        /// Print Options LUE控件绑定打印机列表信息
        /// </summary>
        private void BindPrtOpLueData()
        {
            luePrtOpRptPrt.Properties.DataSource = PrinterSettings.InstalledPrinters;
            luePrtOpA4.Properties.DataSource = PrinterSettings.InstalledPrinters;
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //保存时不允许多次Save点击和Exit
                btnSave.Enabled = false;
                btnExit.Enabled = false;

                #region Pay Type

                int i = 0;
                foreach (var taPaymentTypeInfo in CommonData.TaPaymentType)
                {
                    taPaymentTypeInfo.PaymentType = txtGsPayType[i].Text;

                    _control.UpdateEntity(taPaymentTypeInfo);

                    i++;
                }
                #endregion

                SaveShopDetail();

                SaveGeneralSetting();

                SavePrtOp();

                SaveCallIdPortSet();

                SaveCashDrawer();

                SaveKeypadSet();
            }
            catch (Exception ex) {
                LogHelper.Error(this.Name, ex);
                btnSave.Enabled = true;
                btnExit.Enabled = true;
            }

            CommonTool.ShowMessage("Save successful!");

            btnSave.Enabled = true;
            btnExit.Enabled = true;
        }

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
        /// <summary>
        /// 绑定系统盘符
        /// </summary>
        private void BindSysCol()
        {
            lueBackUpDriver.Properties.DataSource = CommonDAL.GetSysDir().ToList();
        }
        #endregion
    }
}