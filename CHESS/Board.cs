﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    public class Board
    {
        Spot[,] boxes;

        public Board()
        {
            this.resetBoard();
        }

        public Spot getBox(int y, int x)
        {

            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                throw new Exception("Index out of bound");
            }

            return boxes[y, x];
        }

        public bool cleared(int startX, int startY, int endX, int endY)
        {
            int dx = 1;
            int dy = 1;
            if (startX > endX)
            {
                dx = -1;
            }
            if (startY > endY)
            {
                dy = -1;
            }
            if (startX == endX)
            {
                if (dy == 1)
                {
                    for (int i = startY + dy; i < endY; i += dy)
                    {
                        if (this.boxes[i, startX].getPiece() != null)
                            return false;
                    }
                }
                else
                {
                    for (int i = startY + dy; i > endY; i += dy)
                    {
                        if (this.boxes[i, startX].getPiece() != null)
                            return false;
                    }
                }
            }
            else if (startY == endY)
            {
                if (dx == 1)
                {
                    for (int j = startX + dx; j < endX; j += dx)
                    {
                        if (this.boxes[startY, j].getPiece() != null)
                            return false;
                    }
                }
                else
                {
                    for (int j = startX + dx; j > endX; j += dx)
                    {
                        if (this.boxes[startY, j].getPiece() != null)
                            return false;
                    }
                }
            }
            else if (Math.Abs(endX - startX) == Math.Abs(endY - startY))
            {
                if (dx == 1)
                {
                    for (int i = startX + dx, j = startY + dy; i < endX; i += dx, j += dy)
                    {
                        if (this.boxes[j, i].getPiece() != null)
                            return false;
                    }
                }
                else
                {
                    for (int i = startX + dx, j = startY + dy; i > endX; i += dx, j += dy)
                    {
                        if (this.boxes[j, i].getPiece() != null)
                            return false;
                    }
                }

            }
            return true;
        }

        public void resetBoard()
        {
            // initialize white pieces
            boxes = new Spot[8, 8];

            boxes[0, 0] = new Spot(0, 0, new Rook(true));
            boxes[0, 1] = new Spot(0, 1, new Knight(true));
            boxes[0, 2] = new Spot(0, 2, new Bishop(true));
            boxes[0, 3] = new Spot(0, 3, new Queen(true));
            boxes[0, 4] = new Spot(0, 4, new King(true));
            boxes[0, 5] = new Spot(0, 5, new Bishop(true));
            boxes[0, 6] = new Spot(0, 6, new Knight(true));
            boxes[0, 7] = new Spot(0, 7, new Rook(true));

            boxes[1, 0] = new Spot(1, 0, new Pawn(true));
            boxes[1, 1] = new Spot(1, 1, new Pawn(true));
            boxes[1, 2] = new Spot(1, 2, new Pawn(true));
            boxes[1, 3] = new Spot(1, 3, new Pawn(true));
            boxes[1, 4] = new Spot(1, 4, new Pawn(true));
            boxes[1, 5] = new Spot(1, 5, new Pawn(true));
            boxes[1, 6] = new Spot(1, 6, new Pawn(true));
            boxes[1, 7] = new Spot(1, 7, new Pawn(true));


            // initialize black pieces



            boxes[7, 0] = new Spot(7, 0, new Rook(false));
            boxes[7, 1] = new Spot(7, 1, new Knight(false));
            boxes[7, 2] = new Spot(7, 2, new Bishop(false));
            boxes[7, 3] = new Spot(7, 3, new Queen(false));
            boxes[7, 4] = new Spot(7, 4, new King(false));
            boxes[7, 5] = new Spot(7, 5, new Bishop(false));
            boxes[7, 6] = new Spot(7, 6, new Knight(false));
            boxes[7, 7] = new Spot(7, 7, new Rook(false));
            //...
            boxes[6, 0] = new Spot(6, 0, new Pawn(false));
            boxes[6, 1] = new Spot(6, 1, new Pawn(false));
            boxes[6, 2] = new Spot(6, 2, new Pawn(false));
            boxes[6, 3] = new Spot(6, 3, new Pawn(false));
            boxes[6, 4] = new Spot(6, 4, new Pawn(false));
            boxes[6, 5] = new Spot(6, 5, new Pawn(false));
            boxes[6, 6] = new Spot(6, 6, new Pawn(false));
            boxes[6, 7] = new Spot(6, 7, new Pawn(false));



            // initialize remaining boxes without any piece
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    boxes[i, j] = new Spot(i, j, null);
                }
            }
        }
    }
}
