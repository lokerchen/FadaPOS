using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaCustomerInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //Phone #1
        [XmlElement(ElementName = "cusPhone")]
        public virtual string cusPhone { get; set; }

        //Name
        [XmlElement(ElementName = "cusName")]
        public virtual string cusName { get; set; }

        //House No.
        [XmlElement(ElementName = "cusHouseNo")]
        public virtual string cusHouseNo { get; set; }

        //Address #1
        [XmlElement(ElementName = "cusAddr")]
        public virtual string cusAddr { get; set; }

        //Postcode #1
        [XmlElement(ElementName = "cusPostcode")]
        public virtual string cusPostcode { get; set; }

        //Distance
        [XmlElement(ElementName = "cusDistance")]
        public virtual string cusDistance { get; set; }

        //PC Zone
        [XmlElement(ElementName = "cusPcZone")]
        public virtual string cusPcZone { get; set; }

        //Del Charge
        [XmlElement(ElementName = "cusDelCharge")]
        public virtual string cusDelCharge { get; set; }

        //Ready Time
        [XmlElement(ElementName = "cusReadyTime")]
        public virtual string cusReadyTime { get; set; }

        //Int. Notes
        [XmlElement(ElementName = "cusIntNotes")]
        public virtual string cusIntNotes { get; set; }

        //Notes on bill
        [XmlElement(ElementName = "cusNotesOnBill")]
        public virtual string cusNotesOnBill { get; set; }

        //Black Listed
        [XmlElement(ElementName = "cusIsBlack")]
        public virtual string cusIsBlack { get; set; }

        //Delivery / Collection Note
        [XmlElement(ElementName = "cusNote")]
        public virtual string cusNote { get; set; }
    }
}