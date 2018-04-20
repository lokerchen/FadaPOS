using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaConfMenuDisplayFontInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        [XmlElement(ElementName = "MenuDisplayBtnFontSize")]
        public virtual string MenuDisplayBtnFontSize { get; set; }

        [XmlElement(ElementName = "IsMenuDishCodeFontBold")]
        public virtual string IsMenuDishCodeFontBold { get; set; }

        [XmlElement(ElementName = "CategBtnFontSize")]
        public virtual string CategBtnFontSize { get; set; }

        [XmlElement(ElementName = "IsCategFontBold")]
        public virtual string IsCategFontBold { get; set; }
    }
}