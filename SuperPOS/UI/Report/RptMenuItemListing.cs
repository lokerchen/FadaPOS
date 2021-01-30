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

namespace SuperPOS.UI.Report
{
    public partial class RptMenuItemListing : DevExpress.XtraEditors.XtraForm
    {
        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        public RptMenuItemListing()
        {
            InitializeComponent();
        }

        private void RptMenuItemListing_Load(object sender, EventArgs e)
        {
            GetBindData();asfc.controllInitializeSize(this);
        }

        private void RptMenuItemListing_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 绑定初始数据
        /// <summary>
        /// 绑定初始数据
        /// </summary>
        /// <param name="busDate">营业日</param>
        private void GetBindData()
        {
            List<TaMenuItemInfo> lstMi = CommonData.TaMenuItem.Where(s => !s.MiMenuCateID.Contains(",")).ToList();

            List<TaMenuItemInfo> lstMi1 = CommonData.TaMenuItem.Where(s => s.MiMenuCateID.Contains(",")).ToList();

            foreach (TaMenuItemInfo taMenuItemInfo in lstMi1)
            {
                string[] strMcId = taMenuItemInfo.MiMenuCateID.Split(',');

                foreach (var s in strMcId.Where(s => !string.IsNullOrEmpty(s)))
                {
                    taMenuItemInfo.MiMenuCateID = s.Trim();
                    lstMi.Add(taMenuItemInfo);
                }
            }

            var lstDb = from mi in lstMi
                        join mc in CommonData.TaMenuCate
                        on mi.MiMenuCateID equals mc.ID.ToString()
                        select new
                        {
                            ID = mi.ID,
                            gridDishCode = mi.MiDishCode,
                            gridItemDescriptions = mi.MiEngName,
                            gridOtherLang = mi.MiOtherName,
                            gridRegPrice = mi.MiRegularPrice,
                            gridSpecialPrice = mi.MiSpecialPrice,
                            gridCategory = mc.CateEngName,
                        };

            gridControlReport.DataSource = lstDb.ToList();
            gvTaShowOrder.Columns["gridItemDescriptions"].BestFit();
            gvTaShowOrder.FocusedRowHandle = gvTaShowOrder.RowCount - 1;
        }
        #endregion
    }
}