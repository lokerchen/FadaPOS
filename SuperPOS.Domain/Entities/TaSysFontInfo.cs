using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaSysFontInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        [XmlElement(ElementName = "miFont")]
        public virtual string miFont { get; set; }

        [XmlElement(ElementName = "cateFont")]
        public virtual string cateFont { get; set; }
    }
}
