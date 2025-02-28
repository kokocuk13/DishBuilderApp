using System;
using System.Collections.Generic;

namespace DishBuilderApp.logic
{
    internal class Dish
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Name} ({string.Join(", ", Ingredients)}) - {Price:C}";
        }
    }
}
