using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class UsrAuthorityInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //用户编号
        [XmlElement(ElementName = "UsrID")]
        public virtual string UsrID { get; set; }

        //权限ID
        [XmlElement(ElementName = "AuthID")]
        public virtual string AuthID { get; set; }

        //权限所属部门
        [XmlElement(ElementName = "AuthDept")]
        public virtual string AuthDept { get; set; }

        //权限用户
        [XmlElement(ElementName = "AuthUsr")]
        public virtual string AuthUsr { get; set; }

        //权限详情
        [XmlElement(ElementName = "AuthDetails")]
        public virtual string AuthDetails { get; set; }

        //备注
        [XmlElement(ElementName = "AuthRmk")]
        public virtual string AuthRmk { get; set; }
    }
}
