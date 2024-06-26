using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST10361554_PROG6221_POE
{
	/// <summary>
	/// Interaction logic for DisplayRecipeWindow.xaml
	/// </summary>
	public partial class DisplayRecipeWindow : Window
	{
		Recipe _recipe;
		RecipeMethods _recipeMethods;

		public DisplayRecipeWindow(Recipe recipe, RecipeMethods recipeMethods)
		{
			InitializeComponent();
			_recipe = recipe;
			_recipeMethods = recipeMethods;
		}

		public void DisplayRecipe(Recipe recipe)
		{
			Console.WriteLine("\n----------------------------------------------------------------------------");
			Console.WriteLine("Recipe Name: " + recipe.RecipeName);
			Console.WriteLine("----------------------------------------------------------------------------");

			Console.WriteLine("\n\nRecipe Ingredients: " + "\n");

			foreach (RecipeIngredient item in recipe.Ingredients) // for each loop to display the ingredient information for all the ingredients stored in the ingredient array in the recipe object
			{
				Console.WriteLine("-> " + item.IngredientQuantity + " " + item.UnitOfMeasurement + " of " + item.IngredientName + $" ({item.Group}) (Calories: {item.Calories})");
			}

			Console.WriteLine("\n\nRecipe Steps: " + "\n");

			for (int j = 0; j < recipe.Steps.Count; j++)  // for loop to display the recipe step information for all the steps stored in the steps array in the recipe object
			{
				Console.WriteLine("Step Number: " + (j+1));
				Console.WriteLine(recipe.Steps[j].StepDescription + "\n");
			}

			Console.WriteLine("\nAdditional Information: \n");
			Console.WriteLine($"The total calories in this recipe is: {recipe.TotalCalories}\n");
			_recipeMethods.counter.CalorieRanges(recipe);

		}

	}
}
