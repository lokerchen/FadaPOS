using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class OrderItemSumForVatInfo
    {
        public virtual string MiRmk { get; set; }
        public virtual decimal ItemTotalPrice { get; set; }
        

        public OrderItemSumForVatInfo()
        {
            
        }

        public OrderItemSumForVatInfo(string miRmk,
                                decimal itemTotalPrice)
        {
            this.MiRmk = miRmk;
            this.ItemTotalPrice = itemTotalPrice;
        }
    }
}
