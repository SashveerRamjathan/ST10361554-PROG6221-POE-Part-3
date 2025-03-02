﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10361554_PROG6221_POE
{
	public class CalorieCounter
	{
		// This is the calorie delegate, used to define the signature for the event handler
		public delegate void CalorieEventHandler(string message);

		// This is the calorie event, triggered when total calories exceed 300
		public event CalorieEventHandler CaloriesExceed300;

		// Method to add calories to a recipe
		public void AddCalories(Recipe recipe, RecipeIngredient ingredient, double calories)
		{
			// Set the calories for the ingredient
			ingredient.Calories = calories;

			// Add the ingredient's calories to the recipe's total calories
			recipe.TotalCalories += calories;

			// Check if the total calories exceed 300 and raise the event if true
			if (recipe.TotalCalories > 300)
			{
				OnCaloriesExceed300($"The total calories of this recipe is above 300 \nThe total calories so far for this recipe is {recipe.TotalCalories}");
			}
		}

		// Method to add an ingredient's calories to the total calories of a recipe
		public void TotalCalories(Recipe recipe, RecipeIngredient ingredient)
		{
			recipe.TotalCalories += ingredient.Calories;
		}

		// Method to categorize the recipe based on its total calorie count and provide relevant information
		public List<string> CalorieRanges(Recipe recipe)
		{
			double calories = recipe.TotalCalories;
			List<string> calorieInfo = new List<string>();

			// Categorize and describe the recipe based on its total calorie count
			if (calories < 300 && calories != 0)
			{
				calorieInfo.Add("Low Calorie Recipe");
				calorieInfo.Add("Typically, these recipes are light meals or snacks. ");
				calorieInfo.Add("They often include a high proportion of vegetables, lean proteins, and minimal added fats or sugars.");
			}

			if (calories >= 300 && calories <= 600)
			{
				calorieInfo.Add("Moderate Calorie Recipe");
				calorieInfo.Add("These recipes can serve as complete meals, often balancing proteins, carbohydrates, and fats. ");
				calorieInfo.Add("They can be nutritious while still keeping the calorie count in check.");
			}

			if (calories > 600 && calories <= 900)
			{
				calorieInfo.Add("High Calorie Recipe");
				calorieInfo.Add("These meals are more substantial and may include richer ingredients.");
				calorieInfo.Add("These can be part of a healthy diet when balanced with lower-calorie meals.");
			}

			if (calories > 900)
			{
				calorieInfo.Add("Very High Calorie Recipes");
				calorieInfo.Add("These recipes are usually indulgent meals or large portions. ");
				calorieInfo.Add("They often contain high amounts of fats and sugars, making them more calorie-dense. ");
				calorieInfo.Add("They are typically less balanced and should be eaten in moderation.");
			}

			return calorieInfo;
		}

		// Method to raise the CaloriesExceed300 event
		protected virtual void OnCaloriesExceed300(string message)
		{
			CaloriesExceed300?.Invoke(message);
		}
	}
}
