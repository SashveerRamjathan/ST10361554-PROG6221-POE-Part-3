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
		public CreateRecipeWindow()
		{
			InitializeComponent();
		}

		private void CreateRecipeBtn_Click(object sender, RoutedEventArgs e)
		{
			string recipeName = RecipeNameTextbox.Text;
			int numSteps = (int)NumberStepsSlider.Value;
			int numIngredients = (int)NumberIngredientsSlider.Value;

			if (recipeName == "")
			{
				MessageBox.Show("Please enter a recipe name.", "Enter a Recipe Name", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}



		}

		private void BackToMenuBtn_Click(object sender, RoutedEventArgs e)
		{
			MenuWindow menuWindow = new MenuWindow();
			menuWindow.Show();
			this.Close();
		}

		private void NumberStepsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (NumStepsLbl != null)
			{
				NumStepsLbl.Content = $"Number Of Steps: {NumberStepsSlider.Value.ToString()}";
			}
		}

		private void NumberIngredientsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (NumIngredientsLbl != null)
			{
				NumIngredientsLbl.Content = $"Number Of Ingredients: {NumberIngredientsSlider.Value.ToString()}";
			}
		}
	}
}
