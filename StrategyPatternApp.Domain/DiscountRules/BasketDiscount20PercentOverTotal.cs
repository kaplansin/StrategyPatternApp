using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public class BasketDiscount20PercentOverTotal : BasketDiscountOverTotalBase
    {

        public BasketDiscount20PercentOverTotal(double minPrice = 501,
                                                double maxPrice = 1000,
                                                double discountRatio = 0.20,
                                                bool isEnabled = true) : base(minPrice, maxPrice, discountRatio, isEnabled)
        {

        }
    }
}
