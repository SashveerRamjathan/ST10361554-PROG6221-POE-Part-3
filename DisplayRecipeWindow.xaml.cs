using ST10361554_PROG6221_POE.Images;
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
			DisplayRecipe(recipe);
		}

		public void DisplayRecipe(Recipe recipe)
		{
			RecipeNamelbl.Content = recipe.RecipeName;

			RecipeDetailsTextBox.Text += "Recipe Ingredients:\n";

			if (recipe.Ingredients.Count == 0)
			{
				RecipeDetailsTextBox.Text += "No ingredients have been added to this recipe yet.\n\n";
			}
			else
			{
				foreach (RecipeIngredient item in recipe.Ingredients)
				{
					RecipeDetailsTextBox.Text += $"-> {item.IngredientQuantity} {item.UnitOfMeasurement} of {item.IngredientName} ({item.Group}) (Calories: {item.Calories})\n";
				}
			}

			RecipeDetailsTextBox.Text += "\nRecipe Steps:\n";
			if (recipe.Steps.Count == 0)
			{
				RecipeDetailsTextBox.Text += "No steps have been added to this recipe yet.\n\n";
			}
			else 
			{
				for (int j = 0; j < recipe.Steps.Count; j++)
				{
					RecipeDetailsTextBox.Text += $"Step Number: {j + 1}\n";
					RecipeDetailsTextBox.Text += $"{recipe.Steps[j].StepDescription}\n\n";
				}
			}

			RecipeDetailsTextBox.Text += "Additional Information:\n";
			RecipeDetailsTextBox.Text += $"The total calories in this recipe is: {recipe.TotalCalories}\n\n";

			List<string> calorieInfo = _recipeMethods.counter.CalorieRanges(recipe);
			foreach (string item in calorieInfo)
			{
				RecipeDetailsTextBox.Text += $"{item}\n";
			}



		}

		private void BackToMenuBtn_Click(object sender, RoutedEventArgs e)
		{
			MenuWindow menuWindow = new MenuWindow(_recipeMethods);
			menuWindow.Show();
			this.Close();
		}
	}
}
