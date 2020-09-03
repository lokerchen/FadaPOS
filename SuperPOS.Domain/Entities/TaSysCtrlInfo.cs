using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaSysCtrlInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        [XmlElement(ElementName = "ShopName")]
        public virtual string ShopName { get; set; }

        [XmlElement(ElementName = "ShopAddress")]
        public virtual string ShopAddress { get; set; }

        [XmlElement(ElementName = "IsShopDetailsReadOnly")]
        public virtual string IsShopDetailsReadOnly { get; set; }
    }
}
