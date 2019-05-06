using StrategyPatternApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public class NoDiscount : DiscountBase
    {
        public NoDiscount(bool isEnabled = true): base(isEnabled)
        {

        }
        public override double GetDiscountedTotal(Basket basket)
        {
            return basket.Total - this.GetDiscount(basket);
        }
        protected override double GetDiscount(Basket basket)
        {
            return 0;
        }
    }
}
