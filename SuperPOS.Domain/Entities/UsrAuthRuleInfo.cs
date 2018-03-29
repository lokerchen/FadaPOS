using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    //权限组细节权限
    public class UsrAuthRuleInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //权限组ID
        [XmlElement(ElementName = "GrpID")]
        public virtual string GrpID { get; set; }

        //权限部门
        [XmlElement(ElementName = "AccessDept")]
        public virtual string AccessDept { get; set; }

        //权限细节
        [XmlElement(ElementName = "AccessDetail")]
        public virtual string AccessDetail { get; set; }

        //权限对应按钮ID
        [XmlElement(ElementName = "AccessBtnID")]
        public virtual string AccessBtnID { get; set; }

        //是否具有该权限
        [XmlElement(ElementName = "IsAccess")]
        public virtual string IsAccess { get; set; }
    }
}
