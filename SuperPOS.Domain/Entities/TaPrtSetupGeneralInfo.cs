using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaPrtSetupGeneralInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //电话号码
        [XmlElement(ElementName = "TelNo")]
        public virtual string TelNo { get; set; }

        //VAT No.
        [XmlElement(ElementName = "VATNo")]
        public virtual string VATNo { get; set; }

        //Msg1
        [XmlElement(ElementName = "Msg1")]
        public virtual string Msg1 { get; set; }

        //Msg2
        [XmlElement(ElementName = "Msg2")]
        public virtual string Msg2 { get; set; }

        //Msg3
        [XmlElement(ElementName = "Msg3")]
        public virtual string Msg3 { get; set; }

        //Msg4
        [XmlElement(ElementName = "Msg4")]
        public virtual string Msg4 { get; set; }

        //Msg5
        [XmlElement(ElementName = "Msg5")]
        public virtual string Msg5 { get; set; }
    }
}
