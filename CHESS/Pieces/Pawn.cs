using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    public class Pawn : Piece
    {
        public Pawn(bool white) : base(white) { }

        public override bool canMove(Board board, Spot start,
                                           Spot end)
        {
            int distY = end.getY() - start.getY();
            int distX = end.getX() - start.getX();


            if (start.getPiece().isWhite())
            {
                if ((start.getY() == 1 && (distY == 1 || distY == 2)) && distX == 0 && end.getPiece() == null)
                {
                    return true;
                }
                else if ((start.getY() >= 2 && distY == 1) && distX == 0 && end.getPiece() == null)
                {
                    return true;
                }
                else if (Math.Abs(distY) == 1 && Math.Abs(distX) == 1 && end.getPiece() != null && end.getPiece().isWhite() != this.isWhite())
                {
                    return true;
                }
            }

            else if (!start.getPiece().isWhite())
            {

                if ((start.getY() == 6 && distY == -1 || distY == -2) && distX == 0 && end.getPiece() == null)
                {
                    return true;
                }
                else if ((start.getY() <= 6 && distY == -1) && distX == 0 && end.getPiece() == null)
                {
                    return true;
                }
                else if (distY == -1 && Math.Abs(distX) == 1 && end.getPiece()!=null && end.getPiece().isWhite() != this.isWhite())
                {
                    return true;
                }
            }
            return false;
        }


        public override void print()
        {
            if (this.isWhite())
            {
                Console.Write("  PAWN  ");
            }
            else
            {
                Console.Write("  pawn  ");
            }
        }
    }
}
