using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaMenuCateInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //Menu Category英文名
        [XmlElement(ElementName = "CateEngName")]
        public virtual string CateEngName { get; set; }

        //Menu Category其他名
        [XmlElement(ElementName = "CateOtherName")]
        public virtual string CateOtherName { get; set; }

        //Menu Category Position
        [XmlElement(ElementName = "CatePosition")]
        public virtual string CatePosition { get; set; }

        //Department Code ID
        [XmlElement(ElementName = "DeptCodeID")]
        public virtual int DeptCodeID { get; set; }

        //Menu Set ID
        [XmlElement(ElementName = "MenuSetID")]
        public virtual int MenuSetID { get; set; }

        [XmlElement(ElementName = "IsHotKey")]
        public virtual string IsHotKey { get; set; }

        [XmlElement(ElementName = "HotKeyDishCode")]
        public virtual string HotKeyDishCode { get; set; }

        [XmlElement(ElementName = "BtnColor")]
        public virtual string BtnColor { get; set; }
    }
}