using ST10361554_PROG6221_POE.Images;
using System;
using System.Collections.Generic;
using System.Linq;
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
	/// Interaction logic for RecipeDetailsWindow.xaml
	/// </summary>
	public partial class RecipeDetailsWindow : Window
	{
		Recipe _recipe;
		RecipeMethods _recipeMethods;

		public RecipeDetailsWindow(Recipe recipe, RecipeMethods recipeMethods)
		{
			InitializeComponent();
			_recipe = recipe;
			_recipeMethods = recipeMethods;
			LoadRecipeDetails();

			if (_recipe.Ingredients.Count == 0)
			{
				ScaleRecipeBtn.IsEnabled = false;
				ResetScaleBtn.IsEnabled = false;
			}
		}

		private void LoadRecipeDetails() 
		{
			RecipeNamelbl.Content = _recipe.RecipeName;

			if (_recipe.Ingredients.Count > 0)
			{
				IngredientsTextBlock.Text = "";
				foreach (RecipeIngredient item in _recipe.Ingredients)
				{
					IngredientsTextBlock.Text += $"-> {item.IngredientQuantity} {item.UnitOfMeasurement} of {item.IngredientName} ({item.Group}) (Calories: {item.Calories})\n";
				}
			}
			else
			{
				IngredientsTextBlock.Text = "";
				IngredientsTextBlock.Text += "No ingredients have been added to this recipe yet.";
			}

			if (_recipe.Steps.Count > 0)
			{
				StepsItemsControl.ItemsSource = _recipe.Steps;
			}
			
			// Display additional information
			List<string> calorieInfo = _recipeMethods.counter.CalorieRanges(_recipe);
			AdditionalInfoTextBlock.Text = "";
			AdditionalInfoTextBlock.Text  += $"The total calories in this recipe is: {_recipe.TotalCalories}\n\n";
			foreach (string info in calorieInfo)
			{
				AdditionalInfoTextBlock.Text += info + "\n";
			}
		}

		private void ScaleRecipeBtn_Click(object sender, RoutedEventArgs e)
		{
			FactorToScaleWindow factorToScaleWindow = new FactorToScaleWindow(_recipe, _recipeMethods);
			factorToScaleWindow.Show();
			this.Close();
		}

		private void ResetScaleBtn_Click(object sender, RoutedEventArgs e)
		{
			_recipeMethods.RevertScaledQuantities(_recipe);
			LoadRecipeDetails();
		}

		private void BackBtn_Click(object sender, RoutedEventArgs e)
		{
			ViewRecipeBookWindow viewRecipeBookWindow = new ViewRecipeBookWindow(_recipeMethods);
			viewRecipeBookWindow.Show();
			this.Close();
		}
	}
}
