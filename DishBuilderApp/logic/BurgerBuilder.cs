using System;
using System.Collections.Generic;

namespace DishBuilderApp.logic
{
    internal class BurgerBuilder : IDishBuilder
    {
        private Dish _burger = new Dish();

        public void SetName()
        {
            _burger.Name = "Basic Burger";
        }

        public void AddIngredient(string ingredient)
        {
            _burger.Ingredients.Add(ingredient);
        }

        public void SetPrice(decimal price)
        {
            _burger.Price = price;
        }

        public Dish GetResult()
        {
            return _burger;
        }
    }
}
