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


        public static double[,] factor = new double[,]
       {
            { -5.0, -4.0, -3.0, -3.0, -3.0, -3.0, -4.0, -5.0 },
            { -4.0, -2.0,  0.0,  0.0,  0.0,  0.0, -2.0, -4.0 },
            { -3.0,  0.0,  1.0,  1.5,  1.5,  1.0,  0.0, -3.0 },
            { -3.0,  0.5,  1.5,  2.0,  2.0,  1.5,  0.5, -3.0 },
            { -3.0,  0.0,  1.5,  2.0,  2.0,  1.5,  0.0, -3.0 },
            { -3.0,  0.5,  1.0,  1.5,  1.5,  1.0,  0.5, -3.0 },
            { -4.0, -2.0,  0.0,  0.5,  0.5,  0.0, -2.0, -4.0 },
            { -5.0, -4.0, -3.0, -3.0, -3.0, -3.0, -4.0, -5.0 },
        };

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

        public override int value()
        {
            return 30;
        }
    }
}
