using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10361554_PROG6221_POE
{
	public class Recipe
	{
		// Property to store the recipe's name
		public string RecipeName { get; set; }

		// Property to store the number of ingredients in the recipe
		public int NumberOfIngredients { get; set; }

		// Property to store the number of steps needed to make the recipe
		public int NumberOfSteps { get; set; }

		// Stack to store a list of factors the recipe was scaled by
		public Stack<double> FactorsToScale = new Stack<double>();

		// Property to store if the quantity was reset already
		public bool IsQuantityReset { get; set; }

		// Property to store the total calories of the recipe
		public double TotalCalories { get; set; }

		// List to store the ingredients of the recipe
		public List<RecipeIngredient> Ingredients = new List<RecipeIngredient>();

		// List to store the steps of the recipe
		public List<RecipeStep> Steps = new List<RecipeStep>();
	}
}
