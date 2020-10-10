using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaSysPrtSetCounterSetting1Info
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        [XmlElement(ElementName = "SoLocalPrinter")]
        public virtual string SoLocalPrinter { get; set; }

        [XmlElement(ElementName = "SoNumOfCopy")]
        public virtual string SoNumOfCopy { get; set; }

        [XmlElement(ElementName = "SoPrtLang")]
        public virtual string SoPrtLang { get; set; }

        [XmlElement(ElementName = "SoEngFontSize")]
        public virtual string SoEngFontSize { get; set; }

        [XmlElement(ElementName = "SoOtherFontSize")]
        public virtual string SoOtherFontSize { get; set; }

        [XmlElement(ElementName = "IsSoPrtDate")]
        public virtual string IsSoPrtDate { get; set; }

        [XmlElement(ElementName = "IsSoPrtTime")]
        public virtual string IsSoPrtTime { get; set; }

        [XmlElement(ElementName = "IsSoPrtOrderNoSlip")]
        public virtual string IsSoPrtOrderNoSlip { get; set; }

        [XmlElement(ElementName = "IsSoPrtVATNo")]
        public virtual string IsSoPrtVATNo { get; set; }

        [XmlElement(ElementName = "IsSoRefNum")]
        public virtual string IsSoRefNum { get; set; }

        [XmlElement(ElementName = "IsSoOrderNo")]
        public virtual string IsSoOrderNo { get; set; }

        [XmlElement(ElementName = "CoLocalPrinter")]
        public virtual string CoLocalPrinter { get; set; }

        [XmlElement(ElementName = "CoNumOfCopy")]
        public virtual string CoNumOfCopy { get; set; }

        [XmlElement(ElementName = "CoPrtLang")]
        public virtual string CoPrtLang { get; set; }

        [XmlElement(ElementName = "CoEngFontSize")]
        public virtual string CoEngFontSize { get; set; }

        [XmlElement(ElementName = "CoOtherFontSize")]
        public virtual string CoOtherFontSize { get; set; }

        [XmlElement(ElementName = "IsCoPrtDate")]
        public virtual string IsCoPrtDate { get; set; }

        [XmlElement(ElementName = "IsCoPrtTime")]
        public virtual string IsCoPrtTime { get; set; }

        [XmlElement(ElementName = "IsCoPrtOrderNoSlip")]
        public virtual string IsCoPrtOrderNoSlip { get; set; }

        [XmlElement(ElementName = "IsCoPrtVATNo")]
        public virtual string IsCoPrtVATNo { get; set; }

        [XmlElement(ElementName = "IsCoRefNum")]
        public virtual string IsCoRefNum { get; set; }

        [XmlElement(ElementName = "IsCoOrderNo")]
        public virtual string IsCoOrderNo { get; set; }
    }
}