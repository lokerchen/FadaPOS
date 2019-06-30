using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaPrtSetupGeneralSet1Info
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //PrtLang
        [XmlElement(ElementName = "PrtLang")]
        public virtual string PrtLang { get; set; }

        //PrtFontSize
        [XmlElement(ElementName = "PrtFontSize")]
        public virtual string PrtFontSize { get; set; }

        //PrtMsgAtBottom
        [XmlElement(ElementName = "PrtMsgAtBottom")]
        public virtual string PrtMsgAtBottom { get; set; }
    }
}
