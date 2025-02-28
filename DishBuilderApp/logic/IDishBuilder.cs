namespace DishBuilderApp.logic
{
    internal interface IDishBuilder
    {
        void SetName();
        void AddIngredient(string ingredient);
        void SetPrice(decimal price);
        Dish GetResult();
    }
}
