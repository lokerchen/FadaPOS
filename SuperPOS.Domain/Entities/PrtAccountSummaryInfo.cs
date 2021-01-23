using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPOS.Domain.Entities
{
    public class PrtAccountSummaryInfo
    {
        public virtual decimal TotalDeliveryCharge { get; set; }
        public virtual string TotalVAT { get; set; }
        public virtual string NotPaid { get; set; }
        public virtual int ShopCount { get; set; }
        public virtual decimal ShopAmount { get; set; }
        public virtual int DeliveryCount { get; set; }
        public virtual decimal DeliveryAmount { get; set; }
        public virtual int CollectionCount { get; set; }
        public virtual decimal CollectionAmount { get; set; }
        public virtual int FastFoodCount { get; set; }
        public virtual decimal FastFoodAmount { get; set; }
        public virtual int EatInCount { get; set; }
        public virtual decimal EatInAmount { get; set; }
        public virtual int PayType1Count { get; set; }
        public virtual decimal PayType1Amount { get; set; }
        public virtual int PayType2Count { get; set; }
        public virtual decimal PayType2Amount { get; set; }
        public virtual int PayType3Count { get; set; }
        public virtual decimal PayType3Amount { get; set; }
        public virtual int PayType4Count { get; set; }
        public virtual decimal PayType4Amount { get; set; }
        public virtual int PayType5Count { get; set; }
        public virtual decimal PayType5Amount { get; set; }

        public virtual string PayType1 { get; set; }
        public virtual string PayType2 { get; set; }
        public virtual string PayType3 { get; set; }
        public virtual string PayType4 { get; set; }
        public virtual string PayType5 { get; set; }

        public PrtAccountSummaryInfo()
        {
            
        }

        public PrtAccountSummaryInfo(decimal dTotalDeliveryCharge,
                                    int iShopCount,
                                    decimal dShopAmount,
                                    int iDeliveryCount,
                                    decimal dDeliveryAmount,
                                    int iCollectionCount,
                                    decimal dCollectionAmount,
                                    int iPayType1Count,
                                    decimal dPayType1Amount,
                                    int iPayType2Count,
                                    decimal dPayType2Amount,
                                    int iPayType3Count,
                                    decimal dPayType3Amount,
                                    int iPayType4Count,
                                    decimal dPayType4Amount,
                                    int iPayType5Count,
                                    decimal dPayType5Amount,
                                    int iFastFoodCount,
                                    decimal dFastFoodAmount)
        {
            this.TotalDeliveryCharge = dTotalDeliveryCharge;
            this.ShopCount = iShopCount;
            this.ShopAmount = dShopAmount;
            this.DeliveryCount = iDeliveryCount;
            this.DeliveryAmount = dDeliveryAmount;
            this.CollectionCount = iCollectionCount;
            this.CollectionAmount = dCollectionAmount;
            this.PayType1Count = iPayType1Count;
            this.PayType1Amount = dPayType1Amount;
            this.PayType2Count = iPayType2Count;
            this.PayType2Amount = dPayType2Amount;
            this.PayType3Count = iPayType3Count;
            this.PayType3Amount = dPayType3Amount;
            this.PayType4Count = iPayType4Count;
            this.PayType4Amount = dPayType4Amount;
            this.PayType5Count = iPayType5Count;
            this.PayType5Amount = dPayType5Amount;
            this.FastFoodCount = iFastFoodCount;
            this.FastFoodAmount = dFastFoodAmount;
        }
    }
}
