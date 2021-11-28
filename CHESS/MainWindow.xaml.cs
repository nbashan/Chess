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
        #region attributes
        Player p1;
        Player p2;
        Game game = new Game();

        bool startB = true;
        bool human = true;

        Spot start;
        Spot end;

        Uri image = new Bishop(true).getImage();

        bool backFlag = true;
        #endregion

        #region ctor
        public MainWindow(bool startB, bool human)
        {
            InitializeComponent();
            this.startB = startB;
            this.human = human;
            reset(startB, human);
        }
        #endregion

        #region functions
        private void printGrid(Spot spot)
        {
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    var buttonsBackground = (Grid)chess_game.Children[i + j * 8];
                    var buttonsPicture = (Button)buttonsBackground.Children[0];

                    if ((i + j) % 2 == 0)
                        buttonsBackground.Background = new SolidColorBrush(Color.FromRgb(112, 128, 144));
                    else
                        buttonsBackground.Background = new SolidColorBrush(Color.FromRgb(220, 220, 220));

                    Piece piece = game.board.getBox(i, j).getPiece();
                    if (piece != null)
                    {
                        image = piece.getImage();

                        StreamResourceInfo streamInfo = Application.GetResourceStream(image);
                        BitmapFrame temp2 = BitmapFrame.Create(streamInfo.Stream);
                        var brush1 = new ImageBrush();
                        brush1.ImageSource = temp2;

                        buttonsPicture.Background = brush1;

                    }
                    else
                    {
                        if ((i + j) % 2 == 0)
                            buttonsPicture.Background = new SolidColorBrush(Color.FromRgb(112, 128, 144));
                        else
                            buttonsPicture.Background = new SolidColorBrush(Color.FromRgb(220, 220, 220));
                    }




                    if (spot != null && spot.getPiece() != null && spot.getPiece().canMove(game.board, spot, game.board.getBox(i, j)) && game.currentTurn.isWhiteSide() == spot.getPiece().isWhite())
                    {
                        buttonsBackground.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    }
                    
                    if(spot!= null && spot.getX() == j && spot.getY() == i)
                    {
                        buttonsBackground.Background = new SolidColorBrush(Color.FromRgb(164, 247, 255));
                    }

                    Move lastMove;
                    if (game.movesPlayed.Count != 0)
                    {
                        lastMove = game.movesPlayed.Last();
                        buttonsBackground = (Grid)chess_game.Children[lastMove.getEnd().getY() + lastMove.getEnd().getX() * 8];
                        buttonsBackground.Background = new SolidColorBrush(Color.FromRgb(255, 210, 50));
                    }

                }
            }

            updateTrash(game.whiteKilledPieces, whiteScoring, garbage_can2);
            updateTrash(game.blackKilledPieces, blackScoring, garbage_can);

            if (game.board.getKingThreatned())
            {
                var a = (Grid)chess_game.Children[game.board.getKingSpot(game.currentTurn.isWhiteSide()).getY() + game.board.getKingSpot(!game.currentTurn.isWhiteSide()).getX() * 8];
                a.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }
        private void reset(bool startB, bool human)
        {
            game.setStatus(GameStatus.ACTIVE);
            finish.Content = "";

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

            clearGarbage(garbage_can);
            clearGarbage(garbage_can2);

            printGrid(null);
        }
        private void clearGarbage(Grid garbage)
        {
            for (int i = 0; i < 16; i++)
            {
                Button button = (Button)garbage.Children[i];
                button.Background = Brushes.Transparent;
            }
        }
        private void updateTrash(List<Piece> pieces, Label scoring,Grid garbage)
        {
            int index = 0;
            int value = 0;
            foreach (var item in pieces)
            {
                value += item.value();
                image = item.getImage();
                var a1 = (Button)garbage.Children[index];
                StreamResourceInfo streamInfo1 = Application.GetResourceStream(image);

                BitmapFrame temp1 = BitmapFrame.Create(streamInfo1.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp1;

                a1.Background = brush;
                index++;
            }
            scoring.Content = value;
        }
        private void finishGame()
        {
            if(game.getStatus() == GameStatus.BLACK_WIN)
            {
                finish.Content = "BLACK WINS";
            }
            else if (game.getStatus() == GameStatus.WHITE_WIN)
            {
                finish.Content = "WHITE WINS";
            }
            else if (game.getStatus() == GameStatus.FORFEIT)
            {
                finish.Content = "FORFEIT";
            }
            else if (game.getStatus() == GameStatus.RESIGNATION)
            {
                finish.Content = "RESIGNATION";
            }
            else if (game.getStatus() == GameStatus.STALEMATE)
            {
                finish.Content = "STALEMATE";
            }
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        { 
            reset(startB, human);
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (game.movesPlayed.Count != 0)
            {
                Move move = game.movesPlayed.Last();
                game.movesPlayed.RemoveAt(game.movesPlayed.Count() - 1);

                Spot start = game.board.getBox(move.getStart().getY(), move.getStart().getX());
                Spot end = game.board.getBox(move.getEnd().getY(), move.getEnd().getX());
                start.setPiece(move.getStart().getPiece());
                end.setPiece(move.getEnd().getPiece());

                if(move.getEnd().getPiece() != null)
                {
                    if (move.getEnd().getPiece().isWhite())
                    {
                        game.whiteKilledPieces.RemoveAt(game.whiteKilledPieces.Count() - 1);
                    }
                    else
                    {
                        game.blackKilledPieces.RemoveAt(game.blackKilledPieces.Count() - 1);
                    }
                }


                game.switchTurn();
                if (!human && backFlag)
                {
                    backFlag = false;
                    Back_Click(sender, e);
                }
                backFlag = true;

                clearGarbage(garbage_can);
                clearGarbage(garbage_can2);

                printGrid(null);
            }
        }
        private void click(int y, int x)
        {
            if (start == null)
            {
                start = new Spot(game.board.getBox(y, x).getY(), game.board.getBox(y, x).getX(), game.board.getBox(y, x).getPiece());
                printGrid(start);
            }
            else
            {
                end = game.board.getBox(y, x);
                if (game.playerMove(start.getY(), start.getX(), end.getY(), end.getX()))
                {
                    start = null;
                    if (game.getStatus() != GameStatus.ACTIVE)
                    {
                        finishGame();
                    }
                    if (game.currentTurn is ComputerPlayer)
                    {
                        game.ai();
                    }
                    if (game.getStatus() != GameStatus.ACTIVE)
                    {
                        finishGame();
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
        #endregion

        #region board buttons
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
            click(5, 0);
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
            click(5, 3);
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
            click(6, 0);
        }

        private void x1y6_Click(object sender, RoutedEventArgs e)
        {
            click(6, 1);
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
            click(6, 5);
        }

        private void x6y6_Click(object sender, RoutedEventArgs e)
        {
            click(6, 6);
        }

        private void x7y6_Click(object sender, RoutedEventArgs e)
        {
            click(6, 7);
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
            click(7, 7);
        }
        #endregion

        private void home_Click(object sender, RoutedEventArgs e)
        {
            new Start().Show();
            this.Close();
        }
    }
}
