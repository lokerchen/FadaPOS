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

        private TextEdit[] txtGsPayType = new TextEdit[5];
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
            txtGsPayType[4] = txtPayType5;

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

            SetData(this.xtpTaConfig.SelectedTabPage.Name);

            asfc.controllInitializeSize(this);
        }

        private void FrmTaConf_SizeChanged(object sender, EventArgs e)
        {
            asfc.controlAutoSize(this);
        }

        private void SetData(string sPagName)
        {
            SystemData systemData = new SystemData();
            systemData.GetTaPaymentType();
            systemData.GetSysValue();
            systemData.GetTaFreeFood();
            systemData.GetTaDiscount();
            systemData.GetTaConfMenuDisplayFont();
            systemData.GetTaDeliverySetDetail();
            systemData.GetTaDeliverySet();

            if (sPagName.Equals("xtpGs"))
            {
                #region Payment Type
                int i = 0;
                foreach (var taPaymentTypeInfo in CommonData.TaPaymentType)
                {
                    txtGsPayType[i].Text = taPaymentTypeInfo.PaymentType;
                    i++;
                }

                for (int j = i; j < 5; j++)
                {
                    txtGsPayType[j].Text = "";
                }
                #endregion

                txtTotalAmountThreshold.Text = CommonDAL.GetSysValue(PubComm.SYS_VALUE_FREE_FOOD_ITEM_AMOUNT, PubComm.SYS_DESC_FREE_FOOD_ITEM_AMOUNT, "");

                #region Freed Food
                i = 0;
                foreach (var freeFood in CommonData.TaFreeFood)
                {
                    txtGsFreeFoodItem[i].Text = freeFood.DishCode;
                    i++;
                }

                for (int j = i; j < 4; j++)
                {
                    txtGsFreeFoodItem[j].Text = "";
                }
                #endregion

                #region Discount
                foreach (var taDiscountInfo in CommonData.TaDiscount)
                {
                    switch (taDiscountInfo.TaType)
                    {
                        case "DELIVERY":
                            txtDeliveryDiscount.Text = taDiscountInfo.TaDiscount;
                            txtDeliveryDiscountThreshold.Text = taDiscountInfo.TaDiscThre;
                            break;
                        case "COLLECTION":
                            txtCollectionDiscount.Text = taDiscountInfo.TaDiscount;
                            txtCollectionDiscountThreshold.Text = taDiscountInfo.TaDiscThre;
                            break;
                        case "SHOP":
                            txtShopDiscount.Text = taDiscountInfo.TaDiscount;
                            txtShopDiscountThreshold.Text = taDiscountInfo.TaDiscThre;
                            break;
                    }
                }
                #endregion

                #region Menu Display Font
                foreach (var taConfMenuDisplayFontInfo in CommonData.TaConfMenuDisplayFont)
                {
                    txtMenuDishBtnFontSize.Text = taConfMenuDisplayFontInfo.MenuDisplayBtnFontSize;
                    chkGsMenuDishCodeFontBold.Checked = taConfMenuDisplayFontInfo.IsMenuDishCodeFontBold.Equals("Y");
                    txtCategoryBtnFontSize.Text = taConfMenuDisplayFontInfo.CategBtnFontSize;
                    chkGsCategBtnFontBold.Checked = taConfMenuDisplayFontInfo.IsCategFontBold.Equals("Y");
                }
                #endregion
            }
            else //xtpDs
            {
                #region Delivery Distance Charge
                int i = 0;
                foreach (var taDeliverySetDetail in CommonData.TaDeliverySetDetail)
                {
                    txtDsDistanceFrom[i].Text = taDeliverySetDetail.DistFrom;
                    txtDsDistanceTo[i].Text = taDeliverySetDetail.DistTo;
                    txtDsAmountToPay[i].Text = taDeliverySetDetail.AmountToPay;
                    i++;
                }

                for (int j = i; j < 4; j++)
                {
                    txtDsDistanceFrom[i].Text = "";
                    txtDsDistanceTo[i].Text = "";
                    txtDsAmountToPay[i].Text = "";
                }
                #endregion

                #region Delivery Set
                new SystemData().GetTaDeliverySet();

                var lstTds = CommonData.TaDeliverySet.ToList();

                if (lstTds.Any())
                {
                    TaDeliverySetInfo taDeliverySetInfo = lstTds.FirstOrDefault();
                    txtPerMile.Text = taDeliverySetInfo.PerMile;
                    chkDeliveryChge.Checked = taDeliverySetInfo.IsDeliveryCharge.Equals("Y");
                    txtMile.Text = taDeliverySetInfo.DeliveryMile;
                    chkIgnoreDelivery.Checked = taDeliverySetInfo.IsIgnoreDelivery.Equals("Y");
                    txtOrderThreshold.Text = taDeliverySetInfo.OrderThreshold;
                    txtSurchargeAmount.Text = taDeliverySetInfo.SurchargeAmount;
                }
                else
                {
                    txtPerMile.Text = "";
                    chkDeliveryChge.Checked = false;
                    txtMile.Text = "";
                    chkIgnoreDelivery.Checked = false;
                    txtOrderThreshold.Text = "";
                    txtSurchargeAmount.Text = "";
                }
                #endregion
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveData()
        {
            try
            {
                int i = 0;

                #region General Setting

                #region Pay Type
                //foreach (var taPaymentTypeInfo in CommonData.TaPaymentType)
                //{
                //    taPaymentTypeInfo.PaymentType = txtGsPayType[i].Text;

                //    _control.UpdateEntity(taPaymentTypeInfo);

                //    i++;
                //}
                #endregion

                CommonDAL.GetSysValue(PubComm.SYS_VALUE_FREE_FOOD_ITEM_AMOUNT, PubComm.SYS_DESC_FREE_FOOD_ITEM_AMOUNT, txtTotalAmountThreshold.Text);

                #region Free Food
                i = 0;
                foreach (var taFreeFoodInfo in CommonData.TaFreeFood)
                {
                    taFreeFoodInfo.DishCode = txtGsFreeFoodItem[i].Text;

                    _control.UpdateEntity(taFreeFoodInfo);

                    i++;
                }
                #endregion

                #region Discount
                new SystemData().GetTaDiscount();

                TaDiscountInfo discount = new TaDiscountInfo();

                var lstDis = CommonData.TaDiscount.Where(s => s.TaType.Equals("DELIVERY"));
                if (lstDis.Any())
                {
                    discount = lstDis.FirstOrDefault();
                    discount.TaDiscount = txtDeliveryDiscount.Text;
                    discount.TaDiscThre = txtDeliveryDiscountThreshold.Text;

                    _control.UpdateEntity(discount);
                }
                else
                {
                    discount.TaType = "DELIVERY";
                    discount.TaDiscount = txtDeliveryDiscount.Text;
                    discount.TaDiscThre = txtDeliveryDiscountThreshold.Text;
                    _control.AddEntity(discount);
                }

                lstDis = CommonData.TaDiscount.Where(s => s.TaType.Equals("COLLECTION"));
                if (lstDis.Any())
                {
                    discount = lstDis.FirstOrDefault();
                    discount.TaDiscount = txtCollectionDiscount.Text;
                    discount.TaDiscThre = txtCollectionDiscountThreshold.Text;

                    _control.UpdateEntity(discount);
                }
                else
                {
                    discount.TaType = "COLLECTION";
                    discount.TaDiscount = txtCollectionDiscount.Text;
                    discount.TaDiscThre = txtCollectionDiscountThreshold.Text;
                    _control.AddEntity(discount);
                }

                lstDis = CommonData.TaDiscount.Where(s => s.TaType.Equals("SHOP"));
                if (lstDis.Any())
                {
                    discount = lstDis.FirstOrDefault();
                    discount.TaDiscount = txtShopDiscount.Text;
                    discount.TaDiscThre = txtShopDiscountThreshold.Text;

                    _control.UpdateEntity(discount);
                }
                else
                {
                    discount.TaType = "SHOP";
                    discount.TaDiscount = txtShopDiscount.Text;
                    discount.TaDiscThre = txtShopDiscountThreshold.Text;
                    _control.AddEntity(discount);
                }
                #endregion

                #region Menu Display Font
                new SystemData().GetTaConfMenuDisplayFont();

                TaConfMenuDisplayFontInfo taConfMenuDisplayFontInfo = new TaConfMenuDisplayFontInfo();

                if (CommonData.TaConfMenuDisplayFont.Any())
                {
                    taConfMenuDisplayFontInfo = CommonData.TaConfMenuDisplayFont.FirstOrDefault();
                    taConfMenuDisplayFontInfo.MenuDisplayBtnFontSize = txtMenuDishBtnFontSize.Text;
                    taConfMenuDisplayFontInfo.IsMenuDishCodeFontBold = chkGsMenuDishCodeFontBold.Checked ? "Y" : "N";
                    taConfMenuDisplayFontInfo.CategBtnFontSize = txtCategoryBtnFontSize.Text;
                    taConfMenuDisplayFontInfo.IsCategFontBold = chkGsCategBtnFontBold.Checked ? "Y" : "N";
                    _control.UpdateEntity(taConfMenuDisplayFontInfo);
                }
                else
                {
                    _control.AddEntity(taConfMenuDisplayFontInfo);
                }
                #endregion

                #endregion

                #region Delivery Setting

                #region Delivery Distance Chage
                new SystemData().GetTaDeliverySetDetail();
                TaDeliverySetDetailInfo taDeliverySetDetail = new TaDeliverySetDetailInfo();

                i = 0;
                foreach (var taDeliverySetDetailInfo in CommonData.TaDeliverySetDetail)
                {
                    taDeliverySetDetailInfo.DistFrom = txtDsDistanceFrom[i].Text;
                    taDeliverySetDetailInfo.DistTo = txtDsDistanceTo[i].Text;
                    taDeliverySetDetailInfo.AmountToPay = txtDsAmountToPay[i].Text;

                    _control.UpdateEntity(taDeliverySetDetailInfo);

                    i++;
                }
                #endregion

                #region Other Set
                new SystemData().GetTaDeliverySet();

                var lstTds = CommonData.TaDeliverySet.ToList();

                TaDeliverySetInfo taDeliverySetInfo = new TaDeliverySetInfo();
                taDeliverySetInfo.PerMile = txtPerMile.Text;
                taDeliverySetInfo.IsDeliveryCharge = chkDeliveryChge.Checked ? "Y" : "N";
                taDeliverySetInfo.DeliveryMile = txtMile.Text;
                taDeliverySetInfo.IsIgnoreDelivery = chkIgnoreDelivery.Checked ? "Y" : "N";
                taDeliverySetInfo.OrderThreshold = txtOrderThreshold.Text;
                taDeliverySetInfo.SurchargeAmount = txtSurchargeAmount.Text;

                try
                {
                    if (lstTds.Any())
                    {
                        taDeliverySetInfo.ID = lstTds.FirstOrDefault().ID;
                        _control.UpdateEntity(taDeliverySetInfo);
                    }
                    else
                    {
                        _control.AddEntity(taDeliverySetInfo);
                    }

                }
                catch (Exception ex) { LogHelper.Error(this.Name, ex); }
                #endregion

                #endregion
            }
            catch (Exception ex) { LogHelper.Error(this.Name, ex); }

            CommonTool.ShowMessage("Save successful!");

        }

        private void xtpTaConfig_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {
            SetData(e.Page.Name);
        }
    }
}