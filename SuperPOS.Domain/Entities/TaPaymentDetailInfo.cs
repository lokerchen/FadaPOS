using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaPaymentDetailInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //账单编号
        [XmlElement(ElementName = "CheckOrder")]
        public virtual string CheckOrder { get; set; }

        //付款类型
        [XmlElement(ElementName = "PayType")]
        public virtual string PayType { get; set; }

        //付款金额
        [XmlElement(ElementName = "PayAmount")]
        public virtual string PayAmount { get; set; }

        //下单员工ID
        [XmlElement(ElementName = "StaffID")]
        public virtual int StaffID { get; set; }

        //付款时间
        [XmlElement(ElementName = "PayTime")]
        public virtual string PayTime { get; set; }
    }
}