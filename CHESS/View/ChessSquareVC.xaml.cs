using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace CHESS.View
{
    /// <summary>
    /// Interaction logic for ChessSquareVC.xaml
    /// </summary>
    public partial class ChessSquareVC : UserControl
    {


        public int i { get; set; }
        public int j { get; set; }




        public string ButtonImage
        {
            get { return (string)GetValue(ButtonImageProperty); }
            set { SetValue(ButtonImageProperty, value); }
        }


        public static readonly DependencyProperty ButtonImageProperty =
        DependencyProperty.Register("ButtonImage",
             typeof(string), typeof(ChessSquareVC),
             new FrameworkPropertyMetadata(OnButtonImageSourcePathChanged));


        private static void OnButtonImageSourcePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StreamResourceInfo streamInfo = Application.GetResourceStream(new Uri(e.NewValue as string, UriKind.Relative));
            BitmapFrame temp2 = BitmapFrame.Create(streamInfo.Stream);
            var brush1 = new ImageBrush();
            brush1.ImageSource = temp2;

            ((ChessSquareVC)d).myButton.Background = brush1;

        }

        public ChessSquareVC()
        {

            InitializeComponent();

        }

    }
}
