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

namespace ST10361554_PROG6221_POE.Images
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
		RecipeMethods _recipeMethods;

        public MenuWindow(RecipeMethods recipeMethods)
        {
            InitializeComponent();
			_recipeMethods = recipeMethods;
        }

		private void CreateRecipeBtn_Click(object sender, RoutedEventArgs e)
		{
			Recipe recipe = new Recipe();
			CreateRecipeWindow createRecipeWindow = new CreateRecipeWindow(_recipeMethods, recipe);
			createRecipeWindow.Show();
			this.Close();
		}

		private void ViewRecipeBookBtn_Click(object sender, RoutedEventArgs e)
		{
			ViewRecipeBookWindow viewRecipeBookWindow = new ViewRecipeBookWindow(_recipeMethods);
			viewRecipeBookWindow.Show();
			this.Close();
		}

		private void CreateMenuBtn_Click(object sender, RoutedEventArgs e)
		{
			if (_recipeMethods.recipes.Count >= 2)
			{
				CreateMenuWindow createMenuWindow = new CreateMenuWindow(_recipeMethods);
				createMenuWindow.Show();
				this.Close();
			}
			else
			{
				MessageBox.Show("You need at least 2 recipes to create a menu, \nAdd 2 recipes and try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void ViewFoodGroupInfoBtn_Click(object sender, RoutedEventArgs e)
		{
			ViewFoodGroupInfoWindow viewFoodGroupInfoWindow = new ViewFoodGroupInfoWindow(_recipeMethods);
			viewFoodGroupInfoWindow.Show();
			this.Close();
		}

		private void CloseAppBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
