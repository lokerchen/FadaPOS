using System;
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
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaCustomerInfo : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";
        //新增/更新
        private bool isAdd = false;

        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private TaCustomerInfo taCustomerInfo = new TaCustomerInfo();

        //来电号码
        private string cusNum = "";

        //电话来源号码
        private string sCallerPhoneNum = "";
        //订单总额
        private string sOrderTotal = "0.00";

        private int cusID = 0;

        // 申明要使用的dll和api
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private System.Diagnostics.Process softKey;

        private bool isClear = false;

        private string sReadyTime = "";

        public string strReadyTime
        {
            get { return sReadyTime; }
            set { strReadyTime = value; }
        }
        
        public FrmTaCustomerInfo()
        {
            InitializeComponent();
        }

        public FrmTaCustomerInfo(string sComePhoe)
        {
            InitializeComponent();
            sCallerPhoneNum = sComePhoe;
        }

        public FrmTaCustomerInfo(int cID, string sTotal)
        {
            InitializeComponent();
            cusID = cID;
            sOrderTotal = sTotal;
        }

        public TaCustomerInfo CustomerInfo
        {
            get { return taCustomerInfo; }
            set { CustomerInfo = value; }
        }

        private void FrmTaCustomerInfo_Load(object sender, EventArgs e)
        {
            BindLuePostCode();
            
            //if (string.IsNullOrEmpty(cusNum)) return;

            BindData("");
            //gvCompCustomer.BestFitColumns();

            if (CommonData.TaCustomer.Count(s => s.ID == cusID) > 0) cusNum = CommonData.TaCustomer.FirstOrDefault(s => s.ID == cusID).cusPhone;

            if (string.IsNullOrEmpty(cusNum))
            {
                if (string.IsNullOrEmpty(sCallerPhoneNum))
                {
                    txtPhone.Text = "";
                    txtName.Text = "";
                    txtHouseNo.Text = "";
                    txtAddress.Text = "";
                    txtPcZone.Text = "";
                    txtDistance.Text = "";
                    luePostcode.Text = "";
                    txtDelCharge.Text = "";
                    txtReadyTime.Text = "";
                    txtIntNotes.Text = "";
                    txtNotesOnBill.Text = "";
                    chkBlackListed.Checked = false;
                }
                else
                {
                    btnNew_Click(sender, e);
                    txtPhone.Text = sCallerPhoneNum;
                }

            }
            else
            {
                string sTemp = string.IsNullOrEmpty(sCallerPhoneNum) ? cusNum : sCallerPhoneNum;
                
                bool isExit = false;
                for (int i = 0; i < gvCompCustomer.RowCount; i++)
                {
                    string colValue = gvCompCustomer.GetRowCellValue(i, "cusPhone").ToString();

                    if (colValue.Equals(sTemp))
                    {
                        gvCompCustomer.FocusedRowHandle = i;
                        isExit = true;
                        break;
                    }
                }

                if (!isExit && !string.IsNullOrEmpty(sCallerPhoneNum))
                {
                    btnNew_Click(sender, e);
                    txtPhone.Text = sCallerPhoneNum;
                }
            }
            asfc.controllInitializeSize(this);
        }

        private void gvCompCustomer_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvCompCustomer.RowCount < 1) return;
            cusNum = txtPhone.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPhone") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPhone").ToString();
            txtName.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusName") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusName").ToString();
            txtHouseNo.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusHouseNo") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusHouseNo").ToString();
            txtAddress.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusAddr") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusAddr").ToString();
            luePostcode.Properties.NullText = null;
            luePostcode.Properties.NullText = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode").ToString();
            txtDistance.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDistance") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDistance").ToString();
            txtPcZone.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPcZone") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPcZone").ToString();
            txtDelCharge.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDelCharge") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDelCharge").ToString();
            txtReadyTime.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusReadyTime") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusReadyTime").ToString();
            txtIntNotes.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIntNotes") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIntNotes").ToString();
            txtNotesOnBill.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusNotesOnBill") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusNotesOnBill").ToString();
            chkBlackListed.Checked = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIsBlack").ToString().Equals("Y") ? true : false;
        }

        private void BindData(string sPhone)
        {
            new SystemData().GetTaCustomer();

            gridControlCustomer.DataSource = string.IsNullOrEmpty(sPhone) ? CommonData.TaCustomer.ToList() : CommonData.TaCustomer.Where(s => s.cusPhone.Equals(sPhone)).ToList();
            if (!string.IsNullOrEmpty(cusNum)) gvCompCustomer.FocusedRowHandle = gvCompCustomer.RowCount - 1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            isAdd = true;

            txtPhone.Text = "";
            txtName.Text = "";
            txtHouseNo.Text = "";
            txtAddress.Text = "";
            txtPcZone.Text = "";
            txtDistance.Text = "";
            luePostcode.Text = "";
            txtDelCharge.Text = "";
            txtReadyTime.Text = "";
            txtIntNotes.Text = "";
            txtNotesOnBill.Text = "";
            chkBlackListed.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //清空模式下直接返回，不允许保存
            if (isClear) return;

            #region 空判断
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                CommonTool.ShowMessage("Phone can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                CommonTool.ShowMessage("Name can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtHouseNo.Text))
            {
                CommonTool.ShowMessage("HouseNo. can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                CommonTool.ShowMessage("Address can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(luePostcode.Text))
            {
                CommonTool.ShowMessage("Postcode can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtDistance.Text))
            {
                CommonTool.ShowMessage("Distance can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtPcZone.Text))
            {
                CommonTool.ShowMessage("PC Zone can not empty!");
                return;
            }

            if (string.IsNullOrEmpty(txtDelCharge.Text))
            {
                CommonTool.ShowMessage("Del Charge can not empty!");
                return;
            }

            //if (string.IsNullOrEmpty(txtReadyTime.Text))
            //{
            //    CommonTool.ShowMessage("Ready Time can not empty!");
            //    return;
            //}

            //if (string.IsNullOrEmpty(txtIntNotes.Text))
            //{
            //    CommonTool.ShowMessage("Int Notes can not empty!");
            //    return;
            //}

            //if (string.IsNullOrEmpty(txtNotesOnBill.Text))
            //{
            //    CommonTool.ShowMessage("Notes On Bill can not empty!");
            //    return;
            //}
            #endregion

            TaCustomerInfo taCustomerInfo = new TaCustomerInfo();
            taCustomerInfo.cusPhone = txtPhone.Text;
            taCustomerInfo.cusName = txtName.Text;
            taCustomerInfo.cusHouseNo = txtHouseNo.Text;
            taCustomerInfo.cusAddr = txtAddress.Text;
            taCustomerInfo.cusPostcode = luePostcode.Text;
            taCustomerInfo.cusDistance = txtDistance.Text;
            taCustomerInfo.cusPcZone = txtPcZone.Text;
            taCustomerInfo.cusDelCharge = txtDelCharge.Text;
            taCustomerInfo.cusReadyTime = txtReadyTime.Text;
            taCustomerInfo.cusIntNotes = txtIntNotes.Text;
            taCustomerInfo.cusNotesOnBill = txtNotesOnBill.Text;
            taCustomerInfo.cusIsBlack = chkBlackListed.Checked ? "Y" : "N";

            try
            {
                if (isAdd) _control.AddEntity(taCustomerInfo);
                else
                {
                    taCustomerInfo.ID = Convert.ToInt32(gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "ID"));
                    _control.UpdateEntity(taCustomerInfo);
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            BindData("");

            isAdd = false;
            isClear = false;

            sReadyTime = txtReadyTime.Text;

            CommonTool.ShowMessage("Save successful!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CommonTool.ConfirmDelete() == DialogResult.Cancel)
                return;
            else
            {
                if (gvCompCustomer.RowCount < 1) return;

                _control.DeleteEntity(CommonData.TaCustomer.FirstOrDefault(s => s.ID == Convert.ToInt32(gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "ID"))));
                BindData("");

                if (gvCompCustomer.RowCount < 1)
                {
                    txtPhone.Text = "";
                    txtName.Text = "";
                    txtHouseNo.Text = "";
                    txtAddress.Text = "";
                    txtPcZone.Text = "";
                    txtDistance.Text = "";
                    luePostcode.Text = "";
                    txtDelCharge.Text = "";
                    txtReadyTime.Text = "";
                    txtIntNotes.Text = "";
                    txtNotesOnBill.Text = "";
                    chkBlackListed.Checked = false;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (gvCompCustomer.FocusedRowHandle >= 0) isClear = true;

            txtPhone.Text = "";
            txtName.Text = "";
            txtHouseNo.Text = "";
            txtAddress.Text = "";
            txtPcZone.Text = "";
            txtDistance.Text = "";
            luePostcode.Text = "";
            txtDelCharge.Text = "";
            txtReadyTime.Text = "";
            txtIntNotes.Text = "";
            txtNotesOnBill.Text = "";
            chkBlackListed.Checked = false;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void FrmTaCustomerInfo_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (gvCompCustomer.RowCount < 1) taCustomerInfo = null;
            else
            {
                if (isClear) taCustomerInfo = null;
                else
                {
                    if (string.IsNullOrEmpty(cusNum)) taCustomerInfo = null;
                    else
                    {
                        taCustomerInfo.ID = Convert.ToInt32(gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "ID") == null ? "0" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "ID").ToString());
                        taCustomerInfo.cusPhone = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPhone") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPhone").ToString();
                        taCustomerInfo.cusName = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusName") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusName").ToString();
                        taCustomerInfo.cusHouseNo = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusHouseNo") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusHouseNo").ToString();
                        taCustomerInfo.cusAddr = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusAddr") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusAddr").ToString();
                        taCustomerInfo.cusPostcode = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode").ToString();
                        taCustomerInfo.cusDistance = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDistance") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDistance").ToString();
                        taCustomerInfo.cusPcZone = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPcZone") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPcZone").ToString();
                        taCustomerInfo.cusDelCharge = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDelCharge") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDelCharge").ToString();
                        taCustomerInfo.cusReadyTime = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusReadyTime") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusReadyTime").ToString();
                        taCustomerInfo.cusIntNotes = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIntNotes") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIntNotes").ToString();
                        taCustomerInfo.cusNotesOnBill = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusNotesOnBill") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusNotesOnBill").ToString();
                    }
                }
            }
            
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnKeyBoard_Click(object sender, EventArgs e)
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
                int posX = (iActulaWidth - 828) / 2;
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

        #region 绑定Post Code
        /// <summary>
        /// 绑定Print Name
        /// </summary>
        private void BindLuePostCode()
        {
            //new SystemData().GetTaPostcodeSet();

            var lstPcs = from pcs in CommonData.TaPostcodeSet
                         select new
                         {
                             ID = pcs.ID,
                             PostCode = pcs.PostCode,
                             Address = pcs.PCAddr,
                             Zone = pcs.PCZone,
                             Distance = pcs.PCDist
                         };
            luePostcode.Properties.DataSource = lstPcs.ToList();
            luePostcode.Properties.DisplayMember = "PostCode";
            luePostcode.Properties.ValueMember = "PostCode";
        }
        #endregion

        private void luePostcode_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(luePostcode.Text))
            {
                new SystemData().GetTaPostcodeSet();

                var lstPcs = CommonData.TaPostcodeSet.Where(s => s.PostCode.Equals(luePostcode.EditValue));

                if (lstPcs.Any())
                {
                    TaPostcodeSetInfo taPostcodeSetInfo = lstPcs.FirstOrDefault();
                    txtPcZone.Text = taPostcodeSetInfo.PCZone;
                    txtDistance.Text = taPostcodeSetInfo.PCDist;
                    txtAddress.Text = taPostcodeSetInfo.PCAddr;
                }
            }
        }

        private void gvCompCustomer_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvCompCustomer.RowCount < 1) return;
            else gvCompCustomer.FocusedRowHandle = gvCompCustomer.GetSelectedRows()[0];
            cusNum = txtPhone.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPhone") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPhone").ToString();
            txtName.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusName") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusName").ToString();
            txtHouseNo.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusHouseNo") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusHouseNo").ToString();
            txtAddress.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusAddr") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusAddr").ToString();
            //luePostcode.Properties.NullText = null;
            luePostcode.EditValue = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode").ToString();
            //luePostcode.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode").ToString();
            txtDistance.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDistance") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDistance").ToString();
            txtPcZone.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPcZone") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPcZone").ToString();
            txtDelCharge.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDelCharge") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDelCharge").ToString();
            txtReadyTime.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusReadyTime") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusReadyTime").ToString();
            txtIntNotes.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIntNotes") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIntNotes").ToString();
            txtNotesOnBill.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusNotesOnBill") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusNotesOnBill").ToString();
            chkBlackListed.Checked = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIsBlack").ToString().Equals("Y") ? true : false;
        }

        private void txtReadyTime_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cusNum))
            {
                FrmTaCustReadyTime frmTaCustReadyTime = new FrmTaCustReadyTime();
                //frmTaCustReadyTime.Location = gridControlCustomer.Location;
                frmTaCustReadyTime.Location = new Point(gridControlCustomer.Location.X + 100, gridControlCustomer.Location.Y + 50);
                //frmTaCustReadyTime.Size = gridControlCustomer.Size;

                if (frmTaCustReadyTime.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(frmTaCustReadyTime.strShopTime))
                    {
                        txtReadyTime.Text = frmTaCustReadyTime.strShopTime;
                    }
                }
            }
        }

        private void txtDistance_EditValueChanged(object sender, EventArgs e)
        {
            CommonDAL.GetDeliveryFee(txtDistance.Text, "0.00");
        }
    }
}