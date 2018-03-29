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

namespace SuperPOS.UI.Sys
{
    public partial class FrmShiftCodeDetail : DevExpress.XtraEditors.XtraForm
    {
        //添加/更新状态，默认为新增
        private bool isAdd = false;
        //Shift Code ID
        private int iShiftCodeID = 0;

        private readonly EntityControl _control = new EntityControl();

        public FrmShiftCodeDetail()
        {
            InitializeComponent();
        }

        public FrmShiftCodeDetail(int ID)
        {
            InitializeComponent();
            iShiftCodeID = ID;
        }

        #region 窗体加载事件
        private void FrmShiftCodeDetail_Load(object sender, EventArgs e)
        {
            if (iShiftCodeID != 0)
            {
                new SystemData().GetTaShiftCodeList();

                var lstSC = CommonData.TaShiftCodeList.Where(s => s.ID == iShiftCodeID);

                if (lstSC.Any())
                {
                    //设置check box星期状态
                    chkEnable(true);

                    #region 赋值
                    TAShiftCodeInfo taShiftCodeInfo = lstSC.FirstOrDefault();

                    txtShiftCode.Text = taShiftCodeInfo.ShiftCode;
                    txtShiftName.Text = taShiftCodeInfo.ShiftName;
                    txtOtherName.Text = taShiftCodeInfo.OtherName;
                    dtpFrom.Text = taShiftCodeInfo.DtFrom;
                    dtpEnd.Text = taShiftCodeInfo.DtEnd;
                    chkIsSpecialPrice.Checked = taShiftCodeInfo.IsSpecial.Equals("Y");

                    if (!taShiftCodeInfo.IsSpecial.Equals("Y")) chkEnable(false);
                    else
                    {
                        var weekDetail = taShiftCodeInfo.SpecialContent.Split(',');

                        if (weekDetail.Length > 0) SetAllChkChecked(false);
                        foreach (var weekName in weekDetail)
                        {
                            SetChkChecked(weekName);
                        }
                    }


                    #endregion
                }
            }
        }
        #endregion

        #region 添加事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtShiftCode.Text = "";
            txtShiftName.Text = "";
            txtOtherName.Text = "";
            dtpFrom.Text = DateTime.Now.ToShortTimeString();
            dtpEnd.Text = DateTime.Now.ToShortTimeString();
            chkIsSpecialPrice.Checked = false;

            chkEnable(false);

            isAdd = true;
        }
        #endregion

