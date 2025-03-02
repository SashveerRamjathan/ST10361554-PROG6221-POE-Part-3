﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ST10361554_PROG6221_POE
{
	public class RecipeMethods
	{

		// List collection to store more than one recipe
		public List<Recipe> recipes = new List<Recipe>();

		// Instance of CalorieCounter to perform calorie-related operations
		public CalorieCounter counter = new CalorieCounter();

		public void SortRecipes()
		{
			// Lambda expression to sort the list of recipes in alphabetical order
			List<Recipe> sortedRecipes = recipes.OrderBy(r => r.RecipeName).ToList();

			// replace the current list of recipes by the sorted one
			recipes = sortedRecipes;
		}

		public void ScaleRecipeQuantities(Recipe recipe, double factorToScale) // method to scale the quantities of a recipe by the chosen factor, method has  a recipe object as a parameter
		{

			if (recipe.FactorsToScale != null)
			{
				recipe.FactorsToScale.Push(factorToScale); // stores the value in factor to scale to the list property in the recipe object
			}
			else
			{
				MessageBox.Show($"Stack FactorsToScale in ScaleRecipeQuantities() for {recipe.RecipeName} is null", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}

			if (recipe.Ingredients != null)
			{
				List<RecipeIngredient> scaledIngredients = new List<RecipeIngredient>(); // initialises a scaled ingredients list

				recipe.TotalCalories = 0;

				for (int i = 0; i < recipe.NumberOfIngredients; i++) // for-loop to scale each ingredient by the specified factor
				{
					var ingredient = recipe.Ingredients[i]; // stores the ingredient object in a variable

					ingredient.IngredientQuantity *= factorToScale; // gets, multiplies the quantity by the factor and stores it in the corresponding property in the ingredient object 
					ingredient.Calories *= factorToScale; // scales the calories according to the factor as well
					counter.TotalCalories(recipe, ingredient);

					scaledIngredients.Add(ingredient); // adds the ingredient object to the scaled ingredients list
				}

				recipe.Ingredients = scaledIngredients; // saves the new list of scaled ingredients to the ingredients list

			}
			else
			{
				MessageBox.Show($"List Ingredients in ScaleRecipeQuantities() for {recipe.RecipeName} is null", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}

			recipe.IsQuantityReset = false; // sets the value to false

			// displays a message box to inform the user that the recipe has been scaled successfully
			MessageBox.Show($"Recipe has been scaled successfully \nScaled Recipe by factor of {factorToScale}", "Recipe Scaled", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		public void RevertScaledQuantities(Recipe recipe) // // method to revert the scale of the quantities of a recipe by the chosen factor, method has  a recipe object as a parameter
		{
			if (recipe.IsQuantityReset == false) // check if quantities have been reset, if false
			{
				if (recipe.FactorsToScale != null && recipe.FactorsToScale.Count > 0) // check if null and check if there are factors in stack, if true
				{
					List<RecipeIngredient> originalIngredients = new List<RecipeIngredient>(); // list to store the ingredients after their quantities have been reset

					List<double> factors = new List<double>();

					foreach (double factor in recipe.FactorsToScale)
					{
						factors.Add(factor);
					}

					recipe.TotalCalories = 0;

					for (int j = 0; j < recipe.NumberOfIngredients; j++) // for-loop to revert the scale of each ingredient by the specified factor
					{
						var ingredient = recipe.Ingredients[j]; // stores the ingredient object in a variable

						for (int i = 0; i < factors.Count; i++) // for-loop to divide each quantity by the number of times it was scaled by the factors
						{
							ingredient.IngredientQuantity /= factors[i]; // gets, divides the quantity by the factor and stores it in the corresponding property in the ingredient object 
							ingredient.Calories /= factors[i]; //resets the calories back to original values
						}

						counter.TotalCalories(recipe, ingredient);

						originalIngredients.Add(ingredient); // adds the ingredient object to the scaled ingredients array in the recipe object

					}

					recipe.Ingredients = originalIngredients; // sets the list of ingredients to the values in the originalIngredients list

					recipe.FactorsToScale.Clear();

					recipe.IsQuantityReset = true;

					// displays a message box to inform the user that the recipe has been reset successfully
					MessageBox.Show("Quantities have been reset successfully", "Quantities Reset", MessageBoxButton.OK, MessageBoxImage.Information);


				}
				else
				{
					MessageBox.Show("There are no factors to scale the recipe by", "No Factors", MessageBoxButton.OK, MessageBoxImage.Warning);

				}
			}
			else
			{
				MessageBox.Show("Quantities have already been reset", "Quantities Already Reset", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}
	}
}
