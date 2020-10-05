using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaSysPrtSetGeneralInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        [XmlElement(ElementName = "IsPrtLogo")]
        public virtual string IsPrtLogo { get; set; }

        [XmlElement(ElementName = "LogoFilePath")]
        public virtual string LogoFilePath { get; set; }

        [XmlElement(ElementName = "IsPrtStaff")]
        public virtual string IsPrtStaff { get; set; }

        [XmlElement(ElementName = "IsPrtTel")]
        public virtual string IsPrtTel { get; set; }

        [XmlElement(ElementName = "IsPrtAddr")]
        public virtual string IsPrtAddr { get; set; }

        [XmlElement(ElementName = "TelNo")]
        public virtual string TelNo { get; set; }

        [XmlElement(ElementName = "VATNo")]
        public virtual string VATNo { get; set; }

        [XmlElement(ElementName = "Msg1")]
        public virtual string Msg1 { get; set; }

        [XmlElement(ElementName = "Msg2")]
        public virtual string Msg2 { get; set; }

        [XmlElement(ElementName = "Msg3")]
        public virtual string Msg3 { get; set; }

        [XmlElement(ElementName = "Msg4")]
        public virtual string Msg4 { get; set; }

        [XmlElement(ElementName = "Msg5")]
        public virtual string Msg5 { get; set; }
    }
}