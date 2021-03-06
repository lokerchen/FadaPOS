using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;
using Microsoft.Office.Interop.Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SuperPOS.UI.TA;

namespace SuperPOS.Common
{
    public class CommonDAL
    {
        //Menu Item每页大小
        public static int PAGESIZE_MENUITEM = 16;

        //Menu Category每页大小
        public static int PAGESIZE_MENUCATE = 42;

        //页码
        private static int PAGE_NUM = 0;

        private static EntityControl _control = new EntityControl();

        // 申明要使用的dll和api
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("Drawcash.dll")]
        private static extern bool OpenDriverCash2(int code1, int code2, int code3, int code4, int code5, string printerName);

        private static System.Diagnostics.Process softKey;

        #region 加载系统数据
        /// <summary>
        /// 加载系统数据
        /// </summary>
        public static void InitData()
        {
            #region 数据加载
            SystemData systemData = new SystemData();
            //获得Shift Code
            systemData.GetTaShiftCodeList();
            //用户列表
            systemData.GetUsrBase();
            //用户权限
            systemData.GetUsrAuthAccess();
            systemData.GetUsrAuthDetail();
            systemData.GetUsrAuthGroup();
            systemData.GetUsrAuthRule();
            //Computer Address
            systemData.GetCompAddr();
            //店铺详情
            systemData.GetShopDetail();
            //General设定
            systemData.GenSet();
            //Keypad设定
            systemData.GetKeypadList();
            //打印机列表
            systemData.GetSysPrtList();
            //改码
            systemData.GetTaExtraMenu();
            //用户使用钱箱
            systemData.GetTaCashDrawSet();
            //获得Data Manager
            systemData.GetDataManager();
            //获得Free Food
            systemData.GetTaFreeFood();
            //获得Free Food Add
            systemData.GetTaFreeFoodAdd();
            //获得Delivery Set
            systemData.GetTaDeliverySet();
            systemData.GetTaDeliverySetDetail();
            //Post code
            systemData.GetTaPostcodeCharge();
            systemData.GetTaPostcodeZone();
            //Post code settings
            systemData.GetTaPostcodeSet();
            //Sub Menu
            systemData.GetTaSubMenu();
            systemData.GetTaSubMenuDetail();
            //获得MenuItem和Menu Category按钮字体大小
            systemData.GetTaSysFont();
            //获得Change Price时修改菜名的后缀
            systemData.GetTaChangeMenuAttr();
            #region Takeaway
            //Department Code
            systemData.GetTaDeptCode();
            //Menu Set
            systemData.GetTaMenuSet();
            //Menu Category
            systemData.GetTaMenuCate();
            //Menu Item
            systemData.GetTaMenuItem();
            //Menu Item Other Choice
            systemData.GetTaMenuItemOtherChoice();
            //Menu Item Sub Menu
            systemData.GetTaMenuItemSubMenu();//Order Item
            systemData.GetTaOrderItem();
            //Check Order
            systemData.GetTaCheckOrder();
            //系统常用值
            systemData.GetSysValue();
            //付款类型
            systemData.GetTaPaymentType();
            //折扣
            systemData.GetTaDiscount();
            //Delivery Note
            systemData.GetTaDeliveryNote();
            //Driver Set Up
            systemData.GetTaDriver();
            //客户信息
            systemData.GetTaCustomer();
            //账单信息
            systemData.GetTaPayment();
            //付款信息
            systemData.GetTaPaymentDetail();
            //Print Setup
            systemData.GetTaPrtSetupGeneral();
            //Print Set General Setting 1
            systemData.GetTaPrtSetupGetSet1();
            #endregion
            //System Setting
            systemData.GetSysUsrMaintenance();
            //Takeaway Configuration
            systemData.GetTaConfMenuDisplayFont();

            systemData.GetTaSysCtrl();

            ////打印模板
            //systemData.GetTaPreview();
            //DelegatePrt dp = new DelegatePrt();
            //dp.SaveShowOrderModelPreview();
            systemData.GetTaSysPrtSetGeneral();
            systemData.GetTaSysPrtSetCountSetting1();
            systemData.GetTaSysPrtSetCountSetting2();
            systemData.GetTaSysPrtSetKitchen();
            #endregion

            systemData.GetAccountSummary("", "");

            //systemData.GetPrtAccountSummary("", "");

            #region 存储默认打印机名，打印时需要用到
            new SystemData().GetSysValue();
            var lstSv = CommonData.SysValue.Where(s => s.ValueID.Equals(PubComm.SYS_VALUE_DEFAULT_PRINT_NAME));

            SysValueInfo sysValueInfo = new SysValueInfo();
            sysValueInfo.ValueID = PubComm.SYS_VALUE_DEFAULT_PRINT_NAME;
            sysValueInfo.ValueDesc = @"PRINT_DEFAULT_NAME";
            PrintDocument printDocument = new PrintDocument();
            sysValueInfo.ValueResult = printDocument.PrinterSettings.PrinterName;

            if (lstSv.Any())
            {
                sysValueInfo.ID = lstSv.FirstOrDefault().ID;
                _control.UpdateEntity(sysValueInfo);
            }
            else
            {
                _control.AddEntity(sysValueInfo);
            }
            #endregion
        }
        #endregion

