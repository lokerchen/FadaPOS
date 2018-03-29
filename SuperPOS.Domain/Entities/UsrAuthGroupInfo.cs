using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    //用户权限组
    public class UsrAuthGroupInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //权限组英文名
        [XmlElement(ElementName = "GrpEngName")]
        public virtual string GrpEngName { get; set; }

        //权限组其他名
        [XmlElement(ElementName = "GrpOtherName")]
        public virtual string GrpOtherName { get; set; }

        //创建者
        [XmlElement(ElementName = "CreateBy")]
        public virtual string CreateBy { get; set; }

        //创建时间
        [XmlElement(ElementName = "CreateTime")]
        public virtual string CreateTime { get; set; }
    }
}
