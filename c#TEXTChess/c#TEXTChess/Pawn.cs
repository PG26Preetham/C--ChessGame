using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    internal class Pawn : BasePiece
    {
        Grid elPesgrid;
        public bool bHasElPes=false;
        

        public void SetElPes()
        {
            int direction = 1;
            if (team == ETeam.Black) { direction = -1; }
            elPesgrid = new Grid().Initialize(currentPos.x, currentPos.y + direction);
            bHasElPes = true;
        }
        public override List<Grid> GetLegalMoves()
        {
            List<Grid> legalMove = new List<Grid>();
            int direction = 1;
            if (team == ETeam.Black) { direction = -1; }
           

            legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y + direction));
            if(bHasMoved==false)
            {
                legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y + (2*direction)));
                
            }


            if(board.FindPieceAtGrid(new Grid().Initialize(currentPos.x+1, currentPos.y + direction)).team != team)
            {
                legalMove.Add(new Grid().Initialize(currentPos.x+1, currentPos.y + direction));
            }


            if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x - 1, currentPos.y + direction)).team != team)
            {
                legalMove.Add(new Grid().Initialize(currentPos.x - 1, currentPos.y + direction));
            }

            legalMove = CheckBounds(legalMove);

            return legalMove;
        }
    }
}
