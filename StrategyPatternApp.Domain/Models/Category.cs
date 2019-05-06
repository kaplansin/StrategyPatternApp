using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternApp.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public Category(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

    }
}
