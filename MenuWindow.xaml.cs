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
        public MenuWindow()
        {
            InitializeComponent();
        }

		private void CreateRecipeBtn_Click(object sender, RoutedEventArgs e)
		{
			CreateRecipeWindow createRecipeWindow = new CreateRecipeWindow();
			createRecipeWindow.Show();
			this.Close();
		}

		private void ViewRecipeBookBtn_Click(object sender, RoutedEventArgs e)
		{
			ViewRecipeBookWindow viewRecipeBookWindow = new ViewRecipeBookWindow();
			viewRecipeBookWindow.Show();
			this.Close();
		}

		private void CreateMenuBtn_Click(object sender, RoutedEventArgs e)
		{
			CreateMenuWindow createMenuWindow = new CreateMenuWindow();
			createMenuWindow.Show();
			this.Close();
		}

		private void ViewFoodGroupInfoBtn_Click(object sender, RoutedEventArgs e)
		{
			ViewFoodGroupInfoWindow viewFoodGroupInfoWindow = new ViewFoodGroupInfoWindow();
			viewFoodGroupInfoWindow.Show();
			this.Close();
		}

		private void CloseAppBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
