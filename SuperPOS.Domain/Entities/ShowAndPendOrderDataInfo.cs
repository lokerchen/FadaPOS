using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperPOS.Domain.Entities
{
    public class ShowAndPendOrderDataInfo
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
        

        public ShowAndPendOrderDataInfo()
        {
            
        }

        public ShowAndPendOrderDataInfo(int iID,
                                        string strCheckCode,
                                        string strCustPostCode,
                                        string strCustPcZone,
                                        string strCustAddr,
                                        string strPayOrderType,
                                        string strCustName,
                                        string strCustPhone,
                                        string strIsPaid,
                                        string strTotalAmount,
                                        string strUsrName,
                                        string strPaid,
                                        string strCustID,
                                        string strDriverID,
                                        string strDriverName,
                                        string strMenuAmount,
                                        string strPayDiscount,
                                        string strPayPerDiscount,
                                        string strIsSave,
                                        string strBusDate,
                                        string strRefNum,
                                        string strDeliveryFee,
                                        string strPaySurcharge,
                                        string strPayPerSurcharge,
                                        string strPayType1,
                                        string strPayType2,
                                        string strPayType3,
                                        string strPayType4,
                                        string strPayType5,
                                        string strPayTypePay1,
                                        string strPayTypePay2,
                                        string strPayTypePay3,
                                        string strPayTypePay4,
                                        string strPayTypePay5,
                                        string strIsCancel,
                                        string strPayTime,
                                        string strStaffID)
        {
            this.ID = iID; 
            this.CheckCode = strCheckCode; 
            this.CustPostCode = strCustPostCode; 
            this.CustPcZone = strCustPcZone; 
            this.CustAddr = strCustAddr; 
            this.PayOrderType = strPayOrderType; 
            this.CustName = strCustName; 
            this.CustPhone = strCustPhone; 
            this.IsPaid = strIsPaid; 
            this.TotalAmount = strTotalAmount; 
            this.UsrName = strUsrName; 
            this.Paid = strPaid; 
            this.CustID = strCustID; 
            this.DriverID = strDriverID; 
            this.DriverName = strDriverName; 
            this.MenuAmount = strMenuAmount; 
            this.PayDiscount = strPayDiscount; 
            this.PayPerDiscount = strPayPerDiscount; 
            this.IsSave = strIsSave; 
            this.BusDate = strBusDate; 
            this.RefNum = strRefNum; 
            this.DeliveryFee = strDeliveryFee; 
            this.PaySurcharge = strPaySurcharge; 
            this.PayPerSurcharge = strPayPerSurcharge; 
            this.PayType1 = strPayType1;
            this.PayType2 = strPayType2;
            this.PayType3 = strPayType3;
            this.PayType4 = strPayType4;
            this.PayType5 = strPayType5;
            this.PayTypePay1 = strPayTypePay1;
            this.PayTypePay2 = strPayTypePay2;
            this.PayTypePay3 = strPayTypePay3;
            this.PayTypePay4 = strPayTypePay4;
            this.PayTypePay5 = strPayTypePay5;
            this.IsCancel = strIsCancel;
            this.PayTime = strPayTime;
            this.StaffID = strStaffID;

            this.PayType = (Convert.ToDecimal(strPayTypePay1) > 0.00m ? strPayType1 : "") + @" " + 
                            (Convert.ToDecimal(strPayTypePay2) > 0.00m ? strPayType2 : "") + @" " +
                            (Convert.ToDecimal(strPayTypePay3) > 0.00m ? strPayType3 : "") + @" " + 
                            (Convert.ToDecimal(strPayTypePay4) > 0.00m ? strPayType4 : "") + @" " +
                            (Convert.ToDecimal(strPayTypePay5) > 0.00m ? strPayType5 : "") + @" ";
            this.Change = (Convert.ToDecimal(strPaid) - Convert.ToDecimal(strTotalAmount)) <= 0
                            ? "0.0"
                            : (Convert.ToDecimal(strPaid) - Convert.ToDecimal(strTotalAmount)).ToString("0.00");
        }
    }
}
