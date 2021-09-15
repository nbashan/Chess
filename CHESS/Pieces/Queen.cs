using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    public class Queen : Piece
    {
        public Queen(bool white) : base(white) { }

        public static double[,] factor = new double[,]
       {
            { -2.0, -1.0, -1.0, -0.5, -0.5, -1.0, -1.0, -2.0 },
            { -1.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -1.0 },
            { -1.0,  0.0,  0.5,  0.5,  0.5,  0.5,  0.0, -1.0 },
            { -0.5,  0.0,  0.5,  0.5,  0.5,  0.5,  0.0, -0.5 },
            {  0.0,  0.0,  0.5,  0.5,  0.5,  0.5,  0.0, -0.5 },
            { -1.0,  0.5,  0.5,  0.5,  0.5,  0.5,  0.0, -1.0 },
            { -1.0,  0.0,  0.5,  0.0,  0.0,  0.0,  0.0, -1.0 },
            { -2.0, -1.0, -1.0, -0.5, -0.5, -1.0, -1.0, -2.0 },
        };

        public override bool canMove(Board board, Spot start,
                                           Spot end)
        {
            bool isWhite = start.getPiece().isWhite();
            Bishop bishop = new Bishop(isWhite);
            Rook rook = new Rook(isWhite);
            return bishop.canMove(board, start, end) || rook.canMove(board, start, end);
        }

        public override int value()
        {
            return 90;
        }

    }
}
