using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public partial class ScaleRecipeWindow : Window
    {
        private List<Recipe> recipes;

        public ScaleRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            RecipesComboBox.ItemsSource = recipes.OrderBy(r => r.Name).Select(r => r.Name).ToList();
        }

        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RecipesComboBox.SelectedItem != null)
                {
                    string selectedRecipeName = RecipesComboBox.SelectedItem.ToString();
                    Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name == selectedRecipeName);
                    if (selectedRecipe != null)
                    {
                        double factor = double.Parse(ScalingFactorTextBox.Text);
                        var scaledRecipeWindow = new ViewRecipeWindow(selectedRecipe, factor);
                        scaledRecipeWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please select a recipe.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a recipe.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
