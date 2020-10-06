using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaSysPrtSetCounterSetting2Info
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        [XmlElement(ElementName = "SoLocalPriter")]
        public virtual string SoLocalPriter { get; set; }

        [XmlElement(ElementName = "SoNumOfCopy")]
        public virtual string SoNumOfCopy { get; set; }

        [XmlElement(ElementName = "SoPrintLang")]
        public virtual string SoPrintLang { get; set; }

        [XmlElement(ElementName = "SoEngFontSize")]
        public virtual string SoEngFontSize { get; set; }

        [XmlElement(ElementName = "SoOtherLangFont")]
        public virtual string SoOtherLangFont { get; set; }

        [XmlElement(ElementName = "IsSoPrintDate")]
        public virtual string IsSoPrintDate { get; set; }

        [XmlElement(ElementName = "IsSoPrintTime")]
        public virtual string IsSoPrintTime { get; set; }

        [XmlElement(ElementName = "IsSoPrintVATNo")]
        public virtual string IsSoPrintVATNo { get; set; }

        [XmlElement(ElementName = "SoDriverPrintoutCopy")]
        public virtual string SoDriverPrintoutCopy { get; set; }

        [XmlElement(ElementName = "SoDeliveryAddrFont")]
        public virtual string SoDeliveryAddrFont { get; set; }

        [XmlElement(ElementName = "IsSoPrintOrderNo")]
        public virtual string IsSoPrintOrderNo { get; set; }

        [XmlElement(ElementName = "CoLocalPriter")]
        public virtual string CoLocalPriter { get; set; }

        [XmlElement(ElementName = "CoHeadWord")]
        public virtual string CoHeadWord { get; set; }

        [XmlElement(ElementName = "CoPrintLang")]
        public virtual string CoPrintLang { get; set; }

        [XmlElement(ElementName = "CoEngFontSize")]
        public virtual string CoEngFontSize { get; set; }

        [XmlElement(ElementName = "CoOtherLangFont")]
        public virtual string CoOtherLangFont { get; set; }

        [XmlElement(ElementName = "IsCoPrintDate")]
        public virtual string IsCoPrintDate { get; set; }

        [XmlElement(ElementName = "IsCoPrintTime")]
        public virtual string IsCoPrintTime { get; set; }
        
        [XmlElement(ElementName = "IsCoPrintOrderNo")]
        public virtual string IsCoPrintOrderNo { get; set; }

        [XmlElement(ElementName = "IsCoPrintVATNo")]
        public virtual string IsCoPrintVATNo { get; set; }

        [XmlElement(ElementName = "IsCoPrintVATCalculation")]
        public virtual string IsCoPrintVATCalculation { get; set; }
    }
}