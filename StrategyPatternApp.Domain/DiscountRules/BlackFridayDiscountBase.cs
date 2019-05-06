using StrategyPatternApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public abstract class BlackFridayDiscountBase : BasketDiscountOverTotalBase
    {
        public DateTime StartDate { get => new DateTime(2019,11, 28,0,0,0); }
        public DateTime EndDate { get => new DateTime(2019, 11, 30,0,0,0); }

        public BlackFridayDiscountBase(double minPrice = 101,
                                                double maxPrice = 500,
                                                double discountRatio = 0.15,
                                                bool isEnabled = true) : base(minPrice, maxPrice, discountRatio, isEnabled)
        {

        }

        public override bool IsEnabled(Basket basket)
        {
            if (base.IsEnabled(basket))
            {
                if(basket.Date >=StartDate && basket.Date <= EndDate)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
