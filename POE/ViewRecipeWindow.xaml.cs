using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public partial class ViewRecipeWindow : Window
    {
        public ViewRecipeWindow(Recipe recipe, double scale = 1)
        {
            InitializeComponent();
            RecipeNameLabel.Content = recipe.Name;
            IngredientsListView.ItemsSource = recipe.Ingredients.Select(i => new
            {
                i.Name,
                ScaledQuantity = i.Quantity * scale,
                i.Unit,
                ScaledCalories = i.Calories * scale,
                i.FoodGroup
            }).ToList();
            StepsListView.ItemsSource = recipe.Steps.Select((step, index) => new { StepNumber = index + 1, Description = step }).ToList();
            TotalCaloriesLabel.Content = $"Total Calories: {recipe.CalculateTotalCalories() * scale}";

            // Subscribe to the calories exceeded event
            recipe.CaloriesExceeded += OnCaloriesExceeded;
            recipe.CheckCaloriesLimit(300 / (int)scale); // Check if scaled calories exceed 300
        }

        private void OnCaloriesExceeded(string recipeName)
        {
            MessageBox.Show($"WARNING: Calories in '{recipeName}' exceed 300!");
        }
    }
}
