using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class KeypadInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //Key名字
        [XmlElement(ElementName = "KeyName")]
        public virtual string KeyName { get; set; }

        //Key按键
        [XmlElement(ElementName = "KeyCode")]
        public virtual string KeyCode { get; set; }
    }
}
