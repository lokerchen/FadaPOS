using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaPreviewInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //预览类型
        [XmlElement(ElementName = "PreviewType")]
        public virtual string PreviewType { get; set; }

        //预览文件名
        [XmlElement(ElementName = "PreviewFileName")]
        public virtual string PreviewFileName { get; set; }

        //模板内容
        [XmlElement(ElementName = "PreviewContent")]
        public virtual string PreviewContent { get; set; }
    }
}
