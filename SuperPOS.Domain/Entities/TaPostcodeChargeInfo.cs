using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaPostcodeChargeInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //Postcode
        [XmlElement(ElementName = "PostCode")]
        public virtual string PostCode { get; set; }

        //PostCharge
        [XmlElement(ElementName = "PostCharge")]
        public virtual string PostCharge { get; set; }
    }
}
