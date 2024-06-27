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
	/// Interaction logic for DeleteRecipesWindow.xaml
	/// </summary>
	public partial class DeleteRecipesWindow : Window
	{
		RecipeMethods _recipeMethods;

		public DeleteRecipesWindow(RecipeMethods recipeMethods)
		{
			InitializeComponent();
			_recipeMethods = recipeMethods;
			LoadComboBox();
		}

		private void BackToMenuBtn_Click(object sender, RoutedEventArgs e)
		{
			MenuWindow menuWindow = new MenuWindow(_recipeMethods);
			menuWindow.Show();
			this.Close();
		}

		private void DeleteRecipeBtn_Click(object sender, RoutedEventArgs e)
		{
			int recipeIndex = RecipeNamesComboBox.SelectedIndex;

			if (recipeIndex >= 0)
			{
				string selectedRecipeName = RecipeNamesComboBox.SelectedItem.ToString();

				foreach (Recipe recipe in _recipeMethods.recipes)
				{
					if (recipe.RecipeName == selectedRecipeName)
					{
						MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {recipe.RecipeName}?", "Delete Recipe", MessageBoxButton.YesNo, MessageBoxImage.Warning);

						if (result == MessageBoxResult.Yes)
						{
							_recipeMethods.recipes.Remove(recipe);
							RecipeNamesComboBox.Items.Remove(recipe.RecipeName);
							MessageBox.Show($"{recipe.RecipeName} has been deleted", "Recipe Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
						}
						
						break;
					}
				}
			}
			else
			{
				MessageBox.Show("Please select a recipe to add to menu", "Select a Recipe", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		private void ClearAllRecipesBtn_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Are you sure you want to delete all recipes?", "Delete All Recipes", MessageBoxButton.YesNo, MessageBoxImage.Warning);
			if (result == MessageBoxResult.Yes) {
				_recipeMethods.recipes.Clear();
				RecipeNamesComboBox.Items.Clear();
				MessageBox.Show("All recipes have been deleted", "Recipes Deleted", MessageBoxButton.OK, MessageBoxImage.Information);

				MenuWindow menuWindow = new MenuWindow(_recipeMethods);
				menuWindow.Show();
				this.Close();
			}
		}

		private void LoadComboBox()
		{
			foreach (Recipe recipe in _recipeMethods.recipes)
			{
				RecipeNamesComboBox.Items.Add(recipe.RecipeName);

			}
		}
	}
}
