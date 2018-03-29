using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaDiscountInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //折扣类型
        [XmlElement(ElementName = "TaType")]
        public virtual string TaType { get; set; }

        //折扣
        [XmlElement(ElementName = "TaDiscount")]
        public virtual string TaDiscount { get; set; }
        
        //折扣起点
        [XmlElement(ElementName = "TaDiscThre")]
        public virtual string TaDiscThre { get; set; }
    }
}