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

namespace CHESS
{
    /// <summary>
    /// Interaction logic for Second.xaml
    /// </summary>
    public partial class Second : Window
    {

        private bool human = true;

        public Second()
        {
            InitializeComponent();
        }


        private void Computer_Click(object sender, RoutedEventArgs e)
        {
            computerBoarder2.Visibility = Visibility.Visible;
            humanBoarder2.Visibility = Visibility.Hidden;
            human = false;
        }

        private void Human_Click(object sender, RoutedEventArgs e)
        {
            humanBoarder2.Visibility = Visibility.Visible;
            computerBoarder2.Visibility = Visibility.Hidden;
            human = true;
        }



        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(human, false).Show();
            this.Close();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
