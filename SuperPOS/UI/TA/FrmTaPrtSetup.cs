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
using SuperPOS.Print;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaPrtSetup : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        public FrmTaPrtSetup()
        {
            InitializeComponent();
        }

        public FrmTaPrtSetup(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        #region General Setting 1 Print Language
        /// <summary>
        /// 获得General Setting 1 打印语言
        /// </summary>
        private void Gs1PrtLangData()
        {
            List<string> lstLan = new List<string>();
            lstLan.Add(PrtStatic.PRT_GEN_SET1_LAN_ENG);
            lstLan.Add(PrtStatic.PRT_GEN_SET1_LAN_Other);
            lstLan.Add(PrtStatic.PRT_GEN_SET1_LAN_Both);

            lueGs1PrtLang.Properties.DataSource = lstLan.ToList();
        }
        #endregion

        #region General Setting 1 Font Size
        /// <summary>
        /// 获得General Setting 1 Font Size
        /// </summary>
        private void Gs1PrtFontSize()
        {
            List<string> lstFontSize = new List<string>();
            lstFontSize.Add(PrtStatic.PRT_GEN_SET1_FONT_SIZE_8);
            lstFontSize.Add(PrtStatic.PRT_GEN_SET1_FONT_SIZE_10);
            lstFontSize.Add(PrtStatic.PRT_GEN_SET1_FONT_SIZE_12);
            lstFontSize.Add(PrtStatic.PRT_GEN_SET1_FONT_SIZE_14);
            lstFontSize.Add(PrtStatic.PRT_GEN_SET1_FONT_SIZE_16);
            //lstFontSize.Add(PrtStatic.PRT_GEN_SET1_FONT_SIZE_18);
            //lstFontSize.Add(PrtStatic.PRT_GEN_SET1_FONT_SIZE_20);

            lueGs1FontSize.Properties.DataSource = lstFontSize.ToList();
        }
        #endregion

        #region 获得General

        private void GetGeneral()
        {
            try
            {
                new SystemData().GetTaPrtSetupGeneral();
                var lstPrtSetup = CommonData.TaPrtSetupGeneral;

                if (lstPrtSetup.Any())
                {
                    TaPrtSetupGeneralInfo taPrtSetupGeneral = new TaPrtSetupGeneralInfo();
                    taPrtSetupGeneral = lstPrtSetup.FirstOrDefault();

                    txtTelNo.Text = taPrtSetupGeneral.TelNo;
                    txtVatNo.Text = taPrtSetupGeneral.VATNo;
                    txtMsg1.Text = taPrtSetupGeneral.Msg1;
                    txtMsg2.Text = taPrtSetupGeneral.Msg2;
                    txtMsg3.Text = taPrtSetupGeneral.Msg3;
                    txtMsg4.Text = taPrtSetupGeneral.Msg4;
                }
                else
                {
                    txtTelNo.Text = "";
                    txtVatNo.Text = "";
                    txtMsg1.Text = "";
                    txtMsg2.Text = "";
                    txtMsg3.Text = "";
                    txtMsg4.Text = "";
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            
        }
        #endregion

        #region 获得General Setting 1

        private void GetGenSet1()
        {
            try
            {
                new SystemData().GetTaPrtSetupGetSet1();

                var lstGenSet1 = CommonData.TaPrtSetupGeneralSet1;

                if (lstGenSet1.Any())
                {
                    TaPrtSetupGeneralSet1Info taPrtSetup1 = new TaPrtSetupGeneralSet1Info();
                    taPrtSetup1 = lstGenSet1.FirstOrDefault();

                    lueGs1PrtLang.EditValue = taPrtSetup1.PrtLang;
                    lueGs1FontSize.EditValue = taPrtSetup1.PrtFontSize;
                    txtGs1MsgAtBottom.Text = taPrtSetup1.PrtMsgAtBottom;
                }
                else
                {
                    lueGs1PrtLang.Properties.NullText = "";
                    lueGs1PrtLang.EditValue = "";
                    lueGs1FontSize.Properties.NullText = "";
                    lueGs1FontSize.EditValue = "";
                    txtGs1MsgAtBottom.Text = "";
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }
        }
        #endregion

        private void FrmTaPrtSetup_Load(object sender, EventArgs e)
        {
            Gs1PrtLangData();

            Gs1PrtFontSize();

            GetGeneral();

            GetGenSet1();
        }

        private void btnGenExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGs1Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGenSave_Click(object sender, EventArgs e)
        {
            try
            {
                TaPrtSetupGeneralInfo taPrtSetup = new TaPrtSetupGeneralInfo();
                taPrtSetup.TelNo = txtTelNo.Text;
                taPrtSetup.VATNo = txtVatNo.Text;
                taPrtSetup.Msg1 = txtMsg1.Text;
                taPrtSetup.Msg2 = txtMsg2.Text;
                taPrtSetup.Msg3 = txtMsg3.Text;
                taPrtSetup.Msg4 = txtMsg4.Text;
                taPrtSetup.Msg5 = txtMsg5.Text;

                var lstGen = CommonData.TaPrtSetupGeneral;

                if (lstGen.Any())
                {
                    taPrtSetup.ID = lstGen.FirstOrDefault().ID;
                    _control.UpdateEntity(taPrtSetup);
                }
                else
                {
                    _control.AddEntity(taPrtSetup);
                }

                CommonTool.ShowMessage("Save successful!");
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }
        }

        private void btnGs1Save_Click(object sender, EventArgs e)
        {
            try
            {
                TaPrtSetupGeneralSet1Info taPrtSetupGeneralSet1 = new TaPrtSetupGeneralSet1Info();
                taPrtSetupGeneralSet1.PrtLang = lueGs1PrtLang.EditValue.ToString();
                taPrtSetupGeneralSet1.PrtFontSize = lueGs1FontSize.EditValue.ToString();
                taPrtSetupGeneralSet1.PrtMsgAtBottom = txtGs1MsgAtBottom.Text;

                var lstGs1 = CommonData.TaPrtSetupGeneralSet1;

                if (lstGs1.Any())
                {
                    taPrtSetupGeneralSet1.ID = lstGs1.FirstOrDefault().ID;
                    _control.UpdateEntity(taPrtSetupGeneralSet1);
                }
                else
                {
                    _control.AddEntity(taPrtSetupGeneralSet1);
                }

                CommonTool.ShowMessage("Save successful!");
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }
        }
    }
}