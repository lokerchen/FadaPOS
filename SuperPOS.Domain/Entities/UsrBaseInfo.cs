using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class UsrBaseInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //用户名
        [XmlElement(ElementName = "UsrName")]
        public virtual string UsrName { get; set; }

        //用户密码
        [XmlElement(ElementName = "UsrPwd")]
        public virtual string UsrPwd { get; set; }

        //创建者
        [XmlElement(ElementName = "CreateBy")]
        public virtual string CreateBy { get; set; }

        //创建时间
        [XmlElement(ElementName = "CreateTime")]
        public virtual string CreateTime { get; set; }

        //备注
        [XmlElement(ElementName = "UsrRmk")]
        public virtual string UsrRmk { get; set; }
    }
}
