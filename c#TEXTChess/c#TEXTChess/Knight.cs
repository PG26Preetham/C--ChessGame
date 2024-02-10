using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    internal class Knight : BasePiece
    {


        public override bool Move(Grid startPoint, Grid endPoint)
        {


            return true;
        }

        public override Grid[] GetLegalMoves()
        {



            return new Grid[2];
        }
    }
}
