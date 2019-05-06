using System;
using System.Collections.Generic;
using System.Text;
using StrategyPatternApp.Domain.Models;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public class CategoryDiscount : DiscountBase
    {
        private IDictionary<int, double> CategoryDiscounts { get; set; }
        private DiscountBase ParentDiscountStrategy { get; set; }
        public CategoryDiscount(IDictionary<int, double> categoryDiscounts, DiscountBase parentDiscountStrategy, bool isEnabled=true):base(isEnabled)
        {
            this.ParentDiscountStrategy = parentDiscountStrategy;
            this.CategoryDiscounts = categoryDiscounts;
        }

        public override double GetDiscountedTotal(Basket basket)
        {
            if (ParentDiscountStrategy != null)
            {
                double parentDiscountedTotal = basket.calcDiscountedTotal(ParentDiscountStrategy);
                return parentDiscountedTotal - this.GetDiscount(basket);
                
            }
            else
            {
                return basket.GetTotal() - this.GetDiscount(basket);
            }
        }
        protected override double GetDiscount(Basket basket)
        {
            if (this.Enabled)
            {
                double discount = 0;
                foreach (BasketProduct basketProduct in basket.GetOrderProducts())
                {
                    if (basketProduct.Product?.Category != null && CategoryDiscounts.ContainsKey(basketProduct.Product.Category.Id))
                    {
                        discount += basketProduct.Product.GetPrice() * CategoryDiscounts[basketProduct.Product.Category.Id];
                    }
                }
                return Math.Round(discount, 2);
            }
            return 0;
        }
        
    }
}
