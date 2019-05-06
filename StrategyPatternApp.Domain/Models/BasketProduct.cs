using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.Models
{
    public class BasketProduct
    {
        public Product Product { get; set; }
        public int Count { get; set; }

        public BasketProduct(Product product, int count)
        {
            this.Product = product;
            this.Count = count;
        }
    }
}
