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
using DevExpress.XtraTab;
using SuperPOS.UI.Sys;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaAdminMain : DevExpress.XtraEditors.XtraForm
    {
        //用户ID
        public int usrID = 0;
        //用户姓名
        public string usrName = "";

        public FrmTaAdminMain()
        {
            InitializeComponent();
        }

        public FrmTaAdminMain(int uID, string sName)
        {
            InitializeComponent();
            usrID = uID;
            usrName = sName;
        }

        private void FrmTaAdminMain_Load(object sender, EventArgs e)
        {
            //treeMenu.ExpandAll();
        }

        #region Shift Code
        private void ShiftCode_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("SysShiftCode", "Shift Code", new FrmShiftCode(usrID, usrName));
        }
        #endregion

        #region Exit
        private void SysExit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region User Setting
        private void UsrSet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("UsrSet", "User Setting", new FrmUsrSet(usrID, usrName));
        }
        #endregion

        #region Computer Address
        private void CompAdd_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("CompAddr", "Computer Address", new FrmCompAddr(usrID, usrName));
        }
        #endregion

        #region Shop Details
        private void ShopDetail_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("ShopDetail", "Shop Details", new FrmShopDetail(usrID, usrName));
        }
        #endregion

        #region 显示XtraTabPage
        /// <summary>
        /// 显示XtraTabPage
        /// </summary>
        /// <param name="pageName">窗口名字</param>
        /// <param name="pageText">窗口标题</param>
        /// <param name="frmObject">窗口实例</param>
        private void ShowXtraTabPage(string pageName, string pageText, Form frmObject)
        {
            XtraTabPage page = new XtraTabPage();
            page.Name = pageName; //窗口名字
            page.Text = pageText;//窗口标题
            if (!xtraTabControl1.TabPages.Any(s => s.Text.Equals(page.Text)))
            {

                Form frm = frmObject;
                frm.TopLevel = false;
                frm.Show();
                page.Controls.Add(frm);
                this.xtraTabControl1.TabPages.Add(page);
            }
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages.FirstOrDefault(s => s.Text.Equals(page.Text));
        }
        #endregion

        #region General Setting
        private void GenSet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("GenSet", "General Setting", new FrmGenSet(usrID, usrName));
        }
        #endregion

        #region Keypad Setting
        private void KeypadSet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("KeypadSet", "Keypad Setting", new FrmKeyPadSet(usrID, usrName));
        }
        #endregion

        #region Printer Setting
        private void SysPrt_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("SysPrt", "Printer Setting", new FrmPrtSet(usrID, usrName));
        }
        #endregion

        #region Takeaway
        #region Department Code
        private void TADeptCode_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("TADeptCode", "Department Code", new FrmTaDeptCode(usrID, usrName));
        }
        #endregion

        #endregion

        #region TA MenuSet
        private void TAMenuSet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("TAMenuSet", "Menu Set", new FrmTaMenuSet(usrID, usrName));
        }
        #endregion

        #region Menu Cate
        private void TAMenuCat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("MenuCate", "Menu Category", new FrmTaMenuCate(usrID, usrName));
        }
        #endregion

        #region Menu Item
        private void TAMenuItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("MenuItem", "Menu Item", new FrmTaMenuItem(usrID, usrName));
        }
        #endregion

        #region Extra Menu
        private void ExtraMenu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("ExtraMenu", "Extra Menu", new FrmTaExtraMenuEdit(usrID, usrName));
        }
        #endregion

        #region Payment Type
        private void TAPaymentType_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("TaPaymentType", "Payment Type", new FrmTaPaymentType(usrID, usrName));
        }
        #endregion

        #region Discount
        private void TaDiscount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("TaDiscount", "Discount", new FrmTaDiscount(usrID, usrName));
        }
        #endregion

        #region Delivery Note
        private void TaDeliveryNote_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("TaDeliveryNote", "Pre-defined Delivery Notes", new FrmTaDeliveryNote(usrID, usrName));
        }
        #endregion

        private void TaDriver_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("TaDriver", "Driver Set up", new FrmTaDriver(usrID, usrName));
        }

        #region Cash Draw Set
        private void CashDrawSet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("CashDrawSet", "Cash Draw Setting", new FrmTaCashDrawSet(usrID, usrName));
        }
        #endregion

        #region User Authority Group
        private void UsrAuthGroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("UsrAuthGroup", "User Authority Group", new FrmUsrAuthGrp(usrID, usrName));
        }
        #endregion

        #region User Rule
        private void UsrAuthRule_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("UsrAuthRule", "User Rule", new FrmUsrAuthRule(usrID, usrName));
        }
        #endregion

        #region Data Manager
        private void DataManager_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("DataManager", "DataManager", new FrmDataManager(usrID, usrName));
        }
        #endregion

        #region Free Food Item
        private void TaFreeFood_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("TaFreeFood", "Free Food Items", new FrmTaFreeItem(usrID, usrName));
        }
        #endregion

        #region Delivery Setting
        private void TaDeliverySet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("DeliverySet", "Delivery Settings", new FrmTaDeliverySet(usrID, usrName));
        }
        #endregion

        #region Postcode Assignment
        private void TaPostcodeAssign_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("PostcodeAssignment", "Postcode Assignment", new FrmTaPostCode(usrID, usrName));
        }
        #endregion

        #region Postcode Settings
        private void TaPostcodeSet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("PostcodeSettings", "Postcode Settings", new FrmTaPostCodeSet(usrID, usrName));
        }
        #endregion

        #region Sub Menu
        private void TaSubMenu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("SubMenu", "Sub Menu", new FrmTaSubMenu(usrID, usrName));
        }
        #endregion

        private void TaSysFont_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowXtraTabPage("TaSysFont", "MenuItem/Category Button Font", new FrmTaSysFont(usrID, usrName));
        }
    }
}