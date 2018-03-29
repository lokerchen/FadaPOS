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

        //修改菜品名时后面的内容
        [XmlElement(ElementName = "MenuAttr")]
        public virtual string MenuAttr { get; set; }
    }
}
