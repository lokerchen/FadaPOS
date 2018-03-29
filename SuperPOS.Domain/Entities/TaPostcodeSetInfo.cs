using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaPostcodeSetInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //Postcode
        [XmlElement(ElementName = "PostCode")]
        public virtual string PostCode { get; set; }

        [XmlElement(ElementName = "PCZone")]
        public virtual string PCZone { get; set; }

        [XmlElement(ElementName = "PCDist")]
        public virtual string PCDist { get; set; }

        [XmlElement(ElementName = "PCAddr")]
        public virtual string PCAddr { get; set; }
    }
}
