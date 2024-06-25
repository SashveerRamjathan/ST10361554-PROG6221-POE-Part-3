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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ST10361554_PROG6221_POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //// Code Attribution for Timer
        //private DispatcherTimer _timer;
        public MainWindow()
        {
            InitializeComponent();

            //_timer = new DispatcherTimer();
            //_timer.Interval = TimeSpan.FromSeconds(3); // 3 seconds
            //_timer.Tick += (sender, e) => 
            //{
            //    MenuWindow menuWindow = new MenuWindow();
            //    menuWindow.Show();
            //    this.Close();
            //};
            //_timer.Start();

            //this.Show();

        }

		private void getStartedBtn_Click(object sender, RoutedEventArgs e)
		{
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
		}
	}
}
