﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    public class King : Piece
    {
        private bool castlingDone = false;

        public static double[,] factor = new double[,]
      {
            { -3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0 },
            { -3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0 },
            { -3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0 },
            { -3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0 },
            { -2.0, -3.0, -3.0, -4.0, -4.0, -3.0, -3.0, -2.0 },
            { -1.0, -2.0, -2.0, -2.0, -2.0, -2.0, -2.0, -1.0 },
            {  2.0,  2.0,  0.0,  0.0,  0.0,  0.0,  2.0,  2.0 },
            {  2.0,  3.0,  1.0,  0.0,  0.0,  1.0,  3.0,  2.0 },
       };




        public King(bool white) : base(white)
        {
        }

        public bool isCastlingDone()
        {
            return this.castlingDone;
        }

        public void setCastlingDone(bool castlingDone)
        {
            this.castlingDone = castlingDone;
        }

        public override bool canMove(Board board, Spot start, Spot end)
        {
            // we can't move the piece to a Spot that
            // has a piece of the same color
            if (end.getPiece() != null && end.getPiece().isWhite() == this.isWhite())
            {
                return false;
            }

            int x = Math.Abs(start.getX() - end.getX());
            int y = Math.Abs(start.getY() - end.getY());
            if (x + y == 1 || (x==1 && y==1))
            {
                // check if this move will not result in the king
                // being attacked if so return true
                return true;
            }

            return this.isValidCastling(board, start, end);
        }

        private bool isValidCastling(Board board,
                                        Spot start, Spot end)
        {
            int rookX;
            if (start.getX() > end.getX())
            {
                rookX = 0;
            }
            else
                rookX = 7;
            if (this.isCastlingDone())
            {
                return false;
            }

            if (!isCastlingMove(start, end))
            {
                return false;
            }
            if (!board.cleared(start.getX(), start.getY(), rookX, end.getY()))
            {
                return false;
            }
            return true;
        }

        public bool isCastlingMove(Spot start, Spot end)
        {
            if (this.isCastlingDone())
            {
                return false;
            }
            // check if the starting and
            // ending position are correct
            if (end.getY() != start.getY())
            {
                return false;
            }
            if (end.getY() != 0 && end.getY() != 7)
                return false;
            return true;
        }

        public override int value()
        {
            return 10000;
        }

    }
}
