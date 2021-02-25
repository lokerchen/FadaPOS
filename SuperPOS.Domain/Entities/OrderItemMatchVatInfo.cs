using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class OrderItemMatchVatInfo
    {
        public virtual string VatInfo { get; set; }
        public virtual decimal ItemTotalPrice { get; set; }
        
        public OrderItemMatchVatInfo()
        {
            
        }

        public OrderItemMatchVatInfo(string strVatInfo, decimal dItemTotalPrice)
        {
            this.VatInfo = strVatInfo;
            this.ItemTotalPrice = dItemTotalPrice;
        }
    }
}