        #region 获取Session
        /// <summary>
        /// 获取Session
        /// </summary>
        /// <returns></returns>
        public static string GetSession()
        {
            new SystemData().GetTaShiftCodeList();

            return CommonData.TaShiftCodeList.Any(sc => DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToShortTimeString()), Convert.ToDateTime(sc.DtFrom)) >= 0
                            && DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToShortTimeString()), Convert.ToDateTime(sc.DtEnd)) <= 0)
                    ? CommonData.TaShiftCodeList.FirstOrDefault(sc => DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToShortTimeString()), Convert.ToDateTime(sc.DtFrom)) >= 0
                            && DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToShortTimeString()), Convert.ToDateTime(sc.DtEnd)) <= 0).ShiftName
                    : "";
        }

        #endregion

        #region 验证登录用户密码是否正确
        /// <summary>
        /// 验证登录用户密码是否正确
        /// </summary>
        /// <param name="strPwd">用户密码</param>
        /// <returns></returns>
        public static bool IsUser(string strPwd)
        {
            return true;
        }
        #endregion

        #region 判断用户权限
        /// <summary>
        /// 判断用户权限
        /// </summary>
        /// <param name="sID">用户ID</param>
        /// <returns></returns>
        public static bool IsUsrAuth(int sID)
        {
            new SystemData().GetUsrAuthAccess();

            var lst = from aa in CommonData.UsrAuthAccess
                      join ag in CommonData.UsrAuthGroup
                      on aa.AuthGrpID equals ag.ID
                      where aa.UsrID == sID
                      select new
                      {
                          ID = aa.ID
                      };

            return lst.Any();
        }
        #endregion

        #region 用户登录判断
        /// <summary>
        /// 用户登录判断
        /// </summary>
        /// <param name="strPwd">用户密码</param>
        /// <returns></returns>
        public static bool IsUsr(string strPwd)
        {
            new SystemData().GetUsrBase();

            var lstUsr = CommonData.UsrBase.Where(s => s.UsrPwd.Equals(strPwd));

            return lstUsr.Any();
        }
        #endregion

        #region 获得用户ID
        /// <summary>
        /// 获得用户ID
        /// </summary>
        /// <param name="strPwd">用户密码</param>
        /// <returns></returns>
        public static int GetUsrID(string strPwd)
        {
            var lstUsrID = CommonData.UsrBase.Where(s => s.UsrPwd.Equals(strPwd));

            return lstUsrID.Any() ? lstUsrID.FirstOrDefault().ID : 0;
        }
        #endregion

        #region 获得用户名

        public static string GetUsrName(int id)
        {
            new SystemData().GetUsrBase();

            return CommonData.UsrBase.FirstOrDefault(s => s.ID == id).UsrName;
        }
        #endregion

        #region 是否需要在TaMain按钮中展示Menu Item Code
        /// <summary>
        /// 是否需要在TaMain按钮中展示Menu Item Code
        /// </summary>
        /// <returns></returns>
        public static bool IsShowMenuItemCode()
        {
            new SystemData().GenSet();

            return CommonData.GenSet.Any() && CommonData.GenSet.FirstOrDefault().IsShowItemCode.Equals("Y");
        }
        #endregion

        #region 获得MenuItem分页
        /// <summary>
        /// 获得MenuItem分页
        /// </summary>
        /// <param name="iPageNum">页码</param>
        /// <param name="iMenuCateId">MenuCate ID</param>
        /// <param name="iMenuSetId">MenuSet ID</param>
        /// <returns></returns>
        public static List<TaMenuItemInfo> GetListQueryPageMenuItem(int iPageNum, int iMenuCateId, int iMenuSetId)
        {
            //new SystemData().GetTaMenuItem();

            if (iMenuSetId == 0)
            {
                if (iMenuCateId == 0)
                {
                    return CommonData.TaMenuItem.Skip(PAGESIZE_MENUITEM*(iPageNum - 1))
                        .Take(PAGESIZE_MENUITEM).ToList();
                }
                else
                {
                    return CommonData.TaMenuItem.Where(s => s.MiMenuCateID.Replace(" ", "").Split(',').Contains(iMenuCateId.ToString()))
                           .Skip(PAGESIZE_MENUITEM * (iPageNum - 1))
                           .Take(PAGESIZE_MENUITEM).ToList();
                }
            }
            else
            {
                if (iMenuCateId == 0)
                {
                    return CommonData.TaMenuItem.Where(s => s.MiMenuSetID == iMenuSetId)
                                         .Skip(PAGESIZE_MENUITEM * (iPageNum - 1))
                                         .Take(PAGESIZE_MENUITEM).ToList();
                }
                else
                {
                    return CommonData.TaMenuItem.Where(s => s.MiMenuSetID == iMenuSetId && s.MiMenuCateID.Replace(" ", "").Split(',').Contains(iMenuCateId.ToString()))
                                         .Skip(PAGESIZE_MENUITEM * (iPageNum - 1))
                                         .Take(PAGESIZE_MENUITEM).ToList();
                }
            }
        }
        #endregion

        #region 获得MenuCate分页
        /// <summary>
        /// 获得MenuCate分页
        /// </summary>
        /// <param name="iPageNum">页码</param>
        /// <param name="id">MenuSet ID</param>
        /// <returns></returns>
        public static List<TaMenuCateInfo> GetListQueryPageMenuCate(int iPageNum, int msId)
        {
            //new SystemData().GetTaMenuCate();

            return msId == 0
                ? CommonData.TaMenuCate.OrderBy(s => Convert.ToInt32(s.CatePosition)).Skip(PAGESIZE_MENUCATE*(iPageNum - 1)).Take(PAGESIZE_MENUCATE).ToList()
                : CommonData.TaMenuCate.Where(s => s.MenuSetID == msId).Skip(PAGESIZE_MENUCATE*(iPageNum - 1)).Take(PAGESIZE_MENUCATE).OrderBy(s => Convert.ToInt32(s.CatePosition)).ToList();
        }

        #endregion

        #region 查找关键字，获得MenuItem分页
        /// <summary>
        /// 查找关键字，获得MenuItem分页
        /// </summary>
        /// <param name="iPageNum">页码</param>
        /// <param name="sKeyWord">查询关键字</param>
        /// <returns></returns>
        public static List<TaMenuItemInfo> GetListQueryPageMenuItemByKeyWord(int iPageNum, string sKeyWord)
        {
            new SystemData().GetTaMenuItem();

            return !string.IsNullOrEmpty(sKeyWord)
                ? CommonData.TaMenuItem.Where(s => s.MiEngName.Contains(sKeyWord) || s.MiOtherName.Contains(sKeyWord))
                    .Skip(PAGESIZE_MENUITEM*(iPageNum - 1))
                    .Take(PAGESIZE_MENUITEM).ToList()
                : CommonData.TaMenuItem
                    .Skip(PAGESIZE_MENUITEM*(iPageNum - 1))
                    .Take(PAGESIZE_MENUITEM).ToList();
        }

        #endregion

        #region 获得账单号
        /// <summary>
        /// 获得账单号
        /// </summary>
        /// <returns></returns>
        public static string GetCheckCode(bool isUpdate)
        {
            new SystemData().GetSysValue();

            var lstValue = CommonData.SysValue.Where(s => s.ValueID.Equals(PubComm.SYS_VALUE_CHECK_CODE));

            SysValueInfo sysValueInfo = new SysValueInfo();
            //return lstValue.Any() ? lstValue.FirstOrDefault().ValueResult : "1";
            if (lstValue.Any())
            {
                sysValueInfo = lstValue.FirstOrDefault();
                string sc = sysValueInfo.ValueResult;
                if (isUpdate)
                {
                    //sysValueInfo.ValueResult = (Convert.ToInt32(sysValueInfo.ValueResult) + 1).ToString();
                    new SystemData().GetTaCheckOrder();
                    var lstCheck = CommonData.TaCheckOrder.OrderByDescending(s => s.CheckCode)
                                                          .Take(5);

                    if (lstCheck.Any())
                    {
                        sc = (Convert.ToInt64(lstCheck.FirstOrDefault().CheckCode) + 1).ToString();
                    }
                    else
                    {
                        sc = sysValueInfo.ValueResult = (Convert.ToInt32(sysValueInfo.ValueResult) + 1).ToString();
                    }
                }
                else
                {
                    sysValueInfo.ValueResult = (Convert.ToInt32(sysValueInfo.ValueResult) - 1).ToString();
                }
                _control.UpdateEntity(sysValueInfo);
                return sc;
            }
            else
            {
                sysValueInfo.ValueID = PubComm.SYS_VALUE_CHECK_CODE;
                sysValueInfo.ValueDesc = "CHECKCODE";
                sysValueInfo.ValueResult = "1";
                return "1";
            }
        }
        #endregion

        #region 获得账单号

        /// <summary>
        /// 获得账单号
        /// </summary>
        /// <returns></returns>
        public static string GetCheckCode()
        {
            new SystemData().GetSysValue();
            //获得当前营业日
            string strBusDate = GetBusDate();

            //new SystemData().GetTaCheckOrder();

            //当前营业日期内是否存在订单
            var lstCheck = CommonData.TaCheckOrder.Where(s => s.BusDate.Equals(strBusDate)).OrderByDescending(s => s.ID).Take(1);

            if (lstCheck.Any()) //若当前营业日期存在订单，则从订单列表中取最大订单号+1
            {
                return (Convert.ToUInt64(lstCheck.FirstOrDefault().CheckCode) + 1).ToString();
            }
            else    //若当前营业日期不存在订单，则订单号取SYS_VALUE_CHECK_CODE+1
            {
                var lstValue = CommonData.SysValue.Where(s => s.ValueID.Equals(PubComm.SYS_VALUE_CHECK_CODE));

                return lstValue.Any() ? (Convert.ToInt32(lstValue.FirstOrDefault().ValueResult)).ToString() : "1";
            }
        }
        #endregion

        #region 获得Free Food Item Amount
        public static string GetSysValue(string sValueID, string sValueDesc, string dResult)
        {
            new SystemData().GetSysValue();

            var lstValue = CommonData.SysValue.Where(s => s.ValueID.Equals(sValueID));

            SysValueInfo sysValueInfo = new SysValueInfo();
            if (lstValue.Any())
            {
                sysValueInfo = lstValue.FirstOrDefault();

                if (string.IsNullOrEmpty(dResult))
                {
                    _control.UpdateEntity(sysValueInfo);
                    return sysValueInfo.ValueResult;
                }
                else
                {
                    sysValueInfo.ValueResult = dResult;
                    _control.UpdateEntity(sysValueInfo);
                    return dResult;
                }

            }
            else
            {
                sysValueInfo.ValueID = sValueID;
                //sysValueInfo.ValueDesc = "FREEFOODITEMAMOUNT";
                sysValueInfo.ValueDesc = sValueDesc;
                sysValueInfo.ValueResult = string.IsNullOrEmpty(dResult) ? "0.00" : dResult;
                _control.AddEntity(sysValueInfo);
                return dResult;
            }
        }
        #endregion

        #region 更新账单号
        /// <summary>
        /// 更新账单号
        /// </summary>
        /// <param name="checkCode">原账单号</param>
        public static void UpdateCheckCode(string checkCode)
        {
            new SystemData().GetSysValue();

            var lstValue = CommonData.SysValue.Where(s => s.ValueID.Equals(PubComm.SYS_VALUE_CHECK_CODE));

            if (lstValue.Any())
            {
                SysValueInfo sysValueInfo = new SysValueInfo();
                sysValueInfo.ValueID = lstValue.FirstOrDefault().ValueID;
                sysValueInfo.ValueDesc = lstValue.FirstOrDefault().ValueDesc;
                sysValueInfo.ValueResult = (Convert.ToInt32(checkCode) + 1).ToString();

                _control.UpdateEntity(sysValueInfo);
            }
        }
        #endregion

        #region 获得折扣

        public static decimal GetTaDiscount(string sType, decimal MenuAmount)
        {
            new SystemData().GetTaDiscount();

            var lstDiscount = CommonData.TaDiscount.Where(s => s.TaType.Equals(sType.ToUpper()));

            TaDiscountInfo tdi = lstDiscount.FirstOrDefault();

            return tdi != null
                ? (MenuAmount >= Convert.ToDecimal(tdi.TaDiscThre)
                    ? 1 - Convert.ToDecimal(tdi.TaDiscount) / 100
                    : 0.00m)
                : 0.00m;
        }
        #endregion

        #region 获得Delivery Surcharge

        public static decimal GetTaDeliverySurcharge(decimal dMenuAmount)
        {
            new SystemData().GetTaDeliverySet();

            var lstDs = CommonData.TaDeliverySet;

            TaDeliverySetInfo tds = lstDs.FirstOrDefault();

            decimal dResult = 0.00m;
            decimal dSurcharge = 0.00m;
            decimal dOrderThreshold = 0.00m;
            decimal dSurchargeAmount = 0.00m;

            if (tds != null)
            {
                dOrderThreshold = Convert.ToDecimal(string.IsNullOrEmpty(tds.OrderThreshold) ? "0.00" : tds.OrderThreshold);
                dSurchargeAmount = Convert.ToDecimal(string.IsNullOrEmpty(tds.SurchargeAmount) ? "0.00" : tds.SurchargeAmount);

                if (tds.DeliveryMile.Equals("Y"))
                {
                    dResult = 0.00m;
                }
                else
                {
                    //if (tds.IsIgnoreDelivery.Equals("Y"))
                    //{
                    //    dResult = dMenuAmount < dOrderThreshold ? dSurchargeAmount : 0.00m;
                    //}
                    //else
                    //{
                        
                    //}

                    dResult = dMenuAmount < dOrderThreshold ? dSurchargeAmount : 0.00m;
                }
            }

            return dResult;
        }
        #endregion

        #region 获得具体折扣值

        public static decimal GetTaDiscountAmount(string sType, decimal MenuAmount)
        {
            decimal dis = GetTaDiscount(sType, MenuAmount);

            //return dis <= 0.00m ? Math.Round(MenuAmount, 2) : Math.Round(MenuAmount*(1 - dis), 2);
            return dis <= 0.00m ? 0.00m : Math.Round(MenuAmount * (1 - dis), 2);
        }

        #endregion

        #region 获得总单价格
        public static decimal GetTotalAmount(decimal menuAmount, decimal dDiscount, List<TaOrderItemInfo> lstTaOi)
        {
            return dDiscount <= 0.00m ? Math.Round(menuAmount, 2)  : Math.Round(menuAmount * dDiscount, 2);
        }

        #endregion

        public static decimal GetAllDiscount(List<TaOrderItemInfo> lstTaOi, decimal dDiscount)
        {
            var lstDMi = lstTaOi.Where(s => s.IsDiscount.Equals("Y") && s.ItemType.Equals(PubComm.MENU_ITEM_MAIN));

            decimal dAmount = 0.00m;

            if (lstDMi.Any())
            {
                dAmount = lstDMi.Sum(s => Convert.ToDecimal(s.ItemTotalPrice));
            }

            return dDiscount <= 0 
                    ? 0.00m 
                    : dDiscount >= 1.00m ? 0.00m : Math.Round(dAmount * (1 - dDiscount), 2);
        }

        #region 获得系统盘符列表（只有硬盘和可移动磁盘）
        /// <summary>
        /// 获得系统盘符列表（只有硬盘和可移动磁盘）
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSysDir()
        {
            List<string> lst = new List<string>();
            SelectQuery selectQuery = new SelectQuery(PubComm.SELECT_WIN32_LOGICALDISK);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);
            foreach (ManagementObject disk in searcher.Get().Cast<ManagementObject>().Where(disk => disk["DriveType"].ToString().Equals("3") || disk["DriveType"].ToString().Equals("2")))
            {
                lst.Add(disk["Name"].ToString().Trim(':'));
            }

            return lst;
        }
        #endregion

        #region 打开系统模拟键盘

        public static void OpenSysKeyBoard()
        {
            //打开软键盘
            try
            {
                if (!System.IO.File.Exists(Environment.SystemDirectory + "\\osk.exe"))
                {
                    MessageBox.Show("Can not find the system osk！");
                    return;
                }


                softKey = System.Diagnostics.Process.Start("C:\\Windows\\System32\\osk.exe");
                // 上面的语句在打开软键盘后，系统还没用立刻把软键盘的窗口创建出来了。所以下面的代码用循环来查询窗口是否创建，只有创建了窗口
                // FindWindow才能找到窗口句柄，才可以移动窗口的位置和设置窗口的大小。这里是关键。
                IntPtr intptr = IntPtr.Zero;
                while (IntPtr.Zero == intptr)
                {
                    System.Threading.Thread.Sleep(100);
                    //intptr = FindWindow(null, "屏幕键盘");
                    string Ci = System.Threading.Thread.CurrentThread.CurrentCulture.Name;

                    intptr = FindWindow(null, Ci.Equals("zh-CN") ? "屏幕键盘" : "On-Screen Keyboard");
                }

                // 获取屏幕尺寸
                int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
                int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;

                // 设置软键盘的显示位置，底部居中
                int posX = (iActulaWidth - 828)/2;
                int posY = (iActulaHeight - 170);


                //设定键盘显示位置
                MoveWindow(intptr, posX, posY, 828, 170, true);

                //设置软键盘到前端显示
                SetForegroundWindow(intptr);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                LogHelper.Error(ex.Message, ex);
            }
        }
        #endregion

        #region Show Order模板
        public static void SaveShowOrderModelPreview()
        {
            try
            {
                string content = @"";

                TaPreviewInfo taPreview = new TaPreviewInfo();

                foreach (var f in new DirectoryInfo(PrtStatic.PRT_TEMPLATE_FILE_PATH).GetFiles())
                {
                    if (f.Length > 0)
                    {
                        switch (f.Name)
                        {
                            case @"taKitchen.txt":
                                taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_KITCHEN_PRE;
                                break;
                            case @"taReceipt.txt":
                                taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_RECEIPT_PRE;
                                break;
                            case @"taBill.txt":
                                taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_TA_BILL_PRE;
                                break;
                            case @"ta.txt":
                                taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_ALL_PRE;
                                break;
                            case @"showorder.txt":
                                taPreview.PreviewType = PrtStatic.PRT_TEMPLATE_SHOWORDER_PRE;
                                break;
                        }

                        taPreview.PreviewFileName = f.Name;
                        StreamReader objReader = new StreamReader(PrtStatic.PRT_TEMPLATE_FILE_PATH + f.Name, Encoding.UTF8);
                        taPreview.PreviewContent = objReader.ReadToEnd();

                        var lstTaPreview = CommonData.TaPreview.Where(s => s.PreviewType.Equals(taPreview.PreviewType));

                        if (lstTaPreview.Any())
                        {
                            taPreview.ID = lstTaPreview.FirstOrDefault(s => s.PreviewType.Equals(taPreview.PreviewType)).ID;
                            _control.UpdateEntity(taPreview);
                        }
                        else
                        {
                            _control.AddEntity(taPreview);
                        }
                    }
                }
            }
            catch (Exception ex) { LogHelper.Error(@"CommonDAL", ex); }
        }
        #endregion

        #region 获得Business Date
        /// <summary>
        /// 获得Business Date
        /// </summary>
        /// <returns>返回Business Date</returns>
        public static string GetBusDate()
        {
            new SystemData().GetSysValue();

            string sBusDate = CommonData.SysValue.FirstOrDefault(s => s.ValueID.Equals(PubComm.SYS_VALUE_BUS_DATE)).ValueResult;

            //Now大于SysValue中设置的值，则属于当天，否则减一天
            DateTime dt = DateTime.Compare(DateTime.Now, Convert.ToDateTime(sBusDate)) > 0 ? DateTime.Now : DateTime.Now.AddDays(-1);
            
            string strBusDate = dt.ToString(PubComm.DATE_TIME_FORMAT, DateTimeFormatInfo.InvariantInfo);

            return strBusDate;
            //return "2019-12-15";
        }
        #endregion

        #region 计算Delivery Fee
        /// <summary>
        /// 计算Delivery Fee
        /// </summary>
        /// <param name="strDistance">用户距离</param>
        /// <returns></returns>
        public static decimal GetDeliveryFee(string strDistance, string strOrderTotal)
        {
            //结算结果
            decimal dResult = 0.00m;

            try
            {
                //送餐费
                decimal dDistFee = 0.00m;
                ////附加费
                //decimal dSurcharge = 0.00m;
                ////餐费分隔点
                //decimal dOrderThreshold = 0.00m;
                //总餐费
                decimal dOrderTotal = Convert.ToDecimal(strOrderTotal);

                ////超过送餐费的部分
                //decimal dOutDistance = 0.00m;

                new SystemData().GetTaDeliverySetDetail();
                var lstDsd = CommonData.TaDeliverySetDetail.Where(s => !string.IsNullOrEmpty(s.DistFrom) && !string.IsNullOrEmpty(s.DistTo)).OrderByDescending(s => s.AmountToPay);

                if (lstDsd.Any())
                {
                    decimal dDistance = Convert.ToDecimal(string.IsNullOrEmpty(strDistance) ? "0.00" : strDistance);

                    //TaDeliverySetDetailInfo taDeliverySetDetail = lstDsd.FirstOrDefault();
                    //dOutDistance = Convert.ToDecimal(taDeliverySetDetail.DistTo);

                    bool isRangeDist = false;

                    //计算距离产生的费用
                    foreach (var taDeliverySetDetailInfo in lstDsd.Where(taDeliverySetDetailInfo => dDistance >= Convert.ToDecimal(string.IsNullOrEmpty(taDeliverySetDetailInfo.DistFrom) ? "0" : taDeliverySetDetailInfo.DistFrom)
                                                                                                && dDistance <= Convert.ToDecimal(string.IsNullOrEmpty(taDeliverySetDetailInfo.DistTo) ? "9999" : taDeliverySetDetailInfo.DistTo)))
                    {
                        dResult = Convert.ToDecimal(string.IsNullOrEmpty(taDeliverySetDetailInfo.AmountToPay) ? "0" : taDeliverySetDetailInfo.AmountToPay);
                        isRangeDist = true;//是否在列表内，false:不在列表内
                        break;
                    }

                    //超出距离列表之外
                    if (!isRangeDist)
                    {
                        decimal dOrderThreshold = 0.00m;
                        decimal dSurchargeAmount = 0.00m;
                        
                        new SystemData().GetTaDeliverySet();
                        TaDeliverySetInfo taDeliverySetInfo = CommonData.TaDeliverySet.FirstOrDefault();

                        if (taDeliverySetInfo != null)
                        {
                            decimal dOverMile = Convert.ToDecimal(string.IsNullOrEmpty(taDeliverySetInfo.OverMile) ? "0.00" : taDeliverySetInfo.OverMile);
                            decimal dPerMile = Convert.ToDecimal(string.IsNullOrEmpty(taDeliverySetInfo.PerMile) ? "0.00" : taDeliverySetInfo.PerMile);

                            if (Convert.ToDecimal(string.IsNullOrEmpty(strDistance) ? "0.00" : strDistance) >= dOverMile)
                            {
                                dDistFee += Math.Ceiling(Convert.ToDecimal(string.IsNullOrEmpty(strDistance) ? "0.00" : strDistance)) * dPerMile;

                                dOrderThreshold = Convert.ToDecimal(string.IsNullOrEmpty(taDeliverySetInfo.OrderThreshold) ? "0.00" : taDeliverySetInfo.OrderThreshold);

                                dResult = taDeliverySetInfo.DeliveryMile.Equals("Y")
                                          ? dDistFee
                                          : (taDeliverySetInfo.IsIgnoreDelivery.Equals("Y")
                                            ? (dOrderTotal < dOrderThreshold ? 0.00m : dDistFee)
                                            : dDistFee);
                            }
                            else
                            {
                                dResult = 0.00m;
                            }
                        }
                        else
                        {
                            dResult = 0.00m;
                        }
                    }
                }
                
            }
            catch (Exception ex) {
                LogHelper.Error("CommonDAL/GetDeliveryFee", ex);
                return dResult;
            }

            return dResult;
        }

        public static decimal GetDeliveryFee(int iCallerID, string strOrderTotal)
        {
            //结算结果
            decimal dResult = 0.00m;

            string strDistance = GetUserDistance(iCallerID.ToString());

            try
            {
                //送餐费
                decimal dDistFee = 0.00m;
                //附加费
                decimal dSurcharge = 0.00m;
                //餐费分隔点
                decimal dOrderThreshold = 0.00m;
                //总餐费
                decimal dOrderTotal = Convert.ToDecimal(strOrderTotal);

                //超过送餐费的部分
                decimal dOutDistance = 0.00m;

                new SystemData().GetTaDeliverySetDetail();
                var lstDsd = CommonData.TaDeliverySetDetail.Where(s => !string.IsNullOrEmpty(s.DistFrom) && !string.IsNullOrEmpty(s.DistTo)).OrderByDescending(s => s.AmountToPay);

                if (lstDsd.Any())
                {
                    decimal dDistance = Convert.ToDecimal(strDistance);

                    TaDeliverySetDetailInfo taDeliverySetDetail = lstDsd.FirstOrDefault();
                    dOutDistance = Convert.ToDecimal(taDeliverySetDetail.DistTo);

                    foreach (var taDeliverySetDetailInfo in lstDsd.Where(taDeliverySetDetailInfo => dDistance >= Convert.ToDecimal(string.IsNullOrEmpty(taDeliverySetDetailInfo.DistFrom) ? "0" : taDeliverySetDetailInfo.DistFrom)
                                                                                                && dDistance <= Convert.ToDecimal(string.IsNullOrEmpty(taDeliverySetDetailInfo.DistTo) ? "9999" : taDeliverySetDetailInfo.DistTo)))
                    {
                        dDistFee = Convert.ToDecimal(string.IsNullOrEmpty(taDeliverySetDetailInfo.AmountToPay) ? "0" : taDeliverySetDetailInfo.AmountToPay);
                        break;
                    }

                    new SystemData().GetTaDeliverySet();
                    var lstDs = CommonData.TaDeliverySet;

                    //if (dDistFee > 0.0m)
                    //{
                    if (lstDs.Any())
                    {
                        TaDeliverySetInfo taDeliverySetInfo = lstDs.FirstOrDefault();

                        if (dDistance > dOutDistance)
                        {
                            dDistFee += Math.Ceiling(dDistance - dOutDistance) * Convert.ToDecimal(string.IsNullOrEmpty(taDeliverySetInfo.DeliveryMile) ? "0.00" : taDeliverySetInfo.PerMile);
                        }

                        if (taDeliverySetInfo.IsIgnoreDelivery.Equals("Y"))
                        {
                            dResult = dDistFee;
                        }
                        else
                        {
                            if (taDeliverySetInfo.DeliveryMile.Equals("Y"))
                            {
                                dResult = dOrderTotal < dOrderThreshold
                                    ? Convert.ToDecimal(string.IsNullOrEmpty(taDeliverySetInfo.SurchargeAmount) ? "0.00" : taDeliverySetInfo.SurchargeAmount)
                                    : dDistFee;
                            }
                            else
                            {
                                dOrderThreshold = Convert.ToDecimal(string.IsNullOrEmpty(taDeliverySetInfo.OrderThreshold) ? "0.00" : taDeliverySetInfo.OrderThreshold);

                                if (dOrderTotal < dOrderThreshold)
                                    dSurcharge = Convert.ToDecimal(string.IsNullOrEmpty(taDeliverySetInfo.SurchargeAmount) ? "0.00" : taDeliverySetInfo.SurchargeAmount);

                                dResult = dDistFee + dSurcharge;
                            }
                        }
                    }
                    //}
                }

            }
            catch (Exception ex)
            {
                LogHelper.Error("CommonDAL/GetDeliveryFee", ex);
                return dResult;
            }

            return dResult;
        }
        #endregion

        #region 依据Caller ID获得Distance

        public static string GetUserDistance(string callerID)
        {
            string strResult = @"0.00";

            if (!string.IsNullOrEmpty(callerID))
            {
                new SystemData().GetTaCustomer();
                var lstCust = CommonData.TaCustomer.Where(s => s.ID.ToString().Equals(callerID));
                if (lstCust.Any())
                {
                    TaCustomerInfo taCustomerInfo = lstCust.FirstOrDefault();
                    strResult = taCustomerInfo.cusDistance;
                }                
            }

            return strResult;
        }
        #endregion

        #region 打开钱箱

        public static bool OpenCashDraw(bool isNeedPwd, string strPwd)
        {
            try
            {
                new SystemData().GetTaCashDrawSet();
                TaCashDrawSetInfo taCashDrawSetInfo = CommonData.TaCashDrawSet.FirstOrDefault();

                if (taCashDrawSetInfo != null)
                {
                    string strPrtName = taCashDrawSetInfo.ReportPrinter;

                    if (isNeedPwd)
                    {
                        if (taCashDrawSetInfo.IsUseCashDraw.Equals("Y"))
                        {
                            if (!strPwd.Equals(taCashDrawSetInfo.CashDrawPwd))
                            {
                                return false;
                            }
                        }
                    }

                    OpenDriverCash2(27, 112, 48, 55, 121, strPrtName);
                    return true;
                }

                LogHelper.Error("#Cash Draw Printer ERROR#");
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex.InnerException);
                return false;
            }
        }
        #endregion

        #region 是否进行系统数据备份

        public static void IsBackupSysData()
        {
            new SystemData().GenSet();

            GenSetInfo genSetInfo = CommonData.GenSet.FirstOrDefault();

            if (genSetInfo != null)
            {
                if (genSetInfo.IsBackup.Equals("Y"))
                {
                    FileInfo oldFile = new FileInfo(Environment.CurrentDirectory + @"\SuperPOS2.db");

                    string newFileName = @"SuperPOS2-" + Environment.TickCount.ToString() + ".db";

                    string strNewFilePath = genSetInfo.BackupDriver + @":\Backup\";

                    if (!Directory.Exists(strNewFilePath))
                    {
                        Directory.CreateDirectory(strNewFilePath);
                    }

                    oldFile.CopyTo(strNewFilePath + newFileName, true);
                }
            }
        }
        #endregion

        #region 获得打印信息
        public static WbPrtTemplataTa GetAllPrtInfo(string strCusID,
                                              string sStaff,
                                              string strStaffID,
                                              string strChkOrder,
                                              int sItemCount,
                                              string sSubTotal,
                                              string sTotalAmount,
                                              string sTendered,
                                              string sChange,
                                              string sRefNo,
                                              string sDeliveryFee,
                                              string sDiscount,
                                              string sSurcharge,
                                              string checkBusDate)
        {
            WbPrtTemplataTa wbPrtTemplataTa = new WbPrtTemplataTa();
            new SystemData().GetTaSysPrtSetGeneral();
            var lstGen = CommonData.TaSysPrtSetGeneral;
            if (lstGen.Any())
            {
                TaSysPrtSetGeneralInfo taSysPrtSetGeneralInfo = lstGen.FirstOrDefault();

                //wbPrtTemplataTa.PrintAddress = taSysPrtSetGeneralInfo.IsPrtAddr;
                new SystemData().GetTaSysCtrl();
                var lstTaSysCtrl = CommonData.TaSysCtrl;

                if (lstTaSysCtrl.Any())
                {
                    wbPrtTemplataTa.PrintAddress = lstTaSysCtrl.FirstOrDefault().ShopAddress;
                }
                wbPrtTemplataTa.PrintTel = taSysPrtSetGeneralInfo.TelNo;
                wbPrtTemplataTa.VATNo = taSysPrtSetGeneralInfo.VATNo;
                wbPrtTemplataTa.Msg1 = taSysPrtSetGeneralInfo.Msg1;
                wbPrtTemplataTa.Msg2 = taSysPrtSetGeneralInfo.Msg2;
                wbPrtTemplataTa.Msg3 = taSysPrtSetGeneralInfo.Msg3;
                wbPrtTemplataTa.Msg4 = taSysPrtSetGeneralInfo.Msg4;
                wbPrtTemplataTa.Msg5 = taSysPrtSetGeneralInfo.Msg5;
            }

            if (!string.IsNullOrEmpty(strCusID))
            {
                new SystemData().GetTaCustomer();
                var lstCust = CommonData.TaCustomer.Where(s => s.ID == Convert.ToInt32(strCusID));
                if (lstCust.Any())
                {
                    TaCustomerInfo taCustomerInfo = lstCust.FirstOrDefault();
                    wbPrtTemplataTa.CustName = taCustomerInfo.cusName;
                    wbPrtTemplataTa.CustPhone = taCustomerInfo.cusPhone;
                    wbPrtTemplataTa.CustDist = taCustomerInfo.cusDistance;
                    wbPrtTemplataTa.CustMapRef = taCustomerInfo.cusPcZone;
                    wbPrtTemplataTa.CustHouseNo = taCustomerInfo.cusHouseNo;
                    wbPrtTemplataTa.CustAddr = taCustomerInfo.cusAddr;
                    wbPrtTemplataTa.CustPostCode = taCustomerInfo.cusPostcode;
                    wbPrtTemplataTa.ShopTime = taCustomerInfo.cusReadyTime;
                }
            }

            wbPrtTemplataTa.OrderDate = DateTime.Now.ToShortDateString();
            wbPrtTemplataTa.OrderTime = DateTime.Now.ToShortTimeString();
            wbPrtTemplataTa.Staff = string.IsNullOrEmpty(sStaff) ? CommonData.UsrBase.FirstOrDefault(s => s.ID == Convert.ToInt32(strStaffID)).UsrName : sStaff;
            wbPrtTemplataTa.OrderNo = strChkOrder;
            wbPrtTemplataTa.ItemCount = sItemCount >= 1 ? sItemCount.ToString() : "0";
            wbPrtTemplataTa.SubTotal = sSubTotal;
            wbPrtTemplataTa.Total = sTotalAmount;
            wbPrtTemplataTa.PayType = GetPayType(strChkOrder, checkBusDate);
            wbPrtTemplataTa.Tendered = sTendered;
            wbPrtTemplataTa.Change = sChange;
            wbPrtTemplataTa.OrderType = GetPayType(strChkOrder, checkBusDate);
            wbPrtTemplataTa.RefNo = sRefNo;
            wbPrtTemplataTa.DeliveryFee = sDeliveryFee;

            wbPrtTemplataTa.Discount = sDiscount;
            wbPrtTemplataTa.Surcharge = sSurcharge;

            #region VAT计算
            if (CommonData.GenSet.Any())
            {
                wbPrtTemplataTa.Rate1 = CommonData.GenSet.FirstOrDefault().VATPer + @"%";

                var lstVAT = from oi in CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder) && s.BusDate.Equals(checkBusDate))
                             join mi in CommonData.TaMenuItem on oi.ItemCode equals mi.MiDishCode
                             where !string.IsNullOrEmpty(mi.MiRmk) && mi.MiRmk.Contains(@"Without VAT")
                             select new
                             {
                                 itemTotalPrice = oi.ItemTotalPrice
                             };

                decimal dTotal = 0;
                decimal dVatTmp = 0;
                decimal dVat = 0;

                if (lstVAT.Any())
                {
                    dTotal = lstVAT.ToList().Sum(vat => Convert.ToDecimal(vat.itemTotalPrice));
                    //交税
                    dVatTmp = (Convert.ToDecimal(CommonData.GenSet.FirstOrDefault().VATPer) / 100) * dTotal;

                    dVat = Math.Round(dVatTmp, 2, MidpointRounding.AwayFromZero);
                }

                wbPrtTemplataTa.VatA = dVat.ToString();
                //税前
                wbPrtTemplataTa.Net1 = dTotal.ToString();
                //总价
                wbPrtTemplataTa.Gross1 = (dTotal - dVat).ToString();
                wbPrtTemplataTa.Rate2 = "0.00%";
                wbPrtTemplataTa.Net2 = (Convert.ToDecimal(sSubTotal) - dTotal).ToString();
                wbPrtTemplataTa.VatB = "0.00";
                wbPrtTemplataTa.Gross2 = (Convert.ToDecimal(sSubTotal) - dTotal).ToString();
            }
            else
            {
                wbPrtTemplataTa.Rate1 = "0.00%";
                wbPrtTemplataTa.Net1 = "0.00";
                wbPrtTemplataTa.VatA = "0.00";
                wbPrtTemplataTa.Gross1 = "0.00";
                wbPrtTemplataTa.Rate2 = "0.00%";
                wbPrtTemplataTa.Net2 = "0.00";
                wbPrtTemplataTa.VatB = "0.00";
                wbPrtTemplataTa.Gross2 = "0.00";
            }
            #endregion

            return wbPrtTemplataTa;
        }
        #endregion

        public static string GetPayType(string sChkId, string checkBusDate)
        {
            new SystemData().GetTaCheckOrder();
            var lstChk = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(sChkId) && s.BusDate.Equals(checkBusDate));

            string strPt = "Paid By ";

            if (lstChk.Any())
            {
                TaCheckOrderInfo taCheckOrder = lstChk.FirstOrDefault();

                if (Convert.ToDecimal(taCheckOrder.PayTypePay1) > 0)
                {
                    strPt += taCheckOrder.PayType1 + " ";
                }

                if (Convert.ToDecimal(taCheckOrder.PayTypePay2) > 0)
                {
                    strPt += taCheckOrder.PayType2 + " ";
                }

                if (Convert.ToDecimal(taCheckOrder.PayTypePay3) > 0)
                {
                    strPt += taCheckOrder.PayType3 + " ";
                }

                if (Convert.ToDecimal(taCheckOrder.PayTypePay4) > 0)
                {
                    strPt += taCheckOrder.PayType4 + " ";
                }

                if (Convert.ToDecimal(taCheckOrder.PayTypePay5) > 0)
                {
                    strPt += taCheckOrder.PayType5 + " ";
                }
            }

            return strPt;
        }

        public static void ExportToExcel(PrtAccountSummaryInfo prtAsI)
        {
            try
            {
                //要操作的excel模板文件路径
                string strTemplatePath = PubComm.PRT_ACCOUNT_SUMMARY_EXCEL_TEMPLATE;

                //把文件内容导入到工作薄当中，然后关闭文件
                FileStream fs = File.OpenRead(strTemplatePath);
                //IWorkbook workbook = new XSSFWorkbook(fs);
                HSSFWorkbook workbook = new HSSFWorkbook(fs);
                fs.Close();

                //编辑工作薄当中内容
                ISheet sheet = workbook.GetSheetAt(0);

                IRow row = null;

                row = sheet.GetRow(1);
                row.Cells[2].SetCellValue(prtAsI.TotalDeliveryCharge.ToString("0.00"));

                row = sheet.GetRow(2);
                row.Cells[2].SetCellValue(prtAsI.TotalVAT);

                row = sheet.GetRow(3);
                row.Cells[2].SetCellValue(prtAsI.NotPaid);

                row = sheet.GetRow(7);
                row.Cells[1].SetCellValue(prtAsI.DeliveryCount.ToString());
                row.Cells[2].SetCellValue(prtAsI.DeliveryAmount.ToString("0.00"));

                row = sheet.GetRow(8);
                row.Cells[1].SetCellValue(prtAsI.CollectionCount.ToString());
                row.Cells[2].SetCellValue(prtAsI.CollectionAmount.ToString("0.00"));

                row = sheet.GetRow(9);
                row.Cells[1].SetCellValue(prtAsI.ShopCount.ToString());
                row.Cells[2].SetCellValue(prtAsI.ShopAmount.ToString("0.00"));

                row = sheet.GetRow(10);
                row.Cells[1].SetCellValue(prtAsI.FastFoodCount.ToString());
                row.Cells[2].SetCellValue(prtAsI.FastFoodAmount.ToString("0.00"));

                row = sheet.GetRow(11);
                row.Cells[1].SetCellValue(prtAsI.EatInCount.ToString());
                row.Cells[2].SetCellValue(prtAsI.EatInAmount.ToString("0.00"));

                row = sheet.GetRow(12);
                int iAllTakeCount = prtAsI.DeliveryCount + prtAsI.CollectionCount + prtAsI.ShopCount + prtAsI.FastFoodCount;
                decimal dAllTakeAmount = prtAsI.DeliveryAmount + prtAsI.CollectionAmount + prtAsI.ShopAmount + prtAsI.FastFoodAmount;
                row.Cells[1].SetCellValue(iAllTakeCount.ToString());
                row.Cells[2].SetCellValue(dAllTakeAmount.ToString("0.00"));

                row = sheet.GetRow(16);
                row.Cells[1].SetCellValue(prtAsI.PayType1Count.ToString());
                row.Cells[2].SetCellValue(prtAsI.PayType1Amount.ToString("0.00"));

                row = sheet.GetRow(17);
                row.Cells[1].SetCellValue(prtAsI.PayType2Count.ToString());
                row.Cells[2].SetCellValue(prtAsI.PayType2Amount.ToString("0.00"));

                row = sheet.GetRow(18);
                row.Cells[1].SetCellValue(prtAsI.PayType3Count.ToString());
                row.Cells[2].SetCellValue(prtAsI.PayType3Amount.ToString("0.00"));

                row = sheet.GetRow(19);
                row.Cells[1].SetCellValue(prtAsI.PayType4Count.ToString());
                row.Cells[2].SetCellValue(prtAsI.PayType4Amount.ToString("0.00"));

                row = sheet.GetRow(20);
                row.Cells[1].SetCellValue(prtAsI.PayType5Count.ToString());
                row.Cells[2].SetCellValue(prtAsI.PayType5Amount.ToString("0.00"));

                int iAllPayeCount = prtAsI.PayType1Count + prtAsI.PayType2Count + prtAsI.PayType3Count + prtAsI.PayType4Count + prtAsI.PayType5Count;
                decimal dAllPayAmount = prtAsI.PayType1Amount + prtAsI.PayType2Amount + prtAsI.PayType3Amount + prtAsI.PayType4Amount + +prtAsI.PayType5Amount;
                row = sheet.GetRow(21);
                row.Cells[1].SetCellValue(iAllPayeCount.ToString());
                row.Cells[2].SetCellValue(dAllPayAmount.ToString("0.00"));

                //把编辑过后的工作薄重新保存为excel文件
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.SelectedPath = System.Environment.CurrentDirectory + @"\";
                dialog.Description = @"Please select save path";

                string path = System.Environment.CurrentDirectory;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                }
                string fileName = path + @"\" + DateTime.Now.Ticks + @".xls";

                FileStream fs2 = File.Create(fileName);
                workbook.Write(fs2);
                fs2.Close();
            }
            catch (Exception ex)
            {
                LogHelper.Error("ExportToExcel", ex);
            }

            CommonTool.ShowMessage("File save successful!");

            #region 保存至C盘时存在异常，弃用

            //Microsoft.Office.Interop.Excel.Application objExcelApp = new ApplicationClass();//定义Excel Application对象
            //Workbooks objExcelWorkBooks;//定义Workbook工作簿集合对象
            //Workbook objExcelWorkbook;//定义Excel workbook工作簿对象
            //Worksheet objExcelWorkSheet;//定义Workbook工作表对象

            //try
            //{
            //    string workTmp = PubComm.PRT_ACCOUNT_SUMMARY_EXCEL_TEMPLATE;
            //    //objExcelApp = new ApplicationClass();
            //    objExcelWorkBooks = objExcelApp.Workbooks;
            //    objExcelWorkbook = objExcelWorkBooks.Open(workTmp, Type.Missing, Type.Missing, Type.Missing,
            //        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //        Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //    objExcelWorkSheet = (Worksheet)objExcelWorkbook.Worksheets[1];
            //    //strSheetName是指的Exce工作簿的Sheet名，如果没有命名则为"1" 
            //    objExcelWorkSheet.Cells[2, 3] = prtAsI.TotalDeliveryCharge.ToString("0.00"); //intRow,行；intCol;列；strValue，你处理完以后的值
            //    objExcelWorkSheet.Cells[3, 3] = prtAsI.TotalVAT;
            //    objExcelWorkSheet.Cells[4, 3] = prtAsI.NotPaid;

            //    int iAllTakeCount = prtAsI.DeliveryCount + prtAsI.CollectionCount + prtAsI.ShopCount + prtAsI.FastFoodCount;
            //    decimal dAllTakeAmount = prtAsI.DeliveryAmount + prtAsI.CollectionAmount + prtAsI.ShopAmount + prtAsI.FastFoodAmount;
            //    objExcelWorkSheet.Cells[8, 2] = prtAsI.DeliveryCount.ToString();
            //    objExcelWorkSheet.Cells[9, 2] = prtAsI.CollectionCount.ToString();
            //    objExcelWorkSheet.Cells[10, 2] = prtAsI.ShopCount.ToString();
            //    objExcelWorkSheet.Cells[11, 2] = prtAsI.FastFoodCount.ToString();
            //    objExcelWorkSheet.Cells[12, 2] = prtAsI.EatInCount.ToString();
            //    objExcelWorkSheet.Cells[13, 2] = iAllTakeCount.ToString();

            //    objExcelWorkSheet.Cells[8, 3] = prtAsI.DeliveryAmount.ToString("0.00");
            //    objExcelWorkSheet.Cells[9, 3] = prtAsI.CollectionAmount.ToString("0.00");
            //    objExcelWorkSheet.Cells[10, 3] = prtAsI.ShopAmount.ToString("0.00");
            //    objExcelWorkSheet.Cells[11, 3] = prtAsI.FastFoodAmount.ToString("0.00");
            //    objExcelWorkSheet.Cells[12, 3] = prtAsI.EatInAmount.ToString("0.00");
            //    objExcelWorkSheet.Cells[13, 3] = dAllTakeAmount.ToString("0.00");

            //    int iAllPayeCount = prtAsI.PayType1Count + prtAsI.PayType2Count + prtAsI.PayType3Count + prtAsI.PayType4Count + prtAsI.PayType5Count;
            //    decimal dAllPayAmount = prtAsI.PayType1Amount + prtAsI.PayType2Amount + prtAsI.PayType3Amount + prtAsI.PayType4Amount + +prtAsI.PayType5Amount;
            //    objExcelWorkSheet.Cells[17, 2] = prtAsI.PayType1Count.ToString();
            //    objExcelWorkSheet.Cells[18, 2] = prtAsI.PayType2Count.ToString();
            //    objExcelWorkSheet.Cells[19, 2] = prtAsI.PayType3Count.ToString();
            //    objExcelWorkSheet.Cells[20, 2] = prtAsI.PayType4Count.ToString();
            //    objExcelWorkSheet.Cells[21, 2] = prtAsI.PayType5Count.ToString();
            //    objExcelWorkSheet.Cells[22, 2] = iAllPayeCount.ToString();

            //    objExcelWorkSheet.Cells[17, 3] = prtAsI.PayType1Amount.ToString("0.00");
            //    objExcelWorkSheet.Cells[18, 3] = prtAsI.PayType2Amount.ToString("0.00");
            //    objExcelWorkSheet.Cells[19, 3] = prtAsI.PayType3Amount.ToString("0.00");
            //    objExcelWorkSheet.Cells[20, 3] = prtAsI.PayType4Amount.ToString("0.00");
            //    objExcelWorkSheet.Cells[21, 3] = prtAsI.PayType5Amount.ToString("0.00");
            //    objExcelWorkSheet.Cells[22, 3] = dAllPayAmount.ToString("0.00");
            //    //object missing = System.Reflection.Missing.Value;

            //    FolderBrowserDialog dialog = new FolderBrowserDialog();
            //    dialog.SelectedPath = @"C:\";
            //    dialog.Description = @"Please select save path";

            //    string path = @"C:\";

            //    if (dialog.ShowDialog() == DialogResult.OK)
            //    {
            //        path = dialog.SelectedPath;
            //    }
            //    string fileName = path + DateTime.Now.Ticks + @".xls";
            //    objExcelWorkbook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //        XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //}
            //finally
            //{
            //    objExcelApp.Quit();
            //}

            #endregion

            #region 原导出代码，速度太慢，弃用

            //Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            //if (xlApp == null) return;

            ////System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            ////System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            ////Microsoft.Office.Interop.Excel.Workbooks workBooks = xlApp.Workbooks;
            ////Microsoft.Office.Interop.Excel.Workbook workbook = workBooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            ////Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            ////Microsoft.Office.Interop.Excel.Range range;

            //Workbook xlBook = xlApp.Workbooks.Add();

            //_Worksheet oSheet = (_Worksheet)xlBook.Worksheets[1];

            //RangeBuild(oSheet, "A1", "C1", @"Account Summary", 20, 2, true);

            //RangeBuild(oSheet, "A2", "B2", @"Total Delivery Charge", 14, 1, false);
            //RangeBuild(oSheet, "C2", "C2", prtAsI.TotalDeliveryCharge.ToString("0.00"), 14, 3, false);

            //RangeBuild(oSheet, "A3", "B3", @"Total VAT", 14, 1, false);
            //RangeBuild(oSheet, "C3", "C3", prtAsI.TotalVAT, 14, 3, false);

            //RangeBuild(oSheet, "A4", "B4", @"Not Paid", 14, 1, false);
            //RangeBuild(oSheet, "C4", "C4", prtAsI.NotPaid, 14, 3, false);

            //RangeBuild(oSheet, "A5", "A5", @"", 14, 2, false);
            //RangeBuild(oSheet, "B5", "B5", @"", 14, 2, false);
            //RangeBuild(oSheet, "C5", "C5", @"", 14, 2, false);

            //RangeBuild(oSheet, "A6", "C6", @"Total Summary", 20, 2, true);
            //RangeBuild(oSheet, "A7", "A7", @"Order Type", 14, 2, false);
            //RangeBuild(oSheet, "B7", "B7", @"Qty", 14, 2, false);
            //RangeBuild(oSheet, "C7", "C7", @"Account", 14, 2, false);
            //RangeBuild(oSheet, "A8", "A8", @"Delivery", 14, 1, false);
            //RangeBuild(oSheet, "B8", "B8", prtAsI.DeliveryCount.ToString(), 14, 2, false);
            //RangeBuild(oSheet, "C8", "C8", prtAsI.DeliveryAmount.ToString("0.00"), 14, 3, false);
            //RangeBuild(oSheet, "A9", "A9", @"Collection", 14, 1, false);
            //RangeBuild(oSheet, "B9", "B9", prtAsI.CollectionCount.ToString(), 14, 2, false);
            //RangeBuild(oSheet, "C9", "C9", prtAsI.CollectionAmount.ToString("0.00"), 14, 3, false);
            //RangeBuild(oSheet, "A10", "A10", @"Shop", 14, 1, false);
            //RangeBuild(oSheet, "B10", "B10", prtAsI.ShopCount.ToString(), 14, 2, false);
            //RangeBuild(oSheet, "C10", "C10", prtAsI.ShopAmount.ToString("0.00"), 14, 3, false);
            //RangeBuild(oSheet, "A11", "A11", @"Fast Food", 14, 1, false);
            //RangeBuild(oSheet, "B11", "B11", prtAsI.FastFoodCount.ToString(), 14, 2, false);
            //RangeBuild(oSheet, "C11", "C11", prtAsI.FastFoodAmount.ToString("0.00"), 14, 3, false);
            ////Eat In暂时为0
            //RangeBuild(oSheet, "A12", "A12", @"Eat In", 14, 1, false);
            //RangeBuild(oSheet, "B12", "B12", "0", 14, 2, false);
            //RangeBuild(oSheet, "C12", "C12", "0.00", 14, 3, false);
            //int iAllTakeCount = prtAsI.DeliveryCount + prtAsI.CollectionCount + prtAsI.ShopCount + prtAsI.FastFoodCount;
            //decimal dAllTakeAmount = prtAsI.DeliveryAmount + prtAsI.CollectionAmount + prtAsI.ShopAmount + prtAsI.FastFoodAmount;
            //RangeBuild(oSheet, "A13", "A13", @"Total Takings", 14, 1, false);
            //RangeBuild(oSheet, "B13", "B13", iAllTakeCount.ToString(), 14, 2, false);
            //RangeBuild(oSheet, "C13", "C13", dAllTakeAmount.ToString("0.00"), 14, 3, false);

            //RangeBuild(oSheet, "A14", "A14", @"", 14, 2, false);
            //RangeBuild(oSheet, "B14", "B14", @"", 14, 2, false);
            //RangeBuild(oSheet, "C14", "C14", @"", 14, 2, false);

            //RangeBuild(oSheet, "A15", "C15", @"Payment Summary", 20, 2, true);
            //RangeBuild(oSheet, "A16", "A16", @"Payment Type", 14, 2, false);
            //RangeBuild(oSheet, "B16", "B16", @"Qty", 14, 2, false);
            //RangeBuild(oSheet, "C16", "C16", @"Account", 14, 2, false);
            //RangeBuild(oSheet, "A17", "A17", prtAsI.PayType1, 14, 1, false);
            //RangeBuild(oSheet, "B17", "B17", prtAsI.PayType1Count.ToString(), 14, 2, false);
            //RangeBuild(oSheet, "C17", "C17", prtAsI.PayType1Amount.ToString("0.00"), 14, 3, false);
            //RangeBuild(oSheet, "A18", "A18", prtAsI.PayType2, 14, 1, false);
            //RangeBuild(oSheet, "B18", "B18", prtAsI.PayType2Count.ToString(), 14, 2, false);
            //RangeBuild(oSheet, "C18", "C18", prtAsI.PayType2Amount.ToString("0.00"), 14, 3, false);
            //RangeBuild(oSheet, "A19", "A19", prtAsI.PayType3, 14, 1, false);
            //RangeBuild(oSheet, "B19", "B19", prtAsI.PayType3Count.ToString(), 14, 2, false);
            //RangeBuild(oSheet, "C19", "C19", prtAsI.PayType3Amount.ToString("0.00"), 14, 3, false);
            //RangeBuild(oSheet, "A20", "A20", prtAsI.PayType4, 14, 1, false);
            //RangeBuild(oSheet, "B20", "B20", prtAsI.PayType4Count.ToString(), 14, 2, false);
            //RangeBuild(oSheet, "C20", "C20", prtAsI.PayType4Amount.ToString("0.00"), 14, 3, false);
            //RangeBuild(oSheet, "A21", "A21", prtAsI.PayType5, 14, 1, false);
            //RangeBuild(oSheet, "B21", "B21", prtAsI.PayType5Count.ToString(), 14, 2, false);
            //RangeBuild(oSheet, "C21", "C21", prtAsI.PayType5Amount.ToString("0.00"), 14, 3, false);
            //RangeBuild(oSheet, "A22", "A22", @"Payment Total", 14, 1, false);
            //int iAllPayeCount = prtAsI.PayType1Count + prtAsI.PayType2Count + prtAsI.PayType3Count + prtAsI.PayType4Count + prtAsI.PayType5Count;
            //decimal dAllPayAmount = prtAsI.PayType1Amount + prtAsI.PayType2Amount + prtAsI.PayType3Amount + prtAsI.PayType4Amount + +prtAsI.PayType5Amount;
            //RangeBuild(oSheet, "B22", "B22", iAllPayeCount.ToString(), 14, 2, false);
            //RangeBuild(oSheet, "C22", "C22", dAllPayAmount.ToString("0.00"), 14, 3, false);

            ////oSheet.SaveAs(@"C:\" + DateTime.Now.Ticks + @".xls");
            //xlBook.Saved = true;
            //xlBook.SaveCopyAs(@"D:\" + DateTime.Now.Ticks + @".xls");
            //xlApp.Quit();
            //xlApp = null;

            #endregion
        }

        public static void RangeBuild(_Worksheet oSheet, string startCell, string endCell, string strValue, int iFontSize, int iLocation, bool isBold)
        {
            Range range = oSheet.Range[startCell, endCell];
            range.Merge(0);
            range.Value = strValue;

            if (iLocation == 1) range.HorizontalAlignment = Constants.xlLeftToRight;
            else if (iLocation == 2) range.HorizontalAlignment = XlVAlign.xlVAlignCenter;
            else if (iLocation == 3) range.HorizontalAlignment = Constants.xlRight;

            range.Font.Size = iFontSize;

            if (isBold) range.Font.Bold = true;
            
            range.EntireColumn.AutoFit();
        }

        public static decimal GetAllVAT(string sVatRat, string strOrderNum, string strBusDate)
        {
            try
            {
                if (string.IsNullOrEmpty(sVatRat)) sVatRat = CommonData.GenSet.FirstOrDefault().VATPer;

                if (sVatRat != null)
                {
                    new SystemData().GetOrderItemSumForVatInfos(strOrderNum, strBusDate);
                    var lstVAT = CommonData.GetOrderItemSumForVatInfos;

                    decimal dVatTotal = 0;
                    decimal dVatTmp = 0;
                    decimal dVat = 0;

                    if (lstVAT.Any())
                    {
                        dVatTotal = lstVAT.ToList().Sum(vat => vat.ItemTotalPrice);
                        //交税
                        dVatTmp = (Convert.ToDecimal(sVatRat) / 100) * dVatTotal;

                        dVat = Math.Round(dVatTmp, 2, MidpointRounding.AwayFromZero);
                    }

                    return dVat;
                }

                return 0.00m;
            }
            catch (Exception ex)
            {
                LogHelper.Error("CommonDAL/GetAllVAT", ex.InnerException);
                return 0.00m;
            }
        }

        public static void SetPrintPreview(IPrintable panel)
        {
            try
            {
                PrintingSystem ps = new PrintingSystem();
                PrintableComponentLink link = new PrintableComponentLink();
                ps.Links.Add(link);
                link.Component = panel;
                link.PaperKind = PaperKind.A4;
                link.Margins = new Margins(2, 2, 2, 2);
                //link.CreateMarginalHeaderArea += Link_CreateMarginalHeaderArea;
                ps.PreviewFormEx.PrintControl.PrintingSystem.SetCommandVisibility(
                        new[]
                        {
                        PrintingSystemCommand.Save,
                        PrintingSystemCommand.Print,
                        PrintingSystemCommand.ExportXls,
                        PrintingSystemCommand.ClosePreview,
                        PrintingSystemCommand.ShowFirstPage,
                        PrintingSystemCommand.ShowLastPage,
                        }, CommandVisibility.Toolbar);

                link.CreateDocument();
                link.PrintingSystem.ShowMarginsWarning = false;
                ps.PreviewFormEx.Show();
            }
            catch (Exception ex)
            {
                LogHelper.Error("CommonDAL/SetPrintPreview", ex.InnerException);
            }
        }

        public static string SetDateTimeFormat(string strDt, int iAddOrReduce)
        {
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo
            {
                ShortDatePattern = PubComm.DATE_TIME_FORMAT
            };

            return (Convert.ToDateTime(strDt, dtFormat)).AddDays(iAddOrReduce).ToString(PubComm.DATE_TIME_FORMAT, DateTimeFormatInfo.InvariantInfo);
        }

        #region 闪屏等待窗口
        private static SplashScreenManager _loadForm;
        private static Form tmpForm = null;

        private static SplashScreenManager LoadForm
        {
            get
            {
                if (_loadForm == null)
                {
                    _loadForm = new SplashScreenManager(tmpForm, typeof(FrmWaitForm), true, true);
                    _loadForm.ClosingDelay = 0;
                }

                return _loadForm;
            }
        }

        public static void ShowMessage(Form frm)
        {
            bool flag = !LoadForm.IsSplashFormVisible;
            tmpForm = frm;

            if (flag)
            {
                LoadForm.ShowWaitForm();
            }
        }

        public static void HideMessage(Form frm)
        {
            bool isSplashFormVisible = LoadForm.IsSplashFormVisible;

            tmpForm = frm;

            if (isSplashFormVisible)
            {
                LoadForm.CloseWaitForm();
            }
        }
        #endregion
    }
}
