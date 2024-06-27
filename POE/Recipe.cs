using System;
using System.Collections.Generic;

public class Recipe
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<string> Steps { get; set; }
    private List<double> originalQuantities;
    internal int Calories;
    internal string FoodGroup;

    public delegate void CaloriesExceededHandler(string recipeName);
    public event CaloriesExceededHandler CaloriesExceeded;

    public Recipe()
    {
        Ingredients = new List<Ingredient>();
        Steps = new List<string>();
        originalQuantities = new List<double>();
    }

    public void AddIngredient(string name, double quantity, string unit, int calories, string foodGroup)
    {
        Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
        originalQuantities.Add(quantity);
    }

    public void AddStep(string description)
    {
        Steps.Add(description);
    }

    public void PrintRecipe(double scale)
    {
        Console.WriteLine($"Recipe: {Name}\n");
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < Ingredients.Count; i++)
        {
            var scaledQuantity = Ingredients[i].Quantity * scale;
            Console.WriteLine($"- {scaledQuantity} {Ingredients[i].Unit} {Ingredients[i].Name} ({Ingredients[i].Calories * scale} calories)");
        }
        Console.WriteLine("\nSteps:");
        int stepNumber = 1;
        foreach (var step in Steps)
        {
            Console.WriteLine($"{stepNumber++}. {step}");
        }
    }

    public int CalculateTotalCalories()
    {
        int totalCalories = 0;
        foreach (var ingredient in Ingredients)
        {
            totalCalories += ingredient.Calories;
        }
        return totalCalories;
    }

    public void ResetQuantities()
    {
        for (int i = 0; i < Ingredients.Count; i++)
        {
            Ingredients[i].Quantity = originalQuantities[i];
        }
    }

    public void ClearRecipe()
    {
        Name = null;
        Ingredients.Clear();
        Steps.Clear();
        originalQuantities.Clear();
    }

    public void CheckCaloriesLimit(int limit)
    {
        if (CalculateTotalCalories() > limit)
        {
            CaloriesExceeded?.Invoke(Name);
        }
    }

    internal bool ContainsIngredient(string ingredientName)
    {
        return Ingredients.Any(i => i.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase));
    }
}
