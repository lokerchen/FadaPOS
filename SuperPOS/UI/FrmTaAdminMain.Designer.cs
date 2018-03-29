namespace SuperPOS.UI.TA
{
    partial class FrmTaAdminMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.SetSys = new DevExpress.XtraNavBar.NavBarGroup();
            this.ShopDetail = new DevExpress.XtraNavBar.NavBarItem();
            this.GenSet = new DevExpress.XtraNavBar.NavBarItem();
            this.KeypadSet = new DevExpress.XtraNavBar.NavBarItem();
            this.CashDrawSet = new DevExpress.XtraNavBar.NavBarItem();
            this.DataManager = new DevExpress.XtraNavBar.NavBarItem();
            this.CompAdd = new DevExpress.XtraNavBar.NavBarItem();
            this.ShiftCode = new DevExpress.XtraNavBar.NavBarItem();
            this.SysPrt = new DevExpress.XtraNavBar.NavBarItem();
            this.SysExit = new DevExpress.XtraNavBar.NavBarItem();
            this.SetTa = new DevExpress.XtraNavBar.NavBarGroup();
            this.TAPaymentType = new DevExpress.XtraNavBar.NavBarItem();
            this.TaDiscount = new DevExpress.XtraNavBar.NavBarItem();
            this.TaDeliveryNote = new DevExpress.XtraNavBar.NavBarItem();
            this.TaFreeFood = new DevExpress.XtraNavBar.NavBarItem();
            this.TaDeliverySet = new DevExpress.XtraNavBar.NavBarItem();
            this.TaPostcodeAssign = new DevExpress.XtraNavBar.NavBarItem();
            this.TaPostcodeSet = new DevExpress.XtraNavBar.NavBarItem();
            this.TAMenuCat = new DevExpress.XtraNavBar.NavBarItem();
            this.TAMenuItem = new DevExpress.XtraNavBar.NavBarItem();
            this.TaSubMenu = new DevExpress.XtraNavBar.NavBarItem();
            this.ExtraMenu = new DevExpress.XtraNavBar.NavBarItem();
            this.TADeptCode = new DevExpress.XtraNavBar.NavBarItem();
            this.TAMenuSet = new DevExpress.XtraNavBar.NavBarItem();
            this.TAPrtInfoSet = new DevExpress.XtraNavBar.NavBarItem();
            this.TaDriver = new DevExpress.XtraNavBar.NavBarItem();
            this.UsrAuth = new DevExpress.XtraNavBar.NavBarGroup();
            this.UsrSet = new DevExpress.XtraNavBar.NavBarItem();
            this.UsrAuthGroup = new DevExpress.XtraNavBar.NavBarItem();
            this.UsrAuthRule = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem1 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem7 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem8 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.TaSysFont = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.FloatSize = new System.Drawing.Size(500, 561);
            this.dockPanel1.ID = new System.Guid("16aeaab6-9f5c-4043-8afd-ae9652e72e2a");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowAutoHideButton = false;
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(342, 200);
            this.dockPanel1.Size = new System.Drawing.Size(342, 712);
            this.dockPanel1.Text = "Control Panel";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.navBarControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 28);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(332, 679);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.SetSys;
            this.navBarControl1.Appearance.Button.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarControl1.Appearance.Button.Options.UseFont = true;
            this.navBarControl1.Appearance.ItemActive.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarControl1.Appearance.ItemActive.Options.UseFont = true;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.SetSys,
            this.SetTa,
            this.UsrAuth});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.CashDrawSet,
            this.UsrSet,
            this.CompAdd,
            this.ShiftCode,
            this.navBarItem5,
            this.navBarItem6,
            this.navBarItem7,
            this.navBarItem8,
            this.TAMenuCat,
            this.TAMenuItem,
            this.TAMenuSet,
            this.TAPaymentType,
            this.TADeptCode,
            this.SysExit,
            this.UsrAuthGroup,
            this.UsrAuthRule,
            this.navBarItem1,
            this.navBarSeparatorItem1,
            this.ShopDetail,
            this.GenSet,
            this.KeypadSet,
            this.TAPrtInfoSet,
            this.SysPrt,
            this.ExtraMenu,
            this.TaDiscount,
            this.TaDeliveryNote,
            this.TaDriver,
            this.DataManager,
            this.TaFreeFood,
            this.TaDeliverySet,
            this.TaPostcodeAssign,
            this.TaPostcodeSet,
            this.TaSubMenu,
            this.TaSysFont});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 332;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.navBarControl1.Size = new System.Drawing.Size(332, 679);
            this.navBarControl1.TabIndex = 2;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Summer 2008");
            // 
            // SetSys
            // 
            this.SetSys.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetSys.Appearance.Options.UseFont = true;
            this.SetSys.Caption = "System Setting";
            this.SetSys.Expanded = true;
            this.SetSys.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.ShopDetail),
            new DevExpress.XtraNavBar.NavBarItemLink(this.GenSet),
            new DevExpress.XtraNavBar.NavBarItemLink(this.KeypadSet),
            new DevExpress.XtraNavBar.NavBarItemLink(this.CashDrawSet),
            new DevExpress.XtraNavBar.NavBarItemLink(this.DataManager),
            new DevExpress.XtraNavBar.NavBarItemLink(this.CompAdd),
            new DevExpress.XtraNavBar.NavBarItemLink(this.ShiftCode),
            new DevExpress.XtraNavBar.NavBarItemLink(this.SysPrt),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TaSysFont),
            new DevExpress.XtraNavBar.NavBarItemLink(this.SysExit)});
            this.SetSys.Name = "SetSys";
            this.SetSys.ShowIcons = DevExpress.Utils.DefaultBoolean.False;
            // 
            // ShopDetail
            // 
            this.ShopDetail.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShopDetail.Appearance.Options.UseFont = true;
            this.ShopDetail.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShopDetail.AppearanceDisabled.Options.UseFont = true;
            this.ShopDetail.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShopDetail.AppearanceHotTracked.Options.UseFont = true;
            this.ShopDetail.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShopDetail.AppearancePressed.Options.UseFont = true;
            this.ShopDetail.Caption = "Shop Detail";
            this.ShopDetail.Name = "ShopDetail";
            this.ShopDetail.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ShopDetail_LinkClicked);
            // 
            // GenSet
            // 
            this.GenSet.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenSet.Appearance.Options.UseFont = true;
            this.GenSet.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenSet.AppearanceDisabled.Options.UseFont = true;
            this.GenSet.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenSet.AppearanceHotTracked.Options.UseFont = true;
            this.GenSet.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenSet.AppearancePressed.Options.UseFont = true;
            this.GenSet.Caption = "General Setting";
            this.GenSet.Name = "GenSet";
            this.GenSet.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.GenSet_LinkClicked);
            // 
            // KeypadSet
            // 
            this.KeypadSet.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeypadSet.Appearance.Options.UseFont = true;
            this.KeypadSet.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeypadSet.AppearanceDisabled.Options.UseFont = true;
            this.KeypadSet.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeypadSet.AppearanceHotTracked.Options.UseFont = true;
            this.KeypadSet.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeypadSet.AppearancePressed.Options.UseFont = true;
            this.KeypadSet.Caption = "Keypad Setting";
            this.KeypadSet.Name = "KeypadSet";
            this.KeypadSet.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.KeypadSet_LinkClicked);
            // 
            // CashDrawSet
            // 
            this.CashDrawSet.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashDrawSet.Appearance.Options.UseFont = true;
            this.CashDrawSet.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashDrawSet.AppearanceDisabled.Options.UseFont = true;
            this.CashDrawSet.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashDrawSet.AppearanceHotTracked.Options.UseFont = true;
            this.CashDrawSet.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashDrawSet.AppearancePressed.Options.UseFont = true;
            this.CashDrawSet.Caption = "Cash Draw Setting";
            this.CashDrawSet.Name = "CashDrawSet";
            this.CashDrawSet.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.CashDrawSet_LinkClicked);
            // 
            // DataManager
            // 
            this.DataManager.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataManager.Appearance.Options.UseFont = true;
            this.DataManager.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataManager.AppearanceDisabled.Options.UseFont = true;
            this.DataManager.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataManager.AppearanceHotTracked.Options.UseFont = true;
            this.DataManager.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataManager.AppearancePressed.Options.UseFont = true;
            this.DataManager.Caption = "Data Manager";
            this.DataManager.Name = "DataManager";
            this.DataManager.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.DataManager_LinkClicked);
            // 
            // CompAdd
            // 
            this.CompAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompAdd.Appearance.Options.UseFont = true;
            this.CompAdd.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompAdd.AppearanceHotTracked.Options.UseFont = true;
            this.CompAdd.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompAdd.AppearancePressed.Options.UseFont = true;
            this.CompAdd.Caption = "Computer Address";
            this.CompAdd.Name = "CompAdd";
            this.CompAdd.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.CompAdd_LinkClicked);
            // 
            // ShiftCode
            // 
            this.ShiftCode.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShiftCode.Appearance.Options.UseFont = true;
            this.ShiftCode.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShiftCode.AppearanceHotTracked.Options.UseFont = true;
            this.ShiftCode.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShiftCode.AppearancePressed.Options.UseFont = true;
            this.ShiftCode.Caption = "Shift Code";
            this.ShiftCode.Name = "ShiftCode";
            this.ShiftCode.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ShiftCode_LinkClicked);
            // 
            // SysPrt
            // 
            this.SysPrt.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SysPrt.Appearance.Options.UseFont = true;
            this.SysPrt.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SysPrt.AppearanceDisabled.Options.UseFont = true;
            this.SysPrt.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SysPrt.AppearanceHotTracked.Options.UseFont = true;
            this.SysPrt.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SysPrt.AppearancePressed.Options.UseFont = true;
            this.SysPrt.Caption = "Printer Setting";
            this.SysPrt.Name = "SysPrt";
            this.SysPrt.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.SysPrt_LinkClicked);
            // 
            // SysExit
            // 
            this.SysExit.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SysExit.Appearance.Options.UseFont = true;
            this.SysExit.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SysExit.AppearanceHotTracked.Options.UseFont = true;
            this.SysExit.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SysExit.AppearancePressed.Options.UseFont = true;
            this.SysExit.Caption = "Exit";
            this.SysExit.Name = "SysExit";
            this.SysExit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.SysExit_LinkClicked);
            // 
            // SetTa
            // 
            this.SetTa.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetTa.Appearance.Options.UseFont = true;
            this.SetTa.Caption = "Takeaway & Quick Dining Setting";
            this.SetTa.Expanded = true;
            this.SetTa.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.TAPaymentType),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TaDiscount),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TaDeliveryNote),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TaFreeFood),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TaDeliverySet),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TaPostcodeAssign),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TaPostcodeSet),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TAMenuCat),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TAMenuItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TaSubMenu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.ExtraMenu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TADeptCode),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TAMenuSet),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TAPrtInfoSet),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TaDriver)});
            this.SetTa.Name = "SetTa";
            this.SetTa.ShowIcons = DevExpress.Utils.DefaultBoolean.False;
            // 
            // TAPaymentType
            // 
            this.TAPaymentType.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAPaymentType.Appearance.Options.UseFont = true;
            this.TAPaymentType.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAPaymentType.AppearanceDisabled.Options.UseFont = true;
            this.TAPaymentType.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAPaymentType.AppearanceHotTracked.Options.UseFont = true;
            this.TAPaymentType.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAPaymentType.AppearancePressed.Options.UseFont = true;
            this.TAPaymentType.Caption = "Payment Type";
            this.TAPaymentType.Name = "TAPaymentType";
            this.TAPaymentType.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TAPaymentType_LinkClicked);
            // 
            // TaDiscount
            // 
            this.TaDiscount.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDiscount.Appearance.Options.UseFont = true;
            this.TaDiscount.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDiscount.AppearanceDisabled.Options.UseFont = true;
            this.TaDiscount.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDiscount.AppearanceHotTracked.Options.UseFont = true;
            this.TaDiscount.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDiscount.AppearancePressed.Options.UseFont = true;
            this.TaDiscount.Caption = "Discount";
            this.TaDiscount.Name = "TaDiscount";
            this.TaDiscount.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TaDiscount_LinkClicked);
            // 
            // TaDeliveryNote
            // 
            this.TaDeliveryNote.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDeliveryNote.Appearance.Options.UseFont = true;
            this.TaDeliveryNote.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDeliveryNote.AppearanceDisabled.Options.UseFont = true;
            this.TaDeliveryNote.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDeliveryNote.AppearanceHotTracked.Options.UseFont = true;
            this.TaDeliveryNote.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDeliveryNote.AppearancePressed.Options.UseFont = true;
            this.TaDeliveryNote.Caption = "Delivery Notes";
            this.TaDeliveryNote.Name = "TaDeliveryNote";
            this.TaDeliveryNote.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TaDeliveryNote_LinkClicked);
            // 
            // TaFreeFood
            // 
            this.TaFreeFood.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaFreeFood.Appearance.Options.UseFont = true;
            this.TaFreeFood.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaFreeFood.AppearanceDisabled.Options.UseFont = true;
            this.TaFreeFood.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaFreeFood.AppearanceHotTracked.Options.UseFont = true;
            this.TaFreeFood.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaFreeFood.AppearancePressed.Options.UseFont = true;
            this.TaFreeFood.Caption = "Free Food Items";
            this.TaFreeFood.Name = "TaFreeFood";
            this.TaFreeFood.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TaFreeFood_LinkClicked);
            // 
            // TaDeliverySet
            // 
            this.TaDeliverySet.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDeliverySet.Appearance.Options.UseFont = true;
            this.TaDeliverySet.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDeliverySet.AppearanceDisabled.Options.UseFont = true;
            this.TaDeliverySet.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDeliverySet.AppearanceHotTracked.Options.UseFont = true;
            this.TaDeliverySet.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDeliverySet.AppearancePressed.Options.UseFont = true;
            this.TaDeliverySet.Caption = "Delivery Settings";
            this.TaDeliverySet.Name = "TaDeliverySet";
            this.TaDeliverySet.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TaDeliverySet_LinkClicked);
            // 
            // TaPostcodeAssign
            // 
            this.TaPostcodeAssign.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaPostcodeAssign.Appearance.Options.UseFont = true;
            this.TaPostcodeAssign.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaPostcodeAssign.AppearanceDisabled.Options.UseFont = true;
            this.TaPostcodeAssign.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaPostcodeAssign.AppearanceHotTracked.Options.UseFont = true;
            this.TaPostcodeAssign.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaPostcodeAssign.AppearancePressed.Options.UseFont = true;
            this.TaPostcodeAssign.Caption = "Postcode Assignment";
            this.TaPostcodeAssign.Name = "TaPostcodeAssign";
            this.TaPostcodeAssign.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TaPostcodeAssign_LinkClicked);
            // 
            // TaPostcodeSet
            // 
            this.TaPostcodeSet.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaPostcodeSet.Appearance.Options.UseFont = true;
            this.TaPostcodeSet.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaPostcodeSet.AppearanceDisabled.Options.UseFont = true;
            this.TaPostcodeSet.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaPostcodeSet.AppearanceHotTracked.Options.UseFont = true;
            this.TaPostcodeSet.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaPostcodeSet.AppearancePressed.Options.UseFont = true;
            this.TaPostcodeSet.Caption = "Postcode Settings";
            this.TaPostcodeSet.Name = "TaPostcodeSet";
            this.TaPostcodeSet.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TaPostcodeSet_LinkClicked);
            // 
            // TAMenuCat
            // 
            this.TAMenuCat.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAMenuCat.Appearance.Options.UseFont = true;
            this.TAMenuCat.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAMenuCat.AppearanceDisabled.Options.UseFont = true;
            this.TAMenuCat.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAMenuCat.AppearanceHotTracked.Options.UseFont = true;
            this.TAMenuCat.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAMenuCat.AppearancePressed.Options.UseFont = true;
            this.TAMenuCat.Caption = "Menu Category";
            this.TAMenuCat.Name = "TAMenuCat";
            this.TAMenuCat.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TAMenuCat_LinkClicked);
            // 
            // TAMenuItem
            // 
            this.TAMenuItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAMenuItem.Appearance.Options.UseFont = true;
            this.TAMenuItem.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAMenuItem.AppearanceDisabled.Options.UseFont = true;
            this.TAMenuItem.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAMenuItem.AppearanceHotTracked.Options.UseFont = true;
            this.TAMenuItem.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAMenuItem.AppearancePressed.Options.UseFont = true;
            this.TAMenuItem.Caption = "Menu Item";
            this.TAMenuItem.Name = "TAMenuItem";
            this.TAMenuItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TAMenuItem_LinkClicked);
            // 
            // TaSubMenu
            // 
            this.TaSubMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaSubMenu.Appearance.Options.UseFont = true;
            this.TaSubMenu.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaSubMenu.AppearanceDisabled.Options.UseFont = true;
            this.TaSubMenu.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaSubMenu.AppearanceHotTracked.Options.UseFont = true;
            this.TaSubMenu.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaSubMenu.AppearancePressed.Options.UseFont = true;
            this.TaSubMenu.Caption = "Sub Menu";
            this.TaSubMenu.Name = "TaSubMenu";
            this.TaSubMenu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TaSubMenu_LinkClicked);
            // 
            // ExtraMenu
            // 
            this.ExtraMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtraMenu.Appearance.Options.UseFont = true;
            this.ExtraMenu.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtraMenu.AppearanceDisabled.Options.UseFont = true;
            this.ExtraMenu.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtraMenu.AppearanceHotTracked.Options.UseFont = true;
            this.ExtraMenu.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtraMenu.AppearancePressed.Options.UseFont = true;
            this.ExtraMenu.Caption = "Extra Menu Edit";
            this.ExtraMenu.Name = "ExtraMenu";
            this.ExtraMenu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ExtraMenu_LinkClicked);
            // 
            // TADeptCode
            // 
            this.TADeptCode.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TADeptCode.Appearance.Options.UseFont = true;
            this.TADeptCode.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TADeptCode.AppearanceDisabled.Options.UseFont = true;
            this.TADeptCode.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TADeptCode.AppearanceHotTracked.Options.UseFont = true;
            this.TADeptCode.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TADeptCode.AppearancePressed.Options.UseFont = true;
            this.TADeptCode.Caption = "Department Code";
            this.TADeptCode.Name = "TADeptCode";
            this.TADeptCode.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TADeptCode_LinkClicked);
            // 
            // TAMenuSet
            // 
            this.TAMenuSet.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAMenuSet.Appearance.Options.UseFont = true;
            this.TAMenuSet.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAMenuSet.AppearanceDisabled.Options.UseFont = true;
            this.TAMenuSet.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAMenuSet.AppearanceHotTracked.Options.UseFont = true;
            this.TAMenuSet.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAMenuSet.AppearancePressed.Options.UseFont = true;
            this.TAMenuSet.Caption = "Menu Set";
            this.TAMenuSet.Name = "TAMenuSet";
            this.TAMenuSet.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TAMenuSet_LinkClicked);
            // 
            // TAPrtInfoSet
            // 
            this.TAPrtInfoSet.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAPrtInfoSet.Appearance.Options.UseFont = true;
            this.TAPrtInfoSet.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAPrtInfoSet.AppearanceDisabled.Options.UseFont = true;
            this.TAPrtInfoSet.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAPrtInfoSet.AppearanceHotTracked.Options.UseFont = true;
            this.TAPrtInfoSet.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAPrtInfoSet.AppearancePressed.Options.UseFont = true;
            this.TAPrtInfoSet.Caption = "Printer infomation";
            this.TAPrtInfoSet.Name = "TAPrtInfoSet";
            // 
            // TaDriver
            // 
            this.TaDriver.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDriver.Appearance.Options.UseFont = true;
            this.TaDriver.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDriver.AppearanceDisabled.Options.UseFont = true;
            this.TaDriver.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDriver.AppearanceHotTracked.Options.UseFont = true;
            this.TaDriver.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaDriver.AppearancePressed.Options.UseFont = true;
            this.TaDriver.Caption = "Driver Set Up";
            this.TaDriver.Name = "TaDriver";
            this.TaDriver.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TaDriver_LinkClicked);
            // 
            // UsrAuth
            // 
            this.UsrAuth.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrAuth.Appearance.Options.UseFont = true;
            this.UsrAuth.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrAuth.AppearanceHotTracked.Options.UseFont = true;
            this.UsrAuth.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrAuth.AppearancePressed.Options.UseFont = true;
            this.UsrAuth.Caption = "User Authorization";
            this.UsrAuth.Expanded = true;
            this.UsrAuth.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.UsrSet),
            new DevExpress.XtraNavBar.NavBarItemLink(this.UsrAuthGroup),
            new DevExpress.XtraNavBar.NavBarItemLink(this.UsrAuthRule),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem1)});
            this.UsrAuth.Name = "UsrAuth";
            this.UsrAuth.ShowIcons = DevExpress.Utils.DefaultBoolean.False;
            // 
            // UsrSet
            // 
            this.UsrSet.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrSet.Appearance.Options.UseFont = true;
            this.UsrSet.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrSet.AppearanceHotTracked.Options.UseFont = true;
            this.UsrSet.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrSet.AppearancePressed.Options.UseFont = true;
            this.UsrSet.Caption = "User Setting";
            this.UsrSet.Name = "UsrSet";
            this.UsrSet.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.UsrSet_LinkClicked);
            // 
            // UsrAuthGroup
            // 
            this.UsrAuthGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrAuthGroup.Appearance.Options.UseFont = true;
            this.UsrAuthGroup.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrAuthGroup.AppearanceDisabled.Options.UseFont = true;
            this.UsrAuthGroup.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrAuthGroup.AppearanceHotTracked.Options.UseFont = true;
            this.UsrAuthGroup.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrAuthGroup.AppearancePressed.Options.UseFont = true;
            this.UsrAuthGroup.Caption = "Authority Group";
            this.UsrAuthGroup.Name = "UsrAuthGroup";
            this.UsrAuthGroup.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.UsrAuthGroup_LinkClicked);
            // 
            // UsrAuthRule
            // 
            this.UsrAuthRule.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrAuthRule.Appearance.Options.UseFont = true;
            this.UsrAuthRule.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrAuthRule.AppearanceHotTracked.Options.UseFont = true;
            this.UsrAuthRule.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrAuthRule.AppearancePressed.Options.UseFont = true;
            this.UsrAuthRule.Caption = "Authority Rule";
            this.UsrAuthRule.Name = "UsrAuthRule";
            this.UsrAuthRule.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.UsrAuthRule_LinkClicked);
            // 
            // navBarSeparatorItem1
            // 
            this.navBarSeparatorItem1.CanDrag = false;
            this.navBarSeparatorItem1.Enabled = false;
            this.navBarSeparatorItem1.Hint = null;
            this.navBarSeparatorItem1.LargeImageIndex = 0;
            this.navBarSeparatorItem1.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem1.Name = "navBarSeparatorItem1";
            this.navBarSeparatorItem1.SmallImageIndex = 0;
            this.navBarSeparatorItem1.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "navBarItem5";
            this.navBarItem5.Name = "navBarItem5";
            // 
            // navBarItem6
            // 
            this.navBarItem6.Caption = "navBarItem6";
            this.navBarItem6.Name = "navBarItem6";
            // 
            // navBarItem7
            // 
            this.navBarItem7.Caption = "navBarItem7";
            this.navBarItem7.Name = "navBarItem7";
            // 
            // navBarItem8
            // 
            this.navBarItem8.Caption = "navBarItem8";
            this.navBarItem8.Name = "navBarItem8";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "User Setting";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(342, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1015, 712);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1008, 676);
            this.xtraTabPage1.Text = "Admin Control";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(997, 615);
            // 
            // TaSysFont
            // 
            this.TaSysFont.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaSysFont.Appearance.Options.UseFont = true;
            this.TaSysFont.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaSysFont.AppearanceDisabled.Options.UseFont = true;
            this.TaSysFont.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaSysFont.AppearanceHotTracked.Options.UseFont = true;
            this.TaSysFont.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaSysFont.AppearancePressed.Options.UseFont = true;
            this.TaSysFont.Caption = "System Button Font";
            this.TaSysFont.Name = "TaSysFont";
            this.TaSysFont.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TaSysFont_LinkClicked);
            // 
            // FrmTaAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 712);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.dockPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaAdminMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTaAdminMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaAdminMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup SetSys;
        private DevExpress.XtraNavBar.NavBarGroup SetTa;
        private DevExpress.XtraNavBar.NavBarItem CashDrawSet;
        private DevExpress.XtraNavBar.NavBarItem UsrSet;
        private DevExpress.XtraNavBar.NavBarItem CompAdd;
        private DevExpress.XtraNavBar.NavBarItem ShiftCode;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem6;
        private DevExpress.XtraNavBar.NavBarItem navBarItem7;
        private DevExpress.XtraNavBar.NavBarItem navBarItem8;
        private DevExpress.XtraNavBar.NavBarItem TAMenuCat;
        private DevExpress.XtraNavBar.NavBarItem TAMenuItem;
        private DevExpress.XtraNavBar.NavBarItem TAMenuSet;
        private DevExpress.XtraNavBar.NavBarItem TAPaymentType;
        private DevExpress.XtraNavBar.NavBarItem TADeptCode;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraNavBar.NavBarItem SysExit;
        private DevExpress.XtraNavBar.NavBarGroup UsrAuth;
        private DevExpress.XtraNavBar.NavBarItem UsrAuthGroup;
        private DevExpress.XtraNavBar.NavBarItem UsrAuthRule;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem ShopDetail;
        private DevExpress.XtraNavBar.NavBarItem GenSet;
        private DevExpress.XtraNavBar.NavBarItem KeypadSet;
        private DevExpress.XtraNavBar.NavBarItem TAPrtInfoSet;
        private DevExpress.XtraNavBar.NavBarItem SysPrt;
        private DevExpress.XtraNavBar.NavBarItem ExtraMenu;
        private DevExpress.XtraNavBar.NavBarItem TaDiscount;
        private DevExpress.XtraNavBar.NavBarItem TaDeliveryNote;
        private DevExpress.XtraNavBar.NavBarItem TaDriver;
        private DevExpress.XtraNavBar.NavBarItem DataManager;
        private DevExpress.XtraNavBar.NavBarItem TaFreeFood;
        private DevExpress.XtraNavBar.NavBarItem TaDeliverySet;
        private DevExpress.XtraNavBar.NavBarItem TaPostcodeAssign;
        private DevExpress.XtraNavBar.NavBarItem TaPostcodeSet;
        private DevExpress.XtraNavBar.NavBarItem TaSubMenu;
        private DevExpress.XtraNavBar.NavBarItem TaSysFont;
    }
}