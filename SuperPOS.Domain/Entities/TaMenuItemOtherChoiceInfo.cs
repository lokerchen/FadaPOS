using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaMenuItemOtherChoiceInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //其他Choice英文名
        [XmlElement(ElementName = "MiEngName")]
        public virtual string MiEngName { get; set; }

        //其他Choice其他名
        [XmlElement(ElementName = "MiOtherName")]
        public virtual string MiOtherName { get; set; }

        //其他Choice价格
        [XmlElement(ElementName = "MiPrice")]
        public virtual string MiPrice { get; set; }

        //其他Choice是否一直显示
        [XmlElement(ElementName = "IsAutoAppend")]
        public virtual string IsAutoAppend { get; set; }

        //是否启用
        [XmlElement(ElementName = "IsEnableChoice")]
        public virtual string IsEnableChoice { get; set; }

        //关联Menu Item ID
        [XmlElement(ElementName = "MiID")]
        public virtual int MiID { get; set; }

        //类型
        [XmlElement(ElementName = "MiType")]
        public virtual int MiType { get; set; }

        [XmlElement(ElementName = "OptionNum")]
        public virtual string OptionNum { get; set; }
    }
}