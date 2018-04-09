using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SuperPOS.Common;
using SuperPOS.Domain.Entities;

namespace SuperPOS.UI.Sys
{
    public partial class FrmDataManager : DevExpress.XtraEditors.XtraForm
    {
        private string fileName = "";

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        //登录用户ID
        private int usrID = 0;
        //登录用户名字
        private string usrName = "";

        private readonly EntityControl _control = new EntityControl();

        public FrmDataManager()
        {
            InitializeComponent();
        }

        public FrmDataManager(int id, string sUsrName)
        {
            InitializeComponent();
            usrID = id;
            usrName = sUsrName;
        }

        private void FrmDataManager_Load(object sender, EventArgs e)
        {
            new SystemData().GetDataManager();

            if (CommonData.DataManager.Any())
            {
                var dataManager = CommonData.DataManager.FirstOrDefault();

                txtBackup.Text = dataManager.LocBackUp;
                txtRestore.Text = dataManager.LocRestore;
            }
            else
            {
                txtBackup.Text = "";
                txtRestore.Text = "";
            }

            asfc.controllInitializeSize(this);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = @"C:\";
                saveFileDialog.Filter = @"Backup Files|*.db";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    string strDb = Path.GetDirectoryName(Application.ExecutablePath) + @"\" + PubComm.DB_NAME;
                    if (File.Exists(strDb))
                    {
                        File.Copy(strDb, fileName, true);

                        txtBackup.Text = fileName;

                        SaveData();
                    }
                    else
                    {
                        MessageBox.Show("Can not backup data,Please contact Administrator!");
                        return;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can not backup data,Please contact Administrator!");
                return;
                throw;
            }

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = "C:\\";
                saveFileDialog.Filter = @"Backup Files|*.db";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    string strDb = Path.GetDirectoryName(Application.ExecutablePath) + @"\" + PubComm.DB_NAME;
                    if (File.Exists(strDb))
                    {
                        File.Copy(fileName, strDb, true);

                        txtRestore.Text = fileName;

                        SaveData();
                    }
                    else
                    {
                        MessageBox.Show("Can not restore data,Please contact Administrator!");
                        return;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can not restore data,Please contact Administrator!");
                return;
                throw;
            }
        }

        private void SaveData()
        {
            new SystemData().GetDataManager();

            if (CommonData.DataManager.Any())
            {
                var dataManager = CommonData.DataManager.FirstOrDefault();

                dataManager.LocRestore = txtRestore.Text;
                dataManager.LocBackUp = txtBackup.Text;

                _control.UpdateEntity(dataManager);
            }
            else
            {
                DataManagerInfo dataManagerInfo = new DataManagerInfo();
                dataManagerInfo.LocBackUp = txtBackup.Text;
                dataManagerInfo.LocRestore = txtRestore.Text;
                _control.AddEntity(dataManagerInfo);
            }
        }

        private void FrmDataManager_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}