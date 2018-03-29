using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaSubMenuDetailInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //SubMenu ID
        [XmlElement(ElementName = "smID")]
        public virtual int smID { get; set; }

        //English Name
        [XmlElement(ElementName = "EngName")]
        public virtual string EngName { get; set; }

        //Other Name
        [XmlElement(ElementName = "OtherName")]
        public virtual string OtherName { get; set; }

        //Price
        [XmlElement(ElementName = "Price")]
        public virtual string Price { get; set; }
    }
}
