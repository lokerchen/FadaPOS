using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    //用户所属权限组
    public class UsrAuthAccessInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //用户编号
        [XmlElement(ElementName = "UsrID")]
        public virtual int UsrID { get; set; }

        //用户名
        [XmlElement(ElementName = "AuthGrpID")]
        public virtual int AuthGrpID { get; set; }

        //创建者
        [XmlElement(ElementName = "CreateBy")]
        public virtual string CreateBy { get; set; }

        //创建时间
        [XmlElement(ElementName = "CreateTime")]
        public virtual string CreateTime { get; set; }
    }
}
