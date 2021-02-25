using SuperPOS.Domain.Entities;

namespace SuperPOS.Common
{
    public class SystemData
    {
        private EntityControl _control;

        public SystemData() { _control = EntityControl.CreateEntityControl(); }

        public void GetTaShiftCodeList() { CommonData.TaShiftCodeList = _control.SelectAll<TAShiftCodeInfo>(); }

        public void GetUsrBase() { CommonData.UsrBase = _control.SelectAll<UsrBaseInfo>(); }

        public void GetUsrAuthAccess() { CommonData.UsrAuthAccess = _control.SelectAll<UsrAuthAccessInfo>(); }

        public void GetUsrAuthDetail() { CommonData.UsrAuthDetail = _control.SelectAll<UsrAuthDetailInfo>(); }

        public void GetUsrAuthGroup() { CommonData.UsrAuthGroup = _control.SelectAll<UsrAuthGroupInfo>(); }

        public void GetUsrAuthRule() { CommonData.UsrAuthRule = _control.SelectAll<UsrAuthRuleInfo>(); }

        public void GetCompAddr() { CommonData.CompAddr = _control.SelectAll<CompAddrInfo>(); }

        public void GetShopDetail() { CommonData.ShopDetail = _control.SelectAll<ShopDetailInfo>(); }

        public void GenSet() { CommonData.GenSet = _control.SelectAll<GenSetInfo>(); }

        public void GetKeypadList() { CommonData.Keypad = _control.SelectAll<KeypadInfo>(); }

        public void GetSysPrtList() { CommonData.SysPrt = _control.SelectAll<SysPrtSetInfo>(); }

        public void GetTaDeptCode() { CommonData.TaDeptCode = _control.SelectAll<TaDeptCodeInfo>(); }

        public void GetTaMenuSet() { CommonData.TaMenuSet = _control.SelectAll<TaMenuSetInfo>(); }

        public void GetTaMenuCate() { CommonData.TaMenuCate = _control.SelectAll<TaMenuCateInfo>(); }

        public void GetTaMenuItem() { CommonData.TaMenuItem = _control.SelectAll<TaMenuItemInfo>(); }
        
        public void GetTaMenuItemOtherChoice() { CommonData.TaMenuItemOtherChoice = _control.SelectAll<TaMenuItemOtherChoiceInfo>(); }

        public void GetTaOrderItem() { CommonData.TaOrderItem = _control.SelectAll<TaOrderItemInfo>(); }

        public void GetTaCheckOrder() { CommonData.TaCheckOrder = _control.SelectAll<TaCheckOrderInfo>(); }

        public void GetSysValue() { CommonData.SysValue = _control.SelectAll<SysValueInfo>(); }

        public void GetTaExtraMenu() { CommonData.TaExtraMenu = _control.SelectAll<TaExtraMenuInfo>(); }

        public void GetTaPaymentType() { CommonData.TaPaymentType = _control.SelectAll<TaPaymentTypeInfo>(); }

        public void GetTaDiscount() { CommonData.TaDiscount = _control.SelectAll<TaDiscountInfo>(); }

        public void GetTaDeliveryNote() { CommonData.TaDeliveryNote = _control.SelectAll<TaDeliveryNoteInfo>(); }

        public void GetTaDriver() { CommonData.TaDriver = _control.SelectAll<TaDriverInfo>(); }

        public void GetTaCustomer() { CommonData.TaCustomer = _control.SelectAll<TaCustomerInfo>(); }

        public void GetTaPayment() { CommonData.TaPayment = _control.SelectAll<TaPaymentInfo>(); }

        public void GetTaPaymentDetail() { CommonData.TaPaymentDetail = _control.SelectAll<TaPaymentDetailInfo>(); }
        
        public void GetTaCashDrawSet() { CommonData.TaCashDrawSet = _control.SelectAll<TaCashDrawSetInfo>(); }

        public void GetDataManager() { CommonData.DataManager = _control.SelectAll<DataManagerInfo>(); }

        public void GetTaFreeFood() { CommonData.TaFreeFood = _control.SelectAll<TaFreeFoodInfo>(); }

        public void GetTaDeliverySet() { CommonData.TaDeliverySet = _control.SelectAll<TaDeliverySetInfo>(); }

        public void GetTaDeliverySetDetail() { CommonData.TaDeliverySetDetail = _control.SelectAll<TaDeliverySetDetailInfo>(); }

