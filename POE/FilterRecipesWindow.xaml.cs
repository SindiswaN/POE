using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public partial class FilterRecipesWindow : Window
    {
        private List<Recipe> recipes;

        public FilterRecipesWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = IngredientTextBox.Text.ToLower();
            string foodGroup = FoodGroupTextBox.Text.ToLower();
            int maxCalories;
            bool isCaloriesParsed = int.TryParse(MaxCaloriesTextBox.Text, out maxCalories);

            var filteredRecipes = recipes.Where(r =>
                (string.IsNullOrEmpty(ingredient) || r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredient))) &&
                (string.IsNullOrEmpty(foodGroup) || r.Ingredients.Any(i => i.FoodGroup.ToLower().Contains(foodGroup))) &&
                (!isCaloriesParsed || r.CalculateTotalCalories() <= maxCalories)
            ).ToList();

            FilteredRecipesListBox.Items.Clear();
            foreach (var recipe in filteredRecipes)
            {
                FilteredRecipesListBox.Items.Add(recipe.Name);
            }

            if (filteredRecipes.Count == 0)
            {
                MessageBox.Show("No recipes match the filter criteria.");
            }
        }
    }
}
