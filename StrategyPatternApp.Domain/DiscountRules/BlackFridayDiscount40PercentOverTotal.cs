using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public class BlackFridayDiscount40PercentOverTotal : BlackFridayDiscountBase
    {
        public BlackFridayDiscount40PercentOverTotal(double minPrice = 1001,
                                             double maxPrice = 0,
                                             double discountRatio = 0.40,
                                             bool isEnabled = true) : base(minPrice, maxPrice, discountRatio, isEnabled)
        {

        }
    }
}
