using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaPostcodeZoneInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //Postcode
        [XmlElement(ElementName = "PostCode")]
        public virtual string PostCode { get; set; }

        //Zone
        [XmlElement(ElementName = "Zone")]
        public virtual string Zone { get; set; }
    }
}
