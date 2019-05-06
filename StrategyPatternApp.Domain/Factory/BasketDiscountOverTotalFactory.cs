using System;
using System.Collections.Generic;
using System.Text;
using StrategyPatternApp.Domain.DiscountRules;
using StrategyPatternApp.Domain.Enums;
using StrategyPatternApp.Domain.Models;

namespace StrategyPatternApp.Domain.Factory
{
    public class BasketDiscountOverTotalFactory : DiscountFactoryBase<BasketDiscountOverTotalFactory>
    {
        
        public static readonly IDictionary<DiscountTypesEnum, Func<DiscountBase>> Creators =
           new Dictionary<DiscountTypesEnum, Func<DiscountBase>>()
           {
                { DiscountTypesEnum.Basket15Percent, () => new BasketDiscount15PercentOverTotal() },
                { DiscountTypesEnum.Basket20Percent, () => new BasketDiscount20PercentOverTotal() },
                { DiscountTypesEnum.Basket25Percent, () => new BasketDiscount15PercentOverTotal() },
           };

        public override DiscountBase GetDiscountStrategy(Basket basket, DiscountBase parentDiscountStrategy)
        {
            DiscountBase bestStrategy = null;
            double bestPrice = 0;
            foreach (KeyValuePair<DiscountTypesEnum, Func<DiscountBase>> discountStrategy in BasketDiscountOverTotalFactory.Creators)
            {
                DiscountBase currentStrategy = discountStrategy.Value();
                if (currentStrategy.IsEnabled(basket)
                    && (bestStrategy == null || bestStrategy.GetDiscountedTotal(basket) > currentStrategy.GetDiscountedTotal(basket)))
                {
                    (bestPrice, bestStrategy) = this.GetBetterStrategy(bestPrice, bestStrategy, basket, currentStrategy);
                }
            }
            return bestStrategy;
        }
    }
}
