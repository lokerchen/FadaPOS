using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class SysUsrMaintenanceInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //用户列表
        [XmlElement(ElementName = "UsrId")]
        public virtual string UsrId { get; set; }

        //权限所属
        [XmlElement(ElementName = "DeptName")]
        public virtual string DeptName { get; set; }

        //权限详情
        [XmlElement(ElementName = "UsrMaintenance")]
        public virtual string UsrMaintenance { get; set; }

        //是否有权限
        [XmlElement(ElementName = "IsMaint")]
        public virtual string IsMaint { get; set; }
    }
}