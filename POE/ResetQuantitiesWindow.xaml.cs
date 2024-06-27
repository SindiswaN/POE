using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public partial class ResetQuantitiesWindow : Window
    {
        private List<Recipe> recipes;

        public ResetQuantitiesWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            RecipesComboBox.ItemsSource = recipes.OrderBy(r => r.Name).Select(r => r.Name).ToList();
        }

        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            string selectedRecipeName = RecipesComboBox.SelectedItem.ToString();
            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name == selectedRecipeName);
            if (selectedRecipe != null)
            {
                selectedRecipe.ResetQuantities();
                MessageBox.Show("Quantities reset successfully!");
            }
            else
            {
                MessageBox.Show("Please select a recipe.");
            }
        }
    }
}
