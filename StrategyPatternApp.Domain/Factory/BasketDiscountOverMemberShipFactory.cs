using System;
using System.Collections.Generic;
using System.Text;
using StrategyPatternApp.Domain.DiscountRules;
using StrategyPatternApp.Domain.Enums;
using StrategyPatternApp.Domain.Models;

namespace StrategyPatternApp.Domain.Factory
{
    public class BasketDiscountOverMemberShipFactory : DiscountFactoryBase<BasketDiscountOverMemberShipFactory>
    {
        
        public static readonly IDictionary<DiscountTypesEnum, Func<DiscountBase,DiscountBase>> Creators =
           new Dictionary<DiscountTypesEnum, Func<DiscountBase,DiscountBase>>()
           {
                { DiscountTypesEnum.StandartUserDiscount, (parentDiscount) => new BasketDiscountStandartUser(parentDiscount) },
                { DiscountTypesEnum.SilverUserDiscount, (parentDiscount) => new BasketDiscountSilverUser(parentDiscount) },
                { DiscountTypesEnum.GoldUserDiscount, (parentDiscount) => new BasketDiscountGoldUser(parentDiscount) },
           };

        public override DiscountBase GetDiscountStrategy(Basket basket, DiscountBase parentDiscountStrategy)
        {
            DiscountBase bestStrategy = null;
            double bestPrice = 0;
            foreach (KeyValuePair<DiscountTypesEnum, Func<DiscountBase,DiscountBase>> discountStrategy in BasketDiscountOverMemberShipFactory.Creators)
            {
                DiscountBase currentStrategy = discountStrategy.Value(parentDiscountStrategy);
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
