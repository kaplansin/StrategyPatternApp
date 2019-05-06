using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrategyPatternApp.Domain.Models;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public class ProductDiscount : DiscountBase
    {

        public ProductDiscount(bool isEnabled = true): base(isEnabled)
        {

        }
        public override double GetDiscountedTotal(Basket basket)
        {
            return basket.Total - this.GetDiscount(basket);
        }
        protected override double GetDiscount(Basket basket)
        {
            if (this.Enabled)
            {
                double discount = basket.GetOrderProducts().Sum(x => x.Product.GetPrice() - x.Product.GetDiscountedPrice() * x.Count);
                return Math.Round(discount, 2);
            }
            return 0;
        }
    }
}
