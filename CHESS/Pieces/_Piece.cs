using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    abstract public class Piece
    {

        private bool white = false;
        public Piece(bool white)
        {
            this.setWhite(white);
        }
        public bool isWhite()
        {
            return this.white;
        }
        public void setWhite(bool white)
        {
            this.white = white;
        }
        public abstract bool canMove(Board board,
                                    Spot start, Spot end);
        public abstract int value();

    }
}
