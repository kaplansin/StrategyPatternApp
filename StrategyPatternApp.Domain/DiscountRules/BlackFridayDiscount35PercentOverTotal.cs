using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public class BlackFridayDiscount35PercentOverTotal : BlackFridayDiscountBase
    {
        
        public BlackFridayDiscount35PercentOverTotal(double minPrice = 501,
                                              double maxPrice = 1000,
                                              double discountRatio = 0.35,
                                              bool isEnabled = true) : base(minPrice, maxPrice, discountRatio, isEnabled)
        {

        }

    }
}
