using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    //Menu Item
    public class TaMenuItemInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //Dish Code
        [XmlElement(ElementName = "MiDishCode")]
        public virtual string MiDishCode { get; set; }

        //Position
        [XmlElement(ElementName = "MiPosition")]
        public virtual string MiPosition { get; set; }
        
        //English Name
        [XmlElement(ElementName = "MiEngName")]
        public virtual string MiEngName { get; set; }

        //Other Name
        [XmlElement(ElementName = "MiOtherName")]
        public virtual string MiOtherName { get; set; }

        //Regular Price
        [XmlElement(ElementName = "MiRegularPrice")]
        public virtual string MiRegularPrice { get; set; }

        //Special Regular Price
        [XmlElement(ElementName = "MiSpecialPrice")]
        public virtual string MiSpecialPrice { get; set; }

        //时段ID
        [XmlElement(ElementName = "MiSuppleShiftID")]
        public virtual int MiSuppleShiftID { get; set; }

        //打印机ID
        [XmlElement(ElementName = "MiPrintID")]
        public virtual int MiPrintID { get; set; }

        //Department code ID
        [XmlElement(ElementName = "MiDeptCodeID")]
        public virtual int MiDeptCodeID { get; set; }

        //Work day
        [XmlElement(ElementName = "MiWorkDay")]
        public virtual string MiWorkDay { get; set; }

        //Menu Category ID
        [XmlElement(ElementName = "MiMenuCateID")]
        public virtual string MiMenuCateID { get; set; }

        //Rmk
        [XmlElement(ElementName = "MiRmk")]
        public virtual string MiRmk { get; set; }

        //Menu Set ID
        [XmlElement(ElementName = "MiMenuSetID")]
        public virtual int MiMenuSetID { get; set; }

        //Large Price
        [XmlElement(ElementName = "MiLargePrice")]
        public virtual string MiLargePrice { get; set; }

        //Small Price
        [XmlElement(ElementName = "MiSmallPrice")]
        public virtual string MiSmallPrice { get; set; }

        //Button Color
        [XmlElement(ElementName = "MiBtnColor")]
        public virtual string MiBtnColor { get; set; }
    }
}