        #region 删除事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CommonTool.ConfirmDelete() == DialogResult.Cancel) return;
            else
            {
                _control.DeleteEntity(CommonData.TaShiftCodeList.FirstOrDefault(s => s.ID == iShiftCodeID));
                Hide();
            }
        }
        #endregion

        #region 保存事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 判断必须字段
            if (string.IsNullOrEmpty(txtShiftCode.Text))
            {
                CommonTool.ShowMessage("Shift code is empty,please enter!");
                return;
            }
            if (string.IsNullOrEmpty(txtShiftName.Text))
            {
                CommonTool.ShowMessage("Shift name is empty,please enter!");
                return;
            }
            if (string.IsNullOrEmpty(txtOtherName.Text))
            {
                CommonTool.ShowMessage("Other name is empty,please enter!");
                return;
            }

            //未完成验证时间

            ////验证时间
            //if (!CommonData.TaShiftCodeList.Any(
            //        sc => TimeCompare(Convert.ToDateTime(dtpFrom.Text), Convert.ToDateTime(dtpEnd.Text),
            //            Convert.ToDateTime(sc.DtFrom), Convert.ToDateTime(sc.DtEnd))))
            //{
            //    CommonTool.ShowMessage("Time setting error, please re-enter！");
            //    return;
            //}
            #endregion

            #region 添加对象
            TAShiftCodeInfo taShiftCodeInfo = new TAShiftCodeInfo();

            taShiftCodeInfo.ShiftCode = txtShiftCode.Text;
            taShiftCodeInfo.ShiftName = txtShiftName.Text;
            taShiftCodeInfo.OtherName = txtOtherName.Text;
            taShiftCodeInfo.DtFrom = dtpFrom.Value.ToShortTimeString();
            taShiftCodeInfo.DtEnd = dtpEnd.Value.ToShortTimeString();
            taShiftCodeInfo.IsSpecial = chkIsSpecialPrice.Checked ? "Y" : "N";

            if (chkIsSpecialPrice.Checked)
            {
                StringBuilder sb = new StringBuilder();
                if (chkMon.Checked) sb.Append("Mon,");
                if (chkTues.Checked) sb.Append("Tues,");
                if (chkWed.Checked) sb.Append("Wed,");
                if (chkThur.Checked) sb.Append("Thur,");
                if (chkFri.Checked) sb.Append("Fri,");
                if (chkSat.Checked) sb.Append("Sat,");
                if (chkSun.Checked) sb.Append("Sun,");
                taShiftCodeInfo.SpecialContent = sb.ToString();
            }
            #endregion

            try
            {
                if (isAdd) _control.AddEntity(taShiftCodeInfo); //新增
                else
                {
                    taShiftCodeInfo.ID = iShiftCodeID;
                    _control.UpdateEntity(taShiftCodeInfo); //更新
                }
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");
            Hide();
            

        }
        #endregion

        #region 退出事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        #endregion

        #region Special Price按钮切换选择状态事件
        private void chkIsSpecialPrice_CheckedChanged(object sender, EventArgs e)
        {
            chkEnable(chkIsSpecialPrice.Checked);

            if (!chkIsSpecialPrice.Checked) SetAllChkChecked(false);
        }
        #endregion

        #region 设置具体某个星期控件是否被选中
        /// <summary>
        /// 设置具体某个控件是否被选中
        /// </summary>
        /// <param name="sName">是/否被选中</param>
        private void SetChkChecked(string sName)
        {
            switch (sName)
            {
                case "Mon":
                    chkMon.Checked = true;
                    break;
                case "Tues":
                    chkTues.Checked = true;
                    break;
                case "Wed":
                    chkWed.Checked = true;
                    break;
                case "Thur":
                    chkThur.Checked = true;
                    break;
                case "Fri":
                    chkFri.Checked = true;
                    break;
                case "Sat":
                    chkSat.Checked = true;
                    break;
                case "Sun":
                    chkSun.Checked = true;
                    break;
            }
        }
        #endregion

        #region 设置所有星期控件是否被选中
        /// <summary>
        /// 设置所有星期控件是否被选中
        /// </summary>
        /// <param name="isTrueFalse">是/否被选中</param>
        private void SetAllChkChecked(bool isTrueFalse)
        {
            chkMon.Checked = isTrueFalse;
            chkTues.Checked = isTrueFalse;
            chkWed.Checked = isTrueFalse;
            chkThur.Checked = isTrueFalse;
            chkFri.Checked = isTrueFalse;
            chkSat.Checked = isTrueFalse;
            chkSun.Checked = isTrueFalse;
        }
        #endregion

        #region 设置星期check box的状态
        /// <summary>
        /// 设置星期check box的状态
        /// </summary>
        /// <param name="isTrueFalse">设置是否可访问</param>
        private void chkEnable(bool isTrueFalse)
        {
            chkMon.Enabled = isTrueFalse;
            chkTues.Enabled = isTrueFalse;
            chkWed.Enabled = isTrueFalse;
            chkThur.Enabled = isTrueFalse;
            chkFri.Enabled = isTrueFalse;
            chkSat.Enabled = isTrueFalse;
            chkSun.Enabled = isTrueFalse;
        }
        #endregion

        #region 判断时间范围

        public bool TimeCompare(DateTime rangStartTime, DateTime rangeEndTime, DateTime startTime, DateTime endTime)
        {
            //单点区间相同
            if (rangStartTime >= rangeEndTime || startTime >= endTime)
            {
                return false;
            }
            if (DateTime.Compare(rangStartTime, startTime) == 0 ||
                DateTime.Compare(rangStartTime, endTime) == 0 ||
                DateTime.Compare(rangeEndTime, endTime) == 0)
            {
                return false;
            }
            //一点落在区间内
            //左区间
            if (DateTime.Compare(rangStartTime, startTime) < 0 &&
                DateTime.Compare(rangeEndTime, startTime) > 0 &&
                DateTime.Compare(rangStartTime, endTime) < 0 &&
                DateTime.Compare(rangeEndTime, endTime) < 0)
            {
                return false;
            }
            //右区间
            if (DateTime.Compare(rangStartTime, startTime) > 0 &&
                DateTime.Compare(rangStartTime, endTime) < 0 &&
                DateTime.Compare(rangeEndTime, endTime) > 0)
            {
                return false;
            }
            //两点同时落在区间内
            //被区间包含
            if (DateTime.Compare(rangStartTime, startTime) < 0 &&
                DateTime.Compare(rangeEndTime, endTime) > 0)
            {
                return false;
            }
            //包含区间
            if (DateTime.Compare(rangStartTime, startTime) > 0 &&
                DateTime.Compare(rangeEndTime, endTime) < 0)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}