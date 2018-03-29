using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class SysPrtSetInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //打印机编码
        [XmlElement(ElementName = "PrtCode")]
        public virtual string PrtCode { get; set; }

        //打印机名字
        [XmlElement(ElementName = "PrtName")]
        public virtual string PrtName { get; set; }
    }
}