using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaDeliveryNoteInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //Delivery Note
        [XmlElement(ElementName = "DeliveryNote")]
        public virtual string DeliveryNote { get; set; }
    }
}