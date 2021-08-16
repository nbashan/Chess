using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    public class Knight : Piece
    {
        public Knight(bool white) : base(white) { }

        public override bool canMove(Board board, Spot start,
                                            Spot end)
        {
            // we can't move the piece to a spot that has
            // a piece of the same colour
            if (end.getPiece() != null && end.getPiece().isWhite() == this.isWhite())
            {
                return false;
            }

            int x = Math.Abs(start.getX() - end.getX());
            int y = Math.Abs(start.getY() - end.getY());
            return x * y == 2;
        }



        public override void print()
        {
            if (this.isWhite())
            {
                Console.Write(" KNIGHT ");
            }
            else
            {
                Console.Write(" knight ");
            }
        }
    }
}
