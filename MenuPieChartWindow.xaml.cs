using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
	/// Interaction logic for MenuPieChartWindow.xaml
	/// </summary>
	public partial class MenuPieChartWindow : Window
	{
		List<Recipe> _menuRecipes = new List<Recipe>();
		RecipeMethods _recipeMethods;

		public MenuPieChartWindow(List<Recipe> menuRecipes, RecipeMethods recipeMethods)
		{
			InitializeComponent();
			_recipeMethods = recipeMethods;
			_menuRecipes = menuRecipes;

			SeriesCollection = GeneratePieChartInfo();

			// means xaml properties will be able to access the properties of this class 
			DataContext = this;
		}

		private void BackToMenuBtn_Click(object sender, RoutedEventArgs e)
		{
			CreateMenuWindow createMenuWindow = new CreateMenuWindow(_recipeMethods);
			createMenuWindow.Show();
			this.Close();
		}

		public SeriesCollection SeriesCollection { get; set; }

		private void PieChart_DataClick(object sender, LiveCharts.ChartPoint chartPoint)
		{
			// Value in observable value = chartPoint.Y
			// to get the decimal for the section takes up use : chartPoint.Participation
			// to convert the decimal to a % * 100
			// use Math.Round to make the value neater
			MessageBox.Show($"Current value: {chartPoint.Y} ({Math.Round((chartPoint.Participation * 100), 2).ToString()}%)");
		}

		private SeriesCollection GeneratePieChartInfo()
		{
			SeriesCollection seriesCollection = new SeriesCollection();

			// Initialize a dictionary to store food group names and their total calories
			Dictionary<string, double> FoodGroupNameAndValue = new Dictionary<string, double>();

			// Iterate through each recipe in _menuRecipes
			foreach (Recipe recipe in _menuRecipes)
			{
				// Iterate through each ingredient in the current recipe
				foreach (RecipeIngredient ingredient in recipe.Ingredients)
				{
					string groupName = ingredient.Group.ToString();

					// If the group name doesn't exist in the dictionary, add it with initial calories
					if (!FoodGroupNameAndValue.ContainsKey(groupName))
					{
						FoodGroupNameAndValue[groupName] = 0;
					}

					// Add the calories of the current ingredient to the existing total for its group
					FoodGroupNameAndValue[groupName] += ingredient.Calories;
				}
			}

			foreach (var item in FoodGroupNameAndValue)
			{
				seriesCollection.Add(new PieSeries {Title=item.Key, Values=new ChartValues<ObservableValue> {new ObservableValue(item.Value) }, DataLabels=true });
			}

			return seriesCollection;
		}

	}

}
