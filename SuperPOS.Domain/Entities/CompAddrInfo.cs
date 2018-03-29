using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class CompAddrInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //客户端编码
        [XmlElement(ElementName = "AddrCode")]
        public virtual string AddrCode { get; set; }

        //电脑名称
        [XmlElement(ElementName = "CompName")]
        public virtual string CompName { get; set; }
    }
}
