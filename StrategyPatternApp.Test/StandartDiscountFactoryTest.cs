using FluentAssertions;
using StrategyPatternApp.Domain.DiscountRules;
using StrategyPatternApp.Domain.Factory;
using StrategyPatternApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StrategyPatternApp.Test
{
    public class StandartDiscountFactoryTest
    {
        [Fact]
        public void ProductDiscountTest()
        {
            //Arrange
            User u = new User("user", MemberShipTypeEnum.STANDART);
            Basket basket = new Basket(u, DateTime.Now);
            Product p1 = new Product("p1", 50, 45);
            Product p2 = new Product("p2", 40, 30);
            basket.AddOrderProduct(new BasketProduct(p1, 1));
            basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase discountStrategy = StandartDiscountFactory.Instance.GetDiscountStrategy(basket);
            double discountedPrice = basket.calcDiscountedTotal(discountStrategy);
            //Assert
            discountedPrice.Should().Be(75);

        }
    
        [Fact]
        public void BasketDiscount15PercentTest()
        {
            //Arrange
            User u = new User("user", MemberShipTypeEnum.STANDART);
            Basket basket = new Basket(u, DateTime.Now);
            Product p1 = new Product("p1", 100, 90);
            Product p2 = new Product("p2", 200, 180);
            basket.AddOrderProduct(new BasketProduct(p1, 1));
            basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase discountStrategy = StandartDiscountFactory.Instance.GetDiscountStrategy(basket);
            double discountedPrice = basket.calcDiscountedTotal(discountStrategy);
            //Assert
            discountedPrice.Should().Be(255);
            
        }

        [Fact]
        public void BlackFriday30PercentTest()
        {
            //Arrange
            User u = new User("user", MemberShipTypeEnum.STANDART);
            Basket basket = new Basket(u, new DateTime(2019,11,29));
            Product p1 = new Product("p1", 100, 90);
            Product p2 = new Product("p2", 200, 180);
            basket.AddOrderProduct(new BasketProduct(p1, 1));
            basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase discountStrategy = StandartDiscountFactory.Instance.GetDiscountStrategy(basket);
            double discountedPrice = basket.calcDiscountedTotal(discountStrategy);
            //Assert
            discountedPrice.Should().Be(210);

        }
        [Fact]
        public void BlackFriday35PercentTest()
        {
            //Arrange
            User u = new User("user", MemberShipTypeEnum.STANDART);
            Basket basket = new Basket(u, new DateTime(2019, 11, 29));
            Product p1 = new Product("p1", 250, 130);
            Product p2 = new Product("p2", 300, 270);
            basket.AddOrderProduct(new BasketProduct(p1, 1));
            basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase discountStrategy = StandartDiscountFactory.Instance.GetDiscountStrategy(basket);
            double discountedPrice = basket.calcDiscountedTotal(discountStrategy);
            //Assert
            discountedPrice.Should().Be(357.5);

        }
        [Fact]
        public void BlackFriday40PercentTest()
        {
            //Arrange
            User u = new User("user", MemberShipTypeEnum.STANDART);
            Basket basket = new Basket(u, new DateTime(2019, 11, 29));
            Product p1 = new Product("p1", 700, 650);
            Product p2 = new Product("p2", 500, 400);
            basket.AddOrderProduct(new BasketProduct(p1, 1));
            basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase discountStrategy = StandartDiscountFactory.Instance.GetDiscountStrategy(basket);
            double discountedPrice = basket.calcDiscountedTotal(discountStrategy);
            //Assert
            discountedPrice.Should().Be(720);

        }

    }
}
