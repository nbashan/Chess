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
            this.setPiece(piece);
            this.setY(y);
            this.setX(x);
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
    }
}
