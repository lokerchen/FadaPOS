using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaMenuSetInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //Menu Set 英文名
        [XmlElement(ElementName = "MSEngName")]
        public virtual string MSEngName { get; set; }

        //Menu Set其他名字
        [XmlElement(ElementName = "MSOtherName")]
        public virtual string MSOtherName { get; set; }
    }
}