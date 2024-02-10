using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    enum ETeam
    {
        White = 0,
        Black
    }

    public struct Grid
    {
        public int x;
        public int y;
    }

    internal class BasePiece
    {
        public ETeam team { private set; get; }
        public Grid currentPos;

        public void Initialize(ETeam team, Grid startPos)
        {
            this.team = team;
            currentPos = startPos;
        }

        public virtual bool Move(Grid startPos, Grid endPos)
        {
            return true;
        }

        public virtual Grid[] GetLegalMoves()
        {
            return new Grid[2];
        }
    }
}
