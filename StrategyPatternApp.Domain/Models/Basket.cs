using StrategyPatternApp.Domain.DiscountRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPatternApp.Domain.Models
{
    public class Basket
    {
        private List<BasketProduct> BasketProducts { get; set; }
        public User User { get; private set; }
        public double DiscountedTotal { get; private set; }
        public double Total { get; private set; }
        public DateTime Date { get; set; }
        public Basket(User user, DateTime date)
        {
            this.User = user;
            this.BasketProducts= new List<BasketProduct>();
            this.Date = date;
        }
        public double GetTotal()
        {
            return this.BasketProducts.Sum(x => x.Product.GetPrice() * x.Count);
        }
        public void AddOrderProduct(BasketProduct orderProduct)
        {
            this.BasketProducts.Add(orderProduct);
            this.DiscountedTotal = this.GetTotal();
            this.Total = this.GetTotal();
        }
        public List<BasketProduct> GetOrderProducts()
        {
            return this.BasketProducts;
        }
        public double calcDiscountedTotal(DiscountBase discountStrategy)
        {
            DiscountedTotal =  discountStrategy.GetDiscountedTotal(this);
            return DiscountedTotal;
        }
    }
}
