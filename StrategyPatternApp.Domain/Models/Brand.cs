using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.Models
{
    public class Brand
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Brand(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
