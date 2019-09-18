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
using DevExpress.XtraTreeList.Nodes;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI
{
    public partial class FrmTaShowOrder : DevExpress.XtraEditors.XtraForm
    {
        //用户ID
        private int usrID;

        //记录账单号Order No
        private string strChkOrder = "";
        //记录会员ID
        private int intCusID = 0;

        private int intChkID = 0;

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public FrmTaShowOrder()
        {
            InitializeComponent();
        }

        public FrmTaShowOrder(int uId)
        {
            InitializeComponent();

            usrID = uId;
        }

        private void FrmTaShowOrder_Load(object sender, EventArgs e)
        {
            SystemData sysData = new SystemData();

            sysData.GetTaCheckOrder();
            sysData.GetTaCustomer();
            sysData.GetUsrBase();
            sysData.GetTaOrderItem();
            sysData.GetTaPaymentDetail();

            GetBindData("");

            //加载会员信息
            GetCustInfo(intCusID);

            asfc.controllInitializeSize(this);
        }

        #region 绑定初始数据
        /// <summary>
        /// 绑定初始数据
        /// </summary>
        /// <param name="orderType">账单类型</param>
        private void GetBindData(string orderType)
        {
            var lstDb = from check in CommonData.TaCheckOrder
                        join user in CommonData.UsrBase
                            on check.StaffID equals user.ID
                        join driver in CommonData.TaDriver
                            on check.DriverID equals driver.ID
                        where check.IsPaid.Equals("Y")
                        select new
                        {
                            ID = check.ID,
                            gridOrderNo = check.CheckCode,
                            gridPayType = check.PayOrderType,
                            gridOrderType = check.PayOrderType,
                            gridOrderTime = check.PayTime,
                            gridTotal = check.TotalAmount,
                            gridDriver = driver.DriverName,
                            gridStaff = user.UsrName,
                            gridCustID = check.CustomerID                       
                        };

            gridControlTaShowOrder.DataSource = !string.IsNullOrEmpty(orderType)
                                                ? lstDb.Where(s => s.gridOrderType.Equals(orderType)).ToList()
                                                : lstDb.ToList();
            gvTaShowOrder.FocusedRowHandle = gvTaShowOrder.RowCount - 1;
        }
        #endregion

        private void gvTaShowOrder_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvTaShowOrder_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvTaShowOrder.FocusedRowHandle <= 0) return;

            intChkID = Convert.ToInt32(gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "ID").ToString());
            strChkOrder = gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridOrderNo").ToString();
            intCusID = Convert.ToInt32(gvTaShowOrder.GetRowCellValue(gvTaShowOrder.FocusedRowHandle, "gridCustID").ToString());

            //加载OrderItem信息
            InitGrid(CommonData.TaOrderItem.Where(s => s.CheckCode.Equals(strChkOrder)).ToList());

            //加载会员信息
            GetCustInfo(intCusID);
        }

        private void GetCustInfo(int cID)
        {
            if (cID <= 0)
            {
                lblCusName.Text = "";
                lblCusPhone.Text = "";
                lblCusAddr.Text = "";
                lblCusPostcode.Text = "";
                lblCusDistance.Text = "";
                lblDeliveryFee.Text = "";
            }
            else
            {
                new SystemData().GetTaCustomer();

                var lstCust = CommonData.TaCustomer.Where(s => s.ID == cID);

                if (lstCust.Any())
                {
                    TaCustomerInfo taCustomerInfo = lstCust.FirstOrDefault();

                    lblCusName.Text = taCustomerInfo.cusName;
                    lblCusPhone.Text = taCustomerInfo.cusPhone;
                    lblCusAddr.Text = taCustomerInfo.cusAddr;
                    lblCusPostcode.Text = taCustomerInfo.cusPostcode;
                    lblCusDistance.Text = taCustomerInfo.cusDistance;
                    lblDeliveryFee.Text = taCustomerInfo.cusDelCharge;
                }
                else
                {
                    lblCusName.Text = "";
                    lblCusPhone.Text = "";
                    lblCusAddr.Text = "";
                    lblCusPostcode.Text = "";
                    lblCusDistance.Text = "";
                    lblDeliveryFee.Text = "";
                }
            }
        }

        private void InitGrid(List<TaOrderItemInfo> lst)
        {
            TreeListNode node = null;

            //清除TreeList
            treeListOrder.ClearNodes();

            foreach (var taOrderItemInfo in lst)
            {
                if (taOrderItemInfo.ItemType == 1)
                    node = AddTreeListNode(taOrderItemInfo);
                else
                    AddTreeListChild(taOrderItemInfo, node);
            }
        }

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
                taOrderItemInfo.ItemID,
                taOrderItemInfo.ItemCode,
                taOrderItemInfo.ItemDishName,
                taOrderItemInfo.ItemDishOtherName,
                taOrderItemInfo.ItemQty,
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

        #region 增加TreeList节点
        private TreeListNode AddTreeListNode(TaOrderItemInfo taOrderItemInfo)
        {
            treeListOrder.BeginUnboundLoad();

            TreeListNode node = treeListOrder.AppendNode(new object[]
            {
                taOrderItemInfo.ID,
                taOrderItemInfo.ItemID,
                taOrderItemInfo.ItemCode,
                taOrderItemInfo.ItemDishName,
                taOrderItemInfo.ItemDishOtherName,
                taOrderItemInfo.ItemQty,
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
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FrmTaShowOrder_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}