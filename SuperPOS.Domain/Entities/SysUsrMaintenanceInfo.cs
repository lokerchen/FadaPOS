using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class SysUsrMaintenanceInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        [XmlElement(ElementName = "UsrID")]
        public virtual int UsrID { get; set; }

        [XmlElement(ElementName = "TaControlPanel")]
        public virtual string TaControlPanel { get; set; }

        [XmlElement(ElementName = "TaChangePrice")]
        public virtual string TaChangePrice { get; set; }

        [XmlElement(ElementName = "TaPriceOff")]
        public virtual string TaPriceOff { get; set; }

        [XmlElement(ElementName = "TaShowOrderPrtAcctSummary")]
        public virtual string TaShowOrderPrtAcctSummary { get; set; }

        [XmlElement(ElementName = "TaShowOrderChangePayment")]
        public virtual string TaShowOrderChangePayment { get; set; }

        [XmlElement(ElementName = "TaShowOrderEditOrder")]
        public virtual string TaShowOrderEditOrder { get; set; }

        [XmlElement(ElementName = "TaShowOrderPrtReceipt")]
        public virtual string TaShowOrderPrtReceipt { get; set; }

        [XmlElement(ElementName = "TaShowOrderExportData")]
        public virtual string TaShowOrderExportData { get; set; }

        [XmlElement(ElementName = "EiControlPanel")]
        public virtual string EiControlPanel { get; set; }

        [XmlElement(ElementName = "EiChangePrice")]
        public virtual string EiChangePrice { get; set; }

        [XmlElement(ElementName = "EiPriceOff")]
        public virtual string EiPriceOff { get; set; }

        [XmlElement(ElementName = "EiPay")]
        public virtual string EiPay { get; set; }

        [XmlElement(ElementName = "EiPrtBill")]
        public virtual string EiPrtBill { get; set; }

        [XmlElement(ElementName = "EiRemoveItemAfterPrt")]
        public virtual string EiRemoveItemAfterPrt { get; set; }

        [XmlElement(ElementName = "EiTableBooking")]
        public virtual string EiTableBooking { get; set; }

        [XmlElement(ElementName = "EiShowOrderPrtAcctSummary")]
        public virtual string EiShowOrderPrtAcctSummary { get; set; }

        [XmlElement(ElementName = "EiShowOrderChangePayment")]
        public virtual string EiShowOrderChangePayment { get; set; }

        [XmlElement(ElementName = "EiShowOrderEditOrder")]
        public virtual string EiShowOrderEditOrder { get; set; }

        [XmlElement(ElementName = "EiShowOrderPrtReceipt")]
        public virtual string EiShowOrderPrtReceipt { get; set; }

        [XmlElement(ElementName = "EiPrtBillDiscount")]
        public virtual string EiPrtBillDiscount { get; set; }

        [XmlElement(ElementName = "GaSysConf")]
        public virtual string GaSysConf { get; set; }

        [XmlElement(ElementName = "GaSysComputerAdd")]
        public virtual string GaSysComputerAdd { get; set; }

        [XmlElement(ElementName = "GaSysUsrMaint")]
        public virtual string GaSysUsrMaint { get; set; }

        [XmlElement(ElementName = "GaSysShiftCode")]
        public virtual string GaSysShiftCode { get; set; }

        [XmlElement(ElementName = "GaSysDataManager")]
        public virtual string GaSysDataManager { get; set; }

        [XmlElement(ElementName = "GaTaConf")]
        public virtual string GaTaConf { get; set; }

        [XmlElement(ElementName = "GaSysCompactDb")]
        public virtual string GaSysCompactDb { get; set; }

        [XmlElement(ElementName = "GaEiConf")]
        public virtual string GaEiConf { get; set; }

        [XmlElement(ElementName = "GaRptReport")]
        public virtual string GaRptReport { get; set; }

        [XmlElement(ElementName = "GaTaPrtSetup")]
        public virtual string GaTaPrtSetup { get; set; }

        [XmlElement(ElementName = "GaRptAccountSummary")]
        public virtual string GaRptAccountSummary { get; set; }

        [XmlElement(ElementName = "GaEiPrtSetup")]
        public virtual string GaEiPrtSetup { get; set; }

        [XmlElement(ElementName = "GaAsSumView")]
        public virtual string GaAsSumView { get; set; }

        [XmlElement(ElementName = "GaAsPrtSaleRpt")]
        public virtual string GaAsPrtSaleRpt { get; set; }

        [XmlElement(ElementName = "GaLogonExit")]
        public virtual string GaLogonExit { get; set; }

        [XmlElement(ElementName = "GaOpenCashDrawer")]
        public virtual string GaOpenCashDrawer { get; set; }

        [XmlElement(ElementName = "GaWriteAndEnableInv")]
        public virtual string GaWriteAndEnableInv { get; set; }
    }
}