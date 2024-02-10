using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    internal class Bishop : BasePiece
    {
        public override bool Move(Grid startPoint, Grid endPoint)
        {


            return true;
        }

        public override List<Grid> GetLegalMoves()
        {
            List<Grid> legalMove = new List<Grid>();

            for (int i = 1; i < 8; i++)
            {
                legalMove.Add(new Grid().Initialize(currentPos.x + i, currentPos.y + i));
                legalMove.Add(new Grid().Initialize(currentPos.x + i, currentPos.y - i));
                legalMove.Add(new Grid().Initialize(currentPos.x - i, currentPos.y + i));
                legalMove.Add(new Grid().Initialize(currentPos.x - i, currentPos.y - i));
            }

            legalMove = CheckBounds(legalMove);

            return legalMove;
        }
    }
}
