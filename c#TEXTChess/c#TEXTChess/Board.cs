using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    // Board class to represent the the board display and coordinates
    internal class Board
    {
        //
        List<BasePiece> AllPiecesOnBoard = new List<BasePiece>();
        public int BoardSize = 8;


        public void MovePiece(BasePiece piece , Grid toLocation)
        {
            if(piece.Move(toLocation))
            {
                if(FindPieceAtGrid(toLocation)!=null && piece.team != FindPieceAtGrid(toLocation).team)
                {
                    //remove the piece on the board first 
                }
                try
                {
                    Pawn p = (Pawn)piece;
                    if (p != null)
                    {
                        if (!p.bHasMoved)
                        {
                            if(p.currentPos.x-toLocation.x == 2 || p.currentPos.x - toLocation.x == -2)
                            {
                                p.SetElPes();
                            }
                        }
                        else
                        {
                            p.bHasElPes = false;
                        }
                    }
                }
                catch(Exception e)
                {

                }
                // move the piece to the location
                piece.bHasMoved = true;
              
            }
        }

        public BasePiece FindPieceAtGrid(Grid grid)
        {
            for (int i = 0; i < AllPiecesOnBoard.Count; i++)
            {
                if (AllPiecesOnBoard[i].currentPos.x == grid.x && AllPiecesOnBoard[i].currentPos.y == grid.y)
                {
                    return AllPiecesOnBoard[i];
                }
            }
            return null;
        }
        //public int[,] BoardArray()
        //{
        //    // initial comment
        //   // return int;
        //}


    }
}
