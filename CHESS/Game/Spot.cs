using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    public class Spot
    {
        private Piece piece;
        private int x;
        private int y;

        public Spot(int y, int x, Piece piece)
        {
            setPiece(piece);
            setY(y);
            setX(x);
        }
        public Piece getPiece()
        {
            return this.piece;
        }
        public void setPiece(Piece p)
        {
            this.piece = p;
        }
        public int getX()
        {
            return this.x;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public int getY()
        {
            return this.y;
        }
        public void setY(int y)
        {
            this.y = y;
        }

        public List<Board> getNext(Board board,bool white)
        {
            List<Board> ret = new List<Board>();
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (getPiece().canMove(board, this, board.getBox(i, j)) && getPiece().isWhite() == white)
                    {
                        
                        Board boardCopy = new Board(board,new Move(this,board.getBox(i,j)));
                        if (boardCopy.getBox(i, j).getPiece() is King)
                        {
                            boardCopy.finished = true;
                        }
                        boardCopy.getBox(i, j).setPiece(getPiece());
                        boardCopy.getBox(getY(), getX()).setPiece(null);
                        ret.Add(boardCopy);
                    }
                }
            }
            return ret;
        }
    }
}
