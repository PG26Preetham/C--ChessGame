using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    internal class Pawn : BasePiece
    {
        Grid enPasGrid;
        public bool bHasEnPas=false;
        

        public void SetEnPas()
        {
            int direction = 1;
            if (team == ETeam.Black) { direction = -1; }
            enPasGrid = new Grid().Initialize(currentPos.x, currentPos.y + direction);
            bHasEnPas = true;
        }
        public override List<Grid> GetLegalMoves()
        {
            List<Grid> legalMove = new List<Grid>();
            int direction = -1;
            if (team == ETeam.Black) { direction = 1; }
            else { direction = -1; }
           

            legalMove.Add(new Grid().Initialize(currentPos.x + direction, currentPos.y));

            if(bHasMoved==false)
            {
                if(board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + (2 * direction), currentPos.y))==null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x + (2 * direction), currentPos.y));
                }
                         
            }
            if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x+ direction, currentPos.y + 1 )) != null)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + direction, currentPos.y + 1)).team != team)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x +direction, currentPos.y +1));
                }
            }

            if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + direction, currentPos.y - 1)) != null)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + direction, currentPos.y - 1)).team != team)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x + direction, currentPos.y - 1));
                }
            }

            legalMove = CheckBounds(legalMove);

            return legalMove;
        }
    }
}
