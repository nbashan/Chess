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
        public bool white = true;
        public bool human = true;
        public Start()
        {
            InitializeComponent();
        }

        private void White_Click(object sender, RoutedEventArgs e)
        {
            whiteBG.Background = new SolidColorBrush(Color.FromRgb(0,255, 0));
            blackBG.Background = new SolidColorBrush(Color.FromRgb(112, 128, 144));
            white = true;
        }

        private void Black_Click(object sender, RoutedEventArgs e)
        {
            blackBG.Background = new SolidColorBrush(Color.FromRgb(0,255, 0));
            whiteBG.Background = new SolidColorBrush(Color.FromRgb(112, 128, 144));
            white = false;
        }

        private void Computer_Click(object sender, RoutedEventArgs e)
        {
            computerBG.Background = new SolidColorBrush(Color.FromRgb(0,255, 0));
            humanBG.Background = new SolidColorBrush(Color.FromRgb(112, 128, 144));
            human = false;
        }

        private void Human_Click(object sender, RoutedEventArgs e)
        {
            humanBG.Background = new SolidColorBrush(Color.FromRgb(0,255, 0));
            computerBG.Background = new SolidColorBrush(Color.FromRgb(112, 128, 144));
            human = true;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(white,human).Show();
            this.Close();
        }
    }
}
