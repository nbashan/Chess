using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    public enum GameStatus
    {
        ACTIVE,
        BLACK_WIN,
        WHITE_WIN,
        FORFEIT,
        STALEMATE,
        RESIGNATION
    }

    public class Game
    {
        private Player[] players;
        public Board board;
        private Player currentTurn;
        private GameStatus status;
        private List<Move> movesPlayed;

        public void initialize(Player p1, Player p2)
        {
            players = new Player[2];
            players[0] = p1;
            players[1] = p2;

            board = new Board();
            board.resetBoard();

            if (p1.isWhiteSide())
            {
                this.currentTurn = p1;
            }
            else
            {
                this.currentTurn = p2;
            }

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
        public void printGrid()
        {
            Piece piece;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    

                }
            }
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

            return true;
        }


    }
}
