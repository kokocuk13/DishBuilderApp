namespace DishBuilderApp.logic
{
    internal class OrderDirector
    {
        private IDishBuilder _builder;

        public OrderDirector(IDishBuilder builder)
        {
            _builder = builder;
        }

        public void BuildBasicBurger()
        {
            _builder.SetName();
            _builder.AddIngredient("Bun");
            _builder.AddIngredient("Beef Patty");
            _builder.SetPrice(5.99m);
        }
    }
}
