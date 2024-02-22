using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    internal class Knight : BasePiece
    {
<<<<<<< HEAD
=======
       
        //Overriding the getlegal moves function for posible moves of knight
>>>>>>> 7e6e05ecf3cfc266e9b233e0411c34871eb42924
        public override List<Grid> GetLegalMoves()
        {
            List<Grid> legalMove = new List<Grid>();

            legalMove.Add(new Grid().Initialize(currentPos.x + 2, currentPos.y + 1));
            legalMove.Add(new Grid().Initialize(currentPos.x + 2, currentPos.y - 1));
            legalMove.Add(new Grid().Initialize(currentPos.x - 2, currentPos.y + 1));
            legalMove.Add(new Grid().Initialize(currentPos.x - 2, currentPos.y - 1));
            legalMove.Add(new Grid().Initialize(currentPos.x + 1, currentPos.y + 2));
            legalMove.Add(new Grid().Initialize(currentPos.x - 1, currentPos.y + 2));
            legalMove.Add(new Grid().Initialize(currentPos.x + 1, currentPos.y - 2));
            legalMove.Add(new Grid().Initialize(currentPos.x - 1, currentPos.y - 2));

            legalMove = CheckBounds(legalMove);

            return legalMove;
        }
    }
}
