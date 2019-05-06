using StrategyPatternApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.DiscountRules
{
    public abstract class DiscountBase
    {
        protected bool Enabled { get; set; }
        public abstract double GetDiscountedTotal(Basket basket);
        protected abstract double GetDiscount(Basket basket);
        public DiscountBase(bool enabled)
        {
            
            this.Enabled = enabled;
        }
        public virtual bool IsEnabled(Basket basket)
        {
            return this.Enabled;
        }
    }
}
