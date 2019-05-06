using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public class BasketDiscount15PercentOverTotal : BasketDiscountOverTotalBase
    {
        
        public BasketDiscount15PercentOverTotal(double minPrice =101, 
                                                double maxPrice=500, 
                                                double discountRatio=0.15,
                                                bool isEnabled = true): base(minPrice, maxPrice, discountRatio, isEnabled)
        {
            
        }
    }
}
