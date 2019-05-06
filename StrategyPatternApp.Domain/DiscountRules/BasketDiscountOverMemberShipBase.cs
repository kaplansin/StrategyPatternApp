using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrategyPatternApp.Domain.Models;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public abstract class BasketDiscountOverMemberShipBase : DiscountBase
    {
        protected abstract double DiscountRatio { get; }
        public abstract MemberShipTypeEnum MemberShipType { get; }
        private DiscountBase ParentDiscountStrategy { get; set; }
        

        public BasketDiscountOverMemberShipBase(DiscountBase parentDiscountStrategy = null, bool isEnabled=true):base(isEnabled)
        {
            this.ParentDiscountStrategy = parentDiscountStrategy;
        }
        public override double GetDiscountedTotal(Basket basket)
        {
            if (ParentDiscountStrategy != null)
            {
                double parentDiscountedTotal = basket.calcDiscountedTotal(ParentDiscountStrategy);
            }
            return basket.DiscountedTotal - this.GetDiscount(basket);
        }

        public override bool IsEnabled(Basket basket)
        {
            if (base.IsEnabled(basket))
            {
                return basket.User.MemberShipType == this.MemberShipType;
            }
            return false;
        }
        protected override double GetDiscount(Basket basket)
        {
            if (this.Enabled)
            {
                return Math.Round(basket.DiscountedTotal * DiscountRatio, 2);
            }
            return 0;
        }
    }
}
