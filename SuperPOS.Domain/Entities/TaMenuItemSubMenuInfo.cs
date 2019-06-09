using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaMenuItemSubMenuInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //SubMenu 英文名
        [XmlElement(ElementName = "SmEngName")]
        public virtual string SmEngName { get; set; }

        //SubMenu 其他名
        [XmlElement(ElementName = "SmOtherName")]
        public virtual string SmOtherName { get; set; }

        //关联Menu Item ID
        [XmlElement(ElementName = "SmMiID")]
        public virtual int SmMiID { get; set; }

        //Auto Expand
        [XmlElement(ElementName = "IsAutoExpand")]
        public virtual string IsAutoExpand { get; set; }

        //Show Conten On Print Out
        [XmlElement(ElementName = "IsShowContentOnPrtOut")]
        public virtual string IsShowContentOnPrtOut { get; set; }
    }
}
