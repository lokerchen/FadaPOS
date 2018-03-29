using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SuperPOS.Common
{
    public class CommonTool
    {
        #region 确认对话框
        /// <summary>
        /// 确认对话框
        /// </summary>
        /// <param name="strInfo">提示信息</param>
        public static void ShowMessage(string strInfo)
        {
            XtraMessageBox.Show(strInfo, "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region 提示删除对话框
        /// <summary>
        /// 提示删除对话框
        /// </summary>
        /// <returns></returns>
        public static DialogResult ConfirmDelete()
        {
            return XtraMessageBox.Show("Are you sure delete this record?", "Infomation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        #endregion

        #region 提示对话框
        /// <summary>
        /// 提示对话框
        /// </summary>
        /// <returns></returns>
        public static DialogResult ConfirmMessage(string msg)
        {
            return XtraMessageBox.Show(msg, "Infomation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        #endregion
    }
}
