using System;
using System.Windows;

namespace RecipeApp
{
    public partial class AddStepWindow : Window
    {
        private Recipe recipe;

        public AddStepWindow(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            string description = DescriptionTextBox.Text;
            recipe.AddStep(description);
            this.Close();
        }
    }
}
