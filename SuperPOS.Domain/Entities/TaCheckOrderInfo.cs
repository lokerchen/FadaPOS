using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class TaCheckOrderInfo
    {
        [XmlElement(ElementName = "ID")]
        public virtual int ID { get; set; }

        //账单编号
        [XmlElement(ElementName = "CheckCode")]
        public virtual string CheckCode { get; set; }

        //订单类型
        [XmlElement(ElementName = "PayOrderType")]
        public virtual string PayOrderType { get; set; }

        //Delivery
        [XmlElement(ElementName = "PayDelivery")]
        public virtual string PayDelivery { get; set; }

        //Discount
        [XmlElement(ElementName = "PayDiscount")]
        public virtual string PayDiscount { get; set; }

        //Surcharge
        [XmlElement(ElementName = "PaySurcharge")]
        public virtual string PaySurcharge { get; set; }

        //菜品总额
        [XmlElement(ElementName = "MenuAmount")]
        public virtual string MenuAmount { get; set; }

        //需要付款
        [XmlElement(ElementName = "TotalAmount")]
        public virtual string TotalAmount { get; set; }

        //已付金额
        [XmlElement(ElementName = "Paid")]
        public virtual string Paid { get; set; }

        //是否已付完款
        [XmlElement(ElementName = "IsPaid")]
        public virtual string IsPaid { get; set; }

        //会员ID
        [XmlElement(ElementName = "CustomerID")]
        public virtual string CustomerID { get; set; }

        //会员备注
        [XmlElement(ElementName = "CustomerNote")]
        public virtual string CustomerNote { get; set; }

        //司机ID
        [XmlElement(ElementName = "DriverID")]
        public virtual int DriverID { get; set; }

        //下单员工ID
        [XmlElement(ElementName = "StaffID")]
        public virtual int StaffID { get; set; }

        //付款时间
        [XmlElement(ElementName = "PayTime")]
        public virtual string PayTime { get; set; }

        //PayType1
        [XmlElement(ElementName = "PayType1")]
        public virtual string PayType1 { get; set; }

        //PayType1 付款金额
        [XmlElement(ElementName = "PayTypePay1")]
        public virtual string PayTypePay1 { get; set; }

        //PayType2
        [XmlElement(ElementName = "PayType2")]
        public virtual string PayType2 { get; set; }

        //PayType2 付款金额
        [XmlElement(ElementName = "PayTypePay2")]
        public virtual string PayTypePay2 { get; set; }

        //PayType3
        [XmlElement(ElementName = "PayType3")]
        public virtual string PayType3 { get; set; }

        //PayType3 付款金额
        [XmlElement(ElementName = "PayTypePay3")]
        public virtual string PayTypePay3 { get; set; }

        //PayType4
        [XmlElement(ElementName = "PayType4")]
        public virtual string PayType4 { get; set; }

        //PayType4 付款金额
        [XmlElement(ElementName = "PayTypePay4")]
        public virtual string PayTypePay4 { get; set; }

        //PayType5
        [XmlElement(ElementName = "PayType5")]
        public virtual string PayType5 { get; set; }

        //PayType5 付款金额
        [XmlElement(ElementName = "PayTypePay5")]
        public virtual string PayTypePay5 { get; set; }

        //PayType4 付款金额
        [XmlElement(ElementName = "PayPerDiscount")]
        public virtual string PayPerDiscount { get; set; }

        //PayType4 付款金额
        [XmlElement(ElementName = "PayPerSurcharge")]
        public virtual string PayPerSurcharge { get; set; }

        //是否取消账单
        [XmlElement(ElementName = "IsCancel")]
        public virtual string IsCancel { get; set; }

        //是否临时保存账单
        [XmlElement(ElementName = "IsSave")]
        public virtual string IsSave { get; set; }

        //是否临时保存账单
        [XmlElement(ElementName = "BusDate")]
        public virtual string BusDate { get; set; }

        [XmlElement(ElementName = "RefNum")]
        public virtual string RefNum { get; set; }

        [XmlElement(ElementName = "DeliveryFee")]
        public virtual string DeliveryFee { get; set; }

        public TaCheckOrderInfo()
        {

        }

        public TaCheckOrderInfo(int iID,
                                string strCheckCode,
                                string strPayOrderType,
                                string strPayDelivery,
                                string strPayPerDiscount,
                                string strPayDiscount,
                                string strPayPerSurcharge,
                                string strPaySurcharge,
                                string strMenuAmount,
                                string strTotalAmount,
                                string strPaid,
                                string strIsPaid,
                                string strCustomerID,
                                string strCustomerNote,
                                int iDriverID,
                                int iStaffID,
                                string strPayTime,
                                string strPayType1,
                                string strPayTypePay1,
                                string strPayType2,
                                string strPayTypePay2,
                                string strPayType3,
                                string strPayTypePay3,
                                string strPayType4,
                                string strPayTypePay4,
                                string strPayType5,
                                string strPayTypePay5,
                                string strIsCancel,
                                string strIsSave,
                                string strBusDate,
                                string strRefNum,
                                string strDeliveryFee)
        {
            this.ID = iID;
            this.CheckCode = strCheckCode;
            this.PayOrderType= strPayOrderType;
            this.PayDelivery = strPayDelivery;
            this.PayDiscount = strPayDiscount;
            this.PaySurcharge = strPaySurcharge;
            this.MenuAmount = strMenuAmount;
            this.TotalAmount = strTotalAmount;
            this.Paid = strPaid;
            this.IsPaid = strIsPaid;
            this.CustomerID = strCustomerID;
            this.CustomerNote = strCustomerNote;
            this.DriverID = iDriverID;
            this.StaffID = iStaffID;
            this.PayTime = strPayTime;
            this.PayType1 = strPayType1;
            this.PayTypePay1 = strPayTypePay1;
            this.PayType2 = strPayType2;
            this.PayTypePay2 = strPayTypePay2;
            this.PayType3 = strPayType3;
            this.PayTypePay3 = strPayTypePay3;
            this.PayType4 = strPayType4;
            this.PayTypePay4 = strPayTypePay4;
            this.PayType5 = strPayType5;
            this.PayTypePay5 = strPayTypePay5;
            this.PayPerDiscount = strPayPerDiscount;
            this.PayPerSurcharge = strPayPerSurcharge;
            this.IsCancel = strIsCancel;
            this.IsSave = strIsSave;
            this.BusDate = strBusDate;
            this.RefNum = strRefNum;
            this.DeliveryFee = strDeliveryFee;
        }
    }
}