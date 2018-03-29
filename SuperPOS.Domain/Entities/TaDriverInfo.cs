using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaDriverInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //Driver Name
        [XmlElement(ElementName = "DriverName")]
        public virtual string DriverName { get; set; }

        //Driver Phone Number
        [XmlElement(ElementName = "DriverNumber")]
        public virtual string DriverNumber { get; set; }

        //Driver WorkDay
        [XmlElement(ElementName = "DriverWorkDay")]
        public virtual string DriverWorkDay { get; set; }
    }
}