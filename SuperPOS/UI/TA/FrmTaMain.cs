using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList.Nodes;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

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
        private int iLangStatusId = PubComm.MENU_LANG_DEFAULT;
        //菜谱ID
        private int iMenuSetId = 0;
        //MenuCate ID
        private int iMenuCateId = 0;
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

        #region 来电显示相关
        [StructLayout(LayoutKind.Sequential)]
        public struct tag_pstn_Data
        {
            public Int16 uChannelID;//设备通道
            public Int32 lPlayFileHandle;//播放句柄
            public Int32 lRecFileHandle;//录音句柄            
        }

        tag_pstn_Data[] m_tagpstnData = new tag_pstn_Data[BriSDKLib.MAX_CHANNEL_COUNT];
        #endregion

        public FrmTaMain()
        {
            InitializeComponent();
        }

        public FrmTaMain(int id)
        {
            InitializeComponent();
            usrID = id;
        }

        public FrmTaMain(string cId, int id, int cusId)
        {
            InitializeComponent();
            checkID = cId;
            usrID = id;
            CustID = cusId;
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
            try
            {
                #region 保存TreeList
                List<TaOrderItemInfo> lstTaOI = new List<TaOrderItemInfo>();

                lstTaOI = TreeListToOrderItem(isNew);

                foreach (var taOrderItemInfo in lstTaOI)
                {
                    new SystemData().GetTaOrderItem();

                    if (CommonData.TaOrderItem.Any(s => s.ID == taOrderItemInfo.ID))
                    {
                        _control.UpdateEntity(taOrderItemInfo);
                    }
                    else
                    {
                        _control.AddEntity(taOrderItemInfo);
                    }
                }
                #endregion

                #region 保存账单
                //Console.WriteLine(treeListOrder.Columns["ItemTotalPrice"].SummaryFooter.ToString());
                SaveCheckOrder(lstTaOI);
                #endregion

                treeListOrder.Nodes.Clear();

                checkID = CommonDAL.GetCheckCode(true);
                lblCheck.Text = checkID;
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }
        }
        #endregion

        #region Cancel按钮点击
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (treeListOrder.AllNodesCount > 0)
            {
                if (CommonTool.ConfirmMessage("Are you sure you want to cancel the order?") == DialogResult.OK)
                {
                    treeListOrder.Nodes.Clear();
                }
            }

            //Close();
        }
        #endregion

        #region 窗口加载
        private void FrmTaMain_Load(object sender, EventArgs e)
        {
            //展开所有TreeList
            treeListOrder.ExpandAll();

            SetMenuItemBtn();
            SetMenuCateBtn();

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
                checkID = CommonDAL.GetCheckCode(true);

                lblCheck.Text = checkID;
            }
            else
            {
                new SystemData().GetTaOrderItem();
                new SystemData().GetTaCheckOrder();
                //TO DO something
                lblCheck.Text = checkID;

                if (CommonData.TaCheckOrder.Any(s => s.CheckCode.Equals(checkID)))
                    ORDER_TYPE = lblType.Text = CommonData.TaCheckOrder.FirstOrDefault(s => s.CheckCode.Equals(checkID)).PayOrderType;
                //BindData(checkID);
                
                InitGrid(CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID)).ToList());

                treeListOrder.ExpandAll();

                isNew = false;
            }
            //加载TreeList
            //BindData();

            GetCustInfo(CustID);

            asfc.controllInitializeSize(this);

            #region 提示打开来电设备失败
            //if (isNew)
            //{
            //    if (!openDev())
            //    {
            //        if (CommonTool.ConfirmMessage("Failed to open device, continue to order meal?") == DialogResult.Cancel)
            //        {
            //            //无来电设备连接时，取消打开
            //            Close();
            //        }
            //    }
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
                            treeListNode["ItemDishName"] = CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiEngName;
                        }

                        if (treeListNode.HasChildren)
                        {
                            SetChildNode(treeListNode);
                        }
                    }
                }

                btnHome.Text = @"HOME";
                btnKeypad.Text = @"Key";
                btnChange.Text = @"Change";
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
                foreach (TreeListNode treeListNode in treeListOrder.Nodes)
                {
                    //主菜品
                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_MAIN.ToString()))
                    {
                        if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(treeListNode["ItemCode"])))
                        {
                            treeListNode["ItemDishName"] = CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiOtherName;
                        }

                        if (treeListNode.HasChildren)
                        {
                            SetChildNode(treeListNode);
                        }
                    }
                }

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
            if (!string.IsNullOrEmpty(btnMenuCate[0].Text) && !string.IsNullOrEmpty(btnMenuCate[41].Text))
                iCatePageNum = iCatePageNum + 1;

            SetMenuItem(iPageNum, iCatePageNum, iMenuSetId);
        }
        #endregion

        #region MenuCate Left翻页
        private void btnMcLeft_Click(object sender, EventArgs e)
        {
            iCatePageNum = iCatePageNum <= 1 ? 1 : (iCatePageNum <= 1 ? 1 : iCatePageNum - 1);

            SetMenuItem(iPageNum, iCatePageNum, iMenuSetId);
        }
        #endregion

        #region TreeList向上移动
        private void btnUp_Click(object sender, EventArgs e)
        {
            //此为控制节点向上移动，打乱显示格局
            //treeListOrder.BeginUpdate();

            //treeListOrder.SetNodeIndex(treeListOrder.FocusedNode, treeListOrder.GetNodeIndex(treeListOrder.FocusedNode.PrevNode));

            //treeListOrder.EndUpdate();
            treeListOrder.SetFocusedNode(treeListOrder.GetNodeIndex(treeListOrder.FocusedNode) - 1 >= 0
                ? treeListOrder.Nodes[treeListOrder.GetNodeIndex(treeListOrder.FocusedNode) - 1]
                : treeListOrder.Nodes[0]);
        }

        #endregion

        #region TreeList向下移动
        private void btnDown_Click(object sender, EventArgs e)
        {
            treeListOrder.SetFocusedNode(treeListOrder.GetNodeIndex(treeListOrder.FocusedNode) - treeListOrder.Nodes.Count < 1
                ? treeListOrder.Nodes[treeListOrder.Nodes.Count - 1]
                : treeListOrder.Nodes[treeListOrder.GetNodeIndex(treeListOrder.FocusedNode) + 1]);
        }
        #endregion

        #region TreeList增加Qty数量
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (treeListOrder.FocusedNode != null)
            {
                treeListOrder.BeginUpdate();
                decimal dQty = Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"]);
                decimal dPrice = Convert.ToDecimal(treeListOrder.FocusedNode["ItemTotalPrice"]);

                if (dQty > 1)
                {
                    treeListOrder.FocusedNode["ItemQty"] = (dQty + 1).ToString();
                    treeListOrder.FocusedNode["ItemTotalPrice"] = ((dPrice / dQty) * (dQty + 1)).ToString("0.00");
                }
                else
                {
                    treeListOrder.FocusedNode["ItemQty"] = (dQty + 1).ToString();
                    treeListOrder.FocusedNode["ItemTotalPrice"] = (dPrice * 2.0m).ToString("0.00");
                }

                GetChildNodes(treeListOrder.FocusedNode, Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"]));

                treeListOrder.EndUpdate();

                treeListOrder.ExpandAll();
            }
        }
        #endregion
        
        #region TreeList减少Qty数量
        private void btnReduce_Click(object sender, EventArgs e)
        {
            if (treeListOrder.FocusedNode != null)
            {
                treeListOrder.BeginUpdate();
                decimal dQty = Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"]);
                decimal dPrice = Convert.ToDecimal(treeListOrder.FocusedNode["ItemTotalPrice"]);

                if (dQty > 1.0m)
                {
                    treeListOrder.FocusedNode["ItemQty"] = (dQty - 1).ToString("0.00");
                    treeListOrder.FocusedNode["ItemTotalPrice"] = ((dPrice/dQty)*(dQty - 1)).ToString("0.00");

                    GetChildNodes(treeListOrder.FocusedNode, Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"]));
                }
                else
                {
                    treeListOrder.DeleteNode(treeListOrder.FocusedNode);
                }
                treeListOrder.EndUpdate();

                treeListOrder.ExpandAll();
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

                    FrmTaAppendItem frmTaAppendItem = new FrmTaAppendItem();

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
                                taOrderItemInfo.ItemDishName = taExtraResult.rType + " " + taExtraResult.rItemName;
                                taOrderItemInfo.ItemDishOtherName = taExtraResult.rItemName;
                                taOrderItemInfo.ItemQty = sQty;
                                taOrderItemInfo.ItemPrice = taExtraResult.rPrice;
                                taOrderItemInfo.ItemTotalPrice = (Convert.ToDecimal(sQty) * Convert.ToDecimal(taExtraResult.rPrice)).ToString();
                                taOrderItemInfo.CheckCode = checkID;
                                taOrderItemInfo.ItemType = PubComm.MENU_ITEM_APPEND;
                                taOrderItemInfo.ItemParent = sParentID;
                                //taOrderItemInfo.ItemParent = Convert.ToInt32(taMenuItemInfo.ID);
                                taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                                taOrderItemInfo.OrderStaff = usrID;

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
                //只允许菜品
                if (treeListOrder.FocusedNode["ItemType"].ToString().Equals("1"))
                {
                    isIngredMode = true;

                    FrmTaIngredMode frmTaIngredMode = new FrmTaIngredMode();

                    if (frmTaIngredMode.ShowDialog() == DialogResult.OK)
                    {
                        sModeValue = frmTaIngredMode.modeValue;

                        if (string.IsNullOrEmpty(sModeValue)) isIngredMode = false;
                    }
                }
            }
        }
        #endregion

        #region Menu Set选择
        private void btnMenu_Click(object sender, EventArgs e)
        {
            FrmTaMenuSelect frmTaMenuSelect = new FrmTaMenuSelect();

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
            }
        }
        #endregion

        #region Pay按钮
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (treeListOrder.AllNodesCount <= 0) return;

            #region 保存TreeList
            new SystemData().GetTaOrderItem();
            var lstDelOi = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkID));

            foreach (var taOrderItemInfo in lstDelOi)
            {
                _control.DeleteEntity(taOrderItemInfo);
            }

            List<TaOrderItemInfo> lstTaOI = new List<TaOrderItemInfo>();

            lstTaOI = TreeListToOrderItem(isNew);

            foreach (var taOrderItemInfo in lstTaOI)
            {
                new SystemData().GetTaOrderItem();

                if (CommonData.TaOrderItem.Any(s => s.ID == taOrderItemInfo.ID))
                {
                    _control.UpdateEntity(taOrderItemInfo);
                }
                else
                {
                    _control.AddEntity(taOrderItemInfo);
                }
            }
            #endregion

            #region 保存账单
            //Console.WriteLine(treeListOrder.Columns["ItemTotalPrice"].SummaryFooter.ToString());
            SaveCheckOrder(lstTaOI);
            #endregion

            //ORDER_TYPE_SHOP
            if (ORDER_TYPE.Equals(PubComm.ORDER_TYPE_SHOP))
            {
                FrmTaPaymentShop frmTaPaymentShop = new FrmTaPaymentShop(usrID, checkID, ORDER_TYPE, CallerID, SetPrtInfo(lstTaOI));

                if (frmTaPaymentShop.ShowDialog() == DialogResult.OK)
                {
                    if (frmTaPaymentShop.returnPaid) treeListOrder.Nodes.Clear();

                    checkID = CommonDAL.GetCheckCode(true);
                    lblCheck.Text = checkID;
                }
            }
            else
            {
                FrmTaPayment frmTaPayment = new FrmTaPayment(usrID, checkID, ORDER_TYPE, CallerID, SetPrtInfo(lstTaOI));

                if (frmTaPayment.ShowDialog() == DialogResult.OK)
                {
                    if (frmTaPayment.returnPaid) treeListOrder.Nodes.Clear();

                    checkID = CommonDAL.GetCheckCode(true);
                    lblCheck.Text = checkID;
                }
            }
        }
        #endregion

        #region Pend Order按钮
        private void btnPendOrder_Click(object sender, EventArgs e)
        {
            FrmTaPendOrder frmTaPendOrder = new FrmTaPendOrder(usrID);
            this.Hide();
            frmTaPendOrder.ShowDialog();
        }
        #endregion

        #endregion

        #region 方法

        #region 设置MenuItem按钮
        /// <summary>
        /// 设置MenuItem按钮
        /// </summary>
        private void SetMenuItemBtn()
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
                btnMenuItem[i].Font = new Font(SystemFonts.DefaultFont.FontFamily, float.Parse(CommonData.TaSysFont.FirstOrDefault().miFont));
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

            TaMenuItemInfo taMenuItemInfo = GetMenuItemInfo(btn.Text, iMenuCateId, iMenuSetId);

            if (taMenuItemInfo != null)
            {
                if (isIngredMode)
                {
                    TaOrderItemInfo taOrderItemInfo = new TaOrderItemInfo();

                    if (treeListOrder.FocusedNode != null)
                    {
                        int sQty = Convert.ToInt32(treeListOrder.FocusedNode["ItemQty"].ToString());

                        //只允许菜品
                        if (treeListOrder.FocusedNode["ItemType"].ToString().Equals("1"))
                        {
                            taOrderItemInfo.ItemID = Guid.NewGuid().ToString();
                            taOrderItemInfo.ItemCode = taMenuItemInfo.MiDishCode;
                            taOrderItemInfo.ItemDishName = sModeValue + " " + taMenuItemInfo.MiEngName;
                            taOrderItemInfo.ItemDishOtherName = taMenuItemInfo.MiOtherName;
                            taOrderItemInfo.ItemQty = sQty.ToString();
                            taOrderItemInfo.ItemPrice = "0.00";
                            taOrderItemInfo.ItemTotalPrice = "0.00";
                            taOrderItemInfo.CheckCode = checkID;
                            taOrderItemInfo.ItemType = PubComm.MENU_ITEM_APPEND;
                            taOrderItemInfo.ItemParent = treeListOrder.FocusedNode["ItemID"].ToString();
                            //taOrderItemInfo.ItemParent = Convert.ToInt32(taMenuItemInfo.ID);
                            taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                            taOrderItemInfo.OrderStaff = usrID;

                            AddTreeListChild(taOrderItemInfo, treeListOrder.FocusedNode);
                        }
                    }
                }
                else
                {
                    SetListNode(taMenuItemInfo, 1);
                }
            }
        }
        #endregion

        #region 设置MenuCate按钮
        /// <summary>
        /// 设置MenuCate按钮
        /// </summary>
        private void SetMenuCateBtn()
        {
            btnMenuCate[0] = btnMc0;
            btnMenuCate[1] = btnMc1;
            btnMenuCate[2] = btnMc2;
            btnMenuCate[3] = btnMc3;
            btnMenuCate[4] = btnMc4;
            btnMenuCate[5] = btnMc5;
            btnMenuCate[6] = btnMc6;
            btnMenuCate[7] = btnMc7;
            btnMenuCate[8] = btnMc9;
            btnMenuCate[9] = btnMc10;
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
                btnMenuCate[i].Font = new Font(SystemFonts.DefaultFont.FontFamily, float.Parse(CommonData.TaSysFont.FirstOrDefault().cateFont));
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

            lstMc = iLangStatusId == PubComm.MENU_LANG_OTHER 
                    ? CommonData.TaMenuCate.Where(s => s.CateOtherName.Equals(btn.Text)).ToList() 
                    : CommonData.TaMenuCate.Where(s => s.CateEngName.Equals(btn.Text)).ToList();

            if (lstMc.Any())
            {
                iMenuCateId = lstMc.FirstOrDefault().ID;
            }

            iPageNum = 1;
            SetMenuItem(iPageNum, iMenuCateId, iMenuSetId);
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

            foreach (var taMenuCateInfo in CommonDAL.GetListQueryPageMenuCate(iPageNum, msId))
            {
                btnMenuCate[i].Text = iLangStatusId == PubComm.MENU_LANG_DEFAULT
                    ? taMenuCateInfo.CateEngName
                    : taMenuCateInfo.CateOtherName;
                btnMenuCate[i].Appearance.BackColor = string.IsNullOrEmpty(taMenuCateInfo.BtnColor)
                                                        ? Color.FromName(@"RoyalBlue")
                                                        : Color.FromName(taMenuCateInfo.BtnColor);
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

            treeListOrder.DataSource = CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(checkCode)).ToList();

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
                taOrderItemInfo.OrderStaff
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
                taOrderItemInfo.OrderStaff
            }, node);

            Console.WriteLine(node1["ItemParent"].ToString());

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
        private TaMenuItemInfo GetMenuItemInfo(string name, int mcId, int msId)
        {
            var lstMc = CommonData.TaMenuItem;

            if (CommonDAL.IsShowMenuItemCode())
            {
                name = name.Substring(name.IndexOf(")") + 1);
            }

            lstMc = iLangStatusId == PubComm.MENU_LANG_DEFAULT
                    ? CommonData.TaMenuItem.Where(s => s.MiEngName.Equals(name)).ToList()
                    : CommonData.TaMenuItem.Where(s => s.MiOtherName.Equals(name)).ToList();

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

            var lstOther = CommonData.TaMenuItemOtherChoice.Where(s => s.MiID == mId && s.IsAutoAppend.Equals("N") && s.IsEnableChoice.Equals("Y"));

            List<TaOrderItemInfo> lstMi = new List<TaOrderItemInfo>();

            List<TaMenuItemOtherChoiceInfo> lstResult = new List<TaMenuItemOtherChoiceInfo>();

            if (lstOther.Any())
            {
                //弹出用户选择窗口
                if (lstOther.Any(s => s.MiType == 2)) //存在Second Choices
                {
                    //弹出窗口选择
                    FrmTAOtherChoice frmTaOtherChoice1 = new FrmTAOtherChoice(2, mId, lstOther.Where(s => s.MiType == 2).ToList());
                    if (frmTaOtherChoice1.ShowDialog() == DialogResult.OK)
                    {
                        lstResult = frmTaOtherChoice1.lstReturnChoice;
                    }
                }

                if (lstOther.Any(s => s.MiType == 3))
                {
                    //弹出窗口选择
                    FrmTAOtherChoice frmTaOtherChoice2 = new FrmTAOtherChoice(3, mId, lstOther.Where(s => s.MiType == 3).ToList());
                    if (frmTaOtherChoice2.ShowDialog() == DialogResult.OK)
                    {
                        if (frmTaOtherChoice2.lstReturnChoice.Any()) lstResult.AddRange(frmTaOtherChoice2.lstReturnChoice);
                    }
                }
            }

            if (isSubMenu)
            {
                lstResult.AddRange(CommonData.TaMenuItemOtherChoice.Where(s => s.MiID == mId && s.IsAutoAppend.Equals("Y") && s.IsEnableChoice.Equals("Y")));
            }

            foreach (var taMenuItemOtherChoiceInfo in lstResult)
            {
                TaOrderItemInfo taOrderItemInfo = new TaOrderItemInfo();
                taOrderItemInfo.ItemID = "0";
                taOrderItemInfo.ItemCode = taMenuItemOtherChoiceInfo.ID.ToString();
                taOrderItemInfo.ItemDishName = taMenuItemOtherChoiceInfo.MiEngName;
                taOrderItemInfo.ItemDishOtherName = taMenuItemOtherChoiceInfo.MiOtherName;
                taOrderItemInfo.ItemQty = mQty;
                taOrderItemInfo.ItemPrice = taMenuItemOtherChoiceInfo.MiPrice;
                taOrderItemInfo.ItemTotalPrice = (Convert.ToInt32(mQty) * Convert.ToDecimal(taMenuItemOtherChoiceInfo.MiPrice)).ToString();
                taOrderItemInfo.CheckCode = mCheckCode;
                taOrderItemInfo.ItemType = PubComm.MENU_ITEM_CHILD;
                taOrderItemInfo.ItemParent = itemId;
                taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                taOrderItemInfo.OrderStaff = usrID;

                lstMi.Add(taOrderItemInfo);
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
                    taOrderItemInfo.ItemDishName = node["ItemDishName"].ToString();
                    taOrderItemInfo.ItemDishOtherName = node["ItemDishOtherName"].ToString();
                    taOrderItemInfo.ItemQty = node["ItemQty"].ToString();
                    taOrderItemInfo.ItemPrice = node["ItemPrice"].ToString();
                    taOrderItemInfo.ItemTotalPrice = node["ItemTotalPrice"].ToString();
                    taOrderItemInfo.CheckCode = node["CheckCode"].ToString();
                    taOrderItemInfo.ItemType = Convert.ToInt32(node["ItemType"]);
                    taOrderItemInfo.ItemParent = "0";
                    taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                    taOrderItemInfo.OrderStaff = usrID;

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
                    taOrderItemInfo.ItemDishName = childNode["ItemDishName"].ToString();
                    taOrderItemInfo.ItemDishOtherName = childNode["ItemDishOtherName"].ToString();
                    taOrderItemInfo.ItemQty = childNode["ItemQty"].ToString();
                    taOrderItemInfo.ItemPrice = childNode["ItemPrice"].ToString();
                    taOrderItemInfo.ItemTotalPrice = childNode["ItemTotalPrice"].ToString();
                    taOrderItemInfo.CheckCode = childNode["CheckCode"].ToString();
                    taOrderItemInfo.ItemType = Convert.ToInt32(childNode["ItemType"]);
                    taOrderItemInfo.ItemParent = parentID;
                    taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                    taOrderItemInfo.OrderStaff = usrID;

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

        //protected override void DefWndProc(ref System.Windows.Forms.Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case BriSDKLib.BRI_EVENT_MESSAGE:
        //            {
        //                BriSDKLib.TBriEvent_Data EventData = (BriSDKLib.TBriEvent_Data)Marshal.PtrToStructure(m.LParam, typeof(BriSDKLib.TBriEvent_Data));
        //                string strValue = "";
                        
        //                if (BriSDKLib.QNV_SetParam(EventData.uChannelID, BriSDKLib.QNV_PARAM_RINGCALLIDTYPE, BriSDKLib.DIALTYPE_FSK) <= 0)
        //                {
        //                    AppendStatus("QNV_PARAM_RINGCALLIDTYPE");
        //                    return;
        //                }

        //                if (BriSDKLib.QNV_SetParam(EventData.uChannelID, BriSDKLib.QNV_PARAM_AM_LINEIN, 6) <= 0)
        //                {
        //                    AppendStatus("QNV_PARAM_AM_LINEIN");
        //                    return;
        //                }

        //                if (BriSDKLib.QNV_SetDevCtrl(EventData.uChannelID, BriSDKLib.QNV_CTRL_RECVFSK, 1) <= 0)
        //                {
        //                    AppendStatus("QNV_CTRL_RECVFSK");
        //                    return;
        //                }

        //                if (BriSDKLib.QNV_SetDevCtrl(EventData.uChannelID, BriSDKLib.QNV_CTRL_SELECTADCIN, 1) < 0)
        //                {
        //                    AppendStatus("QNV_CTRL_SELECTADCIN");
        //                    return;
        //                }

        //                switch (EventData.lEventType)
        //                {
        //                    case BriSDKLib.BriEvent_PhoneHook:
        //                        {
        //                            strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：电话机摘机";
        //                        }
        //                        break;
        //                    case BriSDKLib.BriEvent_PhoneHang:
        //                        {
        //                            strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：电话机挂机";
        //                        }
        //                        break;
        //                    case BriSDKLib.BriEvent_CallIn:
        //                        {////两声响铃结束后开始呼叫转移到CC
        //                            //AppendStatus(BriSDKLib.BriEvent_CallIn.ToString());
        //                            strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：来电响铃：" + FromASCIIByteArray(EventData.szData);
        //                        }
        //                        break;
        //                    case BriSDKLib.BriEvent_GetCallID:
        //                        {
        //                            //AppendStatus(BriSDKLib.BriEvent_GetCallID.ToString());
        //                            //strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：接收到来电号码 " + FromASCIIByteArray(EventData.szData);

        //                            //MessageBox.Show(strValue);
        //                            string CallerPhone = FromASCIIByteArray(EventData.szData);

        //                            if (string.IsNullOrEmpty(CallerPhone))
        //                            {
        //                                //新客户
        //                            }
        //                            else
        //                            {
        //                                //老客户
        //                            }
        //                        }
        //                        break;
        //                    case BriSDKLib.BriEvent_StopCallIn:
        //                        {
        //                            strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：停止呼入，产生一个未接电话 ";
        //                        }
        //                        break;
        //                    case BriSDKLib.BriEvent_GetDTMFChar: strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：接收到按键 " + FromASCIIByteArray(EventData.szData); break;
        //                    case BriSDKLib.BriEvent_RemoteHang:
        //                        {
        //                            strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：远程挂机 ";
        //                        }
        //                        break;
        //                    case BriSDKLib.BriEvent_Busy:
        //                        {

        //                            strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：接收到忙音,线路已经断开 ";
        //                        }
        //                        break;
        //                    case BriSDKLib.BriEvent_DialTone: strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：检测到拨号音 "; break;
        //                    case BriSDKLib.BriEvent_PhoneDial: strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：电话机拨号 " + FromASCIIByteArray(EventData.szData); break;
        //                    case BriSDKLib.BriEvent_RingBack: strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：拨号后接收到回铃音 "; break;
        //                    case BriSDKLib.BriEvent_DevErr:
        //                        {
        //                            if (EventData.lResult == 3)
        //                            {
        //                                strValue = "通道" + (EventData.uChannelID + 1).ToString() + "：设备可能被移除 ";
        //                            }
        //                        }
        //                        break;
        //                    default: break;
        //                }
        //                if (strValue.Length > 0)
        //                {
        //                    AppendStatus(strValue);
        //                }
        //            }
        //            break;
        //        default:
        //            base.DefWndProc(ref m);
        //            break;
        //    }
        //}

        #region 打开设备
        private bool openDev()
        {
            //if (BriSDKLib.QNV_OpenDevice(BriSDKLib.ODT_LBRIDGE, 0, "") <= 0 || BriSDKLib.QNV_DevInfo(0, BriSDKLib.QNV_DEVINFO_GETCHANNELS) <= 0)
            if (BriSDKLib.QNV_OpenDevice(BriSDKLib.ODT_LBRIDGE, 0, "") <= 0 || BriSDKLib.QNV_DevInfo(0, BriSDKLib.QNV_DEVINFO_GETCHANNELS) <= 0)
            {
                AppendStatus("Open device failure!");
                //MessageBox.Show("打开设备失败");
                return false;
            }

            for (Int16 i = 0; i < BriSDKLib.QNV_DevInfo(-1, BriSDKLib.QNV_DEVINFO_GETCHANNELS); i++)
            {//在windowproc处理接收到的消息
                BriSDKLib.QNV_Event(i, BriSDKLib.QNV_EVENT_REGWND, (Int32)this.Handle, "", new StringBuilder(0), 0);
            }

            //AppendStatus("打开设备成功");
            return true;
        }

        #endregion
        
        #endregion

        #region 保存账单

        private void SaveCheckOrder(List<TaOrderItemInfo> lstTaOI)
        {
            new SystemData().GetTaCheckOrder();
            TaCheckOrderInfo taCheckOrderInfo = new TaCheckOrderInfo();
            var lstChk = CommonData.TaCheckOrder.Where(s => s.CheckCode.Equals(checkID) && s.IsPaid.Equals("N"));
            if (lstChk.Any())
            {
                taCheckOrderInfo = lstChk.FirstOrDefault();
                taCheckOrderInfo.PayOrderType = ORDER_TYPE;
                taCheckOrderInfo.MenuAmount = lstTaOI.Sum(s => Convert.ToDecimal(s.ItemTotalPrice)).ToString();
                //taCheckOrderInfo.PayDiscount = CommonDAL.GetTaDiscount(ORDER_TYPE, Convert.ToDecimal(taCheckOrderInfo.MenuAmount)).ToString();
                taCheckOrderInfo.TotalAmount = CommonDAL.GetTotalAmount(Convert.ToDecimal(taCheckOrderInfo.MenuAmount), Convert.ToDecimal(CommonDAL.GetTaDiscount(ORDER_TYPE, Convert.ToDecimal(taCheckOrderInfo.MenuAmount)))).ToString();
                taCheckOrderInfo.StaffID = usrID;
                taCheckOrderInfo.PayTime = DateTime.Now.ToString();
                _control.UpdateEntity(taCheckOrderInfo);
            }
            else
            {
                taCheckOrderInfo.CheckCode = checkID;
                taCheckOrderInfo.PayOrderType = ORDER_TYPE;
                taCheckOrderInfo.PayDelivery = "0.00";
                taCheckOrderInfo.MenuAmount = lstTaOI.Sum(s => Convert.ToDecimal(s.ItemTotalPrice)).ToString();
                //taCheckOrderInfo.PayDiscount = CommonDAL.GetTaDiscount(ORDER_TYPE, Convert.ToDecimal(taCheckOrderInfo.MenuAmount)).ToString();

                new SystemData().GetTaDiscount();
                var lstDiscount = CommonData.TaDiscount.Where(s => s.TaType.Equals(ORDER_TYPE));
                if (lstDiscount.Any())
                {
                    taCheckOrderInfo.PayPerDiscount = @"%";
                    taCheckOrderInfo.PayDiscount = lstDiscount.FirstOrDefault().TaDiscount;
                }
                else 
                    taCheckOrderInfo.PayDiscount = @"0.00";

                taCheckOrderInfo.TotalAmount = CommonDAL.GetTotalAmount(Convert.ToDecimal(taCheckOrderInfo.MenuAmount), CommonDAL.GetTaDiscount(ORDER_TYPE, Convert.ToDecimal(taCheckOrderInfo.MenuAmount))).ToString();
                taCheckOrderInfo.Paid = "0.00";
                taCheckOrderInfo.IsPaid = "N";
                taCheckOrderInfo.CustomerID = string.IsNullOrEmpty(CallerID) ? "1" : CallerID;
                taCheckOrderInfo.CustomerNote = "";
                taCheckOrderInfo.StaffID = usrID;
                taCheckOrderInfo.PayTime = DateTime.Now.ToString();

                //taCheckOrderInfo.PayPerDiscount = "";
                //taCheckOrderInfo.PayDiscount = @"0.00";
                taCheckOrderInfo.PayPerSurcharge = "";
                taCheckOrderInfo.PaySurcharge = @"0.00";
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

                _control.AddEntity(taCheckOrderInfo);
            }
        }
        #endregion

        #region 设置打印相关信息

        private Hashtable SetPrtInfo(List<TaOrderItemInfo> lstOi)
        {
            Hashtable htDetail = new Hashtable();

            new SystemData().GetUsrBase();

            htDetail["Staff"] = CommonData.UsrBase.Any(s => s.ID == usrID) ? CommonData.UsrBase.FirstOrDefault(s => s.ID == usrID).UsrName : "";

            htDetail["ItemQty"] = treeListOrder.Nodes.Count;
            htDetail["SubTotal"] = lstOi.Sum(s => Convert.ToDecimal(s.ItemTotalPrice)).ToString();
            htDetail["Total"] = lstOi.Sum(s => Convert.ToDecimal(s.ItemTotalPrice)).ToString();

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
                if (CommonTool.ConfirmMessage("Are you sure you want to cancel the order?") == DialogResult.OK)
                {
                    treeListOrder.Nodes.Clear();
                }
            }

            this.Close();
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

                    //改码
                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_APPEND.ToString()))
                    {
                        if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(treeListNode["ItemCode"])))
                        {
                            treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString().Split(' ')[0] + " " + CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiEngName;
                        }
                        else if (CommonData.TaMenuItemOtherChoice.Any(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString())))
                        {
                            treeListNode["ItemDishName"] = CommonData.TaMenuItemOtherChoice.FirstOrDefault(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString()))?.MiEngName;
                        }
                        else if (CommonData.TaExtraMenu.Any(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString())))
                        {
                            treeListNode["ItemDishName"] = CommonData.TaExtraMenu.FirstOrDefault(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString()))?.eMenuEngName;
                        }
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

                    //改码
                    if (treeListNode["ItemType"].ToString().Equals(PubComm.MENU_ITEM_APPEND.ToString()))
                    {
                        if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(treeListNode["ItemCode"])))
                        {
                            treeListNode["ItemDishName"] = treeListNode["ItemDishName"].ToString().Split(' ')[0] + " " + CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(treeListNode["ItemCode"]))?.MiOtherName;
                        }
                        else if (CommonData.TaMenuItemOtherChoice.Any(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString())))
                        {
                            treeListNode["ItemDishName"] = CommonData.TaMenuItemOtherChoice.FirstOrDefault(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString()))?.MiOtherName;
                        }
                        else if (CommonData.TaExtraMenu.Any(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString())))
                        {
                            treeListNode["ItemDishName"] = CommonData.TaExtraMenu.FirstOrDefault(s => s.ID.ToString().Equals(treeListNode["ItemCode"].ToString()))?.eMenuOtherName;
                        }
                    }
                }
            }
        }
        #endregion

        private void SetListNode(TaMenuItemInfo taMenuItemInfo, int iQ)
        {
            //套餐
            if (taMenuItemInfo.MiRmk.Contains("Set Meal"))
            {
                //判断是否存在相同菜品
                //若存在，则合并，并对数量+1
                if (treeListOrder.Nodes.Any(s => s["ItemCode"].Equals(taMenuItemInfo.MiDishCode) && s["ItemType"].ToString().Equals("1")))
                {
                    foreach (TreeListNode treeListNode in treeListOrder.Nodes.Where(s => s["ItemCode"].Equals(taMenuItemInfo.MiDishCode) && s["ItemType"].ToString().Equals("1")))
                    {
                        //if (treeListNode["ItemCode"].ToString().Equals(taMenuItemInfo.MiDishCode))
                        //btnAdd_Click(sender, e);
                        treeListOrder.BeginUpdate();
                        decimal dQty = Convert.ToDecimal(treeListNode["ItemQty"]);
                        decimal dPrice = Convert.ToDecimal(treeListNode["ItemTotalPrice"]);

                        if (dQty > 1)
                        {
                            treeListNode["ItemQty"] = (dQty + iQ).ToString();
                            treeListNode["ItemTotalPrice"] = ((dPrice / dQty) * (dQty + iQ)).ToString("0.00");

                            GetChildNodes(treeListOrder.FocusedNode, Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"]));
                        }
                        else
                        {
                            treeListNode["ItemQty"] = (dQty + iQ).ToString();
                            treeListNode["ItemTotalPrice"] = (dPrice * (dQty + iQ)).ToString();

                            GetChildNodes(treeListOrder.FocusedNode, Convert.ToDecimal(treeListOrder.FocusedNode["ItemQty"]));
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
                    string sEngName = "";
                    string sOtherName = "";
                    decimal sPrice = 0.00m;
                    GetOtherChoices(taMenuItemInfo.ID, out sEngName, out sOtherName, out sPrice);
                    taOrderItemInfo.ItemDishName = taMenuItemInfo.MiEngName;
                    taOrderItemInfo.ItemDishOtherName = taMenuItemInfo.MiOtherName;
                    taOrderItemInfo.ItemQty = iQty.ToString();
                    taOrderItemInfo.ItemPrice = (Convert.ToDecimal(taMenuItemInfo.MiRegularPrice) + sPrice).ToString("0.00");
                    taOrderItemInfo.ItemTotalPrice = (iQty * Convert.ToDecimal(taOrderItemInfo.ItemPrice)).ToString("0.00");
                    taOrderItemInfo.CheckCode = checkID;
                    taOrderItemInfo.ItemType = PubComm.MENU_ITEM_MAIN;
                    taOrderItemInfo.ItemParent = "0";
                    //taOrderItemInfo.ItemParent = Convert.ToInt32(taMenuItemInfo.ID);
                    taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                    taOrderItemInfo.OrderStaff = usrID;

                    TreeListNode node = AddTreeListNode(taOrderItemInfo);

                    //Sub Menu的子菜品
                    GetMenuItemSubMenu(taMenuItemInfo.ID, iQty.ToString(), checkID, taOrderItemInfo.ItemID, node);

                    //Second/Third Choices
                    SetAllOtherChoice(taMenuItemInfo.ID, iQty.ToString(), checkID, taOrderItemInfo.ItemID, node, true);
                }
            }
            else//非套餐
            {
                //判断是否存在相同菜品
                //若存在，则合并，并对数量+1
                if (treeListOrder.Nodes.Any(s => s["ItemCode"].Equals(taMenuItemInfo.MiDishCode) && s["ItemType"].ToString().Equals("1")))
                {
                    foreach (TreeListNode treeListNode in treeListOrder.Nodes.Where(s => s["ItemCode"].Equals(taMenuItemInfo.MiDishCode) && s["ItemType"].ToString().Equals("1")))
                    {
                        //if (treeListNode["ItemCode"].ToString().Equals(taMenuItemInfo.MiDishCode))
                        //btnAdd_Click(sender, e);
                        treeListOrder.BeginUpdate();
                        decimal dQty = Convert.ToDecimal(treeListNode["ItemQty"]);
                        decimal dPrice = Convert.ToDecimal(treeListNode["ItemTotalPrice"]);

                        if (dQty > 1)
                        {
                            treeListNode["ItemQty"] = (dQty + iQ).ToString();
                            treeListNode["ItemTotalPrice"] = ((dPrice / dQty) * (dQty + iQ)).ToString();
                        }
                        else
                        {
                            treeListNode["ItemQty"] = (dQty + iQ).ToString();
                            treeListNode["ItemTotalPrice"] = (dPrice * (dQty + iQ)).ToString();
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
                    string sEngName = "";
                    string sOtherName = "";
                    decimal sPrice = 0.00m;
                    GetOtherChoices(taMenuItemInfo.ID, out sEngName, out sOtherName, out sPrice);
                    taOrderItemInfo.ItemDishName = taMenuItemInfo.MiEngName + sEngName;
                    taOrderItemInfo.ItemDishOtherName = taMenuItemInfo.MiOtherName + sOtherName;
                    taOrderItemInfo.ItemQty = iQty.ToString();
                    taOrderItemInfo.ItemPrice = (Convert.ToDecimal(taMenuItemInfo.MiRegularPrice) + sPrice).ToString("0.00");
                    taOrderItemInfo.ItemTotalPrice = (iQty * Convert.ToDecimal(taOrderItemInfo.ItemPrice)).ToString();
                    taOrderItemInfo.CheckCode = checkID;
                    taOrderItemInfo.ItemType = PubComm.MENU_ITEM_MAIN;
                    taOrderItemInfo.ItemParent = "0";
                    //taOrderItemInfo.ItemParent = Convert.ToInt32(taMenuItemInfo.ID);
                    taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                    taOrderItemInfo.OrderStaff = usrID;

                    TreeListNode node = AddTreeListNode(taOrderItemInfo);

                    //Second/Third Choices
                    SetAllOtherChoice(taMenuItemInfo.ID, iQty.ToString(), checkID, taOrderItemInfo.ItemID, node, false);
                }
            }
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
            FrmTaKeyPad frmTaKeyPad = new FrmTaKeyPad();

            if (frmTaKeyPad.ShowDialog() == DialogResult.OK)
            {
                string sDishCode = frmTaKeyPad.DisCode;
                string sQty = frmTaKeyPad.Qty;

                if (!string.IsNullOrEmpty(sDishCode))
                {
                    if (CommonData.TaMenuItem.Any(s => s.MiDishCode.Equals(sDishCode)))
                    {
                        string sWord = CommonData.TaMenuItem.FirstOrDefault(s => s.MiDishCode.Equals(sDishCode)).MiEngName;
                        TaMenuItemInfo taMenuItemInfo = GetMenuItemInfo(sWord, iMenuCateId, iMenuSetId);

                        SetListNode(taMenuItemInfo, Convert.ToInt32(sQty));
                    }
                }
            }
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

                    FrmTaChangePrice frmTaChangePrice = new FrmTaChangePrice(treeListOrder.FocusedNode["ItemCode"].ToString(), dPrice.ToString());

                    string sNewPrice = dPrice.ToString();

                    string sNewName = "";

                    if (frmTaChangePrice.ShowDialog() == DialogResult.OK)
                    {
                        sNewPrice = frmTaChangePrice.NewPrice;
                        sNewName = frmTaChangePrice.MenuAttr;

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

                        if (!string.IsNullOrEmpty(sNewName))
                        {
                            treeListOrder.FocusedNode["ItemDishName"] += sNewName;
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
            FrmCaller frmCaller = new FrmCaller(usrID);

            if (frmCaller.ShowDialog() == DialogResult.OK)
            {
                string sCallNum = frmCaller.CallNum;
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
                lblName.Text = "";
                lblPhone.Text = "";
                lblAddress.Text = "";
                lblPostcode.Text = "";
                lblDistance.Text = "";
                lblDiliveryFee.Text = "";
            }
            else
            {
                new SystemData().GetTaCustomer();

                var lstCust = CommonData.TaCustomer.Where(s => s.ID == cID);

                if (lstCust.Any())
                {
                    TaCustomerInfo taCustomerInfo = lstCust.FirstOrDefault();

                    lblName.Text = taCustomerInfo.cusName;
                    lblPhone.Text = taCustomerInfo.cusPhone;
                    lblAddress.Text = taCustomerInfo.cusAddr;
                    lblPostcode.Text = taCustomerInfo.cusPostcode;
                    lblDistance.Text = taCustomerInfo.cusDistance;
                    lblDiliveryFee.Text = taCustomerInfo.cusDelCharge;
                }
                else
                {
                    lblName.Text = "";
                    lblPhone.Text = "";
                    lblAddress.Text = "";
                    lblPostcode.Text = "";
                    lblDistance.Text = "";
                    lblDiliveryFee.Text = "";
                }
            }
        }

        private void panelMember_Click(object sender, EventArgs e)
        {
            if (CustID <= 0)
            {
                FrmTaCustomerInfo frmTaCustomerInfo = new FrmTaCustomerInfo();

                if (frmTaCustomerInfo.ShowDialog() == DialogResult.OK)
                {
                    TaCustomerInfo taCustomerInfo = new TaCustomerInfo();
                    taCustomerInfo = frmTaCustomerInfo.CustomerInfo;

                    if (taCustomerInfo == null)
                    {
                        lblName.Text = "";
                        lblPhone.Text = "";
                        lblAddress.Text = "";
                        lblPostcode.Text = "";
                        lblDistance.Text = "";
                        lblDiliveryFee.Text = "";
                    }
                    else
                    {
                        lblName.Text = taCustomerInfo.cusName;
                        lblPhone.Text = taCustomerInfo.cusPhone;
                        lblAddress.Text = taCustomerInfo.cusAddr;
                        lblPostcode.Text = taCustomerInfo.cusPostcode;
                        lblDistance.Text = taCustomerInfo.cusDistance;
                        lblDiliveryFee.Text = taCustomerInfo.cusDelCharge;
                    }
                    
                }
            }
        }

        #region 返回Other Choices的AutoAppend
        private void GetOtherChoices(int miId, out string miEngName, out string miOtherName, out decimal miPrice)
        {
            miEngName = "";
            miOtherName = "";
            miPrice = 0.00m;

            new SystemData().GetTaMenuItemOtherChoice();

            var lstOther = CommonData.TaMenuItemOtherChoice.Where(s => s.MiID == miId && s.IsAutoAppend.Equals("Y") && s.IsEnableChoice.Equals("Y"));

            foreach (var taMenuItemOtherChoiceInfo in lstOther)
            {
                miEngName += " " + taMenuItemOtherChoiceInfo.MiEngName;
                miOtherName += " " + taMenuItemOtherChoiceInfo.MiOtherName;
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
        private void GetChildNodes(TreeListNode parentNode, decimal dQty)
        {
            if (parentNode.Nodes.Count > 0)
            {
                foreach (TreeListNode node in parentNode.Nodes)
                {
                    if (node.Nodes.Count == 0)
                    {
                        //Console.WriteLine(node.GetValue("ItemQty"));
                        node.SetValue("ItemQty", dQty.ToString("0.00"));
                        node.SetValue("ItemTotalPrice", (dQty * Convert.ToDecimal(node.GetValue("ItemPrice"))).ToString("0.00"));
                        
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
                    taOrderItemInfo.ItemCode = taMenuItemSubMenuInfo.ID.ToString();
                    taOrderItemInfo.ItemDishName = taMenuItemSubMenuInfo.SmEngName;
                    taOrderItemInfo.ItemDishOtherName = taMenuItemSubMenuInfo.SmOtherName;
                    taOrderItemInfo.ItemQty = miQty;
                    taOrderItemInfo.ItemPrice = "0.00";
                    taOrderItemInfo.ItemTotalPrice = "0.00";
                    taOrderItemInfo.CheckCode = miCheckCode;
                    taOrderItemInfo.ItemType = PubComm.MENU_ITEM_CHILD;
                    taOrderItemInfo.ItemParent = itemId;
                    taOrderItemInfo.OrderTime = DateTime.Now.ToString();
                    taOrderItemInfo.OrderStaff = usrID;

                    lstMi.Add(taOrderItemInfo);
                }

                if (lstMi.Any())
                {
                    foreach (var orderItemInfo in lstMi) { AddTreeListChild(orderItemInfo, node); }
                }
            }
        }
        #endregion
    }
}