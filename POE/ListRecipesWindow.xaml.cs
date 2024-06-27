using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public partial class ListRecipesWindow : Window
    {
        public ListRecipesWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            RecipesListView.ItemsSource = recipes.OrderBy(r => r.Name).ToList();
        }
    }
}