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
	/// Interaction logic for ViewFoodGroupInfoWindow.xaml
	/// </summary>
	public partial class ViewFoodGroupInfoWindow : Window
	{
		RecipeMethods _recipeMethods;

		public ViewFoodGroupInfoWindow(RecipeMethods recipeMethods)
		{
			InitializeComponent();
			_recipeMethods = recipeMethods;
		}

		private void BackToMenuBtn_Click(object sender, RoutedEventArgs e)
		{
			MenuWindow menuWindow = new MenuWindow(_recipeMethods);
			menuWindow.Show();
			this.Close();
		}
	}
}
