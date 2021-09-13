using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    //BEST GAME EVER
    public enum GameStatus
    {
        ACTIVE,
        BLACK_WIN,
        WHITE_WIN,
        FORFEIT,
        STALEMATE,
        RESIGNATION
    }
    public struct killed
    {
        public Piece piece;
        public bool white;
    }

    public class Game
    {
        public Player[] players;
        private GameStatus status;
        private List<Move> movesPlayed ;
        public List<killed> whiteKilledPieces;
        public List<killed> blackKilledPieces;
        public Board board;
        public Player currentTurn;

        public void initialize(Player p1, Player p2)
        {
           
            movesPlayed = new List<Move>();
            whiteKilledPieces = new List<killed>();
            blackKilledPieces = new List<killed>();
            players = new Player[2];
            players[0] = p1;
            players[1] = p2;

            board = new Board();
            board.resetBoard();

            this.currentTurn = p1;

            //movesPlayed.Clear();
        }

        public bool isEnd()
        {
            return getStatus() != GameStatus.ACTIVE;
        }

        public GameStatus getStatus()
        {
            return status;
        }

        public void setStatus(GameStatus status)
        {
            this.status = status;
        }

        public bool playerMove(int startY,
                                    int startX, int endY, int endX)
        {
            Spot startBox = board.getBox(startY, startX);
            Spot endBox = board.getBox(endY, endX);
            Move move = new Move(currentTurn, startBox, endBox);
            return makeMove(move, currentTurn);
        }

        private bool makeMove(Move move, Player player)
        {
            Piece sourcePiece = move.getStart().getPiece(),
                  destPiece = move.getEnd().getPiece();

            if (sourcePiece == null)
            {
                return false;
            }

            // valid player
            if (player != currentTurn)
            {
                return false;
            }

            if (sourcePiece.isWhite() != player.isWhiteSide())
            {
                return false;
            }

            // valid move?
            if (!sourcePiece.canMove(board, move.getStart(),
                                                move.getEnd()))
            {
                return false;
            }


            if (destPiece != null)
            {
                destPiece.setKilled(true);
                move.setPieceKilled(destPiece);
                killed kPiece;
                kPiece.piece = move.getEnd().getPiece();
                kPiece.white = move.getEnd().getPiece().isWhite();
                if (kPiece.white)
                {
                    whiteKilledPieces.Add(kPiece);
                }
                else
                {
                    blackKilledPieces.Add(kPiece);
                }
            }

            Spot rookmove;
            // castling
            if (sourcePiece != null && sourcePiece is King
            && !move.isCastlingMove())
            {
                move.setCastlingMove(true);
                if (move.getStart().getX() > move.getEnd().getX())
                {
                    rookmove = board.getBox(move.getStart().getY(), 0);
                    board.getBox(move.getStart().getY(), 3).setPiece(rookmove.getPiece());
                    rookmove.setPiece(null);
                }
                else
                {
                    rookmove = board.getBox(move.getStart().getY(), 7);
                    board.getBox(move.getStart().getY(), 5).setPiece(rookmove.getPiece());
                    rookmove.setPiece(null);
                }
            }

            // store the move
            //movesPlayed.Add(move);

            // move piece from the stat box to end box
            move.getEnd().setPiece(move.getStart().getPiece());
            move.getStart().setPiece(null);

            if (destPiece != null && destPiece is King)
            {
                if (player.isWhiteSide())
                {
                    setStatus(GameStatus.WHITE_WIN);
                }
                else
                {
                    setStatus(GameStatus.BLACK_WIN);
                }
            }

            // set the current turn to the other player
            if (currentTurn == players[0])
            {
                currentTurn = players[1];
            }
            else
            {
                currentTurn = players[0];
            }

            movesPlayed.Add(move);



            if(currentTurn is ComputerPlayer)
            {
                ai();
                if (currentTurn == players[0])
                {
                    currentTurn = players[1];
                }
                else
                {
                    currentTurn = players[0];
                }
            }


            return true;
        }


        public void ai()
        {
            //return abmax(gm, DEPTH, game.LOSS - 1, game.VICTORY + 1)[1];
        }




        /*
                VICTORY = 10 ** 20  # The value of a winning board (for max)
                LOSS = -VICTORY  # The value of a losing board (for min)

                struct helper{
                    public int value;
                    public Board board;
                }


                public List<Board> getNext(Board board);

                public helper abmin(depth,a,b);

                public value()






                public helper abmax(depth,a,b){

                    if d == 0 or game.isFinished(gm):
                        return [game.value(gm), 0]
    
                    double v = double.PositiveInfinity;

                    ns = game.getNext(gm)
                    bestMove = 0
                    for st in ns:
                        tmp = abmax(st, d - 1, a, b)
                        if tmp[0] < v:
                            v = tmp[0]
                            bestMove = st
                        if v <= a:
                            return [v, st]
                    return [v, bestMove]



        */


    }
}
