using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    internal class Rook : BasePiece
    {
        public override bool Move(Grid startPoint, Grid endPoint)
        {


            return true;
        }

        public override List<Grid> GetLegalMoves()
        {
            List<Grid> legalMove = new List<Grid>();

            //for (int i = 0; i < 8; i++)
            //{
            //    legalMove.Add(new Grid().Initialize(currentPos.x + i, currentPos.y));
            //    legalMove.Add(new Grid().Initialize(currentPos.x - i, currentPos.y));
            //    legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y + i));
            //    legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y - i));
            //}

            //max i guess we will have to do the logic for all teh stright line mover like this for queen bishop and rook
            for (int i = 0;i<8;i++)
            {
                if(board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + i, currentPos.y))==null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x + i, currentPos.y));
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x - i, currentPos.y)) == null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x - i, currentPos.y));
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y+1)) == null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y+1));
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y - 1)) == null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y - 1));
                }
                else
                {
                    break;
                }
            }



            legalMove = CheckBounds(legalMove);

            return legalMove;
        }
    }
}
