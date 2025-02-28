using DishBuilderApp.logic;
using System.Collections.Generic;
using System.Windows;

namespace DishBuilderApp
{
    public partial class MainWindow : Window
    {
        private BurgerBuilder _burgerBuilder;
        private OrderDirector _director;
        private List<string> _addedIngredients = new List<string>();
        private decimal _currentPrice = 0m;
        private bool _isBasicBurgerCreated = false; // Флаг для проверки создания базового бургера

        public MainWindow()
        {
            InitializeComponent();
            _burgerBuilder = new BurgerBuilder();
            _director = new OrderDirector(_burgerBuilder);
        }

        private void BuildBasicBurger_Click(object sender, RoutedEventArgs e)
        {
            
            _director.BuildBasicBurger();

            
            _isBasicBurgerCreated = true;

            
            _addedIngredients.Clear();
            _currentPrice = 5.00m; 

            
            _addedIngredients.Add("Базовый бургер: булочки, котлета");

            
            UpdateIngredientsList();
            UpdatePrice();
        }

        private void AddCheese_Click(object sender, RoutedEventArgs e)
        {
            if (!_isBasicBurgerCreated) 
            {
                MessageBox.Show("Сначала создайте базовый бургер!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            _burgerBuilder.AddIngredient("Сыр");
            _addedIngredients.Add("Сыр");
            _currentPrice += 1.50m; 

            
            UpdateIngredientsList();
            UpdatePrice();
        }

        private void AddBacon_Click(object sender, RoutedEventArgs e)
        {
            if (!_isBasicBurgerCreated) 
            {
                MessageBox.Show("Сначала создайте базовый бургер!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            _burgerBuilder.AddIngredient("Бекон");
            _addedIngredients.Add("Бекон");
            _currentPrice += 2.00m;

            
            UpdateIngredientsList();
            UpdatePrice();
        }

        private void FinishOrder_Click(object sender, RoutedEventArgs e)
        {
            if (!_isBasicBurgerCreated) 
            {
                MessageBox.Show("Сначала создайте базовый бургер!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Получаем результат из строителя
            var burger = _burgerBuilder.GetResult();

            
            ResultTextBlock.Text = $"Заказ завершен: {burger}. Итоговая цена: {_currentPrice:C}";

            
            ClearOrder();
        }

        private void ClearOrder_Click(object sender, RoutedEventArgs e)
        {
            
            ClearOrder();

            
            UpdateIngredientsList();
            UpdatePrice();
            ResultTextBlock.Text = "Заказ очищен.";
        }

        private void ClearOrder()
        {
            _isBasicBurgerCreated = false;
            _addedIngredients.Clear();
            _currentPrice = 0m;
        }

        private void UpdateIngredientsList()
        {
            IngredientsListBox.Items.Clear();
            foreach (var ingredient in _addedIngredients)
            {
                IngredientsListBox.Items.Add(ingredient);
            }
        }

        private void UpdatePrice()
        {
            PriceTextBlock.Text = $"Текущая цена: {_currentPrice:C}";
        }
    }
}
