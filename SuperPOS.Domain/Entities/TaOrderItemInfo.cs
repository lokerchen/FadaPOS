using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaOrderItemInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //菜品ID
        [XmlElement(ElementName = "ItemCode")]
        public virtual string ItemCode { get; set; }

        //菜品父ID，主要用来关联ItemParent
        [XmlElement(ElementName = "ItemID")]
        public virtual string ItemID { get; set; }

        //菜品名称
        [XmlElement(ElementName = "ItemDishName")]
        public virtual string ItemDishName { get; set; }

        //菜品其他名称
        [XmlElement(ElementName = "ItemDishOtherName")]
        public virtual string ItemDishOtherName { get; set; }

        //菜品数量
        [XmlElement(ElementName = "ItemQty")]
        public virtual string ItemQty { get; set; }

        //菜品单价
        [XmlElement(ElementName = "ItemPrice")]
        public virtual string ItemPrice { get; set; }

        //菜品总价
        [XmlElement(ElementName = "ItemTotalPrice")]
        public virtual string ItemTotalPrice { get; set; }

        //账单编号
        [XmlElement(ElementName = "CheckCode")]
        public virtual string CheckCode { get; set; }

        //菜品类型
        [XmlElement(ElementName = "ItemType")]
        public virtual int ItemType { get; set; }

        //菜品父ID
        [XmlElement(ElementName = "ItemParent")]
        public virtual string ItemParent { get; set; }

        //菜品下单时间
        [XmlElement(ElementName = "OrderTime")]
        public virtual string OrderTime { get; set; }

        //菜品下单员工
        [XmlElement(ElementName = "OrderStaff")]
        public virtual int OrderStaff { get; set; }

        //菜品下单营业日期
        [XmlElement(ElementName = "BusDate")]
        public virtual string BusDate { get; set; }

        //MenuItem的ID
        [XmlElement(ElementName = "MenuItemID")]
        public virtual int MenuItemID { get; set; }
    }
}