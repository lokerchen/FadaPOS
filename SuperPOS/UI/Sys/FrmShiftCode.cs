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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SuperPOS.Common;

namespace SuperPOS.UI.Sys
{
    public partial class FrmShiftCode : DevExpress.XtraEditors.XtraForm
    {
        //用户ID
        public int usrID = 0;
        //用户姓名
        public string usrName = "";

        public FrmShiftCode()
        {
            InitializeComponent();
        }

        public FrmShiftCode(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        private void FrmShiftCode_Load(object sender, EventArgs e)
        {
            BindData();
        }

        #region 单元格双击事件
        private void gcShiftCode_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs arg = e as MouseEventArgs;

            if (arg == null) return;

            //获取鼠标坐标
            GridHitInfo hitInfo = gvShiftCode.CalcHitInfo(new Point(arg.X, arg.Y));

            if (hitInfo.RowHandle >= 0)
            {
                FrmShiftCodeDetail frmShiftCodeDetail = new FrmShiftCodeDetail(Convert.ToInt32(gvShiftCode.GetRowCellValue(gvShiftCode.FocusedRowHandle, "ID")));
                frmShiftCodeDetail.ShowDialog();

                BindData();
            }
        }
        #endregion

        #region 绑定/刷新数据
        /// <summary>
        /// 绑定/刷新数据
        /// </summary>
        private void BindData()
        {
            new SystemData().GetTaShiftCodeList();

            gcShiftCode.DataSource = CommonData.TaShiftCodeList;
        }
        #endregion

        #region 显示Grid行号
        private void gvShiftCode_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #endregion
    }
}