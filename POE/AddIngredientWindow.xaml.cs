
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class AddIngredientWindow : Window
    {
        private Recipe recipe;

        public AddIngredientWindow(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            double quantity = double.Parse(QuantityTextBox.Text);
            string unit = UnitTextBox.Text;
            int calories = int.Parse(CaloriesTextBox.Text);
            string foodGroup = ((ComboBoxItem)FoodGroupComboBox.SelectedItem).Content.ToString();

            recipe.AddIngredient(name, quantity, unit, calories, foodGroup);
            this.Close();
        }
    }
}
