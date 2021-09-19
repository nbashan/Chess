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
        private bool human = true;
        public Start()
        {
            InitializeComponent();
        }

        private void Computer_Start_Click(object sender, RoutedEventArgs e)
        {
            ComputerStart.Background = new SolidColorBrush(Color.FromRgb(0,255, 0));
            HumanStart.Background = new SolidColorBrush(Color.FromRgb(112, 128, 144));
            start = false;
        }

        private void Human_Start_Click(object sender, RoutedEventArgs e)
        {
            HumanStart.Background = new SolidColorBrush(Color.FromRgb(0,255, 0));
            ComputerStart.Background = new SolidColorBrush(Color.FromRgb(112, 128, 144));
            start = true;
        }

        private void Computer_Click(object sender, RoutedEventArgs e)
        {
            HumanStart.Visibility = Visibility.Visible;
            ComputerStart.Visibility = Visibility.Visible;
            startBG.Visibility = Visibility.Visible;
            computerBG.Background = new SolidColorBrush(Color.FromRgb(0,255, 0));
            humanBG.Background = new SolidColorBrush(Color.FromRgb(112, 128, 144));
            human = false;
        }

        private void Human_Click(object sender, RoutedEventArgs e)
        {
            HumanStart.Visibility = Visibility.Hidden;
            ComputerStart.Visibility = Visibility.Hidden;
            startBG.Visibility = Visibility.Hidden;
            humanBG.Background = new SolidColorBrush(Color.FromRgb(0,255, 0));
            computerBG.Background = new SolidColorBrush(Color.FromRgb(112, 128, 144));
            human = true;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(start,human).Show();
            this.Close();
        }
    }
}
