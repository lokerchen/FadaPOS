using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPOS.Print
{
    public class WbPrtTemplataTa
    {
        //Shop
        public string ImgLogo { get; set; }
        public string PrintAddress { get; set; }
        public string PrintTel { get; set; }
        public string VATNo { get; set; }
        public string ShopTime { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public string Staff { get; set; }
        public string OrderNo { get; set; }
        public string OrderItem { get; set; }
        public string ItemCount { get; set; }
        public string SubTotal { get; set; }
        public string Total { get; set; }
        public string PayType { get; set; }
        public string Msg1 { get; set; }
        public string Msg2 { get; set; }
        public string Msg3 { get; set; }
        public string Msg4 { get; set; }
        public string Msg5 { get; set; }

        //Fast Food
        public string RefNo { get; set; }

        //Receipt
        public string HeadingWord { get; set; }
        public string Tendered { get; set; }
        public string Change { get; set; }
        public string Rate1 { get; set; }
        public string Net1 { get; set; }
        public string VatA { get; set; }
        public string Gross1 { get; set; }
        public string Rate2 { get; set; }
        public string Net2 { get; set; }
        public string VatB { get; set; }
        public string Gross2 { get; set; }
        
        //Kitchen
        public string CustName { get; set; }
        public string CustPhone { get; set; }
        public string CustDist { get; set; }
        public string CustMapRef { get; set; }
        public string CustHouseNo { get; set; }
        public string CustAddr { get; set; }
        public string CustPostCode { get; set; }
        public string OrderType { get; set; }

        //Delivery Fee
        public string DeliveryFee { get; set; }
    }
}
