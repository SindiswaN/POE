using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public partial class SelectRecipeWindow : Window
    {
        private List<Recipe> recipes;

        public SelectRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            RecipesListView.ItemsSource = recipes.OrderBy(r => r.Name).ToList();
        }

        private void SelectRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)RecipesListView.SelectedItem;
            if (selectedRecipe != null)
            {
                var viewRecipeWindow = new ViewRecipeWindow(selectedRecipe);
                viewRecipeWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a recipe.");
            }
        }

        private void RecipesListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
