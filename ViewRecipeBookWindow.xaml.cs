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
	/// Interaction logic for ViewRecipeBookWindow.xaml
	/// </summary>
	public partial class ViewRecipeBookWindow : Window
	{
		RecipeMethods _recipeMethods;

		public ViewRecipeBookWindow(RecipeMethods recipeMethods)
		{
			InitializeComponent();
			_recipeMethods=recipeMethods;
			LoadComboBox();
			LoadListBox();

			if (RecipeNamesComboBox.Items.Count == 0)
			{
				ViewRecipeBtn.IsEnabled = false;
				ViewRecipeBtn.ToolTip = "No Recipes at the moment to view";

				RecipeNamesComboBox.IsEnabled = false;
			}
		}

		private void BackToMenuBtn_Click(object sender, RoutedEventArgs e)
		{
			MenuWindow menuWindow = new MenuWindow(_recipeMethods);
			menuWindow.Show();
			this.Close();
		}

		private void ViewRecipeBtn_Click(object sender, RoutedEventArgs e)
		{
			int recipeIndex = RecipeNamesComboBox.SelectedIndex;

			Recipe selectedRecipe;

			if (recipeIndex >= 0)
			{
				selectedRecipe = _recipeMethods.recipes[recipeIndex];

				RecipeDetailsWindow recipeDetailsWindow = new RecipeDetailsWindow(selectedRecipe, _recipeMethods);
				recipeDetailsWindow.Show();
				this.Close();
			}
			else
			{
				MessageBox.Show("Please select a recipe to view", "Select a Recipe", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		private void LoadListBox()
		{
			int recipeNumber = 1;

			if (_recipeMethods.recipes.Count == 0)
			{
				RecipeNamesListbox.Items.Add("There are no saved recipes at the moment, \nTry adding one first");
			}
			else
			{
				foreach (Recipe recipe in _recipeMethods.recipes)
				{
					RecipeNamesListbox.Items.Add($"{recipeNumber}. {recipe.RecipeName}");
					++recipeNumber;
				}
			}
		}

		private void LoadComboBox()
		{
			if (_recipeMethods.recipes.Count > 0)
			{
				foreach (Recipe recipe in _recipeMethods.recipes)
				{
					RecipeNamesComboBox.Items.Add(recipe.RecipeName);
				}
			}
		}
	}
}
