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

namespace SuperPOS.UI.TaAdmin
{
    public partial class FrmTaConf : DevExpress.XtraEditors.XtraForm
    {
        //用户ID
        public int usrID = 0;
        //用户姓名
        public string usrName = "";

        private AutoSizeFormClass asfc = new AutoSizeFormClass();

        private readonly EntityControl _control = new EntityControl();

        private TextEdit[] txtGsPayType = new TextEdit[4];
        private TextEdit[] txtGsFreeFoodItem = new TextEdit[4];
        private TextEdit[] txtDsDistanceFrom = new TextEdit[4];
        private TextEdit[] txtDsDistanceTo = new TextEdit[4];
        private TextEdit[] txtDsAmountToPay = new TextEdit[4];



        public FrmTaConf()
        {
            InitializeComponent();
        }

        public FrmTaConf(int uID, string sName)
        {
            InitializeComponent();
            usrID = uID;
            usrName = sName;
        }

        private void FrmTaConf_Load(object sender, EventArgs e)
        {
            this.xtpTaConfig.SelectedTabPageIndex = 0;

            #region Text加载
            txtGsPayType[0] = txtPayType1;
            txtGsPayType[1] = txtPayType2;
            txtGsPayType[2] = txtPayType3;
            txtGsPayType[3] = txtPayType4;

            txtGsFreeFoodItem[0] = txtFreeFoodItem1;
            txtGsFreeFoodItem[1] = txtFreeFoodItem2;
            txtGsFreeFoodItem[2] = txtFreeFoodItem3;
            txtGsFreeFoodItem[3] = txtFreeFoodItem4;

            txtDsDistanceFrom[0] = txtDsDistanceFrom1;
            txtDsDistanceFrom[1] = txtDsDistanceFrom2;
            txtDsDistanceFrom[2] = txtDsDistanceFrom3;
            txtDsDistanceFrom[3] = txtDsDistanceFrom4;

            txtDsDistanceTo[0] = txtDsDistanceTo1;
            txtDsDistanceTo[1] = txtDsDistanceTo2;
            txtDsDistanceTo[2] = txtDsDistanceTo3;
            txtDsDistanceTo[3] = txtDsDistanceTo4;

            txtDsAmountToPay[0] = txtDsAmountToPay1;
            txtDsAmountToPay[1] = txtDsAmountToPay2;
            txtDsAmountToPay[2] = txtDsAmountToPay3;
            txtDsAmountToPay[3] = txtDsAmountToPay4;
            #endregion

            asfc.controllInitializeSize(this);
        }

        private void FrmTaConf_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }
    }
}