using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaPaymentTypeInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //付款类型
        [XmlElement(ElementName = "PaymentType")]
        public virtual string PaymentType { get; set; }
    }
}