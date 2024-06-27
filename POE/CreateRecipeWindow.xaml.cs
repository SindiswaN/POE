using System;
using System.Collections.Generic;
using System.Windows;

namespace RecipeApp
{
    public partial class CreateRecipeWindow : Window
    {
        private List<Recipe> recipes;
        private Recipe newRecipe;

        public CreateRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            newRecipe = new Recipe();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var addIngredientWindow = new AddIngredientWindow(newRecipe);
            addIngredientWindow.Show();
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            var addStepWindow = new AddStepWindow(newRecipe);
            addStepWindow.Show();
        }

        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            newRecipe.Name = RecipeNameTextBox.Text;
            recipes.Add(newRecipe);
            MessageBox.Show("Recipe saved successfully!");
            this.Close();
        }
    }
}
