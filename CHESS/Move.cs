using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    public class Move
    {
        private Player player;
        private Spot start;
        private Spot end;
        private Piece pieceMoved;
        private Piece pieceKilled;
        private bool castlingMove = false;

        public Move(Player player, Spot start, Spot end)
        {
            this.player = player;
            this.start = start;
            this.end = end;
            this.pieceMoved = start.getPiece();
        }

        public bool isCastlingMove()
        {
            return this.castlingMove;
        }

        public void setCastlingMove(bool castlingMove)
        {
            this.castlingMove = castlingMove;
        }

        public Spot getStart()
        {
            return start;
        }
        public void setStart(Spot setter)
        {
            start = setter;
        }

        public Spot getEnd()
        {
            return end;
        }

        public void setPieceKilled(Piece piece)
        {
            pieceKilled = piece;
            piece.setKilled(true);
        }
    }
}
