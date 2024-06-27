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
	/// Interaction logic for CreateRecipeWindow.xaml
	/// </summary>
	public partial class CreateRecipeWindow : Window
	{
		RecipeMethods _recipeMethods;
		Recipe _recipe;

		public CreateRecipeWindow(RecipeMethods methods, Recipe recipe)
		{
			InitializeComponent();
			_recipeMethods = methods;
			_recipe = recipe;

			if (!string.IsNullOrWhiteSpace(recipe.RecipeName))
			{
				RecipeNameTextbox.Text = recipe.RecipeName;
			}

			NumIngredientsLbl.Content = $"Number Of Ingredients: {recipe.NumberOfIngredients}";
			NumStepsLbl.Content = $"Number Of Steps: {recipe.NumberOfSteps}";
		}

		private void CreateRecipeBtn_Click(object sender, RoutedEventArgs e)
		{
			string recipeName = RecipeNameTextbox.Text;

			if (recipeName == "")
			{
				MessageBox.Show("Please enter a recipe name.", "Enter a Recipe Name", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			_recipe.RecipeName = recipeName;

			_recipeMethods.recipes.Add(_recipe);

			_recipeMethods.SortRecipes();

			MessageBox.Show("Recipe saved successfully", "Recipe Saved", MessageBoxButton.OK, MessageBoxImage.Information);

			DisplayRecipeWindow displayRecipeWindow = new DisplayRecipeWindow(_recipe, _recipeMethods);
			displayRecipeWindow.Show();
			this.Close();
		}

		private void BackToMenuBtn_Click(object sender, RoutedEventArgs e)
		{
			MenuWindow menuWindow = new MenuWindow(_recipeMethods);
			menuWindow.Show();
			this.Close();
		}

		private void AddIngredientBtn_Click(object sender, RoutedEventArgs e)
		{
			string recipeName = RecipeNameTextbox.Text;

			if (recipeName == "")
			{
				MessageBox.Show("Please enter a recipe name.", "Enter a Recipe Name", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			_recipe.RecipeName = recipeName;

			_recipe.NumberOfIngredients++;
			AddIngredientWindow window = new AddIngredientWindow(_recipe, _recipeMethods);
			window.Show();
			this.Close();

		}

		private void AddStepBtn_Click(object sender, RoutedEventArgs e)
		{
			string recipeName = RecipeNameTextbox.Text;

			if (recipeName == "")
			{
				MessageBox.Show("Please enter a recipe name.", "Enter a Recipe Name", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			_recipe.RecipeName = recipeName;

			_recipe.NumberOfSteps++;
			AddStepWindow window = new AddStepWindow(_recipe, _recipeMethods);
			window.Show();
			this.Close();

		}

	}
}
