using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaComePhoneInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }
        
        [XmlElement(ElementName = "CustPhoneNo")]
        public virtual string CustPhoneNo { get; set; }
        
        [XmlElement(ElementName = "ComePhoneTime")]
        public virtual string ComePhoneTime { get; set; }

        [XmlElement(ElementName = "CustName")]
        public virtual string CustName { get; set; }
        
        [XmlElement(ElementName = "CustID")]
        public virtual string CustID { get; set; }

        [XmlElement(ElementName = "BusDate")]
        public virtual string BusDate { get; set; }
    }
}
