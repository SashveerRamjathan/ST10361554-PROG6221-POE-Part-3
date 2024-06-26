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
	/// Interaction logic for AddStepWindow.xaml
	/// </summary>
	public partial class AddStepWindow : Window
	{
		Recipe _recipe;
		RecipeMethods _recipeMethods;

		public AddStepWindow(Recipe recipe, RecipeMethods recipeMethods)
		{
			InitializeComponent();
			_recipe=recipe;
			_recipeMethods=recipeMethods;
		}

		private void AddStepBtn_Click(object sender, RoutedEventArgs e)
		{
			string stepDescription = StepDescriptionTextbox.Text;
			
			RecipeStep step = new RecipeStep();
			step.StepDescription = stepDescription;
			_recipe.Steps.Add(step);

			CreateRecipeWindow createRecipeWindow = new CreateRecipeWindow(_recipeMethods, _recipe);
			createRecipeWindow.Show();
			this.Close();
		}

		private void BackToCreateRecipeBtn_Click(object sender, RoutedEventArgs e)
		{
			--_recipe.NumberOfSteps;

			CreateRecipeWindow createRecipeWindow = new CreateRecipeWindow(_recipeMethods, _recipe);
			createRecipeWindow.Show();
			this.Close();
		}

		private void ClearTextboxBtn_Click(object sender, RoutedEventArgs e)
		{
			StepDescriptionTextbox.Clear();
		}
	}
}
