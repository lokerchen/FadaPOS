using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaSubMenuInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //Set Meal
        [XmlElement(ElementName = "SetMeal")]
        public virtual string SetMeal { get; set; }
    }
}
