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
		}
	}
}
