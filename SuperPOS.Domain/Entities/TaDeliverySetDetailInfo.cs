using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaDeliverySetDetailInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //Distance From
        [XmlElement(ElementName = "DistFrom")]
        public virtual string DistFrom { get; set; }

        //Distance To
        [XmlElement(ElementName = "DistTo")]
        public virtual string DistTo { get; set; }

        //Amount To Pay
        [XmlElement(ElementName = "AmountToPay")]
        public virtual string AmountToPay { get; set; }
    }
}
