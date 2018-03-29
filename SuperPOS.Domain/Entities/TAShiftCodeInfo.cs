using System;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TAShiftCodeInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //时段编号
        [XmlElement(ElementName = "ShiftCode")]
        public virtual string ShiftCode { get; set; }

        //时段英文名称
        [XmlElement(ElementName = "ShiftName")]
        public virtual string ShiftName { get; set; }

        //时段其他名称
        [XmlElement(ElementName = "OtherName")]
        public virtual string OtherName { get; set; }

        //是否具有特殊时段
        [XmlElement(ElementName = "IsSpecial")]
        public virtual string IsSpecial { get; set; }

        //特殊时段开始
        [XmlElement(ElementName = "DtFrom")]
        public virtual string DtFrom { get; set; }

        //特殊时段结束
        [XmlElement(ElementName = "DtEnd")]
        public virtual string DtEnd { get; set; }

        //特殊时段内容
        [XmlElement(ElementName = "SpecialContent")]
        public virtual string SpecialContent { get; set; }

        //备注
        [XmlElement(ElementName = "ShiftRmk")]
        public virtual string ShiftRmk { get; set; }
    }
}
