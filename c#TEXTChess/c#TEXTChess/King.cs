using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    internal class King : BasePiece
    {
        public override bool Move(Grid startPoint, Grid endPoint)
        {


            return true;
        }

        public override List<Grid> GetLegalMoves()
        {
            List<Grid> legalMove = new List<Grid>();
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
