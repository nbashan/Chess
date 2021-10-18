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
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        private bool start = true;
        public Start()
        {
            InitializeComponent();
        }

        private void Computer_Click(object sender, RoutedEventArgs e)
        {
            computerBoarder.Visibility = Visibility.Visible;
            humanBoarder.Visibility = Visibility.Hidden;
            start = false;
        }

        private void Human_Click(object sender, RoutedEventArgs e)
        {
            humanBoarder.Visibility = Visibility.Visible;
            computerBoarder.Visibility = Visibility.Hidden;
            start = true;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (start)
            {
                new MainWindow(start, true).Show();
                this.Close();
            }
            else
            {
                new Second().Show();
                this.Close();
            }
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
