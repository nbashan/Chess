﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    public class Move
    {
        private Spot start;
        private Spot end;
        private bool castlingMove = false;

        public Move(Spot start, Spot end)
        {
            this.start = start;
            this.end = end;
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
    }
}