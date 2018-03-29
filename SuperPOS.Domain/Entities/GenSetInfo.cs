using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    //一般设定
    public class GenSetInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //起始账单号
        [XmlElement(ElementName = "TillNum")]
        public virtual string TillNum { get; set; }

        //账单收银符号
        [XmlElement(ElementName = "CheckCurrency")]
        public virtual string CheckCurrency { get; set; }

        //VAT百分比
        [XmlElement(ElementName = "VATPer")]
        public virtual string VATPer { get; set; }

        //是否在按钮上显示Item Code
        [XmlElement(ElementName = "IsShowItemCode")]
        public virtual string IsShowItemCode { get; set; }

        //退出时是否备份数据库
        [XmlElement(ElementName = "IsBackup")]
        public virtual string IsBackup { get; set; }

        //备份地址
        [XmlElement(ElementName = "BackupDriver")]
        public virtual string BackupDriver { get; set; }
    }
}
