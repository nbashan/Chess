using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    public class Rook : Piece
    {
        public Rook(bool white) : base(white) { }

        public override bool canMove(Board board, Spot start,
                                          Spot end)
        {
            if (end.getPiece() != null && end.getPiece().isWhite() == this.isWhite())
            {
                return false;
            }

            if (
                start.getX() == end.getX() && start.getY() != end.getY() && board.cleared(start.getX(), start.getY(), end.getX(), end.getY())
                ||
                start.getY() == end.getY() && start.getX() != end.getX() && board.cleared(start.getX(), start.getY(), end.getX(), end.getY()))
            {
                return true;
            }
            return false;
        }
    }
}
