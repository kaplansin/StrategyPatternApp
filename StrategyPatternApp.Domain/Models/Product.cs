using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.Models
{
    public class Product
    {
        private string Name { get; set; }
        private double Price { get; set; }
        public Brand Brand { get; private set; }
        public Category Category { get; private set; }
        private double DiscountedPrice { get; set; }
        public Product(string name, double price, double discountedPrice)
        {
            this.Name = name;
            this.Price = price;
            this.DiscountedPrice = discountedPrice;
        }
        public Product(string name, double price, double discountedPrice, Brand brand, Category category)
            : this(name, price, discountedPrice)
        {
            this.Brand = brand;
            this.Category = category;
        }
        public double GetPrice()
        {
            return this.Price;
        }
        public double GetDiscountedPrice()
        {
            return this.DiscountedPrice;
        }
    }
}
