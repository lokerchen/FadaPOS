using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaChangeMenuAttrInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //修改菜品名时后面的英文名
        [XmlElement(ElementName = "MenuAttrEnglishName")]
        public virtual string MenuAttrEnglishName { get; set; }

        //修改菜品名时后面的其他名
        [XmlElement(ElementName = "MenuAttrOtherName")]
        public virtual string MenuAttrOtherName { get; set; }

        //修改菜品名时的价格
        [XmlElement(ElementName = "IncrementPrice")]
        public virtual string IncrementPrice { get; set; }
    }
}
