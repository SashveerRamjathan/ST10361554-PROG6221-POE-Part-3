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
	/// Interaction logic for FactorToScaleWindow.xaml
	/// </summary>
	public partial class FactorToScaleWindow : Window
	{
		Recipe _recipe;
		RecipeMethods _recipeMethods;

		public FactorToScaleWindow(Recipe recipe, RecipeMethods recipeMethods)
		{
			InitializeComponent();
			_recipe = recipe;
			_recipeMethods = recipeMethods;
			LoadComboBox();
		}

		private void SelectFactorBtn_Click(object sender, RoutedEventArgs e)
		{
			if (FactorsComboBox.SelectedIndex != -1)
			{
				double factorToScale = Convert.ToDouble(FactorsComboBox.SelectedValue);
				_recipeMethods.ScaleRecipeQuantities(_recipe, factorToScale);

				RecipeDetailsWindow recipeDetailsWindow = new RecipeDetailsWindow(_recipe, _recipeMethods);
				recipeDetailsWindow.Show();
				this.Close();
			}
			else
			{
				MessageBox.Show("Please select a factor to scale the recipe by.", "Select a Factor", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		private void BackToRecipeDetailsBtn_Click(object sender, RoutedEventArgs e)
		{
			RecipeDetailsWindow recipeDetailsWindow = new RecipeDetailsWindow(_recipe, _recipeMethods);
			recipeDetailsWindow.Show();
			this.Close();
		}

		private void LoadComboBox()
		{
			List<string> factors = new List<string> {"0,5", "2", "3"};

			foreach (string factor in factors)
			{
				FactorsComboBox.Items.Add(factor);
			}
		}
	}
}
