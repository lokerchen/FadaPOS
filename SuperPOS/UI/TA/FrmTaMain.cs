using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;
using SuperPOS.Print;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaMain : DevExpress.XtraEditors.XtraForm
    {
        //操作用户ID
        private int usrID;

        //MenuItem按钮
        private SimpleButton[] btnMenuItem = new SimpleButton[16];
        //ManuCate按钮
        private SimpleButton[] btnMenuCate = new SimpleButton[42];
        //来电显示号码
        private string CallerID = "";
        //账单号
        private string checkID = "";
        //默认语言标识状态位
        public int iLangStatusId = PubComm.MENU_LANG_DEFAULT;
        //菜谱ID
        public int iMenuSetId = 0;
        //MenuCate ID
        public int iMenuCateId = 0;
        //默认菜谱页码 iPageNum = 1;
        private int iPageNum = 1;
        //默认MenuCate iCatePageNum = 1;
        private int iCatePageNum = 1;

        private readonly EntityControl _control = new EntityControl();

        //会员ID
        private int CustID = 0;

        //是否为Ingred Mode
        private bool isIngredMode = false;
        //Ingred Mode 返回值
        private string sModeValue = "";

        //是否为新单
        private bool isNew = true;

        //订单类型
        private string ORDER_TYPE = PubComm.ORDER_TYPE_SHOP;

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        //存储Change Price中的中英文
        private Dictionary<string, string> dChangePrice = new Dictionary<string, string>();
        //存储Other Choices中的中英文
        private Dictionary<string, string> dOtherChoice = new Dictionary<string, string>();

        //保存菜品中英文
        private Dictionary<string, string> dItemName = new Dictionary<string, string>();
        
        //被保存的账单
        private TaCheckOrderInfo saveTaCheckOrderInfo = new TaCheckOrderInfo();

        //营业日期
        private string strBusDate = "";

        #region Payment相关
        private readonly LabelControl[] lblPayType = new LabelControl[5];

        //点击按钮名字
        private string objName = "txtPayTypePay1";

        //付款方式对应金额
        private TextEdit[] txtPayTypePay = new TextEdit[5];

        //司机
        private SimpleButton[] btnDriver = new SimpleButton[10];

        private TextEdit objTxt = null;

        //所有菜单总价格
        private decimal menuAmout = 0.00m;

        //五种不同付款方式
        private decimal ptPay1 = 0.00m;
        private decimal ptPay2 = 0.00m;
        private decimal ptPay3 = 0.00m;
        private decimal ptPay4 = 0.00m;
        private decimal ptPay5 = 0.00m;

        //是否已付款完成
        private bool IsPaid = false;

        private bool IsNotPaid = false;

        //是否已经付完款
        public bool returnPaid = false;

        private int iDriverID = 1;

        private string strDeliveryNote = "";
        
        
        #endregion

        private Hashtable ht = new Hashtable();

        private bool isCalling = false;

        private FrmTaKeyPad frmTaKeyPad;

        #region 来电显示相关
        //是否已在接听电话
        public bool isGetPhone = false;

        [StructLayout(LayoutKind.Sequential)]
        public struct tag_pstn_Data
        {
            public Int16 uChannelID;//设备通道
            public Int32 lPlayFileHandle;//播放句柄
            public Int32 lRecFileHandle;//录音句柄            
        }

        tag_pstn_Data[] m_tagpstnData = new tag_pstn_Data[BriSDKLib.MAX_CHANNEL_COUNT];

        //来电号码被呼叫转移时的临时存储
        private string strTranPhoneNum = "";
        #endregion

        public FrmTaMain()
        {
            InitializeComponent();
        }

        public FrmTaMain(int id, int iLanguage)
        {
            InitializeComponent();
            usrID = id;
            iLangStatusId = iLanguage;
        }

        public FrmTaMain(string cId, int id, int cusId)
        {
            InitializeComponent();
            checkID = cId;
            usrID = id;
            CustID = cusId;
        }

        public FrmTaMain(string cId, int id, int cusId, string sBusDate, int iLanguage)
        {
            InitializeComponent();
            checkID = cId;
            usrID = id;
            CustID = cusId;
            strBusDate = string.IsNullOrEmpty(sBusDate) ? CommonDAL.GetBusDate() : sBusDate;
            iLangStatusId = iLanguage;
        }

        public FrmTaMain(string cId, int id, int cusId, string sBusDate, bool isCall)
        {
            InitializeComponent();
            checkID = cId;
            usrID = id;
            CustID = cusId;
            strBusDate = string.IsNullOrEmpty(sBusDate) ? CommonDAL.GetBusDate() : sBusDate;
            isCalling = isCall;
        }

        #region 事件

        #region 显示TreeList行号
        private void treeListOrder_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tmpTree = sender as DevExpress.XtraTreeList.TreeList;
            DevExpress.Utils.Drawing.IndicatorObjectInfoArgs args = e.ObjectArgs as DevExpress.Utils.Drawing.IndicatorObjectInfoArgs;
            if (args != null)
            {
                int rowNum = tmpTree.GetVisibleIndexByNode(e.Node) + 1;
                this.treeListOrder.IndicatorWidth = rowNum.ToString().Length * 10 + 10;
                args.DisplayText = rowNum.ToString();
            }
        }
        #endregion

        #region Save Order
        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            //列表为空时不保存
            if (treeListOrder.AllNodesCount <= 0)
            {
                return;
            }

            try
            {
                #region 保存TreeList
                AddFreeOrAutomatic();

                List<TaOrderItemInfo> lstTaOI = new List<TaOrderItemInfo>();

                lstTaOI = TreeListToOrderItem(isNew);

                //foreach (var taOrderItemInfo in lstTaOI)
                //{
                //    new SystemData().GetTaOrderItem();

                //    if (CommonData.TaOrderItem.Any(s => s.ID == taOrderItemInfo.ID && s.BusDate.Equals(strBusDate)))
                //    {
                //        _control.UpdateEntity(taOrderItemInfo);
                //    }
                //    else
                //    {
                //        _control.AddEntity(taOrderItemInfo);
                //    }
                //}

                DelegateOrder handler = DelegateOrderOpt.SaveOrder;
                IAsyncResult result = handler.BeginInvoke(checkID, strBusDate, lstTaOI, null, null);
                #endregion

                #region 保存账单
                //Console.WriteLine(treeListOrder.Columns["ItemTotalPrice"].SummaryFooter.ToString());
                SaveCheckOrder(lstTaOI, true);
                #endregion

                //如果是来电显示的，保存后直接关闭当前窗口
                if (isCalling)
                {
                    this.Close();
                }

                treeListOrder.Nodes.Clear();

                #region 清空会员信息
                SetCustInfo(true, true, null);

                ORDER_TYPE = PubComm.ORDER_TYPE_SHOP;
                #endregion

                checkID = CommonDAL.GetCheckCode();
                LogHelper.Info("#checkID:" + checkID + "#btnSaveOrder_Click");
                lblCheck.Text = checkID;

                SetCustClear();
                ORDER_TYPE = PubComm.ORDER_TYPE_SHOP;
                btnType.Appearance.BackColor = Color.HotPink;
                btnType.Text = PubComm.ORDER_TYPE_SHOP;

                handler.EndInvoke(result);
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }
        }
        #endregion

        #region Cancel按钮点击
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (treeListOrder.AllNodesCount > 0)
            {
                FrmCancelOrder frmCancelOrder = new FrmCancelOrder();
                frmCancelOrder.Location = panelControl3.PointToScreen(panelControl1.Location);
                frmCancelOrder.Size = panelControl3.Size;

                if (frmCancelOrder.ShowDialog() == DialogResult.OK)
                {
                    var lstChk =
                        CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate));
                    if (lstChk.Any())
                    {
                        TaCheckOrderInfo taCheck = lstChk.FirstOrDefault();
                        taCheck.IsCancel = "Y";
                        _control.UpdateEntity(taCheck);
                        treeListOrder.Nodes.Clear();

                        checkID = CommonDAL.GetCheckCode();
                        LogHelper.Info("#checkID:" + checkID + "#btnCancel_Click");
                        lblCheck.Text = checkID;
                    }
                    else //未存储的已点菜品列表
                    {
                        treeListOrder.Nodes.Clear();
                    }

                    ORDER_TYPE = PubComm.ORDER_TYPE_SHOP;
                    btnType.Text = ORDER_TYPE;
                    ChangeOrderBtnColor(ORDER_TYPE);
                    GetCustInfo(0);
                }
            }
            else
            {
                ORDER_TYPE = PubComm.ORDER_TYPE_SHOP;
                btnType.Appearance.BackColor = Color.HotPink;
                btnType.Text = PubComm.ORDER_TYPE_SHOP;

                SetCustInfo(true, true, null);
            }

            //Close();
        }
        #endregion

        #region 窗口加载
        private void FrmTaMain_Load(object sender, EventArgs e)
        {
            //展开所有TreeList
            treeListOrder.ExpandAll();

            if (string.IsNullOrEmpty(strBusDate)) strBusDate = CommonDAL.GetBusDate();

            new SystemData().GetTaMenuCate();

            if (CommonData.TaMenuCate.Any())
            {
                iMenuSetId = CommonData.TaMenuCate.OrderBy(s => s.ID).FirstOrDefault().MenuSetID;
            }

            TaConfMenuDisplayFontInfo taSysFontInfo = new TaConfMenuDisplayFontInfo();
            if (CommonData.TaConfMenuDisplayFont.Any())
            {
                taSysFontInfo = CommonData.TaConfMenuDisplayFont.FirstOrDefault();
            }
            else
            {
                taSysFontInfo.MenuDisplayBtnFontSize = "12";
                taSysFontInfo.OtherMenuDisplayBtnFontSize = "12";
            }
            
            SetMenuItemBtn(taSysFontInfo);
            SetMenuCateBtn(taSysFontInfo);

            //加载MenuCate
            SetMenuCate(iCatePageNum, iMenuSetId);
            //加载MenuItem
            SetMenuItem(iCatePageNum, iMenuCateId, iMenuSetId);

            treeListOrder.KeyFieldName = "ID";
            treeListOrder.ParentFieldName = "ItemParent";

            //默认订单类型
            lblType.Text = PubComm.ORDER_TYPE_SHOP;

            if (string.IsNullOrEmpty(checkID))
            {
                //获得账单号
                checkID = CommonDAL.GetCheckCode();
                LogHelper.Info("#checkID:" + checkID + "#FrmTaMain_Load");
                lblCheck.Text = checkID;
            }
            else
            {
                new SystemData().GetTaOrderItem();
                new SystemData().GetTaCheckOrder();
                //TO DO something
                lblCheck.Text = checkID;

                var lstTaCO = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate));

                if (lstTaCO.Any())
                {
                    TaCheckOrderInfo taCheck = lstTaCO.FirstOrDefault();
                    ORDER_TYPE = lblType.Text = taCheck.PayOrderType;
                }
                //BindData(checkID);
                
                ChangeOrderBtnColor(ORDER_TYPE);

                InitGrid(CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate)).ToList());

                treeListOrder.ExpandAll();

                if (treeListOrder.Nodes.Count > 0) treeListOrder.SetFocusedNode(treeListOrder.Nodes[treeListOrder.Nodes.Count - 1]);

                isNew = false;
            }
            //加载TreeList
            //BindData();

            GetCustInfo(CustID);

            #region Payment相关
            //ReloadParam(false);
            //PaymentPubLoad();
            //QueryPayment();
            #endregion

            SetBtnLang(iLangStatusId);
            
            asfc.controllInitializeSize(this);

            #region 提示打开来电设备失败
            //if (isNew)
            //{
                if (!opendev())
                {
                    if (CommonTool.ConfirmMessage("Failed to open device, continue to order meal?") == DialogResult.Cancel)
                    {
                        //无来电设备连接时，取消打开
                        Close();
                    }
                }
            //}
            #endregion
        }
        #endregion

        #region Language按钮
        private void btnLanguage_Click(object sender, EventArgs e)
        {
            iLangStatusId = iLangStatusId == PubComm.MENU_LANG_DEFAULT 
                            ? PubComm.MENU_LANG_OTHER 
                            : PubComm.MENU_LANG_DEFAULT;

            SetMenuCate(iCatePageNum, iMenuSetId);
            SetMenuItem(iPageNum, iMenuCateId, iMenuSetId);

            //英文
            if (iLangStatusId == PubComm.MENU_LANG_DEFAULT)
            {
                foreach (TreeListNode treeListNode in treeListOrder.Nodes)
                {
                    //主菜品
                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_MAIN.ToString()))
                    {
                        if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(treeListNode["ItemCode"])))
                        {
                            treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString()
                                                           .Replace(CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiOtherName, 
                                                                    CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiEngName);
                        }

                        treeListNode["ItemDishName"] = ModifItemOtherName(treeListNode["ItemDishName"].ToString(), iLangStatusId);

                        if (treeListNode.HasChildren)
                        {
                            SetChildNode(treeListNode);
                        }
                    }
                }
            }
            else
            {
                foreach (TreeListNode treeListNode in treeListOrder.Nodes)
                {
                    //主菜品
                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_MAIN.ToString()))
                    {
                        if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(treeListNode["ItemCode"])))
                        {
                            treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString()
                                .Replace(CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiEngName,
                                    CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiOtherName);
                        }

                        treeListNode["ItemDishName"] = ModifItemOtherName(treeListNode["ItemDishName"].ToString(), iLangStatusId);

                        if (treeListNode.HasChildren)
                        {
                            SetChildNode(treeListNode);
                        }
                    }
                }
            }

            SetBtnLang(iLangStatusId);
        }
        #endregion

        #region MenuItem Right翻页
        private void btnMiRight_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(btnMenuItem[0].Text) && !string.IsNullOrEmpty(btnMenuItem[15].Text))
                iPageNum = iPageNum + 1;

            SetMenuItem(iPageNum, iMenuCateId, iMenuSetId);
        }
        #endregion

        #region MenuItem Left翻页
        private void btnMiLeft_Click(object sender, EventArgs e)
        {
            iPageNum = iPageNum <= 1 ? 1 : (iPageNum <= 1 ? 1 : iPageNum - 1);

            SetMenuItem(iPageNum, iMenuCateId, iMenuSetId);
        }
        #endregion

        #region MenuCate Right翻页
        private void btnMcRight_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(btnMenuCate[0].Text) && !string.IsNullOrEmpty(btnMenuCate[41].Text))
            if (!string.IsNullOrEmpty(btnMenuCate[0].Text))
            {
                iCatePageNum = iCatePageNum >= 2 ? 1 : iCatePageNum + 1;
            }

            SetMenuCate(iCatePageNum, iMenuSetId);

            //SetMenuItem(iPageNum, iCatePageNum, iMenuSetId);
        }
        #endregion

        #region MenuCate Left翻页
        private void btnMcLeft_Click(object sender, EventArgs e)
        {
            iCatePageNum = iCatePageNum <= 1 ? 2 : iCatePageNum - 1;

            SetMenuCate(iCatePageNum, iMenuSetId);

            //SetMenuItem(iPageNum, iCatePageNum, iMenuSetId);
        }
        #endregion

        #region TreeList向上移动
        private void btnUp_Click(object sender, EventArgs e)
        {
            //此为控制节点向上移动，打乱显示格局
            //treeListOrder.BeginUpdate();

            //treeListOrder.SetNodeIndex(treeListOrder.FocusedNode, treeListOrder.GetNodeIndex(treeListOrder.FocusedNode.PrevNode));

            //treeListOrder.EndUpdate();

            if (treeListOrder.Nodes.Count > 0)
            {
                treeListOrder.SetFocusedNode(treeListOrder.GetNodeIndex(treeListOrder.FocusedNode) - 1 >= 0
                   ? treeListOrder.Nodes[treeListOrder.GetNodeIndex(treeListOrder.FocusedNode) - 1]
                   : treeListOrder.Nodes[0]);
            }
        }

        #endregion

        #region TreeList向下移动
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (treeListOrder.Nodes.Count > 0)
            {
                treeListOrder.SetFocusedNode(treeListOrder.GetNodeIndex(treeListOrder.FocusedNode) - treeListOrder.Nodes.Count < 1
                   ? treeListOrder.Nodes[treeListOrder.Nodes.Count - 1]
                   : treeListOrder.Nodes[treeListOrder.GetNodeIndex(treeListOrder.FocusedNode) + 1]);
            }
        }
        #endregion

        #region TreeList增加Qty数量
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (treeListOrder.FocusedNode != null)
            {
                //只允许菜品操作
                if (treeListOrder.FocusedNode["ItemType"].ToString().Equals("1"))
                {
                    treeListOrder.BeginUpdate();
                    decimal dQty = Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"]);
                    decimal dPrice = Convert.ToDecimal(treeListOrder.FocusedNode["ItemTotalPrice"]);

                    if (dQty > 1)
                    {
                        treeListOrder.FocusedNode["ItemQty"] = (Convert.ToInt32(dQty + 1)).ToString();
                        treeListOrder.FocusedNode["ItemTotalPrice"] = ((dPrice / dQty) * (dQty + 1)).ToString("0.00");
                    }
                    else
                    {
                        treeListOrder.FocusedNode["ItemQty"] = (Convert.ToInt32(dQty + 1)).ToString();
                        treeListOrder.FocusedNode["ItemTotalPrice"] = (dPrice * 2.0m).ToString("0.00");
                    }

                    GetChildNodes(treeListOrder.FocusedNode, Convert.ToInt32(Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"].ToString())));

                    treeListOrder.EndUpdate();

                    treeListOrder.ExpandAll();
                }
                
            }
        }
        #endregion
        
        #region TreeList减少Qty数量
        private void btnReduce_Click(object sender, EventArgs e)
        {
            if (treeListOrder.FocusedNode != null)
            {
                //if (treeListOrder.FocusedNode["ItemType"].ToString().Equals("1"))
                //{
                    treeListOrder.BeginUpdate();
                    decimal dQty = Convert.ToDecimal(string.IsNullOrEmpty(treeListOrder.FocusedNode["ItemQty"].ToString()) 
                                                     ? "0" 
                                                     : treeListOrder.FocusedNode["ItemQty"]);
                    decimal dPrice = Convert.ToDecimal(string.IsNullOrEmpty(treeListOrder.FocusedNode["ItemTotalPrice"].ToString()) 
                                                       ? "0" 
                                                       : treeListOrder.FocusedNode["ItemTotalPrice"]);

                    if (dQty > 1.0m)
                    {
                        treeListOrder.FocusedNode["ItemQty"] = (Convert.ToInt32(dQty - 1)).ToString();
                        treeListOrder.FocusedNode["ItemTotalPrice"] = ((dPrice / dQty) * (dQty - 1)).ToString("0.00");

                        GetChildNodes(treeListOrder.FocusedNode, Convert.ToInt32(Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"].ToString())));
                    }
                    else
                    {
                        treeListOrder.DeleteNode(treeListOrder.FocusedNode);
                    }
                    treeListOrder.EndUpdate();

                    treeListOrder.ExpandAll();
                //}
            }

        }
        #endregion
        
        #region TreeList删除节点
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (treeListOrder.FocusedNode != null)
            {
                treeListOrder.DeleteNode(treeListOrder.FocusedNode);
            }
        }
        #endregion

        #region 增加改码
        private void btnAppend_Click(object sender, EventArgs e)
        {
            if (treeListOrder.FocusedNode != null)
            {
                string sQty = treeListOrder.FocusedNode["ItemQty"].ToString();

                //只允许菜品有改码
                if (treeListOrder.FocusedNode["ItemType"].ToString().Equals("1"))
                {
                    string sParentID = treeListOrder.FocusedNode["ItemID"].ToString();

                    List<TaOrderItemInfo> lstMi = new List<TaOrderItemInfo>();

                    FrmTaAppendItem frmTaAppendItem = new FrmTaAppendItem(iLangStatusId);
                    if (frmTaAppendItem.ShowDialog() == DialogResult.OK)
                    {
                        List<TaExtraResult> lstAppend = new List<TaExtraResult>();
                        lstAppend = frmTaAppendItem.LstResults;

                        if (lstAppend.Any())
                        {
                            foreach (var taExtraResult in lstAppend)
                            {
                                TaOrderItemInfo taOrderItemInfo = new TaOrderItemInfo();
                                taOrderItemInfo.ItemID = "0";
                                taOrderItemInfo.ItemCode = taExtraResult.rID.ToString();
                                taOrderItemInfo.ItemDishName = taExtraResult.rType + " " + (iLangStatusId == PubComm.MENU_LANG_DEFAULT ? taExtraResult.rItemName : taExtraResult.rOtherItemName);
                                taOrderItemInfo.ItemDishOtherName = taExtraResult.rType + " " + taExtraResult.rOtherItemName;
                                taOrderItemInfo.ItemQty = sQty;
                                taOrderItemInfo.ItemPrice = taExtraResult.rPrice;
                                taOrderItemInfo.ItemTotalPrice = (Convert.ToDecimal(sQty) * Convert.ToDecimal(taExtraResult.rPrice)).ToString();
                                taOrderItemInfo.CheckCode = checkID;
                                taOrderItemInfo.ItemType = PubComm.MENU_ITEM_APPEND;
                                taOrderItemInfo.ItemParent = sParentID;
                                //taOrderItemInfo.ItemParent = Convert.ToInt32(taMenuItemInfo.ID);
                                taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                                taOrderItemInfo.OrderStaff = usrID;

                                taOrderItemInfo.BusDate = strBusDate;
                                taOrderItemInfo.MenuItemID = 0;

                                taOrderItemInfo.IsDiscount = "N";

                                lstMi.Add(taOrderItemInfo);
                            }
                        }

                        if (lstMi.Any())
                        {
                            foreach (var orderItemInfo in lstMi) { AddTreeListChild(orderItemInfo, treeListOrder.FocusedNode); }
                        }
                    }
                }
            }
        }
        #endregion

        #region Ingred Mode
        private void btnIngredMode_Click(object sender, EventArgs e)
        {
            if (treeListOrder.FocusedNode != null)
            {
                ////只允许菜品
                //if (treeListOrder.FocusedNode["ItemType"].ToString().Equals("1"))
                //{
                    isIngredMode = true;

                    FrmTaIngredMode frmTaIngredMode = new FrmTaIngredMode();
                    frmTaIngredMode.Location = btnUp.PointToScreen(panelControl1.Location);

                    if (frmTaIngredMode.ShowDialog() == DialogResult.OK)
                    {
                        sModeValue = frmTaIngredMode.modeValue;

                        if (string.IsNullOrEmpty(sModeValue)) isIngredMode = false;
                    }
                //}
            }
        }
        #endregion

        #region Menu Set选择
        private void btnMenu_Click(object sender, EventArgs e)
        {
            FrmTaMenuSelect frmTaMenuSelect = new FrmTaMenuSelect(iMenuSetId);

            if (frmTaMenuSelect.ShowDialog() == DialogResult.OK)
            {
                iMenuSetId = frmTaMenuSelect.MenuSetId;

                //加载MenuCate
                SetMenuCate(iCatePageNum, iMenuSetId);
                //加载MenuItem
                SetMenuItem(iCatePageNum, iMenuCateId, iMenuSetId);
            }
        }
        #endregion

        #region 更改订单类型
        private void btnOrderType_Click(object sender, EventArgs e)
        {
            FrmTaChangeOrderType frmTaChangeOrderType = new FrmTaChangeOrderType();

            if (frmTaChangeOrderType.ShowDialog() == DialogResult.OK)
            {
                ORDER_TYPE = lblType.Text = frmTaChangeOrderType.OrderType;
                ChangeOrderBtnColor(ORDER_TYPE);
            }
        }
        #endregion

        #region Pay按钮
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (treeListOrder.AllNodesCount <= 0) return;

            #region 保存TreeList
            //new SystemData().GetTaOrderItem();
            //var lstDelOi = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate));

            //foreach (var taOrderItemInfo in lstDelOi)
            //{
            //    _control.DeleteEntity(taOrderItemInfo);
            //}

            AddFreeOrAutomatic();

            List<TaOrderItemInfo> lstTaOI = new List<TaOrderItemInfo>();
            
            lstTaOI = TreeListToOrderItem(isNew);
            
            //代码
            //new SystemData().GetTaOrderItem();

            //foreach (var taOrderItemInfo in lstTaOI)
            //{
            //    TaOrderItemInfo taOi = CommonData.TaOrderItem.FirstOrDefault(s => s.ID == taOrderItemInfo.ID);

            //    if (taOi != null)
            //    {
            //        _control.UpdateEntity(taOrderItemInfo);
            //    }
            //    else
            //    {
            //        _control.AddEntity(taOrderItemInfo);
            //    }
            //}

            DelegateOrder handler = DelegateOrderOpt.SaveOrder;
            IAsyncResult result = handler.BeginInvoke(checkID, strBusDate, lstTaOI, null, null);

            #endregion

            #region 保存账单
            //Console.WriteLine(treeListOrder.Columns["ItemTotalPrice"].SummaryFooter.ToString());
            SaveCheckOrder(lstTaOI, false);
            #endregion
            
            ht = SetPrtInfo(lstTaOI);
            
            if (ORDER_TYPE.Equals(PubComm.ORDER_TYPE_SHOP))
            {
                FrmTaPaymentShop frmTaPaymentShop = new FrmTaPaymentShop(usrID, checkID, ORDER_TYPE, CustID.ToString(), ht, strBusDate, saveTaCheckOrderInfo, lblReadyTime.Visible ? lblReadyTime.Text : "");
                frmTaPaymentShop.Location = pcMain.Location;
                frmTaPaymentShop.Size = pcMain.Size;
                
                if (frmTaPaymentShop.ShowDialog() == DialogResult.OK)
                {
                    if (frmTaPaymentShop.returnPaid) treeListOrder.Nodes.Clear();

                    checkID = (Convert.ToInt32(checkID) + 1).ToString();
                    lblCheck.Text = checkID;

                    SetCustClear();
                }
            }
            else if (ORDER_TYPE.Equals(PubComm.ORDER_TYPE_DELIVERY))
            {
                FrmTaPaymentDelivery frmTaPaymentDelivery = new FrmTaPaymentDelivery(usrID, checkID, ORDER_TYPE, CustID.ToString(), ht, strBusDate, saveTaCheckOrderInfo, lblReadyTime.Visible ? lblReadyTime.Text : "");
                frmTaPaymentDelivery.Location = pcMain.Location;
                frmTaPaymentDelivery.Size = pcMain.Size;

                if (frmTaPaymentDelivery.ShowDialog() == DialogResult.OK)
                {
                    if (frmTaPaymentDelivery.returnPaid) treeListOrder.Nodes.Clear();

                    checkID = (Convert.ToInt32(checkID) + 1).ToString();
                    lblCheck.Text = checkID;

                    SetCustClear();
                    ORDER_TYPE = PubComm.ORDER_TYPE_SHOP;
                    btnType.Appearance.BackColor = Color.HotPink;
                    btnType.Text = PubComm.ORDER_TYPE_SHOP;
                }
            }
            else if (ORDER_TYPE.Equals(PubComm.ORDER_TYPE_COLLECTION))
            {
                FrmTaPaymentCollection frmTaPaymentCollection = new FrmTaPaymentCollection(usrID, checkID, ORDER_TYPE, CustID.ToString(), ht, strBusDate, saveTaCheckOrderInfo, lblReadyTime.Visible ? lblReadyTime.Text : "");
                frmTaPaymentCollection.Location = pcMain.Location;
                frmTaPaymentCollection.Size = pcMain.Size;

                if (frmTaPaymentCollection.ShowDialog() == DialogResult.OK)
                {
                    if (frmTaPaymentCollection.returnPaid) treeListOrder.Nodes.Clear();

                    checkID = (Convert.ToInt32(checkID) + 1).ToString();
                    lblCheck.Text = checkID;

                    SetCustClear();
                    ORDER_TYPE = PubComm.ORDER_TYPE_SHOP;
                    btnType.Appearance.BackColor = Color.HotPink;
                    btnType.Text = PubComm.ORDER_TYPE_SHOP;
                }
            }
            else
            {
                FrmTaPayment frmTaPayment = new FrmTaPayment(usrID, checkID, ORDER_TYPE, CustID.ToString(), ht, strBusDate);
                frmTaPayment.Location = pcMain.Location;
                frmTaPayment.Size = pcMain.Size;

                if (frmTaPayment.ShowDialog() == DialogResult.OK)
                {
                    if (frmTaPayment.returnPaid) treeListOrder.Nodes.Clear();

                    checkID = CommonDAL.GetCheckCode();
                    lblCheck.Text = checkID;
                    LogHelper.Info("#checkID:" + checkID + "#btnPay_Click");
                    SetCustClear();
                }
            }

            handler.EndInvoke(result);
        }
        #endregion

        #region Pend Order按钮
        private void btnPendOrder_Click(object sender, EventArgs e)
        {
            isGetPhone = true;

            if (treeListOrder.AllNodesCount > 0)
            {
                FrmCancelOrder frmCancelOrder = new FrmCancelOrder();
                frmCancelOrder.Location = panelControl3.PointToScreen(panelControl1.Location);
                frmCancelOrder.Size = panelControl3.Size;

                if (frmCancelOrder.ShowDialog() == DialogResult.OK)
                {
                    var lstChk =
                        CommonData.TaCheckOrder.Where(
                            s => s.CheckCode.Equals(checkID) && s.IsPaid.Equals("N") && s.BusDate.Equals(strBusDate));
                    if (lstChk.Any())
                    {
                        TaCheckOrderInfo taCheck = lstChk.FirstOrDefault();
                        taCheck.IsCancel = "Y";
                        _control.UpdateEntity(taCheck);
                    }

                    treeListOrder.Nodes.Clear();

                    FrmTaPendOrder frmTaPendOrder = new FrmTaPendOrder(usrID, iLangStatusId);
                    this.Hide();
                    frmTaPendOrder.ShowDialog();
                    isGetPhone = false;
                }
            }
            else
            {
                FrmTaPendOrder frmTaPendOrder = new FrmTaPendOrder(usrID, iLangStatusId);
                this.Hide();
                frmTaPendOrder.ShowDialog();
                isGetPhone = false;
            }
        }
        #endregion

        #endregion

        #region 方法

        #region 设置MenuItem按钮
        /// <summary>
        /// 设置MenuItem按钮
        /// </summary>
        private void SetMenuItemBtn(TaConfMenuDisplayFontInfo taSysFontInfo)
        {
            btnMenuItem[0] = btnMi0;
            btnMenuItem[1] = btnMi1;
            btnMenuItem[2] = btnMi2;
            btnMenuItem[3] = btnMi3;
            btnMenuItem[4] = btnMi4;
            btnMenuItem[5] = btnMi5;
            btnMenuItem[6] = btnMi6;
            btnMenuItem[7] = btnMi7;
            btnMenuItem[8] = btnMi8;
            btnMenuItem[9] = btnMi9;
            btnMenuItem[10] = btnMi10;
            btnMenuItem[11] = btnMi11;
            btnMenuItem[12] = btnMi12;
            btnMenuItem[13] = btnMi13;
            btnMenuItem[14] = btnMi14;
            btnMenuItem[15] = btnMi15;

            for (int i = 0; i < 16; i++)
            {
                btnMenuItem[i].Click += btnMenuItem_Click;
                btnMenuItem[i].Font = SetBtnFont(taSysFontInfo, iLangStatusId, 1);
            }
        }
        #endregion

        #region MenuItem 点击
        /// <summary>
        /// MenuItem 点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenuItem_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;

            TaMenuItemInfo taMenuItemInfo = GetMenuItemInfo(btn.Text, iMenuCateId, iMenuSetId, false);

            SetMenuItem(taMenuItemInfo);
        }
        #endregion

        #region 设置MenuCate按钮
        /// <summary>
        /// 设置MenuCate按钮
        /// </summary>
        private void SetMenuCateBtn(TaConfMenuDisplayFontInfo taSysFontInfo)
        {
            btnMenuCate[0] = btnMc0;
            btnMenuCate[1] = btnMc1;
            btnMenuCate[2] = btnMc2;
            btnMenuCate[3] = btnMc3;
            btnMenuCate[4] = btnMc4;
            btnMenuCate[5] = btnMc5;
            btnMenuCate[6] = btnMc6;
            btnMenuCate[7] = btnMc7;
            btnMenuCate[8] = btnMc8;
            btnMenuCate[9] = btnMc9;
            btnMenuCate[10] = btnMc10;
            btnMenuCate[11] = btnMc11;
            btnMenuCate[12] = btnMc12;
            btnMenuCate[13] = btnMc13;
            btnMenuCate[14] = btnMc14;
            btnMenuCate[15] = btnMc15;
            btnMenuCate[16] = btnMc16;
            btnMenuCate[17] = btnMc17;
            btnMenuCate[18] = btnMc18;
            btnMenuCate[19] = btnMc19;
            btnMenuCate[20] = btnMc20;
            btnMenuCate[21] = btnMc21;
            btnMenuCate[22] = btnMc22;
            btnMenuCate[23] = btnMc23;
            btnMenuCate[24] = btnMc24;
            btnMenuCate[25] = btnMc25;
            btnMenuCate[26] = btnMc26;
            btnMenuCate[27] = btnMc27;
            btnMenuCate[28] = btnMc28;
            btnMenuCate[29] = btnMc29;
            btnMenuCate[30] = btnMc30;
            btnMenuCate[31] = btnMc31;
            btnMenuCate[32] = btnMc32;
            btnMenuCate[33] = btnMc33;
            btnMenuCate[34] = btnMc34;
            btnMenuCate[35] = btnMc35;
            btnMenuCate[36] = btnMc36;
            btnMenuCate[37] = btnMc37;
            btnMenuCate[38] = btnMc38;
            btnMenuCate[39] = btnMc39;
            btnMenuCate[40] = btnMc40;
            btnMenuCate[41] = btnMc41;

            for (int i = 0; i < 42; i++)
            {
                btnMenuCate[i].Click += btnMenuCate_Click;
                btnMenuCate[i].Font = SetBtnFont(taSysFontInfo, iLangStatusId, 2); ;
            }
        }
        #endregion

        #region MenuCate 点击
        /// <summary>
        /// MenuCate 点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenuCate_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;

            var lstMc = CommonData.TaMenuCate;

            TaMenuCateInfo taMenuCateInfo = null;

            lstMc = iLangStatusId == PubComm.MENU_LANG_OTHER 
                    ? CommonData.TaMenuCate.Where(s => s.CateOtherName.Equals(btn.Text)).ToList() 
                    : CommonData.TaMenuCate.Where(s => s.CateEngName.Equals(btn.Text)).ToList();

            if (lstMc.Any())
            {
                taMenuCateInfo = lstMc.FirstOrDefault();
                iMenuCateId = taMenuCateInfo.ID;
            }

            if (taMenuCateInfo != null && taMenuCateInfo.IsHotKey.Equals("Y"))
            {
                new SystemData().GetTaMenuItem();

                TaMenuItemInfo taMenuItemInfo = CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(taMenuCateInfo.HotKeyDishCode));

                if (taMenuItemInfo != null)
                {
                    SetMenuItem(taMenuItemInfo);
                }
            }
            else
            {
                iPageNum = 1;
                SetMenuItem(iPageNum, iMenuCateId, iMenuSetId);
            }
        }
        #endregion

        #region 设置MenuItem按钮显示
        /// <summary>
        /// 设置MenuItem按钮显示
        /// </summary>
        /// <param name="iPageNum">页码</param>
        /// <param name="mcId">MenuCate ID</param>
        /// <param name="msId">MenuSet ID</param>
        private void SetMenuItem(int iPageNum, int mcId, int msId)
        {
            bool status = CommonDAL.IsShowMenuItemCode();

            TaConfMenuDisplayFontInfo taSysFontInfo = new TaConfMenuDisplayFontInfo();
            if (CommonData.TaConfMenuDisplayFont.Any())
            {
                taSysFontInfo = CommonData.TaConfMenuDisplayFont.FirstOrDefault();
            }
            else
            {
                taSysFontInfo.MenuDisplayBtnFontSize = "12";
                taSysFontInfo.OtherMenuDisplayBtnFontSize = "12";
            }

            int i = 0;
            foreach (var taMenuItemInfo in CommonDAL.GetListQueryPageMenuItem(iPageNum, iMenuCateId, iMenuSetId))
            {
                btnMenuItem[i].Text = status
                    ? "(" + taMenuItemInfo.MiDishCode + ")" +
                      (iLangStatusId == PubComm.MENU_LANG_DEFAULT
                          ? taMenuItemInfo.MiEngName
                          : taMenuItemInfo.MiOtherName)
                    : (iLangStatusId == PubComm.MENU_LANG_DEFAULT
                        ? taMenuItemInfo.MiEngName
                        : taMenuItemInfo.MiOtherName);

                
                btnMenuItem[i].Appearance.BackColor = string.IsNullOrEmpty(taMenuItemInfo.MiBtnColor) 
                                                        ? Color.FromName(@"Gold")
                                                        : Color.FromName(taMenuItemInfo.MiBtnColor);
                btnMenuItem[i].Font = SetBtnFont(taSysFontInfo, iLangStatusId, 1);

                i++;
            }

            for (int j = i; j < 16; j++)
            {
                btnMenuItem[j].Text = "";
                btnMenuItem[j].Appearance.BackColor = Color.FromName(@"Gold");
            }
        }
        #endregion

        #region 设置MenuCate按钮显示
        /// <summary>
        /// 设置MenuCate按钮显示
        /// </summary>
        /// <param name="iPageNum">页码</param>
        /// <param name="msId">MenuSet ID</param>
        private void SetMenuCate(int iPageNum, int msId)
        {
            int i = 0;

            TaConfMenuDisplayFontInfo taSysFontInfo = new TaConfMenuDisplayFontInfo();
            if (CommonData.TaConfMenuDisplayFont.Any())
            {
                taSysFontInfo = CommonData.TaConfMenuDisplayFont.FirstOrDefault();
            }
            else
            {
                taSysFontInfo.MenuDisplayBtnFontSize = "12";
                taSysFontInfo.OtherMenuDisplayBtnFontSize = "12";
            }

            foreach (var taMenuCateInfo in CommonDAL.GetListQueryPageMenuCate(iPageNum, msId))
            {
                btnMenuCate[i].Text = iLangStatusId == PubComm.MENU_LANG_DEFAULT
                    ? taMenuCateInfo.CateEngName
                    : taMenuCateInfo.CateOtherName;
                btnMenuCate[i].Appearance.BackColor = string.IsNullOrEmpty(taMenuCateInfo.BtnColor)
                                                        ? Color.FromName(@"RoyalBlue")
                                                        : Color.FromName(taMenuCateInfo.BtnColor);

                btnMenuCate[i].Font = SetBtnFont(taSysFontInfo, iLangStatusId, 2);

                i++;
            }

            for (int j = i; j < 42; j++)
            {
                btnMenuCate[j].Text = "";
                btnMenuCate[j].Appearance.BackColor = Color.FromName(@"RoyalBlue");
            }
        }
        #endregion

        #region 绑定TreeList数据

        private void BindData(string checkCode)
        {
            new SystemData().GetTaOrderItem();

            treeListOrder.DataSource = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkCode) && s.BusDate.Equals(strBusDate)).ToList();

            treeListOrder.KeyFieldName = "ID";
            treeListOrder.ParentFieldName = "ItemParent";

            //展开所有TreeList
            treeListOrder.ExpandAll();
        }
        #endregion

        #region 增加TreeList节点

        private TreeListNode AddTreeListNode(TaOrderItemInfo taOrderItemInfo)
        {
            treeListOrder.BeginUnboundLoad();

            //treeListOrder.AppendNode(new object[]
            TreeListNode node = treeListOrder.AppendNode(new object[]
            {
                taOrderItemInfo.ID,
                taOrderItemInfo.ItemQty,
                taOrderItemInfo.ItemID,
                taOrderItemInfo.ItemDishName,
                taOrderItemInfo.ItemCode,
                taOrderItemInfo.ItemDishOtherName,
                taOrderItemInfo.ItemPrice,
                taOrderItemInfo.ItemTotalPrice,
                taOrderItemInfo.CheckCode,
                taOrderItemInfo.ItemType,
                taOrderItemInfo.ItemParent,
                taOrderItemInfo.OrderTime,
                taOrderItemInfo.OrderStaff,
                taOrderItemInfo.BusDate,
                taOrderItemInfo.MenuItemID,
                taOrderItemInfo.IsDiscount
            }, -1);

            treeListOrder.EndUnboundLoad();

            treeListOrder.ExpandAll();

            return node;

            //node.SetValue(treeListOrder.Columns[0], taOrderItemInfo.ID);
            //node.SetValue(treeListOrder.Columns[1], taOrderItemInfo.ItemCode);
            //node.SetValue(treeListOrder.Columns[2], taOrderItemInfo.ItemDishName);
            //node.SetValue(treeListOrder.Columns[3], taOrderItemInfo.ItemDishOtherName);
            //node.SetValue(treeListOrder.Columns[4], taOrderItemInfo.ItemQty);
            //node.SetValue(treeListOrder.Columns[5], taOrderItemInfo.ItemPrice);
            //node.SetValue(treeListOrder.Columns[6], taOrderItemInfo.ItemTotalPrice);
            //node.SetValue(treeListOrder.Columns[7], taOrderItemInfo.CheckCode);
            //node.SetValue(treeListOrder.Columns[8], taOrderItemInfo.ItemType);
            //node.SetValue(treeListOrder.Columns[9], taOrderItemInfo.ItemParent);
            //node.SetValue(treeListOrder.Columns[10], taOrderItemInfo.OrderTime);
            //node.SetValue(treeListOrder.Columns[11], taOrderItemInfo.OrderStaff);
        }
        #endregion

        #region 增加TreeList子节点
        /// <summary>
        /// 增加TreeList子节点
        /// </summary>
        /// <param name="taOrderItemInfo">OrderItem信息</param>
        /// <param name="node">父节点</param>
        private void AddTreeListChild(TaOrderItemInfo taOrderItemInfo, TreeListNode node)
        {
            treeListOrder.BeginUnboundLoad();

            TreeListNode node1 = treeListOrder.AppendNode(new object[]
            {
                taOrderItemInfo.ID,
                taOrderItemInfo.ItemQty,
                taOrderItemInfo.ItemID,
                taOrderItemInfo.ItemDishName,
                taOrderItemInfo.ItemCode,    
                taOrderItemInfo.ItemDishOtherName,
                taOrderItemInfo.ItemPrice,
                taOrderItemInfo.ItemTotalPrice,
                taOrderItemInfo.CheckCode,
                taOrderItemInfo.ItemType,
                taOrderItemInfo.ItemParent,
                taOrderItemInfo.OrderTime,
                taOrderItemInfo.OrderStaff,
                taOrderItemInfo.BusDate,
                taOrderItemInfo.MenuItemID,
                taOrderItemInfo.IsDiscount
            }, node);

            //Console.WriteLine(node1["ItemParent"].ToString());

            treeListOrder.EndUnboundLoad();

            treeListOrder.ExpandAll();
        }
        #endregion

        #region 获得按钮信息
        /// <summary>
        /// 获得按钮信息
        /// </summary>
        /// <param name="name">MenuItem名字</param>
        /// <param name="mcId">MenuCate ID</param>
        /// <param name="msId">MenuSet ID</param>
        /// <returns></returns>
        public TaMenuItemInfo GetMenuItemInfo(string name, int mcId, int msId, bool isKeyPad)
        {
            var lstMc = CommonData.TaMenuItem;

            if (isKeyPad)
            {
                lstMc = CommonData.TaMenuItem.Where(s => s.MiDishCode.Equals(name)).ToList();
            }
            else
            {
                if (CommonDAL.IsShowMenuItemCode())
                {
                    name = name.Substring(name.IndexOf("(") + 1, name.IndexOf(")") - name.IndexOf("(") - 1);

                    lstMc = CommonData.TaMenuItem.Where(s => s.MiDishCode.Equals(name)).ToList();
                }
                else
                {
                    lstMc = iLangStatusId == PubComm.MENU_LANG_DEFAULT
                    ? CommonData.TaMenuItem.Where(s => s.MiEngName.Equals(name)).ToList()
                    : CommonData.TaMenuItem.Where(s => s.MiOtherName.Equals(name)).ToList();
                }
            }

            if (msId == 0)
            {
                return mcId == 0
                    ? (lstMc.Any() ? lstMc.FirstOrDefault() : null)
                    : (lstMc.Any(s => s.MiMenuCateID.Contains(mcId.ToString()))
                        ? lstMc.FirstOrDefault(s => s.MiMenuCateID.Contains(mcId.ToString()))
                        : null);
            }
            else
            {
                return mcId == 0
                    ? (lstMc.Any(s => s.MiMenuSetID == msId)
                        ? lstMc.FirstOrDefault(s => s.MiMenuSetID == msId)
                        : null)
                    : (lstMc.Any(s => s.MiMenuCateID.Contains(mcId.ToString()) && s.MiMenuSetID == msId)
                        ? lstMc.FirstOrDefault(s => s.MiMenuCateID.Contains(mcId.ToString()) && s.MiMenuSetID == msId)
                        : null);
            }
        }
        #endregion

        #region MenuItem Second/Third Choices自动增加获取
        /// <summary>
        /// MenuItem Second/Third Choices自动增加获取
        /// </summary>
        /// <param name="miId">MenuItem ID</param>
        /// <param name="miQty">MenuItem Qty</param>
        /// <param name="miCheckCode">账单号</param>
        /// <returns></returns>
        private void GetAppendOtherChoice(int miId, string miQty, string miCheckCode, string itemId, TreeListNode miNode)
        {
            new SystemData().GetTaMenuItemOtherChoice();

            List<TaOrderItemInfo> lstMi = new List<TaOrderItemInfo>();

            var lstOther = CommonData.TaMenuItemOtherChoice.Where(s => s.MiID == miId && s.IsAutoAppend.Equals("Y") && s.IsEnableChoice.Equals("Y"));

            if (lstOther.Any())
            {
                foreach (var taMenuItemOtherChoiceInfo in lstOther)
                {
                    TaOrderItemInfo taOrderItemInfo = new TaOrderItemInfo();
                    taOrderItemInfo.ItemCode = taMenuItemOtherChoiceInfo.ID.ToString();
                    taOrderItemInfo.ItemDishName = taMenuItemOtherChoiceInfo.MiEngName;
                    taOrderItemInfo.ItemDishOtherName = taMenuItemOtherChoiceInfo.MiOtherName;
                    taOrderItemInfo.ItemQty = miQty;
                    taOrderItemInfo.ItemPrice = taMenuItemOtherChoiceInfo.MiPrice;
                    taOrderItemInfo.ItemTotalPrice = (Convert.ToInt32(miQty) * Convert.ToDecimal(taMenuItemOtherChoiceInfo.MiPrice)).ToString();
                    taOrderItemInfo.CheckCode = miCheckCode;
                    taOrderItemInfo.ItemType = PubComm.MENU_ITEM_CHILD;
                    taOrderItemInfo.ItemParent = itemId;
                    taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                    taOrderItemInfo.OrderStaff = usrID;

                    lstMi.Add(taOrderItemInfo);
                }
            }

            if (lstMi.Any())
            {
                foreach (var orderItemInfo in lstMi) { AddTreeListChild(orderItemInfo, miNode); }
            }
        }
        #endregion

        #region MenuItem Second/Third Choices用户选择增加

        /// <summary>
        ///  MenuItem Second/Third Choices用户选择增加
        /// </summary>
        /// <param name="miId"></param>
        /// <param name="miQty"></param>
        /// <param name="miCheckCode"></param>
        /// <param name="node"></param>
        private void GetNotAppendOtherChoice(int mId, string mQty, string mCheckCode, string itemId, TreeListNode mNode, bool isSubMenu)
        {
            new SystemData().GetTaMenuItemOtherChoice();

            var lstOther = CommonData.TaMenuItemOtherChoice.Where(s => s.MiID == mId && s.IsEnableChoice.Equals("Y"));

            List<TaOrderItemInfo> lstMi = new List<TaOrderItemInfo>();

            List<TaMenuItemOtherChoiceInfo> lstResult = new List<TaMenuItemOtherChoiceInfo>();

            if (lstOther.Any())
            {
                //弹出用户选择窗口
                if (lstOther.Any(s => s.MiType == 2)) //存在Second Choices
                {
                    //弹出窗口选择
                    FrmTAOtherChoice frmTaOtherChoice1 = new FrmTAOtherChoice(2, mId, lstOther.Where(s => s.MiType == 2).ToList(), iLangStatusId);
                    frmTaOtherChoice1.Location = panelControl5.PointToScreen(panelControl1.Location);
                    //frmTaOtherChoice1.Size = panelControl5.Size + panelControl3.Size;
                    frmTaOtherChoice1.Size = new Size(panelControl5.Width + panelControl3.Width, panelControl5.Height);
                    if (frmTaOtherChoice1.ShowDialog() == DialogResult.OK)
                    {
                        lstResult = frmTaOtherChoice1.lstReturnChoice;
                    }
                }

                if (lstOther.Any(s => s.MiType == 3))
                {
                    //弹出窗口选择
                    FrmTAOtherChoice frmTaOtherChoice2 = new FrmTAOtherChoice(3, mId, lstOther.Where(s => s.MiType == 3).ToList(), iLangStatusId);
                    frmTaOtherChoice2.Location = panelControl5.PointToScreen(panelControl1.Location);
                    //frmTaOtherChoice2.Size = panelControl5.Size + panelControl3.Size;
                    frmTaOtherChoice2.Size = new Size(panelControl5.Width + panelControl3.Width, panelControl5.Height);
                    if (frmTaOtherChoice2.ShowDialog() == DialogResult.OK)
                    {
                        if (frmTaOtherChoice2.lstReturnChoice.Any()) lstResult.AddRange(frmTaOtherChoice2.lstReturnChoice);
                    }
                }
            }

            //if (isSubMenu)
            //{
            //    lstResult.AddRange(CommonData.TaMenuItemOtherChoice.Where(s => s.MiID == mId && s.IsEnableChoice.Equals("Y")));
            //}

            foreach (var taMenuItemOtherChoiceInfo in lstResult)
            {
                TaOrderItemInfo taOrderItemInfo = new TaOrderItemInfo();
                taOrderItemInfo.ItemID = "0";
                taOrderItemInfo.ItemCode = taMenuItemOtherChoiceInfo.ID.ToString();
                taOrderItemInfo.ItemQty = mQty;
                taOrderItemInfo.ItemTotalPrice = (Convert.ToInt32(mQty) * Convert.ToDecimal(taMenuItemOtherChoiceInfo.MiPrice)).ToString();
                taOrderItemInfo.BusDate = strBusDate;
                taOrderItemInfo.MenuItemID = taMenuItemOtherChoiceInfo.ID;

                if (taMenuItemOtherChoiceInfo.IsAutoAppend.Equals("Y"))
                {
                    //为语言转换做数据存储
                    if (!dOtherChoice.ContainsKey(taMenuItemOtherChoiceInfo.MiEngName)) dOtherChoice.Add(taMenuItemOtherChoiceInfo.MiEngName, taMenuItemOtherChoiceInfo.MiOtherName);

                    mNode["ItemDishName"] = mNode["ItemDishName"] + taMenuItemOtherChoiceInfo.MiEngName;
                    mNode["ItemDishOtherName"] = mNode["ItemDishOtherName"] + taMenuItemOtherChoiceInfo.MiOtherName;

                    treeListOrder.BeginUpdate();
                    decimal dQty = Convert.ToDecimal(mNode["ItemQty"]);
                    decimal dPrice = Convert.ToDecimal(mNode["ItemTotalPrice"]);

                    if (dQty >= 1.0m)
                    {
                        mNode["ItemTotalPrice"] = ((dPrice + Convert.ToDecimal(taMenuItemOtherChoiceInfo.MiPrice)) * dQty).ToString("0.00");
                    }
                    treeListOrder.EndUpdate();

                    treeListOrder.ExpandAll();
                }
                else
                {
                    taOrderItemInfo.ItemDishName = taMenuItemOtherChoiceInfo.MiEngName;
                    taOrderItemInfo.ItemDishOtherName = taMenuItemOtherChoiceInfo.MiOtherName;
                    taOrderItemInfo.ItemPrice = taMenuItemOtherChoiceInfo.MiPrice;

                    taOrderItemInfo.CheckCode = mCheckCode;
                    taOrderItemInfo.ItemType = PubComm.MENU_ITEM_CHILD;
                    taOrderItemInfo.ItemParent = itemId;
                    taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                    taOrderItemInfo.OrderStaff = usrID;

                    taOrderItemInfo.MenuItemID = taMenuItemOtherChoiceInfo.ID;

                    lstMi.Add(taOrderItemInfo);
                }
                
            }

            if (lstMi.Any())
            {
                foreach (var orderItemInfo in lstMi) { AddTreeListChild(orderItemInfo, mNode); }
            }
        }

        #endregion

        #region MenuItem Second/Third Choices设置

        private void SetAllOtherChoice(int miId, string miQty, string miCheckCode, string itemId, TreeListNode node, bool isSubMenu)
        {
            //Second/Third Choices自动增加
            //GetAppendOtherChoice(miId, miQty, miCheckCode, itemId, node);
            //Second/Third Choices用户选择增加
            GetNotAppendOtherChoice(miId, miQty, miCheckCode, itemId, node, isSubMenu);
        }
        #endregion

        #region TreeList转为OrderItem

        private List<TaOrderItemInfo> TreeListToOrderItem(bool isAdd)
        {
            List<TaOrderItemInfo> lstTaOI = new List<TaOrderItemInfo>();

            try
            {
                foreach (TreeListNode node in treeListOrder.Nodes)
                {
                    TaOrderItemInfo taOrderItemInfo = new TaOrderItemInfo();

                    if (!isNew) taOrderItemInfo.ID = Convert.ToInt32(node["ID"]);

                    taOrderItemInfo.ItemID = node["ItemID"].ToString();
                    taOrderItemInfo.ItemCode = node["ItemCode"].ToString();
                    taOrderItemInfo.ItemQty = node["ItemQty"].ToString();
                    taOrderItemInfo.ItemPrice = node["ItemPrice"].ToString();
                    taOrderItemInfo.ItemTotalPrice = node["ItemTotalPrice"].ToString();
                    taOrderItemInfo.CheckCode = node["CheckCode"].ToString();
                    taOrderItemInfo.ItemType = Convert.ToInt32(node["ItemType"]);

                    //taOrderItemInfo.ItemDishName = node["ItemDishName"].ToString();
                    if (iLangStatusId != PubComm.MENU_LANG_DEFAULT)
                    {
                        if (taOrderItemInfo.ItemType == PubComm.MENU_ITEM_MAIN)
                        {
                            TaMenuItemInfo taMi = CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(node["ItemCode"]));
                            if (taMi != null)
                            {
                                taOrderItemInfo.ItemDishName = node["ItemDishName"].ToString().Replace(taMi?.MiOtherName, taMi?.MiEngName);
                            }

                            taOrderItemInfo.ItemDishName = ModifItemOtherName(taOrderItemInfo.ItemDishName, PubComm.MENU_LANG_DEFAULT);
                        }

                    }
                    else
                    {
                        taOrderItemInfo.ItemDishName = node["ItemDishName"].ToString();
                    }

                    taOrderItemInfo.ItemDishOtherName = ModifItemOtherName(node["ItemDishOtherName"].ToString(), PubComm.MENU_LANG_OTHER);
                    
                    taOrderItemInfo.ItemParent = "0";
                    taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                    taOrderItemInfo.OrderStaff = usrID;
                    taOrderItemInfo.BusDate = strBusDate;
                    taOrderItemInfo.MenuItemID = Convert.ToInt32(node["MenuItemID"]);

                    taOrderItemInfo.IsDiscount = node["IsDiscount"].ToString();

                    lstTaOI.Add(taOrderItemInfo);

                    if (node.HasChildren)
                    {
                        lstTaOI.AddRange(GetTreeListChild(isAdd, node["ItemID"].ToString(), node));
                    }
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            return lstTaOI;
        }
        #endregion

        #region TreeList子节点转为OrderItem
        /// <summary>
        /// TreeList子节点转为OrderItem
        /// </summary>
        /// <param name="isAdd"></param>
        /// <param name="parentID"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<TaOrderItemInfo> GetTreeListChild(bool isAdd, string parentID, TreeListNode node)
        {
            List<TaOrderItemInfo> lstTaOI = new List<TaOrderItemInfo>();

            try
            {
                foreach (TreeListNode childNode in node.Nodes)
                {
                    TaOrderItemInfo taOrderItemInfo = new TaOrderItemInfo();

                    if (!isNew) taOrderItemInfo.ID = Convert.ToInt32(childNode["ID"]);

                    taOrderItemInfo.ItemID = "0";
                    taOrderItemInfo.ItemCode = childNode["ItemCode"].ToString();
                    taOrderItemInfo.ItemQty = childNode["ItemQty"].ToString();
                    taOrderItemInfo.ItemPrice = childNode["ItemPrice"].ToString();
                    taOrderItemInfo.ItemTotalPrice = childNode["ItemTotalPrice"].ToString();
                    taOrderItemInfo.CheckCode = childNode["CheckCode"].ToString();
                    taOrderItemInfo.ItemType = Convert.ToInt32(childNode["ItemType"]);

                    if (taOrderItemInfo.ItemType == PubComm.MENU_ITEM_APPEND)
                    {
                        TaExtraMenuInfo taExtraMenuInfo = CommonData.TaExtraMenu.FirstOrDefault(s => s.ID.ToString().Equals(childNode["ItemCode"]));
                        if (taExtraMenuInfo != null)
                        {
                            taOrderItemInfo.ItemDishName = childNode["ItemDishName"].ToString().Replace(taExtraMenuInfo?.eMenuOtherName, taExtraMenuInfo?.eMenuEngName);
                        }
                    }
                    else
                    {
                        taOrderItemInfo.ItemDishName = childNode["ItemDishName"].ToString();
                    }

                    taOrderItemInfo.ItemDishOtherName = childNode["ItemDishOtherName"].ToString();

                    taOrderItemInfo.ItemParent = parentID;
                    taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                    taOrderItemInfo.OrderStaff = usrID;
                    taOrderItemInfo.BusDate = strBusDate;
                    taOrderItemInfo.MenuItemID = Convert.ToInt32(childNode["MenuItemID"]);

                    taOrderItemInfo.IsDiscount = childNode["IsDiscount"].ToString();

                    lstTaOI.Add(taOrderItemInfo);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            return lstTaOI;
        } 
        #endregion

        #region 来电显示相关
        private void AppendStatus(string ms)
        {
        }

        public static string FromUnicodeByteArray(byte[] characters)
        {
            UnicodeEncoding u = new UnicodeEncoding();
            string ustring = u.GetString(characters);
            return ustring;
        }

        public static string FromASCIIByteArray(byte[] characters)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case BriSDKLib.BRI_EVENT_MESSAGE:
                    {
                        BriSDKLib.TBriEvent_Data EventData = (BriSDKLib.TBriEvent_Data)Marshal.PtrToStructure(m.LParam, typeof(BriSDKLib.TBriEvent_Data));
                        string strValue = "";
                        switch (EventData.lEventType)
                        {
                            case BriSDKLib.BriEvent_PhoneHook:
                                {
                                    strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：电话机摘机";
                                }
                                break;
                            case BriSDKLib.BriEvent_PhoneHang:
                                {
                                    strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：电话机挂机";
                                }
                                break;
                            case BriSDKLib.BriEvent_CallIn:
                                {////两声响铃结束后开始呼叫转移到CC
                                    //strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：来电响铃" + FromASCIIByteArray(EventData.szData);
                                    //if (string.IsNullOrEmpty(strTranPhoneNum.Trim())) return;

                                    if (strTranPhoneNum.Trim().Equals("0") || strTranPhoneNum.Trim().Equals("1")) return;

                                    string strPhoneNum = FromASCIIByteArray(EventData.szData).Trim();
                                    
                                    if (!string.IsNullOrEmpty(strPhoneNum))
                                    {
                                        if (strPhoneNum.Equals("0") || strPhoneNum.Equals("1")) return;
                                    }
                                    
                                    //LogHelper.Info("BriEvent_CallIn#strTranPhoneNum:" + strTranPhoneNum + "##" + FromASCIIByteArray(EventData.szData).Trim() + "#isGetPhone:" + isGetPhone.ToString());

                                    if (string.IsNullOrEmpty(strTranPhoneNum))
                                    {
                                        strTranPhoneNum = strPhoneNum;
                                    }
                                    
                                    if (!string.IsNullOrEmpty(strTranPhoneNum) && !isGetPhone)
                                    {
                                        ShowCallIdWindow(strTranPhoneNum);
                                    }
                                }
                                break;
                            case BriSDKLib.BriEvent_GetCallID:
                            case BriSDKLib.BriEvent_RecvedFSK:
                                {
                                    //strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：接收到来电号码 " + FromASCIIByteArray(EventData.szData);

                                    try
                                    {
                                        //LogHelper.Info("a:#" + isGetPhone.ToString() + "#");
                                        #region 来电显示
                                        
                                        string CallerPhone = FromASCIIByteArray(EventData.szData).Trim();

                                        if (!string.IsNullOrEmpty(CallerPhone))
                                        {
                                            if (CallerPhone.Equals("0") || CallerPhone.Equals("1")) return;
                                        }
                                        
                                        strTranPhoneNum = CallerPhone.Trim();

                                        if (isGetPhone) return;
                                        
                                        //LogHelper.Info("BriEvent_GetCallID#CallerPhone:" + CallerPhone.Trim() + "strTranPhoneNum:" + strTranPhoneNum + "#isGetPhone:" + isGetPhone.ToString());

                                        ShowCallIdWindow(CallerPhone);

                                        #endregion
                                    }
                                    catch (Exception ex) { LogHelper.Error("DefWndProc", ex); }
                                }
                                break;
                            default:
                                strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：接受到未解析消息代码 " + EventData.lEventType.ToString();
                                break;
                        }
                        if (strValue.Length > 0)
                        {
                            AppendStatus(strValue);
                        }
                    }
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        #region 打开设备
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        private delegate Int32 ProcEventCallback(Int16 uChannelID, Int32 dwUserData, Int32 lType, Int32 lHandle, Int32 lResult, Int32 lParam, IntPtr pData, IntPtr pDataEx);

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private static ProcEventCallback procEvent;

        static Int32 procEventCallback(Int16 uChannelID, Int32 dwUserData, Int32 lType, Int32 lHandle, Int32 lResult, Int32 lParam, IntPtr pData, IntPtr pDataEx)
        {
            //回调函数被调用，用户可以根据需要编写自己的代码
            //以下代码只是为展示消息，向窗体传送消息。非必须。
            BriSDKLib.TBriEvent_Data tbe = new BriSDKLib.TBriEvent_Data { };
            tbe.uChannelID = uChannelID;
            tbe.lEventType = lType;
            tbe.lEventHandle = lHandle;
            tbe.lParam = lParam;
            tbe.lResult = lResult;
            tbe.szData = new byte[BriSDKLib.MAX_BRIEVENT_DATA];
            Marshal.Copy(pData, tbe.szData, 0, BriSDKLib.MAX_BRIEVENT_DATA - 1);
            int size = Marshal.SizeOf(typeof(BriSDKLib.TBriEvent_Data));
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(tbe, bufferIntPtr, false);
            SendMessage((IntPtr)dwUserData, BriSDKLib.BRI_EVENT_MESSAGE, IntPtr.Zero, bufferIntPtr);
            Marshal.FreeHGlobal(bufferIntPtr);
            return 1;
        }

        private bool opendev()
        {
            try
            {
                if (BriSDKLib.QNV_OpenDevice(BriSDKLib.ODT_LBRIDGE, 0, "") <= 0 || BriSDKLib.QNV_DevInfo(0, BriSDKLib.QNV_DEVINFO_GETCHANNELS) <= 0)
                {
                    AppendStatus("打开设备失败");
                    return false;
                }
            
                procEvent = new ProcEventCallback(procEventCallback);

                for (Int16 i = 0; i < BriSDKLib.QNV_DevInfo(-1, BriSDKLib.QNV_DEVINFO_GETCHANNELS); i++)
                {
                    //方式1还是2，根据自己需要,任选一种
                    //
                    //方式1：有窗体程序，在windowproc处理接收到的消息
                    BriSDKLib.QNV_Event(i, BriSDKLib.QNV_EVENT_REGWND, (Int32)this.Handle, IntPtr.Zero, new StringBuilder(0), 0);

                    //方式2：无窗体程序，在回调函数procEvent里面处理消息，窗体Handle不是必须参数（无窗体可以传0），本例为在窗体显示消息方便才传递过去，会在回调函数里面原样传回
                    //BriSDKLib.QNV_Event(i, BriSDKLib.QNV_EVENT_REGCBFUNC, (Int32)this.Handle, Marshal.GetFunctionPointerForDelegate(procEvent), new StringBuilder(0), 0);

                    BriSDKLib.QNV_SetParam(i, BriSDKLib.QNV_PARAM_AM_LINEIN, 5);  //设置线路增益              
                }
                
                //AppendStatus("打开设备成功");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error("opendev:" + ex.Message);
                return false;
            }
        }
        
        #endregion
        
        #endregion

        #region 保存账单

        private void SaveCheckOrder(List<TaOrderItemInfo> lstTaOI, bool isSave)
        {
            new SystemData().GetTaCheckOrder();
            TaCheckOrderInfo taCheckOrderInfo = new TaCheckOrderInfo();
            var lstChk = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate));
            if (lstChk.Any())
            {
                taCheckOrderInfo = lstChk.FirstOrDefault();
                //taCheckOrderInfo = lstChk.FirstOrDefault();
                taCheckOrderInfo.PayOrderType = ORDER_TYPE;
                //taCheckOrderInfo.MenuAmount = lstTaOI.Sum(s => Convert.ToDecimal(string.IsNullOrEmpty(s.ItemTotalPrice) ? "0.00" : s.ItemTotalPrice)).ToString();
                taCheckOrderInfo.MenuAmount = treeListOrder.Nodes.Count > 0 ? treeListOrder.GetSummaryValue(treeListOrder.Columns[7]).ToString() : "0.00";
                //taCheckOrderInfo.PayDiscount = CommonDAL.GetTaDiscount(ORDER_TYPE, Convert.ToDecimal(taCheckOrderInfo.MenuAmount)).ToString();

                TaDiscountInfo tdi = CommonData.TaDiscount.FirstOrDefault(s => s.TaType.Equals(ORDER_TYPE));
                if (tdi != null)
                {
                    string strPayPerDiscount = tdi.TaDiscount;

                    if (Convert.ToDecimal(taCheckOrderInfo.MenuAmount) > Convert.ToDecimal(string.IsNullOrEmpty(tdi.TaDiscThre) ? "0.00" : tdi.TaDiscThre))
                    {
                        taCheckOrderInfo.PayPerDiscount = strPayPerDiscount.Equals(@"0") ? "" : strPayPerDiscount + @"%";
                        //taCheckOrderInfo.PayDiscount = (Convert.ToDecimal(taCheckOrderInfo.TotalAmount)
                        //                                * Convert.ToDecimal(strPayPerDiscount) / 100).ToString("0.00");
                        //折扣
                        decimal dDiscount = CommonDAL.GetTaDiscount(ORDER_TYPE, Convert.ToDecimal(taCheckOrderInfo.MenuAmount));
                        //折扣后的价格
                        decimal dDiscountTotal = CommonDAL.GetAllDiscount(lstTaOI, dDiscount);
                        taCheckOrderInfo.PayDiscount = dDiscountTotal.ToString("0.00");
                    }
                    else
                    {
                        taCheckOrderInfo.PayPerDiscount = "";
                        taCheckOrderInfo.PayDiscount = @"0.00";
                    }
                }
                else
                    taCheckOrderInfo.PayDiscount = @"0.00";

                if (Convert.ToDecimal(taCheckOrderInfo.PayDiscount) > 0)
                {
                    taCheckOrderInfo.TotalAmount = (Convert.ToDecimal(taCheckOrderInfo.TotalAmount) - Convert.ToDecimal(taCheckOrderInfo.PayDiscount)).ToString();
                }
                
                taCheckOrderInfo.StaffID = usrID;
                taCheckOrderInfo.PayTime = DateTime.Now.ToString();
                taCheckOrderInfo.IsSave = isSave ? "Y" : "N";
                taCheckOrderInfo.DeliveryFee = (CustID >= 1 && ORDER_TYPE.Equals(PubComm.ORDER_TYPE_DELIVERY)) ? lblDeliveryFee.Text : @"0.00";

                saveTaCheckOrderInfo = taCheckOrderInfo;

                _control.UpdateEntity(taCheckOrderInfo);
            }
            else
            {
                taCheckOrderInfo.CheckCode = checkID;
                taCheckOrderInfo.PayOrderType = ORDER_TYPE;
                taCheckOrderInfo.PayDelivery = "0.00";

                
                //taCheckOrderInfo.MenuAmount = lstTaOI.Sum(s => Convert.ToDecimal(string.IsNullOrEmpty(s.ItemTotalPrice) ? "0.00" : s.ItemTotalPrice)).ToString();
                taCheckOrderInfo.MenuAmount = treeListOrder.Nodes.Count > 0 ? treeListOrder.GetSummaryValue(treeListOrder.Columns[7]).ToString() : "0.00";
                //taCheckOrderInfo.PayDiscount = CommonDAL.GetTaDiscount(ORDER_TYPE, Convert.ToDecimal(taCheckOrderInfo.MenuAmount)).ToString();

                decimal dDiscount = CommonDAL.GetTaDiscount(ORDER_TYPE, Convert.ToDecimal(taCheckOrderInfo.MenuAmount));
                decimal dDiscountTotal = CommonDAL.GetAllDiscount(lstTaOI, dDiscount);
                taCheckOrderInfo.TotalAmount = (Convert.ToDecimal(taCheckOrderInfo.MenuAmount) - dDiscountTotal).ToString("0.00");

                new SystemData().GetTaDiscount();
                //var lstDiscount = CommonData.TaDiscount.Where(s => s.TaType.Equals(ORDER_TYPE));
                //if (lstDiscount.Any())
                //{
                //    string strPayPerDiscount = lstDiscount.FirstOrDefault().TaDiscount;
                //    taCheckOrderInfo.PayPerDiscount = strPayPerDiscount.Equals(@"0") ? "" : strPayPerDiscount + @"%";
                //    taCheckOrderInfo.PayDiscount = (Convert.ToDecimal(taCheckOrderInfo.TotalAmount) 
                //                                   * Convert.ToDecimal(lstDiscount.FirstOrDefault().TaDiscount) / 100).ToString("0.00");
                //}
                TaDiscountInfo tdi = CommonData.TaDiscount.FirstOrDefault(s => s.TaType.Equals(ORDER_TYPE));
                if (tdi != null)
                {
                    string strPayPerDiscount = tdi.TaDiscount;

                    if (Convert.ToDecimal(taCheckOrderInfo.MenuAmount) > Convert.ToDecimal(string.IsNullOrEmpty(tdi.TaDiscThre) ? "0.00" : tdi.TaDiscThre))
                    {
                        taCheckOrderInfo.PayPerDiscount = strPayPerDiscount.Equals(@"0") ? "" : strPayPerDiscount + @"%";
                        decimal dDiscount1 = CommonDAL.GetTaDiscount(ORDER_TYPE, Convert.ToDecimal(taCheckOrderInfo.MenuAmount));
                        decimal dDiscountTotal1 = CommonDAL.GetAllDiscount(lstTaOI, dDiscount1);
                        taCheckOrderInfo.PayDiscount = dDiscountTotal1.ToString("0.00");
                    }
                    else
                    {
                        taCheckOrderInfo.PayPerDiscount = "";
                        taCheckOrderInfo.PayDiscount = @"0.00";
                    }
                }
                else
                    taCheckOrderInfo.PayDiscount = @"0.00";

                if (Convert.ToDecimal(taCheckOrderInfo.PayDiscount) > 0)
                {
                    taCheckOrderInfo.TotalAmount = (Convert.ToDecimal(taCheckOrderInfo.TotalAmount) - Convert.ToDecimal(taCheckOrderInfo.PayDiscount)).ToString();
                }

                taCheckOrderInfo.Paid = "0.00";
                taCheckOrderInfo.IsPaid = "N";
                taCheckOrderInfo.CustomerID = string.IsNullOrEmpty(CustID.ToString()) ? "1" : CustID.ToString();
                taCheckOrderInfo.CustomerNote = "";
                taCheckOrderInfo.StaffID = usrID;
                taCheckOrderInfo.PayTime = DateTime.Now.ToString();

                //taCheckOrderInfo.PayPerDiscount = "";
                //taCheckOrderInfo.PayDiscount = @"0.00";
                if (ORDER_TYPE.Equals(PubComm.ORDER_TYPE_DELIVERY))
                {
                    decimal dSurcharge = CommonDAL.GetTaDeliverySurcharge(Convert.ToDecimal(taCheckOrderInfo.MenuAmount));
                    taCheckOrderInfo.PayPerSurcharge = "";
                    taCheckOrderInfo.PaySurcharge = dSurcharge.ToString("0.00");
                }
                else
                {
                    taCheckOrderInfo.PayPerSurcharge = "";
                    taCheckOrderInfo.PaySurcharge = @"0.00";
                }
                taCheckOrderInfo.PayType1 = "";
                taCheckOrderInfo.PayTypePay1 = @"0.00";
                taCheckOrderInfo.PayType2 = "";
                taCheckOrderInfo.PayTypePay2 = @"0.00";
                taCheckOrderInfo.PayType3 = "";
                taCheckOrderInfo.PayTypePay3 = @"0.00";
                taCheckOrderInfo.PayType4 = "";
                taCheckOrderInfo.PayTypePay4 = @"0.00";
                taCheckOrderInfo.PayType5 = "";
                taCheckOrderInfo.PayTypePay5 = @"0.00";

                //默认DriverID为1
                taCheckOrderInfo.DriverID = 1;

                taCheckOrderInfo.IsCancel = "N";

                taCheckOrderInfo.IsSave = isSave ? "Y" : "N";

                taCheckOrderInfo.BusDate = string.IsNullOrEmpty(strBusDate) ? CommonDAL.GetBusDate() : strBusDate;

                taCheckOrderInfo.DeliveryFee = (CustID >= 1 && ORDER_TYPE.Equals(PubComm.ORDER_TYPE_DELIVERY)) ? lblDeliveryFee.Text : @"0.00";

                saveTaCheckOrderInfo = taCheckOrderInfo;

                _control.AddEntity(taCheckOrderInfo);
            }
        }
        #endregion

        #region 设置打印相关信息

        private Hashtable SetPrtInfo(List<TaOrderItemInfo> lstOi)
        {
            Hashtable htDetail = new Hashtable();

            new SystemData().GetUsrBase();

            UsrBaseInfo ubi = CommonData.UsrBase.FirstOrDefault(s => s.ID == usrID);

            htDetail["Staff"] = ubi != null ? ubi.UsrName : "";

            //new SystemData().GetTaOrderItem();

            int iItemCount = 0;
            //foreach (TreeListNode treeListNode in treeListOrder.Nodes)
            //{

            //    if (treeListNode["ItemType"].ToString().Equals("1"))
            //    {
            //        iItemCount += Convert.ToInt32(treeListNode["ItemQty"].ToString());
            //    }
            //}
            iItemCount = treeListOrder.Nodes.Count > 0 ? Convert.ToInt32(treeListOrder.GetSummaryValue(treeListOrder.Columns[1])) : 0;
            htDetail["ItemQty"] = iItemCount.ToString();
            //htDetail["SubTotal"] = lstOi.Sum(s => Convert.ToDecimal(string.IsNullOrEmpty(s.ItemTotalPrice) ? "0.00" : s.ItemTotalPrice)).ToString();
            //htDetail["Total"] = lstOi.Sum(s => Convert.ToDecimal(string.IsNullOrEmpty(s.ItemTotalPrice) ? "0.00" : s.ItemTotalPrice)).ToString();
            htDetail["SubTotal"] = treeListOrder.Nodes.Count > 0 ? treeListOrder.GetSummaryValue(treeListOrder.Columns[7]).ToString() : "0.00";
            htDetail["Total"] = treeListOrder.Nodes.Count > 0 ? treeListOrder.GetSummaryValue(treeListOrder.Columns[7]).ToString() : "0.00";

            return htDetail;
        }
        #endregion

        #region 初始化表格
        private void InitGrid(List<TaOrderItemInfo> lst)
        {
            TreeListNode node = null;

            foreach (var taOrderItemInfo in lst)
            {
                if (taOrderItemInfo.ItemType == 1)
                    node = AddTreeListNode(taOrderItemInfo);
                else
                    AddTreeListChild(taOrderItemInfo, node);

            }
        }
        #endregion

        #endregion

        private void FrmTaMain_SizeChanged(object sender, EventArgs e)
        {
            //asfc.controlAutoSize(this, 1170, 700);
            asfc.controlAutoSize(this);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (treeListOrder.AllNodesCount > 0)
            {
                FrmCancelOrder frmCancelOrder = new FrmCancelOrder();
                frmCancelOrder.Location = panelControl3.PointToScreen(panelControl1.Location);
                frmCancelOrder.Size = panelControl3.Size;

                if (frmCancelOrder.ShowDialog() == DialogResult.OK)
                {
                    var lstChk =
                        CommonData.TaCheckOrder.Where(
                            s => s.CheckCode.Equals(checkID) && s.IsPaid.Equals("N") && s.BusDate.Equals(strBusDate));
                    if (lstChk.Any())
                    {
                        TaCheckOrderInfo taCheck = lstChk.FirstOrDefault();
                        taCheck.IsCancel = "Y";
                        _control.UpdateEntity(taCheck);
                        treeListOrder.Nodes.Clear();
                    }
                    else
                    {
                        treeListOrder.Nodes.Clear();
                        //checkID = CommonDAL.GetCheckCode();
                        //LogHelper.Info("#checkID:" + checkID + "#button1_Click");
                        //lblCheck.Text = checkID;
                        ORDER_TYPE = PubComm.ORDER_TYPE_SHOP;
                        btnType.Text = PubComm.ORDER_TYPE_SHOP;
                        ChangeOrderBtnColor(PubComm.ORDER_TYPE_SHOP);
                        SetCustInfo(true, true, new TaCustomerInfo());
                    }

                    isGetPhone = true;
                    this.Hide();
                }
            }
            else
            {
                isGetPhone = true;
                this.Hide();
            }
            //BriSDKLib.QNV_CloseDevice(BriSDKLib.ODT_ALL, 0);
            //this.Close();
        }

        #region 对Node子节点操作中英文显示
        private void SetChildNode(TreeListNode parentNode)
        {
            foreach (TreeListNode treeListNode in parentNode.Nodes)
            {
                //Console.WriteLine(treeListNode["ItemCode"]);

                if (iLangStatusId == PubComm.MENU_LANG_DEFAULT)
                {
                    //子菜品
                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_CHILD.ToString()))
                    {
                        if (CommonData.TaMenuItemOtherChoice.Any(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString())))
                        {
                            treeListNode["ItemDishName"] = CommonData.TaMenuItemOtherChoice.FirstOrDefault(s => s.ID.ToString().Equals(treeListNode["ItemCode"]))?.MiEngName;
                        }
                    }

                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_INGRED_MODE.ToString()))
                    {
                        if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(treeListNode["ItemCode"].ToString())))
                        {
                            TaMenuItemInfo taMi = CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]));
                            treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString().Replace(
                                                           taMi.MiOtherName,
                                                           taMi.MiEngName);
                        }
                    }

                    //改码
                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_APPEND.ToString()))
                    {
                        //if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(treeListNode["ItemCode"])))
                        //{
                        //    treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString().Split(' ')[0] + " " + CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiEngName;
                        //}
                        //else if (CommonData.TaMenuItemOtherChoice.Any(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString())))
                        //{
                        //    treeListNode["ItemDishName"] = CommonData.TaMenuItemOtherChoice.FirstOrDefault(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString()))?.MiEngName;
                        //}
                        //else if (CommonData.TaExtraMenu.Any(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString())))
                        if (CommonData.TaExtraMenu.Any(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString())))
                        {
                            TaExtraMenuInfo taEmi = CommonData.TaExtraMenu.FirstOrDefault(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString()));
                            treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString().Replace(taEmi.eMenuOtherName, taEmi.eMenuEngName);
                        }
                    }

                    //套餐子菜品
                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_SUB_CHILD.ToString()))
                    {
                        treeListNode["ItemDishName"] = CommonData.TaMenuItemSubMenu.FirstOrDefault(s => s.ID.ToString().Equals(treeListNode["MenuItemID"].ToString()))?.SmEngName;
                    }
                }
                else
                {
                    //子菜品
                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_CHILD.ToString()))
                    {
                        if (CommonData.TaMenuItemOtherChoice.Any(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString())))
                        {
                            treeListNode["ItemDishName"] = CommonData.TaMenuItemOtherChoice.FirstOrDefault(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString()))?.MiOtherName;
                        }
                    }

                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_INGRED_MODE.ToString()))
                    {
                        if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(treeListNode["ItemCode"].ToString())))
                        {
                            TaMenuItemInfo taMi = CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]));
                            treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString().Replace(
                                                           taMi.MiEngName,
                                                           taMi.MiOtherName);
                        }
                    }

                    //改码
                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_APPEND.ToString()))
                    {
                        //if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(treeListNode["ItemCode"])))
                        //{
                        //    treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString().Split(' ')[0] + " " + CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiOtherName;
                        //}
                        //else if (CommonData.TaMenuItemOtherChoice.Any(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString())))
                        //{
                        //    treeListNode["ItemDishName"] = CommonData.TaMenuItemOtherChoice.FirstOrDefault(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString()))?.MiOtherName;
                        //}
                        //else if (CommonData.TaExtraMenu.Any(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString())))
                        if (CommonData.TaExtraMenu.Any(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString())))
                        {
                            TaExtraMenuInfo taEmi = CommonData.TaExtraMenu.FirstOrDefault(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString()));
                            treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString().Replace(taEmi.eMenuEngName, taEmi.eMenuOtherName);
                        }
                    }

                    //套餐子菜品
                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_SUB_CHILD.ToString()))
                    {
                        treeListNode["ItemDishName"] = CommonData.TaMenuItemSubMenu.FirstOrDefault(s => s.ID.ToString().Equals(treeListNode["MenuItemID"].ToString()))?.SmOtherName;
                    }
                }
            }
        }
        #endregion

        public void SetListNode(TaMenuItemInfo taMenuItemInfo, int iQ, bool isKeypad)
        {
            //套餐
            if (taMenuItemInfo.MiRmk.Contains("Set Meal"))
            {
                SetSameMenuItemMerge(taMenuItemInfo, iQ, true);
            }
            else//非套餐
            {
                SetSameMenuItemMerge(taMenuItemInfo, iQ, false);
            }

            if (isKeypad)
                if (treeListOrder.Nodes.Count > 0) treeListOrder.SetFocusedNode(treeListOrder.Nodes[treeListOrder.Nodes.Count - 1]);
        }

        private void btnSearchMeal_Click(object sender, EventArgs e)
        {
            string sKeyWord = "";

            FrmTaSearchFoodItem frmTaSearchFoodItem = new FrmTaSearchFoodItem();

            if (frmTaSearchFoodItem.ShowDialog() == DialogResult.OK)
            {
                sKeyWord = frmTaSearchFoodItem.sId;

                if (!string.IsNullOrEmpty(sKeyWord))
                {
                    //if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(sKeyWord)))
                    //{
                    //    string sWord = CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(sKeyWord)).MiEngName;
                    //    TaMenuItemInfo taMenuItemInfo = GetMenuItemInfo(sWord, iMenuCateId, iMenuSetId);

                    //    SetListNode(taMenuItemInfo, 1);
                    //}
                    bool status = CommonDAL.IsShowMenuItemCode();

                    int i = 0;
                    foreach (var taMenuItemInfo in CommonDAL.GetListQueryPageMenuItemByKeyWord(iPageNum, sKeyWord))
                    {
                        btnMenuItem[i].Text = status
                            ? "(" + taMenuItemInfo.MiDishCode + ")" +
                              (iLangStatusId == PubComm.MENU_LANG_DEFAULT
                                  ? taMenuItemInfo.MiEngName
                                  : taMenuItemInfo.MiOtherName)
                            : (iLangStatusId == PubComm.MENU_LANG_DEFAULT
                                ? taMenuItemInfo.MiEngName
                                : taMenuItemInfo.MiOtherName);
                        i++;
                    }
                    
                    for (int j = i; j < 16; j++)
                    {
                        btnMenuItem[j].Text = "";
                    }

                    //如果没有找到菜品，则返回所有菜品
                    if (i == 0)
                    {
                        SetMenuItem(iCatePageNum, iMenuCateId, iMenuSetId);
                    }
                }
            }
        }

        private void btnKeypad_Click(object sender, EventArgs e)
        {
            if (frmTaKeyPad == null)
            {
                frmTaKeyPad = new FrmTaKeyPad(this);
                
            }
            else
            {
                if (frmTaKeyPad.IsDisposed)
                {
                    frmTaKeyPad = new FrmTaKeyPad(this);
                    frmTaKeyPad.Show();
                }
                else
                {
                    frmTaKeyPad.Activate();
                }
            }

            frmTaKeyPad.Location = panelControl3.PointToScreen(panelControl1.Location);
            frmTaKeyPad.Size = panelControl3.Size;

            frmTaKeyPad.Show();
        }

        private void treeListOrder_DoubleClick(object sender, EventArgs e)
        {
            if (treeListOrder.FocusedNode != null)
            {
                if (treeListOrder.FocusedNode["ItemType"].ToString().Equals("1"))
                {
                    decimal dPrice = 0.0m;
                    bool isUpdate = false;
                    if (Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"].ToString()) > 1)
                    {
                        dPrice = Convert.ToDecimal(treeListOrder.FocusedNode["ItemTotalPrice"].ToString()) /
                                 Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"].ToString());
                        isUpdate = true;
                    }
                    else
                        dPrice = Convert.ToDecimal(treeListOrder.FocusedNode["ItemTotalPrice"].ToString());

                    FrmTaChangePrice frmTaChangePrice = null;
                    //if (iLangStatusId == PubComm.MENU_LANG_DEFAULT)
                    TaMenuItemInfo taMi = CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListOrder.FocusedNode["ItemCode"].ToString()));

                    string sEName = treeListOrder.FocusedNode["ItemDishName"].ToString();
                    string sOName = treeListOrder.FocusedNode["ItemDishOtherName"].ToString();
                    if (taMi != null)
                    {
                        sEName = taMi.MiEngName;
                        sOName = taMi.MiOtherName;
                    }

                    frmTaChangePrice = new FrmTaChangePrice(treeListOrder.FocusedNode["ItemCode"].ToString(),
                                                                            sEName,
                                                                            sOName,
                                                                            dPrice.ToString(),
                                                                            iLangStatusId);
                    //else
                    //    frmTaChangePrice = new FrmTaChangePrice(treeListOrder.FocusedNode["ItemCode"].ToString(),
                    //                                                         treeListOrder.FocusedNode["ItemDishOtherName"].ToString(),
                    //                                                         treeListOrder.FocusedNode["ItemDishName"].ToString(),
                    //                                                         dPrice.ToString(),
                    //                                                         iLangStatusId);

                    string sNewPrice = dPrice.ToString();

                    List<TaChangeMenuAttrInfo> lstTaChangeMenuAttrInfos = new List<TaChangeMenuAttrInfo>();

                    if (frmTaChangePrice.ShowDialog() == DialogResult.OK)
                    {
                        sNewPrice = frmTaChangePrice.NewPrice;
                        lstTaChangeMenuAttrInfos = frmTaChangePrice.MenuAttrEng;

                        if (!string.IsNullOrEmpty(sNewPrice))
                        {
                            if (isUpdate)
                            {
                                treeListOrder.FocusedNode["ItemTotalPrice"] =
                                    Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"].ToString())*
                                    Convert.ToDecimal(sNewPrice);

                                treeListOrder.FocusedNode["ItemPrice"] = Convert.ToDecimal(sNewPrice);
                            }
                            else
                            {
                                treeListOrder.FocusedNode["ItemPrice"] = Convert.ToDecimal(sNewPrice);
                                treeListOrder.FocusedNode["ItemTotalPrice"] = Convert.ToDecimal(sNewPrice);
                            }
                        }

                        foreach (var taChangeMenuAttrInfo in lstTaChangeMenuAttrInfos)
                        {
                            if (!dChangePrice.ContainsKey(taChangeMenuAttrInfo.MenuAttrEnglishName))
                            {
                                if (string.IsNullOrEmpty(taChangeMenuAttrInfo.MenuAttrOtherName))
                                {
                                    taChangeMenuAttrInfo.MenuAttrOtherName = taChangeMenuAttrInfo.MenuAttrEnglishName;
                                }

                                dChangePrice.Add(taChangeMenuAttrInfo.MenuAttrEnglishName, taChangeMenuAttrInfo.MenuAttrOtherName);
                            }

                            bool isSmalOrLarge = taChangeMenuAttrInfo.MenuAttrEnglishName.Equals(@"(" + PubComm.MENU_ITEM_LARGE_ENG + ")") ||
                                                 taChangeMenuAttrInfo.MenuAttrEnglishName.Equals(@"(" + PubComm.MENU_ITEM_SMALL_ENG + ")");
                            if (iLangStatusId == PubComm.MENU_LANG_DEFAULT)
                            {
                                if (isSmalOrLarge)
                                {
                                    if (treeListOrder.FocusedNode["ItemDishName"].ToString().Contains(@"(" + PubComm.MENU_ITEM_LARGE_ENG + ")")
                                        || treeListOrder.FocusedNode["ItemDishName"].ToString().Contains(@"(" + PubComm.MENU_ITEM_SMALL_ENG + ")"))
                                    {
                                        treeListOrder.FocusedNode["ItemDishName"] = treeListOrder.FocusedNode["ItemDishName"].ToString()
                                            .Replace(@"(" + PubComm.MENU_ITEM_LARGE_ENG + ")", taChangeMenuAttrInfo.MenuAttrEnglishName)
                                            .Replace(@"(" + PubComm.MENU_ITEM_SMALL_ENG + ")", taChangeMenuAttrInfo.MenuAttrEnglishName);
                                    }
                                    else
                                    {
                                        treeListOrder.FocusedNode["ItemDishName"] += taChangeMenuAttrInfo.MenuAttrEnglishName;
                                    }

                                }
                                else
                                {
                                    treeListOrder.FocusedNode["ItemDishName"] += taChangeMenuAttrInfo.MenuAttrEnglishName;
                                }
                            }
                            else
                            {
                                if (isSmalOrLarge)
                                {
                                    if (treeListOrder.FocusedNode["ItemDishName"].ToString().Contains(@"(" + PubComm.MENU_ITEM_LARGE_OTHER + ")")
                                        || treeListOrder.FocusedNode["ItemDishName"].ToString().Contains(@"(" + PubComm.MENU_ITEM_SMALL_OTHER + ")"))
                                    {
                                        treeListOrder.FocusedNode["ItemDishName"] = treeListOrder.FocusedNode["ItemDishName"].ToString()
                                            .Replace(@"(" + PubComm.MENU_ITEM_LARGE_OTHER + ")", taChangeMenuAttrInfo.MenuAttrOtherName)
                                            .Replace(@"(" + PubComm.MENU_ITEM_SMALL_OTHER + ")", taChangeMenuAttrInfo.MenuAttrOtherName);
                                    }
                                    else
                                    {
                                        treeListOrder.FocusedNode["ItemDishName"] += taChangeMenuAttrInfo.MenuAttrOtherName;
                                    }
                                }
                                else
                                {
                                    treeListOrder.FocusedNode["ItemDishName"] += taChangeMenuAttrInfo.MenuAttrOtherName;
                                }
                            }

                            treeListOrder.FocusedNode["ItemDishOtherName"] += taChangeMenuAttrInfo.MenuAttrOtherName;
                        }
                    }
                }
            }
        }

        private void btnCustInfo_Click(object sender, EventArgs e)
        {
            FrmTaCustomerInfo frmTaCustomerInfo = new FrmTaCustomerInfo();
            frmTaCustomerInfo.ShowDialog();
        }

        private void btnCid_Click(object sender, EventArgs e)
        {
            FrmCaller frmCaller = new FrmCaller(usrID, strBusDate, true);

            frmCaller.Location = pcMain.Location;
            frmCaller.Size = pcMain.Size;

            if (frmCaller.ShowDialog() == DialogResult.OK)
            {
                //string sCallNum = frmCaller.CallNum;
                TaCustomerInfo taCustomerInfo = new TaCustomerInfo();

                ORDER_TYPE = string.IsNullOrEmpty(frmCaller.OrderType) ? PubComm.ORDER_TYPE_SHOP : frmCaller.OrderType;
                taCustomerInfo = frmCaller.TaCustomer;
                string strReadTime = frmCaller.ReadyTime;

                if (taCustomerInfo == null)
                {
                    SetCustInfo(true, true, null);
                }
                else
                {
                    SetCustInfo(false, false, taCustomerInfo);
                }

                ChangeOrderBtnColor(ORDER_TYPE);
                isGetPhone = false;
            }
            else
            {
                TaCustomerInfo taCustomerInfo = new TaCustomerInfo();

                //ORDER_TYPE = string.IsNullOrEmpty(frmCaller.OrderType) ? PubComm.ORDER_TYPE_SHOP : frmCaller.OrderType;
                taCustomerInfo = frmCaller.TaCustomer;
                string strReadTime = frmCaller.ReadyTime;

                if (taCustomerInfo == null)
                {
                    ORDER_TYPE = PubComm.ORDER_TYPE_SHOP;
                    SetCustInfo(true, true, null);
                }
                else
                {
                    ORDER_TYPE = PubComm.ORDER_TYPE_DELIVERY;
                    SetCustInfo(false, false, taCustomerInfo);
                }

                ChangeOrderBtnColor(ORDER_TYPE);
                isGetPhone = false;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            treeListOrder_DoubleClick(sender, e);
        }

        private void GetCustInfo(int cID)
        {
            if (cID <= 0)
            {
                SetCustInfo(true, true, null);
            }
            else
            {
                new SystemData().GetTaCustomer();

                var lstCust = CommonData.TaCustomer.Where(s => s.ID == cID);

                if (lstCust.Any())
                {
                    TaCustomerInfo taCustomerInfo = lstCust.FirstOrDefault();

                    SetCustInfo(false, false, taCustomerInfo);
                }
                else
                {
                    SetCustInfo(true, true, null);
                }
            }
        }

        private void panelMember_Click(object sender, EventArgs e)
        {
            //if (CustID <= 0)
            //{
            
            string sFoot = treeListOrder.Nodes.Count > 0 ? treeListOrder.GetSummaryValue(treeListOrder.Columns[7]).ToString() : "0.00";
            FrmTaCustomerInfo frmTaCustomerInfo = new FrmTaCustomerInfo(CustID, sFoot);

            if (frmTaCustomerInfo.ShowDialog() == DialogResult.OK)
            {
                TaCustomerInfo taCustomerInfo = new TaCustomerInfo();
                taCustomerInfo = frmTaCustomerInfo.CustomerInfo;

                if (taCustomerInfo == null)
                {
                    SetCustInfo(true, true, null);
                }
                else
                {
                    SetCustInfo(false, false, taCustomerInfo);

                    //存在客户信息时，变更订单类型
                    ORDER_TYPE = PubComm.ORDER_TYPE_DELIVERY;
                    ChangeOrderBtnColor(ORDER_TYPE);
                }
                    
            }
            //}
        }

        #region 返回Other Choices的AutoAppend
        private void GetOtherChoices(int miId, out string miEngName, out string miOtherName, out decimal miPrice)
        {
            miEngName = "";
            miOtherName = "";
            miPrice = 0.00m;

            new SystemData().GetTaMenuItemOtherChoice();

            var lstOther = CommonData.TaMenuItemOtherChoice.Where(s => s.MiID == miId && s.IsEnableChoice.Equals("Y"));

            foreach (var taMenuItemOtherChoiceInfo in lstOther)
            {
                miEngName += taMenuItemOtherChoiceInfo.MiEngName;
                miOtherName += taMenuItemOtherChoiceInfo.MiOtherName;
                miPrice += Convert.ToDecimal(taMenuItemOtherChoiceInfo.MiPrice);
            }
        }
        #endregion

        #region 获得子目录,并修改对应子节点的Qty及ItemTotalPrice
        /// <summary>
        /// 获得子目录,并修改对应子节点的Qty及ItemTotalPrice
        /// </summary>
        /// <param name="parentNode">父节点</param>
        /// <param name="dQty">父节点数量</param>
        private void GetChildNodes(TreeListNode parentNode, int dQty)
        {
            if (parentNode.Nodes.Count > 0)
            {
                foreach (TreeListNode node in parentNode.Nodes)
                {
                    if (node.Nodes.Count == 0)
                    {
                        //Console.WriteLine(node.GetValue("ItemQty"));
                        if (!string.IsNullOrEmpty(node.GetValue("ItemPrice").ToString()))
                        {
                            node.SetValue("ItemQty", dQty.ToString("0"));
                            node.SetValue("ItemTotalPrice", (dQty * Convert.ToDecimal(node.GetValue("ItemPrice"))).ToString("0.00"));
                        }
                    }
                    if (node.Nodes.Count > 0)
                    {
                        GetChildNodes(node,dQty);
                    }
                }
            }
        }
        #endregion

        #region 获得Sub Menu

        private void GetMenuItemSubMenu(int miId, string miQty, string miCheckCode, string itemId, TreeListNode node)
        {
            new SystemData().GetTaMenuItemSubMenu();

            var lstResult = CommonData.TaMenuItemSubMenu.Where(s => s.SmMiID == miId);

            List<TaOrderItemInfo> lstMi = new List<TaOrderItemInfo>();

            if (lstResult.Any(s => s.IsAutoExpand.Equals("Y")))
            {
                foreach (var taMenuItemSubMenuInfo in lstResult)
                {
                    TaOrderItemInfo taOrderItemInfo = new TaOrderItemInfo();

                    taOrderItemInfo.ItemID = "0";
                    taOrderItemInfo.ItemCode = "";
                    taOrderItemInfo.ItemDishName = taMenuItemSubMenuInfo.SmEngName;
                    taOrderItemInfo.ItemDishOtherName = taMenuItemSubMenuInfo.SmOtherName;
                    taOrderItemInfo.ItemQty = "";
                    taOrderItemInfo.ItemPrice = "";
                    taOrderItemInfo.ItemTotalPrice = "";
                    taOrderItemInfo.CheckCode = miCheckCode;
                    taOrderItemInfo.ItemType = PubComm.MENU_ITEM_SUB_CHILD;
                    taOrderItemInfo.ItemParent = itemId;
                    taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                    taOrderItemInfo.OrderStaff = usrID;
                    taOrderItemInfo.BusDate = strBusDate;
                    taOrderItemInfo.MenuItemID = taMenuItemSubMenuInfo.ID;
                    taOrderItemInfo.IsDiscount = "N";
                    lstMi.Add(taOrderItemInfo);
                }

                if (lstMi.Any())
                {
                    foreach (var orderItemInfo in lstMi) { AddTreeListChild(orderItemInfo, node); }
                }
            }
        }
        #endregion

        #region 获得OrderType并变更按钮颜色
        /// <summary>
        /// 订单按钮颜色变更
        /// </summary>
        /// <param name="sOrderType">订单类型</param>
        private void ChangeOrderBtnColor(string sOrderType)
        {
            if (sOrderType.Equals(PubComm.ORDER_TYPE_DELIVERY))
            {
                btnType.Appearance.BackColor = Color.ForestGreen;
                btnType.Text = PubComm.ORDER_TYPE_DELIVERY;
            }
            else if (sOrderType.Equals(PubComm.ORDER_TYPE_SHOP))
            {
                btnType.Appearance.BackColor = Color.HotPink;
                btnType.Text = PubComm.ORDER_TYPE_SHOP;
            }
            else if (sOrderType.Equals(PubComm.ORDER_TYPE_COLLECTION))
            {
                btnType.Appearance.BackColor = Color.Turquoise;
                btnType.Text = PubComm.ORDER_TYPE_COLLECTION;
            }
            else
            {
                btnType.Appearance.BackColor = Color.HotPink;
                btnType.Text = PubComm.ORDER_TYPE_SHOP;
            }
        }
        #endregion

        #region 订单类型变换按钮事件
        /// <summary>
        /// 订单类型变换按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnType_Click(object sender, EventArgs e)
        {
            if (btnType.Text.Equals(PubComm.ORDER_TYPE_SHOP))
            {
                ORDER_TYPE = PubComm.ORDER_TYPE_DELIVERY;
                btnType.Appearance.BackColor = Color.ForestGreen;
                btnType.Text = PubComm.ORDER_TYPE_DELIVERY;
            }
            else if (btnType.Text.Equals(PubComm.ORDER_TYPE_DELIVERY))
            {
                ORDER_TYPE = PubComm.ORDER_TYPE_COLLECTION;
                btnType.Appearance.BackColor = Color.Turquoise;
                btnType.Text = PubComm.ORDER_TYPE_COLLECTION;
            }
            else if (btnType.Text.Equals(PubComm.ORDER_TYPE_COLLECTION))
            {
                ORDER_TYPE = PubComm.ORDER_TYPE_SHOP;
                btnType.Appearance.BackColor = Color.HotPink;
                btnType.Text = PubComm.ORDER_TYPE_SHOP;
            }
        }
        #endregion

        #region 替换菜品名称中的部分附加值
        /// <summary>
        /// 替换菜品名称中的部分附加值
        /// </summary>
        /// <param name="itemname">原菜品名</param>
        /// <param name="iLang">语言标识</param>
        /// <returns></returns>
        private string ModifItemOtherName(string itemname, int iLang)
        {
            string modItemName = itemname;

            foreach (KeyValuePair<string, string> keyValuePair in dChangePrice)
            {
                modItemName = iLang == PubComm.MENU_LANG_DEFAULT
                                ? modItemName.Replace(keyValuePair.Value, keyValuePair.Key)
                                : modItemName.Replace(keyValuePair.Key, keyValuePair.Value);
            }

            foreach (KeyValuePair<string, string> keyValuePair in dOtherChoice)
            {
                modItemName = iLang == PubComm.MENU_LANG_DEFAULT
                                ? modItemName.Replace(keyValuePair.Value, keyValuePair.Key)
                                : modItemName.Replace(keyValuePair.Key, keyValuePair.Value);
            }

            return modItemName;
        }
        #endregion

        #region 根据当前语言进行自动菜品名称选择
        /// <summary>
        /// 根据当前语言进行自动菜品名称选择
        /// </summary>
        public void SetLang()
        {
            //英文
            if (iLangStatusId == PubComm.MENU_LANG_DEFAULT)
            {
                foreach (TreeListNode treeListNode in treeListOrder.Nodes)
                {
                    //主菜品
                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_MAIN.ToString()))
                    {
                        if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(treeListNode["ItemCode"])))
                        {
                            treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString()
                                                           .Replace(CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiOtherName,
                                                                    CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiEngName);
                        }

                        treeListNode["ItemDishName"] = ModifItemOtherName(treeListNode["ItemDishName"].ToString(), iLangStatusId);

                        if (treeListNode.HasChildren)
                        {
                            SetChildNode(treeListNode);
                        }
                    }
                }
            }
            else
            {
                foreach (TreeListNode treeListNode in treeListOrder.Nodes)
                {
                    //主菜品
                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_MAIN.ToString()))
                    {
                        if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(treeListNode["ItemCode"])))
                        {
                            treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString()
                                .Replace(CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiEngName,
                                    CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiOtherName);
                        }

                        treeListNode["ItemDishName"] = ModifItemOtherName(treeListNode["ItemDishName"].ToString(), iLangStatusId);

                        if (treeListNode.HasChildren)
                        {
                            SetChildNode(treeListNode);
                        }
                    }
                }
            }
        }
        #endregion

        #region 司机点击事件
        private void btnDriver_Click(object sender, EventArgs e)
        {
            var btn = (SimpleButton)sender;

            for (int i = 0; i < CommonData.TaDriver.Count(s => s.DriverWorkDay.Contains(DateTime.Now.DayOfWeek.ToString())); i++)
            {
                btnDriver[i].Appearance.BackColor = btnDriver[i].Text.Equals(btn.Text) ? Color.LightGreen : Color.NavajoWhite;
            }
        }
        #endregion

        #region 数字按钮输入事件
        private void btn_Click(object sender, EventArgs e)
        {
            var btn = (SimpleButton)sender;

            if (btn.Name.Equals("btnClear"))
            {
                objTxt.Text = "0.00";

                //if (objTxt.Name.Equals("txtPercentDiscount"))
                //{
                //    txtPercentDiscount.Text = "";
                //    txtDiscount.Text = @"0.00";
                //}

                //if (objTxt.Name.Equals("txtPercentSurcharge"))
                //{
                //    txtPercentSurcharge.Text = "";
                //    txtSurcharge.Text = @"0.00";
                //}
            }
            else if (btn.Name.Equals("btnDel"))
            {
                objTxt.Text = objTxt.Text.Length > 0 ? objTxt.Text.Substring(0, objTxt.Text.Length - 1) : "";
            }
            else
            {
                if (objTxt.Text.Equals("0.00") || objTxt.Text.Equals("0.0") || objTxt.Text.Equals("0") || string.IsNullOrEmpty(objTxt.Text))
                    objTxt.Text = btn.Text;
                else
                    objTxt.Text += btn.Text;
            }
        }
        #endregion

        #region 根据文本框返回具体数字
        /// <summary>
        /// 根据文本框返回具体数字
        /// </summary>
        /// <param name="txt">文本框</param>
        /// <returns></returns>
        private decimal TxtToDecimal(TextEdit txt)
        {
            try
            {
                return Convert.ToDecimal(string.IsNullOrEmpty(txt.Text) ? @"0.00" : txt.Text);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
                return 0.0m;
            }
        }
        #endregion

        private string GetPayType()
        {
            new SystemData().GetTaCheckOrder();
            var lstChk = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate));

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

        private void SetCustClear()
        {
            SetCustInfo(true, false, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CallerPhone = "07533375888";

            if (!string.IsNullOrEmpty(CallerPhone) && isGetPhone) return;

            if (!string.IsNullOrEmpty(CallerPhone.Trim()))
            {
                isGetPhone = true;

                #region 保存来电信息
                TaComePhoneInfo taComePhoneInfo = new TaComePhoneInfo();
                taComePhoneInfo.CustPhoneNo = CallerPhone;
                taComePhoneInfo.ComePhoneTime = DateTime.Now.ToString();
                taComePhoneInfo.CustName = @"";
                taComePhoneInfo.CustID = "0";
                taComePhoneInfo.BusDate = strBusDate;

                _control.AddEntity(taComePhoneInfo);
                #endregion

                IAsyncResult result = null;
                DelegateOrder handler = null;

                if (treeListOrder.Nodes.Count > 0)
                {
                    #region 保存TreeList
                    //new SystemData().GetTaOrderItem();
                    //var lstDelOi = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID) && s.BusDate.Equals(strBusDate));

                    //foreach (var taOrderItemInfo in lstDelOi)
                    //{
                    //    _control.DeleteEntity(taOrderItemInfo);
                    //}
                    AddFreeOrAutomatic();

                    List<TaOrderItemInfo> lstTaOI = new List<TaOrderItemInfo>();

                    lstTaOI = TreeListToOrderItem(isNew);

                    //foreach (var taOrderItemInfo in lstTaOI)
                    //{
                    //    new SystemData().GetTaOrderItem();

                    //    if (CommonData.TaOrderItem.Any(s => s.ID == taOrderItemInfo.ID))
                    //    {
                    //        _control.UpdateEntity(taOrderItemInfo);
                    //    }
                    //    else
                    //    {
                    //        _control.AddEntity(taOrderItemInfo);
                    //    }
                    //}
                    handler = DelegateOrderOpt.SaveOrder;
                    result = handler.BeginInvoke(checkID, strBusDate, lstTaOI, null, null);
                    #endregion

                    #region 保存账单
                    SaveCheckOrder(lstTaOI, false);
                    #endregion
                }

                LogHelper.Info("CallerPhone:" + CallerPhone);
                //新客户
                FrmCaller frmCaller = new FrmCaller(CallerPhone, strBusDate, ORDER_TYPE, lblReadyTime.Visible ? lblReadyTime.Text : "");
                frmCaller.Location = pcMain.Location;
                frmCaller.Size = pcMain.Size;

                if (frmCaller.ShowDialog() == DialogResult.OK)
                {
                    TaCustomerInfo taCustomerInfo = new TaCustomerInfo();

                    ORDER_TYPE = frmCaller.OrderType;
                    taCustomerInfo = frmCaller.TaCustomer;
                    string strReadTime = frmCaller.ReadyTime;

                    if (taCustomerInfo == null)
                    {
                        SetCustInfo(true, true, null);
                    }
                    else
                    {
                        treeListOrder.Nodes.Clear();
                        checkID = CommonDAL.GetCheckCode();
                        LogHelper.Info("#checkID:" + checkID + "#button1_Click");
                        lblCheck.Text = checkID;
                        ChangeOrderBtnColor(ORDER_TYPE);
                        SetCustInfo(false, false, taCustomerInfo);
                    }
                    isGetPhone = false;
                }

                if (treeListOrder.Nodes.Count > 0) handler.EndInvoke(result);
            }
        }

        private void SetCustInfo(bool bStatus, bool bClear, TaCustomerInfo tci)
        {
            if (bStatus)
            {
                CustID = 0;

                lblName.Text = "";
                lblPhone.Text = "";
                lblAddress.Text = "";
                lblPostcode.Text = "";
                lblDistance.Text = "";
                lblDeliveryFee.Text = "";
                lblReadyTime.Text = "";

                if (bClear)
                {
                    lblName.Visible = false;
                    lblPhone.Visible = false;
                    lblAddress.Visible = false;
                    lblPostcode.Visible = false;
                    lblDistance.Visible = false;
                    lblDeliveryFee.Visible = false;
                    lblReadyTime.Visible = false;
                }

                lblCustName.Visible = false;
                lblCustPhone.Visible = false;
                lblCustAddress.Visible = false;
                lblCustPostcode.Visible = false;
                lblCustDistance.Visible = false;
                lblCustDeliveryFee.Visible = false;
                lblCustReadyTime.Visible = false;
            }
            else
            {
                CustID = tci.ID;

                lblName.Visible = true;
                lblPhone.Visible = true;
                lblAddress.Visible = true;
                lblPostcode.Visible = true;
                lblDistance.Visible = true;
                lblDeliveryFee.Visible = true;
                lblReadyTime.Visible = true;

                lblName.Text = tci.cusName;
                lblPhone.Text = tci.cusPhone;
                lblAddress.Text = tci.cusHouseNo + @" " + tci.cusAddr;
                lblPostcode.Text = tci.cusPostcode;
                lblDistance.Text = tci.cusDistance;
                lblDeliveryFee.Text = tci.cusDelCharge;
                lblReadyTime.Text = tci.cusReadyTime;

                lblCustName.Visible = true;
                lblCustPhone.Visible = true;
                lblCustAddress.Visible = true;
                lblCustPostcode.Visible = true;
                lblCustDistance.Visible = true;
                lblCustDeliveryFee.Visible = true;
                lblCustReadyTime.Visible = true;
            }
        }

        private void SetBtnLang(int iLanguage)
        {
            if (iLanguage == PubComm.MENU_LANG_DEFAULT)
            {
                btnHome.Text = @"HOME";
                btnKeypad.Text = @"Key";
                btnChange.Text = @"CHGE";
                btnPay.Text = @"Accept";
                btnMenu.Text = @"Menu";
                btnCid.Text = @"CID";
                btnLanguage.Text = @"LANGUAGE";
                btnPendOrder.Text = @"Pending Orders";
                btnSaveOrder.Text = @"Save Order";
                btnCancel.Text = @"CANCEL ORDER";
                btnEatIn.Text = @"Eat In";
            }
            else
            {
                btnHome.Text = @"主界面";
                btnKeypad.Text = @"快捷按钮";
                btnChange.Text = @"改码";
                btnPay.Text = @"付款";
                btnMenu.Text = @"菜谱";
                btnCid.Text = @"来电";
                btnLanguage.Text = @"语言";
                btnPendOrder.Text = @"挂单";
                btnSaveOrder.Text = @"保存";
                btnCancel.Text = @"取消订单";
                btnEatIn.Text = @"堂食";
            }
        }

        private void SetSameMenuItemMerge(TaMenuItemInfo taMenuItemInfo, int iQ, bool isSubMenu)
        {
            //判断是否存在相同菜品
            //若存在，则合并，并对数量+1
            TreeListNode TlNSameMi = treeListOrder.Nodes.FirstOrDefault(s => s["ItemCode"].Equals(taMenuItemInfo.MiDishCode)
                                                         && s["ItemType"].ToString().Equals("1")
                                                         && !s["ItemPrice"].ToString().Equals("0.00")
                                                         && s["ItemDishName"].Equals(iLangStatusId == PubComm.MENU_LANG_DEFAULT
                                                                                     ? taMenuItemInfo.MiEngName
                                                                                     : taMenuItemInfo.MiOtherName));


            if (TlNSameMi != null && !TlNSameMi.HasChildren && !taMenuItemInfo.MiRegularPrice.Equals("0.00"))
            {
                foreach (TreeListNode treeListNode in treeListOrder.Nodes.Where(s => s["ItemCode"].Equals(taMenuItemInfo.MiDishCode)
                                                                                && s["ItemType"].ToString().Equals("1")
                                                                                && s["ItemDishName"].Equals(iLangStatusId == PubComm.MENU_LANG_DEFAULT ? taMenuItemInfo.MiEngName : taMenuItemInfo.MiOtherName)))
                {
                    //if (treeListNode["ItemCode"].ToString().Equals(taMenuItemInfo.MiDishCode))
                    //btnAdd_Click(sender, e);
                    treeListOrder.BeginUpdate();
                    decimal dQty = Convert.ToDecimal(treeListNode["ItemQty"]);
                    decimal dPrice = Convert.ToDecimal(treeListNode["ItemTotalPrice"]);

                    if (dQty > 1)
                    {
                        treeListNode["ItemQty"] = (Convert.ToInt32(dQty + iQ)).ToString();
                        treeListNode["ItemTotalPrice"] = ((dPrice / dQty) * (dQty + iQ)).ToString("0.00");

                        GetChildNodes(treeListOrder.FocusedNode, Convert.ToInt32(Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"].ToString())));
                    }
                    else
                    {
                        treeListNode["ItemQty"] = (Convert.ToInt32(dQty + iQ)).ToString();
                        treeListNode["ItemTotalPrice"] = (dPrice * (dQty + iQ)).ToString();

                        GetChildNodes(treeListOrder.FocusedNode, Convert.ToInt32(Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"].ToString())));
                    }
                    treeListOrder.EndUpdate();

                    treeListOrder.ExpandAll();
                }
            }
            else
            {
                int iQty = iQ;
                TaOrderItemInfo taOrderItemInfo = new TaOrderItemInfo();
                taOrderItemInfo.ItemID = Guid.NewGuid().ToString();
                taOrderItemInfo.ItemCode = taMenuItemInfo.MiDishCode;
                //taOrderItemInfo.ItemDishName = taMenuItemInfo.MiEngName;
                //taOrderItemInfo.ItemDishOtherName = taMenuItemInfo.MiOtherName;
                taOrderItemInfo.ItemPrice = (Convert.ToDecimal(taMenuItemInfo.MiRegularPrice)).ToString("0.00");
                taOrderItemInfo.ItemQty = iQty.ToString();
                taOrderItemInfo.ItemTotalPrice = (iQty * Convert.ToDecimal(taOrderItemInfo.ItemPrice)).ToString("0.00");
                taOrderItemInfo.CheckCode = checkID;
                taOrderItemInfo.ItemType = PubComm.MENU_ITEM_MAIN;

                taOrderItemInfo.ItemDishName = taMenuItemInfo.MiEngName;
                taOrderItemInfo.ItemDishOtherName = taMenuItemInfo.MiOtherName;

                taOrderItemInfo.ItemParent = "0";
                //taOrderItemInfo.ItemParent = Convert.ToInt32(taMenuItemInfo.ID);
                taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                taOrderItemInfo.OrderStaff = usrID;
                taOrderItemInfo.BusDate = strBusDate;
                taOrderItemInfo.MenuItemID = taMenuItemInfo.ID;

                taOrderItemInfo.IsDiscount = taMenuItemInfo.MiRmk.Contains("Discountable") ? "N" : "Y";

                TreeListNode node = AddTreeListNode(taOrderItemInfo);

                //Sub Menu的子菜品
                if (isSubMenu) GetMenuItemSubMenu(taMenuItemInfo.ID, iQty.ToString(), checkID, taOrderItemInfo.ItemID, node);

                //Second/Third Choices
                SetAllOtherChoice(taMenuItemInfo.ID, iQty.ToString(), checkID, taOrderItemInfo.ItemID, node, true);
            }
        }

        private void AddFreeOrAutomatic()
        {
            try
            {
                //判断Automatic
                SysValueInfo svAutomatic = CommonData.SysValue.FirstOrDefault(s => s.ValueID.Equals(PubComm.SYS_VALUE_ADD_ITEM_AMOUNT));
                if (svAutomatic != null)
                {
                    if (Convert.ToDecimal(treeListOrder.GetSummaryValue(treeListOrder.Columns[7]).ToString()) > Convert.ToDecimal(svAutomatic.ValueResult))
                    {
                        var lstAuto = CommonData.TaFreeFoodAdd.Where(s => !string.IsNullOrEmpty(s.AddDishCode.Trim()));
                        
                        foreach (var autoMi in lstAuto)
                        {
                            //不存在才加，否则不加
                            if (!treeListOrder.Nodes.Any(s => s["ItemCode"].Equals(autoMi.AddDishCode.Trim())))
                            {
                                TaMenuItemInfo taMi = CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(autoMi.AddDishCode.Trim()));
                                if (taMi != null) SetSameMenuItemMerge(taMi, 1, false);
                            }
                        }
                    }
                }

                //判断Free
                SysValueInfo svFree = CommonData.SysValue.FirstOrDefault(s => s.ValueID.Equals(PubComm.SYS_VALUE_FREE_FOOD_ITEM_AMOUNT));
                if (svFree != null)
                {
                    if (Convert.ToDecimal(treeListOrder.GetSummaryValue(treeListOrder.Columns[7]).ToString()) > Convert.ToDecimal(svFree.ValueResult))
                    {
                        var lstAdd = CommonData.TaFreeFood.Where(s => !string.IsNullOrEmpty(s.DishCode));

                        //存在Free
                        if (lstAdd.Any())
                        {
                            TreeListNode nodeFree = null;
                            bool isContainFreeItem = false;

                            foreach (var taFreeFoodInfo in lstAdd)
                            {
                                nodeFree = treeListOrder.Nodes.FirstOrDefault(s => s["ItemCode"].Equals(taFreeFoodInfo.DishCode) && s["ItemPrice"].Equals("0.00"));

                                if (nodeFree != null)
                                {
                                    isContainFreeItem = true;
                                    break;
                                }
                            }

                            if (!isContainFreeItem)
                            {
                                FrmFreeItem frmTaFreeItem = new FrmFreeItem(iLangStatusId);
                                frmTaFreeItem.Location = panelControl3.PointToScreen(panelControl1.Location);
                                frmTaFreeItem.Size = panelControl3.Size;

                                if (frmTaFreeItem.ShowDialog() == DialogResult.OK)
                                {
                                    TaMenuItemInfo taMiFree = frmTaFreeItem.TaMiFreeMi;

                                    //不存在才加，否则不加
                                    if (taMiFree != null)
                                    {
                                        //if (!treeListOrder.Nodes.Any(s => s["ItemCode"].Equals(taMiFree.MiDishCode)))
                                        //{
                                        taMiFree.MiSmallPrice = "0.00";
                                        taMiFree.MiLargePrice = "0.00";
                                        taMiFree.MiRegularPrice = "0.00";
                                        taMiFree.MiSpecialPrice = "0.00";
                                        SetSameMenuItemMerge(taMiFree, 1, false);
                                        //}
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("FrmMain.AddFreeOrAutomatic", ex.InnerException);
                return;
            }
        }

        private Font SetBtnFont(TaConfMenuDisplayFontInfo taConfMenuDisplayFontInfo, int iLange, int iMenuItemOrCate)
        {
            if (iLange == PubComm.MENU_LANG_DEFAULT)
            {
                return iMenuItemOrCate == 1
                    ? (string.IsNullOrEmpty(taConfMenuDisplayFontInfo.MenuDisplayBtnFontSize)
                        ? new Font(SystemFonts.DefaultFont.FontFamily, float.Parse("12.00"))
                        : new Font(SystemFonts.DefaultFont.FontFamily, float.Parse(taConfMenuDisplayFontInfo.MenuDisplayBtnFontSize)))
                    : (string.IsNullOrEmpty(taConfMenuDisplayFontInfo.CategBtnFontSize)
                        ? new Font(SystemFonts.DefaultFont.FontFamily, float.Parse("12.00"))
                        : new Font(SystemFonts.DefaultFont.FontFamily, float.Parse(taConfMenuDisplayFontInfo.CategBtnFontSize)));
            }
            else
            {
                return iMenuItemOrCate == 1
                    ? (string.IsNullOrEmpty(taConfMenuDisplayFontInfo.OtherMenuDisplayBtnFontSize)
                        ? new Font(SystemFonts.DefaultFont.FontFamily, float.Parse("12.00"))
                        : new Font(SystemFonts.DefaultFont.FontFamily, float.Parse(taConfMenuDisplayFontInfo.OtherMenuDisplayBtnFontSize)))
                    : (string.IsNullOrEmpty(taConfMenuDisplayFontInfo.OtherCategBtnFontSize)
                        ? new Font(SystemFonts.DefaultFont.FontFamily, float.Parse("12.00"))
                        : new Font(SystemFonts.DefaultFont.FontFamily, float.Parse(taConfMenuDisplayFontInfo.OtherCategBtnFontSize)));
            }
        }

        private void ShowCallIdWindow(string CallerPhone)
        {
            try
            {
                DelegateOrder handler = null;
                IAsyncResult result = null;

                if (!string.IsNullOrEmpty(CallerPhone.Trim()))
                {
                    isGetPhone = true;

                    #region 保存来电信息

                    TaComePhoneInfo taComePhoneInfo = new TaComePhoneInfo();
                    taComePhoneInfo.CustPhoneNo = CallerPhone;
                    taComePhoneInfo.ComePhoneTime = DateTime.Now.ToString();
                    taComePhoneInfo.CustName = @"";
                    taComePhoneInfo.CustID = "0";
                    taComePhoneInfo.BusDate = strBusDate;

                    _control.AddEntity(taComePhoneInfo);

                    #endregion

                    if (treeListOrder.Nodes.Count > 0)
                    {
                        #region 保存TreeList

                        AddFreeOrAutomatic();

                        List<TaOrderItemInfo> lstTaOI = new List<TaOrderItemInfo>();

                        lstTaOI = TreeListToOrderItem(isNew);

                        handler = DelegateOrderOpt.SaveOrder;
                        result = handler.BeginInvoke(checkID, strBusDate, lstTaOI, null, null);

                        #endregion

                        #region 保存账单

                        SaveCheckOrder(lstTaOI, false);

                        #endregion
                    }

                    LogHelper.Info("CallerPhone:" + CallerPhone);

                    //新客户
                    FrmCaller frmCaller = new FrmCaller(CallerPhone, strBusDate, ORDER_TYPE, lblReadyTime.Visible ? lblReadyTime.Text : "");
                    frmCaller.Location = pcMain.Location;
                    frmCaller.Size = pcMain.Size;

                    if (frmCaller.ShowDialog() == DialogResult.OK)
                    {
                        TaCustomerInfo taCustomerInfo = new TaCustomerInfo();

                        ORDER_TYPE = frmCaller.OrderType;
                        taCustomerInfo = frmCaller.TaCustomer;
                        string strReadTime = frmCaller.ReadyTime;

                        if (taCustomerInfo == null)
                        {
                            SetCustInfo(true, true, null);
                        }
                        else
                        {
                            treeListOrder.Nodes.Clear();
                            checkID = CommonDAL.GetCheckCode();
                            LogHelper.Info("#checkID:" + checkID + "#ShowCallIdWindow");
                            lblCheck.Text = checkID;
                            ChangeOrderBtnColor(ORDER_TYPE);
                            SetCustInfo(false, false, taCustomerInfo);
                        }
                        isGetPhone = false;
                        strTranPhoneNum = "";
                    }

                    if (!string.IsNullOrEmpty(CallerPhone.Trim())) handler.EndInvoke(result);
                }
            }
            catch (Exception ex) { LogHelper.Error("ShowCallIdWindow", ex); }
        }

        private void SetMenuItem(TaMenuItemInfo taMenuItemInfo)
        {
            if (taMenuItemInfo != null)
            {
                if (isIngredMode)
                {
                    TaOrderItemInfo taOrderItemInfo = new TaOrderItemInfo();

                    if (treeListOrder.FocusedNode != null)
                    {
                        //treeListOrder.SetFocusedNode(treeListOrder.Nodes[treeListOrder.GetVisibleIndexByNode(treeListOrder.FocusedNode) - 1]);

                        if (!treeListOrder.FocusedNode["ItemType"].ToString().Equals("1"))
                        {
                            //for (int i = 1; i < treeListOrder.AllNodesCount; i++)
                            //{
                            //    //TreeListNode tLn = treeListOrder.Nodes[treeListOrder.GetVisibleIndexByNode(treeListOrder.FocusedNode) - i];
                            //    //TreeListNode tLn = treeListOrder.Nodes[treeListOrder.GetNodeIndex(treeListOrder.FocusedNode) - i];

                            //}
                            TreeListNode tLn = treeListOrder.FocusedNode.ParentNode;
                            if (tLn["ItemType"].ToString().Equals("1"))
                            {
                                treeListOrder.SetFocusedNode(tLn);
                            }
                        }

                        int sQty = Convert.ToInt32(treeListOrder.FocusedNode["ItemQty"].ToString());

                        //只允许菜品
                        if (treeListOrder.FocusedNode["ItemType"].ToString().Equals("1"))
                        {
                            taOrderItemInfo.ItemID = Guid.NewGuid().ToString();
                            taOrderItemInfo.ItemCode = taMenuItemInfo.MiDishCode;
                            taOrderItemInfo.ItemDishName = sModeValue + " " + taMenuItemInfo.MiEngName;
                            taOrderItemInfo.ItemDishOtherName = sModeValue + " " + taMenuItemInfo.MiOtherName;
                            taOrderItemInfo.ItemQty = sQty.ToString();
                            taOrderItemInfo.ItemPrice = "0.00";
                            taOrderItemInfo.ItemTotalPrice = "0.00";
                            taOrderItemInfo.CheckCode = checkID;
                            taOrderItemInfo.ItemType = PubComm.MENU_ITEM_INGRED_MODE;
                            taOrderItemInfo.ItemParent = treeListOrder.FocusedNode["ItemID"].ToString();
                            //taOrderItemInfo.ItemParent = Convert.ToInt32(taMenuItemInfo.ID);
                            taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                            taOrderItemInfo.OrderStaff = usrID;
                            taOrderItemInfo.BusDate = strBusDate;

                            taOrderItemInfo.MenuItemID = taMenuItemInfo.ID;

                            taOrderItemInfo.IsDiscount = taMenuItemInfo.MiRmk.Contains("Discountable") ? "N" : "Y";

                            AddTreeListChild(taOrderItemInfo, treeListOrder.FocusedNode);

                            if (iLangStatusId == PubComm.MENU_LANG_DEFAULT)
                            {
                                foreach (TreeListNode treeListNode in treeListOrder.Nodes)
                                {
                                    //主菜品
                                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_MAIN.ToString()))
                                    {
                                        if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(treeListNode["ItemCode"])))
                                        {
                                            treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString()
                                                                           .Replace(CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiOtherName,
                                                                                    CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiEngName);
                                        }

                                        treeListNode["ItemDishName"] = ModifItemOtherName(treeListNode["ItemDishName"].ToString(), iLangStatusId);

                                        if (treeListNode.HasChildren)
                                        {
                                            SetChildNode(treeListNode);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (TreeListNode treeListNode in treeListOrder.Nodes)
                                {
                                    //主菜品
                                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_MAIN.ToString()))
                                    {
                                        if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(treeListNode["ItemCode"])))
                                        {
                                            treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString()
                                                .Replace(CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiEngName,
                                                    CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiOtherName);
                                        }

                                        treeListNode["ItemDishName"] = ModifItemOtherName(treeListNode["ItemDishName"].ToString(), iLangStatusId);

                                        if (treeListNode.HasChildren)
                                        {
                                            SetChildNode(treeListNode);
                                        }
                                    }
                                }
                            }

                            //添加完菜品后恢复到正常状态
                            isIngredMode = false;

                            SetLang();
                        }
                    }
                }
                else
                {
                    SetListNode(taMenuItemInfo, 1, false);

                    SetLang();
                }

                treeListOrder.SetFocusedNode(treeListOrder.Nodes[treeListOrder.Nodes.Count - 1]);
            }
        }
    }
}