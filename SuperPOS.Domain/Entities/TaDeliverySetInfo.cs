using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaDeliverySetInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //Per Mile Thereafter
        [XmlElement(ElementName = "PerMile")]
        public virtual string PerMile { get; set; }

        //Delivery Charge Includes In Order
        [XmlElement(ElementName = "IsDeliveryCharge")]
        public virtual string IsDeliveryCharge { get; set; }

        //Ignore Delivery Surcharge When Distance Exceeds
        [XmlElement(ElementName = "DeliveryMile")]
        public virtual string DeliveryMile { get; set; }

        //Ignore Delivery Distance Charge If Surcharge Applies
        [XmlElement(ElementName = "IsIgnoreDelivery")]
        public virtual string IsIgnoreDelivery { get; set; }

        //Order Threshold
        [XmlElement(ElementName = "OrderThreshold")]
        public virtual string OrderThreshold { get; set; }

        //Surcharge Amount
        [XmlElement(ElementName = "SurchargeAmount")]
        public virtual string SurchargeAmount { get; set; }
    }
}
