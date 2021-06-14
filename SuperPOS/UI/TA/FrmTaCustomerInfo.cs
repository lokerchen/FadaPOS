using Dapper;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using SuperPOS.Common;
using SuperPOS.Dapper;
using SuperPOS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SuperPOS.UI.TA
{
    public partial class FrmTaCustomerInfo : DevExpress.XtraEditors.XtraForm
    {
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

        private TextEdit objTxt = null;

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
            //BindLuePostCode();

            //if (string.IsNullOrEmpty(cusNum)) return;

            BindData("", "", "");
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
                    //luePostcode.Text = "";
                    txtPostcode.Text = "";
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

            SetClick();

            objTxt = txtPhone;

            asfc.controllInitializeSize(this);
        }
        private void gvCompCustomer_RowClick(object sender, RowClickEventArgs e)
        {
            if (isAdd) return;
            if (gvCompCustomer.RowCount < 1) return;
            else gvCompCustomer.FocusedRowHandle = gvCompCustomer.GetSelectedRows()[0];
            cusNum = txtPhone.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPhone") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPhone").ToString();
            txtName.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusName") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusName").ToString();
            txtHouseNo.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusHouseNo") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusHouseNo").ToString();
            txtAddress.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusAddr") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusAddr").ToString();
            //luePostcode.Properties.NullText = null;
            //luePostcode.Properties.NullText = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode").ToString();
            txtPostcode.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode").ToString();
            txtDistance.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDistance") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDistance").ToString();
            txtPcZone.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPcZone") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPcZone").ToString();
            string sDelCharge = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDelCharge") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDelCharge").ToString();
            txtDelCharge.Text = string.IsNullOrEmpty(sDelCharge) ? CommonDAL.GetDeliveryFee(txtDistance.Text, "0.00").ToString("0.00") : sDelCharge;
            txtReadyTime.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusReadyTime") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusReadyTime").ToString();
            //txtReadyTime.Text = "";
            txtIntNotes.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIntNotes") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIntNotes").ToString();
            txtNotesOnBill.Text = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusNotesOnBill") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusNotesOnBill").ToString();
            chkBlackListed.Checked = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIsBlack") != null && (gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusIsBlack").ToString().Equals("Y") ? true : false);
        }

        private void BindData(string sPhone, string sName, string sAddress)
        {
            //new SystemData().GetTaCustomer();
            CommonData.TaCustomer = new SQLiteDbHelper().QueryMultiByWhere<TaCustomerInfo>("Ta_Customer", "", null);

            IList<TaCustomerInfo> lstTmp = CommonData.TaCustomer;

            if (!string.IsNullOrEmpty(sPhone))
            {
                lstTmp = lstTmp.Where(s => s.cusPhone.Equals(sPhone)).ToList();
            }

            if (!string.IsNullOrEmpty(sName))
            {
                lstTmp = lstTmp.Where(s => s.cusName.Equals(sName)).ToList();
            }

            if (!string.IsNullOrEmpty(sAddress))
            {
                lstTmp = lstTmp.Where(s => s.cusAddr.Equals(sAddress)).ToList();
            }

            //gridControlCustomer.DataSource = string.IsNullOrEmpty(sPhone) ? CommonData.TaCustomer.Where(s => !string.IsNullOrEmpty(s.cusPhone)).ToList() 
            //                                                              : CommonData.TaCustomer.Where(s => s.cusPhone.Equals(sPhone) && !string.IsNullOrEmpty(s.cusPhone)).ToList();

            //var lstTmpPcs = from pcs in lstTmp
            //                select new
            //                {
            //                    //ID = pcs.ID,
            //                    Phone = pcs.cusPhone,
            //                    Name = pcs.cusName,
            //                    Address = pcs.cusAddr,
            //                    PostCode = pcs.cusPostcode,
            //                    Distance = pcs.cusDistance,
            //                    PCZone = pcs.cusPcZone,
            //                    BalckListed = pcs.cusIsBlack
            //                };
            
            gridControlCustomer.DataSource = lstTmp;

            if (!string.IsNullOrEmpty(cusNum)) gvCompCustomer.FocusedRowHandle = gvCompCustomer.RowCount - 1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            isAdd = true;
            isClear = false;

            txtPhone.Text = "";
            txtName.Text = "";
            txtHouseNo.Text = "";
            txtAddress.Text = "";
            txtPcZone.Text = "";
            txtDistance.Text = "";
            //luePostcode.Text = "";
            txtPostcode.Text = "";
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

            if (string.IsNullOrEmpty(txtPostcode.Text))
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
            //taCustomerInfo.cusPostcode = luePostcode.Text;
            taCustomerInfo.cusPostcode = txtPostcode.Text;
            taCustomerInfo.cusDistance = txtDistance.Text;
            taCustomerInfo.cusPcZone = txtPcZone.Text;
            //taCustomerInfo.cusDelCharge = (CommonDAL.GetDeliveryFee(txtDistance.Text, "0.00")).ToString("0.00"); 
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

            gridControlPostcode.Visible = false;

            BindData("", "", "");

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
                BindData("", "", "");

                if (gvCompCustomer.RowCount < 1)
                {
                    txtPhone.Text = "";
                    txtName.Text = "";
                    txtHouseNo.Text = "";
                    txtAddress.Text = "";
                    txtPcZone.Text = "";
                    txtDistance.Text = "";
                    //luePostcode.Text = "";
                    txtPostcode.Text = "";
                    txtDelCharge.Text = "";
                    txtReadyTime.Text = "";
                    txtIntNotes.Text = "";
                    txtNotesOnBill.Text = "";
                    chkBlackListed.Checked = false;
                }
            }

            isClear = false;
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
            //luePostcode.Text = "";
            txtPostcode.Text = "";
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
                        //taCustomerInfo.cusPostcode = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPostcode").ToString();
                        taCustomerInfo.cusPostcode = txtPostcode.Text;
                        taCustomerInfo.cusDistance = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDistance") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDistance").ToString();
                        taCustomerInfo.cusPcZone = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPcZone") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusPcZone").ToString();
                        //taCustomerInfo.cusDelCharge = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDelCharge") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusDelCharge").ToString();
                        taCustomerInfo.cusDelCharge = txtDelCharge.Text;
                        //taCustomerInfo.cusReadyTime = gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusReadyTime") == null ? "" : gvCompCustomer.GetRowCellValue(gvCompCustomer.FocusedRowHandle, "cusReadyTime").ToString();
                        taCustomerInfo.cusReadyTime = txtReadyTime.Text;
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
        //private void BindLuePostCode()
        //{
        //    //new SystemData().GetTaPostcodeSet();

        //    var lstPcs = from pcs in CommonData.TaPostcodeSet
        //                 select new
        //                 {
        //                     ID = pcs.ID,
        //                     PostCode = pcs.PostCode,
        //                     Address = pcs.PCAddr,
        //                     Zone = pcs.PCZone,
        //                     Distance = pcs.PCDist
        //                 };
        //    luePostcode.Properties.DataSource = lstPcs.ToList();
        //    luePostcode.Properties.DisplayMember = "PostCode";
        //    luePostcode.Properties.ValueMember = "PostCode";
        //}
        #endregion

        private void luePostcode_EditValueChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(luePostcode.Text))
            //{
            //    //new SystemData().GetTaPostcodeSet();

            //    //var lstPcs = CommonData.TaPostcodeSet.Where(s => s.PostCode.Equals(luePostcode.EditValue));

            //    string strSqlWhere = "";
            //    DynamicParameters dynamicParams = new DynamicParameters();

            //    strSqlWhere = " PostCode=@PostCode";

            //    dynamicParams.Add("PostCode", luePostcode.EditValue);

            //    var lstPcs = new SQLiteDbHelper().QueryMultiByWhere<TaPostcodeSetInfo>("Ta_Postcode_Set", strSqlWhere, dynamicParams);

            //    if (lstPcs.Any())
            //    {
            //        TaPostcodeSetInfo taPostcodeSetInfo = lstPcs.FirstOrDefault();
            //        txtPcZone.Text = taPostcodeSetInfo.PCZone;
            //        txtDistance.Text = taPostcodeSetInfo.PCDist;
            //        txtAddress.Text = taPostcodeSetInfo.PCAddr;
            //    }
            //}
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
            txtDelCharge.Text = (CommonDAL.GetDeliveryFee(txtDistance.Text, "0.00")).ToString("0.00");
        }

        #region 键盘按钮Click
        /// <summary>
        /// 键盘按钮Click
        /// </summary>
        private void SetClick()
        {
            btn1.Click += btn_Click;
            btn2.Click += btn_Click;
            btn3.Click += btn_Click;
            btn4.Click += btn_Click;
            btn5.Click += btn_Click;
            btn6.Click += btn_Click;
            btn7.Click += btn_Click;
            btn8.Click += btn_Click;
            btn9.Click += btn_Click;
            btn0.Click += btn_Click;

            btnQ.Click += btn_Click;
            btnW.Click += btn_Click;
            btnE.Click += btn_Click;
            btnR.Click += btn_Click;
            btnT.Click += btn_Click;
            btnY.Click += btn_Click;
            btnU.Click += btn_Click;
            btnI.Click += btn_Click;
            btnO.Click += btn_Click;
            btnP.Click += btn_Click;
            btnA.Click += btn_Click;
            btnS.Click += btn_Click;
            btnD.Click += btn_Click;
            btnF.Click += btn_Click;
            btnG.Click += btn_Click;
            btnH.Click += btn_Click;
            btnJ.Click += btn_Click;
            btnK.Click += btn_Click;
            btnL.Click += btn_Click;
            btnZ.Click += btn_Click;
            btnX.Click += btn_Click;
            btnC.Click += btn_Click;
            btnV.Click += btn_Click;
            btnB.Click += btn_Click;
            btnN.Click += btn_Click;
            btnM.Click += btn_Click;

            btnBack.Click += btn_Click;
            btnPoint.Click += btn_Click;
            btnEnter.Click += btn_Click;
            btnSpace.Click += btn_Click;
            btnClr.Click += btn_Click;
            btnLeft.Click += btn_Click;
            btnRight.Click += btn_Click;
        }

        #endregion

        #region 数字按钮输入事件
        private void btn_Click(object sender, EventArgs e)
        {
            var btn = (SimpleButton)sender;

            switch (btn.Name.Replace("btn", ""))
            {
                case "Back":
                    objTxt.Text = objTxt.Text.Length > 0 ? objTxt.Text.Substring(0, objTxt.Text.Length - 1) : "";
                    break;
                case "Point":
                    objTxt.Text += @".";
                    break;
                case "Enter":
                    break;
                case "Space":
                    objTxt.Text += @" ";
                    break;
                case "Clr":
                    objTxt.Text = "";
                    break;
                case "Left":
                    //objTxt.Select(1, 0);
                    break;
                case "Right":
                    break;
                default:
                    objTxt.Text += btn.Text;
                    break;
            }

            GridView gv = new GridView();
            string strColumn = "";

            if (objTxt.Name.Equals("txtPostcode"))
            {
                gridControlPostcode.Visible = true;
                gridControlPostcode.Size = gridControlCustomer.Size;
                gridControlPostcode.Location = new Point(gridControlCustomer.Location.X, gridControlCustomer.Location.Y);
                //gvPostcode.Columns["pcPostcode"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[pcPostcode] LIKE '%" + objTxt.Text + "%'");
                gv = gvPostcode;
                strColumn = "pcPostcode";
            }
            else if (objTxt.Name.Equals("txtPhone"))
            {
                gridControlPostcode.Visible = false;
                gv = gvCompCustomer;
                strColumn = "cusPhone";
            }
            else if (objTxt.Name.Equals("txtName"))
            {
                gridControlPostcode.Visible = false;
                gv = gvCompCustomer;
                strColumn = "cusName";
            }
            else if (objTxt.Name.Equals("txtAddress"))
            {
                gridControlPostcode.Visible = false;
                gv = gvCompCustomer;
                strColumn = "cusAddr";
            }
            
            if (!string.IsNullOrEmpty(strColumn))
            {
                if (isAdd) gv.Columns[strColumn].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[" + strColumn + "] LIKE '%" + objTxt.Text + "%'");
            }
            
        }
        #endregion

        #region Text文本框MouseDown事件
        private void txtPhone_MouseDown(object sender, MouseEventArgs e)
        {
            objTxt = txtPhone;

            if (isAdd) BindData(txtPhone.Text, txtName.Text, txtAddress.Text);
            else BindData("", "", "");
        }

        private void txtName_MouseDown(object sender, MouseEventArgs e)
        {
            objTxt = txtName;

            gridControlPostcode.Visible = false;

            if (isAdd) BindData(txtPhone.Text, txtName.Text, txtAddress.Text);
            else BindData("", "", "");
        }

        private void txtHouseNo_MouseDown(object sender, MouseEventArgs e)
        {
            objTxt = txtHouseNo;

            gridControlPostcode.Visible = false;

            if (isAdd) BindData(txtPhone.Text, txtName.Text, txtAddress.Text);
            else BindData("", "", "");
        }

        private void txtAddress_MouseDown(object sender, MouseEventArgs e)
        {
            objTxt = txtAddress;

            gridControlPostcode.Visible = false;

            if (isAdd) BindData(txtPhone.Text, txtName.Text, txtAddress.Text);
            else BindData("", "", "");
        }

        private void txtIntNotes_MouseDown(object sender, MouseEventArgs e)
        {
            objTxt = txtIntNotes;

            gridControlPostcode.Visible = false;

            if (isAdd) BindData(txtPhone.Text, txtName.Text, txtAddress.Text);
            else BindData("", "", "");
        }

        private void txtNotesOnBill_MouseDown(object sender, MouseEventArgs e)
        {
            objTxt = txtNotesOnBill;

            gridControlPostcode.Visible = false;

            if (isAdd) BindData(txtPhone.Text, txtName.Text, txtAddress.Text);
            else BindData("", "", "");
        }

        private void txtPostcode_MouseDown(object sender, MouseEventArgs e)
        {
            objTxt = txtPostcode;

            BindOtherData();
            //gridControlPostcode.Visible = true;
            //if (isAdd) BindData(txtPhone.Text, txtName.Text, txtAddress.Text);
            //else BindData("", "", "");
        }

        private void txtDistance_MouseDown(object sender, MouseEventArgs e)
        {
            objTxt = txtDistance;

            gridControlPostcode.Visible = false;

            if (isAdd) BindData(txtPhone.Text, txtName.Text, txtAddress.Text);
            else BindData("", "", "");
        }

        private void txtPcZone_MouseDown(object sender, MouseEventArgs e)
        {
            objTxt = txtPcZone;

            gridControlPostcode.Visible = false;

            if (isAdd) BindData(txtPhone.Text, txtName.Text, txtAddress.Text);
            else BindData("", "", "");
        }

        private void txtDelCharge_MouseDown(object sender, MouseEventArgs e)
        {
            objTxt = txtDelCharge;

            gridControlPostcode.Visible = false;

            if (isAdd) BindData(txtPhone.Text, txtName.Text, txtAddress.Text);
            else BindData("", "", "");
        }
        #endregion

        private void txtPostcode_Leave(object sender, EventArgs e)
        {
            //(gridControlCustomer.DefaultView as GridView).Columns.Clear();
            gridControlPostcode.Visible = false;

            if (isAdd) BindData(txtPhone.Text, txtName.Text, txtAddress.Text);
            else BindData("", "", "");
        }

        private void BindOtherData()
        {
            //string strSqlWhere = "";
            //DynamicParameters dynamicParams = new DynamicParameters();

            //strSqlWhere = " PostCode=@PostCode";

            //dynamicParams.Add("PostCode", luePostcode.EditValue);

            var lstPcs = new SQLiteDbHelper().QueryMultiByWhere<TaPostcodeSetInfo>("Ta_Postcode_Set", "", null);

            var lstTmpPcs = from pcs in CommonData.TaPostcodeSet
                            select new
                            {
                                pcID = pcs.ID,
                                pcPostcode = pcs.PostCode,
                                pcAddr = pcs.PCAddr,
                                pcZone = pcs.PCZone,
                                pcDist = pcs.PCDist
                            };

            gridControlPostcode.Visible = true;
            gridControlPostcode.Size = gridControlCustomer.Size;
            gridControlPostcode.Location = new Point(gridControlCustomer.Location.X, gridControlCustomer.Location.Y);

            gridControlPostcode.DataSource = lstTmpPcs;
            (gridControlPostcode.DefaultView as GridView)?.BestFitColumns();
        }

        private void gvPostcode_RowClick(object sender, RowClickEventArgs e)
        {
            txtAddress.Text = gvPostcode.GetRowCellValue(gvPostcode.FocusedRowHandle, "pcAddr") == null ? "" : gvPostcode.GetRowCellValue(gvPostcode.FocusedRowHandle, "pcAddr").ToString();
            txtPostcode.Text = gvPostcode.GetRowCellValue(gvPostcode.FocusedRowHandle, "pcPostcode") == null ? "" : gvPostcode.GetRowCellValue(gvPostcode.FocusedRowHandle, "pcPostcode").ToString();
            txtDistance.Text = gvPostcode.GetRowCellValue(gvPostcode.FocusedRowHandle, "pcDist") == null ? "" : gvPostcode.GetRowCellValue(gvPostcode.FocusedRowHandle, "pcDist").ToString();
            txtPcZone.Text = gvPostcode.GetRowCellValue(gvPostcode.FocusedRowHandle, "pcZone") == null ? "" : gvPostcode.GetRowCellValue(gvPostcode.FocusedRowHandle, "pcZone").ToString();
            string sDelCharge = gvCompCustomer.GetRowCellValue(gvPostcode.FocusedRowHandle, "cusDelCharge") == null ? "" : gvCompCustomer.GetRowCellValue(gvPostcode.FocusedRowHandle, "cusDelCharge").ToString();
            txtDelCharge.Text = string.IsNullOrEmpty(sDelCharge) ? CommonDAL.GetDeliveryFee(txtDistance.Text, "0.00").ToString("0.00") : sDelCharge;
        }
    }
}