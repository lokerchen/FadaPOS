using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaSysPrtSetKitchenInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        [XmlElement(ElementName = "PrintLang")]
        public virtual string PrintLang { get; set; }

        [XmlElement(ElementName = "PrintPriceDishCode")]
        public virtual string PrintPriceDishCode { get; set; }

        [XmlElement(ElementName = "EngFontSize")]
        public virtual string EngFontSize { get; set; }

        [XmlElement(ElementName = "OtherFontSize")]
        public virtual string OtherFontSize { get; set; }

        [XmlElement(ElementName = "DeliveryAddr")]
        public virtual string DeliveryAddr { get; set; }

        [XmlElement(ElementName = "IsPrintAsc")]
        public virtual string IsPrintAsc { get; set; }

        [XmlElement(ElementName = "IsPrintDate")]
        public virtual string IsPrintDate { get; set; }

        [XmlElement(ElementName = "IsPrintTime")]
        public virtual string IsPrintTime { get; set; }

        [XmlElement(ElementName = "IsPrintPayType")]
        public virtual string IsPrintPayType { get; set; }

        [XmlElement(ElementName = "IsPrintDeliveryAddr")]
        public virtual string IsPrintDeliveryAddr { get; set; }

        [XmlElement(ElementName = "IsPrintOrderNo")]
        public virtual string IsPrintOrderNo { get; set; }

        [XmlElement(ElementName = "IsPrintAscendingSortNo")]
        public virtual string IsPrintAscendingSortNo { get; set; }
    }
}