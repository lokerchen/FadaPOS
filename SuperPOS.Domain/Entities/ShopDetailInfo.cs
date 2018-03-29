using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    //店铺详情
    public class ShopDetailInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //店铺名称
        [XmlElement(ElementName = "ShopName")]
        public virtual string ShopName { get; set; }

        //店铺地址
        [XmlElement(ElementName = "ShopAddr")]
        public virtual string ShopAddr { get; set; }

        //店铺电话
        [XmlElement(ElementName = "ShopTelNo")]
        public virtual string ShopTelNo { get; set; }

        //VAT
        [XmlElement(ElementName = "ShopVATNo")]
        public virtual string ShopVATNo { get; set; }
    }
}
