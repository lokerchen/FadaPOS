using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class VIEW_ShowAndPendOrderInfo
    {
        public virtual int ID { get; set; }
        public virtual string CheckCode { get; set; }
        public virtual string CustPostCode { get; set; }
        public virtual string CustPcZone { get; set; }
        public virtual string CustAddr { get; set; }
        public virtual string PayOrderType { get; set; }
        public virtual string CustName { get; set; }
        public virtual string CustPhone { get; set; }
        public virtual string IsPaid { get; set; }
        public virtual string TotalAmount { get; set; }
        public virtual string UsrName { get; set; }
        public virtual string Paid { get; set; }
        public virtual string CustID { get; set; }
        public virtual string DriverID { get; set; }
        public virtual string DriverName { get; set; }
        public virtual string MenuAmount { get; set; }
        public virtual string PayDiscount { get; set; }
        public virtual string PayPerDiscount { get; set; }
        public virtual string IsSave { get; set; }
        public virtual string BusDate { get; set; }
        public virtual string RefNum { get; set; }
        public virtual string DeliveryFee { get; set; }
        public virtual string PaySurcharge { get; set; }
        public virtual string PayPerSurcharge { get; set; }
        public virtual string PayType1 { get; set; }
        public virtual string PayType2 { get; set; }
        public virtual string PayType3 { get; set; }
        public virtual string PayType4 { get; set; }
        public virtual string PayType5 { get; set; }
        public virtual string PayTypePay1 { get; set; }
        public virtual string PayTypePay2 { get; set; }
        public virtual string PayTypePay3 { get; set; }
        public virtual string PayTypePay4 { get; set; }
        public virtual string PayTypePay5 { get; set; }
        public virtual string IsCancel { get; set; }
        public virtual string PayTime { get; set; }
        public virtual string StaffID { get; set; }

        public virtual string PayType { get; set; }

        public virtual string Change { get; set; }
    }
}
