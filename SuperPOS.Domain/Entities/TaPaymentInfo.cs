using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaPaymentInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //账单编号
        [XmlElement(ElementName = "CheckCode")]
        public virtual string CheckCode { get; set; }

        //订单类型
        [XmlElement(ElementName = "PayOrderType")]
        public virtual string PayOrderType { get; set; }

        //Delivery
        [XmlElement(ElementName = "PayDelivery")]
        public virtual string PayDelivery { get; set; }

        //Discount
        [XmlElement(ElementName = "PayDiscount")]
        public virtual string PayDiscount { get; set; }

        //账单总额
        [XmlElement(ElementName = "PayAmout")]
        public virtual string PayAmout { get; set; }

        //是否已付完款
        [XmlElement(ElementName = "IsPaid")]
        public virtual string IsPaid { get; set; }

        //会员ID
        [XmlElement(ElementName = "CustomerID")]
        public virtual string CustomerID { get; set; }

        //会员备注
        [XmlElement(ElementName = "CustomerNote")]
        public virtual string CustomerNote { get; set; }

        //司机ID
        [XmlElement(ElementName = "DriverID")]
        public virtual int DriverID { get; set; }

        //下单员工ID
        [XmlElement(ElementName = "StaffID")]
        public virtual int StaffID { get; set; }

        //付款时间
        [XmlElement(ElementName = "PayTime")]
        public virtual string PayTime { get; set; }
    }
}