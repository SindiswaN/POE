using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            var createRecipeWindow = new CreateRecipeWindow(recipes);
            createRecipeWindow.Show();
        }

        private void ListRecipes_Click(object sender, RoutedEventArgs e)
        {
            var listRecipesWindow = new ListRecipesWindow(recipes);
            listRecipesWindow.Show();
        }

        private void SelectRecipe_Click(object sender, RoutedEventArgs e)
        {
            var selectRecipeWindow = new SelectRecipeWindow(recipes);
            selectRecipeWindow.Show();
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            var scaleRecipeWindow = new ScaleRecipeWindow(recipes);
            scaleRecipeWindow.Show();
        }

        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes available.");
                return;
            }

            var resetQuantitiesWindow = new ResetQuantitiesWindow(recipes);
            resetQuantitiesWindow.Show();
        }

        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes available.");
                return;
            }

            var clearRecipeWindow = new ClearRecipeWindow(recipes);
            clearRecipeWindow.Show();
        }

        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            var filterRecipesWindow = new FilterRecipesWindow(recipes);
            filterRecipesWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