        public void GetTaPostcodeCharge() { CommonData.TaPostcodeCharge = _control.SelectAll<TaPostcodeChargeInfo>(); }

        public void GetTaPostcodeZone() { CommonData.TaPostcodeZone = _control.SelectAll<TaPostcodeZoneInfo>(); }

        public void GetTaPostcodeSet() { CommonData.TaPostcodeSet = _control.SelectAll<TaPostcodeSetInfo>(); }

        public void GetTaSubMenu() { CommonData.TaSubMenu = _control.SelectAll<TaSubMenuInfo>(); }

        public void GetTaSubMenuDetail() { CommonData.TaSubMenuDetail = _control.SelectAll<TaSubMenuDetailInfo>(); }

        public void GetTaSysFont() { CommonData.TaSysFont = _control.SelectAll<TaSysFontInfo>(); }

        public void GetTaChangeMenuAttr() { CommonData.TaChangeMenuAttr = _control.SelectAll<TaChangeMenuAttrInfo>(); }

        public void GetSysUsrMaintenance() { CommonData.SysUsrMaintenance = _control.SelectAll<SysUsrMaintenanceInfo>(); }

        public void GetTaConfMenuDisplayFont() { CommonData.TaConfMenuDisplayFont = _control.SelectAll<TaConfMenuDisplayFontInfo>(); }

        public void GetTaMenuItemSubMenu() { CommonData.TaMenuItemSubMenu = _control.SelectAll<TaMenuItemSubMenuInfo>(); }

        public void GetTaPrtSetupGeneral() { CommonData.TaPrtSetupGeneral = _control.SelectAll<TaPrtSetupGeneralInfo>(); }

        public void GetTaPrtSetupGetSet1() { CommonData.TaPrtSetupGeneralSet1 = _control.SelectAll<TaPrtSetupGeneralSet1Info>(); }

        public void GetTaPreview() { CommonData.TaPreview = _control.SelectAll<TaPreviewInfo>(); }

        public void GetTaSysCtrl() { CommonData.TaSysCtrl = _control.SelectAll<TaSysCtrlInfo>(); }

        public void GetTaFreeFoodAdd() { CommonData.TaFreeFoodAdd = _control.SelectAll<TaFreeFoodAddInfo>(); }

        public void GetTaSysPrtSetGeneral() { CommonData.TaSysPrtSetGeneral = _control.SelectAll<TaSysPrtSetGeneralInfo>(); }

        public void GetTaSysPrtSetCountSetting1() { CommonData.TaSysPrtSetCounterSetting1 = _control.SelectAll<TaSysPrtSetCounterSetting1Info>(); }

        public void GetTaSysPrtSetCountSetting2() { CommonData.TaSysPrtSetCounterSetting2 = _control.SelectAll<TaSysPrtSetCounterSetting2Info>(); }

        public void GetTaSysPrtSetKitchen() { CommonData.TaSysPrtSetKitchen = _control.SelectAll<TaSysPrtSetKitchenInfo>(); }

        public void GetComePhoneInfo() { CommonData.TaComePhoneInfo = _control.SelectAll<TaComePhoneInfo>(); }

        public void GetAccountSummary(string strDateTimeFrom, string strDateTimeTo) { CommonData.GetAccountSummaryInfos = _control.GetAccountSummary(strDateTimeFrom, strDateTimeTo); }

        public void GetPrtAccountSummary(string strOrderNum, string strBusDate) { CommonData.GetPrtAccountSummaryInfos = _control.GetPrtAccountSummary(strOrderNum, strBusDate); }

        public void GetOrderItemSumForVatInfos(string strOrderNum, string strBusDate) { CommonData.GetOrderItemSumForVatInfos = _control.GetOrderItemSumForVatInfos(strOrderNum, strBusDate); }

        public void GetRptTotalSales(string strBusDate) { CommonData.GetRptTotalSalesInfo = _control.GetRptTotalSales(strBusDate); }

        public void GetShowAndPendOrderData(string strOrderNum, string strBusDate) { CommonData.GetShowAndPendOrderData = _control.GetShowAndPendOrderData(strOrderNum, strBusDate); }

        public void GetOrderItemMatchVat(string strOrderNum, string strBusDate) { CommonData.GetOrderItemMatchVat = _control.GetOrderItemMatchVat(strOrderNum, strBusDate); }
    }
}
