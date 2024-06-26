using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10361554_PROG6221_POE
{
	public class RecipeMethods
	{

		// List collection to store more than one recipe
		public List<Recipe> recipes = new List<Recipe>();

		// Instance of FoodGroupInformation to access food group information
		public FoodGroupInformation FoodGroupInformation = new FoodGroupInformation();

		// Instance of CalorieCounter to perform calorie-related operations
		public CalorieCounter counter = new CalorieCounter();

		public void DisplayRecipe() // "DisplayRecipe" overloaded method that takes no parameters, formats and displays a recipe
		{
			if (recipes.Count > 0) // if statement to check if there are any recipes in the list, if true
			{
				for (int i = 0; i < recipes.Count; i++) // for loop to display the recipe information for all the recipes stored in the recipes list collection
				{
					Console.WriteLine("\n----------------------------------------------------------------------------");
					Console.WriteLine("Recipe Number: " + (i+1));
					Console.WriteLine("----------------------------------------------------------------------------");
					Console.WriteLine("Recipe Name: " + recipes[i].RecipeName);
					Console.WriteLine("\n\nRecipe Ingredients: " + "\n");

					foreach (RecipeIngredient item in recipes[i].Ingredients) // for each loop to display the ingredient information for all the ingredients stored in the ingredient array in the recipe object
					{
						Console.WriteLine("-> " + item.IngredientQuantity + " " + item.UnitOfMeasurement + " of " + item.IngredientName + $" ({item.Group}) (Calories: {item.Calories})");
					}

					Console.WriteLine("\n\nRecipe Steps: " + "\n");

					for (int j = 0; j < recipes[i].Steps.Count; j++) // for loop to display the recipe step information for all the steps stored in the steps array in the recipe object
					{
						Console.WriteLine("Step Number: " + (j+1));
						Console.WriteLine(recipes[i].Steps[j].StepDescription + "\n");
					}

					Console.WriteLine("\nAdditional Information: \n");
					Console.WriteLine($"The total calories in this recipe is: {recipes[i].TotalCalories}\n");
					counter.CalorieRanges(recipes[i]);
				}
			}
			else
			{
				Console.WriteLine("There are no recipes to display at the moment, \nTry adding one first"); // message displayed if the recipes list collection has no recipes stored
			}
		}
	}
}
