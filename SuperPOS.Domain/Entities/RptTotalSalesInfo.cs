using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class RptTotalSalesInfo
    {
        public virtual string ItemCode { get; set; }
        public virtual string ItemDishName { get; set; }
        public virtual string ItemDishOtherName { get; set; }
        public virtual int ItemQty { get; set; }
        public virtual decimal ItemTotalPrice { get; set; }
       
        public RptTotalSalesInfo()
        {
            
        }

        public RptTotalSalesInfo(string ItemCode,
                                 string ItemDishName,
                                 string ItemDishOtherName,
                                 int ItemQty,
                                 decimal ItemTotalPrice)
        {
            this.ItemCode = ItemCode;
            this.ItemDishName = ItemDishName;
            this.ItemDishOtherName = ItemDishOtherName;
            this.ItemQty = ItemQty;
            this.ItemTotalPrice = ItemTotalPrice;
 
        }
    }
}
