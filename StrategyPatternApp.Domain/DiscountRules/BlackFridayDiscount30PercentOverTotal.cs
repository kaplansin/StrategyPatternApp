using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public class BlackFridayDiscount30PercentOverTotal : BlackFridayDiscountBase
    {
        
        public BlackFridayDiscount30PercentOverTotal(double minPrice = 101,
                                                double maxPrice = 500,
                                                double discountRatio = 0.30,
                                                bool isEnabled = true) : base(minPrice, maxPrice, discountRatio, isEnabled)
        {

        }
    }
}
