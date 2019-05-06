using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public class BasketDiscount25PercentOverTotal : BasketDiscountOverTotalBase
    {
        
        public BasketDiscount25PercentOverTotal(double minPrice = 1001,
                                               double maxPrice = 0,
                                               double discountRatio = 0.25,
                                               bool isEnabled = true) : base(minPrice, maxPrice, discountRatio, isEnabled)
        {

        }
    }
}
