using System;
using System.Collections.Generic;
using System.Text;
using StrategyPatternApp.Domain.DiscountRules;
using StrategyPatternApp.Domain.Enums;
using StrategyPatternApp.Domain.Models;

namespace StrategyPatternApp.Domain.Factory
{
    public class CategoryDiscountFactory : DiscountFactoryBase<CategoryDiscountFactory>
    {
        public static readonly IDictionary<int, double> Discounts =
           new Dictionary<int, double>()
           {
                { 1, 0.1 },
                { 2, 0.15 },
                { 3, 0.20 },
           };

        public override DiscountBase GetDiscountStrategy(Basket basket, DiscountBase parentDiscountStrategy)
        {
            return new CategoryDiscount(Discounts, parentDiscountStrategy);
        }
    }
}
