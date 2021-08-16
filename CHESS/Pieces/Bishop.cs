using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    public class Bishop : Piece
    {
        public Bishop(bool white) : base(white) { }



        public override bool canMove(Board board, Spot start,
                                           Spot end)
        {
            // we can't move the piece to a spot that has
            // a piece of the same colour
            if (end.getPiece() != null && end.getPiece().isWhite() == this.isWhite())
            {
                return false;
            }
            return Math.Abs(end.getX() - start.getX()) == Math.Abs(end.getY() - start.getY()) && board.cleared(start.getX(), start.getY(), end.getX(), end.getY());
        }


        public override void print()
        {
            if (this.isWhite())
            {
                Console.Write(" BISHOP ");
            }
            else
            {
                Console.Write(" bishop ");
            }
        }
    }
}
