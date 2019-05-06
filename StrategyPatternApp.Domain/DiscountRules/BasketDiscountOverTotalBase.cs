using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrategyPatternApp.Domain.Models;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public abstract class BasketDiscountOverTotalBase : DiscountBase
    {
        protected double MinPrice { get; set; }
        protected double MaxPrice { get; set; }
        protected double DiscountRatio { get; set; }
        public BasketDiscountOverTotalBase(double minPrice, double maxPrice, double discountRatio,bool isEnabled = true): base(isEnabled)
        {
            this.MinPrice = minPrice;
            this.MaxPrice = maxPrice;
            this.DiscountRatio = discountRatio;
        }
        public override double GetDiscountedTotal(Basket basket)
        {
            
            if(MinPrice ==0 || ( MinPrice > 0 && basket.Total >= MinPrice))
            {
                if(MaxPrice == 0 || (MaxPrice > 0 && basket.Total <= MaxPrice))
                {
                    return basket.Total - this.GetDiscount(basket);
                }
            }
            return basket.Total;
        }

        protected override double GetDiscount(Basket basket)
        {
            if (this.Enabled)
            {
                return Math.Round(basket.Total * DiscountRatio, 2);
            }
            return 0;
        }
        public override bool IsEnabled(Basket basket)
        {
            if (base.IsEnabled(basket))
            {
                if(basket.GetTotal() >= this.MinPrice && basket.GetTotal() <= this.MaxPrice)
                {
                    return true;
                }
            }
            return true;
        }
    }
}
