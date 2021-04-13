using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class VIEW_OrderItemMatchVatInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        [XmlElement(ElementName = "CheckCode")]
        public virtual string CheckCode { get; set; }

        [XmlElement(ElementName = "BusDate")]
        public virtual string BusDate { get; set; }

        [XmlElement(ElementName = "VatInfo")]
        public virtual string VatInfo { get; set; }

        [XmlElement(ElementName = "ItemTotalPrice")]
        public virtual string ItemTotalPrice { get; set; }
    }
}
