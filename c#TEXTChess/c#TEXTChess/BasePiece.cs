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

        public Board board;
    
        public void Initialize(ETeam team, Grid startPos ,Board BoardRef)
        {
            this.team = team;
            currentPos = startPos;
            board = BoardRef;
        }

        // I feel like we can remove the "startPos" because it would just be the "currentPos" [Done]
        public  bool Move(Grid endPos) 
        {
            List<Grid> list = new List<Grid>();
            list = GetLegalMoves();
            for(int i=0;i<list.Count; i++)
            {
                if (list[i].x == endPos.x && list[i].y == endPos.y)
                {
                    return true;
                }
               
            }
            return false;
        }


        // Virtual function for finding all legal moves
        public virtual List<Grid> GetLegalMoves() { return new List<Grid>(0); }


        // Function for checking if the moves are within the board
        protected List<Grid> CheckBounds(List<Grid> legalMove)
        {
            for (int i = legalMove.Count - 1; i > 0; i--) // Iterating backwards to prevent issues caused by RemoveAt()
            {
                if (legalMove[i].x < 1 || legalMove[i].x > board.BoardSize || legalMove[i].y < 1 || legalMove[i].y > board.BoardSize)
                {
                    legalMove.RemoveAt(i);
                } // Added a null check to prevent crash for now
                else if ((board.FindPieceAtGrid(legalMove[i]) != null && board.FindPieceAtGrid(legalMove[i]).team == team)) //made this so if there is a piece of the same team the move is invalid
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