using StrategyPatternApp.Domain.DiscountRules;
using StrategyPatternApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.Factory
{
    public abstract class DiscountFactoryBase<T>  where T : new()
    {
        protected static T instance = default(T);
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }
                return instance;
            }
        }

        public abstract DiscountBase GetDiscountStrategy(Basket basket, DiscountBase parentDiscountStrategy);

        protected virtual (double price, DiscountBase) GetBetterStrategy(double discountedPrice, DiscountBase currentStragey, Basket basket, DiscountBase nextDiscountStrategy)
        {
            if (nextDiscountStrategy != null)
            {
                double nextPrice = nextDiscountStrategy.GetDiscountedTotal(basket);
                if (currentStragey == null ||  nextPrice < discountedPrice)
                {
                    return (nextPrice, nextDiscountStrategy);
                }
            }
            return (discountedPrice, currentStragey);
        }
    }
}
