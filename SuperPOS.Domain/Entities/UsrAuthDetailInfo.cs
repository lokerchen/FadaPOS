using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    //用户权限详细清单
    public class UsrAuthDetailInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //权限部门
        [XmlElement(ElementName = "AuthDept")]
        public virtual string AuthDept { get; set; }

        //权限编号
        [XmlElement(ElementName = "AuthCode")]
        public virtual string AuthCode { get; set; }

        //权限名
        [XmlElement(ElementName = "AuthName")]
        public virtual string AuthName { get; set; }

        //权限类型（一/二级）
        [XmlElement(ElementName = "AuthType")]
        public virtual string AuthType { get; set; }

        //父节点
        [XmlElement(ElementName = "AuthParent")]
        public virtual string AuthParent { get; set; }
    }
}
