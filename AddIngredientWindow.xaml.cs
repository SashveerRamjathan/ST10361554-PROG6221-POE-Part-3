using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ST10361554_PROG6221_POE
{
	/// <summary>
	/// Interaction logic for AddIngredientWindow.xaml
	/// </summary>
	public partial class AddIngredientWindow : Window
	{
		Recipe _recipe;
		RecipeMethods _recipeMethods;

        public AddIngredientWindow(Recipe recipe, RecipeMethods recipeMethods)
		{
			InitializeComponent();
			_recipe=recipe;
			_recipeMethods=recipeMethods;
			LoadUnitsOfMeasurement();
			LoadFoodGroups();

			// Subscribe to the CalorieExceeds300 event from the CalorieCounter
			_recipeMethods.counter.CaloriesExceed300 += OnCaloriesExceed300Handler;


		}

		private void AddIngredientBtn_Click(object sender, RoutedEventArgs e)
		{

			string ingredientName = IngredientNameTextbox.Text;

			if (string.IsNullOrWhiteSpace(ingredientName))
			{
				MessageBox.Show("Please enter the name of the ingredient.", "Invalid Ingredient Name", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}
			else if (ContainsNumbers(ingredientName))
			{
				MessageBox.Show("Ingredient name cannot contain numbers.", "Invalid Ingredient Name", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			string ingredientQuantity = IngredientQuantityTextbox.Text;

			if (string.IsNullOrWhiteSpace(ingredientQuantity))
			{
				MessageBox.Show("Please enter the quantity of the ingredient.", "Invalid Ingredient Quantity", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}
			else if (!double.TryParse(ingredientQuantity, out double quantity))
			{
				MessageBox.Show("Quantity must be a number.", "Invalid Ingredient Quantity", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			double ingredientQuantityValue = double.Parse(ingredientQuantity);

			string unitOfMeasurement = MeasurementComboBox.Text;

			if (string.IsNullOrWhiteSpace(unitOfMeasurement))
			{
				MessageBox.Show("Please select a unit of measurement.", "Invalid Unit of Measurement", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			int foodGroup = FoodGroupComboBox.SelectedIndex;

			if (foodGroup == -1)
			{
				MessageBox.Show("Please select a food group.", "Invalid Food Group", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			FoodGroups group = (FoodGroups)foodGroup;

			string calories = CaloriesTextbox.Text;

			if (string.IsNullOrWhiteSpace(calories))
			{
				MessageBox.Show("Please enter the calories of the ingredient.", "Invalid Ingredient Calories", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}
			else if (!double.TryParse(calories, out double cal))
			{
				MessageBox.Show("Calories must be a number.", "Invalid Ingredient Calories", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			double caloriesValue = double.Parse(calories);

			RecipeIngredient ingredient = new RecipeIngredient
			{
				IngredientName = ingredientName,
				IngredientQuantity = ingredientQuantityValue,
				UnitOfMeasurement = unitOfMeasurement,
				Group = group,
				Calories = caloriesValue
			};

			_recipeMethods.counter.AddCalories(_recipe, ingredient, caloriesValue);

			_recipe.Ingredients.Add(ingredient);

			// Unsubscribe to the CalorieExceeds300 event from the CalorieCounter
			_recipeMethods.counter.CaloriesExceed300 -= OnCaloriesExceed300Handler;

			CreateRecipeWindow createRecipeWindow = new CreateRecipeWindow(_recipeMethods, _recipe);
			createRecipeWindow.Show();
			this.Close();
		}

		private void BackToCreateRecipeBtn_Click(object sender, RoutedEventArgs e)
		{
			--_recipe.NumberOfIngredients;

			CreateRecipeWindow createRecipeWindow = new CreateRecipeWindow(_recipeMethods, _recipe);
			createRecipeWindow.Show();
			this.Close();
		}

		private void LoadUnitsOfMeasurement()
		{
			List<string> units = new List<string>
			{
				"Grams","Kilograms","Millilitres","Litres","Teaspoons","Tablespoons","Cups","Whole","Slices","Pieces","Halves"
			};

			MeasurementComboBox.ItemsSource = units;
		}

		private void LoadFoodGroups()
		{
			FoodGroupComboBox.ItemsSource = Enum.GetNames(typeof(FoodGroups));
		}

		private bool ContainsNumbers(string input)
		{
			return Regex.IsMatch(input, @"\d");
		}

		public void OnCaloriesExceed300Handler(string message)
		{
			MessageBox.Show(message, "Calorie Count for Recipe Exceeded", MessageBoxButton.OK, MessageBoxImage.Warning);
			return;
		}
	}
}
