using System;
using System.Collections.Generic;
using System.Text;
using StrategyPatternApp.Domain.DiscountRules;
using StrategyPatternApp.Domain.Enums;
using StrategyPatternApp.Domain.Models;

namespace StrategyPatternApp.Domain.Factory
{
    public class BlackFridayDiscountFactory : DiscountFactoryBase<BlackFridayDiscountFactory>
    {
       
        public static readonly IDictionary<DiscountTypesEnum, Func<DiscountBase>> Creators =
           new Dictionary<DiscountTypesEnum, Func<DiscountBase>>()
           {
                { DiscountTypesEnum.BlackFriday30Percent, () => new BlackFridayDiscount30PercentOverTotal() },
                { DiscountTypesEnum.BlackFriday35Percent, () => new BlackFridayDiscount35PercentOverTotal() },
                { DiscountTypesEnum.BlackFriday40Percent, () => new BlackFridayDiscount40PercentOverTotal() },
           };

        public override DiscountBase GetDiscountStrategy(Basket basket, DiscountBase parentDiscountStrategy)
        {


            DiscountBase bestStrategy = null;
            double bestPrice = 0;
            foreach (KeyValuePair<DiscountTypesEnum, Func<DiscountBase>> discountStrategy in BlackFridayDiscountFactory.Creators)
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
