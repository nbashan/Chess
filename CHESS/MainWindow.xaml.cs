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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace CHESS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player p1;
        Player p2;
        Game game = new Game();

        bool startB = true;
        bool human = true;


        Uri white_bishop = new Uri("images/white_bishop.png", UriKind.Relative);
        Uri white_king = new Uri("images/white_king.png", UriKind.Relative);
        Uri white_knight = new Uri("images/white_knight.png", UriKind.Relative);
        Uri white_pawn = new Uri("images/white_pawn.png", UriKind.Relative);
        Uri white_queen = new Uri("images/white_queen.png", UriKind.Relative);
        Uri white_rook = new Uri("images/white_rook.png", UriKind.Relative);


        Uri black_bishop = new Uri("images/black_bishop.png", UriKind.Relative);
        Uri black_king = new Uri("images/black_king.png", UriKind.Relative);
        Uri black_knight = new Uri("images/black_knight.png", UriKind.Relative);
        Uri black_pawn = new Uri("images/black_pawn.png", UriKind.Relative);
        Uri black_queen = new Uri("images/black_queen.png", UriKind.Relative);
        Uri black_rook = new Uri("images/black_rook.png", UriKind.Relative);




        Spot start;
        Spot end;







        public MainWindow(bool startB, bool human)
        {
            this.startB = startB;
            this.human = human;
            reset(startB, human);
        }

        public void reset(bool startB, bool human)
        {
            InitializeComponent();
            if (human)
            {
                p1 = new HumanPlayer(true);
                p2 = new HumanPlayer(false);               
                game.initialize(p1, p2);
            }
            else
            {
                if (!startB)
                {
                    p1 = new ComputerPlayer(true);
                    p2 = new HumanPlayer(false);
                    game.initialize(p1, p2);
                    game.ai();
                }
                else
                {
                    p1 = new HumanPlayer(true);
                    p2 = new ComputerPlayer(false);
                    game.initialize(p1, p2);
                }
            }
            if (game.blackKilledPieces.Count == 0)
            {
                for (int i = 0; i < 16; i++)
                {

                    var a1 = (Button)garbage_can.Children[i];
                    a1.Background = Brushes.Transparent;
                }
            }
            if (game.whiteKilledPieces.Count == 0)
            {
                for (int i = 0; i < 16; i++)
                {
                    var a1 = (Button)garbage_can2.Children[i];
                    a1.Background = Brushes.Transparent;
                }
            }
            game.setStatus(GameStatus.ACTIVE);

            printGrid(null);
        }

        public void printGrid(Spot spot)
        {
            Uri image = white_pawn;
            //print grid
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    var a = (Grid)chess_game.Children[i + j * 8];
                    var b = (Button)a.Children[0];
                    if ((i+j)%2 == 0)
                        a.Background  = new SolidColorBrush(Color.FromRgb(112, 128, 144));
                    else
                        a.Background = new SolidColorBrush(Color.FromRgb(220, 220, 220));
                    Piece piece = game.board.getBox(i, j).getPiece();
                    if (piece != null)
                    {
                        if (piece.isWhite())
                        {
                            if (piece is Pawn)
                                image = white_pawn;
                            else if (piece is King)
                                image = white_king;
                            else if (piece is Queen)
                                image = white_queen;
                            else if (piece is Rook)
                                image = white_rook;
                            else if (piece is Bishop)
                                image = white_bishop;
                            else if (piece is Knight)
                                image = white_knight;
                        }
                        else
                        {
                            if (piece is Pawn)
                                image = black_pawn;
                            else if (piece is King)
                                image = black_king;
                            else if (piece is Queen)
                                image = black_queen;
                            else if (piece is Rook)
                                image = black_rook;
                            else if (piece is Bishop)
                                image = black_bishop;
                            else if (piece is Knight)
                                image = black_knight;
                        }

                        StreamResourceInfo streamInfo= Application.GetResourceStream(image);

                        BitmapFrame temp2 = BitmapFrame.Create(streamInfo.Stream);
                        var brush1 = new ImageBrush();
                        brush1.ImageSource = temp2;

                        b.Background = brush1;

                    }
                    else
                    {
                        if ((i + j) % 2 == 0)
                            b.Background = new SolidColorBrush(Color.FromRgb(112, 128, 144));
                        else
                            b.Background = new SolidColorBrush(Color.FromRgb(220, 220, 220));
                    }

                   

                    if (spot != null && spot.getPiece() != null && spot.getPiece().canMove(game.board, spot, game.board.getBox(i, j)) && game.currentTurn.isWhiteSide() == spot.getPiece().isWhite()) 
                    {
                        a.Background = new SolidColorBrush(Color.FromRgb(255,0,0));
                    }
                }
            }

            
            int index = 0;
            foreach(var item in game.whiteKilledPieces)
            {
                if (item is Pawn)
                    image = white_pawn;
                else if (item is King)
                    image = white_king;
                else if (item is Queen)
                    image = white_queen;
                else if (item is Rook)
                    image = white_rook;
                else if (item is Bishop)
                    image = white_bishop;
                else if (item is Knight)
                    image = white_knight;
                var a1 = (Button)garbage_can2.Children[index];
                StreamResourceInfo streamInfo1 = Application.GetResourceStream(image);

                BitmapFrame temp1 = BitmapFrame.Create(streamInfo1.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp1;

                a1.Background = brush;
                index++;
            }


            int index2 = 0;
            foreach (var item in game.blackKilledPieces)
            {
                if (item is Pawn)
                    image = black_pawn;
                else if (item is King)
                    image = black_king;
                else if (item is Queen)
                    image = black_queen;
                else if (item is Rook)
                    image = black_rook;
                else if (item is Bishop)
                    image = black_bishop;
                else if (item is Knight)
                    image = black_knight;
                var a1 = (Button)garbage_can.Children[index2];
                StreamResourceInfo streamInfo1 = Application.GetResourceStream(image);

                BitmapFrame temp1 = BitmapFrame.Create(streamInfo1.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp1;

                a1.Background = brush;
                index2++;
            }





            //{
            //    y = 0;
            //    for (int i = 0; i < 4; i++)
            //    {
            //        x = 23 + 8 * i + j;
            //    }
            //    y++;

            //}

        }









        private void click(int y, int x)
        {
            if (start == null)
            {
                start = game.board.getBox(y, x);
                List<Board> board = game.board.getNext(game.currentTurn.isWhiteSide());
                printGrid(start);
            }
            else
            {
                end = game.board.getBox(y, x);
                if (game.playerMove(start.getY(), start.getX(), end.getY(), end.getX()))
                {
                    start = null;
                    if (game.currentTurn is ComputerPlayer)
                    {
                        game.ai();
                    }
                    printGrid(null);
                }
                else
                {
                    start = null;
                    click(y, x);
                }
            }
        }

        private void x0y0_Click(object sender, RoutedEventArgs e)
        {
            click(0, 0);
        }

        private void x1y0_Click(object sender, RoutedEventArgs e)
        {
            click(0, 1);
        }

        private void x2y0_Click(object sender, RoutedEventArgs e)
        {
            click(0, 2);
        }

        private void x3y0_Click(object sender, RoutedEventArgs e)
        {
            click(0, 3);
        }

        private void x4y0_Click(object sender, RoutedEventArgs e)
        {
            click(0, 4);
        }

        private void x5y0_Click(object sender, RoutedEventArgs e)
        {
            click(0, 5);
        }

        private void x6y0_Click(object sender, RoutedEventArgs e)
        {
            click(0, 6);
        }

        private void x7y0_Click(object sender, RoutedEventArgs e)
        {
            click(0, 7);
        }

        private void x0y1_Click(object sender, RoutedEventArgs e)
        {
            click(1, 0);
        }

        private void x1y1_Click(object sender, RoutedEventArgs e)
        {
            click(1, 1);
        }

        private void x2y1_Click(object sender, RoutedEventArgs e)
        {
            click(1, 2);
        }

        private void x3y1_Click(object sender, RoutedEventArgs e)
        {
            click(1, 3);
        }

        private void x4y1_Click(object sender, RoutedEventArgs e)
        {
            click(1, 4);
        }

        private void x5y1_Click(object sender, RoutedEventArgs e)
        {
            click(1, 5);
        }

        private void x6y1_Click(object sender, RoutedEventArgs e)
        {
            click(1, 6);
        }

        private void x7y1_Click(object sender, RoutedEventArgs e)
        {
            click(1, 7);
        }

        private void x0y2_Click(object sender, RoutedEventArgs e)
        {
            click(2, 0);
        }

        private void x1y2_Click(object sender, RoutedEventArgs e)
        {
            click(2, 1);
        }

        private void x2y2_Click(object sender, RoutedEventArgs e)
        {
            click(2, 2);
        }

        private void x3y2_Click(object sender, RoutedEventArgs e)
        {
            click(2, 3);
        }

        private void x4y2_Click(object sender, RoutedEventArgs e)
        {
            click(2, 4);
        }

        private void x5y2_Click(object sender, RoutedEventArgs e)
        {
            click(2, 5);
        }

        private void x6y2_Click(object sender, RoutedEventArgs e)
        {
            click(2, 6);
        }

        private void x7y2_Click(object sender, RoutedEventArgs e)
        {
            click(2, 7);
        }

        private void x0y3_Click(object sender, RoutedEventArgs e)
        {
            click(3, 0);
        }

        private void x1y3_Click(object sender, RoutedEventArgs e)
        {
            click(3, 1);
        }

        private void x2y3_Click(object sender, RoutedEventArgs e)
        {
            click(3, 2);
        }

        private void x3y3_Click(object sender, RoutedEventArgs e)
        {
            click(3, 3);
        }

        private void x4y3_Click(object sender, RoutedEventArgs e)
        {
            click(3, 4);
        }

        private void x5y3_Click(object sender, RoutedEventArgs e)
        {
            click(3, 5);
        }

        private void x6y3_Click(object sender, RoutedEventArgs e)
        {
            click(3, 6);
        }

        private void x7y3_Click(object sender, RoutedEventArgs e)
        {
            click(3, 7);
        }

        private void x0y4_Click(object sender, RoutedEventArgs e)
        {
            click(4, 0);
        }

        private void x1y4_Click(object sender, RoutedEventArgs e)
        {
            click(4, 1);
        }

        private void x2y4_Click(object sender, RoutedEventArgs e)
        {
            click(4, 2);
        }

        private void x3y4_Click(object sender, RoutedEventArgs e)
        {
            click(4, 3);
        }

        private void x4y4_Click(object sender, RoutedEventArgs e)
        {
            click(4, 4);
        }

        private void x5y4_Click(object sender, RoutedEventArgs e)
        {
            click(4, 5);
        }

        private void x6y4_Click(object sender, RoutedEventArgs e)
        {
            click(4, 6);
        }

        private void x7y4_Click(object sender, RoutedEventArgs e)
        {
            click(4, 7);
        }

        private void x0y5_Click(object sender, RoutedEventArgs e)
        {
            click(5,0 );
        }

        private void x1y5_Click(object sender, RoutedEventArgs e)
        {
            click(5, 1);
        }

        private void x2y5_Click(object sender, RoutedEventArgs e)
        {
            click(5, 2);
        }

        private void x3y5_Click(object sender, RoutedEventArgs e)
        {
            click(5, 4);
        }

        private void x4y5_Click(object sender, RoutedEventArgs e)
        {
            click(5, 4);
        }

        private void x5y5_Click(object sender, RoutedEventArgs e)
        {
            click(5, 5);
        }

        private void x6y5_Click(object sender, RoutedEventArgs e)
        {
            click(5, 6);
        }

        private void x7y5_Click(object sender, RoutedEventArgs e)
        {
            click(5, 7);
        }

        private void x0y6_Click(object sender, RoutedEventArgs e)
        {
            click(6,0);
        }

        private void x1y6_Click(object sender, RoutedEventArgs e)
        {
            click(6,1);
        }

        private void x2y6_Click(object sender, RoutedEventArgs e)
        {
            click(6, 2);
        }

        private void x3y6_Click(object sender, RoutedEventArgs e)
        {
            click(6, 3);
        }

        private void x4y6_Click(object sender, RoutedEventArgs e)
        {
            click(6, 4);
        }

        private void x5y6_Click(object sender, RoutedEventArgs e)
        {
            click(6,5);
        }

        private void x6y6_Click(object sender, RoutedEventArgs e)
        {
            click(6,6);
        }

        private void x7y6_Click(object sender, RoutedEventArgs e)
        {
            click(6,7);
        }

        private void x0y7_Click(object sender, RoutedEventArgs e)
        {
            click(7, 0);
        }

        private void x1y7_Click(object sender, RoutedEventArgs e)
        {
            click(7, 1);
        }

        private void x2y7_Click(object sender, RoutedEventArgs e)
        {
            click(7, 2);
        }

        private void x3y7_Click(object sender, RoutedEventArgs e)
        {
            click(7, 3);
        }

        private void x4y7_Click(object sender, RoutedEventArgs e)
        {
            click(7, 4);
        }

        private void x5y7_Click(object sender, RoutedEventArgs e)
        {
            click(7, 5);
        }

        private void x6y7_Click(object sender, RoutedEventArgs e)
        {
            click(7, 6);
        }

        private void x7y7_Click(object sender, RoutedEventArgs e)
        {
            click(7,7);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            reset(startB, human);
        }
    }
}
