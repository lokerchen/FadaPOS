using System.Collections.Generic;
using SuperPOS.Domain.Entities;
using SuperPOS.UI.TA;

namespace SuperPOS.Common
{
    public class CommonData
    {
        public static IList<TAShiftCodeInfo> TaShiftCodeList { get; set; } 

        public static IList<UsrBaseInfo> UsrBase { get; set; } 

        public static IList<UsrAuthAccessInfo> UsrAuthAccess { get; set; }

        public static IList<UsrAuthDetailInfo> UsrAuthDetail { get; set; } 

        public static IList<UsrAuthGroupInfo> UsrAuthGroup { get; set; } 

        public static IList<UsrAuthRuleInfo> UsrAuthRule { get; set; } 

        public static IList<CompAddrInfo> CompAddr { get; set; } 

        public static IList<ShopDetailInfo> ShopDetail { get; set; }

        public static IList<GenSetInfo> GenSet { get; set; } 

        public static IList<KeypadInfo> Keypad { get; set; }

        public static IList<SysPrtSetInfo> SysPrt { get; set; }

        public static IList<TaDeptCodeInfo> TaDeptCode { get; set; } 

        public static IList<TaMenuSetInfo> TaMenuSet { get; set; } 

        public static IList<TaMenuCateInfo> TaMenuCate { get; set; } 

        public static IList<TaMenuItemInfo> TaMenuItem { get; set; } 

        public static IList<TaMenuItemOtherChoiceInfo> TaMenuItemOtherChoice { get; set; } 

        public static IList<TaOrderItemInfo> TaOrderItem { get; set; } 

        public static IList<TaCheckOrderInfo> TaCheckOrder { get; set; }

        public static IList<SysValueInfo> SysValue { get; set; } 

        public static IList<TaExtraMenuInfo> TaExtraMenu { get; set; } 
         
        public static IList<TaPaymentTypeInfo> TaPaymentType { get; set; }

        public static IList<TaDiscountInfo> TaDiscount { get; set; }

        public static IList<TaDeliveryNoteInfo> TaDeliveryNote { get; set; }

        public static IList<TaDriverInfo> TaDriver { get; set; } 

        public static IList<TaCustomerInfo> TaCustomer { get; set; }
        
        public static IList<TaPaymentInfo> TaPayment { get; set; }
        
        public static IList<TaPaymentDetailInfo> TaPaymentDetail { get; set; } 

        public static IList<TaCashDrawSetInfo> TaCashDrawSet { get; set; }

        public static IList<DataManagerInfo> DataManager { get; set; } 

        public static IList<TaFreeFoodInfo> TaFreeFood { get; set; }

        public static IList<TaDeliverySetInfo> TaDeliverySet { get; set; } 

        public static IList<TaDeliverySetDetailInfo> TaDeliverySetDetail { get; set; } 

        public static IList<TaPostcodeChargeInfo> TaPostcodeCharge { get; set; } 

        public static IList<TaPostcodeZoneInfo> TaPostcodeZone { get; set; } 

        public static IList<TaPostcodeSetInfo> TaPostcodeSet { get; set; } 

        public static IList<TaSubMenuInfo> TaSubMenu { get; set; } 

        public static IList<TaSubMenuDetailInfo> TaSubMenuDetail { get; set; } 

        public static IList<TaSysFontInfo> TaSysFont { get; set; } 

        public static IList<TaChangeMenuAttrInfo> TaChangeMenuAttr { get; set; } 

        public static IList<SysUsrMaintenanceInfo> SysUsrMaintenance { get; set; } 

        public static IList<TaConfMenuDisplayFontInfo> TaConfMenuDisplayFont { get; set; } 
    }
}
