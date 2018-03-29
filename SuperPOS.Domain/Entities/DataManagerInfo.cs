using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class DataManagerInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //备份数据库位置
        [XmlElement(ElementName = "LocBackUp")]
        public virtual string LocBackUp { get; set; }

        //覆盖数据库文件位置
        [XmlElement(ElementName = "LocRestore")]
        public virtual string LocRestore { get; set; }
    }
}
