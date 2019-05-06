using System;
using System.Collections.Generic;
using System.Text;
using StrategyPatternApp.Domain.DiscountRules;
using StrategyPatternApp.Domain.Models;

namespace StrategyPatternApp.Domain.Factory
{
    public class StandartDiscountFactory : DiscountFactoryBase<StandartDiscountFactory>
    {
       
        public override DiscountBase GetDiscountStrategy(Basket basket,DiscountBase parentDiscountStrategy =null)
        {
            DiscountBase bestStrategy = null;
            double bestPrice = 0;
            //Product Discount + MembershipDiscount
            DiscountBase productDiscount = new ProductDiscount(true);
            DiscountBase membershipAndProductDiscount = BasketDiscountOverMemberShipFactory.Instance.GetDiscountStrategy(basket, productDiscount);
            bestStrategy = membershipAndProductDiscount;
            bestPrice = membershipAndProductDiscount.GetDiscountedTotal(basket);

            //Basket Discount + MembershipDiscount
            DiscountBase basketDiscount = BasketDiscountOverTotalFactory.Instance.GetDiscountStrategy(basket,null);
            DiscountBase memberShipAndBasketDiscount = BasketDiscountOverMemberShipFactory.Instance.GetDiscountStrategy(basket, basketDiscount);
            (bestPrice, bestStrategy) = GetBetterStrategy(bestPrice, bestStrategy, basket, memberShipAndBasketDiscount);
            //Product Discount + CategoryDiscount + MembershipDiscount
            DiscountBase categoryAndProductDiscount = CategoryDiscountFactory.Instance.GetDiscountStrategy(basket, productDiscount);
            DiscountBase membershipCategoryAndProdutDiscount = BasketDiscountOverMemberShipFactory.Instance.GetDiscountStrategy(basket, categoryAndProductDiscount);
            (bestPrice, bestStrategy) = GetBetterStrategy(bestPrice, bestStrategy, basket, membershipCategoryAndProdutDiscount);
            //Special Offer Basket Discount (like BlackFriday)

            DiscountBase blackFridayDiscountStrategy = BlackFridayDiscountFactory.Instance.GetDiscountStrategy(basket, null);
            (bestPrice, bestStrategy) = GetBetterStrategy(bestPrice, bestStrategy, basket, blackFridayDiscountStrategy);
            return bestStrategy;
        }
        
    }
}
