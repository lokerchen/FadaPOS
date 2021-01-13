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

namespace SuperPOS.UI.TA
{
    public partial class FrmTaMenuSet : DevExpress.XtraEditors.XtraForm
    {
        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private TextBox[] txtEngName = new TextBox[4];
        private TextBox[] txtOtherName = new TextBox[4];
        private Label[] lblDelMenuContent = new Label[4];
        private Label[] lblID = new Label[4];

        //是否为Add
        private bool isAdd = false;

        public FrmTaMenuSet()
        {
            InitializeComponent();
        }

        public FrmTaMenuSet(int id, string name)
        {
            InitializeComponent();
            usrID = id;
            usrName = name;
        }

        #region Save保存事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                new SystemData().GetTaMenuSet();
                TaMenuSetInfo taMenuSetInfo = new TaMenuSetInfo();
                taMenuSetInfo.MSEngName = txtEngName[i].Text;
                taMenuSetInfo.MSOtherName = txtOtherName[i].Text;

                try
                {
                    //taMenuSetInfo.ID = Convert.ToInt32(gvTaMenuSet.GetRowCellValue(gvTaMenuSet.FocusedRowHandle, "ID"));
                    //_control.UpdateEntity(taMenuSetInfo);
                    taMenuSetInfo.ID = Convert.ToInt32(lblID[i].Text);
                    _control.UpdateEntity(taMenuSetInfo);
                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
            }

            CommonTool.ShowMessage("Save successful!");
        }
        #endregion

        #region 绑定数据源
        private void BindData()
        {
            new SystemData().GetTaMenuSet();

            //gridControlTaMenuSet.DataSource = CommonData.TaMenuSet.ToList();

            //gvTaMenuSet.FocusedRowHandle = gvTaMenuSet.RowCount - 1;
            
            int i = 0;
            foreach (var tms in CommonData.TaMenuSet)
            {
                txtEngName[i].Text = tms.MSEngName;
                txtOtherName[i].Text = tms.MSOtherName;
                lblID[i].Text = tms.ID.ToString();
                i++;
            }

            lueFrom.Properties.DataSource = CommonData.TaMenuSet.ToList();
            lueTo.Properties.DataSource = CommonData.TaMenuSet.ToList();

            lueFrom.Properties.DisplayMember = "MSEngName";
            lueFrom.Properties.ValueMember = "ID";
            lueFrom.ItemIndex = 0;

            lueTo.Properties.DisplayMember = "MSEngName";
            lueTo.Properties.ValueMember = "ID";
            lueTo.ItemIndex = 0;
        }
        #endregion

        private void FrmTaMenuSet_Load(object sender, EventArgs e)
        {
            #region 控件赋值
            txtEngName[0] = txtEngName1;
            txtEngName[1] = txtEngName2;
            txtEngName[2] = txtEngName3;
            txtEngName[3] = txtEngName4;

            txtOtherName[0] = txtOtherName1;
            txtOtherName[1] = txtOtherName2;
            txtOtherName[2] = txtOtherName3;
            txtOtherName[3] = txtOtherName4;

            lblID[0] = lbl1;
            lblID[1] = lbl2;
            lblID[2] = lbl3;
            lblID[3] = lbl4;

            lblDelMenuContent[0] = lblDeleteMenuContent1;
            lblDelMenuContent[1] = lblDeleteMenuContent2;
            lblDelMenuContent[2] = lblDeleteMenuContent3;
            lblDelMenuContent[3] = lblDeleteMenuContent4;

            lblDeleteMenuContent1.Click += DeleteMenu;
            lblDeleteMenuContent2.Click += DeleteMenu;
            lblDeleteMenuContent3.Click += DeleteMenu;
            lblDeleteMenuContent4.Click += DeleteMenu;
            #endregion
            
            BindData();

            //txtEngName[0] = txtEngName1;

            asfc.controllInitializeSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmTaMenuSet_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void DeleteMenu(object sender, EventArgs e)
        {
            //To Do Something
            Label lbl = (Label) sender;

            lbl.Enabled = false;

            new SystemData().GetTaMenuItem();

            int iNum = Convert.ToInt32(lbl.Text.Replace("lblDeleteMenuContent", ""));

            var lstMi = CommonData.TaMenuItem.Where(s => s.MiMenuSetID == iNum);

            try
            {
                foreach (var taMenuItemInfo in lstMi)
                {
                    taMenuItemInfo.MiMenuSetID = Convert.ToInt32(lueTo.EditValue);
                    _control.DeleteEntity(taMenuItemInfo);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.Name, ex);
            }

            CommonTool.ShowMessage("Delete successful!");

            lbl.Enabled = true;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (lueFrom.EditValue.Equals(lueTo.EditValue)) return;

            btnCopy.Enabled = false;

            new SystemData().GetTaMenuItem();
            new SystemData().GetTaMenuCate();

            try
            {
                var lstMi = CommonData.TaMenuItem.Where(s => s.MiMenuSetID == Convert.ToInt32(lueFrom.EditValue));

                foreach (var taMenuItemInfo in lstMi)
                {
                    taMenuItemInfo.MiMenuSetID = Convert.ToInt32(lueTo.EditValue);
                    _control.AddEntity(taMenuItemInfo);
                }

                var lstMc = CommonData.TaMenuCate.Where(s => s.MenuSetID == Convert.ToInt32(lueFrom.EditValue));
                foreach (var taMenuCateInfo in lstMc)
                {
                    taMenuCateInfo.MenuSetID = Convert.ToInt32(lueTo.EditValue);
                    _control.AddEntity(taMenuCateInfo);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.Name, ex);
            }

            CommonTool.ShowMessage("Save successful!");


            btnCopy.Enabled = true;
        }
    }
}