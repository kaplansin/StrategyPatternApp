using FluentAssertions;
using StrategyPatternApp.Domain.DiscountRules;
using StrategyPatternApp.Domain.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace StrategyPatternApp.Test
{
    public class BasketDiscountTest
    {
        private Basket Basket;
        public BasketDiscountTest()
        {
            User u = new User("user", MemberShipTypeEnum.STANDART);
            Basket = new Basket(u,DateTime.Now);
        }
        [Fact]
        public void BasketTotalNoDiscount()
        {
            //Arrange
            Product p1 = new Product("p1", 100,100);
            Product p2 = new Product("p2", 200,100);
            
            Basket.AddOrderProduct(new BasketProduct(p1, 1));
            Basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase discountStrategy = new NoDiscount();
            double discountedPrice = Basket.calcDiscountedTotal(discountStrategy);
            //Assert
            discountedPrice.Should().Be(300);
        }
        [Fact]
        public void BasketTotalProductDiscount()
        {
            //Arrange
            Product p1 = new Product("p1", 100, 90);
            Product p2 = new Product("p2", 200, 180);
          
            Basket.AddOrderProduct(new BasketProduct(p1, 1));
            Basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase discountStrategy = new ProductDiscount();
            double discountedPrice = Basket.calcDiscountedTotal(discountStrategy);
            //Assert
            discountedPrice.Should().Be(270);
        }

        [Fact]
        public void BasketDiscount15PercentOverTotal()
        {
            //Arrange
            Product p1 = new Product("p1", 250, 230);
            Product p2 = new Product("p2", 100, 90);
            
            Basket.AddOrderProduct(new BasketProduct(p1, 1));
            Basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase discountStrategy = new BasketDiscount15PercentOverTotal();
            double discountedPrice = Basket.calcDiscountedTotal(discountStrategy);
            //Assert
            discountedPrice.Should().Be(297.50);
        }

        [Fact]
        public void BasketDiscount20PercentOverTotal()
        {
            //Arrange
            Product p1 = new Product("p1", 450, 400);
            Product p2 = new Product("p2", 200, 150);
            
            Basket.AddOrderProduct(new BasketProduct(p1, 1));
            Basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase discountStrategy = new BasketDiscount20PercentOverTotal();
            double discountedPrice = Basket.calcDiscountedTotal(discountStrategy);
            //Assert
            discountedPrice.Should().Be(520);
        }

        [Fact]
        public void BasketDiscount25PercentOverTotal()
        {
            //Arrange
            Product p1 = new Product("p1", 800, 700);
            Product p2 = new Product("p2", 400, 250);
            
            Basket.AddOrderProduct(new BasketProduct(p1, 1));
            Basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase discountStrategy = new BasketDiscount25PercentOverTotal();
            double discountedPrice = Basket.calcDiscountedTotal(discountStrategy);
            //Assert
            discountedPrice.Should().Be(900);
        }

        [Fact]
        public void BlackFridayDiscount30PercentOverTotal()
        {
            //Arrange
            Product p1 = new Product("p1", 250, 230);
            Product p2 = new Product("p2", 100, 90);
         
            Basket.AddOrderProduct(new BasketProduct(p1, 1));
            Basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase discountStrategy = new BlackFridayDiscount30PercentOverTotal();
            double discountedPrice = Basket.calcDiscountedTotal(discountStrategy);
            //Assert
            discountedPrice.Should().Be(245);
        }

        [Fact]
        public void BlackFridayDiscount35PercentOverTotal()
        {
            //Arrange
            Product p1 = new Product("p1", 450, 400);
            Product p2 = new Product("p2", 200, 150);
            
            Basket.AddOrderProduct(new BasketProduct(p1, 1));
            Basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase discountStrategy = new BlackFridayDiscount35PercentOverTotal();
            double discountedPrice = Basket.calcDiscountedTotal(discountStrategy);
            //Assert
            discountedPrice.Should().Be(422.5);
        }

        [Fact]
        public void BlackFridayDiscount40PercentOverTotal()
        {
            //Arrange
            Product p1 = new Product("p1", 800, 700);
            Product p2 = new Product("p2", 400, 250);
            
            Basket.AddOrderProduct(new BasketProduct(p1, 1));
            Basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase discountStrategy = new BlackFridayDiscount40PercentOverTotal();
            double discountedPrice = Basket.calcDiscountedTotal(discountStrategy);
            //Assert
            discountedPrice.Should().Be(720);
        }

        [Fact]
        public void BasketDiscountOverStandartMemberShipType()
        {
            //Arrange
            Product p1 = new Product("p1", 800, 700);
            Product p2 = new Product("p2", 400, 250);
            User u = new User("user", MemberShipTypeEnum.STANDART);
            Basket = new Basket(u,DateTime.Now);
            Basket.AddOrderProduct(new BasketProduct(p1, 1));
            Basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase productDiscountStrategy = new ProductDiscount();
            DiscountBase memberShipDiscountStrategy = new BasketDiscountStandartUser(productDiscountStrategy);
            double discountedPrice = Basket.calcDiscountedTotal(memberShipDiscountStrategy);
            //Assert
            discountedPrice.Should().Be(950);
        }

        [Fact]
        public void BasketDiscountOverSilverMemberShipType()
        {
            //Arrange
            Product p1 = new Product("p1", 800, 700);
            Product p2 = new Product("p2", 400, 250);
            User u = new User("user", MemberShipTypeEnum.SILVER);
            Basket = new Basket(u,DateTime.Now);
            Basket.AddOrderProduct(new BasketProduct(p1, 1));
            Basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase productDiscountStrategy = new ProductDiscount();
            DiscountBase memberShipDiscountStrategy = new BasketDiscountSilverUser(productDiscountStrategy);
            double discountedPrice = Basket.calcDiscountedTotal(memberShipDiscountStrategy);
            //Assert
            discountedPrice.Should().Be(902.5);
        }
        [Fact]
        public void BasketDiscountOverGoldMemberShipType()
        {
            //Arrange
            Product p1 = new Product("p1", 800, 700);
            Product p2 = new Product("p2", 400, 250);
            User u = new User("user", MemberShipTypeEnum.GOLD);
            Basket = new Basket(u,DateTime.Now);
            Basket.AddOrderProduct(new BasketProduct(p1, 1));
            Basket.AddOrderProduct(new BasketProduct(p2, 1));
            //Act
            DiscountBase productDiscountStrategy = new ProductDiscount();
            DiscountBase memberShipDiscountStrategy = new BasketDiscountGoldUser(productDiscountStrategy);
            double discountedPrice = Basket.calcDiscountedTotal(memberShipDiscountStrategy);
            //Assert
            discountedPrice.Should().Be(855);
        }
        [Fact]
        public void CategoryDiscount()
        {
            //Arrange
            Brand brand = new Brand(1, "b1");
            Category category = new Category(1, "c1");
            Product p1 = new Product("p1", 800, 700, brand, category);

            Brand brand2 = new Brand(2, "b2");
            Category category2 = new Category(2, "c2");
            Product p2 = new Product("p2", 400, 250, brand2, category2);
            User u = new User("user", MemberShipTypeEnum.GOLD);
            Basket = new Basket(u, DateTime.Now);
            Basket.AddOrderProduct(new BasketProduct(p1, 1));
            Basket.AddOrderProduct(new BasketProduct(p2, 1));

            Dictionary<int, Double> categoryDiscounts = new Dictionary<int, double> { { 1, 0.1 }, { 3, 0.15 } };
            DiscountBase productDiscountStrategy = new ProductDiscount();
            DiscountBase categoryDiscountStrategy = new CategoryDiscount(categoryDiscounts, productDiscountStrategy);
            DiscountBase memberShipDiscountStrategy = new BasketDiscountGoldUser(categoryDiscountStrategy);
            double discountedPrice = Basket.calcDiscountedTotal(memberShipDiscountStrategy);
            //Act
            //700+250 =950 total after product discount
            //950 - 80 = 870 total after category discount
            //770 - 87 = 783 total after gold membership discount
            discountedPrice.Should().Be(783);
        }

        [Fact]
        public void CategoryDiscount_ProductDiscountDisabled()
        {
            //Arrange
            Brand brand = new Brand(1, "b1");
            Category category = new Category(1, "c1");
            Product p1 = new Product("p1", 800, 700, brand, category);

            Brand brand2 = new Brand(2, "b2");
            Category category2 = new Category(2, "c2");
            Product p2 = new Product("p2", 400, 250, brand2, category2);
            User u = new User("user", MemberShipTypeEnum.GOLD);
            Basket = new Basket(u, DateTime.Now);
            Basket.AddOrderProduct(new BasketProduct(p1, 1));
            Basket.AddOrderProduct(new BasketProduct(p2, 1));

            Dictionary<int, Double> categoryDiscounts = new Dictionary<int, double> { { 1, 0.1 }, { 3, 0.15 } };
            DiscountBase productDiscountStrategy = new ProductDiscount(false);
            DiscountBase categoryDiscountStrategy = new CategoryDiscount(categoryDiscounts, productDiscountStrategy);
            DiscountBase memberShipDiscountStrategy = new BasketDiscountGoldUser(categoryDiscountStrategy);
            double discountedPrice = Basket.calcDiscountedTotal(memberShipDiscountStrategy);
            //Act
            //800+400 =1200 total after product discount
            //1200 - 80 = 1120 total after category discount
            //1120 - 112 = 783 total after gold membership discount
            discountedPrice.Should().Be(1008);
        }
        
        

    }
}
