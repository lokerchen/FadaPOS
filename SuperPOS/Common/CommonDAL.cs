using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;

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
            new SystemData().GetTaMenuItem();

            if (iMenuSetId == 0)
            {
                if (iMenuCateId == 0)
                {
                    return CommonData.TaMenuItem.Skip(PAGESIZE_MENUITEM*(iPageNum - 1))
                        .Take(PAGESIZE_MENUITEM).ToList();
                }
                else
                {
                    return CommonData.TaMenuItem.Where(s => s.MiMenuCateID.Equals(iMenuCateId.ToString()))
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
                    return CommonData.TaMenuItem.Where(s => s.MiMenuSetID == iMenuSetId && s.MiMenuCateID.Equals(iMenuCateId.ToString()))
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
            new SystemData().GetTaMenuCate();

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
            new SystemData().GetTaCheckOrder();
            //当前营业日期内是否存在订单
            var lstCheck = CommonData.TaCheckOrder.Where(s => s.BusDate.Equals(GetBusDate())).OrderByDescending(s => s.ID).Take(1);

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

            return lstDiscount.Any()
                ? (MenuAmount >= Convert.ToDecimal(lstDiscount.FirstOrDefault().TaDiscThre)
                    ? 1 - Convert.ToDecimal(lstDiscount.FirstOrDefault().TaDiscount) / 100
                    : 0.00m)
                : 0.00m;
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
        public static decimal GetTotalAmount(decimal menuAmount, decimal dDiscount)
        {
            return dDiscount <= 0.00m ? Math.Round(menuAmount, 2)  : Math.Round(menuAmount * dDiscount, 2);
        }

        #endregion

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
            return DateTime.Compare(DateTime.Now, Convert.ToDateTime(sBusDate)) > 0 ? DateTime.Now.ToShortDateString() : DateTime.Now.AddDays(-1).ToShortDateString();
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
    }
}
