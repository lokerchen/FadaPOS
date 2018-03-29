using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class SysValueInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //常值ID
        [XmlElement(ElementName = "ValueID")]
        public virtual string ValueID { get; set; }

        //常值描述
        [XmlElement(ElementName = "ValueDesc")]
        public virtual string ValueDesc { get; set; }

        //常值结果值
        [XmlElement(ElementName = "ValueResult")]
        public virtual string ValueResult { get; set; }
    }
}