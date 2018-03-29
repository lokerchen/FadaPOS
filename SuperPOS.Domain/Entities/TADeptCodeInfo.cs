using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaDeptCodeInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //部门名称
        [XmlElement(ElementName = "DeptEngName")]
        public virtual string DeptEngName { get; set; }
        
        //部门其他名字
        [XmlElement(ElementName = "DeptOtherName")]
        public virtual string DeptOtherName { get; set; }
    }
}