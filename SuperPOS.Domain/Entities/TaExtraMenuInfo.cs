using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    //改码
    public class TaExtraMenuInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //改码英文名称
        [XmlElement(ElementName = "eMenuEngName")]
        public virtual string eMenuEngName { get; set; }

        //改码中文名称
        [XmlElement(ElementName = "eMenuOtherName")]
        public virtual string eMenuOtherName { get; set; }

        //改码价格
        [XmlElement(ElementName = "eMenuPrice")]
        public virtual string eMenuPrice { get; set; }

        //改码位置
        [XmlElement(ElementName = "eMenuPosition")]
        public virtual string eMenuPosition { get; set; }

        //改码类型
        [XmlElement(ElementName = "eMenuType")]
        public virtual string eMenuType { get; set; }

        //改码Button类型
        [XmlElement(ElementName = "eMenuBtnName")]
        public virtual string eMenuBtnName { get; set; }
    }
}