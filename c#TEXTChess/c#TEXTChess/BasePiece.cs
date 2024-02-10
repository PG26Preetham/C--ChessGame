using c_TEXTChess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

        public Grid Initialize(int x, int y)
        {
            this.x = x;
            this.y = y;

            return this;
        }
    }

    internal class BasePiece
    {
        public ETeam team { private set; get; }
        public Grid currentPos { private set; get; }

    
        public void Initialize(ETeam team, Grid startPos)
        {
            this.team = team;
            currentPos = startPos;
        }

        // I feel like we can remove the "startPos" because it would just be the "currentPos"
        public virtual bool Move(Grid startPos, Grid endPos) { return true; }


        // Virtual function for finding all legal moves
        public virtual List<Grid> GetLegalMoves() { return new List<Grid>(0); }


        // Function for checking if the moves are within the board
        protected List<Grid> CheckBounds(List<Grid> legalMove)
        {
            for (int i = legalMove.Count - 1; i > 0; i--) // Iterating backwards to prevent issues caused by RemoveAt()
            {
                if (legalMove[i].x < 1 || legalMove[i].x > 8 || legalMove[i].y < 1 || legalMove[i].y > 8)
                {
                    legalMove.RemoveAt(i);
                }
            }

            return legalMove;
        }


    }
}

// Put this in {Program.cs} to test

/*BasePiece testPiece = new Rook();
testPiece.Initialize(ETeam.Black, new Grid().Initialize(4, 4));

List<Grid> legalMoves = testPiece.GetLegalMoves();

for (int i = 0; i < testPiece.GetLegalMoves().Count; i++)
{
    Console.Write(legalMoves[i].x);
    Console.Write(" , ");
    Console.WriteLine(legalMoves[i].y);
}*/