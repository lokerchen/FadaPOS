using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class AccountSummaryInfo
    {
        public virtual int ID { get; set; }
        public virtual string CheckCode { get; set; }
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
        public virtual string PayOrderType { get; set; }
        public virtual string PayTime { get; set; }
        public virtual decimal TotalAmount { get; set; }
        public virtual string DriverName { get; set; }
        public virtual string UsrName { get; set; }
        public virtual int CustomerID { get; set; }
        public virtual string PayPerDiscount { get; set; }
        public virtual decimal PayDiscount { get; set; }
        public virtual decimal MenuAmount { get; set; }
        public virtual string BusDate { get; set; }
        public virtual string Paid { get; set; }
        public virtual string RefNum { get; set; }
        public virtual decimal DeliveryFee { get; set; }
        public virtual int StaffID { get; set; }
        public virtual decimal PaySurcharge { get; set; }

        public AccountSummaryInfo()
        {
            
        }

        public AccountSummaryInfo(int ID,
                                string CheckCode,
                                string PayType1,
                                string PayType2,
                                string PayType3,
                                string PayType4,
                                string PayType5,
                                string PayOrderType,
                                string PayTime,
                                decimal TotalAmount,
                                string DriverName,
                                string UsrName,
                                int CustomerID,
                                string PayPerDiscount,
                                decimal PayDiscount,
                                decimal MenuAmount,
                                string BusDate,
                                string Paid,
                                string RefNum,
                                decimal DeliveryFee,
                                int StaffID,
                                decimal PaySurcharge,
                                string PayTypePay1,
                                string PayTypePay2,
                                string PayTypePay3,
                                string PayTypePay4,
                                string PayTypePay5)
        {
            this.ID = ID;
            this.CheckCode = CheckCode;
            this.PayType1 = PayType1;
            this.PayType2 = PayType2;
            this.PayType3 = PayType3;
            this.PayType4 = PayType4;
            this.PayType5 = PayType5;
            this.PayOrderType = PayOrderType;
            this.PayTime = PayTime;
            this.TotalAmount = TotalAmount;
            this.DriverName = DriverName;
            this.UsrName = UsrName;
            this.CustomerID = CustomerID;
            this.PayPerDiscount = PayPerDiscount;
            this.PayDiscount = PayDiscount;
            this.MenuAmount = MenuAmount;
            this.BusDate = BusDate;
            this.Paid = Paid;
            this.RefNum = RefNum;
            this.DeliveryFee = DeliveryFee;
            this.StaffID = StaffID;
            this.PaySurcharge = PaySurcharge;
            this.PayTypePay1 = PayTypePay1;
            this.PayTypePay2 = PayTypePay2;
            this.PayTypePay3 = PayTypePay3;
            this.PayTypePay4 = PayTypePay4;
            this.PayTypePay5 = PayTypePay5;
        }
    }
}
