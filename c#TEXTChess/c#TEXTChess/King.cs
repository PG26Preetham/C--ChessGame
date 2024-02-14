using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    internal class King : BasePiece
    {
        public bool isBeingChecked = false;
        public bool canKingSideCastle = false;
        public bool canQueenSideCastle = false;

        public void CheckChecks()
        {
            if (!board.IsGridSafe(new Grid().Initialize(currentPos.x, currentPos.y), team))
            {
                isBeingChecked = true;
            }
            else
            {
                isBeingChecked = false;
            }
        }

        public void CheckCheckmate()
        {

        }

        public void CheckCastle()
        {
            if (bHasMoved || isBeingChecked) return;

            for (int i = 1; i < 3; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x - i, currentPos.y)) != null) return;
                if (!board.IsGridSafe((new Grid().Initialize(currentPos.x - i, currentPos.y)), team)) return;          
            }
            for (int i = 1; i < 2; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + i, currentPos.y)) != null) return;
                if (!board.IsGridSafe((new Grid().Initialize(currentPos.x + i, currentPos.y)), team)) return;
            }      

            if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x - 4, currentPos.y)) != null)
            {
                BasePiece p = board.FindPieceAtGrid(new Grid().Initialize(currentPos.x - 4, currentPos.y));
                if (!p.bHasMoved) canQueenSideCastle = true;
                
            }
            if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + 3, currentPos.y)) != null)
            {
                BasePiece p = board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + 3, currentPos.y));
                if (!p.bHasMoved) canKingSideCastle = true;
            }
        }


        public override List<Grid> GetLegalMoves()
        {
            List<Grid> legalMove = new List<Grid>();

            if (!bHasMoved)
            {
                CheckChecks();
                CheckCastle();

                if (canKingSideCastle) legalMove.Add(new Grid().Initialize(currentPos.x + 2, currentPos.y));
                if (canQueenSideCastle) legalMove.Add(new Grid().Initialize(currentPos.x - 2, currentPos.y));
            } 

            legalMove.Add(new Grid().Initialize(currentPos.x + 1, currentPos.y));
            legalMove.Add(new Grid().Initialize(currentPos.x -1, currentPos.y));
            legalMove.Add(new Grid().Initialize(currentPos.x +1, currentPos.y+1));
            legalMove.Add(new Grid().Initialize(currentPos.x -1, currentPos.y+1));
            legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y+1));
            legalMove.Add(new Grid().Initialize(currentPos.x + 1, currentPos.y-1));
            legalMove.Add(new Grid().Initialize(currentPos.x - 1, currentPos.y-1));
            legalMove.Add(new Grid().Initialize(currentPos.x , currentPos.y-1));
            legalMove = CheckBounds(legalMove);

            return legalMove;
        }
    }
}
