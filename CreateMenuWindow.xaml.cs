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
	/// Interaction logic for CreateMenuWindow.xaml
	/// </summary>
	public partial class CreateMenuWindow : Window
	{
		RecipeMethods _recipeMethods;
		List<Recipe> _menuRecipes = new List<Recipe>();

		public CreateMenuWindow(RecipeMethods recipeMethods)
		{
			InitializeComponent();
			_recipeMethods = recipeMethods;
			LoadComboBox();
		}

		private void AddToMenuBtn_Click(object sender, RoutedEventArgs e)
		{
			int recipeIndex = RecipeNamesComboBox.SelectedIndex;

			Recipe selectedRecipe;

			if (recipeIndex >= 0)
			{
				selectedRecipe = _recipeMethods.recipes[recipeIndex];
				_menuRecipes.Add(selectedRecipe);
				RecipeNamesListbox.Items.Add($"{selectedRecipe.RecipeName} added to menu");
			}
			else
			{
				MessageBox.Show("Please select a recipe to add to menu", "Select a Recipe", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		private void BackToMenuBtn_Click(object sender, RoutedEventArgs e)
		{
			MenuWindow menuWindow = new MenuWindow(_recipeMethods);
			menuWindow.Show();
			this.Close();
		}

		private void LoadComboBox()
		{
			int recipeNumber = 1;

			if (_menuRecipes.Count == 0)
			{
				RecipeNamesListbox.Items.Add("There are recipes added to the menu, \nTry adding one first");
			}

			foreach (Recipe recipe in _recipeMethods.recipes)
			{
				RecipeNamesListbox.Items.Add($"{recipeNumber}. {recipe.RecipeName}");
				++recipeNumber;
			}
		}

		private void CreateMenuBtn_Click(object sender, RoutedEventArgs e)
		{
			if (_menuRecipes.Count == 0 || _menuRecipes.Count == 1)
			{
				MessageBox.Show("Please select two recipes to create a menu", "Error Creating Menu", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			else
			{
				MenuPieChartWindow menuPieChartWindow = new MenuPieChartWindow(_menuRecipes, _recipeMethods);
				menuPieChartWindow.Show();
				this.Close();
			}
		}
	}
}
